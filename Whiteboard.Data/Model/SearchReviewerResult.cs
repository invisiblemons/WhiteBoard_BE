using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whiteboard.Data.Model
{
    public class SearchReviewerResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalRows { get; set; }
        public Guid CampusId { get; set; }
        public IEnumerable<ReviewerDetail> Reviewers { get; set; }

        [JsonConstructor]
        public SearchReviewerResult()
        {
        }
    }
}
