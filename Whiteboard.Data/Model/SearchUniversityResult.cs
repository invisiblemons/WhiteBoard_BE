using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whiteboard.Data.Model
{
    public class SearchUniversityResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalRow { get; set; }
        public IEnumerable<UniversityDetail> Universitys { get; set; }

        [JsonConstructor]
        public SearchUniversityResult()
        {
        }
    }
}
