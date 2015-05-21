using System.Collections.Specialized;
using Adborroto.FlowJs.Result;

namespace Adborroto.FlowJs.Chunk.Binder
{
    public interface IChunkBinder
    {
        ValueResult<Chunk> Parse(NameValueCollection collection);
    }
}