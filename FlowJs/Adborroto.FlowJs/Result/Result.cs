using System.Collections.Generic;
using System.Linq;
using Adborroto.FlowJs.Error;

namespace Adborroto.FlowJs.Result
{
    public abstract class Result
    {
        public IEnumerable<ApplicationError> Errors { get; set; }

        public bool Sucess
        {
            get { return !Errors.Any(); }
        }
    }
}