using CS_WillisTowersWatson_2016.Services;
using System.Web.Mvc;

namespace CS_WillisTowersWatson_2016.Controllers
{
    public class HomeController : Controller
    {
        private IMessageService messageService;
        private IDataSerivce _dataService;

        public HomeController(IMessageService messageService, IDataSerivce dataService)
        {
            this.messageService = messageService;
            this._dataService = dataService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = messageService.SendMessage("test message");
            ViewBag.Data = _dataService.ConnectionName();
            return View();
        }
    }
}