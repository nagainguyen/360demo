using Libs.Data;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IHotSpotsRepository : IRepository<HotSpot>
    {
        //code...khai bao
        public void insertHotSpots(HotSpot hotspot);
        public void deleteHotSpots(HotSpot hotspot);
        public void updateHotSpots(HotSpot hotspot);
        public class HotSpotRepository : RepositoryBase<HotSpot>, IHotSpotsRepository
        {
            public HotSpotRepository(ApplicationDbContext dbContext) : base(dbContext)
            {
            }
            //viet insert cac kieu trong 1 table thi lam o repositrories
            public void insertHotSpots(HotSpot hotspot)
            {
                _dbContext.HotSpots.Add(hotspot);
            }

            public void deleteHotSpots(HotSpot hotspot)
            {
                _dbContext.HotSpots.Remove(hotspot);
            }

            public void updateHotSpots(HotSpot hotspot)
            {
                _dbContext.HotSpots.Update(hotspot);
            }

           
            //code jj
        }
    }
}
