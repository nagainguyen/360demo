using Libs.Entity;
using Libs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotSpotsController : ControllerBase
    {
        private HotSpotsService hotSpotsService;

        public HotSpotsController(HotSpotsService hotSpotsService)
        {
            this.hotSpotsService = hotSpotsService;
        }


        [HttpPost]
        [Route("insertHotSpot")]
        public IActionResult insertHotSpot(HotSpotModel hotSpotModel)
        {
           HotSpot hotSpot = new HotSpot();
           
            hotSpot.NameScene = hotSpotModel.NameScene;
            hotSpot.NameNextScene = hotSpotModel.NameNextScene;
            hotSpot.text = hotSpotModel.text;
            hotSpot.pitch = hotSpotModel.pitch;
            hotSpot.yaw = hotSpotModel.yaw;
            //if (images == null || string.IsNullOrEmpty(images.name) || string.IsNullOrEmpty(images.idImage) || string.IsNullOrEmpty(images.linkImage))
            //{
            //    return BadRequest(new { status = false, message = "Invalid or missing data" });
            //}
            hotSpotsService.insertHotSpot(hotSpot);
            return Ok(new { status = true, message = "INSERT SUCCESS" });
        }

        [HttpGet]
        [Route("listHotSpots")]
        public IActionResult GetHotSpotLists()
        {

            List<HotSpot> HotSpotLists = hotSpotsService.GetHotSpotLists();
            return Ok(new { status = true, message = "SUCCESS", data = HotSpotLists });
        }
       

        [HttpDelete]
        [Route("Delete")]
        public IActionResult deleteHotSpot(Guid idHsp)
        {
            hotSpotsService.deleteHotSpot(idHsp);
            return Ok(new { status = true, message = "DELETE SUCCESS" });
        }

        [HttpPost]
        [Route("updateHotSpot")]
        public IActionResult updateHotSpot(HotSpotModel hotSpotModel)
        {
            try
            {
                HotSpot hotSpot = hotSpotsService.getHotSpot(hotSpotModel.idHsp);
                if (hotSpot == null)
                {
                    return NotFound(new { status = false, message = "Image not found" });
                }
                hotSpot.NameScene = hotSpotModel.NameScene;
                hotSpot.NameNextScene = hotSpotModel.NameNextScene;
                hotSpot.text = hotSpotModel.text;
                hotSpot.pitch = hotSpotModel.pitch;
                hotSpot.yaw = hotSpotModel.yaw;

                hotSpotsService.updateHotSpot(hotSpot);
                return Ok(new { status = true, message = "Update success", data = hotSpot });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = $"Error: {ex.Message}" });
            }
        }


    }
}
