using System.Collections.Specialized;
using Adborroto.FlowJs.Result;

namespace Adborroto.FlowJs.Chunk.Parser
{
    public interface IChunkParser
    {
        ValueResult<Chunk> Parse(NameValueCollection collection);
    }
}