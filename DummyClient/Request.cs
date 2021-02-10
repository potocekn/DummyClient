using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    class Request
    {
        public RequestType Type { get; }
        public List<string> Params { get; }

        public Request(RequestType type, List<string> parameters)
        {
            Type = type;
            Params = parameters;
        }
    }
}
