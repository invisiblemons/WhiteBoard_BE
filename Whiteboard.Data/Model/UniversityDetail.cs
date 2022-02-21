using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Model
{
    public class MajorForUniversityDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [JsonConstructor]
        public MajorForUniversityDetail()
        {
        }

        public MajorForUniversityDetail(Major major)
        {
            Id = major.Id;
            Name = major.Name;
            Code = major.Code;
        }
    }

    public class CampusForUniversityDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public IEnumerable<MajorForUniversityDetail> Majors { get; set; }

        [JsonConstructor]
        public CampusForUniversityDetail()
        {
        }

        public CampusForUniversityDetail(Campus campus)
        {
            Id = campus.Id;
            Name = campus.Name;
            Address = campus.Address;
            PhoneNumber = campus.PhoneNumber;
            Email = campus.Email;
            Image = campus.Image;
            Majors = campus.Majors.Where(m => m.Status != MyConstant.Deleted).Select(major => new MajorForUniversityDetail(major));
        }
    }

    public class UniversityDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }//HCI
        public IEnumerable<CampusForUniversityDetail> Campus { get; set; }

        [JsonConstructor]
        public UniversityDetail()
        {
        }

        public UniversityDetail(University university)
        {
            Id = university.Id;
            Name = university.Name;
            PhoneNumber = university.PhoneNumber;
            Email = university.Email;
            Image = university.Image;
            Link = university.Link;
            Status = "Created";//HCI
            Campus = university.Campuses.Where(c => c.Status != MyConstant.Deleted).Select(campus => new CampusForUniversityDetail(campus));
        }
    }
}
