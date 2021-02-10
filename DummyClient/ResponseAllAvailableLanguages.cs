using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    class ResponseAllAvailableLanguages : Response
    {
        public List<string> Languages { get; set; }


        public ResponseAllAvailableLanguages(ResponseStatus status, RequestType type, List<string> languages)
        {
            Status = status;
            Type = RequestType.ALL_AVAILABLE_LANGUAGES;
            Languages = languages;
        }
    }
}
