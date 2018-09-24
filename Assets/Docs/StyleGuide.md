# Naming Conventions

* Namespaces, types, properties and methods are always CapsCase.
* Local and private variables are always camelCase.

# Class Layout

```csharp
class SomeClass
{
    // Static Members
    // Instance Members

    // Delegates
    // Events
    // Fields
    // Properties
    // Methods
    // InnerTypes

    // Public
    // Internal
    // Protected
    // Private
}
```

# Commenting

All classes should have a simpmle comment added to them describing what
the class does, how it behaves and how it can be used.

Methods and properties do not require comments. If they are sufficiently
complex then it may be worth documenting some of that complexity.

Comments within methods should be limited, prefering to comment the
method itself.

```
NOTE: In the future classes that are apart of an externally used API may
require more formal commenting for documentation generation purposes.
```
