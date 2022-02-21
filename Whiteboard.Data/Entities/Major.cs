using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Major
    {
        public Major()
        {
            Reviewers = new HashSet<Reviewer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CampusId { get; set; }
        public string Status { get; set; }

        public virtual Campus Campus { get; set; }
        public virtual ICollection<Reviewer> Reviewers { get; set; }
    }
}
