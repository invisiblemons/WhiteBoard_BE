using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Review
    {
        public Review()
        {
            PictureForReviews = new HashSet<PictureForReview>();
            ReviewCriteria = new HashSet<ReviewCriterion>();
        }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime OnDateTime { get; set; }
        public Guid CampaignId { get; set; }
        public Guid ReviewerId { get; set; }
        public string WhyNotPublic { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual ICollection<PictureForReview> PictureForReviews { get; set; }
        public virtual ICollection<ReviewCriterion> ReviewCriteria { get; set; }
    }
}
