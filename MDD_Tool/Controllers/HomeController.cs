﻿using MDD_Tool.Models;
using Microsoft.AspNetCore.Mvc;
using ModelTransformer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDD_Tool.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UmlCodeModel model)
        {
            if (model != null && !string.IsNullOrWhiteSpace(model.UmlCode))
            {
                ViewBag.Code = UmlParser.Parse(model.UmlCode);
            }

            return View();
        }

        public IActionResult FindUser()
        {
            return new JsonResult("Founded user");
        }
    }
}
