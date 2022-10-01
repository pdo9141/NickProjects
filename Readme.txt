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
    9 await async things you need to know:
        a) If you async await you need to async await all the way
        b) Async void is bad, an exception will kill the process. Always return Task instead of void    
        c) When you see yourself using Task.Run (execute trivial code in async fashion) just to comply with async/await, use instead Task.FromResult
           Task.Run will waste a ThreadPool thread for no reason. You can even use ValueTask to be more memory efficient
        d) Don't use .Result or .Wait (you're synchronizing the call), avoids deadlocks and threadpool starvation, wasted resources 
        e) Prefer await over ContinueWith (just don't use this)
        f) Always pass CancellationToken and use downstream (helps with folks refreshing page or closing browser or cancelling in Postman)
        g) Prefer async over task. Debugging and exception is better when you use async/await instead of returning just Task without async
        h) Don't use async/await in contructors. Refactor to make constructor private, use factory pattern. Create class instance in async/await public method.
        i) Use Task.Delay instead of Thread.Sleep if using async/await
06) https://www.youtube.com/watch?v=mEhkelf0K6g&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=25
    When to use ValueTask instead of Task to save precious memory?
    Whenever you're using caching and most of the time it reads from cache then that's the proper use case for ValueTask        
    There will be no difference in speed, this will only improve memory utilization
07) https://www.youtube.com/watch?v=vBdf3pe1jNU&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=24
    Best Nuget package you probably don't know about but should use
    What if you wanted to measure the response time of an API (cross cutting concerns) without doing these manually (adding diagnostics code within the method)?
    You can use Castle.Core Nuget package. Create interceptor which implements IInterceptor (you can think of it like middleware)
08) https://www.youtube.com/watch?v=FM5dpxJMULY&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=20
    What is Span in C# and why you should be using it
    If you wanted to parse a Date string into month, day, year int values. You could use Substring but that would use the heap since string is a reference type.
    You can alternatively use Span (or ReadOnlySpan) which is value type (ref struct) and swap Substring for Slice.
    Don't use ToString() if you're using ReadOnlySpan. Return ReadOnlySpan and let caller decide what to do with it.
09) https://www.youtube.com/watch?v=qapJwFY9y2Y&list=FL7icRCaZ3lLMJQzi9ZJ62Gg&index=19
    20 Nuget packages that every .NET developer should be familar with
    a) xUnit & NUnit: focus on xUnit more, better solution of the two and Microsoft uses it instead of in-house solution
    b) Moq & NSubstitute: NSubstitue seems like a better solution
    c) Polly: helps with retries, policies, circuit breakers
    d) FluentAssertions: assertions on unit testing, english like fluency
    e) BenchmarkDotNet: awesome benchmark tool
    f) Serilog: better solution for logging
    g) Autofixture & Bogus: generate fake data for tests, seeding data
    h) Scrutor: helps with Startup.cs and DI, helps with cross cutting concerns separating concerns
    i) Automapper: ORM mapper
    j) Dapper & EF Core: use Dapper for reads and EF Core for writes
    k) MediatR & Brighter: use for mediator pattern or pub/sub, helps implement CQRS
    l) FluentValidation: helps validate object and write rules using fluent patterns
    m) Refit & RestSharp: helps create client for REST APIs
    n) Json.NET: high performance JSON serializer
    