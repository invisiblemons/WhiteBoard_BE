using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class CriterionForCampaignDetail
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int[] Ratings { get; set; }
        public double AverageRatings { get; set; }

        [JsonConstructor]
        public CriterionForCampaignDetail()
        {
        }

        public CriterionForCampaignDetail(Entities.Criterion criterion)
        {
            this.Id = criterion.Id;
            this.Name = criterion.Name;
            this.Ratings = criterion.GetRating();
            this.AverageRatings = 0;
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += this.Ratings[i];
                this.AverageRatings += (i + 1) * this.Ratings[i];
            }
            if (sum != 0)
                this.AverageRatings /= sum;
            this.AverageRatings = Math.Round(this.AverageRatings, 1);
        }
    }

    public class CampaignDetail
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid CampusId { get; set; }
        public String CampusName { get; set; }
        public String CampusImage { get; set; }
        public String Description { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public String Image { get; set; }
        public Guid UniversityId { get; set; }
        public String UniversityName { get; set; }
        public String UniversityImage { get; set; }
        public int ReviewerJoined { get; set; }
        public int UnpublishedReviews { get; set; }
        public int PublishedReviews { get; set; }
        public int WaitingReviews { get; set; }
        public double AverageRatings { get; set; }
        public IEnumerable<CriterionForCampaignDetail> Criterions { get; set; }

        [JsonConstructor]
        public CampaignDetail()
        {
        }

        public CampaignDetail(Campaign campaign)
        {
            this.Id = campaign.Id;
            this.Name = campaign.Name;
            this.CampusId = campaign.CampusId;
            this.CampusName = campaign.Campus.Name;
            this.CampusImage = campaign.Campus.Image;
            this.Description = campaign.Description;
            this.StartDay = campaign.StartDay;
            this.EndDay = campaign.EndDay;
            this.Image = campaign.Image;
            this.UniversityId = campaign.Campus.UniversityId;
            this.UniversityName = campaign.Campus.University.Name;
            this.UniversityImage = campaign.Campus.University.Image;
            this.ReviewerJoined = campaign.ReviewerJoined;
            this.UnpublishedReviews = campaign.UnpublishedReviews;
            this.PublishedReviews = campaign.PublishedReviews;
            this.WaitingReviews = campaign.WaitingReviews;
            this.Criterions = campaign.Criteria.Select(criterion => new CriterionForCampaignDetail(criterion));
            this.AverageRatings = 0;
            if (Criterions.Any())
            {
                int sum = 0;
                foreach (CriterionForCampaignDetail criterionForCampaignDetail in Criterions)
                {
                    sum++;
                    this.AverageRatings += criterionForCampaignDetail.AverageRatings;
                }
                this.AverageRatings /= sum;
            }
            this.AverageRatings = Math.Round(this.AverageRatings, 1);
        }
    }
}
