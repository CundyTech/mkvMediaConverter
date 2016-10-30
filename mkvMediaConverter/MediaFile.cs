using System;

namespace mkvMediaConverter
{
    class MediaFile
    {
        /// <summary>
        /// Name of media file
        /// </summary>
        public string StrName { get; set; }

        /// <summary>
        /// Filepath of original media file
        /// </summary>
        public string StrOriginFilePath { get; set; }

        /// <summary>
        /// Filepath of converted media file
        /// </summary>
        public string StrOutputFilePath { get; set; }

        /// <summary>
        /// Date Time when file was first seen by watcher
        /// </summary>
        public DateTime DtDateTimeStamp { get; set; }

        /// <summary>
        /// Original File Extension
        /// </summary>
        public ExtentionType ExtensionType { get; set; }

        /// <summary>
        /// Extenstion of file after conversion
        /// </summary>
        public ExtentionType ConversionType { get; set; }

        /// <summary>
        /// Hash of media file
        /// </summary>
        public Byte[] Hash { get; set; }

        /// <summary>
        /// Has file been processed by queue
        /// </summary>
        public bool Processed { get; set; }

        /// <summary>
        /// percentage complete
        /// </summary>
        public int Progress { get; set; }


    }


    /// <summary>
    /// Extension types of media files
    /// </summary>
    public enum ExtentionType
    {
        Mkv,
        Mp4
    }
}
