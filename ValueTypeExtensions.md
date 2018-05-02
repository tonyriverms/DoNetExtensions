# Value-Type Extensions

If you feel the intellisense for value types looks really bleak, these extensions make potentially useful enrichment. This category currently includes:

[8. Bit Operations](#BitOperations)

[9. Conversion to Hexical String](#ConversiontoHexicalString)

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
