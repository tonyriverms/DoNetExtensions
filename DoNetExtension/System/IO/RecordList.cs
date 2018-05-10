using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoNetExtension.System.IO;

//Note: All the stuff in this file has been tested, but not guaranteed bug-free for now. (06/06/10)

namespace System.IO
{
    /// <summary>
    /// Provides some common operations for System.IO.IRecord and System.IO.IRecordManager objects.
    /// </summary>
    public static class RecordOperations
    {
        /// <summary>
        /// Checks compatibility (being on the same info-stream and data-stream) between this record and another record.
        /// </summary>
        /// <param name="thisRecord">This System.IO.IRecord object.</param>
        /// <param name="record">Another System.IO.IRecord object.</param>
        /// <returns>true if the two records are weakly compatible with each other; otherwise false.</returns>
        public static bool CheckCompatibility(this IRecord thisRecord, IRecord record)
        {
            return thisRecord.InfoStream == record.InfoStream &&
                thisRecord.DataStream == record.DataStream;
        }
    }

    /// <summary>
    /// Provides methods to organize records represented by a set of System.IO.RecordStream objects in a list-like approach, 
    /// and optimizes the space occupancy.
    /// </summary>
    public class RecordList<T> : IRecord where T : IRecord, new()
    {
        List<T> _records;
        Stream _infoStream, _dataStream;
        long _infoPosition;
        bool _loaded;
        int _initialCapability;
        ISpaceManager _manager;

        /// <summary>
        /// DO NOT use this constructor. This constructor makes any instance a viable child of another instance of this class.
        /// </summary>
        public RecordList() { }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        /// <param name="initialCapability">The initial capability of this record group. 
        /// The default value is the same as that of a System.Collection.Generic.List{T} class.</param>
        public RecordList(Stream infoStream, Stream dataStream, int initialCapability)
            : this(infoStream, -1, dataStream, initialCapability)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        public RecordList(Stream infoStream, Stream dataStream)
            : this(infoStream, -1, dataStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="baseStream">A System.IO.Stream that stores both section information and the data.</param>
        public RecordList(Stream baseStream)
            : this(baseStream, -1, baseStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="baseStream">A System.IO.Stream that stores both section information and the data.</param>
        /// <param name="infoPosition">The position of the section information in the info-stream.</param>
        public RecordList(Stream baseStream, long infoPosition)
            : this(baseStream, infoPosition, baseStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="infoPosition">The position of the section information in the stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        /// <param name="initialCapability">The initial capability of this record group. 
        /// The default value is the same as that of a System.Collection.Generic.List{T} class.</param>
        public RecordList(Stream infoStream, long infoPosition, Stream dataStream, int initialCapability)
        {
            _infoStream = infoStream;
            _dataStream = dataStream;
            _infoPosition = infoPosition;
            _initialCapability = initialCapability;
            _loaded = false;
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="infoStream">A System.IO.Stream that stores section infomation. 
        /// The section information will be stored at the current position of this stream.</param>
        /// <param name="infoPosition">The position of the section information in the info-stream.</param>
        /// <param name="dataStream">A System.IO.Stream that stores real data.</param>
        public RecordList(Stream infoStream, long infoPosition, Stream dataStream)
        {
            _infoStream = infoStream;
            _dataStream = dataStream;
            _infoPosition = infoPosition;
            _initialCapability = -1;
            _loaded = false;
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="records">An array of records to be added in this record group. 
        /// The frist record defines the section length and the streams all the other records should have. 
        /// All the records before the first incompatible record will be added into this record group.</param>
        public RecordList(params T[] records)
        {
            var firstRecord = (IRecord)records[0];
            _infoStream = firstRecord.InfoStream;
            _dataStream = firstRecord.DataStream;
            _infoPosition = firstRecord.InfoPosition;
            _records = new List<T>(records.Length);
            for (int i = 1; i < records.Length; i++)
                Add(records[i]);
            _loaded = true;
        }

        /// <summary>
        /// Initializes a new instance of System.IO.RecordList object.
        /// </summary>
        /// <param name="records">A list of records to be added in this record group. 
        /// The frist record defines the section length and the streams all the other records should have. 
        /// All the records before the first incompatible record will be added into this record group.</param>
        public RecordList(IList<T> records)
        {
            var firstRecord = (IRecord)records[0];
            _infoStream = firstRecord.InfoStream;
            _dataStream = firstRecord.DataStream;
            _infoPosition = firstRecord.InfoPosition;
            _records = new List<T>(records.Count);
            for (int i = 1; i < records.Count; i++)
                Add(records[i]);
            _loaded = true;
        }

        /// <summary>
        /// Adds a compatible record to this record group. 
        /// Note that the same record SHOULD NOT be added twice or more into this record list. 
        /// This method does not check repeatition.
        /// </summary>
        /// <param name="record">The record to be added.</param>
        public void Add(T record)
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            if (this._infoStream == record.InfoStream && this._dataStream == record.DataStream)
                _records.Add(record);
            else throw new InvalidOperationException(IOResources.ERR_IRecord_NotCompatible);
        }

        /// <summary>
        /// Adds a number of compatible records to this record group. 
        /// If there are imcompatible ones in the input, they will be ignored.
        /// </summary>
        /// <param name="records">The records to be added.</param>
        public void AddRange(IEnumerable<T> records)
        {
            foreach (var record in records)
                Add(record);
        }

        /// <summary>
        /// Adds a number of System.IO.IRecord objects to this record list.
        /// </summary>
        /// <param name="count">The number of the System.IO.IRecord objects to add.</param>
        public void AddNew(int count)
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            while (count-- > 0)
            {
                var newRecord = new T()
                {
                    DataStream = _dataStream,
                    InfoStream = _infoStream,
                    //Manager = _manager,
                    InfoPosition = -1
                };
                _records.Add(newRecord);
            }
        }

        /// <summary>
        /// Adds a System.IO.IRecord objects to this record list.
        /// </summary>
        /// <param name="count">The number of the System.IO.IRecord objects to add.</param>
        public void AddNew()
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);

            var newRecord = new T()
            {
                DataStream = _dataStream,
                InfoStream = _infoStream,
                //Manager = _manager,
                InfoPosition = -1
            };
            _records.Add(newRecord);
        }

        /// <summary>
        /// Gets the last System.IO.IRecord object in this record list.
        /// </summary>
        public T Last
        {
            get
            {
                return _records[_records.Count - 1];
            }
        }

        /// <summary>
        /// Removes a record at the given position.
        /// </summary>
        /// <param name="index">The position of the record to remove.</param>
        public void RemoveAt(int index)
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            _records.RemoveAt(index);
        }

        /// <summary>
        /// Removes all records in this record group.
        /// </summary>
        public void RemoveAll()
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            _records.Clear();
        }

        /// <summary>
        /// Gets a record in this record group by position (index).
        /// </summary>
        /// <param name="index">The position of the record to get.</param>
        /// <returns>A record at the specified position.</returns>
        public T this[int index]
        {
            get
            {
                if (_loaded)
                    return _records[index];
                else
                    throw new InvalidOperationException(
                        IOResources.ERR_IRecord_NotLoaded);
            }
            set
            {
                if (!_loaded)
                    throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
                if (this._dataStream == value.DataStream && this._infoStream == value.InfoStream)
                    _records[index] = value;
                else throw new InvalidOperationException(IOResources.ERR_IRecord_NotCompatible);
            }
        }

        /// <summary>
        /// Loads the section information of all records.
        /// </summary>
        public virtual void LoadInfo()
        {
            if (_loaded)
                return;

            //ExHandling: No need to handle "_loade = false"
            _records =
                (_initialCapability <= 0 ? new List<T>() : new List<T>(_initialCapability));

            if (_infoPosition != -1)
            {
                _infoStream.SeekTo(_infoPosition);
                var list = new List<long>();
                _infoStream.ReadList(list);

                for (int i = 0; i < list.Count; i++)
                    _records.Add(new T()
                    {
                        InfoPosition = list[i],
                        DataStream = _dataStream,
                        InfoStream = _infoStream,
                        //Manager = _manager
                    });
            }

            this._loaded = true;

            //ExHandling: No need to handle "_infoPosition == -1"
        }

        /// <summary>
        /// Saves the section information of all records.
        /// </summary>
        public virtual void SaveInfo()
        {
            if (!_loaded)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);

            var list = new List<long>();
            foreach (var pair in _records)
            {
                pair.SaveInfo();
                list.Add(pair.InfoPosition);
            }

            if (_infoPosition == -1)
            {
                _infoPosition = _infoStream.Length;
                _infoStream.SeekTo(_infoPosition);
                _infoStream.WriteList(list, WritingMode.New);
            }
            else
            {
                _infoStream.SeekTo(_infoPosition);
                _infoStream.WriteList(list, WritingMode.Override);
            }

        }

        /// <summary>
        /// Unloads section information of all records. 
        /// The section information is able to be loaded again later. 
        /// Once the section information is unloaded, this record is not readable before the LoadInfo method is called.
        /// </summary>
        public virtual void UnloadInfo()
        {
            for (int i = 0; i < _records.Count; i++)
                _records[i].UnloadInfo();
            _records.Clear();
            _records = null;
            _loaded = false;
        }

        /// <summary>
        /// Removes all the data of all records. But the section information will be retained.
        /// </summary>
        public virtual void Clear()
        {
            for (int i = 0; i < _records.Count; i++)
                _records[i].Clear();
            _records.Clear();
        }

        /// <summary>
        /// Sets a delegation method to write additional LENGTH-FIXED information. 
        /// DO NOT write any data of indefinite or changable length, such as a linked list. 
        /// If this property is set to an bugged method the data in the info-stream can be corrupted.
        /// </summary>
        public Action<Stream> WriteMoreInfo { get; set; }

        /// <summary>s
        /// Sets a delegation method to read additional LENGTH-FIXED information. 
        /// If this property is set to an bugged method for the most part a validity-check failure will occure.
        /// </summary>
        public Action<Stream> ReadMoreInfo { get; set; }

        /// <summary>
        /// Gets the number of records in this record list. This record list must be loaded when you access this property.
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
        }

        long IBasicRecord.InfoPosition
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

    }
}
