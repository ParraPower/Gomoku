using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Tofi.Framework.Logic.Models;

namespace Gomoku.Logic.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsGuest { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
