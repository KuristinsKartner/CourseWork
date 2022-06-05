using Correspondence.Interfaces;
using Correspondence.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class FilesService : IFilesService
    {
        private CorrespContext context;
        public FilesService(CorrespContext context)
        {
            this.context = context;
        }
        public void AddFiles(IFormFile scan, IFormFile format, IFormFile sverst)
        {
            long? scan_length, format_length, sverst_length;
            string scan_name, format_name, sverst_name, scan_extension,format_extension,sverst_extension;
            byte[] scan_bytes, format_bytes, sverst_bytes;
            if (scan != null)
            {
                scan_length = scan.Length;
                scan_name = scan.FileName;
                scan_name = System.IO.Path.GetFileNameWithoutExtension(scan_name);
                scan_extension = scan.FileName;
                scan_extension = System.IO.Path.GetExtension(scan_extension);
                using var scan_filestream = scan.OpenReadStream();
                scan_bytes = new byte[(int)scan_length];
                scan_filestream.Read(scan_bytes, 0, (int)scan_length);
                scan_filestream.Close();
            }
            else
            {
                scan_length = null;
                scan_name = null;
                scan_extension = null;
                scan_bytes = null;
            }
            if (format != null)
            {
                format_length = format.Length;
                format_name = format.FileName;
                format_name = System.IO.Path.GetFileNameWithoutExtension(format_name);
                format_extension = format.FileName;
                format_extension = System.IO.Path.GetExtension(format_extension);
                using var format_filestream = format.OpenReadStream();
                format_bytes = new byte[(int)format_length];
                format_filestream.Read(format_bytes, 0, (int)format_length);
                format_filestream.Close();
            }
            else
            {
                format_length = null;
                format_name = null;
                format_extension = null;
                format_bytes = null;
            }
            if (sverst != null)
            {
                sverst_length = sverst.Length;
                sverst_name = sverst.FileName;
                sverst_name = System.IO.Path.GetFileNameWithoutExtension(sverst_name);
                sverst_extension = sverst.FileName;
                sverst_extension = System.IO.Path.GetExtension(sverst_extension);
                using var sverst_filestream = sverst.OpenReadStream();
                sverst_bytes = new byte[(int)sverst_length];
                sverst_filestream.Read(sverst_bytes, 0, (int)sverst_length);
                sverst_filestream.Close();
            }
            else
            {
                sverst_length = null;
                sverst_name = null;
                sverst_extension = null;
                sverst_bytes = null;
            }

            context.Files.Add(new Files()
            {
                FormatData = format_bytes,
                ScanData = scan_bytes,
                SverstData = sverst_bytes,
                FormatName = format_name,
                ScanName = scan_name,
                SverstName = sverst_name,
                FormatExtension = format_extension,
                ScanExtension = scan_extension,
                SverstExtension = sverst_extension,
                FormatLength = format_length,
                ScanLength = scan_length,
                SverstLength = sverst_length
            });
        }
        public bool ReWrite(int? id, IFormFile scan, IFormFile format, IFormFile sverst)
        {
            RewriteScan(id, scan);
            RewriteFormat(id, format);
            RewriteSverst(id, sverst);
            return true;
        }
        public bool RewriteScan(int? id, IFormFile scan)
        {
            Files files = GetFiles(id);
            if (files != null)
            {
                long? scan_length;
                string scan_name, scan_extension;
                byte[] scan_bytes;
                if (scan != null)
                {
                    scan_length = scan.Length;
                    scan_name = scan.FileName;
                    scan_name = System.IO.Path.GetFileNameWithoutExtension(scan_name);
                    scan_extension = scan.FileName;
                    scan_extension = System.IO.Path.GetExtension(scan_extension);
                    using var scan_filestream = scan.OpenReadStream();
                    scan_bytes = new byte[(int)scan_length];
                    scan_filestream.Read(scan_bytes, 0, (int)scan_length);
                    scan_filestream.Close();
                }
                else
                {
                    scan_length = null;
                    scan_name = null;
                    scan_extension = null;
                    scan_bytes = null;
                }
                files.ScanName = scan_name;
                files.ScanExtension = scan_extension;
                files.ScanData = scan_bytes;
                files.ScanLength = scan_length;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RewriteFormat(int? id, IFormFile format)
        {
            Files files = GetFiles(id);
            if (files != null)
            {
                long? format_length;
                string format_name, format_extension;
                byte[] format_bytes;
                if (format != null)
                {
                    format_length = format.Length;
                    format_name = format.FileName;
                    format_name = System.IO.Path.GetFileNameWithoutExtension(format_name);
                    format_extension = format.FileName;
                    format_extension = System.IO.Path.GetExtension(format_extension);
                    using var format_filestream = format.OpenReadStream();
                    format_bytes = new byte[(int)format_length];
                    format_filestream.Read(format_bytes, 0, (int)format_length);
                    format_filestream.Close();
                }
                else
                {
                    format_length = null;
                    format_name = null;
                    format_extension = null;
                    format_bytes = null;
                }

                files.FormatName = format_name;
                files.FormatExtension = format_extension;
                files.FormatData = format_bytes;
                files.FormatLength = format_length;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RewriteSverst(int? id, IFormFile sverst)
        {
            Files files = GetFiles(id);
            if (files != null)
            {
                long? sverst_length;
                string sverst_name, sverst_extension;
                byte[] sverst_bytes;
                if (sverst != null)
                {
                    sverst_length = sverst.Length;
                    sverst_name = sverst.FileName;
                    sverst_name = System.IO.Path.GetFileNameWithoutExtension(sverst_name);
                    sverst_extension = sverst.FileName;
                    sverst_extension = System.IO.Path.GetExtension(sverst_extension);
                    using var sverst_filestream = sverst.OpenReadStream();
                    sverst_bytes = new byte[(int)sverst_length];
                    sverst_filestream.Read(sverst_bytes, 0, (int)sverst_length);
                    sverst_filestream.Close();
                }
                else
                {
                    sverst_length = null;
                    sverst_name = null;
                    sverst_extension = null;
                    sverst_bytes = null;
                }
                
                files.SverstName = sverst_name;
                files.SverstExtension = sverst_extension;
                files.SverstData = sverst_bytes;
                files.SverstLength = sverst_length;

                return true;
            }
            else
            {
                return false;
            }
        }
        public int LastID()
        {
            var GetID = context.Files.OrderBy(f => f.Id).LastOrDefault();
            return GetID.Id;
        }

        public int GetID(string scan_name, string format_name, string sverst_name,
                         byte[] scan_data, byte[] format_data, byte[] sverst_data,
                         string scan_extension, string format_extension, string sverst_extension,
                         long? scan_length, long? format_length, long? sverst_length)
        {
            var files = context.Files.Where(f => f.ScanName == scan_name && f.FormatName==format_name && f.SverstName==sverst_name 
                                            && f.ScanData == scan_data && f.FormatData == format_data && f.SverstData == sverst_data
                                            && f.ScanExtension == scan_extension && f.FormatExtension == format_extension && f.SverstExtension == sverst_extension
                                            && f.ScanLength == scan_length && f.FormatLength == format_length && f.SverstLength == sverst_length).FirstOrDefault();
            return files != null ? files.Id : 0;
        }
        public int GetID(IFormFile scan, IFormFile format, IFormFile sverst)
        {
            long? scan_length, format_length, sverst_length;
            string scan_name, format_name, sverst_name, scan_extension, format_extension, sverst_extension;
            byte[] scan_bytes, format_bytes, sverst_bytes;
            if (scan != null)
            {
                scan_length = scan.Length;
                scan_name = scan.FileName;
                scan_name = System.IO.Path.GetFileNameWithoutExtension(scan_name);
                scan_extension = scan.FileName;
                scan_extension = System.IO.Path.GetExtension(scan_extension);
                using var scan_filestream = scan.OpenReadStream();
                scan_bytes = new byte[(int)scan_length];
                scan_filestream.Read(scan_bytes, 0, (int)scan_length);
                scan_filestream.Close();
            }
            else
            {
                scan_length = null;
                scan_name = null;
                scan_extension = null;
                scan_bytes = null;
            }
            if (format != null)
            {
                format_length = format.Length;
                format_name = format.FileName;
                format_name = System.IO.Path.GetFileNameWithoutExtension(format_name);
                format_extension = format.FileName;
                format_extension = System.IO.Path.GetExtension(format_extension);
                using var format_filestream = format.OpenReadStream();
                format_bytes = new byte[(int)format_length];
                format_filestream.Read(format_bytes, 0, (int)format_length);
                format_filestream.Close();
            }
            else
            {
                format_length = null;
                format_name = null;
                format_extension = null;
                format_bytes = null;
            }
            if (sverst != null)
            {
                sverst_length = sverst.Length;
                sverst_name = sverst.FileName;
                sverst_name = System.IO.Path.GetFileNameWithoutExtension(sverst_name);
                sverst_extension = sverst.FileName;
                sverst_extension = System.IO.Path.GetExtension(sverst_extension);
                using var sverst_filestream = sverst.OpenReadStream();
                sverst_bytes = new byte[(int)sverst_length];
                sverst_filestream.Read(sverst_bytes, 0, (int)sverst_length);
                sverst_filestream.Close();
            }
            else
            {
                sverst_length = null;
                sverst_name = null;
                sverst_extension = null;
                sverst_bytes = null;
            }
            return GetID(scan_name, format_name, sverst_name,
                         scan_bytes, format_bytes, sverst_bytes, 
                         scan_extension, format_extension, sverst_extension, 
                         scan_length, format_length, sverst_length);
        }
        public Files GetFiles(int? id)
        {
            Files rez = context.Files.Find(id);
            return rez ?? null;
        }
    }
}
