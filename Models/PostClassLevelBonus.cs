using System.Security.Claims;
using System;
using System.Collections.Generic;

namespace tftwebapinew.Models
{
    public class PostClassLevelBonus
    {
        public int ClassId { get; set; }

        public int Level { get; set; }

        public int? CharacterCount { get; set; }

        public string? BonusEffect { get; set; }

        public virtual PostClass Class { get; set; } = null!;
    }
}

