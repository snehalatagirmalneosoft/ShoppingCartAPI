using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Common
{
    public class ResponseMessage<T>
    {
        public string Message { get; set; }

        public T Data { get; set; }

        public System.Net.HttpStatusCode StatusCode { get; set; }


    }
}
