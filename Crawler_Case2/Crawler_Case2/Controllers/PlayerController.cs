using Crawler_Case2.Abstract;
using Crawler_Case2.Concrete;
using Crawler_Case2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Crawler_Case2.Controllers
{
    public class PlayerController : Controller
    {
        Context db = new Context();
        IPlayerRepo _playerRepo;

        public PlayerController(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public IActionResult Index()
        {
            var players = _playerRepo.GetListAll();
            return View(players);


        }
        public ActionResult GetUpdateData()
        {

            var data = _playerRepo.GetListAll();
            //return Json(data, JsonRequestBehavior.AllowGet);

            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
        [HttpGet]
        public ActionResult PlayerAdd()
        {
            ViewBag.tId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult PlayerAdd(Player play)
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
            ViewBag.tId = new SelectList(db.Teams, "Id", "Name", play.TeamId);
            play.Photo = paramphoto;
            _playerRepo.Insert(play);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult PlayerEdit(int id)
        {
            ViewBag.tId = new SelectList(db.Teams, "Id", "Name");
            var player = _playerRepo.GetById(id);
            return View(player);
        }
        public ActionResult PlayerEdit(Player play, int id)
        {
            var paramphoto = "aaa";
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


            ViewBag.tId = new SelectList(db.Teams, "Id", "Name", play.TeamId);
            play.Id = id;
            play.Photo = paramphoto;
            _playerRepo.Update(play);
            return RedirectToAction("Index");
        }


        public ActionResult PlayerDelete(int id)
        {
            _playerRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetPlayer(int id)
        {
            var teams = _playerRepo.GetPlayerByTeam(id);
            return View(teams);
        }
        public ActionResult GetPlayerData(int id)
        {

            var data = _playerRepo.GetPlayerByTeam(id);


            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

    }
}
