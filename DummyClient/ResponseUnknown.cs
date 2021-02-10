using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    class ResponseUnknown : Response
    {
        public ResponseUnknown()
        {
            Status = ResponseStatus.INVALID;
        }
    }
}
