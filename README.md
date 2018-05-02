# .NET Extensions
The project aims to provide hundreds of fully-documented, tested, and useful extension methods to existing standard .NET classes, which we have accumulated through the years. 

We have been coding with .NET for more than ten years, and we notice many standard classes (like array, list, dictionary, etc.) lack rich methods to facilitate their use and quick development. Although each piece extension method in this library is not much, we believe as a whole they bring great convenience and help enhance producitivity for other .NET programmers.

## Initial Release

This initial release includes **_several extensions for arrays and collections_** as shown below. Currently all methods are under the same namespace as the classes they extend. Therefore, the **_usage_** is to just add reference to the extension library, import the namespace like "System.Collections" as usual, and then benefit from the added methods.

Each method may have multiple overloads. We are unable to present them one by one here, but these methods are very intuitive and have full XML documentation.

### 1. The "In" Method

Instead of "a.Contains(b)", we provide an alternative "b.In(a)", where "a" is a collection, and "b" is an element to check.

```c#
var a = new[] {1,2,3};
var b = 1;
if (b.In(a))
  Do something.
```

**_In_**: returns true if the element to check is contained in an array/list/collection.

### 2. Collection to Array Conversion

```c#
var list = new List<int>();
var arr = list.ToArrayOrNull(); // returns a null reference
list.Add(1);
list.Add(2);
arr = list.ToArrayOrNull(); // returns an array [1,2]
arr = list.ToArrayThenClear(); // returns an array [1,2] and clears the list
arr = list.ToArrayOrNull(); // returns a null reference because list has been cleared.
```

**_ToArrayOrNull_**: returns a null reference if the collection is empty (rather than returns an empty array by the build-in ToArray() method), or otherwise works like build-in ToArray() method.

**_ToArrayThenClear_**: works like the build-in ToArray() method, but clears the collection after the elements are output to the array.

**_ToArrayOrNullThenClear_**: works like the ToArrayOrNull() method, but clears the collection after the elements are output to the array.

All added methods support conversion starting at a specified index.

### 3. Unified Emptiness Check

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

### 4. Convenient IndexOf

Adds extension methods that dummpy the _Array.IndexOf_ and static _Array.IndexOf_ methods. Also adds support for searches of subarrays.

```c#
var arr = new [] {1, 2, 3, 4};
arr.IndexOf(2); //returns 1, equivalent to Array.IndexOf(arr, 2)
arr.IndexOf(2, 2); // searches for 2 starting at position 2 of the array, so returns -1
arr.IndexOf(4, 1, 2); // searches for 4 starting at position 1 of the array, and only compares 2 elements afterwards, so returns -1
arr.IndexOf(4, 1, 3); // return 3

arr.IndexOf(new[] {3, 4}); // searches the subarray and returns 2.
```

**_IndexOf_**: Returns the index of the first occurrence of a target element or a target subarray in the current array.
**_LastIndexOf_**: Returns the index of the first occurrence of a target element ~~or a target subarray~~ in the current array (subarray search support not added yet).

### 5. Collection to Concatenated String

**_ToConcatString_**: Outputs a concatenated string representation for elements in a collection. For each element, their _ToString()_ method is used.

```c#
var arr = new int[] {1,2,3};
arr.ToConcatString(','); // returns "1,2,3"
arr.ToConcatString("--"); // returns "1--2--3"
```

### 6. Basic Operations on Array

It is not uncommon that we might need to just add/remove one specified item to/from an array, and return a new array with the item added/removed (for example, such addition/removal is rarely used by the client, and it is not desirable to complicate the code design with other data structure like list or linked list).

```c#
var arr = new int[] {1,2,3};
var arr2 = arr.Remove(2); // returns a new array instance [1,3]
var arr3 = arr.RemoveAt(2); // returns a new array instance [1,2]
var arr4 = arr.AddFirst(0); // returns a new array instance [0,1,2,3]
var arr5 = arr.AddLast(4); // returns a new array instance [1,2,3,4]
var arr6 = arr.Insert(18, index:2); // returns a new array [1,2,18,3], with 18 inserted at position 2
var arr7 = arr.Insert(arr, index:2); // returns a new array [1,2,1,2,3,3], with "1,2,3" inserted at position 2

var merged = (new[] { arr, arr2, arr3, arr4, arr5, arr6, arr7}).Merge(); // merges all above arrays into on single array.
```

**_AddFirst_**: Returns a new array with one or more elements appended at the beginning of the current array.

**_AddLast_**: Returns a new array with one or more elements appended at the end of the current array.

**_Remove_**: Returns a new array with the specified element(s) removed.

**_RemoveAt_**: Returns a new array with the element at the specified index(es) removed.

**_Insert_**: Returns a new array with one or more elements inserted at the specified index.

**_Merge_**: Merges a collection of arrays into a single array.
