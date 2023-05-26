using Crawler_Case2.Abstract;
using Crawler_Case2.Concrete;
using Crawler_Case2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Crawler_Case2.Controllers
{
    public class TeamsController : Controller
	{
		Context db = new Context();
		ITeamsRepo _teamsRepo;

        public TeamsController(ITeamsRepo teamsRepo)
        {
            _teamsRepo = teamsRepo;
        }

        public IActionResult Index()
		{
			List<Teams> teams = _teamsRepo.GetListAll();
			return View(teams);
		}

        public ActionResult GetUpdateData()
        {
            var data = _teamsRepo.GetListAll();
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(Teams teams )
        {
            var paramphoto = "";
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    string newimage = Path.GetFileName(file.FileName);
                    string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", newimage);
                    using (var stream = new FileStream(imagepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    paramphoto = "/Images/" + newimage;
                }
            }
            teams.Logo = paramphoto;
            _teamsRepo.Insert(teams);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditTeam(int id)
        {
            var teams = _teamsRepo.GetById(id);
            return View(teams);
        }



        [HttpPost]
        public ActionResult EditTeam(Teams teams, int id)
        {
            string paramlogo = "";
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    string newimage = Path.GetFileName(file.FileName);
                    string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", newimage);
                    using (var stream = new FileStream(imagepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    paramlogo = "/Images/" + newimage;
                }
            }

            teams.Logo = paramlogo;
            teams.Id = id;
            _teamsRepo.Update(teams);
             return RedirectToAction("Index");

        }
        public ActionResult DeleteTeam(int id)
        { 
                //return HttpNotFound();
            _teamsRepo.Delete(id);
            return RedirectToAction("Index");
        }
        
        
    }
}
