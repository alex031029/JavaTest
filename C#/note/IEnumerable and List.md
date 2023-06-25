# IEnumerable and List

**IEnumerable is read-only and List is not.** 

See such error message

      namespace ExtractReservation
      {
          class Program
          {
              static void Main(string[] args)
              {
                  string IPReservationFilePath = "IPReservationsTableWU_Network_e5f70864-a632-4386-b347-a3ad822b2274.csv";
                  string NetworkContainerFilePath = "NetworkContainerTableWU_Network_e5f70864-a632-4386-b347-a3ad822b2274.csv";
                  var IPReservationFileLines = System.IO.File.ReadLines(IPReservationFilePath);
                  Console.WriteLine(IPReservationFileLines[0]);   // Error	CS0021	Cannot apply indexing with [] to an expression of type 'IEnumerable<string>'

              }
          }
      }
      
[Reference from Stack Overflow](https://stackoverflow.com/questions/3628425/ienumerable-vs-list-what-to-use-how-do-they-work)

A class that implement `IEnumerable` allows you to use the `foreach` syntax. 

Basically it has a method to get the next item in the collection. 
It doesn't need the whole collection to be in memory and doesn't know how many items are in it, `foreach` just keeps getting the next item until it runs out.

Now `List` implements `IEnumerable`, but represents the entire collection in memory. 
If you have an `IEnumerable` and you call `.ToList()` you create a new list with the contents of the enumeration in memory.

![image](https://user-images.githubusercontent.com/2452221/144999316-4437c660-fba5-4dda-9f22-fcd233c62cb2.png)
![image](https://user-images.githubusercontent.com/2452221/144999339-46669168-6df7-4f8f-aa11-8c47210d4060.png)
