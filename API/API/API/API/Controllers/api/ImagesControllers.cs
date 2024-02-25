using Libs.Entity;
using Libs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private ImagesService ImagesService;
        private HotSpotsService hotSpotsService;
        public ImagesController(ImagesService ImagesService, HotSpotsService hotSpotsService)
        {
            this.ImagesService = ImagesService;
            this.hotSpotsService = hotSpotsService;

        }


        [HttpPost]
        [Route("insertImage")]
        public IActionResult insertImage(ImagesModel imagesModel)
        {
           Images images = new Images();
           // images.idHsp = Guid.NewGuid();
            images.idScence = imagesModel.IdScence;
            images.Name = imagesModel.Name;
            images.title = imagesModel.title;
            images.linkImage = imagesModel.linkImage;
            images.pitch = imagesModel.pitch;
            images.yaw = imagesModel.yaw;
           
            ImagesService.insertImages(images);
            return Ok(new { status = true, message = "INSERT SUCCESS" });
        }

        [HttpGet]
        [Route("listImages")]
        public IActionResult GetImageLists()
        {

            List<Images> ImageLists = ImagesService.GetImageLists();




            return Ok(new { status = true, message = "SUCCESS", data = ImageLists });
        }


        [HttpGet]
        [Route("GetAllScenesWithHotSpots")]
        public async Task<IActionResult> GetScenesWithHotSpots()
        {
            try
            {
                List<Images> scenes = await ImagesService.GetImageListsAsync();
                List<HotSpot> allHotSpots = await hotSpotsService.GetAllHotSpotsAsync();

                List<SceneWithHotSpots> scenesWithHotSpots = new List<SceneWithHotSpots>();

                foreach (var scene in scenes)
                {
                    List<HotSpot> hotSpotsForScene = allHotSpots
                        .Where(x => x.NameScene == scene.Name)
                       
                        .ToList();

                    SceneWithHotSpots sceneWithHotSpots = new SceneWithHotSpots
                    {
                        IdScene = scene.idScence,
                        Name = scene.Name,
                        Title = scene.title,
                        LinkImage = scene.linkImage,
                        Pitch = scene.pitch,
                        Yaw = scene.yaw,
                        HotSpots = hotSpotsForScene
                    };

                    scenesWithHotSpots.Add(sceneWithHotSpots);
                }

                return Ok(new { status = true, message = "Thành công", data = scenesWithHotSpots });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult deleteImage(Guid IDScence)
        {
            ImagesService.deleteImage(IDScence);
            return Ok(new { status = true, message = "DELETE SUCCESS" });
        }


        [HttpPost]
        [Route("updateImage")]
        public IActionResult updateImage(ImagesModel imageModel)
        {
            try
            {
                Images images = ImagesService.getImage(imageModel.IdScence);
                if (images == null)
                {
                    return NotFound(new { status = false, message = "Image not found" });
                }

                images.Name = imageModel.Name;
                images.title = imageModel.title;
                images.linkImage = imageModel.linkImage;
                images.pitch = imageModel.pitch;
                images.yaw = imageModel.yaw;

                ImagesService.updateImage(images);
                return Ok(new { status = true, message = "Update success", data = images });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = $"Error: {ex.Message}" });
            }
        }


    }
    public class SceneWithHotSpots
    {
        public Guid IdScene { get; set; }
        public string ?Name { get; set; }
        public string ?Title { get; set; }
        public string ?LinkImage { get; set; }
        public double Pitch { get; set; }
        public double Yaw { get; set; }
        public List<HotSpot>? HotSpots { get; set; }
    }
}
