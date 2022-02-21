using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.Data.Model
{
    public class ImageForPostReview
    {
        public String Image { get; set; }
    }

    public class CriterionForPostReview
    {
        public Guid CriterionId { get; set; }
        public int Rating { get; set; }
    }

    public class PostReview
    {
        [Required]
        public String Title { get; set; }
        public String Content { get; set; }
        public Guid CampaignId { get; set; }
        public Guid ReviewerId { get; set; }
        public ICollection<ImageForPostReview> Images { get; set; }
        public ICollection<CriterionForPostReview> Criterions { get; set; }
    }
}
