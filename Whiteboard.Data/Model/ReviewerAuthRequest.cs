using System;
using System.ComponentModel.DataAnnotations;
using Whiteboard.Data;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class ReviewerAuthRequest
    {
        [Required]
        public String IdToken { get; set; }
        public String Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public Guid? MajorId { get; set; }
        public string Certification { get; set; }


        public Reviewer ToReviewer(string fireBaseUId, String email)
        {
            return new Reviewer {
                FireBaseUId = fireBaseUId,
                Email = email,
                MajorId = this.MajorId,
                Name = this.Name,
                Birthday = this.Birthday,
                PhoneNumber = this.PhoneNumber,
                Avatar = this.Avatar,
                UnpublishedReviews = 0,
                PublishedReviews = 0,
                WaitingReviews = 0,
                Certification = this.Certification,
                Status = MyConstant.Unverified
            };
        }
    }
}
