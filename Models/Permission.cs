using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karbantarto.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
