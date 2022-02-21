using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class University
    {
        public University()
        {
            Campuses = new HashSet<Campus>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Campus> Campuses { get; set; }
    }
}
