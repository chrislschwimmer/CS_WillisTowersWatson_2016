using CS_WillisTowersWatson_2016.Services;
using System.Web.Mvc;

namespace CS_WillisTowersWatson_2016.Controllers
{
    public class AccountController : Controller
    {
        private IMessageService messageService;
        private IDataSerivce _dataService;

        public AccountController(IMessageService messageService, IDataSerivce dataService)
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