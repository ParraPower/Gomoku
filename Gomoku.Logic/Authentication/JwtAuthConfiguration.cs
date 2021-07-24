using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Logic.Authentication
{
    public class JwtAuthConfiguration
    {
        public string Secret { get; set; }
        public long Expiry { get; set; }
    }
}
