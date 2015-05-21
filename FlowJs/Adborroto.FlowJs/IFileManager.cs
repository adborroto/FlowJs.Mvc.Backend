using System.IO;

namespace Adborroto.FlowJs
{
    public interface IFileManager
    {
        void Copy(Stream file, string fileName);

        void Rename(string fileName, string newFileName);

        bool Exits(string fileName);

        Stream Create(string fileName);

        Stream Read(string fileName);

        void Delete(string chunkUniqueName);
    }
}