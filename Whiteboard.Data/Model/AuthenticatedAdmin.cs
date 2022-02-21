using System;
using System.ComponentModel.DataAnnotations;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class AuthenticatedAdmin
    {
        [Required]
        public string Token { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        //public string Avatar { get; set; }
        public string AvatarURL { get; set; }
        public string Email { get; set; }
        public DateTime Exp { get; set; }
        //public DateTime Expires { get; set; }
        //public String Status { get; set; }

        public AuthenticatedAdmin(Admin admin, String Token, DateTime Expires)
        {
            this.Token = Token;
            this.Name = admin.Name;
            this.Birthday = admin.Birthday;
            this.PhoneNumber = admin.PhoneNumber;
            //this.Avatar = admin.Avatar;
            this.AvatarURL = admin.Avatar;
            this.Email = admin.Email;
            this.Exp = Expires;
            //this.Expires = Expires;
            //this.Status = admin.Status;
        }
    }
}
