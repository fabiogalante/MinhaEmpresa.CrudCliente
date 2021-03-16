﻿using Newtonsoft.Json;

namespace MinhaEmpresa.CrudCliente.API.Extensions.Middleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
