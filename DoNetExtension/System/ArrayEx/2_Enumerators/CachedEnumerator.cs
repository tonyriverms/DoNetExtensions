using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        /// <summary>
        /// Caches the current <see cref="System.Collections.Generic.IEnumerable{T}"/>. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;"/>
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="enumerable">The enumerable to cache.</param>
        /// <returns>An resetable enumerator that can enumerate each element in the provided <paramref name="enumerable"/>.</returns>
        public static IEnumerator<T> GetCachedEnumerator<T>(this IEnumerable<T> enumerable)
        {
            return new CachedEnumerator<T, T>(enumerable.GetEnumerator());
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.Generic.IEnumerable&lt;T1&gt;"/>. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;"/>
        /// </summary>
        /// <typeparam name="T1">The type of objects in the <paramref name="enumerable"/> to enumerate.</typeparam>
        /// <typeparam name="T2">The type of objects the cached enumerator yields.</typeparam>
        /// <param name="enumerable">The enumerable to cache.</param>
        /// <param name="converter">Provides a method that converts an element of type <c>T1</c> to the other type <c>T2</c> when that element is yielded by the cached enumerator. This argument can be <c>null</c>, indicating the implicit conversion is used. The date in the original <paramref name="enumerable"/> will not be affected.</param>
        /// <returns>An resetable enumerator that can enumerate each element (converted to type <c>T2</c> when the element is yielded) in the provided <paramref name="enumerable"/>.</returns>
        public static IEnumerator<T2> GetCachedEnumerator<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> converter)
        {
            return new CachedEnumerator<T1, T2>(enumerable.GetEnumerator(), converter);
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.IEnumerable"/>. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;"/>
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="enumerable">The enumerable to cache.</param>
        /// <returns>An resetable enumerator that can enumerate each element in the provided <paramref name="enumerable"/>.</returns>
        public static IEnumerator<T> GetCachedEnumerator<T>(this IEnumerable enumerable)
        {
            return new CachedEnumerator<T, T>(enumerable.GetEnumerator());
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.IEnumerable"/>. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;"/>
        /// </summary>
        /// <typeparam name="T">The type of objects the cached enumerator yields.</typeparam>
        /// <param name="enumerable">The enumerable to cache.</param>
        /// <param name="converter">Provides a method that converts an object to type <c>T</c> when that object is yielded by the cached enumerator. This argument can be <c>null</c>, indicating the implicit conversion is used. The date in the original <paramref name="enumerable"/> will not be affected.</param>
        /// <returns>An resetable enumerator that can enumerate each element (converted to type <c>T</c> when the element is yielded) in the provided <paramref name="enumerable"/>.</returns>
        public static IEnumerator<T> GetCachedEnumerator<T>(this IEnumerable enumerable, Func<object, T> converter)
        {
            return new CachedEnumerator<object, T>(enumerable.GetEnumerator(), converter);
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.Generic.IEnumerator{T}"/>. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;"/>
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="enumerator">The enumerator to cache.</param>
        /// <returns>An resetable enumerator that can enumerate each element in the provided <paramref name="enumerator"/>.</returns>
        public static IEnumerator<T> GetCachedEnumerator<T>(this IEnumerator<T> enumerator)
        {
            return new CachedEnumerator<T, T>(enumerator);
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.Generic.IEnumerator&lt;T1&gt;" />. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;" />
        /// </summary>
        /// <typeparam name="T1">The type of objects the <paramref name="enumerator" /> enumerates.</typeparam>
        /// <typeparam name="T2">The type of objects the cached enumerator yields.</typeparam>
        /// <param name="enumerator">The enumerator to cache.</param>
        /// <param name="converter">Provides a method that converts an element of type <c>T1</c> to the other type <c>T2</c> when that element is yielded by the cached enumerator. This argument can be <c>null</c>, indicating the implicit conversion is used.</param>
        /// <returns>An resetable enumerator that can enumerate each element (converted to type <c>T2</c> when the element is yielded) in the provided <paramref name="enumerator" />.</returns>
        public static IEnumerator<T2> GetCachedEnumerator<T1, T2>(this IEnumerator<T1> enumerator, Func<T1, T2> converter)
        {
            return new CachedEnumerator<T1, T2>(enumerator, converter);
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.IEnumerator"/>. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;"/>
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="enumerator">The enumerator to cache.</param>
        /// <returns>An resetable enumerator that can enumerate each element in the provided <paramref name="enumerator"/>.</returns>
        public static IEnumerator<T> GetCachedEnumerator<T>(this IEnumerator enumerator)
        {
            return new CachedEnumerator<T, T>(enumerator);
        }

        /// <summary>
        /// Caches the current <see cref="System.Collections.IEnumerator" />. For details on enumerator cache, see <see cref="CachedEnumerator&lt;T1, T2&gt;" />
        /// </summary>
        /// <typeparam name="T">The type of objects the cached enumerator yields.</typeparam>
        /// <param name="enumerator">The enumerator to cache.</param>
        /// <param name="converter">Provides a method that converts an object to the other type <c>T</c> when that element is yielded by the cached enumerator. This argument can be <c>null</c>, indicating the implicit conversion is used.</param>
        /// <returns>An resetable enumerator that can enumerate each element (converted to type <c>T</c> when the element is yielded) in the provided <paramref name="enumerator" />.</returns>
        public static IEnumerator<T> GetCachedEnumerator<T>(this IEnumerator enumerator, Func<object, T> converter)
        {
            return new CachedEnumerator<object, T>(enumerator, converter);
        }
    }

    /// <summary>
    /// Provides element caches for an <see cref="IEnumerator&lt;T1&gt;"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the elements which the source enumerator iterates.</typeparam>
    /// <typeparam name="T2">The type of the elements this cached enumerator returns.</typeparam>
    /// <remarks>
    /// The enumerators intended for one-time iteration does not support <c>Reset</c>, especially an iterator constructed on a method with <see cref="System.Collections.IEnumerable"/>, <see cref="System.Collections.IEnumerator"/>, <see cref="System.Collections.Generic.IEnumerable{T}"/> or <see cref="System.Collections.Generic.IEnumerator{T}"/> as the return type. Cached enumerator elegantly endows these one-time enumerators the ability to iterate unlimited times.
    /// <para>The following code demonstrates a one-time iterator and a cached iterator. Note that the iterator <c>e1</c> does not support reset after all elements have been yielded. On the contrary, <c>e2</c> can be used again and again.</para>
    /// <code>
    ///class Program
    ///{
    ///    static void Main()
    ///    {
    ///        var e1 = SomeNumbers();
    ///        while (e1.MoveNext()) Console.Write(e1.Current);
    ///        // Output: 358
    ///
    ///        try
    ///        {
    ///            e1.Reset();
    ///        }
    ///        catch
    ///        {
    ///            Console.WriteLine("Reset is not supported.");
    ///            //Output: Reset is not supported.

    ///            while (e1.MoveNext()) Console.Write(e1.Current);
    ///            //no output
    ///        }
    ///        
    ///        //GetCachedEnumerator is an extension method that internally uses the CachedEnumerator class.
    ///        var e2 = SomeNumbers().GetCachedEnumerator();
    ///        while (e2.MoveNext()) Console.Write(e2.Current);
    ///        // Output: 358
    ///        
    ///        e2.Reset();
    ///        while (e2.MoveNext()) Console.Write(e2.Current);
    ///        // Output: 358
    /// 
    ///        while (e2.MoveNext()) Console.Write(e2.Current);
    ///        // Output: 358
    ///        
    ///        Console.ReadKey();
    ///    }

    ///    public static System.Collections.IEnumerator SomeNumbers()
    ///    {
    ///        yield return 3;
    ///        yield return 5;
    ///        yield return 8;
    ///    }
    ///}
    /// </code>
    /// <para>Please NOTE that once an enumerator is cached, DO NOT use the original enumerator, and use the cached enumerator INSTEAD. When the <c>MoveNext</c> method is called on the original enumerator, the cached enumerator also moves to the next without caching the yielded element. This operation does not throw an exception, but it may cause logic inconsistency.</para>
    /// </remarks>
    public class CachedEnumerator<T1, T2> : IEnumerator<T2>
    {
        Func<T1, T2> _converter;
        IEnumerator _enum;
        object _cache;
        int _status;
        T2 _current;
        bool _hasNext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedEnumerator&lt;T1, T2&gt;"/> class.
        /// </summary>
        /// <param name="enumeratorToCache">An <see cref="System.Collections.Generic.IEnumerator{T}"/> to cache. DO NOT use this enumerator after it is cached, use the created cached enumerator INSTEAD.</param>
        /// <param name="converter">Provides a method that converts each yield of the original enumerator to another data type. This argument can be <c>null</c>, indicating the implicit conversion is used.</param>
        /// <exception cref="System.ArgumentNullException">Occurs when <paramref name="enumeratorToCache"/> is <c>null</c>.</exception>
        public CachedEnumerator(IEnumerator<T1> enumeratorToCache, Func<T1, T2> converter = null) : this((IEnumerator)enumeratorToCache, converter) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedEnumerator&lt;T1, T2&gt;"/> class.
        /// </summary>
        /// <param name="enumeratorToCache">An <see cref="System.Collections.IEnumerator"/> to cache. NOTE that this enumerator must yield objects of type <c>T1</c>, and DO NOT use this enumerator after it is cached, use the created cached enumerator INSTEAD.</param>
        /// <param name="converter">Provides a method that converts each yield of the original enumerator to another data type. This argument can be <c>null</c>, indicating the implicit conversion is used.</param>
        /// <exception cref="System.ArgumentNullException">Occurs when <paramref name="enumeratorToCache"/> is <c>null</c>.</exception>
        public CachedEnumerator(IEnumerator enumeratorToCache, Func<T1, T2> converter = null)
        {
            if (enumeratorToCache == null) throw new ArgumentNullException("enumeratorToCache");
            _enum = enumeratorToCache;
            _cache = new SinglyLinkedList<T2>();
            _converter = converter;
            _status = -3;
            _hasNext = false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _hasNext = true;
            if(_enum is IEnumerator<T1>)
                ((IEnumerator<T1>)_enum).Dispose();
            else if (_enum is IEnumerator<T2>)
                ((IEnumerator<T2>)_enum).Dispose();
            _cache = null;
        }

        object Collections.IEnumerator.Current
        {
            get { if (!_hasNext) throw new InvalidOperationException(); return _current; }
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The current.</value>
        /// <exception cref="System.InvalidOperationException">Occurs when this property is accessed before <see cref="MoveNext"/> is called.</exception>
        /// <returns>The element in the collection at the current position of the enumerator.</returns>
        /// <remarks>After an enumerator is created, the <see cref="MoveNext"/> method must be called to advance the enumerator to the first element of the collection before reading the value of the <see cref="Current"/> property; otherwise, <see cref="Current"/> is undefined and an <see cref="System.InvalidOperationException"/> will be thrown.</remarks>
        public T2 Current
        {
            get { if (!_hasNext) throw new InvalidOperationException("The Current property is undefined. Call the MoveNext method first."); return _current; }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns><c>true</c> if the enumerator was successfully advanced to the next element; <c>false</c> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (_enum.MoveNext())
            {
                switch (_status)
                {
                    case -3:
                        {
                            _hasNext = true;
                            _status = -1;
                            goto case -1;
                        }
                    case -1:
                        {
                            var list = (SinglyLinkedList<T2>)_cache;
                            _current = _converter == null ? (T2)((object)_enum.Current) : _converter((T1)_enum.Current);
                            list.AddLast(_current);
                            return true;
                        }
                    case -2:
                        {
                            _current = (T2)_enum.Current;
                            return true;
                        }
                    default:
                        {
                            _current = (T2)_enum.Current;
                            ((T2[])_cache)[_status] = _current;
                            ++_status;
                            return true;
                        }
                }
            }
            else
            {
                _hasNext = false;
                return false;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            if (_hasNext)
            {
                switch (_status)
                {
                    case -1:
                        {
                            try
                            {
                                _enum.Reset();
                                var list = (SinglyLinkedList<T2>)_cache;
                                list.Clear();
                            }
                            catch (NotSupportedException)
                            {
                                while (this.MoveNext()) ;
                                Reset();
                            }
                            break;
                        }
                    case -2:
                        {
                            _enum.Reset();
                            break;
                        }
                    default:
                        {
                            _enum.Reset();
                            _status = 0;
                            break;
                        }
                }
            }
            else
            {
                switch (_status)
                {
                    case -3: break;
                    case -1:
                        {
                            _status = 0;
                            ((IEnumerator<T1>)_enum).Dispose();
                            var list = (SinglyLinkedList<T2>)_cache;
                            _enum = list.GetEnumerator();
                            _cache = new T2[list.Count];
                            _hasNext = true;
                            break;
                        }
                    case -2:
                        {
                            _enum.Reset();
                            _hasNext = true;
                            break;
                        }
                    default:
                        {
                            var arr = (T2[])_cache;
                            ((IEnumerator<T2>)_enum).Dispose();
                            _enum = arr.GetEnumerator();
                            _status = -2;
                            _hasNext = true;
                            break;
                        }
                }
            }
        }
    }
}
