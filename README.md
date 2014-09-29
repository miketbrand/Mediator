# FusionAlliance.Mediator

The mediator pattern is useful for managing request/reply responsibilities in an application.

## Usage

To use the mediator, simply create a custom request reply objects. Send the request to the mediator.

*Note: It is not necessary that the objects be immutable.*

### Sample Request/Reply/Handler

These classes demonstrate a simple request and reply, to say hello to a given name.

``` csharp
public class SayHello : IRequest<SayHelloReply>
{
  private readonly string _name;

  public HelloRequest(string name)
  {
    _name = name;
  }

  public string Name
  {
    get { return _name; }
  }
}
```

``` csharp
public class SayHelloReply
{
  private readonly string _hello;

  public SayHelloReplay(string hello)
  {
    _hello = hello;
  }

  public string Hello
  {
    get { return _hello; }
  }
}
```

The handler's responsibility is to handle the request.

``` csharp
public class SayHelloHandler : IRequestHandler<SayHello, SayHelloReply>
{
  public void Dispose()
  {
    Dispose(true);
  }

  public SayHelloReply Handle(SayHello request)
  {
    var hello = string.Format("Hello, {0}!", request.Name);
    return new SayHelloReply(hello);
  }

  protected virtual void Dispose(bool isDisposing)
  {
    /* Nothing to do here. */
  }
}
```

### Sample Request/Reply/Handler with Database

The most common use of this pattern is for some type of data access, whether a database or service. In the example below, the `Product` class would be some type of data entity.

*Note: This example uses [Dapper](https://github.com/StackExchange/dapper-dot-net) for database access.*

``` csharp
public class GetProductById : IRequest<Product>
{
    public GetProductById(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}

public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
{
    private readonly IDbConnection _connection;

    public GetProductByIdHandler(IDbConnection connection)
    {
        if (connection == null)
            throw new ArgumentNullException("connection");

        if (connection.State != ConnectionState.Open)
            throw new ArgumentException(string.Format("Connection is not open. Connection state is {0}.", connection.State);

        _connection = connection;
    }

    public static string Sql
    {
        get { return @"SELECT TOP 1 * FROM [dbo].[Products] WHERE [ProductId] = @ProductId";
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public Product Handle(GetProductById request)
    {
        var p = new
        {
            ProductId = request.Id
        };
        var product = _connection.Query<Product>(Sql, p).First();
        return product;
    }

    protected virtual void Dispose(bool isDisposing)
    {
        if (isDisposing)
        {
            _connection.Dispose();
        }
    }
}
```


## Build

*Instructions coming "soon".*

## Contributors

* Jarrett Meyer -- [@jarrettmeyer](https://twitter.com/jarrettmeyer)