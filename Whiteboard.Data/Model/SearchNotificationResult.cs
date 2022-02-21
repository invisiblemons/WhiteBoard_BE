using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Whiteboard.Data.Model
{
    public class SearchNotificationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalRows { get; set; }
        public String SortBy { get; set; }
        public String Order { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Guid? ReviewerId { get; set; }
        public IEnumerable<NotificationDetail> Notifications { get; set; }

        [JsonConstructor]
        public SearchNotificationResult()
        {
        }
    }
}
