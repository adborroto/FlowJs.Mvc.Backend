using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adborroto.FlowJs.Error;

namespace Adborroto.FlowJs.Result
{
    public class ValueResult<T> : Result
    {
        private ValueResult(T value)
        {
            Result = value;
        }

        private ValueResult(IEnumerable<ApplicationError> errors)
        {
            Errors = errors;
        }


        public T Result { get; private set; }

        public static ValueResult<T> Successed(T value)
        {
           return new ValueResult<T>(value);
        }

        public static ValueResult<T> Failed(ApplicationError error)
        {
            return new ValueResult<T>(new List<ApplicationError>() { error });
        }

        public static ValueResult<T> Failed(IEnumerable<ApplicationError> errors)
        {
            return new ValueResult<T>(errors);
        }
    }
}
