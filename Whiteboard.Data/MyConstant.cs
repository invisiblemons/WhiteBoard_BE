using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.Data
{
    public class MyConstant
    {
        //SortBY
        public const String Name = "Name";
        public const String StartDay = "StartDay";
        public const String EndDay = "EndDay";
        public const String Title = "Title";

        //Order
        public const String Acs = "Acs";
        public const String Des = "Des";

        ////SortBY+Order
        //public static readonly String NameAcs = Name + Acs;
        //public static readonly String StartDayAcs = StartDay + Acs;
        //public static readonly String EndDayAcs = EndDay + Acs;
        //public static readonly String NameDes = Name + Des;
        //public static readonly String StartDayDes = StartDay + Des;
        //public static readonly String EndDayDes = EndDay + Des;

        public const int DefaultsPageSizeForSerch = 20;

        //Role
        public const String Admin = "Admin";
        public const String Reviewer = "Reviewer";
        public const String AdminOrReviewer = Admin + ", " + Reviewer;

        //Secret
        public const String Secret = "123456789123456789";

        //Global Status
        public const String Deleted = "Deleted";

        //University
        public const String Created = "Created";

        //Review Status
        public const String Waiting = "Waiting";
        public const String Unpublished = "Unpublished";
        public const String Published = "Published";
        public const String Locked = "Locked";

        //Reviewer Status
        public const String Verified = "Verified";
        public const String Unverified = "Unverified";
        public const String Blocked = "Blocked";

        //token
        public const int DaysExpires = 1000;

        //Notification
        public const String CreateCampaign = "CreateCampaign";
        public const String CreateCampaignTitle = "Chiến dịch";
        public const String CreateCampaignBody1 = "Có chiến dịch ";
        public const String CreateCampaignBody2 = " vừa được tạo";

        public const String PublicReview = "PublicReview";
        public const String PublicReviewTitle = "Bài viết";
        public const String PublicReviewBody1 = "Bài viết ";
        public const String PublicReviewBody2 = " của bạn đã được duyệt";

        public const String UnPublicReview = "UnpublicReview";
        public const String UnPublicReviewTitle = "Bài viết";
        public const String UnPublicReviewBody1 = "Bài viết ";
        public const String UnPublicReviewBody2 = " của bạn đã bị từ chối vì ";

        public const String VerifiedReviewer = "VerifiedReviewer";
        public const String VerifiedReviewerTitle = "Thông báo";
        public const String VerifiedReviewerBody = "Tài khoản của bạn đã được xác thực";

        public const String BlockedReviewer = "BlockedReviewer";
        public const String BlockedReviewerTitle = "Thông báo";
        public const String BlockedReviewerBody = "Tài khoản của bạn đã bị khóa vì ";

        public const String UnBlockedReviewer = "UnBlockedReviewer";
        public const String UnBlockedReviewerTitle = "Thông báo";
        public const String UnBlockedReviewerBody = "Tài khoản của bạn đã được mở khóa";


        //Table name
        public const String Campaign = "Campaign";
        //public const String Reviewer = "Campaign";
        public const String Campus = "Campus";
        
    }
}
