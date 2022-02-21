using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class PictureForReview
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }

        public virtual Review Review { get; set; }
    }
}
