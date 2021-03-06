# Char & String Extensions

[10. Char Extensions](#CharExtensions)

[16. String IndexOf Extensions](#IndexOfExtensions)

[17. Multiple Keyword Search](#MultipleStringSearch)

[18. Enhanced Trim](#EnhancedTrim)

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


**_IndexOfFirstNonSpaceCharacter(startIndex) : int**: Gets the index of the first non-white-space Unicode character in the string at and after the search starting position. A similar method **FirstNonSpaceCharacter(startIndex)** returns the non-white-space character instead of the index.

**_IndexOfLastNonSpaceCharacter(startIndex) : int**: Gets the index of the last non-white-space Unicode character in the string at and before the search starting position. A similar method **LastNonSpaceCharacter(startIndex)** returns the non-white-space character instead of the index.

### <a name="MultipleStringSearch"></a>17. Multiple Keyword Search

Adds a ``MultipleStringSearch`` class that provides methods for efficient multiple keywords search. The method could be 3 times faster than naive use of IndexOf for 10 keywords.

```c#
var msearcher = new MultipleStringSearch(keywords: new[] {"key1", "key2", "key3", "key4", ...}) // you can pass in as many keywords as you like.
var str = ...; // any string to search for the keywords

var allResults = msearcher.FindAll(str, startIndex:0); // returns an array of StringSearchResult objects
var firstOccurrence = msearch.FindFirst(str, startIndex:0); // returns one StringSearchResult object representing the first occurrence of any of the keyword.
var containsAny = msearch.ContainsAny(str, startIndex:0); // checks if str contains any of the keyword
```

### <a name="EnhancedTrim"></a>18. Enhanced Trim

Trims characters or substrings at the beginning or end of a string instance.

**_TrimStart(predicate)_**: Removes all leading occurrences of characters that satisfy the specified predicate. Returns the original instance if no characters are removed. Other similar functions include **_TrimEnd(predicate)_** and **_Trim(predicate)_**. Note .NET has build-in methods **_TrimStart(chars)_**, **_TrimEnd(chars)_** and **_Trim(chars)_** that remove leading or tailing characters in a specified char array.

**_TrimStart(strings)_**: Removes all leading occurrences of specified strings. Other similar functions include **_TrimEnd(strings)_** and **_Trim(strings)_**. NOTE only the first matched leading and tailing occurrences will be removed. 

```c#
var str = "123123abc4569";
Console.WriteLine(str.TrimStart(c => c.IsDigit()));  // prints abc4569
Console.WriteLine(str.Trim(c => c.IsDigit()));  // prints abc
Console.WriteLine(str.Trim("123", "4569");  // prints 123abc, only the first occurrence of "123" is trimmed
```


