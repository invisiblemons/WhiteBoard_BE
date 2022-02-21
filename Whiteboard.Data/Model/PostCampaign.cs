using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class CriterionForPostCampaign
    {
        public string Name { get; set; }
    }
    public class PostCampaign
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CampusId { get; set; }
        public string Description { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public String Image { get; set; }
        public ICollection<CriterionForPostCampaign> Criterions { get; set; }
    }
}
