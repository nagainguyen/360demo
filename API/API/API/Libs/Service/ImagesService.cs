using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Libs.Repositories.IImagesRepository;

namespace Libs.Service
{
    public class ImagesService
    {
        private ApplicationDbContext applicationDbContext;
        private ImagesRepository imagesRepository;

        public ImagesService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.imagesRepository = new ImagesRepository(applicationDbContext);
        }
        public void Save()
        {
            this.applicationDbContext.SaveChanges();
        }
        ///
        public void insertImages(Images images)
        {
            imagesRepository.insertImages(images);
            Save();
        }
        ///
        public List<Images> GetImageLists()
        {
            return applicationDbContext.Images.ToList();
        }
        public async Task<List<Images>> GetImageListsAsync()
        {
            return await applicationDbContext.Images.ToListAsync();
        }

        //
        public Images getImage(Guid id)
        {
            return applicationDbContext.Images.FirstOrDefault(x => x.idScence == id);
        }
        ///
        public void deleteImage(Guid id)
        {
            Images tam = applicationDbContext.Images.FirstOrDefault(x => x.idScence.Equals(id));
         
            imagesRepository.deleteImages(tam);
            Save();
        }
        //
        public void updateImage(Images images)
        {
            Images tam = applicationDbContext.Images.FirstOrDefault(x => x.idScence == images.idScence);
            imagesRepository.updateImages(tam);
            Save();

        }
    }
}
