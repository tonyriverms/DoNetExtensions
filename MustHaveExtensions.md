We believe these simple yet thoughtful "must-have" extensions would bring better consistency, readability and productivity to your code.

### <a name="ConsistentContainmentCheck"></a> 1. Consistent Containment Check -- The "In" Method

Instead of "_a.Contains(b)_", we provide an alternative "_b.In(a)_". If "_a_" is a collection, the the method checks if "_b_" is an element in "_a_"; if "_a_" is a dictionary, then the method checks if "_b_" is a key in "_a_". This "In" method is somewhat "python" style, **_shorter_** and **_more consistent_**; besides that, it returns _false_ for null reference.

```c#
var arr = new[] {1,2,3};
if (1.In(arr)) // equivalent to arr.Contains(1)
  Do something...

var dict = new Dictionary<string, int> { { "a", 1 } };
if ("a".In(dict)) // equivalent to dict.ContainsKey("a")
  Do something...

arr = null;
1.In(arr); // returns false

dict = null;
"a".In(dict); // returns false
```

**_In_**: returns true if the element to check is contained in an array/list/collection, or a key of a dictionary.

### <a name="ConsistentEmptinessCheck"></a> 3. Consistent Emptiness Check

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
  
var dict = new Dictionary<string, int> { { "a", 1 } };
if (dict.IsNotNullOrEmpty())
  Do something...
```

**_IsNullOrEmpty_**: Returns true if a collection is a null reference or is an empty collection.

**_IsNotNullOrEmpty_**: Returns true if a collection is not a null reference or is not an empty collection.

**_IsEmpty_**: Returns true if a collection is an empty collection (throws an NullReferenceException if it is a null reference).

**_IsNotEmpty_**: Returns true if a collection is not an empty collection (throws an NullReferenceException if it is a null reference).

### <a name="ConvenientSwapBitOperations"></a>7. Swap Method

Swapping two values have been an annoying issue that disrupts code readability. The following extensions address this problem. It is implemented by efficient bit operations when possible.

```c#
var a = 1;
var b = 2;
a.Swap(ref b);
Console.WriteLine(a); // prints 2
Console.WriteLine(b); // prints 1

var t1 = DateTime.Now;
var t2 = new DateTime(2010, 10, 22);
t1.Swap(ref t2);
Console.WriteLine(t1); // prints "[10/22/2010 12:00:00 AM]"
Console.WriteLine(t2); // prints the recorded time
```

In this category, we also provide convenient extensions to retrieve higer bits or lower bits of a value of type _long_/_ulong_, _int_/_uint_, _short_/_ushort_ or _byte_. Following gives two examples, for full description see the method XML documentation.

```c#
int a = 100;
var a_high = a.High(); // gets the higher 16 bits of this 32-bit integer, represented by a 16-bit unsigned integer, which is 0 in this case.

byte b = 100;
var b_low = b.Low(); // gets the lower 4 bits of _b_. The returned value is a byte, and the lower 4 bits of _b_ is positioned at the lower half of the returned byte. For example, the bits of this case is _01100100_, and it returns _00000100_.
var b_high = b.High(); // gets the higher 4 bits of _b_. The returned value is a byte, and the higher 4 bits of _b_ is positioned at the LOWER half of the returned byte. For example, the bits of this case is _01100100_, and it returns _00000110_.
```

In addition, you can retrieve all bytes of basic values types float/double, long/ulong, int/uint, short/ushort and DateTime.
```c#
var t = DateTime.Now;
t.ToBytes(); // gets a byte array representing the DateTime instance t
```

**_Swap_**: Swaps the current value of struct types with another value.
