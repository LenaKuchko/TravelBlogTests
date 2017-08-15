using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TravelBlog.Models.Repositories
{
    public class EFLocationRepository : ILocationRepository
    {
        TravelBlogContext db = new TravelBlogContext();  
        
        public IQueryable<Location> Locations { get { return db.Locations; } }

        public Location Save(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return location;
        }

        public Location Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return location;
        }

        public void Remove(Location location)
        {
            db.Remove(location);
            db.SaveChanges();
        }
    }
}
