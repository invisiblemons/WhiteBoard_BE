using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using Whiteboard.Data.Context;
using Whiteboard.Data.Entities;
using System.Linq;

namespace whiteboard.api.controllers
{
    //[Authorize(Roles = MyConstant.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class Initdatacontroller : ControllerBase
    {
        private readonly WhiteboardContext context;

        public Initdatacontroller(WhiteboardContext context)
        {
            this.context = context;
        }

        private static string ToParseGuid(string x)
        {
            return x.Length switch
            {
                1 => x + "1111111-1111-1111-1111-111111111111",
                2 => x + "111111-1111-1111-1111-111111111111",
                3 => x + "11111-1111-1111-1111-111111111111",
                4 => x + "1111-1111-1111-1111-111111111111",
                5 => x + "111-1111-1111-1111-111111111111",
                6 => x + "11-1111-1111-1111-111111111111",
                7 => x + "1-1111-1111-1111-111111111111",
                8 => x + "-1111-1111-1111-111111111111",
                _ => "",
            };
        }

        bool admin = false;
        bool uni = false;
        bool campus = false;
        bool major = false;
        bool reviewer = false;
        bool campaign = false;
        bool criterion = false;
        bool review = false;
        bool pictureforreview = false;
        bool reviewcriterion = false;


        //[HttpGet("RemoveTestRow")]
        //public void RemoveTestRow()
        //{
        //    var campaigns = from c in context.Campaigns
        //                    where (c.Name == "name" || c.Name == "name2")
        //                    select c;
        //    context.Campaigns.RemoveRange(campaigns);
        //    context.SaveChanges();
        //}

        [HttpGet("InitDataAdmins")]
        public ActionResult Initdataadmin()
        {
            //add admin
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    FireBaseUId = "nr7myi9tbzgyjcszs9bdcsqywnz1",
                    Email = "longnbpse140814@fpt.edu.vn",
                    Avatar = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t1.18169-9/15697958_720212038155830_2906837649172891736_n.jpg?_nc_cat=111&ccb=1-5&_nc_sid=174925&_nc_ohc=b1SUjVy7LmIAX8Ez8R6&tn=3tomuPux_JwZsnM5&_nc_ht=scontent.fsgn2-1.fna&oh=b957b610a72a4d529c57a5549d81fcfe&oe=61883E11",
                    Name = "Nguyễn Bá Phi Long",
                    Birthday = DateTime.ParseExact("09/10/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0378945612",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    FireBaseUId = "psEEUCNO7PZf0hvxvwmOL4rOxVc2",
                    Email = "hsddung92long@gmail.com",
                    Avatar = "https://scontent.fsgn2-4.fna.fbcdn.net/v/t1.18169-9/23168030_888989481278084_4317044370415565472_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=174925&_nc_ohc=E3Sf_wiIQPMAX9xZ8Ny&_nc_ht=scontent.fsgn2-4.fna&oh=d73e969b00142c60979683fbb80b422c&oe=618705F6",
                    Name = "Nguyễn Bá Phi Long",
                    Birthday = DateTime.ParseExact("08/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0142587951",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("3")),
                    FireBaseUId = "w5nc5FcgaxgDnKR4kZ67IK6CmD73",
                    Email = "dangminh200320@gmail.com",
                    Avatar = "https://scontent.fsgn2-2.fna.fbcdn.net/v/t1.15752-9/243592946_651781115783702_6310347599270954694_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=ae9488&_nc_ohc=WOlS7A7bxBAAX_oytjA&_nc_ht=scontent.fsgn2-2.fna&oh=dcf3056e98588acb8c68b10d773810ec&oe=617E3AD0",
                    Name = "Đăng Công Minh",
                    Birthday = DateTime.ParseExact("12/08/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0724569813",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("4")),
                    FireBaseUId = "ezB6kng621SQ0h9GM2nEvXTA6uI3",
                    Email = "minhdcse140811@fpt.edu.vn",
                    Avatar = "https://scontent.fsgn2-2.fna.fbcdn.net/v/t1.15752-9/243592946_651781115783702_6310347599270954694_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=ae9488&_nc_ohc=WOlS7A7bxBAAX_oytjA&_nc_ht=scontent.fsgn2-2.fna&oh=dcf3056e98588acb8c68b10d773810ec&oe=617E3AD0",
                    Name = "Đăng Công Minh",
                    Birthday = DateTime.ParseExact("18/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0325413698",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("5")),
                    FireBaseUId = "gkEGPgn0uDhZwDkFFw3VwFOAfoy1",
                    Email = "dat7124@gmail.com",
                    Avatar = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t31.18172-8/17157368_333315983730501_7105730900845101890_o.jpg?_nc_cat=111&ccb=1-5&_nc_sid=e3f864&_nc_ohc=9U2UNrGxCUUAX_9pDZ3&tn=3tomuPux_JwZsnM5&_nc_ht=scontent.fsgn2-1.fna&oh=b671379424b1e41592846d115dce0143&oe=618964A1",
                    Name = "Đỗ Thành Đạt",
                    Birthday = DateTime.ParseExact("10/02/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0125469831",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("6")),
                    FireBaseUId = "c7uFw2cPB0S52K4CTn3nxgiZIYN2",
                    Email = "lethanhvan0105@gmail.com",
                    Avatar = "https://scontent.fsgn2-2.fna.fbcdn.net/v/t39.30808-6/242562983_1045842172938221_4571792889453206030_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=Q_bdTyQwtq8AX80oiL5&_nc_ht=scontent.fsgn2-2.fna&oh=bccc7a3cb2ff0b495595683b6b2aa149&oe=61678F29",
                    Name = "Lê Thanh Vân",
                    Birthday = DateTime.ParseExact("03/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0397564178",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("7")),
                    FireBaseUId = "1EBQVSqQgtfI8U5Njji3kcUzHIk1",
                    Email = "vanltse141176@fpt.edu.vn",
                    Avatar = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t1.6435-9/182006457_958652318323874_1214579627405391374_n.jpg?_nc_cat=104&ccb=1-5&_nc_sid=174925&_nc_ohc=nvv4ZXp14bsAX-d2M3d&tn=3tomuPux_JwZsnM5&_nc_ht=scontent.fsgn2-5.fna&oh=c8261a09d4e82f42bd378a4d3ebc90b9&oe=618917B3",
                    Name = "Lê Thanh Vân",
                    Birthday = DateTime.ParseExact("12/06/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0784123659",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Admins.Add(new Admin
                {
                    Id = Guid.Parse(ToParseGuid("8")),
                    FireBaseUId = "dDoSh3xbbMYImZctlvQpaYN28Vk1",
                    Email = "phuonglhk@fpt.edu.vn",
                    Avatar = "https://scontent.fsgn2-3.fna.fbcdn.net/v/t1.15752-9/244426401_640070846987978_1187496892351981377_n.jpg?_nc_cat=108&ccb=1-5&_nc_sid=ae9488&_nc_ohc=Lyg_K0BUsQsAX-FOfVQ&_nc_ht=scontent.fsgn2-3.fna&oh=1f31e8706a54956e004f87669773761d&oe=61803637",
                    Name = "Lâm Khánh Hữu Phương",
                    Birthday = DateTime.ParseExact("06/02/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "0741236589",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }

            return Ok();
        }

        [HttpGet("InitDataAll")]
        public ActionResult<string> Initdataall()
        {
            string message = "";
            try
            {
                message += "admin ";
                var n = from a in context.Admins
                        select a;
                admin = n.Any();
                if (!admin)
                {
                    Initdataadmin();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }

            }
            catch
            {

            }
            try
            {
                message += "university ";
                var n = from m in context.Universities
                        select m;
                uni = n.Any();
                if (!uni)
                {
                    InitDataUniversity();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "campus ";
                var n = from m in context.Campuses
                        select m;
                campus = n.Any();
                if (!campus && uni)
                {
                    InitDataCampus();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "marjor ";
                var n = from m in context.Majors
                        select m;
                major = n.Any();
                if (!major && campus)
                {
                    InitDataMarjor();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "reviewer ";
                var n = from m in context.Reviewers
                        select m;
                reviewer = n.Any();
                if (!reviewer && major)
                {
                    InitDataReviewer();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "campaign ";
                var n = from c in context.Campaigns
                        select c;
                campaign = n.Any();
                if (!campaign && campus)
                {
                    InitDataCampaign();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "review ";
                var n = from m in context.Reviews
                        select m;
                review = n.Any();
                if (!review && campaign && reviewer)
                {
                    InitDataReview();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "pictureforreview ";
                var n = from m in context.PictureForReviews
                        select m;
                pictureforreview = n.Any();
                if (!pictureforreview && review)
                {
                    InitDataPictureForReview();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }

            try
            {
                message += "criterion ";
                var n = from m in context.Criterions
                        select m;
                criterion = n.Any();
                if (!criterion && campaign)
                {
                    InitdataCriterion();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }
            try
            {
                message += "reviewcriterion ";
                var n = from m in context.ReviewCriteria
                        select m;
                reviewcriterion = n.Any();
                if (!reviewcriterion && review && criterion)
                {
                    InitDataReviewCriterion();
                    message += "! ";
                }
                else
                {
                    message += "$ ";
                }
            }
            catch
            {

            }


            return Ok(message);
        }

        [HttpGet("InitDataReviewer")]
        public ActionResult InitDataReviewer()
        {
            //add reviewer
            try
            {
                context.Reviewers.Add(new Reviewer
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    FireBaseUId = "nr7myi9tbzgyjcszs9bdcsqywnz1",
                    Email = "longnbpse140814@fpt.edu.vn",
                    PublishedReviews = 5,
                    WaitingReviews = 0,
                    UnpublishedReviews = 0,
                    Status = "Verified",
                    Birthday = DateTime.ParseExact("03/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Avatar = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t1.18169-9/15697958_720212038155830_2906837649172891736_n.jpg?_nc_cat=111&ccb=1-5&_nc_sid=174925&_nc_ohc=b1SUjVy7LmIAX8Ez8R6&tn=3tomuPux_JwZsnM5&_nc_ht=scontent.fsgn2-1.fna&oh=b957b610a72a4d529c57a5549d81fcfe&oe=61883E11",
                    Certification = "",
                    MajorId = Guid.Parse(ToParseGuid("6")),
                    PhoneNumber = "0214785236",
                    Name = "Nguyễn Bá Phi Long"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviewers.Add(new Reviewer
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    FireBaseUId = "psEEUCNO7PZf0hvxvwmOL4rOxVc2",
                    Email = "hsddung92long@gmail.com",
                    PublishedReviews = 4,
                    WaitingReviews = 0,
                    UnpublishedReviews = 0,
                    Status = "Verified",
                    Birthday = DateTime.ParseExact("06/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Avatar = "https://scontent.fsgn2-4.fna.fbcdn.net/v/t1.18169-9/23168030_888989481278084_4317044370415565472_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=174925&_nc_ohc=E3Sf_wiIQPMAX9xZ8Ny&_nc_ht=scontent.fsgn2-4.fna&oh=d73e969b00142c60979683fbb80b422c&oe=618705F6",
                    Certification = "",
                    MajorId = Guid.Parse(ToParseGuid("7")),
                    PhoneNumber = "0147852369",
                    Name = "Nguyễn Bá Hùng"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviewers.Add(new Reviewer
                {
                    Id = Guid.Parse(ToParseGuid("3")),
                    FireBaseUId = "e82dgiMzkQhtuAUKE3XCAAsnyb32",
                    Email = "haltse140593@fpt.edu.vn",
                    PublishedReviews = 5,
                    WaitingReviews = 0,
                    UnpublishedReviews = 0,
                    Status = "Verified",
                    Birthday = DateTime.ParseExact("05/12/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Avatar = "https://scontent.fsgn2-2.fna.fbcdn.net/v/t1.6435-9/80574435_1272732946261515_3376890552984272896_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=LuVCvt4lgmkAX9clNXx&_nc_ht=scontent.fsgn2-2.fna&oh=f88a102faa515df2983051802c5919f3&oe=618AA8A1",
                    Certification = "",
                    MajorId = Guid.Parse(ToParseGuid("6")),
                    PhoneNumber = "0369847125",
                    Name = "Lương Thanh Hà"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Reviewers.Add(new Reviewer
            //    {
            //        Id = Guid.Parse(ToParseGuid("4")),
            //        FireBaseUId = "ezB6kng621SQ0h9GM2nEvXTA6uI3",
            //        Email = "minhdcse140811@fpt.edu.vn",
            //        PublishedReviews = 0,
            //        WaitingReviews = 0,
            //        UnpublishedReviews = 0,
            //        Status = "verified",
            //        Birthday = DateTime.ParseExact("04/11/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Avatar = "https://scontent.fsgn2-2.fna.fbcdn.net/v/t1.15752-9/243592946_651781115783702_6310347599270954694_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=ae9488&_nc_ohc=WOlS7A7bxBAAX_oytjA&_nc_ht=scontent.fsgn2-2.fna&oh=dcf3056e98588acb8c68b10d773810ec&oe=617E3AD0",
            //        Certification = "",
            //        MajorId = Guid.Parse(ToParseGuid("2")),
            //        PhoneNumber = 0368147963,
            //        Name = "Đặng Minh"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Reviewers.Add(new Reviewer
            //    {
            //        Id = Guid.Parse(ToParseGuid("5")),
            //        FireBaseUId = "gkEGPgn0uDhZwDkFFw3VwFOAfoy1",
            //        Email = "dat7124@gmail.com",
            //        PublishedReviews = 0,
            //        WaitingReviews = 0,
            //        UnpublishedReviews = 0,
            //        Status = "verified",
            //        Birthday = DateTime.ParseExact("03/09/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Avatar = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t31.18172-8/17157368_333315983730501_7105730900845101890_o.jpg?_nc_cat=111&ccb=1-5&_nc_sid=e3f864&_nc_ohc=9U2UNrGxCUUAX_9pDZ3&tn=3tomuPux_JwZsnM5&_nc_ht=scontent.fsgn2-1.fna&oh=b671379424b1e41592846d115dce0143&oe=618964A1",
            //        Certification = "",
            //        MajorId = Guid.Parse(ToParseGuid("3")),
            //        PhoneNumber = 0125469831,
            //        Name = "Đỗ Thành Đạt"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Reviewers.Add(new Reviewer
            //    {
            //        Id = Guid.Parse(ToParseGuid("6")),
            //        FireBaseUId = "c7uFw2cPB0S52K4CTn3nxgiZIYN2",
            //        Email = "lethanhvan0105@gmail.com",
            //        PublishedReviews = 0,
            //        WaitingReviews = 0,
            //        UnpublishedReviews = 0,
            //        Status = "verified",
            //        Birthday = DateTime.ParseExact("03/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Avatar = "https://scontent.fsgn2-2.fna.fbcdn.net/v/t39.30808-6/242562983_1045842172938221_4571792889453206030_n.jpg?_nc_cat=103&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=Q_bdTyQwtq8AX80oiL5&_nc_ht=scontent.fsgn2-2.fna&oh=bccc7a3cb2ff0b495595683b6b2aa149&oe=61678F29",
            //        Certification = "",
            //        MajorId = Guid.Parse(ToParseGuid("5")),
            //        PhoneNumber = 0397564178,
            //        Name = "Lê Thanh Vân"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Reviewers.Add(new Reviewer
            //    {
            //        Id = Guid.Parse(ToParseGuid("7")),
            //        FireBaseUId = "1EBQVSqQgtfI8U5Njji3kcUzHIk1",
            //        Email = "vanltse141176@fpt.edu.vn",
            //        PublishedReviews = 0,
            //        WaitingReviews = 0,
            //        UnpublishedReviews = 0,
            //        Status = "verified",
            //        Birthday = DateTime.ParseExact("12/06/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Avatar = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t1.6435-9/182006457_958652318323874_1214579627405391374_n.jpg?_nc_cat=104&ccb=1-5&_nc_sid=174925&_nc_ohc=nvv4ZXp14bsAX-d2M3d&tn=3tomuPux_JwZsnM5&_nc_ht=scontent.fsgn2-5.fna&oh=c8261a09d4e82f42bd378a4d3ebc90b9&oe=618917B3",
            //        Certification = "",
            //        MajorId = Guid.Parse(ToParseGuid("7")),
            //        PhoneNumber = 0784123659,
            //        Name = "Lê Thanh Vân"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Reviewers.Add(new Reviewer
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        FireBaseUId = "dDoSh3xbbMYImZctlvQpaYN28Vk1",
            //        Email = "phuonglhk@fpt.edu.vn",
            //        PublishedReviews = 0,
            //        WaitingReviews = 0,
            //        UnpublishedReviews = 0,
            //        Status = "verified",
            //        Birthday = DateTime.ParseExact("06/02/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Avatar = "https://scontent.fsgn2-3.fna.fbcdn.net/v/t1.15752-9/244426401_640070846987978_1187496892351981377_n.jpg?_nc_cat=108&ccb=1-5&_nc_sid=ae9488&_nc_ohc=Lyg_K0BUsQsAX-FOfVQ&_nc_ht=scontent.fsgn2-3.fna&oh=1f31e8706a54956e004f87669773761d&oe=61803637",
            //        Certification = "",
            //        MajorId = Guid.Parse(ToParseGuid("1")),
            //        PhoneNumber = 0784123659,
            //        Name = "Lâm Khánh Hữu Phương"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            return Ok();
        }

        [HttpGet("InitDataUniversity")]
        public ActionResult InitDataUniversity()
        {
            //add university
            try
            {
                context.Universities.Add(new University
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    Name = "FPT",
                    PhoneNumber = "023673001866",
                    Email = "daihocfpt@fpt.edu.vn",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/archive/1/1d/20210321075522%21Logo_%C4%90%E1%BA%A1i_h%E1%BB%8Dc_FPT.png",
                    //Status = "true",

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("2")),
            //        Name = "Trường Đại học Công nghiệp",
            //        PhoneNumber = 02838940390,
            //        Email = "dhcn@iuh.edu.vn",
            //        Image = "https://th.bing.com/th/id/R.169be66a2c9620c366af117d1b56545c?rik=UN5R%2fRD58WTMig&riu=http%3a%2f%2ftoplist.vn%2fimages%2f800px%2fdai-hoc-cong-nghiep-tphcm-149759.jpg&ehk=tLFnWOxa%2fEYZJais6r5xo3ZK24jQPirfVqCi%2fIcZK%2fU%3d&risl=&pid=ImgRaw&r=0",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("3")),
            //        Name = "Trường Đại học Kinh tế",
            //        PhoneNumber = 02838295299,
            //        Email = "info@ueh.edu.vn",
            //        Image = "https://media.vneconomy.vn/w800/images/upload/2021/10/08/large-image-edb907cea0.png",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("4")),
            //        Name = "Trường Đại học Giáo dục",
            //        PhoneNumber = 02473017123,
            //        Email = "education@vnu.edu.vn",
            //        Image = "https://th.bing.com/th/id/R.343edc4252e54c6a8132ed66ee5742cb?rik=qlJyMnsWOjXY8w&riu=http%3a%2f%2ftuyensinh.vnu.edu.vn%2fassets%2fuploads%2ffiles%2fNews%2f2cee9-01d23-tuyen-sinh-dhgd-2021.jpg&ehk=T%2bkq5ahAV2M%2famm8QglWCBJu3VGiklRXqTmitl0nX0M%3d&risl=&pid=ImgRaw&r=0",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("5")),
            //        Name = "Trường Đại học Khoa học Tự nhiên",
            //        PhoneNumber = 02862884499,
            //        Email = "bantin@hcmus.edu.vn",
            //        Image = "https://thongtintuyensinh.net/wp-content/uploads/2020/06/dai_hoc_khoa_hoc_tu_nhien_tp_hcm1-768x614.jpg",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("6")),
            //        Name = "Trường Đại học Khoa học Xã hội và Nhân văn",
            //        PhoneNumber = 02838221909,
            //        Email = "phongdaotao@hcmussh.edu.vn",
            //        Image = "https://vn-school.s3-ap-northeast-1.amazonaws.com/school/7/truong-dai-hoc-khoa-hoc-xa-hoi-va-nhan-van-3-ZUnQl6.jpg",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("7")),
            //        Name = "Trường Đại học Ngoại ngữ",
            //        PhoneNumber = 02838632052,
            //        Email = "contact@huflit.edu.vn",
            //        Image = "https://www.huflit.edu.vn/uploads/about/1-truong.jpg",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        Name = "Trường Đại học Y Dược",
            //        PhoneNumber = 02838558411,
            //        Email = "daihocyduoc@ump.edu.vn",
            //        Image = "https://th.bing.com/th/id/R.fee57891a4f8e14667f59e9dd203a322?rik=RYkYhYokJstWuw&riu=http%3a%2f%2fkienthucnhakhoa.edu.vn%2fupload%2fimage%2ftruong-dai-hoc-y-duoc-tp-hcm.jpg&ehk=R1Unn0LaVjxmbea%2bqGFD44OegGmt2nmiMzostEWyevI%3d&risl=&pid=ImgRaw&r=0",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.Universities.Add(new University
                {
                    Id = Guid.Parse(ToParseGuid("9")),
                    Name = "Trường Đại học Bách Khoa",
                    PhoneNumber = "02838647256",
                    Email = " ctctsv@hcmut.edu.vn",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/c/cd/Logo-hcmut.svg/1004px-Logo-hcmut.svg.png",
                    //Status = "true",

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Universities.Add(new University
            //    {
            //        Id = Guid.Parse(ToParseGuid("10")),
            //        Name = "Trường Đại học Công nghệ Thông tin và Truyền thông",
            //        PhoneNumber = 02837252002,
            //        Email = "info@uit.edu.vn",
            //        Image = "https://th.bing.com/th/id/OIP.0tvzhNvYOw0dLUQMkuuGTAHaFS?pid=ImgDet&rs=1",
            //        //Status = "true",

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            return Ok();
        }

        [HttpGet("InitDataCampaign")]
        public ActionResult InitDataCampaign()
        {
            //add campaign
            /// campain1
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    Name = "Tổng quan về trường đại học FPT",
                    CampusId = Guid.Parse(ToParseGuid("2")),
                    Description = "Review, đánh giá trường đại học FPT về những ưu và nhược điểm. Giúp bạn có cái nhìn tổng quan sâu sắc hơn về trường đại học FPT.",
                    StartDay = DateTime.ParseExact("09/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("28/11/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://hcmuni.fpt.edu.vn/Data/Sites/1/media/2020-kim-vi/seo/campus/1-truong-dai-hoc-fpt-tphcm/truong-dai-hoc-fpt-tp-hcm-(1).jpg",
                    ReviewerJoined = 2,
                    UnpublishedReviews = 0,
                    PublishedReviews = 2,
                    WaitingReviews = 0

                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain2
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    Name = "Quân sự trong tôi",
                    CampusId = Guid.Parse(ToParseGuid("2")),

                    Description = "Hãy miêu tả 1 kỷ niệm đẹp của bạn trong khoảng thời gian học quân sự.",
                    StartDay = DateTime.ParseExact("18/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("20/11/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://hcmuni.fpt.edu.vn/Data/Sites/1/media/kho%E1%BA%A3nh-kh%E1%BA%AFc-%C4%91%E1%BB%9Di-l%C3%ADnh/72211011_1369286846561085_7354137037672284160_o.jpg",
                    ReviewerJoined = 2,
                    UnpublishedReviews = 0,
                    PublishedReviews = 2,
                    WaitingReviews = 0
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain3
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("3")),
                    Name = "Trung thu yêu thương",
                    CampusId = Guid.Parse(ToParseGuid("2")),

                    Description = "Viết một bài viết liên quan đến chủ đề Tết Trung thu",
                    StartDay = DateTime.ParseExact("01/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("01/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://scontent.fsgn5-11.fna.fbcdn.net/v/t1.6435-9/242106022_396028035428006_4788682959364881495_n.png?_nc_cat=111&ccb=1-5&_nc_sid=0debeb&_nc_ohc=DY1l7SfAowYAX9fUsN8&_nc_ht=scontent.fsgn5-11.fna&oh=01313f795925d987b651772603153edf&oe=619F51FC",
                    ReviewerJoined = 2,
                    UnpublishedReviews = 0,
                    PublishedReviews = 2,
                    WaitingReviews = 0

                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain 4
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("4")),
                    Name = "FPTU DEBATE TOURNAMENT – SÀN ĐẤU TRANH BIỆN HẤP DẪN NHẤT ĐẠI HỌC FPT",
                    CampusId = Guid.Parse(ToParseGuid("2")),

                    Description = "Cuộc thi tranh biện FPTU Debate Tournament Season 2 đã chính thức quay trở lại. Cuộc thi chính là cơ hội cho các bạn sinh viên được cọ xát, tham gia thể hiện khả năng lập luận và tư duy phản biện, rèn luyện tinh thần đồng đội của mình.",
                    StartDay = DateTime.ParseExact("29/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("25/11/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://hcmuni.fpt.edu.vn/Data/Sites/1/News/6696/poster.jpg",
                    ReviewerJoined = 2,
                    UnpublishedReviews = 0,
                    PublishedReviews = 0,
                    WaitingReviews = 2
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain5
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("5")),
                    Name = "Xuân ấm áp",
                    CampusId = Guid.Parse(ToParseGuid("2")),

                    Description = "Viết một bài viết liên quan đến chủ đề Lễ Hội Mùa Xuân.",
                    StartDay = DateTime.ParseExact("10/01/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("15/02/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://daihoc.fpt.edu.vn/media/2021/01/133736669_2830535887215900_1735885041122993898_o-910x346.png",
                    ReviewerJoined = 0,
                    UnpublishedReviews = 0,
                    PublishedReviews = 0,
                    WaitingReviews = 0
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain6
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("6")),
                    Name = "Chào đón tân sinh viên",
                    CampusId = Guid.Parse(ToParseGuid("2")),
                    Status = "Ended",
                    Description = "Viết một bài viết nêu lên những cảm nhận,những trải nghiệm của bạn trong sự kiện chào đón tân sinh viên.",
                    StartDay = DateTime.ParseExact("05/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("20/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://th.bing.com/th/id/R.8f7d802612603fae5d32863423f68e0b?rik=MOC1ZkYwv%2fHHIg&riu=http%3a%2f%2fphuthanhdat.com.vn%2fuploads%2fdsc_0726.jpg&ehk=9TZ2AXlZ8vHH12fc3A4H5w7UFo%2bCo0%2f%2bfv09LmCnV6A%3d&risl=&pid=ImgRaw&r=0",
                    ReviewerJoined = 2,
                    UnpublishedReviews = 0,
                    PublishedReviews = 2,
                    WaitingReviews = 0
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //// campain7
            //try
            //{
            //    context.Campaigns.Add(new Campaign
            //    {
            //        Id = Guid.Parse(ToParseGuid("7")),
            //        Name = "Codewars Intership",
            //        CampusId = Guid.Parse(ToParseGuid("2")),
            //        Status = "Public",
            //        Description = "Nêu cảm nhận của bạn khi tham gia cuộc thi Codewars Intership trong kì thực tập tại FPT Software",
            //        StartDay = DateTime.ParseExact("30/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        EndDay = DateTime.ParseExact("28/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Image = "https://scontent.fsgn2-6.fna.fbcdn.net/v/t1.6435-9/241380248_4075436759252463_4866786731961157608_n.jpg?_nc_cat=110&ccb=1-5&_nc_sid=825194&_nc_ohc=eLc_KTMpmggAX8XFVAn&_nc_ht=scontent.fsgn2-6.fna&oh=98aa7cda9ec9ef856c7abc8578573722&oe=618A9FCF"

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //// campain8
            //try
            //{
            //    context.Campaigns.Add(new Campaign
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        Name = "Tình nguyện mùa hè xanh",
            //        CampusId = Guid.Parse(ToParseGuid("2")),
            //        Status = "Ended",
            //        Description = "Chiến dịch được thực hiện với mục tiêu giúp đỡ những hoàn cảnh khó khăn ở vùng sâu, vùng xa, đồng thời tham gia sinh hoạt văn hóa và giao lưu với các em nhỏ tại địa phương.",
            //        StartDay = DateTime.ParseExact("28/05/5021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        EndDay = DateTime.ParseExact("30/06/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        Image = "https://i.chungta.vn/2014/09/18/anhdoievent-937305-1413030758.jpg"

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// campain9
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("9")),
                    Name = "Đánh giá trường Đại Học Bách khoa",
                    CampusId = Guid.Parse(ToParseGuid("18")),
                    Status = "Ended",
                    Description = "Review, đánh giá trường đại học Bách Khoa về những ưu và nhược điểm. Giúp bạn có cái nhìn tổng quan sâu sắc hơn về trường đại học Bách Khoa.",
                    StartDay = DateTime.ParseExact("11/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("30/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://thptquocgia.com/wp-content/uploads/bach-khoa.jpg",
                    ReviewerJoined = 1,
                    UnpublishedReviews = 0,
                    PublishedReviews = 0,
                    WaitingReviews = 1
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain10
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("10")),
                    Name = "Chiến dịch tình nguyện MÙA HÈ XANH",
                    CampusId = Guid.Parse(ToParseGuid("18")),
                    Status = "Ended",
                    Description = "Hãy nêu cảm nghĩ và trải nghiệm của bạn khi tham gia chiến dịch giúp đỡ,đồng thời tham gia sinh hoạt văn hóa và giao lưu với các em nhỏ tại những vùng khó khăn.",
                    StartDay = DateTime.ParseExact("12/07/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("25/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://iuyouth.edu.vn/wp-content/uploads/2021/07/AVAFINAL-01-2048x2048.jpg",
                    ReviewerJoined = 1,
                    UnpublishedReviews = 0,
                    PublishedReviews = 1,
                    WaitingReviews = 0

                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain12
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("12")),
                    Name = "Blouse Trắng Tình Nguyện Chống Dịch",
                    CampusId = Guid.Parse(ToParseGuid("18")),
                    Status = "Ended",
                    Description = "Chiến dịch được thực hiện với mục tiêu iếp cận và giúp đỡ những hộ dân còn nhiều khó khăn về khám chữa bệnh. Mục tiêu của chiến dịch lần này nhằm thổi bùng lên ngọn lửa tương thân tương ái, “lá lành đùm lá rách” đang lan tỏa sâu rộng đến những khu vực vùng sâu vùng xa.",
                    StartDay = DateTime.ParseExact("09/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("30/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://scontent.fsgn2-3.fna.fbcdn.net/v/t1.6435-9/209439387_4206032602823399_5117557307166831661_n.png?_nc_cat=108&ccb=1-5&_nc_sid=730e14&_nc_ohc=LYqIaDpwq6IAX8Vln-s&_nc_ht=scontent.fsgn2-3.fna&oh=be4be91ec6b0011bde46b5d4bc478bae&oe=6180CDDF",
                    ReviewerJoined = 1,
                    UnpublishedReviews = 0,
                    PublishedReviews = 1,
                    WaitingReviews = 0
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// campain13
            try
            {
                context.Campaigns.Add(new Campaign
                {
                    Id = Guid.Parse(ToParseGuid("13")),
                    Name = "Trung thu vui vẻ",
                    CampusId = Guid.Parse(ToParseGuid("18")),
                    Status = "Ended",
                    Description = "Viết một bài viết liên quan đến chủ đề Tết Trung thu",
                    StartDay = DateTime.ParseExact("20/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDay = DateTime.ParseExact("30/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Image = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t1.6435-9/p843x403/242336314_1517546761944864_4536750263173847509_n.jpg?_nc_cat=104&ccb=1-5&_nc_sid=730e14&_nc_ohc=gYmU3TNjAhEAX91zUmp&_nc_ht=scontent.fsgn2-5.fna&oh=79c0fb244c862f6e5a16b3508c168063&oe=618B05B8",
                    ReviewerJoined = 1,
                    UnpublishedReviews = 0,
                    PublishedReviews = 1,
                    WaitingReviews = 0
                });
                context.SaveChanges();
            }
            catch
            {

            }
            return Ok();
        }

        [HttpGet("InitDataCampus")]
        public ActionResult InitDataCampus()
        {
            // add campus
            /// đại học fpt
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("1")),
            //        Name = "Hòa Lạc",
            //        Status ="true" ,
            //        Address = "Khu Giáo dục và Đào tạo – Khu Công nghệ cao Hòa Lạc – Km29 Đại lộ Thăng Long, H. Thạch Thất, TP. Hà Nội",
            //        PhoneNumber = 02473001866,
            //        Email = "daihocfpt@fpt.edu.vn",
            //        Image = "https://daihoc.fpt.edu.vn/media/2016/12/nh%C3%A0-hi%E1%BB%87u-b%E1%BB%99-768x512.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.Campuses.Add(new Campus
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    Name = "Hồ Chí Minh",
                    //Status = "true",
                    Address = "Lô E2a-7, Đường D1 Khu Công nghệ cao, P. Long Thạnh Mỹ, TP. Thủ Đức, TP. Hồ Chí Minh",
                    PhoneNumber = "02873001866",
                    Email = "daihocfpt@fpt.edu.vn",
                    Image = "https://daihoc.fpt.edu.vn/media/2020/02/IMG_0664-910x607.jpg",
                    UniversityId = Guid.Parse(ToParseGuid("1"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("3")),
            //        Name = "Đà Nẵng",
            //        //Status = "true",
            //        Address = "Khu đô thị công nghệ FPT Đà Nẵng, P. Hoà Hải, Q. Ngũ Hành Sơn, TP. Đà Nẵng",
            //        PhoneNumber = 02367301866,
            //        Email = "daihocfpt@fpt.edu.vn",
            //        Image = "https://i.chungta.vn/2020/09/30/the-thinke-9110-1601403066.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("4")),
            //        Name = "Cần Thơ",
            //        //Status = "true",
            //        Address = "Số 600 Đường Nguyễn Văn Cừ (nối dài), P. An Bình, Q. Ninh Kiều, TP. Cần Thơ",
            //        PhoneNumber = 02927301866,
            //        Email = "daihocfpt@fpt.edu.vn",
            //        Image = "https://trangedu.com/wp-content/uploads/2020/12/dai-hoc-fpt-can-tho.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("5")),
            //        Name = "Quy Nhơn",
            //        //Status = "true",
            //        Address = "Khu đô thị mới An Phú Thịnh, Phường Nhơn Bình & Phường Đống Đa, TP. Quy Nhơn, Bình Định",
            //        PhoneNumber = 02567301866,
            //        Email = "daihocfpt@fpt.edu.vn",
            //        Image = "https://uni.fpt.edu.vn/Data/Sites/1/Banner/fpt_quy-nhon_ktx_pctt_01.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            ///// dai hoc công nghiệp
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("6")),
            //        Name = "Cơ sở chính (TP.HCM)",
            //        //Status = "true",
            //        Address = "12 Nguyễn Văn Bảo, P.4, Q. Gò Vấp, TP.HCM",
            //        PhoneNumber = 02838651670,
            //        Email = "dhcn@iuh.edu.vn",
            //        Image = "https://images.foody.vn/res/g11/107882/s/foody-truong-dai-hoc-cong-nghiep-tphcm-go-vap-460-635571706082225880.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("2"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("7")),
            //        Name = "Phân hiệu Quảng Ngãi",
            //        //Status = "true",
            //        Address = "938 Quang Trung, TP. Quảng Ngãi",
            //        PhoneNumber = 02553250075,
            //        Email = "dhcn@iuh.edu.vn",
            //        Image = "http://www.hui.edu.vn/Resource/Upload2/Image/album/cacdonvi/quangngai/khu-giang-duong.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("2"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /////Trường Đại học Kinh tế
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        Name = "Hồ Chí Minh",
            //        //Status = "true",
            //        Address = "59C Nguyễn Đình Chiểu, P.6, Q.3, TP. Hồ Chí Minh",
            //        PhoneNumber = 02838230082,
            //        Email = "tuyensinh@ueh.edu.vn",
            //        Image = "https://show.vn/wp-content/uploads/Thong-tin-tuyen-sinh-truong-Dai-hoc-Kinh-te-TPHCM.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("3"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("9")),
            //        Name = "Vĩnh Long",
            //        //Status = "true",
            //        Address = "1B Nguyễn Trung Trực, P8,TP.Vĩnh Long,tỉnh Vĩnh Long",
            //        PhoneNumber = 02703823359,
            //        Email = "tuyensinh@ueh.edu.vn",
            //        Image = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t1.6435-9/244091800_1980351612121806_266307489164062716_n.jpg?_nc_cat=105&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=-IgOeC1f3egAX_zUXkv&_nc_ht=scontent.fsgn2-1.fna&oh=8e877bf26e2a19e78d2ae3e7ed2825e4&oe=618A3D6C",
            //        UniversityId = Guid.Parse(ToParseGuid("3"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /////Trường Đại học Khoa học Tự nhiên
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("10")),
            //        Name = "Cơ sở 1",
            //        //Status = "true",
            //        Address = "227 Nguyễn Văn Cừ, Phường 4, Quận 5, Tp. HCM",
            //        PhoneNumber = 038353193,
            //        Email = "bantin@hcmus.edu.vn",
            //        Image = "https://7bbb83f1-a-62cb3a1a-s-sites.googlegroups.com/site/camnangtansv/truong-dhai-hoc-khoa-hoc-tu-nhien/cac-co-so-cua-truong/29.jpg?attachauth=ANoY7comVIXvRjRX9jsmuM9H3kXuPV3Xvy4Udhpyagkyl3XOnnZn6kU_-3EFMVFgkJApIdxnVwkjVKsHMeYMSp6s7iOpMnF1udUSSgNpsgdM8Nh8D396pNZSZo-AErszaOKTfmYrHIlljrzdTR3yblQHgL91RXN0FY1UBvuqNnmcHhVDMEfS2XGRtkKZ0gt7qO43fBGQSTUVTmSfX6CqWE1OaLsyozTNbzt5UCR9-EcpIbK-PLT-EO_LjO7mNZmt2fBqK9gLJGQGHl2ljs42bxmAldheAmAnHA%3D%3D&attredirects=0",
            //        UniversityId = Guid.Parse(ToParseGuid("5"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("12")),
            //        Name = "Cơ sở 2",
            //        //Status = "true",
            //        Address = " Phường Linh Trung, Quận Thủ Đức, Tp. HCM",
            //        PhoneNumber = 038353193,
            //        Email = "bantin@hcmus.edu.vn",
            //        Image = "https://trangtuyensinh.com.vn/images/files/trangtuyensinh.com.vn/daihoc/truong-dai-hoc-khoa-hoc-tu-nhien-dhqg-tphcm-trang-tuyen-sinh.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("5"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /////Trường Đại học Khoa học Xã hội và Nhân văn
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("13")),
            //        Name = "Cơ sở Quận 1",
            //        //Status = "true",
            //        Address = "10-12 Đinh Tiên Hoàng, Phường Bến Nghé, Quận 1, TP. HCM",
            //        PhoneNumber = 0838293828,
            //        Email = "hanhchinh@hcmussh.edu.vn",
            //        Image = "https://hcmussh.edu.vn/img/content/vE9dPtXQCjzHOllMr2Fih3i-.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("6"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("14")),
            //        Name = "Cơ sở Thành phố Thủ Đức",
            //        //Status = "true",
            //        Address = "Khu phố 6, Phường Linh Trung, Thành phố Thủ Đức, TP. HCM",
            //        PhoneNumber = 02838293828,
            //        Email = "hanhchinh@hcmussh.edu.vn",
            //        Image = "https://media.travelmag.vn/files/content/2021/09/16/dh-khxh-va-nv-18113378.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("6"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            ///// Trường Đại học Ngoại ngữ
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("15")),
            //        Name = "Hồ Chí Minh",
            //        //Status = "true",
            //        Address = "828 Sư Vạn Hạnh, Phường 13, Quận 10, TP. Hồ Chí Minh",
            //        PhoneNumber = 02838632052,
            //        Email = "tuyensinh@huflit.edu.vn",
            //        Image = "https://bigdata-vn.com/wp-content/uploads/2021/09/Truong-Dai-hoc-Ngoai-ngu-Tin-hoc-TP-HCM.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("7"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            ///// Trường Đại học Y Dược
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("16")),
            //        Name = "Hồ Chí Minh",
            //        //Status = "true",
            //        Address = "217 Hồng Bàng, Phường 11, Quận 5, TP.HCM",
            //        PhoneNumber = 02838566154,
            //        Email = "hanhchinhtochuckhoay@ump.edu.vn",
            //        Image = "https://baomoi-photo-fbcrawler.zadn.vn/w720x480/2021_10_10_83_40503215/5ecfa0a1ede304bd5df2.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("8"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// Trường Đại học Bách Khoa
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("17")),
            //        Name = "Cơ sở 1",
            //        //Status = "true",
            //        Address = "268 Lý Thường Kiệt, Phường 14, Quận 10, TP. HCM",
            //        PhoneNumber = 02838651670,
            //        Email = "info@hcmut.edu.vn",
            //        Image = "https://unizone.edu.vn/wp-content/uploads/2019/11/truong-dai-hoc-bach-khoa-tp-hcm.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("9"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.Campuses.Add(new Campus
                {
                    Id = Guid.Parse(ToParseGuid("18")),
                    Name = "Cơ sở 2",
                    //Status = "true",
                    Address = "Cơ sở Dĩ An – Khu đô thị Đại học Quốc Gia TP. HCM, Quận Thủ Đức, TP. HCM",
                    PhoneNumber = "02838647256",
                    Email = "info@hcmut.edu.vn",
                    Image = "https://myphammioskin.com.vn/dai-hoc-bach-khoa-thu-duc/imager_1_38499_700.jpg",
                    UniversityId = Guid.Parse(ToParseGuid("9"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            ///// Trường Đại học Công nghệ Thông tin
            //try
            //{
            //    context.Campuses.Add(new Campus
            //    {
            //        Id = Guid.Parse(ToParseGuid("19")),
            //        Name = "Hồ Chí Minh",
            //        //Status = "true",
            //        Address = "Khu phố 6, P.Linh Trung, Tp.Thủ Đức, Tp.Hồ Chí Minh.",
            //        PhoneNumber = 02837252002,
            //        Email = "info@uit.edu.vn",
            //        Image = "https://tuyensinh.uit.edu.vn/sites/default/files/uploads/files/dai-hoc-uit-3.jpg",
            //        UniversityId = Guid.Parse(ToParseGuid("9"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            return Ok();
        }

        [HttpGet("InitDataMarjor")]
        public ActionResult InitDataMarjor()
        {
            // add marjor
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //       Id = Guid.Parse(ToParseGuid("1")),
            //       Name = "Công nghệ thông tin",
            //       Code = "CNTT",
            //       Status ="true",
            //       CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("2")),
            //        Name = "Quản trị kinh doanh",
            //        Code = "QTKD",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("3")),
            //        Name = "Ngôn ngữ Anh",
            //        Code = "NNA",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("4")),
            //        Name = "Ngôn ngữ Hàn Quốc",
            //        Code = "NNH",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("5")),
            //        Name = "Kinh doanh Quốc Tế",
            //        Code = "KTQT",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.Majors.Add(new Major
                {
                    Id = Guid.Parse(ToParseGuid("6")),
                    Name = "Kỹ thuật phần mềm",
                    Code = "KTPM",
                    //Status = "true",
                    CampusId = Guid.Parse(ToParseGuid("2"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Majors.Add(new Major
                {
                    Id = Guid.Parse(ToParseGuid("7")),
                    Name = "An toàn thông tin",
                    Code = "ATTT",
                    //Status = "true",
                    CampusId = Guid.Parse(ToParseGuid("18"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        Name = "Quản trị khách sạn",
            //        Code = "QTKS",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("9")),
            //        Name = "Ngôn ngữ Nhật",
            //        Code = "NNN",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Majors.Add(new Major
            //    {
            //        Id = Guid.Parse(ToParseGuid("10")),
            //        Name = "Truyền thông đa phương tiện",
            //        Code = "TTDPT",
            //        //Status = "true",
            //        CampusId = Guid.Parse(ToParseGuid("1"))
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            return Ok();
        }

        [HttpGet("initdatacriterion")]
        public ActionResult InitdataCriterion()
        {
            //add criterion
            /// Chiến dịch 1
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    Name = "Cơ sở vật chất",
                    CampaignId = Guid.Parse(ToParseGuid("1"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    Name = "Chương trình giảng dạy",
                    CampaignId = Guid.Parse(ToParseGuid("1"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("3")),
            //        Name = "Đội ngũ giáo viên",
            //        CampaignId = Guid.Parse(ToParseGuid("1")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("4")),
            //        Name = "Dịch vụ",
            //        CampaignId = Guid.Parse(ToParseGuid("1")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// Chiến dịch 2
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("5")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("2"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("6")),
            //        Name = "Sự kiện",
            //        CampaignId = Guid.Parse(ToParseGuid("2")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("7")),
                    Name = "Sinh Hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("2"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        Name = "Cơ sở vật chất",
            //        CampaignId = Guid.Parse(ToParseGuid("2")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// Chiến dịch 3
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("9")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("3"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("10")),
                    Name = "Sinh hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("3"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("12")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("3"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// Chiến dịch 4
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("13")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("4"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("14")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("4"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("15")),
                    Name = "Cơ sở vật chất",
                    CampaignId = Guid.Parse(ToParseGuid("4"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // Chiến dịch 5
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("16")),
                    Name = "Sinh hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("5"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("17")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("5"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("18")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("5"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // Chiến dịch 6
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("19")),
            //        Name = "Cơ sở vật chất",
            //        CampaignId = Guid.Parse(ToParseGuid("6")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("20")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("6"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("22")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("6"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("23")),
                    Name = "Sinh hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("6"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //// chiến dich 7
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("24")),
            //        Name = "Hoạt động",
            //        CampaignId = Guid.Parse(ToParseGuid("7")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("25")),
            //        Name = "Sinh hoạt",
            //        CampaignId = Guid.Parse(ToParseGuid("7")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("26")),
            //        Name = "Sự kiện",
            //        CampaignId = Guid.Parse(ToParseGuid("7")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("27")),
            //        Name = "Mức độ thân thiện",
            //        CampaignId = Guid.Parse(ToParseGuid("7")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //// chiến dịch 8
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("28")),
            //        Name = "Sự kiện",
            //        CampaignId = Guid.Parse(ToParseGuid("8")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("29")),
            //        Name = "Hoạt động",
            //        CampaignId = Guid.Parse(ToParseGuid("8")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Criterions.Add(new Criterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("30")),
            //        Name = "Sinh hoạt",
            //        CampaignId = Guid.Parse(ToParseGuid("8")),
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            // chiến dịch 9
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("32")),
                    Name = "Cơ sở vật chất",
                    CampaignId = Guid.Parse(ToParseGuid("9"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("33")),
                    Name = "Chương trình giảng dạy",
                    CampaignId = Guid.Parse(ToParseGuid("9"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("34")),
                    Name = "Dịch vụ",
                    CampaignId = Guid.Parse(ToParseGuid("9"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("35")),
                    Name = "Đội ngũ giáo viên",
                    CampaignId = Guid.Parse(ToParseGuid("9"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // chien dich 10
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("36")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("10"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("37")),
                    Name = "Sinh hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("10"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("38")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("10"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // chien dich 12
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("39")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("12"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("40")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("12"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("42")),
                    Name = "Sinh hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("12"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // chien dich 13
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("43")),
                    Name = "Sự kiện",
                    CampaignId = Guid.Parse(ToParseGuid("13"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("44")),
                    Name = "Hoạt động",
                    CampaignId = Guid.Parse(ToParseGuid("13"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Criterions.Add(new Criterion
                {
                    Id = Guid.Parse(ToParseGuid("45")),
                    Name = "Sinh hoạt",
                    CampaignId = Guid.Parse(ToParseGuid("13"))
                });
                context.SaveChanges();
            }
            catch
            {

            }
            return Ok();
        }

        [HttpGet("InitDataReview")]
        public ActionResult InitDataReview()
        {
            // add review
            /// review 1
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    Status = "Waiting",
                    Title = "Có Nên Học Đại Học FPT Không?",
                    Content = "Lạc vào FPT, bạn sẽ lập tức bị đốn tim bởi không gian xanh mướt và lối kiến trúc đẹp như mơ chẳng kém gì những khu nghỉ dưỡng hạng sang.\n- Sinh viên không cần phải lên tận Hồ Tây để chụp sen, sinh viên Đại học FPT có thể thỏa sức tạo dáng tại hồ sen rộng 2 ha ngay trong khuôn viên nhà trường.\n- Tương truyền rằng: Ở FPT, dàn nam nhân hùng hậu đã áp đảo về mặt số lượng với dàn nữ nhân. Do đó, tỷ lệ Ế của các nam nhân nhà F ngày một tăng theo cấp số nhân.\n- trường Đại Học của tập đoàn FPT thì chắc là cũng tốt đấy, với cả có trường nào pr lại nói trường mình không tốt đâu, còn bị dìm hay không, tốt nghiệp sớm hay muộn chủ yếu là do bản thân thôi, còn vào trường này là phải có điều kiện rồi, nyc mình đang học ở đây  . gia đình bạn có điều kiện và bạn có đam mê với CNTT thì vào thôi chứ còn chờ gì nữa hihi.\n- Mình hiện tại năm cuối của trường, và xác nhận việc dìm học sinh là có thật :slight_smile: Nhưng chỉ là 1 vài giảng viên thôi, mà kiểu giảng viên sát thủ như vậy luôn xuất hiện ở các trường đại học khác mà nên không sao, miễn bạn học tốt, chăm chỉ, tư duy tốt là ok. Bởi vì chương trình học ở đây khá nặng nên nhiều sv bỏ cuộc hoặc out (đó là những sv sức học yếu) nên về kêu ca, đồn thổi, ngụy biện cho cái bất tài của họ là bình thường',",
                    OnDateTime = DateTime.ParseExact("01/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("1")),
                    ReviewerId = Guid.Parse(ToParseGuid("1")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("14")),
                    Status = "Waiting",
                    Title = "Có Nên Học Đại Học FPT Không?",
                    Content = "Lạc vào FPT, bạn sẽ lập tức bị đốn tim bởi không gian xanh mướt và lối kiến trúc đẹp như mơ chẳng kém gì những khu nghỉ dưỡng hạng sang.\n- Sinh viên không cần phải lên tận Hồ Tây để chụp sen, sinh viên Đại học FPT có thể thỏa sức tạo dáng tại hồ sen rộng 2 ha ngay trong khuôn viên nhà trường.\n- Tương truyền rằng: Ở FPT, dàn nam nhân hùng hậu đã áp đảo về mặt số lượng với dàn nữ nhân. Do đó, tỷ lệ Ế của các nam nhân nhà F ngày một tăng theo cấp số nhân.\n- trường Đại Học của tập đoàn FPT thì chắc là cũng tốt đấy, với cả có trường nào pr lại nói trường mình không tốt đâu, còn bị dìm hay không, tốt nghiệp sớm hay muộn chủ yếu là do bản thân thôi, còn vào trường này là phải có điều kiện rồi, nyc mình đang học ở đây  . gia đình bạn có điều kiện và bạn có đam mê với CNTT thì vào thôi chứ còn chờ gì nữa hihi.\n- Mình hiện tại năm cuối của trường, và xác nhận việc dìm học sinh là có thật :slight_smile: Nhưng chỉ là 1 vài giảng viên thôi, mà kiểu giảng viên sát thủ như vậy luôn xuất hiện ở các trường đại học khác mà nên không sao, miễn bạn học tốt, chăm chỉ, tư duy tốt là ok. Bởi vì chương trình học ở đây khá nặng nên nhiều sv bỏ cuộc hoặc out (đó là những sv sức học yếu) nên về kêu ca, đồn thổi, ngụy biện cho cái bất tài của họ là bình thường',",
                    OnDateTime = DateTime.ParseExact("01/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("1")),
                    ReviewerId = Guid.Parse(ToParseGuid("3")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// review 2
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    Status = "Waiting",
                    Title = "Quân sự tháng 9",
                    Content = "Buổi sáng ngày đầu nhập học, chúng tôi được mặc quân phục màu xanh cùng nón tai bèo, trông như những thanh niên xung phong. Chúng tôi được nghe những quy tắc khi học tập và sinh hoạt ở trong ký túc xá của trung tâm, những yêu cầu như: thức giấc đúng giờ, tập trung tập thể dục, ăn sáng, học tập theo đúng quy định. Các buổi học chính trị với những bài học quan trọng, xen lẫn là câu chuyện cười hài hước của các giảng viên, đã giúp chúng tôi vượt qua những cơn buồn ngủ, để hoàn thành tốt các yêu cầu của nhà trường. Có lẽ những giờ thực hành để lại ấn tượng nhất trong tôi, nhất là cảm giác thích thú khi được chạm vào các loại súng, những hộp thiết đạn.... những cái mà chúng tôi chỉ có thể thấy qua sách báo, phim ảnh nay lại rất gần gũi.",
                    OnDateTime = DateTime.ParseExact("15/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("2")),
                    ReviewerId = Guid.Parse(ToParseGuid("1")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("15")),
                    Status = "Waiting",
                    Title = "Quân sự tháng 9",
                    Content = "Buổi sáng ngày đầu nhập học, chúng tôi được mặc quân phục màu xanh cùng nón tai bèo, trông như những thanh niên xung phong. Chúng tôi được nghe những quy tắc khi học tập và sinh hoạt ở trong ký túc xá của trung tâm, những yêu cầu như: thức giấc đúng giờ, tập trung tập thể dục, ăn sáng, học tập theo đúng quy định. Các buổi học chính trị với những bài học quan trọng, xen lẫn là câu chuyện cười hài hước của các giảng viên, đã giúp chúng tôi vượt qua những cơn buồn ngủ, để hoàn thành tốt các yêu cầu của nhà trường. Có lẽ những giờ thực hành để lại ấn tượng nhất trong tôi, nhất là cảm giác thích thú khi được chạm vào các loại súng, những hộp thiết đạn.... những cái mà chúng tôi chỉ có thể thấy qua sách báo, phim ảnh nay lại rất gần gũi.",
                    OnDateTime = DateTime.ParseExact("15/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("2")),
                    ReviewerId = Guid.Parse(ToParseGuid("3")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// review 3
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("3")),
                    Status = "Waiting",
                    Title = "Trung thu yêu thương",
                    Content = "Tuổi thơ ai cũng từng rước đèn quanh xóm, phá cỗ mâm bánh kẹo, hoa quả cùng với đám trẻ con cùng trang lứa. Tuổi thơ của mình cũng thế, cũng làm lồng đèn ông sao, rồi rước đèn với lũ bạn và các anh chị trong khu xóm nhỏ, vừa đi vừa ngân nga hát “Tết Trung Thu em rước đèn đi chơi, em rước đèn đi khắp phố phường. Lòng vui sướng với đèn trong tay. Em múa ca trong ánh trăng rằm”. Những ký ức về Tết Trung Thu khiến mình vẫn luôn muốn quay trở về ngày đó nhất là kỷ niệm với nhóm Củ Cải Lộn Xào. Bữa tiệc nào cũng đến lúc tàn, niềm vui nào cũng đến lúc tan nhưng thứ để lại trong lòng chúng ta là những ký ức, kỷ niệm mãi không quên đó. Cho đến bây giờ, mình vẫn luôn muốn quay trở lại ngày đó để cùng cười thật thoải mái với chúng nó, cùng nói về những điều xàm xí, cùng nghĩ về ước mơ tương lai. Hai năm rồi, Trung Thu năm nào mình cũng lục lại những tấm hình kỷ niệm đó để coi lại và vào group chat ỷ ôi vài câu nhớ ngày đó, hỏi Ngân khi nào thì vào lại Vũng Tàu để còn sum vầy. Mình nhớ Củ Cải Lộn Xào nhiều lắm vì chẳng ở đâu mình có được những người bạn như vậy. Huỳnh Anh, Mai Anh, Ngọc Thanh, Ngọc Nhi mình vẫn gặp mặt chúng nó được vì đều học ở Sài Gòn, khi về Vũng Tàu vẫn có thể gọi nhau đi chơi, còn Hồng Ngân thì ra Hà Nội nên chỉ có thể đợi nó vào ngày Tết. Mong dịch Covid-19 này hết sớm để nhóm Củ Cải có thể họp mặt.",
                    OnDateTime = DateTime.ParseExact("29/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("3")),
                    ReviewerId = Guid.Parse(ToParseGuid("1")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("16")),
                    Status = "Waiting",
                    Title = "Trung thu yêu thương",
                    Content = "Tuổi thơ ai cũng từng rước đèn quanh xóm, phá cỗ mâm bánh kẹo, hoa quả cùng với đám trẻ con cùng trang lứa. Tuổi thơ của mình cũng thế, cũng làm lồng đèn ông sao, rồi rước đèn với lũ bạn và các anh chị trong khu xóm nhỏ, vừa đi vừa ngân nga hát “Tết Trung Thu em rước đèn đi chơi, em rước đèn đi khắp phố phường. Lòng vui sướng với đèn trong tay. Em múa ca trong ánh trăng rằm”. Những ký ức về Tết Trung Thu khiến mình vẫn luôn muốn quay trở về ngày đó nhất là kỷ niệm với nhóm Củ Cải Lộn Xào. Bữa tiệc nào cũng đến lúc tàn, niềm vui nào cũng đến lúc tan nhưng thứ để lại trong lòng chúng ta là những ký ức, kỷ niệm mãi không quên đó. Cho đến bây giờ, mình vẫn luôn muốn quay trở lại ngày đó để cùng cười thật thoải mái với chúng nó, cùng nói về những điều xàm xí, cùng nghĩ về ước mơ tương lai. Hai năm rồi, Trung Thu năm nào mình cũng lục lại những tấm hình kỷ niệm đó để coi lại và vào group chat ỷ ôi vài câu nhớ ngày đó, hỏi Ngân khi nào thì vào lại Vũng Tàu để còn sum vầy. Mình nhớ Củ Cải Lộn Xào nhiều lắm vì chẳng ở đâu mình có được những người bạn như vậy. Huỳnh Anh, Mai Anh, Ngọc Thanh, Ngọc Nhi mình vẫn gặp mặt chúng nó được vì đều học ở Sài Gòn, khi về Vũng Tàu vẫn có thể gọi nhau đi chơi, còn Hồng Ngân thì ra Hà Nội nên chỉ có thể đợi nó vào ngày Tết. Mong dịch Covid-19 này hết sớm để nhóm Củ Cải có thể họp mặt.",
                    OnDateTime = DateTime.ParseExact("29/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("3")),
                    ReviewerId = Guid.Parse(ToParseGuid("3")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// review 4
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("4")),
                    Status = "Waiting",
                    Title = "Sàn đấu tranh hùng biện hấp dẫn tại Đại học FPT",
                    Content = "Đây là một cuộc thi mang đến một sân chơi học thuật dành riêng cho sinh viên Đại Học FPT. Cuộc thi chính là cơ hội cho các bạn sinh viên được cọ xát, tham gia thể hiện khả năng lập luận và tư duy phản biện, rèn luyện tinh thần đồng đội của mình.Cuộc thi đã mở ra nhiều cơ hội tham gia cho bạn sinh viên có niềm yêu thích, đam mê với bộ môn biện luận.Cuộc thi đã giúp cho các bạn sinh viên phá bỏ giới hạn của bản thân vượi qua các vòng của cuộc thi để chứng minh bản thân phá bỏ giới hạn khả năng của minh để trưởng thành, mạnh mẽ và tự tin hơn.",
                    OnDateTime = DateTime.ParseExact("19/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("4")),
                    ReviewerId = Guid.Parse(ToParseGuid("1")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("17")),
                    Status = "Waiting",
                    Title = "Sàn đấu tranh hùng biện hấp dẫn tại Đại học FPT",
                    Content = "Đây là một cuộc thi mang đến một sân chơi học thuật dành riêng cho sinh viên Đại Học FPT. Cuộc thi chính là cơ hội cho các bạn sinh viên được cọ xát, tham gia thể hiện khả năng lập luận và tư duy phản biện, rèn luyện tinh thần đồng đội của mình.Cuộc thi đã mở ra nhiều cơ hội tham gia cho bạn sinh viên có niềm yêu thích, đam mê với bộ môn biện luận.Cuộc thi đã giúp cho các bạn sinh viên phá bỏ giới hạn của bản thân vượi qua các vòng của cuộc thi để chứng minh bản thân phá bỏ giới hạn khả năng của minh để trưởng thành, mạnh mẽ và tự tin hơn.",
                    OnDateTime = DateTime.ParseExact("19/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("4")),
                    ReviewerId = Guid.Parse(ToParseGuid("3")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            ///// review 5
            //try
            //{
            //    context.Reviews.Add(new Review
            //    {
            //        Id = Guid.Parse(ToParseGuid("5")),
            //        Status = "Public",
            //        Title = "Viết một bài viết liên quan đến chủ đề Lễ Hội Mùa Xuân.",
            //        Content = "Sự kiện thường niên Xuân Ấm Áp 2021 đã khép lại vô cùng thành công và đạt được những giá trị mong muốn.Có thể thấy rằng, “Xuân Ấm Áp 2020″ đã diễn ra tốt đẹp và nhận được sự quan tâm, chú ý của tất cả các bạn sinh viên. Hơn thế nữa, nó còn minh chứng được một điều rằng tất cả các bạn trẻ đang cố gắng sẻ chia, cảm thông từ những điều nhỏ bé nhất đến với mọi người xung quanh.Sự kiện đưa đến những món quà tuy nhỏ nhưng đủ sức mạnh để lan tỏa thông điệp yêu thương đến mọi người trong xã hội để tất cả đều có một cái Tết an lành, hạnh phúc và nhiều sức khỏe",
            //        OnDateTime = DateTime.ParseExact("14/02/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        CampaignId = Guid.Parse(ToParseGuid("5")),
            //        ReviewerId = Guid.Parse(ToParseGuid("1")),
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.Reviews.Add(new Review
            //    {
            //        Id = Guid.Parse(ToParseGuid("18")),
            //        Status = "Public",
            //        Title = "Viết một bài viết liên quan đến chủ đề Lễ Hội Mùa Xuân.",
            //        Content = "Sự kiện thường niên Xuân Ấm Áp 2021 đã khép lại vô cùng thành công và đạt được những giá trị mong muốn.Có thể thấy rằng, “Xuân Ấm Áp 2020″ đã diễn ra tốt đẹp và nhận được sự quan tâm, chú ý của tất cả các bạn sinh viên. Hơn thế nữa, nó còn minh chứng được một điều rằng tất cả các bạn trẻ đang cố gắng sẻ chia, cảm thông từ những điều nhỏ bé nhất đến với mọi người xung quanh.Sự kiện đưa đến những món quà tuy nhỏ nhưng đủ sức mạnh để lan tỏa thông điệp yêu thương đến mọi người trong xã hội để tất cả đều có một cái Tết an lành, hạnh phúc và nhiều sức khỏe",
            //        OnDateTime = DateTime.ParseExact("14/02/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        CampaignId = Guid.Parse(ToParseGuid("5")),
            //        ReviewerId = Guid.Parse(ToParseGuid("3")),
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// review 6
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("6")),
                    Status = "Waiting",
                    Title = "Kỉ niệm đáng nhớ khi bước chân vào môi trường đại học",
                    Content = "Lễ chào đón tân sinh viên là một bước ngoặc trong đời mà mỗi sinh viên đều phải trải qua khi bước chân vào môi trường đại học.Đây được xem như một kỷ niệm đáng nhớ trong cuộc đời của mỗi sinh viên.Mỗi trườn có những cách tổ chức và cảm nhận của sinh viên về lễ chào đón là khác nhau.Những đối vối tôi nó là một sử khởi đầu mới cho sự trưởng thành cũng với nhiều cung bậc cảm xúc khác nhau.Lễ chào đón diễn ra một cách hoàng tráng trang nghiêm.Cùng với đó là những lỡi khuyên chân thành từ các thầy cô, những sự kiện và các hoạt động đã để lại nhiều kỉ niệm trong lòng tôi.",
                    OnDateTime = DateTime.ParseExact("01/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("6")),
                    ReviewerId = Guid.Parse(ToParseGuid("1")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("19")),
                    Status = "Waiting",
                    Title = "Kỉ niệm đáng nhớ khi bước chân vào môi trường đại học",
                    Content = "Lễ chào đón tân sinh viên là một bước ngoặc trong đời mà mỗi sinh viên đều phải trải qua khi bước chân vào môi trường đại học.Đây được xem như một kỷ niệm đáng nhớ trong cuộc đời của mỗi sinh viên.Mỗi trườn có những cách tổ chức và cảm nhận của sinh viên về lễ chào đón là khác nhau.Những đối vối tôi nó là một sử khởi đầu mới cho sự trưởng thành cũng với nhiều cung bậc cảm xúc khác nhau.Lễ chào đón diễn ra một cách hoàng tráng trang nghiêm.Cùng với đó là những lỡi khuyên chân thành từ các thầy cô, những sự kiện và các hoạt động đã để lại nhiều kỉ niệm trong lòng tôi.",
                    OnDateTime = DateTime.ParseExact("01/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("6")),
                    ReviewerId = Guid.Parse(ToParseGuid("3")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            ///// review 7
            //try
            //{
            //    context.Reviews.Add(new Review
            //    {
            //        Id = Guid.Parse(ToParseGuid("7")),
            //        Status = "Public",
            //        Title = "Cuộc thi codewar cho sinh viên FPT thực tập ở FPT Software",
            //        Content = "Cuộc thi Codeware được tổ chức dành cho các bạn sinh viên thực tập tại FPT Software.Đầy là một sân chơi lớn góp mặt đông đảo các bạn sinh viên từ nhiều trường đại học khác nhau.Sinh viên có cơ hội được thể hiện tài năng, giao lưu kết bạn và trao đổi kinh nghiệm của bản thân.Đây là cuộc thi khá hữu ích cho các bạn sinh viên tạo thêm động lực,niềm đam mê hết mình với lập trình, với công nghệ.",
            //        OnDateTime = DateTime.ParseExact("25/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        CampaignId = Guid.Parse(ToParseGuid("7")),
            //        ReviewerId = Guid.Parse(ToParseGuid("1")),
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            ///// review 8
            //try
            //{
            //    context.Reviews.Add(new Review
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        Status = "Public",
            //        Title = "Mùa hè xanh' FSB về vùng biển nghèo",
            //        Content = "Đây là hoạt động do trường DH FPT tổ chức chiến dịch tình nguyện Mùa hè xanh - La Gi.Các sinh viên tình nguyện cùng các thành viên phòng Công tác sinh viên đã ghi dấu ấn đậm nét cho người dân La Gi (Bình Thuận ) bằng nhiều hoạt động thiết thực.Với hoạt động thiện nguyện xung kích, công việc tưởng nhẹ nhàng nhưng lại không hề đơn giản.Tất cả thành viên trong đội thiện nguyện gặp rất nhiều khó khăn nhưng đã hoàn thành tốt công việc.Tham gia chương trình, chúng em được trải nghiệm cuộc sống tuy khó khăn, thiếu thốn nhưng vô cùng ý nghĩa khi được tận tay giúp đỡ những gia đình nghèo khó và góp sức xây dựng nông thôn mới ở La Gi.",
            //        OnDateTime = DateTime.ParseExact("25/06/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            //        CampaignId = Guid.Parse(ToParseGuid("8")),
            //        ReviewerId = Guid.Parse(ToParseGuid("1")),
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// review 9
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("9")),
                    Status = "Waiting",
                    Title = "Đại học Bách Khoa trong tim tôi",
                    Content = "Nếu bạn thực sự đam mê công nghệ và hiểu rõ bản chất khoa học thì đây thực sự là ngôi trường đáng để học nhất. Nhiều người cứ suốt ngày than thở sao BK giờ bla bla nhưng đối với mình, đây vẫn là ngôi trường đúng với sự lựa chọn của mình khi thi đại học. Nếu bạn đã từng trực tiếp tiếp xúc và làm việc với các thầy cô ở đây thì hẳn bạn sẽ rất chủ động tìm tòi kiến thức và chịu khó học hỏi.",
                    OnDateTime = DateTime.ParseExact("21/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("9")),
                    ReviewerId = Guid.Parse(ToParseGuid("2")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// review 10
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("10")),
                    Status = "Waiting",
                    Title = "Tình nguyện mùa hè xanh",
                    Content = "Đến hẹn lại lên, khi cái nắng mùa hè chói chang trên từng sắc lá, khi những kỳ thi căng thẳng tạm gác qua một bên cũng chính là lúc các bạn sinh viên tạm biệt bàn ghế nhà trường, khoác lên mình chiếc áo màu xanh tình nguyện, hăm hở đến vùng đất mới để cống hiến sức trẻ, góp một phần sức mình dựng xây quê hương đất nước. Có nhiều lý do để các bạn học sinh, sinh viên tìm đến với Mùa hè xanh. Đó có thể là niềm vui giúp đỡ những người có hoàn cảnh khó khăn và được hiểu biết hơn về những giá trị văn hóa dân tộc khắp mọi miền của Tổ quốc hay mong muốn được trưởng thành qua những chuyến đi. Nhưng trên tất cả, mục tiêu chung của những tình nguyện viên là đem sức trẻ, lòng quyết tâm và tinh thần tình nguyện đến giúp đồng bào vùng sâu vùng xa.",
                    OnDateTime = DateTime.ParseExact("10/08/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("10")),
                    ReviewerId = Guid.Parse(ToParseGuid("2")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// review 12
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("12")),
                    Status = "Waiting",
                    Title = "Tình Nguyện Chống Dịch",
                    Content = "Đến hẹn lại lên, khi cái nắng mùa hè chói chang trên từng sắc lá, khi những kỳ thi căng thẳng tạm gác qua một bên cũng chính là lúc các bạn sinh viên tạm biệt bàn ghế nhà trường, khoác lên mình chiếc áo màu xanh tình nguyện, hăm hở đến vùng đất mới để cống hiến sức trẻ, góp một phần sức mình dựng xây quê hương đất nước. Có nhiều lý do để các bạn học sinh, sinh viên tìm đến với Mùa hè xanh. Đó có thể là niềm vui giúp đỡ những người có hoàn cảnh khó khăn và được hiểu biết hơn về những giá trị văn hóa dân tộc khắp mọi miền của Tổ quốc hay mong muốn được trưởng thành qua những chuyến đi. Nhưng trên tất cả, mục tiêu chung của những tình nguyện viên là đem sức trẻ, lòng quyết tâm và tinh thần tình nguyện đến giúp đồng bào vùng sâu vùng xa.",
                    OnDateTime = DateTime.ParseExact("19/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("12")),
                    ReviewerId = Guid.Parse(ToParseGuid("2")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// review 13
            try
            {
                context.Reviews.Add(new Review
                {
                    Id = Guid.Parse(ToParseGuid("13")),
                    Status = "Waiting",
                    Title = "Tết Trung Thu",
                    Content = "Tết trung thu hay còn được biết đến là tết thiếu nhi, đây là một sự kiện vô cùng hoành tráng chỉ sau tết nguyên đán. Lễ được tính theo âm lịch, ngày rằm tháng 8. Trung thu là dịp tuyệt vời để cùng trải lòng về những kỉ niệm, những khó khăn trong suốt một năm qua.Sự kiện tổ chức định kỳ hàng năm, nhằm mang đến không khí đoàn viên ấm cúng, vui tươi mỗi dịp Trung Thu cho thiếu nhi ở địa bàn khó khăn",
                    OnDateTime = DateTime.ParseExact("15/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CampaignId = Guid.Parse(ToParseGuid("13")),
                    ReviewerId = Guid.Parse(ToParseGuid("2")),
                });
                context.SaveChanges();
            }
            catch
            {

            }
            return Ok();
        }

        [HttpGet("InitDataPictureForReview")]
        public ActionResult InitDataPictureForReview()
        {
            // Add PictureForReview
            // bài 1
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    ReviewId = Guid.Parse(ToParseGuid("1")),
                    Picture = "https://i.ytimg.com/vi/01C5TDIrD2o/maxresdefault.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("14")),
                    ReviewId = Guid.Parse(ToParseGuid("1")),
                    Picture = "https://hcmuni.fpt.edu.vn/Data/Sites/1/Banner/dai-hoc-fpt-tp-hcm-1.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 2
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    ReviewId = Guid.Parse(ToParseGuid("2")),
                    Picture = "https://www.giasukinhte.com/wp-content/uploads/2018/02/thang-hoc-quan-su-1.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("15")),
                    ReviewId = Guid.Parse(ToParseGuid("2")),
                    Picture = "https://th.bing.com/th/id/R.3c0be1ada46997f6408319accf13886c?rik=I486OoO49%2byteA&riu=http%3a%2f%2fthpt.fpt.edu.vn%2fwp-content%2fuploads%2fTHPT_FPT_Hoc-quan-su-1024x768.jpg&ehk=jUuoyfweG4rtaNO04cOoRt7x6Ysp2SSLQYJClE8kfm0%3d&risl=&pid=ImgRaw&r=0",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 3
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("3")),
                    ReviewId = Guid.Parse(ToParseGuid("3")),
                    Picture = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/243031844_399490975081712_7284694123980505278_n.png?_nc_cat=103&_nc_rgb565=1&ccb=1-5&_nc_sid=0debeb&_nc_ohc=KMzadaNfcUEAX9kQUPO&_nc_oc=AQl_wrfGZ872OExUniOQ7rAivelYGyBSl1IlpH4bv_LHXzfOj4rl-D-ipR8JBsSlGpX-xNjxFE6ndhkYenkfHNQH&_nc_ht=scontent.fsgn5-7.fna&oh=e57eb786fab2e12fc190ffac5200524e&oe=61786339",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("16")),
                    ReviewId = Guid.Parse(ToParseGuid("3")),
                    Picture = "https://hcmuni.fpt.edu.vn/Data/Sites/1/media/zz2020file/trungthuyeuthuong/dhfpttrungthuyeuthuong3.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("17")),
                    ReviewId = Guid.Parse(ToParseGuid("3")),
                    Picture = "https://hcmuni.fpt.edu.vn/Data/Sites/1/media/zz2020file/trungthuyeuthuong/dhfpt12345.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 4
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("4")),
                    ReviewId = Guid.Parse(ToParseGuid("4")),
                    Picture = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t1.6435-9/242338128_1980912658731831_7490468617578363594_n.jpg?_nc_cat=104&ccb=1-5&_nc_sid=730e14&_nc_ohc=8KgZDagF_UEAX8h0tXX&_nc_ht=scontent.fsgn2-5.fna&oh=0203cf2b27604b7b18a17bfea31e6153&oe=618999D5",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //// bài 5
            //try
            //{
            //    context.PictureForReviews.Add(new PictureForReview
            //    {
            //        Id = Guid.Parse(ToParseGuid("5")),
            //        ReviewId = Guid.Parse(ToParseGuid("5")),
            //        Picture = "https://daihoc.fpt.edu.vn/media/2020/01/IMG_5271-910x607.jpg",
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            // bài 6
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("6")),
                    ReviewId = Guid.Parse(ToParseGuid("6")),
                    Picture = "https://cantho.fpt.edu.vn/Data/Sites/1/media/092020/s%E1%BB%B1-ki%E1%BB%87n/119457487_3464740970230495_4458676711979227713_o.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            //// bài 7
            //try
            //{
            //    context.PictureForReviews.Add(new PictureForReview
            //    {
            //        Id = Guid.Parse(ToParseGuid("7")),
            //        ReviewId = Guid.Parse(ToParseGuid("7")),
            //        Picture = "https://scontent.fsgn2-6.fna.fbcdn.net/v/t1.6435-9/241380248_4075436759252463_4866786731961157608_n.jpg?_nc_cat=110&ccb=1-5&_nc_sid=825194&_nc_ohc=eLc_KTMpmggAX8XFVAn&_nc_ht=scontent.fsgn2-6.fna&oh=98aa7cda9ec9ef856c7abc8578573722&oe=618A9FCF",
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //// bài 8
            //try
            //{
            //    context.PictureForReviews.Add(new PictureForReview
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        ReviewId = Guid.Parse(ToParseGuid("8")),
            //        Picture = "https://i.chungta.vn/2014/09/18/anhthiennguyen-922160-1413030758.jpg",
            //        //Status = "true"
            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            // bài 9
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("9")),
                    ReviewId = Guid.Parse(ToParseGuid("9")),
                    Picture = "https://lh5.googleusercontent.com/iw1LrpIRx7eXMfRpzyLOgxsEocfO85zG6YVtlwcxs6AhsIm5EZpw0Bt9G7vxtdrqU1SCqkt16SudSRb4f_7VQbaHBzUwb7ijqzlPGzBEuOI51hnDzk-mR6sRm2cf4hi7UFHNlXpL",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 10
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("10")),
                    ReviewId = Guid.Parse(ToParseGuid("10")),
                    Picture = "https://th.bing.com/th/id/OIP.ppVFyt9wh9XE4DrGtizyJgHaFj?pid=ImgDet&rs=1",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 12
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("12")),
                    ReviewId = Guid.Parse(ToParseGuid("12")),
                    Picture = "https://www.bing.com/images/search?view=detailV2&ccid=mWn8zTDI&id=CE897CED3932C1DB206BA5FFD05A503AFDA1C4EE&thid=OIF.Rae9MQgMGsEmSAct%2fbJDkA&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.9969fccd30c8897d389bd07a840c4ec0%3frik%3d%26riu%3dhttp%253a%252f%252fct16.com.vn%252fwp-content%252fuploads%252f2021%252f08%252fz2721214129140_0e60f27bfdbac15ed6454de6672dae9e_wdst.jpg%26ehk%3dWTezxXoA1Nvtl0MSPfX%252ftrLHPLLFo%252blxRkDmw5BtJ04%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=970&expw=1567&q=T%c3%acnh+Nguy%e1%bb%87n+Ch%e1%bb%91ng+D%e1%bb%8bch&simid=431521954575&FORM=IRPRST&ck=45A7BD31080C1AC12648072DFDB24390&selectedIndex=6",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 13
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("13")),
                    ReviewId = Guid.Parse(ToParseGuid("13")),
                    Picture = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t1.6435-9/p843x403/242336314_1517546761944864_4536750263173847509_n.jpg?_nc_cat=104&ccb=1-5&_nc_sid=730e14&_nc_ohc=gYmU3TNjAhEAX91zUmp&_nc_ht=scontent.fsgn2-5.fna&oh=79c0fb244c862f6e5a16b3508c168063&oe=618B05B8",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }

            //bai 1 hà
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("18")),
                    ReviewId = Guid.Parse(ToParseGuid("14")),
                    Picture = "https://i.ytimg.com/vi/01C5TDIrD2o/maxresdefault.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("19")),
                    ReviewId = Guid.Parse(ToParseGuid("14")),
                    Picture = "https://hcmuni.fpt.edu.vn/Data/Sites/1/Banner/dai-hoc-fpt-tp-hcm-1.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài 2 hà
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("20")),
                    ReviewId = Guid.Parse(ToParseGuid("15")),
                    Picture = "https://www.giasukinhte.com/wp-content/uploads/2018/02/thang-hoc-quan-su-1.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("22")),
                    ReviewId = Guid.Parse(ToParseGuid("15")),
                    Picture = "https://th.bing.com/th/id/R.3c0be1ada46997f6408319accf13886c?rik=I486OoO49%2byteA&riu=http%3a%2f%2fthpt.fpt.edu.vn%2fwp-content%2fuploads%2fTHPT_FPT_Hoc-quan-su-1024x768.jpg&ehk=jUuoyfweG4rtaNO04cOoRt7x6Ysp2SSLQYJClE8kfm0%3d&risl=&pid=ImgRaw&r=0",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bai 3 ha
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("23")),
                    ReviewId = Guid.Parse(ToParseGuid("16")),
                    Picture = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/243031844_399490975081712_7284694123980505278_n.png?_nc_cat=103&_nc_rgb565=1&ccb=1-5&_nc_sid=0debeb&_nc_ohc=KMzadaNfcUEAX9kQUPO&_nc_oc=AQl_wrfGZ872OExUniOQ7rAivelYGyBSl1IlpH4bv_LHXzfOj4rl-D-ipR8JBsSlGpX-xNjxFE6ndhkYenkfHNQH&_nc_ht=scontent.fsgn5-7.fna&oh=e57eb786fab2e12fc190ffac5200524e&oe=61786339",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("24")),
                    ReviewId = Guid.Parse(ToParseGuid("16")),
                    Picture = "https://hcmuni.fpt.edu.vn/Data/Sites/1/media/zz2020file/trungthuyeuthuong/dhfpttrungthuyeuthuong3.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("25")),
                    ReviewId = Guid.Parse(ToParseGuid("16")),
                    Picture = "https://hcmuni.fpt.edu.vn/Data/Sites/1/media/zz2020file/trungthuyeuthuong/dhfpt12345.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bai 4 ha
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("26")),
                    ReviewId = Guid.Parse(ToParseGuid("17")),
                    Picture = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t1.6435-9/242338128_1980912658731831_7490468617578363594_n.jpg?_nc_cat=104&ccb=1-5&_nc_sid=730e14&_nc_ohc=8KgZDagF_UEAX8h0tXX&_nc_ht=scontent.fsgn2-5.fna&oh=0203cf2b27604b7b18a17bfea31e6153&oe=618999D5",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bai 6 ha
            try
            {
                context.PictureForReviews.Add(new PictureForReview
                {
                    Id = Guid.Parse(ToParseGuid("27")),
                    ReviewId = Guid.Parse(ToParseGuid("19")),
                    Picture = "https://cantho.fpt.edu.vn/Data/Sites/1/media/092020/s%E1%BB%B1-ki%E1%BB%87n/119457487_3464740970230495_4458676711979227713_o.jpg",
                    //Status = "true"
                });
                context.SaveChanges();
            }
            catch
            {

            }

            return Ok();
        }

        [HttpGet("InitDataReviewCriterion")]
        public ActionResult InitDataReviewCriterion()
        {
            //Add ReviewCriterion
            /// Bai review 1
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("1")),
                    ReviewId = Guid.Parse(ToParseGuid("1")),
                    CriterionId = Guid.Parse(ToParseGuid("1")),
                    Rating = 4,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("2")),
                    ReviewId = Guid.Parse(ToParseGuid("1")),
                    CriterionId = Guid.Parse(ToParseGuid("2")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("3")),
            //        ReviewId = Guid.Parse(ToParseGuid("1")),
            //        CriterionId = Guid.Parse(ToParseGuid("3")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("4")),
            //        ReviewId = Guid.Parse(ToParseGuid("1")),
            //        CriterionId = Guid.Parse(ToParseGuid("4")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// Bài review 2
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("5")),
                    ReviewId = Guid.Parse(ToParseGuid("2")),
                    CriterionId = Guid.Parse(ToParseGuid("5")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("6")),
            //        ReviewId = Guid.Parse(ToParseGuid("2")),
            //        CriterionId = Guid.Parse(ToParseGuid("6")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("7")),
                    ReviewId = Guid.Parse(ToParseGuid("2")),
                    CriterionId = Guid.Parse(ToParseGuid("7")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("8")),
            //        ReviewId = Guid.Parse(ToParseGuid("2")),
            //        CriterionId = Guid.Parse(ToParseGuid("8")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            /// Bài review 3
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("9")),
                    ReviewId = Guid.Parse(ToParseGuid("3")),
                    CriterionId = Guid.Parse(ToParseGuid("9")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("10")),
                    ReviewId = Guid.Parse(ToParseGuid("3")),
                    CriterionId = Guid.Parse(ToParseGuid("10")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("12")),
                    ReviewId = Guid.Parse(ToParseGuid("3")),
                    CriterionId = Guid.Parse(ToParseGuid("12")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            /// bài review 4
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("13")),
                    ReviewId = Guid.Parse(ToParseGuid("4")),
                    CriterionId = Guid.Parse(ToParseGuid("13")),
                    Rating = 4,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("14")),
                    ReviewId = Guid.Parse(ToParseGuid("4")),
                    CriterionId = Guid.Parse(ToParseGuid("14")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("15")),
                    ReviewId = Guid.Parse(ToParseGuid("4")),
                    CriterionId = Guid.Parse(ToParseGuid("15")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //// bài review 5
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("16")),
            //        ReviewId = Guid.Parse(ToParseGuid("5")),
            //        CriterionId = Guid.Parse(ToParseGuid("16")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("17")),
            //        ReviewId = Guid.Parse(ToParseGuid("5")),
            //        CriterionId = Guid.Parse(ToParseGuid("17")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("18")),
            //        ReviewId = Guid.Parse(ToParseGuid("5")),
            //        CriterionId = Guid.Parse(ToParseGuid("18")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            // bài review 6
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("19")),
            //        ReviewId = Guid.Parse(ToParseGuid("6")),
            //        CriterionId = Guid.Parse(ToParseGuid("19")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("20")),
                    ReviewId = Guid.Parse(ToParseGuid("6")),
                    CriterionId = Guid.Parse(ToParseGuid("20")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("22")),
                    ReviewId = Guid.Parse(ToParseGuid("6")),
                    CriterionId = Guid.Parse(ToParseGuid("22")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("23")),
                    ReviewId = Guid.Parse(ToParseGuid("6")),
                    CriterionId = Guid.Parse(ToParseGuid("23")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            //// bài review 7
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("24")),
            //        ReviewId = Guid.Parse(ToParseGuid("7")),
            //        CriterionId = Guid.Parse(ToParseGuid("24")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("25")),
            //        ReviewId = Guid.Parse(ToParseGuid("7")),
            //        CriterionId = Guid.Parse(ToParseGuid("25")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("26")),
            //        ReviewId = Guid.Parse(ToParseGuid("7")),
            //        CriterionId = Guid.Parse(ToParseGuid("26")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("27")),
            //        ReviewId = Guid.Parse(ToParseGuid("7")),
            //        CriterionId = Guid.Parse(ToParseGuid("27")),
            //        Rating = 4,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //// bài review 8
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("28")),
            //        ReviewId = Guid.Parse(ToParseGuid("8")),
            //        CriterionId = Guid.Parse(ToParseGuid("28")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("29")),
            //        ReviewId = Guid.Parse(ToParseGuid("8")),
            //        CriterionId = Guid.Parse(ToParseGuid("29")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            //try
            //{
            //    context.ReviewCriteria.Add(new ReviewCriterion
            //    {
            //        Id = Guid.Parse(ToParseGuid("30")),
            //        ReviewId = Guid.Parse(ToParseGuid("8")),
            //        CriterionId = Guid.Parse(ToParseGuid("30")),
            //        Rating = 5,

            //    });
            //    context.SaveChanges();
            //}
            //catch
            //{

            //}
            // bài review 9
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("32")),
                    ReviewId = Guid.Parse(ToParseGuid("9")),
                    CriterionId = Guid.Parse(ToParseGuid("32")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("33")),
                    ReviewId = Guid.Parse(ToParseGuid("9")),
                    CriterionId = Guid.Parse(ToParseGuid("33")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("34")),
                    ReviewId = Guid.Parse(ToParseGuid("9")),
                    CriterionId = Guid.Parse(ToParseGuid("34")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("35")),
                    ReviewId = Guid.Parse(ToParseGuid("9")),
                    CriterionId = Guid.Parse(ToParseGuid("35")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 10
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("36")),
                    ReviewId = Guid.Parse(ToParseGuid("10")),
                    CriterionId = Guid.Parse(ToParseGuid("36")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("37")),
                    ReviewId = Guid.Parse(ToParseGuid("10")),
                    CriterionId = Guid.Parse(ToParseGuid("37")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("38")),
                    ReviewId = Guid.Parse(ToParseGuid("10")),
                    CriterionId = Guid.Parse(ToParseGuid("38")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 12
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("39")),
                    ReviewId = Guid.Parse(ToParseGuid("12")),
                    CriterionId = Guid.Parse(ToParseGuid("39")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("40")),
                    ReviewId = Guid.Parse(ToParseGuid("12")),
                    CriterionId = Guid.Parse(ToParseGuid("40")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("42")),
                    ReviewId = Guid.Parse(ToParseGuid("12")),
                    CriterionId = Guid.Parse(ToParseGuid("42")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 13
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("43")),
                    ReviewId = Guid.Parse(ToParseGuid("13")),
                    CriterionId = Guid.Parse(ToParseGuid("43")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("44")),
                    ReviewId = Guid.Parse(ToParseGuid("13")),
                    CriterionId = Guid.Parse(ToParseGuid("44")),
                    Rating = 4,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("45")),
                    ReviewId = Guid.Parse(ToParseGuid("13")),
                    CriterionId = Guid.Parse(ToParseGuid("45")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }

            // bài reivew 14
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("46")),
                    ReviewId = Guid.Parse(ToParseGuid("14")),
                    CriterionId = Guid.Parse(ToParseGuid("1")),
                    Rating = 4,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("47")),
                    ReviewId = Guid.Parse(ToParseGuid("14")),
                    CriterionId = Guid.Parse(ToParseGuid("2")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 15
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("48")),
                    ReviewId = Guid.Parse(ToParseGuid("15")),
                    CriterionId = Guid.Parse(ToParseGuid("5")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("49")),
                    ReviewId = Guid.Parse(ToParseGuid("15")),
                    CriterionId = Guid.Parse(ToParseGuid("7")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 16
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("50")),
                    ReviewId = Guid.Parse(ToParseGuid("16")),
                    CriterionId = Guid.Parse(ToParseGuid("9")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("52")),
                    ReviewId = Guid.Parse(ToParseGuid("16")),
                    CriterionId = Guid.Parse(ToParseGuid("10")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("53")),
                    ReviewId = Guid.Parse(ToParseGuid("16")),
                    CriterionId = Guid.Parse(ToParseGuid("12")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 17
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("54")),
                    ReviewId = Guid.Parse(ToParseGuid("17")),
                    CriterionId = Guid.Parse(ToParseGuid("13")),
                    Rating = 4,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("55")),
                    ReviewId = Guid.Parse(ToParseGuid("17")),
                    CriterionId = Guid.Parse(ToParseGuid("14")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("56")),
                    ReviewId = Guid.Parse(ToParseGuid("17")),
                    CriterionId = Guid.Parse(ToParseGuid("15")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            // bài review 19
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("57")),
                    ReviewId = Guid.Parse(ToParseGuid("19")),
                    CriterionId = Guid.Parse(ToParseGuid("20")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("58")),
                    ReviewId = Guid.Parse(ToParseGuid("19")),
                    CriterionId = Guid.Parse(ToParseGuid("22")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            try
            {
                context.ReviewCriteria.Add(new ReviewCriterion
                {
                    Id = Guid.Parse(ToParseGuid("59")),
                    ReviewId = Guid.Parse(ToParseGuid("19")),
                    CriterionId = Guid.Parse(ToParseGuid("23")),
                    Rating = 5,

                });
                context.SaveChanges();
            }
            catch
            {

            }
            return Ok();
        }
    }
}