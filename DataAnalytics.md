# Data Analytics Extensions

14. [Dictionary-Based Data Processing](#DictionaryBasedDataProcessing)

### <a name="DictionaryBasedDataProcessing"></a>14. Dictionary-Based Data Preprocessing

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
