using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.Data.Model
{
    public class PutReview
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public String Status { get; set; }
        [Required]
        public String Title { get; set; }
        public String Content { get; set; }
        [Required]
        public Guid CampaignId { get; set; }
        [Required]
        public Guid ReviewerId { get; set; }
    }
}
