using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{ 
    [Table("Locations")]
    public class Location
    {
        public Location()
        {
        }

        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

        public override bool Equals(System.Object otherLocation)
        {
            if (!(otherLocation is Location))
            {
                return false;
            }
            else
            {
                Location location = (Location)otherLocation;
                return this.LocationId.Equals(location.LocationId);
            }
        }

        public override int GetHashCode()
        {
            return this.LocationId.GetHashCode();
        }
    }
}


