using System.IO;
using System.Text;
using System.Web;
using Adborroto.FlowJs.Chunk;
using Adborroto.FlowJs.Chunk.Binder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adborroto.FlowJs.Test
{
    [TestClass]
    public class FlowManagerTest
    {
        private IFlowManager GetManager()
        {
            return new FlowManager(new ChunkBasicBinder(), new ChunkNameGenerator(), new BasicFileManager("chunks"));
        }

        private HttpRequest GetValidRequest(string id, string fileName, int chunkNumber, long chunkSize, long totalSize)
        {
            var request = new HttpRequest(fileName, "http://www.flow.com",
                ValidQueryString(id, fileName, chunkNumber, chunkSize, totalSize));
            return request;
        }

        private string ValidQueryString(string id, string fileName, int chunkNumber, long chunkSize, long totalSize)
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("flowIdentifier={0}", id))
                .Append(string.Format("&flowFilename={0}", fileName))
                .Append(string.Format("&flowChunkNumber={0}", chunkNumber))
                .Append(string.Format("&flowChunkSize={0}", chunkSize))
                .Append(string.Format("&flowTotalSize={0}", totalSize));
            return builder.ToString();
        }

        [TestMethod]
        public void NotNullManager()
        {
            var manager = GetManager();
            Assert.IsNotNull(manager);
        }

        [TestMethod]
        public void Request()
        {
            var manager = GetManager();
            var request = GetValidRequest("123456789", "pics.jpg", 1, 1000, 1000);
            manager.Post(request);
        }
    }
}
