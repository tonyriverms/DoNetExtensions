# Essential Extensions

The "essentials" are those extensions that prevail our coding and projects. We hope these simple yet thoughtful "must-haves" would bring better consistency, readability and productivity to your code and project as well. This category currently includes:

[1. Consistent Containment Check](#ConsistentContainmentCheck)

[3. Consistent Emptiness Check](#ConsistentEmptinessCheck)

[7. Value Swap](#ValueSwap)

[12. Sort Enhancement](#SortEnhancement)

[15. ForEach Shortcut](#ForEachShortcut)

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
); // 
