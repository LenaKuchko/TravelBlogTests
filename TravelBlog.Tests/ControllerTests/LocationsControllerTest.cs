using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Controllers;
using Xunit;
using TravelBlog.Models;
using Moq;
using TravelBlog.Models.Repositories;

namespace TravelBlog.Tests.ControllerTests
{
    public class LocationsControllerTest
    {
        Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Locations).Returns(new Location[]
                {
                    new Location { LocationId = 1, Name = "Kyiv" },
                    new Location { LocationId = 2, Name ="Poltava" }
                }.AsQueryable());
        }
        //without mock
        //[Fact]
        //public void Post_MethodAddsLocation_Test()
        //{
        //    LocationsController controller = new LocationsController();
        //    Location testLocation = new Location();
        //    testLocation.Name = "test location";

        //    controller.Create(testLocation);
        //    ViewResult indexView = new LocationsController().Index() as ViewResult;
        //    var collection = indexView.ViewData.Model as IEnumerable<Location>;

        //    Assert.Contains<Location>(testLocation, collection);


        //}
        //without mock
        //[Fact]
        //public void Get_ModelListLocationsIndex_Test()
        //{
        //    //Arrange
        //    ViewResult indexView = new LocationsController().Index() as ViewResult;

        //    //Act
        //    var result = indexView.ViewData.Model;

        //    //Assert
        //    Assert.IsType<List<Location>>(result);
        //}


        [Fact]
        public void Mock_GetViewResultIndex_Test() //Confirms route returns view
        {
            //Arrange
            DbSetup();
            LocationsController controller = new LocationsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_IndexListOfLocations_Test() //Confirms model as list of Locations
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new LocationsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsType<List<Location>>(result);
        }

        [Fact]
        public void Mock_ConfirmEntry_Test() //Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            LocationsController controller = new LocationsController(mock.Object);
            Location testLocation = new Location();
            testLocation.Name = "Kyiv";
            testLocation.LocationId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Location>;

            // Assert
            Assert.Contains<Location>(testLocation, collection);
        }
    }
}
