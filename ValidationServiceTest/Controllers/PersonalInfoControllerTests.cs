using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using WebApp.Contracts;
using WebApp.Controllers;
using WebApp.Models;
using Xunit;

namespace ValidationServiceTest.Controllers
{
    public class PersonalInfoControllerTests
    {
        private readonly Mock<IPersonalInfoRepo> _mock;
        private readonly PersonalInfoController _controller;

        public PersonalInfoControllerTests()
        {
            _mock = new Mock<IPersonalInfoRepo>();
            _controller = new PersonalInfoController(_mock.Object);

        }


        [Fact]
        public void Index_ActionReturnsViewResult()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ActionReturnsCountOfPeople()
        {
            _mock.Setup(x => x.GetAll())
                .Returns(new List<Person>() { new Person(), new Person() });

            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var people = Assert.IsType<List<Person>>(viewResult.Model);
            Assert.Equal(2, people.Count);
        }

        [Fact]
        public void Create_ActionReturnsViewResult()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_InvalidModelState_ReturnsViewResult()
        {
            _controller.ModelState.AddModelError("Surname", "Surname is required");

            var person = new Person { Name = "David", Age = 29 };

            var result = _controller.Create(person);

            var viewResult = Assert.IsType<ViewResult>(result);
            var tempPerson = Assert.IsType<Person>(viewResult.Model);

            Assert.Equal(person.Name, tempPerson.Name);
            Assert.Equal(person.Age, tempPerson.Age);
        }


        [Fact]
        public void Create_InvalidModelState_NeverCreatesPerson()
        {
            _controller.ModelState.AddModelError("Surname", "Surname is required");

            var person = new Person { Name = "David", Age = 29 };

            _controller.Create(person);

            _mock.Verify(x => x.CreatePerson(It.IsAny<Person>()), Times.Never);
        }

        [Fact]
        public void Create_ValidModelState_CreatesPerson()
        {
            

            var person = new Person { Name = "David", Surname = "Anderson", Age = 29 };

            _controller.Create(person);

            _mock.Verify(x => x.CreatePerson(It.IsAny<Person>()), Times.Once);
        }

        [Fact]
        public void Create_ModelStateValid_CreatesPerson_2ndWay()
        {
            Person? person = null;

            _mock.Setup(r => r.CreatePerson(It.IsAny<Person>()))
                .Callback<Person>(x => person = x);

            var tempPerson = new Person
            {
                Name = "Victor",
                Surname = "Hugo",
                Age = 32
            };

            _controller.Create(tempPerson);
            _mock.Verify(x => x.CreatePerson(It.IsAny<Person>()), Times.Once);

            Assert.Equal(person.Name, tempPerson.Name);
            Assert.Equal(person.Surname, tempPerson.Surname);
            Assert.Equal(person.Age, tempPerson.Age);
        }

        [Fact]
        public void Create_ActionRedirectsToIndex_Action()
        {
            var person = new Person
            {
                Name = "David",
                Surname = "Anderson",
                Age = 45,
            };

            var result = _controller.Create(person);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
