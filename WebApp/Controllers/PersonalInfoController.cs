using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Contracts;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IPersonalInfoRepo _repo;

        public PersonalInfoController(IPersonalInfoRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var people = _repo.GetAll();
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Surname,Age")] Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }



            _repo.CreatePerson(person);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
