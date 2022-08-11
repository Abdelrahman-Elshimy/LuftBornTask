using Luftborn.core;
using Luftborn.core.DTO.Authors;
using Luftborn.core.Interfaces;
using Luftborn.core.Models;
using LuftBornTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LuftBornTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _unitofwork;
        public HomeController(ILogger<HomeController> logger, IUnitofWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            var authors = _unitofwork.Authors.GetAll();
            return View(authors);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public UpdateOrCreateAuthorDTO CreateOrEdit(string name, int id)
        {
            try
            {
                var authorExist = _unitofwork.Authors.GetByIdAsync(id).Result;
                if (authorExist != null)
                {
                    authorExist.Name = name;
                    _unitofwork.Authors.Update(authorExist);
                    _unitofwork.Complete();
                    return new UpdateOrCreateAuthorDTO { Author = authorExist.Name, Message = "Author Updated Successfully" };
                }
                else
                {
                    Author author = new()
                    {
                        Name = name
                    };
                    _unitofwork.Authors.Add(author);
                    _unitofwork.Complete();
                    return new UpdateOrCreateAuthorDTO { Author = author.Name, Message = "Author Added Successfully" };
                }
            }catch
            {
                return new UpdateOrCreateAuthorDTO() { Message = "Error Occured", Author = null};
            }
        }

        public void Delete(int id)
        {
            var author = _unitofwork.Authors.GetByIdAsync(id).Result;
            _unitofwork.Authors.Delete(author);
            _unitofwork.Complete();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _unitofwork.Authors.GetAll();
        }
    }
}
