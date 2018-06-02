# .NET Extensions
The project aims to provide hundreds of fully-documented, tested, and useful extension methods to existing standard .NET classes, which we have accumulated through the years. 

We have been coding with .NET for more than ten years, and we notice many standard classes (like array, list, dictionary, etc.) lack rich methods to facilitate their use and quick development. Although each piece extension method in this library is not much, we believe as a whole they bring great convenience and help enhance producitivity for other .NET programmers.

Nuget: https://www.nuget.org/packages/DoNetExtensions/. In nuget package manager, enter "**Install-Package DoNetExtensions**" to get the latest version. 

Latest Update: [Value Swap](#ValueSwap), [Bit Operations](#BitOperations), [Conversion to Hexical String](#ConversiontoHexicalString), [Char Extensions](#CharExtensions)

## Initial Release (update 10)

**Usage**: Currently all methods are under the same namespace as the classes they extend. Therefore just add reference to the extension library (enter "**Install-Package DoNetExtensions**" in the nuget package manager), import the standard namespaces like "System.Collections" as usual, and then benefit from the added methods. 

Each method may have multiple overloads. We are unable to present them one by one here, but these methods are very intuitive and have full XML documentation. We carefully tag _AggressiveInlining_ attribute to "short" extensions to avoid impacting performance. 

By category: 

a. [Essential Extensions](MustHaveExtensions.md)

b. [Array and Collection Extensions](ArrayAndCollectionExtensions.md)

c. [Data Analytics Extensions](DataAnalytics.md)

d. [Value Type Extensions](ValueTypeExtensions.md)

e. [Char and String Extensions](StringExtensions.md)

f. [IO Extensions](IOExtensions.md)

All extensions:

1) [Consistent Containment Check](#ConsistentContainmentCheck); 2) [Collection to Array Conversion](#CollectiontoArrayConversion); 3) [Consistent Emptiness Check](#ConsistentEmptinessCheck); 4) [Convenient IndexOf](#ConvenientIndexOf); 5) [Collection to Concatenated String](#CollectiontoConcatenatedString); 6) [Basic Array Operations](#BasicArrayOperations); 7) [Value Swap](#ValueSwap); 8) [Bit Operations](#BitOperations); 9) [Conversion to Hexical String](ConversiontoHexicalString); 10) [Char Extensions](#CharExtensions); 11) [SubArray Methods](#SubArray); 12) [Sort Enhancement](#SortEnhancement); 13) [Mutable Tuples for Data Processing](#MutableTuplesforDataProcessing); 14) [Dictionary-Based Counting](#DictionaryBasedCounting); 15) [ForEach Shortcut](#ForEachShortcut); [16. String IndexOf Extensions](#IndexOfExtensions); [17. Multiple Keyword Search](#MultipleStringSearch)

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
1.NotIn(arr); // returns true

dict = null;
"a".In(dict); // returns false
"a".NotIn(dict); // returns true
```

We also provide "InAny" and "InAll".

```c#
1.InAny(new []{1,2,3}, new []{2,3,4}); // returns true
1.InAll(new []{1,2,3}, new []{2,3,4}); // returns false
```

The same extension is added for string.

```c#
'c'.In("string to check"); // returns true
'c'.NotIn("string to check"); // returns false
'c'.InAll("string to check", "another string"); // returns false
'c'.InAny("string to check", "another string"); // returns true
```

The same extension is added for Python style range checking. The lower bound is included in the range, while the upper bound is excluded.

```c#
// ranges (2,5) represents number 2,3,4
1.In(2,5); // returns false
2.In(2,5); // returns true, lower bound is included
5.In(2,5); // returns false, upper bound is excluded

// range (1,5,2) represents number 1,3, the numbers from 1 to 5 with step 2
2 In(1,5,2); // returns false
3.In(1,5,2); // returns true
```

**_In_**: returns _true_ if the element to check is contained in an array/list/collection/string/range, or a key of a dictionary.

**_NotIn_**: negation of **_In_**.

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

### <a name="SortEnhancement"></a>12. Sort Enhancement

The methods makes the experience of frequent array sorting operations much more comfortable. The sorting is in-place. Use classic non-LINQ implementation for efficiency.

```c#
var keys = new []{2,3,2,1,2,5,7};
keys.Sort(); // equivalent to Array.Sort(arr), returns {1,2,2,2,3,5,7}
keys.SortDesc(); // sort descendingly, returns {7,5,3,2,2,2,1}

keys = new []{2,3,2,1,2,5,7};
var values = new []{'b','c','b','a','b','e','g'};
keys.SortWithValues(values); // keys become "{1,2,2,2,3,5,7}" and values become "{'a','b','b','b','c','e','g'}"
keys.SortDescWithValues(values); // keys become "{7,5,3,2,2,2,1}" and values become "{'g','e','c','b','b','b','a'}"
```

The extension method allows you specify a method to convert each array element to another comparable object for comparison. It has the same result as OrderBy().ToArray(), but the sorting is in-place and faster.

```c#
var keys = new []{"we","add","sorting","extensions"};

// returns {"add","we","sorting","extensions"}, same result as keys.OrderBy(key=>key[1]).ToArray()
keys.Sort(key=>key[1]);

// returns {"extensions","sorting","we","add"}
keys.SortDesc(key=>key[1]);

//TODO currently does not support specifying the conversion method while sorting with values
```

We add an efficent method to find the k th element (or the top k elements) in the array, based on ascending order or descending order. The "top k" elements will be moved to the beginning of the array.

```c#
var keys = new[] {2,3,2,1,2,0,7,5,4,3};

// returns 1, and "keys" become "{0,1,2,2,3,7,3,4,5,2}" with the smallest 2 elements moved to the beginning of the array
keys.TopK(2);

// returns 5, and "keys" become "{7,5,4,1,0,3,2,2,3,2}" with the largest 2 elements moved to the beginning of the array
keys.TopKDesc(2);
```

**_Sort_**: in-place sort the array ascendingly.

**_SortDesc_**: in-place sort the array descendingly.

**_SortWithValues_**: in-place sort the key array ascendingly, and in-place adjust the order of the value array accordingly

**_SortDescWithValues_**: in-place sort the key array descendingly, and in-place adjust the order of the value array accordingly

**_TopK_**: in-place moves the smallest k elements to the beginning of the array.

**_TopKDesc_**: in-place moves the largest k elements to the beginning of the array.

**_TopKWithValues_**: in-place moves the smallest k elements of the key array to the beginning, and in-place adjust the order of the value array accordingly

**_TopKDescWithValues_**: in-place moves the largest k elements of the key array to the beginning, and in-place adjust the order of the value array accordingly

### <a name="MutableTuplesforDataProcessing"></a>13. Mutable Tuples for Data Processing: Pair, Triple

Simple class implementations for mutable tuples. Neither Tuple or ValueTuple in vallia .NET is intended for data processing in data science or machine learning, making C# very hard to use for the cutting-edge development. Although we no longer often code C# for that purpose, occasionally we still use it for data preprocessing, as it is faster than Python for big data. The immutability of C# tuples make it tedious for the job.

It is very unfortunate that even though C# now supports interactive scripting, it still primarily focuses on software engineering. Our **_objective is make it better for data pre-processing as best as we can_**. 

The Pair and Triple supports implicit conversion to ValueTuple and Tuple objects. The Pair class in addition has implicit conversion to KeyValuePair class, so they can go in any place that supports build-in tuples. They support arithmetic addition and subtraction.

Both Pair and Triple are well-supported by various extension methods.
```c#
var dict1 = new Dictionary<string, Pair<int>>();
var dict2 = new Dictionary<string, (int,int)>();
var list1 = new List<Pair<int>>();
var list2 = new List<(int,int)>();

var pair = new Pair<int>(2,3);
var vallinaPair = (2,3);

dict1.Add("test1", pair);
dict1.Add("test2", vallinaPair); // implicit conversion happens
dict2.Add("test1", pair); // implicit conversion happens
dict2.Add("test2", vallinaPair);

dict1.Add("test3", 2, 3); // a new Add overload that supports convenient syntax for Pair
dict2.Add("test3", 2, 3); // a new Add overload that supports convenient syntax for ValueTuple

// The same support for List.

list1.Add(pair);
list1.Add(vallinaPair); // implicit conversion happens
list2.Add(pair); // implicit conversion happens
list2.Add(vallinaPair);
list1.Add(2,3); // a new Add overload that supports convenient syntax for Pair
list2.Add(2,3); // a new Add overload that supports convenient syntax for ValueTuple
```

### <a name="DictionaryBasedCounting"></a>14. Dictionary-Based Counting

Dictionary is the essential class used for data pre-processing in data analytics, data science, or machine learning. The following extensions make it quick for this purpose.

**_Stat_**: counting the number of occurrences of keys, able to specify count increment, supports various increment objects whose addition operator is defined.

**_MergeStat_**: merges the countings of a sequence of dictionaries.

```c#
// Suppose you want to count occurrences of the following keys.
var keys = new[] {"key1", "key2", "key5", "key1", "key3", "key3", "key4", "key5", "key5"};

// Any class that implements IDictionary<string, TValue> is good for this as long as "+" opeartor is defined for TValue.
// Let's first let TValue be int.
// After execution, the counter becomes { "key1":2, "key2":1, "key3":2, "key4":1, "key5":3 }.
var counter = new Dictionary<string, int>();
foreach (var key in keys)
   counter.Stat(key); // increase the count for the current key by 1
   
// We can specify the increment as 2. 
// After execution, the counter becomes { "key1":4, "key2":2, "key3":4, "key4":2, "key5":6 }
counter.Clear();
foreach (var key in keys)
   counter.Stat(key, 2);
   
// We can use a tuple for different counts.
// After execution, the counter2 becomes { "key1":(4,5), "key2":(2,3), "key3":(2,2), "key4":(0,1), "key5":(5,6) }, 
// and coutner3 becomes { "key1":(2,2), "key2":(1,1), "key3":(2,2), "key4":(1,1), "key5":(3,3) }.
var entries = new[] {("key1",(1,2)), ("key2",(2,3)), ("key5",(2,4)), 
                     ("key1",(3,3)), ("key3",(1,0)), ("key3",(1,2)), 
                     ("key4",(0,1)), ("key5",(2,1)), ("key5",(1,1))}; // every key is associated with a value tuple
var counter2 = new Dictionary<string, Pair<int>>();
var counter3 = new Dictionary<string, Pair<int>>();
foreach (var entry in entries)
{
   counter2.Stat(entry.Item1, entry.Item2); // increase the tuple values, using the added mutable tuple class Pair<int>
   counter3.Stat(entry.Item1, (1,1)); // another counting that can be merged with counter2 later
}

// Merges counts, returns { "key1":(6,7), "key2":(3,4), "key3":(4,4), "key4":(1,2), "key5":(8,9) }
var merged = (new[] {counter2, counter3}).MergeStat();
```
### <a name="ForEachShortcut"></a>15. ForEach Shortcut

Now you can use following code to quickly specify iterations.

```c#
5.ForEach(i => Console.WriteLine(i)); // iteration index as input of the delegate, prints out 0,1,2,3,4
(1,5).ForEach(i => Console.WriteLine(i)); // prints out 1,2,3,4
(1,7,2).ForEach(i => Console.WriteLine(i)); // prints out 1,3,5

var arr = new[] {"a","for","each","short", "cut"};
arr.Foreach(item => Console.WriteLine(item.Length)); // prints out 1,3,4,5,3
arr.Foreach((index,item) => Console.WriteLine($"the length of the {index}th string is {item.Length}")); // accepts iteration indexes
arr.Foreach((index,item) => 
{
   Console.WriteLine($"the length of the {index}th string is {item.Length}")};
   if (item.Length == 3) return false; // returns false to break the iteration
   return true;
); // accepts iteration indexes
```

### <a name="IndexOfExtensions"></a>16. String IndexOf Extensions

A corresponding ``LastIndexOf`` is available for all methods of this category. Negative ``startIndex`` is supported.

**_IndexOf(predicate, startIndex, count)_**: Reports the index of the first character satisfying the specified predicate. You can specify the search starting position, and the number of character positions to examine.

```c#
var str = 'abc def ghj';
str.IndexOf(c=>c.IsWhiteSpace()); // returns 3
str.IndexOf(c=>c.IsWhiteSpace(), startIndex:4); // returns 7
str.IndexOf(c=>c.IsWhiteSpace(), startIndex:-6); // returns 7
str.IndexOf(c=>c.IsWhiteSpace(), startIndex:4, count:2); // returns -1
str.LastIndexOf(c=>c.IsWhiteSpace()); // returns 7
```

**_IndexOfAny(chars, startIndex, count, out hitIndex)_**: Reports the index of the first occurrence of any character in a specified char array. The index of the matched char in the char array is returned by an out parameter hitIndex. 

```c#
var str = 'abc def ghj';
str.IndexOfAny(new[] {'d','g','z'}, out int hitIndex); // function returns 4 ('d' matched), and hitIndex returns 0 (the index of 'd' is 0 in the char array).
```

**_IndexOfAny(strings, startIndex, count) : StringSearchResult_**: Reports the index of the first occurrence of any strings in a specified char array. A ``StringSearchResult`` object is returned containing all needed information.

### <a name="MultipleStringSearch"></a>17. Multiple Keyword Search

Adds a ``MultipleStringSearch`` class that provides methods for efficient multiple keywords search. The method could be 3 times faster than naive use of IndexOf for 10 keywords.

```c#
var msearcher = new MultipleStringSearch(keywords: new[] {"key1", "key2", "key3", "key4", ...}) // you can pass in as many keywords as you like.
var str = ... // any string to search for the keywords

var allResults = msearcher.FindAll(str, startIndex:0); // returns an array of StringSearchResult objects
var firstOccurrence = msearch.FindFirst(str, startIndex:0); // returns one StringSearchResult object representing the first occurrence of any of the keyword.
var containsAny = msearch.ContainsAny(str, startIndex:0); // checks if str contains any of the keyword
```
