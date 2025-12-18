using System;
using System.Collections.Generic;

namespace AkademiQPortfolio.Data
{
    public partial class Education
    {
        public int EducationId { get; set; }
        public string? Name { get; set; }
        public string? Section { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
    }
}
