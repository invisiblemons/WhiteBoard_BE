using System;
using System.ComponentModel.DataAnnotations;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class PutCampaign
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CampusId { get; set; }
        public string Description { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }

        public Campaign ToCampaign()
        {
            return new Campaign
            {
                Id = Id,
                Name = Name,
                CampusId = CampusId,
                Description = Description,
                StartDay = StartDay,
                EndDay = EndDay,
                Image = Image
            };
        }
    }
}
