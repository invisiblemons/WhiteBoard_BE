using System;
using System.Collections.Generic;

#nullable disable

namespace Whiteboard.Data.Entities
{
    public partial class ReviewCriterion
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid CriterionId { get; set; }
        public int Rating { get; set; }
        public string Status { get; set; }

        public virtual Criterion Criterion { get; set; }
        public virtual Review Review { get; set; }
    }
}
