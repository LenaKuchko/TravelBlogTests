using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using TravelBlog.Models.Repositories;

namespace TravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationRepository locationRepo;

        public LocationsController(ILocationRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.locationRepo = new EFLocationRepository();
            }
            else
            {
                this.locationRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            return View(locationRepo.Locations.OrderBy(location => location.Name).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisLocation = locationRepo.Locations.Include(location => location.Experiences).ThenInclude(experiences => experiences.People).FirstOrDefault(location => location.LocationId == id);
            //var thisExperience = from p in db.People
            //                    join e in db.Experiences on p.ExperienceId equals e.ExperienceId
            //                    join l in db.Locations on e.LocationId equals l.LocationId
            //                    where l.LocationId == id
            //                    select new { p };
            Debug.WriteLine(thisLocation);
            return View(thisLocation);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            locationRepo.Save(location);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }
        [HttpPost]
        public IActionResult Edit(Location location)
        {
            locationRepo.Edit(location);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            locationRepo.Remove(thisLocation);
            return RedirectToAction("Index");
        }
    }
}
