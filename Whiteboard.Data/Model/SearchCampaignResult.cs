using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Whiteboard.Data.Model
{
    public class SearchCampaignResult
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
        public Guid? Universityid { get; set; }
        public Guid? Campusid { get; set; }
        public IEnumerable<CampaignDetail> Campaigns { get; set; }

        [JsonConstructor]
        public SearchCampaignResult()
        {
        }
    }
}
