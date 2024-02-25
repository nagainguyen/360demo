using Libs.Entity;
using Libs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuVucController : ControllerBase
    {
        private KhuvucsService khuvucsService;

        public KhuVucController(KhuvucsService khuvucsService)
        {
            this.khuvucsService = khuvucsService;
        }


        [HttpPost]
        [Route("insertKhuvuc")]
        public IActionResult inserKhuvucs(KhuvucsModel khuvucsModel)
        {
            Khuvucs khuvucs = new Khuvucs();

            khuvucs.tenkv = khuvucsModel.tenkv;
            khuvucs.makv = khuvucsModel.makv;


            khuvucsService.insertKhuvucs(khuvucs);
            return Ok(new { status = true, message = "INSERT SUCCESS" });
        }

        [HttpGet]
        [Route("listKhuvucs")]
        public IActionResult Getkv()
        {

            List<Khuvucs> khuvucLists = khuvucsService.Getkv();
            return Ok(new { status = true, message = "SUCCESS", data = khuvucLists });
        }

        [HttpPost]
        [Route("DaleteKhuvuc")]
        public IActionResult deleteKhuvucs(KhuvucsModel khuvucsModel)
        {
            khuvucsService.deleteKhuvucs(khuvucsModel.idkv);
            return Ok(new { status = true, message = "DELETE SUCCESS" });
        }

        [HttpPost]
        [Route("updateKhuvuc")]
        public IActionResult updateDiadiem(KhuvucsModel khuvucsModel)
        {
            Khuvucs khuvucs = khuvucsService.GetKhuvucs(khuvucsModel.idkv);

            khuvucs.tenkv = khuvucsModel.tenkv;
            khuvucs.makv = khuvucsModel.makv;

            Ok(new { status = true, });
            khuvucsService.updateKhuvucs(khuvucs);
            return Ok(new { status = true, message = "", data = khuvucs });

        }

    }
}
