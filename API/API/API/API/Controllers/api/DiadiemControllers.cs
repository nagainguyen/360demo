using Libs.Entity;
using Libs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiadiemController : ControllerBase
    {
        private DiadiemService DiadiemService;

        public DiadiemController(DiadiemService DiadiemService)
        {
            this.DiadiemService = DiadiemService;
        }


        [HttpPost]
        [Route("inserDiadiem")]
        public IActionResult insertdd(DiadiemModel diadiemModel)
        {
            Diadiem diadiem = new Diadiem();
         
            diadiem.tenddiem = diadiemModel.tenddiem;
            diadiem.maddiem = diadiemModel.maddiem;


                DiadiemService.insertDiadiem(diadiem);
                return Ok(new { status = true, message = "INSERT SUCCESS" });
            }

            [HttpGet]
            [Route("listDiadiems")]
            public IActionResult Getdd()
            {

                List<Diadiem> DiadiemLists = DiadiemService.Getdd();
                return Ok(new { status = true, message = "SUCCESS", data = DiadiemLists });
            }

            [HttpPost]
            [Route("DeleteDiadiems")]
            public IActionResult deleteDiadiem(DiadiemModel diadiemModel)
            {
                DiadiemService.deleteDiadiem(diadiemModel.idddiem);
                return Ok(new { status = true, message = "DELETE SUCCESS" });
            }

            [HttpPost]
            [Route("updateDiadiem")]
            public IActionResult updateDiadiem(DiadiemModel diadiemModel)
            {
                Diadiem diadiem = DiadiemService.GetDiadiem(diadiemModel.idddiem);
                
                diadiem.tenddiem = diadiemModel.tenddiem;
                diadiem.maddiem = diadiemModel.maddiem;

                Ok(new { status = true, });
                DiadiemService.updateDiadiem(diadiem);
                return Ok(new { status = true, message = "", data = diadiem });

            }

        }
    }
