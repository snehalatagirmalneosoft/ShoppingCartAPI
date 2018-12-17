using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Common
{
    public static class ResponseHandler<T>
    {
        //vaishnavi soni
        public static ResponseMessage<T> CreateResponse(ResponseMessage<T> objResponseData, string message, T objData, HttpStatusCode responseCode)
        {
            objResponseData.Message = message;
            objResponseData.Data = objData;
            objResponseData.StatusCode = responseCode;
            return objResponseData;
        }

        //vaishnavi soni
        public static ResponseMessage<T> CreateErrorResponse(ResponseMessage<T> objResponseData)
        {
            objResponseData.Message = "Internal Server Error.";
            objResponseData.Data = default(T);
            objResponseData.StatusCode = HttpStatusCode.InternalServerError;
            return objResponseData;
        }

    }
}
