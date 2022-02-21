using System;
using System.Text.Json.Serialization;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class ReviewerDetail
    {
        public Guid Id { get; set; }
        public string FireBaseUId { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? MajorId { get; set; }
        public string Avatar { get; set; }
        public string Certification { get; set; }
        public string Status { get; set; }
        public int UnpublishedReviews { get; set; }
        public int PublishedReviews { get; set; }
        public int WaitingReviews { get; set; }
        public string UniName { get; set; }
        public string CampusName { get; set; }

        [JsonConstructor]
        public ReviewerDetail()
        {
        }

        public ReviewerDetail(Reviewer reviewer) { 
            Id = reviewer.Id;
            FireBaseUId = reviewer.FireBaseUId;
            Name = reviewer.Name;
            Birthday = reviewer.Birthday;
            Email = reviewer.Email;
            PhoneNumber = reviewer.PhoneNumber;
            MajorId = reviewer.MajorId;
            Avatar = reviewer.Avatar;
            Certification = reviewer.Certification;
            Status = reviewer.Status;
            UnpublishedReviews = reviewer.UnpublishedReviews;
            PublishedReviews = reviewer.PublishedReviews;
            WaitingReviews = reviewer.WaitingReviews;
            if (reviewer.Major != null)
            {
                if (reviewer.Major.Campus != null)
                {
                    CampusName = reviewer.Major.Campus.Name;
                    if (reviewer.Major.Campus.University != null)
                    {
                        UniName = reviewer.Major.Campus.University.Name;
                    }
                }
            }
        }
    }
}