using Libs.Entity;
using Libs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Libs.Repositories.IDiadiemRepository;

namespace Libs.Service
{
    public class DiadiemService
    {
        private ApplicationDbContext applicationDbContext;
        private DiadiemRepository diadiemRepository;

        public DiadiemService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.diadiemRepository = new DiadiemRepository(applicationDbContext);
        }
        public void Save()
        {
            this.applicationDbContext.SaveChanges();
        }
        ///
        public void insertDiadiem(Diadiem diadiem)
        {
            diadiemRepository.insertDiadiem(diadiem);
            Save();
        }
        ///
        public List<Diadiem> Getdd()
        {
            return applicationDbContext.Diadiem.ToList();
        }
        //
        public Diadiem GetDiadiem(Guid id)
        {
            return applicationDbContext.Diadiem.FirstOrDefault(x => x.idddiem == id);
        }
        ///
        public void deleteDiadiem(Guid id)
        {
            Diadiem dd = applicationDbContext.Diadiem.FirstOrDefault(x => x.idddiem.Equals(id));

            diadiemRepository.deleteDiadiem(dd);
            Save();
        }
        //
        public void updateDiadiem(Diadiem diadiem)
        {
            Diadiem dd= applicationDbContext.Diadiem.FirstOrDefault(x => x.idddiem == diadiem.idddiem);
            diadiemRepository.updateDiadiem(dd);
            Save();

        }
    }
}