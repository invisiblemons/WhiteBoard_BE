using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class NotificationDetail
    {
        public Guid Id { get; set; }
        public DateTime OnDateTime { get; set; }
        public string Type { get; set; }
        public Guid? AboutReviewID { get; set; }
        public Guid? AboutCampaignID { get; set; }
        public Guid? TopicReviewerID { get; set; }
        //public Guid? TopicCampaignID { get; set; }
        public Guid? TopicCampusID { get; set; }
        public string WhyNotPublic { get; set; }
        public string CampaignName { get; set; }
        public string ReviewTitle { get; set; }

        [JsonConstructor]
        public NotificationDetail()
        {
        }

        public NotificationDetail(Notification notification)
        {
            this.Id = notification.Id;
            this.OnDateTime = notification.OnDateTime;
            this.Type = notification.Type;
            this.AboutReviewID = notification.AboutReviewID;
            this.AboutCampaignID = notification.AboutCampaignID;
            this.TopicReviewerID = notification.TopicReviewerID;
            //this.TopicCampaignID = notification.TopicCampaignID;
            this.TopicCampusID = notification.TopicCampusID;
            if (notification.Review != null)
            {
                if (Type == MyConstant.UnPublicReview)
                {
                    WhyNotPublic = notification.Review.WhyNotPublic;
                }
                ReviewTitle =  notification.Review.Title;
            }
            if (notification.Campaign != null)
            {
                CampaignName = notification.Campaign.Name;
            }
        }
    }
}
