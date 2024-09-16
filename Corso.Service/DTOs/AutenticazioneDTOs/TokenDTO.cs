using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Service.DTOs.AutenticazioneDTOs
{
    public class TokenDTO
    {
        public string accessToken { get; set; }
        public double accessTokenExpire { get; set; }
        public string refreshToken { get; set; }
        public double refreshTokenExpire { get; set; }
    }
}
