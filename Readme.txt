01) https://www.youtube.com/watch?v=6zoMd_FwSwQ&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=31
    Stop using string interpolation when loggin in .NET. Why? You will bypass structured logging (metadata in Azure or AWS).
    Use the logging method overload instead where you pass fields as paramters [].
    If you use structured logging you'll see in the console nice color formatting for each property metadata.
    You'll be able to search, filter, and export property metadata in Azure if structured logging is used.
02) https://www.youtube.com/watch?v=tSuwe7FowzE&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=30
    Sequential IDs are good for performance (primary clustered ID indexing) but opens up guessable attack vector.
    GUIDs can be used as an alternative but it comes at the cost of performance.    
    To get the best of both worlds, look at Nuget package Hashids.net.
    This mostly applies to RDBMS, disregard for NOSQL DBs. GUIDs are perfectly fine when using something like CosmosDB.
    Performance degradation using Hashids.net is not the best memory wise but the value proposition outweighs the hit I think
03) https://www.youtube.com/watch?v=kIkbGXLkc-g&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=29
    There's a setup "trick" that .NET libraries use that you should be using too.   
    For configuration options use Action<YourClassOptions>? configure, allows you to use pattern below
    builder.Services.AddAwesomeness(options =>
    {
        options.Prefix = "PHD";
        options.AgeFilter = 69;
    });
04) https://www.youtube.com/watch?v=iQ8cNI7a6mk&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=28
    You should probably be using this dependency injection method. Imagine scenario where you have two concrete classes that implement same interface.
    builder.Services.AddSingleton<IService, ServiceOne>();     
    builder.Services.AddSingleton<IService, ServiceTwo>();     
    The last one will be resolved. You will get both if you use IEnumerable. Will register services no matter uniqueness or implementation type.
    
    builder.Services.TryAddSingleton<IService, ServiceOne>();     
    builder.Services.TryAddSingleton<IService, ServiceTwo>();     
    The first one will be resolved. You will only see first one if you use IEnumerable. TryAddSingleton does duplicate check guard.
    Will check uniqueness on the service interface

    var descriptorOne = new ServiceDescriptor(typeof(IService), typeOf(ServiceOne), ServiceLifetime.Singleton);
    var descriptorTwo = new ServiceDescriptor(typeof(IService), typeOf(ServiceTwo), ServiceLifetime.Singleton);
    builder.Services.TryAddEnumerable(descriptorOne);
    builder.Services.TryAddEnumerable(descriptorTwo);
    builder.Services.TryAddEnumerable(descriptorTwo);
    Will check uniqueness on the service interface and implementation
05) https://www.youtube.com/watch?v=lQu-eBIIh-w&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=27
    await async mistakes that you should avoid    

