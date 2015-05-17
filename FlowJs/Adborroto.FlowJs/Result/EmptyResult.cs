using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adborroto.FlowJs.Error;

namespace Adborroto.FlowJs.Result
{
    public class EmptyResult:Result
    {
        private EmptyResult()
        {
            
        }
        private EmptyResult(IEnumerable<ApplicationError> errors )
        {
            Errors = errors;
        }

        public static EmptyResult Successed()
        {
            return new EmptyResult();
        }

        public static EmptyResult Failed(ApplicationError error)
        {
            return new EmptyResult(new List<ApplicationError>() {error});
        }

        public static EmptyResult Failed(IEnumerable<ApplicationError> errors)
        {
            return new EmptyResult(errors);
        }

    }
}
