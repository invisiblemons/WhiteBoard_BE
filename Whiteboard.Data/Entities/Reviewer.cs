using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Reviewer
    {
        public Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        public Guid Id { get; set; }
        public string FireBaseUId { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? MajorId { get; set; }
        public string Avatar { get; set; }
        public string Certification { get; set; }
        public string Status { get; set; }
        public int UnpublishedReviews { get; set; }
        public int PublishedReviews { get; set; }
        public int WaitingReviews { get; set; }
        public string WhyBlocked { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
