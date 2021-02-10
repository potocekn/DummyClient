using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    abstract class Response
    {
        public ResponseStatus Status { get; set; }
        public RequestType Type { get; set; }
    }
}
