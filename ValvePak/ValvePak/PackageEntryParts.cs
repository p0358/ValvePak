using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValvePak
{
    public class PackageEntryParts
    {
        public ushort ArchiveIndex { get; set; }
        public ushort Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public ulong Offset { get; set; }
        public ulong Length { get; set; }
        public ulong OriginalLength { get; set; }
    }
}
