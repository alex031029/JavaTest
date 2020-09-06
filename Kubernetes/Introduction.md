# Introduction

1. 过去的单体式应用（Monolithic Applications）正在被逐渐拆分成很多小的microservices
1. microservices之间互相独立，能够独立的更新、升级
1. 但是因为microservices的数量大幅度上升，讲这些程序进行整合的难度就大幅度提高
1. 于是我们需要automation，包括
	* automatic scheduling 
	* automatic configuration
	* supervision
	* failure-handling
1. 于是这里我们就需要Kubernetes的帮忙

kubernetes会抽象化hardware infrastructure，允许你不了解服务器结构的情况下进行部署。
所以Kubernetes很适合on-premises的datacenter。

## Understanding the Needs for a System like Kubernetes

### Moving from Monolithic Apps to Microservices

Traits of Monolithic Apps

* Highly Coupled components that are developed, deployed and managed as one entity
* Run as a single OS process
* 改变任何一个component，需要对整个app进行redeployment
* 开发难度会随着时间语法提高、同时app的质量还会下降
* 需要少量但是非常强力的server提供足够的resources运行应用
	* 这可以是scale up 或者 scale out
	* 如果monolithic app中任何一个component不支持scaling，则整个app不支持scaling

#### Splitting apps into microservices

Thus, we are forced to startting splitting complex monolithic applications into smaller independently deployable components called **microservices**

Communication between microservices:
* Synchronous protocol: HTTP. RESTful APIs
* Asynchronous protocol: AMQS (Advanced Message Queueing Protocol)

#### Deploying microservices

Drawbacks of microservices：
* 当component的数量大幅度上升的时候，deployment的决策难度会大幅度上升
* 同时应对大量的microservices，容易出现错误(error-prone)
* microservices同时非常难以debug与trace execution calls 
	* 不过现在有的工具如Zipkin来解决这类问题
* 会出现不同的microservice的dependency不同的情况。

### Providing a consistent environment to applications

### Moving to continous delivery: DevOps and NoOps

以前大家倾向于区分开发与运维。如今，公司认为开发的人员才是维护这个软件运维的最好的人员。
于是deloper, QA and operations teams之间高度合作，即DevOps

理想情况下，我们希望developer能够在完全不了解下hardware infrastructure同时也不接触运维的情况下，部署应用。
这种就被称为NoOps

## Introducing Container Technologies

### Understanding what containers are 

Instead of using VM to isolate environment of each microservice (or software process in general), 
developers are turning to Linux container technologies.

container中的进程与其他的进程一样，是运行在host的操作系统中。
VM则不相同，不同的进程是运行在不同的操作系统中。

### Compare virtual machines to containers

Containers, compared to VMs, are 
* more lightweigted
	* 允许你在同样的配置下，运行更多的进程
* one container for one application
	* VM由于额外开销比较多，往往一个VM上会运行更多的进程
* 使用的system call与host OS的kernel相同，host OS的kernel直接可以调用其CPU执行，而不需要进行virtualization
	* VM使用的system call是调用guest OS（即VM的OS）中的kernel。然后这些kernel再通过host的CPU执行命令

VM的优势
* full isolation.因为每个VM都有自己一套完整的Linux kernel。
	* containers则使用的共同的kernel

### Introducing the mechanism that make container isolation possible

container isolation的两种机制
1. Linux Namespace
	* make sure each process sees its own personal view of system
2. Linux Control Groups (cgroups)
	* limit the amount of resources the process can consume 
	
## Introducing the Docker container platform

Docker是第一个做到让container在不同的机器间轻松移植的平台。
Docker简化了打包的工作。
Docker会打包app，同时还包括它所有的libraries and dependencies, even the whole OS file system，
将这些都打包为一个portable package，可以被provision到其他机器运行的Docker上。

当你在Docker里跑一个app的时候，它会看到exact filesystem contents that you've bundled with.
比如你把app与Red Hat Enterprise Linux （RHEL），那么app就会认为它运行在RHEL上面。
即使你真正的机器是Fedora或者其他Linux版本。只有kernel会有不同。

Docker-based container image与VM images之间的一个重大区别在于，container image are composed of layers.
这些layers是被不同的images共享与复用的。

### Understanding Docker concepts

1. **Images**: 一个docker-based image就是你打包你的软件与其运行环境的总和。它包括了filesystem，让app可以寻找路径
1. **Registries**: docker registry本质是一个repository，里面存有docker image以及一些facilites。
1. **Containers**： docker-based container即一个从Docker-based container image中创造出来的Linux container。一个container运行商docker上，docker运行在host上。

### Understanding image layers

不同的image可以共享完全相同的layer，这使得distribution更快！
这同时减少了storage footprint。

### Understanding the portability limitation of container images

理论上container image可以运行在任何Linux docker上面，但这里有个小前提（caveat）：container使用的都是host的kernel。
如果container需要特别的kernel版本，那么不是所有的机器都晕运行这个container。

这个限制是由container本身的轻量级带来的，VM就没有这个问题。
因为VM自带kernel。

另外一个限制在于对于hardware architecture的要求。
一个为X86设计的container无法运行在ARM架构上。
这个同样需要VM来解决。