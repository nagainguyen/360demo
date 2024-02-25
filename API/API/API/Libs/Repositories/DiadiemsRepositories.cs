using Libs.Data;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Libs.Repositories
{
    public interface IDiadiemRepository : IRepository<Diadiem>
    {
        //code...khai bao
        public void insertDiadiem(Diadiem diadiem);
        public void deleteDiadiem(Diadiem diadiem);
        public void updateDiadiem(Diadiem diadiem);
        public class DiadiemRepository : RepositoryBase<Diadiem>, IDiadiemRepository
        {
            public DiadiemRepository(ApplicationDbContext dbContext) : base(dbContext)
            {
            }
          
            public void insertDiadiem(Diadiem diadiem)
            {
                _dbContext.Diadiem.Add(diadiem);
            }

            public void deleteDiadiem(Diadiem diadiem)
            {
                _dbContext.Diadiem.Remove(diadiem);
            }

            public void updateDiadiem(Diadiem diadiem)
            {
                _dbContext.Diadiem.Update(diadiem);
            }
        }
    }
}
