# DynamicIndex

DynamicIndex allows traversing .NET objects in a javascript like fashion. Sometimes you just need to be able to get navigate objects at runtime.

__DynamicIndex is not currently on Nuget. It will be eventually. Open an issue if you need it now.__

Using it is very simple:

You need one import:

```csharp
using DynamicIndex
```

Assuming your object looks something like this:

```csharp
var o = new Class1() 
{
    Int1 = 120,
    Int2 = -34,
    String1 = "Hello",
    String2 = "World",
    Array1 = [1, 2],
    Object1 = new Class2() 
    {
        Int1 = 4
    }
};
```

You first get a DynamicIndex object by calling the `Index()` extension method. Then you can use nested indexers to index the object. Finally, get the value out using `Get()`.

For example:

```csharp
// isValid1 = true
// val1 = 120
var isValid1 = o.Index()["Int1"].Get(out var val1);

// isValid2 = true
// val2 = 2
var isValid2 = o.Index()["Array1"][1].Get(out var val2);

// isValid3 = true
// val3 = 4
var isValid3 = o.Index()["Object1"]["Int1"].Get(out var val3);
```

If you know the type at compile time, you can strongly type `Get()`:

```csharp
var isValid = o.Index()["String1"].Get<string>(out var val); // val is type string, not object
```

In addition, the indexers are errorless. `Get()` will return false if any indexer keys and/or indices are not found.

```csharp
var isValid = o.Index()["String100ThatDoesntExits"].Get(out var val); // returns false;
```
