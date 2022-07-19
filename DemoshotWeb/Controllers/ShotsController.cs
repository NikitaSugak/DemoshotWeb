using DemoshotWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DemoshotWeb.Models.IShotRepository;

namespace DemoshotWeb.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ShotsController : Controller
    {
        IUserRepository repo;
        public ShotsController(IUserRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetShots());
        }

        public ActionResult Details(int id)
        {
            Shot user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Shot user)
        {
            repo.Create(user);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Shot user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Shot user)
        {
            repo.Update(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Shot user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
