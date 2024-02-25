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
    public interface IKhuvucsRepository : IRepository<Khuvucs>
    {
        //code...khai bao
        public void insertKhuvucs(Khuvucs khuvucs);
        public void deleteKhuvucs(Khuvucs khuvucs);
        public void updateKhuvucs(Khuvucs khuvucs);
        public class KhuvucsRepository : RepositoryBase<Khuvucs>, IKhuvucsRepository
        {
            public KhuvucsRepository(ApplicationDbContext dbContext) : base(dbContext)
            {
            }

            public void deleteKhuvucs(Khuvucs khuvucs)
            {
                _dbContext.Khuvucs.Remove(khuvucs);
            }

            public void insertKhuvucs(Khuvucs khuvucs)
            {
                _dbContext.Khuvucs.Add(khuvucs);
            }

            public void updateKhuvucs(Khuvucs khuvucs)
            {
                _dbContext.Khuvucs.Update(khuvucs);
            }
       

        }
    }
}
