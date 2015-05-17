using System;
using System.Collections.Specialized;
using Adborroto.FlowJs.Error;
using Adborroto.FlowJs.Result;

namespace Adborroto.FlowJs.Chunk.Parser
{
    public class ChunkParser:IChunkParser
    {
        public ValueResult<Chunk> Parse(NameValueCollection form)
        {
            try
            {
                
                if (string.IsNullOrEmpty(form["flowIdentifier"]))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError("flowIdentifier: is undefined"));
                
                if (string.IsNullOrEmpty(form["flowFilename"]))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError("flowFilename: is undefined"));

                if (string.IsNullOrEmpty(form["flowChunkNumber"]))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError("flowChunkNumber: is undefined"));

                int chunkNumber;
                if (!int.TryParse(form["flowChunkNumber"], out chunkNumber))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError(string.Format("flowChunkNumber: {0} is an invalid number", form["flowChunkNumber"])));

                //Size = long.Parse(form["flowChunkSize"]);
                //TotalSize = long.Parse(form["flowTotalSize"]);
                //Identifier = CleanIdentifier(form["flowIdentifier"]);
                //FileName = form["flowFilename"];
                //TotalChunks = int.Parse(form["flowTotalChunks"]);
                
            }
            catch (Exception e)
            {
                return ValueResult<Chunk>.Failed(new UndefinedApplicationError(e));
            }
        }
    }
}
