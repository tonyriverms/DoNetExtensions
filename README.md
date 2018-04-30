# .Net Extensions
The project aims to provide hundreds of useful and tested extension methods to existing standard .Net classes.

We have been coding with .NET for more than ten years, and we notice many standard classes (like array, list, dictionary, etc.) lack rich methods to facilitate their use and quick development. This project simply aims to enrich these standard classes and brings convenience to other .NET programmers.

## Initial Release

This initial release includes **_several categories of extensions for arrays and collections_** as shown below. Currently all methods are under the same namespace as the classes they extend. Therefore, the **_usage_** is to just add reference to the extension library and then benefit from the added methods.

### 1. Collection to Array Conversion

**_ToArrayOrNull_**: returns a null reference if the collection is empty (rather than returns an empty array by the build-in ToArray() method), or otherwise works like build-in ToArray() method.

**_ToArrayThenClear_**: works like the build-in ToArray() method, but clears the collection after the elements are output to the array.

**_ToArrayOrNullThenClear_**: works like the ToArrayOrNull() method, but clears the collection after the elements are output to the array.

All added methods support conversion starting at a specified index.

### 2. Unified Emptiness Check

Although incredibly useful, the emptiness of an array or a collection has to be checked in a clumsy way, even for today after 10 years.

```c#
var arr = new int[] {1,2,3};
if (arr != null && arr.Length != 0) // NOTE: the new syntax "arr?.Length != 0" will not do the check as desired!
  Do something...
  
var list = new List<int> {1,2,3};
if (list != null && arr.Count != 0) // NOTE: have to use a different property "Count"
  Do something...
```

Now with the extension, above can be greatly simplified and more readable. The method is added to both arrays and collections.

```c#
var arr = new int[] {1,2,3};
if (arr.IsNotNullOrEmpty())
  Do something...
  
var list = new List<int> { 1,2,3};
if (list.IsNotNullOrEmpty())
  Do something...
  
var dict = new Dictionary<string, int> { { "a", 1 } }
if (dict.IsNotNullOrEmpty())
  Do something...
```

**_IsNullOrEmpty_**: Returns true if a collection is a null reference or is an empty collection.

**_IsNotNullOrEmpty_**: Returns true if a collection is not a null reference or is not an empty collection.

**_IsEmpty_**: Returns true if a collection is an empty collection (throws an NullReferenceException if it is a null reference).

**_IsNotEmpty_**: Returns true if a collection is not an empty collection (throws an NullReferenceException if it is a null reference).

### 3. Basic Operations on An Array

