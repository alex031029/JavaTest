using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Auth;
using System.Globalization;




namespace PoolCreation
{
    class Program
    {
        // static is required, since they are used in static methods
        private static string batchAccountUrl = "https://vnetireutest.eastus.batch.azure.com";
        private static string batchAccountName = "vnetireutest";
        private static string subscription = "e934ef50-ed58-41de-84db-5f05bc018751";
        public static BatchClient MyCreateBatchClientKey()
        {
            // paste it when using it :)
            string batchKeyValue = "";
            BatchSharedKeyCredentials sharedKeyCredentials = new BatchSharedKeyCredentials(batchAccountUrl, batchAccountName, batchKeyValue);
            BatchClient batchClient = BatchClient.Open(sharedKeyCredentials);
            Console.WriteLine("batchClient To String:" + batchClient.ToString());
            return batchClient;
        }

        public static BatchClient MyCreateBatchClientToken()
        {
            string token = "";
            BatchTokenCredentials tokenCredentials = new BatchTokenCredentials(batchAccountUrl, token);
            return BatchClient.Open(tokenCredentials);
        }
        // internal is to make sure that the class CreatePoolAsync is feasible only in this exe file
        // static is to invoke methods in CreatePoolAync without newing an objet
        // 

        internal static async Task CreatePoolAsync(string poolName)
        {
            var batchClient = MyCreateBatchClientToken();
            try
            {
                // ImageReference and VirtualMachineConfiguration is under Microsoft.Azure.Batch namespace
                var imageReference = new ImageReference("WindowsServer", "MicrosoftWindowsServer", "2019-Datacenter-with-Containers", "latest");//17763.1158.2004131759//17763.557.20190604 //17763.973.2001110547//"2019-Datacenter-with-Containers"
                var vmConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64")
                {
                    ContainerConfiguration = new ContainerConfiguration()
                    {
                        ContainerImageNames = new List<string>() { "mcr.microsoft.com/windows/servercore:ltsc2019" }, //mcr.microsoft.com/windows/servercore:ltsc2019
                    },
                    WindowsConfiguration = new WindowsConfiguration(false),
                    // DiskEncrytionTarget is in under Microsoft.Azure.Batch.Common namespace
                    DiskEncryptionConfiguration = new DiskEncryptionConfiguration(new List<DiskEncryptionTarget> { DiskEncryptionTarget.OsDisk, DiskEncryptionTarget.TemporaryDisk })
                };
                var pool = batchClient.PoolOperations.CreatePool(poolName, "standard_d2_v2", vmConfiguration, 1);


                // set flag
                pool.NetworkConfiguration = new NetworkConfiguration()
                {
                    DynamicVNetAssignmentScope = DynamicVNetAssignmentScope.Job,
                    //SubnetId = "/subscriptions/b371d9e7-d3c2-4b1a-83ec-84e1f50c2222/resourceGroups/ligeng-temp/providers/Microsoft.Network/virtualNetworks/ligeng-test-s360/subnets/default"
                    //SubnetId = "/subscriptions/3ee7eaf5-6a2f-49fd-953f-d760b5ac2e05/resourceGroups/ligeng/providers/Microsoft.Network/virtualNetworks/ligengvnet/subnets/poolsubnet"
                };

                // add starttask
                //pool.StartTask = new StartTask();
                //pool.StartTask.CommandLine = StartupCmd;
                //pool.StartTask.UserIdentity = new UserIdentity(new AutoUserSpecification(AutoUserScope.Task, ElevationLevel.Admin) );
                //pool.StartTask.MaxTaskRetryCount = 0;
                //pool.StartTask.WaitForSuccess = true;

                try
                {
                    // ConfigureAwait can be used for preventing from deadlock
                    await pool.CommitAsync().ConfigureAwait(false);
                }
                catch (BatchException ex)
                {
                    if (ex.RequestInformation.HttpStatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        Console.WriteLine("Pool is already created. Pool name: " + poolName);
                        return;
                    }

                    Console.WriteLine(ex);
                    throw;
                }
                Console.WriteLine("Pool Creation succeed. Pool name: " + poolName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        internal static async Task CreateJobAsync(string poolName, string jobName, string subNetId) // TODO add vnet subnet lock info
        {
            var batchClient = MyCreateBatchClientKey();
            try
            {
                PoolInformation pool = new PoolInformation() { PoolId = poolName };
                var job = batchClient.JobOperations.CreateJob(jobName, pool);
                if (!string.IsNullOrEmpty(subNetId))
                {
                    job.NetworkConfiguration = new JobNetworkConfiguration(subNetId);
                }

                await job.CommitAsync(new List<BatchClientBehavior>() { RetryPolicyProvider.NoRetryProvider() }).ConfigureAwait(false);                //
            }
            catch (Exception ex)
            {
                BatchException batchEx = ex as BatchException;
                if (batchEx != null && batchEx.RequestInformation.HttpStatusCode == System.Net.HttpStatusCode.Conflict)
                {

                    var job = await batchClient.JobOperations.GetJobAsync(jobName).ConfigureAwait(false);
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Job already been created, Pool name: {0}, Job name: {1}, subnet: {2} ", job.PoolInformation.PoolId, job.Id, job.NetworkConfiguration?.SubnetId));
                    return;
                }
                // Console.WriteLine(ExtractBatchError(batchEx));
                //throw;
            }
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Job Creation succeed. pool name: {0}, job name: {1}, subnet {2}.", poolName, jobName, subNetId));
        }




        internal static async Task CreateTaskAsync(string jobName, string taskName, string taskCommand)
        {
            try
            {
                var batchClient = MyCreateBatchClientKey();
                // set it!
                string poolName = "d2pool-int2-a";
                PoolInformation pool = new PoolInformation() { PoolId = poolName };
                var job = await batchClient.JobOperations.GetJobAsync(jobName).ConfigureAwait(false);
                var task = new CloudTask(taskName, "cmd /c powershell.exe .\\Validate-Basic.ps1"); ///c powershell.exe .\\Validate-Basic.ps1
                task.UserIdentity = new UserIdentity(new AutoUserSpecification(elevationLevel: ElevationLevel.Admin));

                task.ContainerSettings = new TaskContainerSettings("mcr.microsoft.com/windows/servercore:ltsc2019");//@"-v C:\ADMSTaskExeutor:C:\ADMSTaskExeutor -v C:\mdsshared:C:\mdsshared"//C:\batch\tasks\shared
                task.ResourceFiles = new List<ResourceFile>() { ResourceFile.FromUrl("https://ligengsharedjpw.blob.core.windows.net/public/Validate-Basic.ps1", "Validate-Basic.ps1") };

                //task.CommandLine =
                //    "cmd /c powershell.exe -File \"%AZ_BATCH_NODE_SHARED_DIR%\\Init-Container.ps1\" %AZ_BATCH_NODE_ROOT_DIR% & %AZ_BATCH_NODE_SHARED_DIR%\\TaskExecutor.exe /ShardName:1 /PartitionKey:jobId-8 /RowKey:00033819-1dda-3300-ea2c-a38115d5da6700033819-1dda-3300-ea2c-a38115d5da67 /IsLargePayload:False /IsSecondary:False /ActivityId:cdd8636d-2520-4010-b727-d8ec454839e2 /QueueId:4afdb09f-8cfb-4b08-a0bf-8b90a5984067 /MAEXITINSECONDS:120";

                await job.AddTaskAsync(task).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //if (!IsAzureBatchError(ex, BatchErrorCodeStrings.TaskExists))
                //{
                //    throw;
                //}
                Console.WriteLine(ex);
                throw;
            }
        }

        internal static async Task TestAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("TestASync");
            });
            Console.WriteLine("TestSync");
            return;
        }

        // async Task Main is supported after C# 7.1
        // VS 2017 would raise an error if we do not modify csproj file
        static async Task Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            
            Console.WriteLine("Hello World!");
            // var batchClient = MyCreateBatchClientKey();
            // Console.WriteLine(batchClient.CustomBehaviors);
            string poolName = "d2pool-int2-a";
            await CreatePoolAsync(poolName);
            //await TestAsync();
            Console.WriteLine("Good Bye");
            Console.ReadKey();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
