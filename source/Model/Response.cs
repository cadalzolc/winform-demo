using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadalzo.demo
{
    public class Response
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
        public object Data { get; set; } = null;

        public Response() { }
        public Response(string IMessage) 
        {
            Message = IMessage;
        }
        public Response(string IMessage, bool ISuccess)
        {
            Message = IMessage;
            Success = ISuccess;
        }
        public Response(string IMessage, bool ISuccess, object IData)
        {
            Message = IMessage;
            Success = ISuccess;
            Data = IData;
        }
    }
}