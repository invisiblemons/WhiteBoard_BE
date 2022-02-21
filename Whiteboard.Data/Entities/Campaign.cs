using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Campaign
    {
        public Campaign()
        {
            Criteria = new HashSet<Criterion>();
            Reviews = new HashSet<Review>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CampusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string Image { get; set; }
        public int ReviewerJoined { get; set; }
        public int UnpublishedReviews { get; set; }
        public int PublishedReviews { get; set; }
        public int WaitingReviews { get; set; }

        public virtual Campus Campus { get; set; }
        public virtual ICollection<Criterion> Criteria { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
