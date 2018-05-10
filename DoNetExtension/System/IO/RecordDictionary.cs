using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoNetExtension.System.IO;

//Note: All the stuff in this file has been tested, but not guaranteed bug-free for now. (06/06/10)

namespace System.IO
{
    /// <summary>
    /// Provides methods to organize records represented by a set of System.IO.RecordStream objects in a dictionary-like approach, 
    /// and optimizes the space occupancy.
    /// </summary>
    public class RecordDictionary<T> : IRecord 
        where T : IBasicRecord, new()
    {
        Dictionary<string, T> _records;
        Stream _infoStream, _dataStream;
        long _infoPosition;
        bool _loaded;
        int _initialCapability;

        /// <summary>
        /// DO NOT use this constructor. This constructor makes any instance a viable child of another instance of this class.
        /// </summary>
        public RecordDictionary() { }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordDictionary object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        /// <param name="initialCapability">The initial capability of this record group. 
        /// The default value is the same as that of a System.Collection.Generic.List{T} class.</param>
        public RecordDictionary(Stream infoStream, Stream dataStream, int initialCapability)
            : this(infoStream, -1, dataStream, initialCapability)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordDictionary object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        public RecordDictionary(Stream infoStream, Stream dataStream)
            : this(infoStream, -1, dataStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordDictionary object.
        /// </summary>
        /// <param name="baseStream">A System.IO.Stream that stores both section information and the real data.</param>
        public RecordDictionary(Stream baseStream)
            : this(baseStream, -1, baseStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordDictionary object.
        /// </summary>
        /// <param name="baseStream">A System.IO.Stream that stores both section information and the data.</param>
        /// <param name="infoPosition">The position of the section information in the info-stream.</param>
        public RecordDictionary(Stream baseStream, long infoPosition)
            : this(baseStream, infoPosition, baseStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordDictionary object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="infoPosition">The position of the section information in the stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        /// <param name="initialCapability">The initial capability of this record group. 
        /// The default value is the same as that of a System.Collection.Generic.List{T} class.</param>
        public RecordDictionary(Stream infoStream, long infoPosition, Stream dataStream, int initialCapability)
        {
            //if (infoPosition <= 0) throw new ArgumentOutOfRangeException(
            //    IOResources.ERR_IRecord_InvalidSectionLength);
            _infoStream = infoStream;
            _dataStream = dataStream;
            _infoPosition = infoPosition;
            _initialCapability = initialCapability;
            _loaded = false;
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordDictionary object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="infoPosition">The position of the section information in the stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        public RecordDictionary(Stream infoStream, long infoPosition, Stream dataStream)
        {
            //if (infoPosition <= 0) throw new ArgumentOutOfRangeException(
            //    IOResources.ERR_IRecord_InvalidSectionLength);
            _infoStream = infoStream;
            _dataStream = dataStream;
            _infoPosition = infoPosition;
            _initialCapability = -1;
            _loaded = false;
        }

        public bool ContainsKey(string key)
        {
            return _records.ContainsKey(key);
        }

        /// <summary>
        /// Adds a compatible record to this record dictionary. Like an ordinary dictionary every record must have a unique key. 
        /// Call this method after you initialize this dictionary by calling LoadInfo method, or an InvalidOperationException will be thrown.
        /// </summary>
        /// <param name="record">The record to be added.</param>
        public void Add(string key, T record)
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            if (this._infoStream == record.InfoStream && this._dataStream == record.DataStream)
                _records.Add(key, record);
            else throw new InvalidOperationException(
                IOResources.ERR_IRecord_NotCompatible);
        }

        /// <summary>
        /// Adds an empty record of type System.IO.RecordStream to this record group. 
        /// You can write data to this empty record later by retrieving it by key and using it as a regular System.IO.Stream.
        /// Call this method after you initialize this dictionary by calling LoadInfo method, or an InvalidOperationException will be thrown.
        /// </summary>
        /// <param name="count">The number of the System.IO.RecordStream objects to add.</param>
        public void AddNew(string key)
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            var newRecord = new T()
            {
                DataStream = _dataStream,
                InfoStream = _infoStream,
                InfoPosition = -1,
                //Manager = _manager
            };
            _records.Add(key, newRecord);
        }

        /// <summary>
        /// Removes a record specified by its key.
        /// </summary>
        /// <param name="index">The key of the record to remove.</param>
        public void Remove(string key)
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            var r = _records[key];
            _records.Remove(key);
        }

        /// <summary>
        /// Removes all records in this record dictionary.
        /// </summary>
        public void RemoveAll()
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            _records.Clear();
        }

        /// <summary>
        /// Retrieves a record in this record dictionary by key.
        /// </summary>
        /// <param name="index">The key of the record to retrieve.</param>
        /// <returns>A record with the specified key.</returns>
        public T this[string key]
        {
            get
            {
                if (_loaded) return _records[key];
                else throw new InvalidOperationException(
                    IOResources.ERR_IRecord_NotLoaded);
            }
            set
            {
                if(!_loaded)
                    throw new InvalidOperationException(
                                        IOResources.ERR_IRecord_NotLoaded);

                if (this._dataStream == value.DataStream && this._infoStream == value.InfoStream)
                    _records[key] = value;
                else throw new InvalidOperationException(
                    IOResources.ERR_IRecord_NotCompatible);
            }
        }

        /// <summary>
        /// Loads information necessary for record management. Call this method before calling any other operations.
        /// </summary>
        public virtual void LoadInfo()
        {
            if (_loaded)
                return;

            //ExHandling: No need to handle "_loade = false"

            _records = new Dictionary<string, T>();

            if (_infoPosition != -1)
            {
                _infoStream.SeekTo(_infoPosition);
                var list = new List<KeyValuePair<string, long>>();
                _infoStream.ReadObjects<KeyValuePair<string, long>>(list, _bytesToPair);

                for (int i = 0; i < list.Count; i++)
                    _records.Add(list[i].Key, new T()
                        {
                            InfoPosition = list[i].Value,
                            DataStream = _dataStream,
                            InfoStream = _infoStream,
                            //Manager = _manager
                        });
            }

            _loaded = true;

            //ExHandling: No need to handle "_infoPosition == -1"
        }

        byte[] _pairToBytes(KeyValuePair<string, long> pair)
        {
            MemoryStream ms = new MemoryStream(256);
            ms.WriteString(pair.Key);
            ms.WriteInt64(pair.Value);
            return ms.ToArray();
        }

        KeyValuePair<string, long> _bytesToPair(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            string str = ms.ReadString();
            long val = ms.ReadInt64();
            return new KeyValuePair<string, long>(str, val);
        }

        /// <summary>
        /// Saves record management information.
        /// </summary>
        public virtual void SaveInfo()
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);

            var list = new List<KeyValuePair<string, long>>();
            foreach (var pair in _records)
            {
                pair.Value.SaveInfo();
                list.Add(new KeyValuePair<string, long>(pair.Key, pair.Value.InfoPosition));
            }

            if (_infoPosition < 0)
            {
                _infoPosition = _infoStream.Length;
                _infoStream.SeekTo(_infoPosition);
                _infoStream.WriteObjects<KeyValuePair<string, long>>
                    (list.GetEnumerator(),
                    WritingMode.New,
                    _pairToBytes);
            }
            else
            {
                _infoStream.SeekTo(_infoPosition);
                _infoStream.WriteObjects<KeyValuePair<string, long>>
                    (list.GetEnumerator(),
                    WritingMode.Override,
                    _pairToBytes);
            }
        }

        /// <summary>
        /// Unloads record management information.
        /// The unloaded information is able to be reloaded again later. 
        /// Once this information is unloaded, this record is not retrievable before the LoadInfo method is called.
        /// </summary>
        public virtual void UnloadInfo()
        {
            foreach(var item in _records.Values)
                item.UnloadInfo();
            _records.Clear();
            _records = null;
            _loaded = false;
        }

        /// <summary>
        /// Removes all the data of all records. But the management information will be retained.
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in _records.Values)
                item.Clear();
            _records.Clear();
        }

        /// <summary>
        /// Sets a delegation method to write additional LENGTH-FIXED information. 
        /// DO NOT write any data of indefinite or changable length, such as a linked list. 
        /// If this property is set to an bugged method the data in the info-stream can be corrupted.
        /// </summary>
        protected Action<Stream> WriteMoreInfo { get; set; }

        /// <summary>
        /// Sets a delegation method to read additional LENGTH-FIXED information. 
        /// If this property is set to an bugged method for the most part a validity-check failure will occure.
        /// </summary>
        protected Action<Stream> ReadMoreInfo { get; set; }

        /// <summary>
        /// Gets the number of records in this record dictionary. This record dictionary must already have been loaded when you access this property.
        /// </summary>
        public int Count
        {
            get
            {
                if (_loaded)
                    return _records.Count;
                else
                    throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        public long InfoPosition
        {
            get { return _infoPosition; }
            set { _infoPosition = value; }
        }

        Stream IBasicRecord.InfoStream
        {
            get { return _infoStream; }
            set { _infoStream = value; }
        }

        Stream IBasicRecord.DataStream
        {
            get { return _dataStream; }
            set { _dataStream = value; }
        }

        //ISpaceManager IRecord.Manager
        //{
        //    get { return _manager; }
        //    set { _manager = value; }
        //}

        Action<Stream> IRecord.WriteMoreInfo { get; set; }
        Action<Stream> IRecord.ReadMoreInfo { get; set; }
    }
}
