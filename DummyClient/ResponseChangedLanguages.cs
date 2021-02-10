using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    class ResponseChangedLanguages : Response
    {
        public List<string> ChangedLanguages { get; set; }
        
        public ResponseChangedLanguages(ResponseStatus status, RequestType type, List<string> parameters)
        {
            Status = status;
            Type = RequestType.CHANGED_LANGUAGES;
            ChangedLanguages = parameters;
        }
    }
}
