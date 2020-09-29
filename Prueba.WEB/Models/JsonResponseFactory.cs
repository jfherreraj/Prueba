using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WEB.Models
{
    public static class JsonResponseFactory
    {
        public static object ErrorResponse(string message)
        {
            return new { Success = false, Message = message };
        }
        public static object ErrorResponse(object referenceObject, string message)
        {
            return new { Success = false, Object = referenceObject, Message = message };
        }
        public static object SuccessResponse(string message)
        {
            return new { Success = true, Message = message };
        }
        public static object SuccessResponse(object referenceObject, string message)
        {
            return new { Success = true, Object = referenceObject, Message = message };
        }
    }
}