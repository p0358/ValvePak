using System;
using System.Collections.Generic;

namespace ValvePak
{
    public class PackageEntry
    {

        public string FileName { get; set; }
        public string DirectoryName { get; set; }
        public string TypeName { get; set; }

        public uint CRC32 { get; set; }
        public byte[] SmallData { get; set; } // PreloadBytes

        //private List<PackageEntryParts> parts; /*internal*/
        public List<PackageEntryParts> Parts { get; set; }
        //public parts = new List<PackageEntryParts>();
        /*public ushort ArchiveIndex { get; set; }
        public ushort Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public ulong Offset { get; set; }
        public ulong Length { get; set; }
        public ulong OriginalLength { get; set; }*/

        public ulong Length
        {
            get
            {
                ulong totalLength = /*Length*/0;
                foreach (var part in this.Parts)
                {
                    totalLength += part.Length;
                }

                return totalLength;
            }
        }

        public ulong OriginalLength
        {
            get
            {
                ulong totalLength = /*OriginalLength*/0;
                foreach (var part in this.Parts)
                {
                    totalLength += part.OriginalLength;
                }

                return totalLength;
            }
        }

        public /*uint*/ulong TotalLength
        {
            get
            {
                ulong totalLength = /*Length*/0;
                foreach (var part in this.Parts)
                {
                    totalLength += part.Length;
                }

                if (SmallData != null)
                {
                    totalLength += /*(uint)*/(ulong)SmallData.Length;
                }

                return totalLength;
            }
        }

        public /*uint*/ulong TotalOriginalLength
        {
            get
            {
                ulong totalLength = /*OriginalLength*/0;
                foreach (var part in this.Parts)
                {
                    totalLength += part.OriginalLength;
                }

                if (SmallData != null)
                {
                    totalLength += /*(uint)*/(ulong)SmallData.Length;
                }

                return totalLength;
            }
        }

        public /*uint*/int NumberOfParts
        {
            get
            {
                return this.Parts.Count;
            }
        }

        public string GetFileName()
        {
            var fileName = FileName;

            if (TypeName != string.Empty)
            {
                fileName += "." + TypeName;
            }

            return fileName;
        }

        public string GetFullPath()
        {
            if (DirectoryName == null)
            {
                return GetFileName();
            }

            return DirectoryName + Package.DirectorySeparatorChar + GetFileName();
        }

        public override string ToString()
        {
            //return $"{GetFullPath()} crc=0x{CRC32:x2} metadatasz={SmallData.Length} fnumber={ArchiveIndex} ofs=0x{Offset:x2} sz={Length}";
            return $"{GetFullPath()} crc=0x{CRC32:x2} metadatasz={SmallData.Length} szpacked={Length} szoriginal={OriginalLength} numberofparts={NumberOfParts}";
        }

        public PackageEntry()
        {
            this.Parts = new List<PackageEntryParts>();
        }

        /*public AddPart(PackageEntryParts part)
        {
            this.Parts.Add(part);
        }*/
    }

}
