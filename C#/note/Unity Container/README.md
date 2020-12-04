# Unity Container

Unity本质是一个依赖注入容器(Dependency Injection Container)

## Reference

* [GitHub Page](https://github.com/unitycontainer/unity)
* [IoC Container]


## Dependency Injection and Inversion of Control (IoC)

**依赖注入**与**控制反转**基本表达了一样的意思。基本上来说控制翻转的定义更加宽泛


## IoC Container

所有的IoC Container需要支持三种功能

* Register: The container must know which dependency to instantiate when it encounters a particular type. This process is called registration. Basically, it must include some way to register type-mapping.
* Resolve: When using the IoC container, we don't need to create objects manually. The container does it for us. This is called resolution. The container must include some methods to resolve the specified type; the container creates an object of the specified type, injects the required dependencies if any and returns the object.
* Dispose: The container must manage the lifetime of the dependent objects. Most IoC containers include different lifetimemanagers to manage an object's lifecycle and dispose it.
