# Concepts

## Idempotent

A HTTP method is idepotent is an identical request can be made once or serveral times in a row with the same effectwhile leaving the server in the same state. 

idempotent methods:
* GET
* HEAD
* PUT
* DELETE

non-idempotent methods
* POST
* PATCH
* CONNECT

All safe methods are also idempotent. 

## Safe

An HTTP method is safe if it does not alter the state of the server. 也就是说，一个对服务器进行只读操作的就是安全的操作。

safe methods:
* GET
* HEAD
* OPTIONS

# Request methods

## GET

GET should only retrieve data and should have no other effect

## HEAD

Asks for a reponse identical to that of a GET request, but without the request body.
This is useful for retrieving meta-information written in response headers without having to transport the entire content

## POST 

The POST method requests that the server accept the entity enclosed in the request as a new subordinate of the web resoure indentified by the URI.

## PUT 

The PUT method requests taht the enclosed entity be stored under the supplied URI.

## DELETE

Delete the specified resource

## TRACE

The TRACE method enchoes the received request so that a client can see what changed or additions have been made by intermediate servers. 

## OPTIONS

The OPTIONS method returns the HTTP methods that the server supports for the specified URL.

## CONNECT 

It converts the request conection to a transparant TCP/IP tunnel. 

## PATCH

It applies partial modifications to a resource.
A PATCH is not necessary idempotent, although it can be. 
