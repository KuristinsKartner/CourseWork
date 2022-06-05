#nullable disable
using System;
using System.Collections.Generic;

namespace Correspondence.Models
{
    public partial class Files
    {
        public Files()
        {
            Mains = new HashSet<Main>();
        }

        public int Id { get; set; }
        public byte[] FormatData { get; set; }
        public byte[] ScanData { get; set; }
        public byte[] SverstData { get; set; }
        public string FormatName { get; set; }
        public string ScanName { get; set; }
        public string SverstName { get; set; }
        public string FormatExtension { get; set; }
        public string ScanExtension { get; set; }
        public string SverstExtension { get; set; }
        public long? FormatLength { get; set; }
        public long? ScanLength { get; set; }
        public long? SverstLength { get; set; }

        public virtual ICollection<Main> Mains { get; set; }
    }
}