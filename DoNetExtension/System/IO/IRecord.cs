using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    public interface IBasicRecord
    {
        /// <summary>
        /// Loads the section information of this record. 
        /// This method should presume the info-stream is not at the right position (i.e. call SeekTo method befor reading) and 
        /// should NOT wind the stream back where it was right before the reading started.
        /// </summary>
        void LoadInfo();

        /// <summary>
        /// Saves the section information of this record. 
        /// This method should presume the info-stream is not at the right position (i.e. call SeekTo method befor writing) and 
        /// should NOT wind the stream back where it was right before the saving started.
        /// </summary>
        void SaveInfo();

        /// <summary>
        /// Unloads section information of this record. 
        /// The section information should be able to be loaded again later. 
        /// Once the section information is unloaded, this record should not be readable before the LoadInfo method is called.
        /// </summary>
        void UnloadInfo();

        /// <summary>
        /// Gets or sets the stream where the section information is stored. 
        /// This property is meant to be used in the code of class implementing this interface. 
        /// ANY class implementing this interface SHOULD NOT publicly expose this property.
        /// Be CAREFULL with the existing data in this stream if you have to tamper with them. 
        /// If the section information is corrupted, all the data will be lost.
        /// </summary>
        Stream InfoStream { get; set; }

        /// <summary>
        /// Gets or sets the stream where the data is stored. 
        /// This property is meant to be used in the code of class implementing this interface. 
        /// ANY class implementing this interface SHOULD NOT publicly expose this property.
        /// Be CAREFULL with the existing data in this stream if you have to tamper with them.
        /// </summary>
        Stream DataStream { get; set; }

        /// <summary>
        /// Gets or sets the position where the section information is stored in the info-stream. 
        /// This property is meant to be used in the code of class implementing this interface. 
        /// ANY class implementing this interface SHOULD NOT publicly expose this property.
        /// </summary>
        long InfoPosition { get; set; }

        /// <summary>
        /// Removes all the data in this record. 
        /// </summary>
        void Clear();
    }

    //Important:

    /// <summary>
    /// Defines the methods and properties a record that a System.IO.IRecordManager can manage.
    /// </summary>
    public interface IRecord : IBasicRecord
    {

        /// <summary>
        /// Gets or sets a manager for this record. 
        /// This property is meant to be used in the code of class implementing this interface. 
        /// ANY class implementing this interface SHOULD NOT publicly expose this property.
        /// </summary>
        //ISpaceManager Manager { get; set; }

        /// <summary>
        /// Gets or sets a delegation method to write additional LENGTH-FIXED information. 
        /// DO NOT write any data of indefinite or changable length, such as a linked list. 
        /// If this property is set to an bugged method the data in the info-stream can be corrupted.
        /// </summary>
        Action<Stream> WriteMoreInfo { get; set; }

        /// <summary>
        /// Gets or sets a delegation method to read additional LENGTH-FIXED information. 
        /// If this property is set to an bugged method for the most part a validity-check failure will occure.
        /// </summary>
        Action<Stream> ReadMoreInfo { get; set; }
    }
}
