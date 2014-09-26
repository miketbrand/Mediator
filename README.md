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

## Build

*Instructions coming "soon".*

## Contributors

* Jarrett Meyer -- [@jarrettmeyer](https://twitter.com/jarrettmeyer)