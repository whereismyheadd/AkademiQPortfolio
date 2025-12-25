using System;
using System.Collections.Generic;

namespace AkademiQPortfolio.Data
{
    public partial class Skilltable
    {
        public int SkillId { get; set; }
        public string? Title { get; set; }
        public byte? Levels { get; set; }
        public string? Test { get; set; }
    }
}


//bizim ilk başta skill diye bir nesne üretiyoruz --->skillTable

//Abdullah 20 test

//skill = skillId,title(seda),level(20),test