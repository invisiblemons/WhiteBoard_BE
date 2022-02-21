using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Whiteboard.Data.Entities
{
    public partial class Notification
    {
        public Guid Id { get; set; }
        public DateTime OnDateTime { get; set; }
        public string Type { get; set; }
        public Guid? AboutReviewID { get; set; }
        public Guid? AboutCampaignID { get; set; }
        public Guid? TopicReviewerID { get; set; }
        public string WhyBlockedReviewer { get; set; }
        //public Guid? TopicCampaignID { get; set; }
        public Guid? TopicCampusID { get; set; }

        [ForeignKey(nameof(AboutCampaignID))]
        public virtual Campaign Campaign { get; set; }
        [ForeignKey(nameof(AboutReviewID))]
        public virtual Review Review { get; set; }
        [ForeignKey(nameof(TopicReviewerID))]
        public virtual Reviewer Reviewer { get; set; }

        //public string GetJson()
        //{
        //    return JsonSerializer.Serialize(new {
        //        OnDateTime = this.OnDateTime,
        //        Message = this.Body,
        //        AboutReviewID = this.AboutReviewID,
        //        AboutCampaignID = this.AboutCampaignID,
        //    });
        //}

        public string GetTopic()
        {
            if (TopicReviewerID != null)
            {
                return MyConstant.Reviewer + TopicReviewerID;
            //} else
            //{
            //    if (TopicCampaignID != null)
            //    {
            //        return MyConstant.Campaign + TopicCampaignID;
                }
                else
                {
                    if (TopicCampusID != null)
                    {
                        return MyConstant.Campus + TopicCampusID;
                    }
                    else
                    {
                        return "Bug";
                    }
                }
            //}
        }
    }
}
