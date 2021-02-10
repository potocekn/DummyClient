using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    class ResponseResourcesForLanguages : Response
    {
        public Dictionary<string, List<string>> ResourcesForLanguages { get; set; }
        public ResponseResourcesForLanguages(ResponseStatus status, RequestType type, Dictionary<string, List<string>> parameters)
        {
            Status = status;
            Type = type;
            ResourcesForLanguages = parameters;
        }
    }
}
