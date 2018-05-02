# Char & String Extensions

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
