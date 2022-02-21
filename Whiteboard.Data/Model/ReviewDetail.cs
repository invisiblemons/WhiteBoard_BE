using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class PictureForReviewDetail
    {
        public Guid Id { get; set; }
        public String Picture { get; set; }

        [JsonConstructor]
        public PictureForReviewDetail()
        {
        }

        public PictureForReviewDetail(PictureForReview picture)
        {
            Id = picture.Id;
            Picture = picture.Picture;
        }
    }

    public class CriterionForReviewDetail
    {
        public Guid Id { get; set; }
        public Guid CriteriaId { get; set; }
        public String CriteriaName { get; set; }
        public int Rating { get; set; }

        [JsonConstructor]
        public CriterionForReviewDetail()
        {
        }

        public CriterionForReviewDetail(ReviewCriterion criterion)
        {
            Id = criterion.Id;
            CriteriaId = criterion.Criterion.Id;
            CriteriaName = criterion.Criterion.Name;
            Rating = criterion.Rating;
        }
    }

    public class ReviewDetail
    {
        public Guid Id { get; set; }
        public String Status { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime OnDateTime { get; set; }
        public Guid CampaignId { get; set; }
        public String CampaignName { get; set; }
        public String CampaignImage { get; set; }
        public Guid ReviewerId { get; set; }
        public String ReviewerName { get; set; }
        public String ReviewerAvatar { get; set; }
        public String ReviewerEmail { get; set; }
        public Guid CampusId { get; set; }
        public String CampusName { get; set; }
        public String CampusImage { get; set; }
        public Guid UniversityId { get; set; }
        public String UniversityName { get; set; }
        public String UniversityImage { get; set; }
        public String WhyNotPublic { get; set; }
        public IEnumerable<PictureForReviewDetail> Pictures { get; set; }
        public IEnumerable<CriterionForReviewDetail> Criterions { get; set; }

        [JsonConstructor]
        public ReviewDetail()
        {
        }

        public ReviewDetail(Review review)
        {
            Id = review.Id;
            Status = review.Status;
            Title = review.Title;
            Content = review.Content;
            OnDateTime = review.OnDateTime;
            CampaignId = review.Campaign.Id;
            CampaignName = review.Campaign.Name;
            CampaignImage = review.Campaign.Image;
            ReviewerId = review.Reviewer.Id;
            ReviewerName = review.Reviewer.Name;
            ReviewerAvatar = review.Reviewer.Avatar;
            ReviewerEmail = review.Reviewer.Email;
            CampusId = review.Campaign.Campus.Id;
            CampusName = review.Campaign.Campus.Name;
            CampusImage = review.Campaign.Campus.Image;
            UniversityId = review.Campaign.Campus.University.Id;
            UniversityName = review.Campaign.Campus.University.Name;
            UniversityImage = review.Campaign.Campus.University.Image;
            WhyNotPublic = review.WhyNotPublic;
            Pictures = review.PictureForReviews.Select(p => new PictureForReviewDetail(p));
            Criterions = review.ReviewCriteria.Select(c => new CriterionForReviewDetail(c)); ;
        }
    }
}
