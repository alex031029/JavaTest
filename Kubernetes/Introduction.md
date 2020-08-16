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

Thus, we are forced to startting splitting complex monolithic applications into smaller independently deployable components called **microservices**
