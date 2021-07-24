using ServiceStack.DataAnnotations;
using System;
using Tofi.Framework.Data.Entities;

namespace Gomoku.Data.Entities
{
    [Alias("User")]
    public class UserEntity : BaseEntity
    {
        public Guid UniqueKey { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsGuest { get; set; }
        public string Password { get; set; }
    }
}
