namespace Adborroto.FlowJs.Chunk
{
    public class Chunk
    {
        private Chunk()
        {
            
        }
        public int Number { get; set; }
        public long Size { get; set; }
        public long TotalSize { get; set; }
        public string Identifier { get; set; }
        public string FileName { get; set; }
        public int TotalChunks { get; set; }

        public static Chunk NewChunk(int number, long size, long totalSize, string id, string fileName, int totalChunks)
        {
            return new Chunk()
            {
                Number = number,
                Size = size,
                TotalSize = totalSize,
                Identifier = id,
                FileName = fileName,
                TotalChunks = totalChunks,
            };

        }
    }
}
