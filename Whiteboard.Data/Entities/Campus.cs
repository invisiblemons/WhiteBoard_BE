using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Campus
    {
        public Campus()
        {
            Campaigns = new HashSet<Campaign>();
            Majors = new HashSet<Major>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public Guid UniversityId { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Major> Majors { get; set; }
    }
}
