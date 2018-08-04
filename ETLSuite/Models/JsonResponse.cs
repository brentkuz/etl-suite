using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models
{
    public class JsonResponse
    {
        public JsonResponse() { }
        public JsonResponse(bool success, string notification, object data)
        {
            this.Success = success;
            this.Notification = notification;
            this.Data = data;
        }
        public bool Success { get; set; } = true;
        public string Notification { get; set; }
        public object Data { get; set; }
    }
}
