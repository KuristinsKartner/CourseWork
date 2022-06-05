using Correspondence.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Interfaces
{
    public interface IFilesService
    {
        public void AddFiles(IFormFile scan, IFormFile format, IFormFile sverst);
        public int LastID();
        public Files GetFiles(int? id);
        public int GetID(string scan_name, string format_name, string sverst_name,
                         byte[] scan_data, byte[] format_data, byte[] sverst_data,
                         string scan_extension, string format_extension, string sverst_extension,
                         long? scan_length, long? format_length, long? sverst_length);
        public int GetID(IFormFile scan, IFormFile format, IFormFile sverst);
        public bool ReWrite(int? id, IFormFile scan, IFormFile format, IFormFile sverst);
        public bool RewriteScan(int? id, IFormFile scan);
        public bool RewriteFormat(int? id, IFormFile format);
        public bool RewriteSverst(int? id, IFormFile sverst);
    }
}
