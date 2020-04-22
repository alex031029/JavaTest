https://stackoverflow.com/questions/13988334/difference-between-destructor-dispose-and-finalize-method\



Destructor implicitly calls the Finalize method, they are technically the same. 
Dispose is available with objects that implement the IDisposable interface. 
