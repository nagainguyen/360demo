using Libs.Entity;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Libs.Repositories.IHotSpotsRepository;

namespace Libs.Service
{
    public class HotSpotsService
    {
        private ApplicationDbContext applicationDbContext;
        private HotSpotRepository hotSpotRepository;

        public HotSpotsService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.hotSpotRepository = new HotSpotRepository(applicationDbContext);
        }
        public void Save()
        {
            this.applicationDbContext.SaveChanges();
        }
        ///
        public void insertHotSpot(HotSpot hotspot)
        {
            hotSpotRepository.insertHotSpots(hotspot);
            Save();
        }
        ///
        public List<HotSpot> GetHotSpotLists()
        {
            return applicationDbContext.HotSpots.ToList();
        }
        //
        public HotSpot getHotSpot(Guid id)
        {
            return applicationDbContext.HotSpots.FirstOrDefault(x => x.idHsp == id);
        }
        public async Task<List<HotSpot>> GetAllHotSpotsAsync()
        {
            return await applicationDbContext.HotSpots.ToListAsync();
        }


        ///
        public void deleteHotSpot(Guid idHsp)
        {
            HotSpot tam = applicationDbContext.HotSpots.FirstOrDefault(x => x.idHsp.Equals(idHsp));

            hotSpotRepository.deleteHotSpots(tam);
            Save();
        }
        //
        public void updateHotSpot(HotSpot hotSpot)
        {
            HotSpot tam = applicationDbContext.HotSpots.FirstOrDefault(x => x.idHsp == hotSpot.idHsp);
            hotSpotRepository.updateHotSpots(tam);
            Save();

        }
    }
}
