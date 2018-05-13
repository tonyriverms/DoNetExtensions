# Data Analytics Extensions

13) [Mutable Tuples for Data Processing](#MutableTuplesforDataProcessing)
14. [Dictionary-Based Data Processing](#DictionaryBasedDataProcessing)

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
list1.Add(2,3);
list2.Add(2,3);
```

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
