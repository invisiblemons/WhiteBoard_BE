using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string FireBaseUId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
    }
}
