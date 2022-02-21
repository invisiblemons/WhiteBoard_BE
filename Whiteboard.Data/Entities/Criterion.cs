using System;
using System.Collections.Generic;
using System.Text.Json;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class Criterion
    {
        public Criterion()
        {
            ReviewCriteria = new HashSet<ReviewCriterion>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CampaignId { get; set; }
        public string Ratings { get; set; }

        public int[] GetRating() {
            return Ratings is null ? new int[5] : JsonSerializer.Deserialize<int[]>(Ratings);
        }
        public void SetRating(int[] rating) {
            Ratings = JsonSerializer.Serialize(rating);
        }
        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<ReviewCriterion> ReviewCriteria { get; set; }
    }
}
