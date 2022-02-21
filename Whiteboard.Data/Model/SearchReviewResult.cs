using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class SearchReviewResult
    {
        public String KeyWord { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalRows { get; set; }
        public String SortBy { get; set; }
        public String Order { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public String Status { get; set; }
        public Guid? CampaignId { get; set; }
        public Guid? ReviewerId { get; set; }
        public Guid? UniversityId { get; set; }
        public IEnumerable<ReviewDetail> Reviews { get; set; }

        [JsonConstructor]
        public SearchReviewResult()
        {
        }
    }
}
