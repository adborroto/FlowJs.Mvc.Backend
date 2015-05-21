namespace Adborroto.FlowJs
{
    public interface IChunkNameGenerator
    {
        /// <summary>
        /// Genereta an unique name for chunk. If temporal then un unique temporal name is return
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="temporal"></param>
        /// <returns></returns>
        string Generate(Chunk.Chunk chunk,bool temporal = false);

        string Generate(string fileName, string flowIdentifier, int chunkNumer, bool temporal = false);
    }
}