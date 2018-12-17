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
        public static ResponseMessage<List<T>> CreateResponse(ResponseMessage<List<T>> objResponseData, string message, List<T> objData, HttpStatusCode responseCode)
        {
            objResponseData.Message = message;
            objResponseData.Data = objData;
            objResponseData.StatusCode = responseCode;
            return objResponseData;
        }

        public static ResponseMessage<List<T>> CreateResponse(ResponseMessage<List<T>> objResponseData, string message, HttpStatusCode responseCode)
        {
            objResponseData.Message = message;
            objResponseData.Data = new List<T>();
            objResponseData.StatusCode = responseCode;
            return objResponseData;
        }

        //vaishnavi soni
        public static ResponseMessage<T> CreateResponse(ResponseMessage<T> objResponseData, string message, T objData, HttpStatusCode responseCode)
        {
            objResponseData.Message = message;
            objResponseData.Data = objData;
            objResponseData.StatusCode = responseCode;
            return objResponseData;
        }

        public static ResponseMessage<T> CreateResponse(ResponseMessage<T> objResponseData, string message, HttpStatusCode code)
        {
            objResponseData.Message = message;
            objResponseData.Data = default(T);
            objResponseData.StatusCode = code;
            return objResponseData;
        }

        public static ResponseMessage<List<T>> CreateErrorResponse(ResponseMessage<List<T>> objResponseData)
        {
            objResponseData.Message = "Internal Server Error.";
            objResponseData.Data = new List<T>();
            objResponseData.StatusCode = HttpStatusCode.InternalServerError;
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
