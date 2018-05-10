# Array and Collection Extensions

[2. Collection to Array Conversion](#CollectiontoArrayConversion)

[4. Convenient IndexOf](#ConvenientIndexOf)

[5. Collection to Concatenated String](#CollectiontoConcatenatedString)

[6. Basic Array Operations](#BasicArrayOperations)

[11. SubArray Methods](#SubArray)

### <a name="CollectiontoArrayConversion"></a> 2. Collection to Array Conversion

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

### <a name="ConvenientIndexOf"></a>4. Convenient IndexOf

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

### <a name="CollectiontoConcatenatedString"></a>5. Collection to Concatenated String

**_ToConcatString_**: Outputs a concatenated string representation for elements in a collection. For each element, their _ToString()_ method is used.

```c#
var arr = new int[] {1,2,3};
arr.ToConcatString(','); // returns "1,2,3"
arr.ToConcatString("--"); // returns "1--2--3"
```

### <a name="BasicArrayOperations"></a>6. Basic Array Operations

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

### <a name="SubArray"></a>11. SubArray Methods
```c#
var arr = new[] {1,2,3,4,5};
var subarr1 = arr.SubArray(1,3); // gets {2,3,4}, a subarray starting at position 1, of length 3
var subarr2 = arr.SubFirst(3); // gets {1,2,3}, a subsarray consisting of the first 3 elements
var subarr3 = arr.SubLast(3); // gets {3,4,5}, a subsarray consisting of the last 3 elements
```

**_SubArray_**: gets a subarray starting at a position of a specified length.

**_SubFirst_**: gets a subarray consisting of the beginning elements of the current array.

**_SubLast_**: gets a subarray consisting of the ending elements of the current array.
