# ASP .NET Web API

## Test

You can use Postman to call https://localhost:44327/api/products/1 to get result like below.

```Json
{
    "Id": 1,
    "Name": "Tomato Soup",
    "Category": "Groceries",
    "Price": 1.0
}
```


## Exception Filters

当一个非`HttpResponseException`的exception被抛出的时候，可以通过filter来处理这些exception。
当然filter需要进行register。这个可以是by action, by controller或者globally。
我这里的例子是globally，与IRMS webrole一致。
