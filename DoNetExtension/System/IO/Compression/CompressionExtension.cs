using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.IO.Compression
{
    public enum TextCompressionMethods : byte
    {
        Gamma,
        Delta,
        Huffman
    }

    /// <summary>
    /// Representing compression algorithms.
    /// </summary>
    public enum ByteCompressionMethods : byte
    {
        /// <summary>
        /// No compression algorithm is used. The original data will be returned.
        /// </summary>
        None = 0,
        /// <summary>
        /// Uses GZip algorithm and performs an optimal compression.
        /// </summary>
        GZipOptimal = 1,
        /// <summary>
        /// Uses Deflate algorithm and performs an optimal compression.
        /// </summary>
        DeflateOptimal = 2,
        /// <summary>
        /// Uses GZip algorithm and performs a fast compression.
        /// </summary>
        GZipFast = 3,
        /// <summary>
        /// Uses Deflate algorithm and performs a fast compression.
        /// </summary>
        DeflateFast = 4
    }

    /// <summary>
    /// Provides methods to easily compress byte arrays.
    /// </summary>
    public static class CompressionEx
    {
        /// <summary>
        /// Compresses a byte array using a specified algorithm.
        /// </summary>
        /// <param name="dataToCompress">The byte array to compress.</param>
        /// <param name="algorithm">The algorithm used to compress the array. 
        /// This method will check the compression rate after the compression is done, 
        /// and if it is not smaller than 1 (indicating the "compressed" data takes even more space than the original data and the compression is ineffective), 
        /// the original data will be returned and this argument will be set <c>ByteCompressionMethods.None</c>.</param>
        /// <returns>
        /// The compressed byte array if the compression is successful; 
        /// or the original bytes if the compression is ineffective.
        /// </returns>
        public static byte[] Compress(this byte[] dataToCompress, ref ByteCompressionMethods algorithm)
        {
            return Compress(dataToCompress, 0, ref algorithm);
        }

        /// <summary>
        /// Compresses a byte array using a specified algorithm.
        /// </summary>
        /// <param name="dataToCompress">The byte array to compress.</param>
        /// <param name="startIndex">The zero-based position in the array where the compression begins.</param>
        /// <param name="algorithm">The algorithm used to compress the array. 
        /// This method will check the compression rate after the compression is done, 
        /// and if it is not smaller than 1 (indicating the "compressed" data takes even more space than the original data and the compression is ineffective), 
        /// the original data will be returned and this argument will be set <c>ByteCompressionMethods.None</c>.</param>
        /// <returns>
        /// The compressed byte array if the compression is successful; 
        /// or the bytes in the original byte array from <paramref name="startIndex"/> to the end if the compression is ineffective.
        /// </returns>
        public static byte[] Compress(this byte[] dataToCompress, int startIndex, ref ByteCompressionMethods algorithm)
        {
            byte[] compressedData;
            using (MemoryStream compressedMs = new MemoryStream())
            {
                switch (algorithm)
                {
                    case ByteCompressionMethods.GZipOptimal:
                        {
                            using (GZipStream gzs = new GZipStream(compressedMs, CompressionLevel.Optimal))
                                gzs.Write(dataToCompress, startIndex, dataToCompress.Length - startIndex);

                            compressedData = compressedMs.ToArray();

                            break;
                        }
                    case ByteCompressionMethods.GZipFast:
                        {
                            using (GZipStream gzs = new GZipStream(compressedMs, CompressionLevel.Fastest))
                                gzs.Write(dataToCompress, startIndex, dataToCompress.Length - startIndex);

                            compressedData = compressedMs.ToArray();

                            break;
                        }
                    case ByteCompressionMethods.DeflateOptimal:
                        {
                            using (DeflateStream ds = new DeflateStream(compressedMs, CompressionLevel.Optimal))
                                ds.Write(dataToCompress, startIndex, dataToCompress.Length - startIndex);
                            compressedData = compressedMs.ToArray();

                            break;
                        }
                    case ByteCompressionMethods.DeflateFast:
                        {
                            using (DeflateStream ds = new DeflateStream(compressedMs, CompressionLevel.Fastest))
                                ds.Write(dataToCompress, startIndex, dataToCompress.Length - startIndex);
                            compressedData = compressedMs.ToArray();

                            break;
                        }
                    default:
                        {
                            var tmpMs = new MemoryStream(dataToCompress, startIndex, dataToCompress.Length - startIndex);
                            return tmpMs.ToArray();
                        }
                }
            }

            if (compressedData.Length < dataToCompress.Length)
                return compressedData;
            else
            {
                algorithm = ByteCompressionMethods.None;
                return dataToCompress;
            }
        }

        /// <summary>
        /// Decompresses a byte array using a specified algorithm.
        /// </summary>
        /// <param name="dataToDecompress">The byte array to decompress.</param>
        /// <param name="algorithm">The algorithm used to decompress the array.</param>
        /// <returns>The decompressed byte array.</returns>
        public static byte[] DeCompress(this byte[] dataToDecompress, ByteCompressionMethods algorithm)
        {
            return DeCompress(dataToDecompress, 0, algorithm);
        }

        /// <summary>
        /// Decompresses a byte array using a specified algorithm.
        /// </summary>
        /// <param name="dataToDecompress">The byte array to decompress.</param>
        /// <param name="startIndex">The zero-based position in the array where the decompression begins.</param>
        /// <param name="algorithm">The algorithm used to decompress the array.</param>
        /// <returns>The decompressed byte array.</returns>
        public static byte[] DeCompress(this byte[] dataToDecompress, int startIndex, ByteCompressionMethods algorithm)
        {
            byte[] decompressedData;
            int tmp;
            using (MemoryStream compressedMs = new MemoryStream(dataToDecompress, startIndex, dataToDecompress.Length - startIndex))
            {
                switch (algorithm)
                {
                    case ByteCompressionMethods.GZipOptimal:
                    case ByteCompressionMethods.GZipFast:
                        {
                            using (Stream gzs = new GZipStream(compressedMs, CompressionMode.Decompress), decompressedMs = new MemoryStream())
                            {
                                while ((tmp = ((GZipStream)gzs).ReadByte()) != -1)
                                    decompressedMs.WriteByte((byte)tmp);
                                decompressedData = ((MemoryStream)decompressedMs).ToArray();
                            }
                            break;
                        }
                    case ByteCompressionMethods.DeflateOptimal:
                    case ByteCompressionMethods.DeflateFast:
                        {
                            compressedMs.SeekForward(startIndex);
                            using (Stream ds = new DeflateStream(compressedMs, CompressionMode.Decompress), decompressedMs = new MemoryStream())
                            {
                                while ((tmp = ((DeflateStream)ds).ReadByte()) != -1)
                                    decompressedMs.WriteByte((byte)tmp);
                                decompressedData = ((MemoryStream)decompressedMs).ToArray();
                            }
                            break;
                        }
                    default:
                        {
                            decompressedData = compressedMs.ToArray();
                            break;
                        }
                }
                return decompressedData;
            }
        }
    }
}
