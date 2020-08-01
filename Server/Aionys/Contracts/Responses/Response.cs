using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.Contracts.Responses
{
    public class Response<T>
    {
        public Response() { }

        public Response(T response)
        {
            Data = response;
        }

        public T Data { get; set; }
    }
}
