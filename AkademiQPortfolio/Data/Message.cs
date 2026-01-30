using System;
using System.Collections.Generic;

namespace AkademiQPortfolio.Data
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string? NameSurname { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? MessageContent { get; set; }
        public DateTime? SendDate { get; set; }
        public bool? IsRead { get; set; }
    }
}
