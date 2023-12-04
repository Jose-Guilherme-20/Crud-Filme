using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesCrud.src.Filme.API.Models
{
    public class Secrets
    {
        public string JwtTokenSecret { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
    }
}