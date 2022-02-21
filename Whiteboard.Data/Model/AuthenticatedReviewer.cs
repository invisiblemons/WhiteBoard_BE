using System;
using System.ComponentModel.DataAnnotations;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class AuthenticatedReviewer
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public String Token { get; set; }
        public String Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public int PublishedReviews { get; set; }
        public int UnpublishedReviews { get; set; }
        public int WaitingReviews { get; set; }
        public DateTime Expires { get; set; }
        public String Status { get; set; }
        public String Certification { get; set; }

        public Guid? MajorId { get; set; }
        public String MajorName { get; set; }
        public String MajorCode { get; set; }
        public Guid? CampusId { get; set; }
        public String CampusName { get; set; }
        public Guid? UniversityId { get; set; }
        public String UniversityName { get; set; }

        public AuthenticatedReviewer(Reviewer reviewer, String Token, DateTime Expires)
        {
            this.Id = reviewer.Id;
            this.Token = Token;
            this.Name = reviewer.Name;
            this.Birthday = reviewer.Birthday;
            this.PhoneNumber = reviewer.PhoneNumber;
            this.Avatar = reviewer.Avatar;
            this.Email = reviewer.Email;
            this.PublishedReviews = reviewer.PublishedReviews;
            this.UnpublishedReviews = reviewer.UnpublishedReviews;
            this.WaitingReviews = reviewer.WaitingReviews;
            this.Expires = Expires;
            this.Status = reviewer.Status;
            this.Certification = reviewer.Certification;

            if (reviewer.MajorId != null)
            {
                this.MajorId = reviewer.Major.Id;
                this.MajorName = reviewer.Major.Name;
                this.MajorCode = reviewer.Major.Code;
                this.CampusId = reviewer.Major.Campus.Id;
                this.CampusName = reviewer.Major.Campus.Name;
                this.UniversityId = reviewer.Major.Campus.University.Id;
                this.UniversityName = reviewer.Major.Campus.University.Name;
            }
        }
    }
}
