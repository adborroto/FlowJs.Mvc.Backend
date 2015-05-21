using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Adborroto.FlowJs.Error;
using Adborroto.FlowJs.Result;

namespace Adborroto.FlowJs.Chunk.Binder
{
    public class ChunkBasicBinder:IChunkBinder
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

                if (string.IsNullOrEmpty(form["flowChunkSize"]))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError("flowChunkSize: is undefined"));

                if (string.IsNullOrEmpty(form["flowTotalSize"]))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError("flowTotalSize: is undefined"));

                var id = CleanIdentifierString(form["flowIdentifier"]);
                var fileName = form["flowFilename"];

                int chunkNumber;
                if (!int.TryParse(form["flowChunkNumber"], out chunkNumber))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError(string.Format("flowChunkNumber: {0} is an invalid number", form["flowChunkNumber"])));

                long chunkSize;
                if (!long.TryParse(form["flowChunkSize"], out chunkSize))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError(string.Format("flowChunkSize: {0} is an invalid number", form["flowChunkSize"])));

                long chunkTotalSize;
                if (!long.TryParse(form["flowTotalSize"], out chunkTotalSize))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError(string.Format("flowTotalSize: {0} is an invalid number", form["flowTotalSize"])));

                int chunkAmount;
                if (!int.TryParse(form["flowTotalChunks"], out chunkAmount))
                    return ValueResult<Chunk>.Failed(new ParseChunkApplicationError(string.Format("flowTotalChunks: {0} is an invalid number", form["flowTotalChunks"])));

                return
                    ValueResult<Chunk>.Successed(Chunk.NewChunk(chunkNumber, chunkSize, chunkTotalSize, id, fileName,
                        chunkAmount));

            }
            catch (Exception e)
            {
                return ValueResult<Chunk>.Failed(new UndefinedApplicationError(e));
            }
        }

        private string CleanIdentifierString(string identifier)
        {
            return Regex.Replace(identifier, "/[^0-9A-Za-z_-]/g", "");
        }
    }
}
