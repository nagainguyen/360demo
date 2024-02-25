using Libs.Entity;
using Libs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private LoginsService loginsService;

        public AccountsController(LoginsService loginsService)
        {
            this.loginsService = loginsService;
        }

        [HttpPost]
        [Route("insertAccount")]
        public IActionResult insertTaiKhoan(LoginsModel loginsModel)
        {
            Logins logins = new Logins();

            logins.taikhoan = loginsModel.taikhoan;
            logins.matkhau = loginsModel.matkhau;


            loginsService.insertLogins(logins);
            return Ok(new { status = true, message = "INSERT SUCCESS" });
        }

        [HttpPost]
        [Route("dangNhapTaiKhoan")]
        public IActionResult dangNhapTaiKhoan(LoginsModel loginsModel)
        {
            Logins logins = loginsService.getLogin(loginsModel.taikhoan);
            if (logins != null && logins.matkhau.Equals(loginsModel.matkhau))
            {
                return Ok(new { status = true, message =   "" });
            }
            else
            {
                return RedirectToAction("Logins");
            }
        }

        [HttpGet]
        [Route("listAccount")]
        public IActionResult GetImageLists()
        {

            List<Logins> tkLists = loginsService.Gettk();
            return Ok(new { status = true, message = "SUCCESS", data = tkLists });
        }

        [HttpPost]
        [Route("DeleteAccount")]
        public IActionResult deleteTaiKhoan(LoginsModel loginsModel)
        {
            loginsService.deleteLogins(loginsModel.taikhoan);
            return Ok(new { status = true, message = "DELETE SUCCESS" });
        }

        [HttpPost]
        [Route("updateAccount")]
        public IActionResult updateTaiKhoan(LoginsModel loginsModel)
        {
            Logins logins = loginsService.getLogin(loginsModel.taikhoan);
            logins.taikhoan = logins.taikhoan ;
            logins.matkhau = loginsModel.matkhau;

            Ok(new { status = true, });
            loginsService.updateLogin(logins);
            return Ok(new { status = true, message = "UPDATE SUCCESS", data = logins });

        }
    }
}
