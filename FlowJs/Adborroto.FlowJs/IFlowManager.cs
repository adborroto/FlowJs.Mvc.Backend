using System.Web;
using Adborroto.FlowJs.Chunk;
using Adborroto.FlowJs.Result;

namespace Adborroto.FlowJs
{
    public interface IFlowManager
    {
        ValueResult<ChunkStatus> Post(HttpRequest request);
    }
}