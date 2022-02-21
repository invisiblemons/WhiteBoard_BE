using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.Data.Model
{
    public class UnpublicReviewRequest
    {
        [Required]
        public String Message { get; set; }
    }
}
