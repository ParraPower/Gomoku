using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tofi.Framework.Data.Entities;

namespace Gomoku.Data.Entities
{
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        public Guid UniqueKey { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsGuest { get; set; }
    }
}
