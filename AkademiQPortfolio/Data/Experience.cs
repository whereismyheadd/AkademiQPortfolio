using System;
using System.Collections.Generic;

namespace AkademiQPortfolio.Data
{
    public partial class Experience
    {
        public int ExperienceId { get; set; }
        public string? Title { get; set; }
        public string? ExperienceName { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public string? Description { get; set; }
    }
}
