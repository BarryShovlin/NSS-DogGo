using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _OwnerRepo;

        // ASP.NET will give us an instance of our Owner Repository. This is called "Dependency Injection"
        public OwnersController(IOwnerRepository OwnerRepository)
        {
            _OwnerRepo = OwnerRepository;
        }
        // GET: OwnersController
        public ActionResult Index()
        {
            List<Owner> Owners = _OwnerRepo.GetAllOwners();

            return View(Owners);
        }

        // GET: OwnersController/Details/5
        public ActionResult Details(int id)
        {
            Owner Owner = _OwnerRepo.GetOwnerById(id);

            if (Owner == null)
            {
                return NotFound();
            }

            return View(Owner);
        }
    }
}
