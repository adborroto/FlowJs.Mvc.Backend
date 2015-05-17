using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adborroto.FlowJs.Error
{
    public  class UndefinedApplicationError:ApplicationError
    {
        public UndefinedApplicationError(string description) : base(description)
        {
        }

        public UndefinedApplicationError(Exception exception)
            : base(exception.Message)
        {
        }
    }
}
