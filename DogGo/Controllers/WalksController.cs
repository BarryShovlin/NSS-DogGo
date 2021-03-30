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
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalksController(IWalkRepository walkRepository)
        {
            _walkRepo = walkRepository;
        }
        // GET: WalkersController
        public ActionResult Index()
        {
            List<Walk> walks = _walkRepo.GetAllWalks();

            return View(walks);
        }
    }
}