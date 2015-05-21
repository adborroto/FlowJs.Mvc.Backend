using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adborroto.FlowJs
{
    public class BasicFileManager:IFileManager
    {
        private readonly string _path;

        public BasicFileManager(string path)
        {
            _path = path;
        }

        public void Copy(Stream file, string fileName)
        {
            var filePathAndName = Path.Combine(_path, fileName);
            using (var writer = new FileStream(filePathAndName, FileMode.Create))
            {
                var buffer = new byte[file.Length];
                file.Read(buffer, 0, (int) file.Length);

                writer.Write(buffer, 0, buffer.Length);
            }
        }

        public void Rename(string fileName, string newFileName)
        {
            var filePathName = Path.Combine(_path, newFileName);
            var filePathOldName = Path.Combine(_path, fileName);
            File.Move(filePathOldName,filePathName);
        }

        public bool Exits(string fileName)
        {
           return File.Exists(Path.Combine(_path, fileName));
        }

        public Stream Create(string fileName)
        {
           return File.Create(Path.Combine(_path, fileName));
        }

        public Stream Read(string fileName)
        {
            return new FileStream(Path.Combine(_path, fileName), FileMode.Open);
        }

        public void Delete(string fileName)
        {
            File.Delete(Path.Combine(_path, fileName));
        }
    }
}
