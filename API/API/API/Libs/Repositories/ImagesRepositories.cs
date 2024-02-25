using Libs.Data;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IImagesRepository : IRepository<Images>
    {
        //code...khai bao
        public void insertImages(Images images);
        public void deleteImages(Images images);
        public void updateImages(Images images);
        public class ImagesRepository : RepositoryBase<Images>, IImagesRepository
        {
            public ImagesRepository(ApplicationDbContext dbContext) : base(dbContext)
            {
            }
            //viet insert cac kieu trong 1 table thi lam o repositrories
            public void insertImages(Images images) {
                _dbContext.Images.Add(images);
            }

            public void deleteImages(Images images) {
                _dbContext.Images.Remove(images);
            }
            public void updateImages(Images images) {
                _dbContext.Images.Update(images);
            }
            //code jj
        }
    }
}
