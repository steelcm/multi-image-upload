using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Prepopulate();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            // todo: map new images (found under viewModel.Files)
            // todo: update/delete existing images (found unser viewModel.Images)
            return RedirectToAction("index");
        }
    }

    public class IndexViewModel
    {
        public string MyName { get; set; }
        public IList<ImageViewModel> Images { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
    public static class IndexViewModelExtensions
    {
        public static void Prepopulate(this IndexViewModel self)
        {
            self.MyName = "Chris is Awesome";
            self.Images = new List<ImageViewModel>()
            {
                new ImageViewModel()
                {
                    Id = 1,
                    ImageUrl = "https://placeholdit.imgix.net/~text?txtsize=28&txt=300%C3%97300&w=300&h=300"
                },
                new ImageViewModel()
                {
                    Id = 2,
                    ImageUrl = "https://placeholdit.imgix.net/~text?txtsize=33&txt=350%C3%97150&w=350&h=150"
                }
            };
        }
    }

    public class ImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }

}
