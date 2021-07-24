using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Logic.Models
{
    public class UserCreate
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        //public bool IsGuest { get; set; }
    }
}
