# .NET Extensions
The project aims to provide hundreds of fully-documented, tested, and useful extension methods to existing standard .NET classes, which we have accumulated through the years. 

We have been coding with .NET for more than ten years, and we notice many standard classes (like array, list, dictionary, etc.) lack rich methods to facilitate their use and quick development. Although each piece extension method in this library is not much, we believe as a whole they bring great convenience and help enhance producitivity for other .NET programmers.

Nuget: https://www.nuget.org/packages/DoNetExtensions/. In nuget package manager, enter "**Install-Package DoNetExtensions**" to get the latest version. 

Latest Update: [Value Swap](#ValueSwap), [Bit Operations](#BitOperations), [Conversion to Hexical String](#ConversiontoHexicalString)

## Initial Release (version 8)

**Usage**: Currently all methods are under the same namespace as the classes they extend. Therefore just add reference to the extension library (enter "**Install-Package DoNetExtensions**" in the nuget package manager), import the standard namespaces like "System.Collections" as usual, and then benefit from the added methods. 

Each method may have multiple overloads. We are unable to present them one by one here, but these methods are very intuitive and have full XML documentation. We carefully tag _AggressiveInlining_ attribute to "short" extensions to avoid impacting performance. 

By category: 

a. [Must-Have Extensions](MustHaveExtensions.md)

b. [Array and Collection Extensions](ArrayAndCollectionExtensions.md)

b. [Value Type Extensions](ValueTypeExtensions.md)

d. [Char and String Extensions](StringExtensions.md)

e. [IO Extensions](IOExtensions.md)

All extensions:

1) [Consistent Containment Check](#ConsistentContainmentCheck); 2) [Collection to Array Conversion](#CollectiontoArrayConversion); 3) [Consistent Emptiness Check](#ConsistentEmptinessCheck); 4) [Convenient IndexOf](#ConvenientIndexOf); 5) [Collection to Concatenated String](#CollectiontoConcatenatedString); 6) [Basic Array Operations](#BasicArrayOperations); 7) [Value Swap](#ValueSwap); 8) [Bit Operations](#BitOperations); 9) [Conversion to Hexical String](ConversiontoHexicalString); 10) [Char Extensions](#CharExtensions).

### <a name="ConsistentContainmentCheck"></a> 1. Consistent Containment Check for Collections and Strings -- The "In" Method

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

We also provide "InAny" and "InAll".

```c#
1.InAny(new []{1,2,3}, new[]{2,3,4}); // returns true
1.InAll(new []{1,2,3}, new[]{2,3,4}); // returns false
```

The same extension is added for string.

```c#
'c'.In("string to check"); // returns true
'c'.InAll("string to check", "another string"); // returns false
'c'.InAny("string to check", "another string"); // returns true
```

**_In_**: returns _true_ if the element to check is contained in an array/list/collection/string, or a key of a dictionary.

**_InAny_**: returns _true_ if the element to check is contained in any of the provided arrays/lists/collections/strings.

**_InAll_**: returns _true_ if the element to check is contained in all of the provided arrays/lists/collections/strings.

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


### <a name="ConsistentEmptinessCheck"></a> 3. Consistent Emptiness Check for Collections & Strings

Although incredibly useful, the emptiness of an array or a collection has to be checked in a clumsy way, even for today after 10 years.

```c#
var arr = new int[] {1,2,3};
if (arr != null && arr.Length != 0) // NOTE: the new syntax "arr?.Length != 0" will not do the check as desired!
  Do something...
  
var list = new List<int> {1,2,3};
if (list != null && arr.Count != 0) // NOTE: have to use a different property "Count"
  Do something...
  
var str = "abc";
if (!string.IsNullOrEmpty(str)) // another style of emptiness check, inconsistent with all others
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
  
var str = "abc";
if (str.IsNotNullOrEmpty())
  Do something...
```

**_IsNullOrEmpty_**: Returns true if a collection/string is a null reference or is an empty collection/string.

**_IsNotNullOrEmpty_**: the negation of **_IsNullOrEmpty_**.

**_IsEmpty_**: Returns true if a collection/string is an empty collection/string (throws an NullReferenceException if it is a null reference).

**_IsNotEmpty_**: the negation of **_IsEmpty_**.

**_IsEmptyOrBlank_**: Returns true if a string is an empty string or contains only white-space characters (throws an NullReferenceException if it is a null reference).

**_IsNotEmptyOrBlank_**: the negation of **_IsEmptyOrBlank_**, for strings only.

**_IsNullOrEmptyOrBlank_**: Returns true if a the string is a null reference, or is an empty string, or is a string with only white-sapce characters.

**_IsNotNullOrEmptyOrBlank_**: the negation of **_IsNullOrEmptyOrBlank_**, for strings only.

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

### <a name="BasicArrayOperations"></a>6. Array Operations

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

### <a name="ValueSwap"></a>7. Value Swap

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

Due to complier limitation, currently the extension only supports value types or structs. For reference type, you could consider use _Swapper.Swap_ static method.

```c#
var a = "123";
var b = "456";
Swapper.Swap(ref a, ref b); // due to compiler limitation, a static method has to be used for reference types
```

**_Swap_**: Swaps the current value of struct types with another value. 

### <a name="BitOperations"></a>8. Bit Operations

We provide convenient extensions to retrieve higer bits or lower bits of a value of type _long_/_ulong_, _int_/_uint_, _short_/_ushort_ or _byte_. Following gives two examples, for full description see the method XML documentation.

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

long a = 100;
var h_high_bytes = a.High().ToBytes(); // combines with High, Low methods to get high/low bytes.
```

**_High_**: Returns the higher-half bits (the left half if you write the value as a 0-1 string) of a supported value.

**_Low_**: Returns the lower-half bits (the right half if you write the value as a 0-1 string) of a supported value.

**_ToBytes_**: Returns a byte array representing a value of basic value type.

### <a name="ConversiontoHexicalString"></a>9. Conversion to Hexical String

If a hexical string of a value type is needed, than the following comes handy.
```c#
var a = 1234;
a.ToHex(); // returns full 32-bit representation "000004D2"
a.ToHex(fullLength:false); // returns "4D2"
```

**_ToHex_**: Returns the hexical representation of the basic value types (byte, int, float, etc.).

### <a name="CharExtensions"></a>10. Char Extensions

Some static methods of Char class is now available as extension methods. Some useful ones include **_IsWhiteSpace_**, **_IsLetter_**, **_IsNumber_**, **_IsDigit_**, **_IsLetterOrDigit_**, **_IsUpper_**, **_IsLower_**, **_IsPunctuation_**, **_IsCurrencySymbol_**, **_GetNumericValue_**, **_ToLower_**, **_ToUpper_**, etc.

We add some new methods for ASCII characters.

**_IsASCIIUpper_**: returns _true_ if the character is from A to Z.

**_IsASCIILower_**: returns _true_ if the character is from a to z.

**_IsASCIIDigit_**: returns _true_ if the character is from 0 to 9.

**_IsASCIILetterOrDigit_**: returns _true_ if the character is an ASCII letter or digit (a-z,A-Z,0-9).

**_IsASCII_**: returns _true_ if the character is an ASCII character.

**_IsNegativeSign_**: returns _true_ if the character represents the numerical negative sign (e.g. '-') under a culture.

```c#
var a = ' ';
a.IsWhiteSpace(); // returns true
a.IsASCIIUpper(); // returns false
a.IsASCII(); // returns true
```
