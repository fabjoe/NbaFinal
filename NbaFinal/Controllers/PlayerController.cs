using Microsoft.AspNetCore.Mvc;
using NbaFinal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaFinal.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepo _playerRepo;
        public PlayerController(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }
        public IActionResult Index()
        {
            return View(_playerRepo.GetAll());
        }
    }
}
