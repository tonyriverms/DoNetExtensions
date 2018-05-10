using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    public enum RecordKeepMode
    {
        KeepObjectAndInfo,
        KeepObject,
        KeepInfo,
        KeepNone
    }

    public class Record<T> : RecordStream where T:class
    {
        T _object;

        public Func<Stream, T> ReadOperation { get; set; }

        RecordKeepMode _mode;

        public Record()
        {
            _mode = RecordKeepMode.KeepObject;
        }

        public Record(T obj, Func<Stream, T> readOperation)
        {
            _object = obj;
            ReadOperation = readOperation;
            MetaNumber = obj.GetHashCode();
        }

        public void SaveData(Action<T> saveOperation, int sectionLength = 512)
        {
            LoadInfo();
            if (!Initialized)
                CreateNew(sectionLength);
            this.SeekToBegin();

            saveOperation(_object);
            SaveInfo();

            if (_mode == RecordKeepMode.KeepObject)
                UnloadInfo();
            else if (_mode == RecordKeepMode.KeepInfo)
                _object = default(T);
            else if (_mode == RecordKeepMode.KeepNone)
            {
                UnloadInfo();
                _object = default(T);
            }
        }

        public void SetData(T data)
        {
            _object = data;
            MetaNumber = data.GetHashCode();
        }

        public T GetData()
        {
            return GetData(ReadOperation);
        }

        public T GetData(Func<Stream, T> readOpearation)
        {
            if (readOpearation == null)
                throw new InvalidOperationException();

            if (_object != null) return _object;

            this.LoadInfo();
            this.SeekToBegin();
            if (_mode == RecordKeepMode.KeepObject)
            {
                _object = readOpearation(this);
                this.UnloadInfo();
                return _object;
            }
            else if (_mode == RecordKeepMode.KeepInfo)
                return readOpearation(this);
            else if (_mode == RecordKeepMode.KeepNone)
            {
                var obj = readOpearation(this);
                this.UnloadInfo();
                return obj;
            }
            else
            {
                _object = readOpearation(this);
                return _object;
            }
        }


        public override int GetHashCode()
        {
            return MetaNumber;
        }

        public override bool Equals(object obj)
        {
            return this.GetData().Equals(obj);
        }
    }
}
