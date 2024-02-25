using Libs.Entity;
using Libs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Libs.Repositories.IKhuvucsRepository;

namespace Libs.Service
{
    public class KhuvucsService
    {
        private ApplicationDbContext applicationDbContext;
        private KhuvucsRepository khuvucsRepository;

        public KhuvucsService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.khuvucsRepository = new KhuvucsRepository(applicationDbContext);
        }
        public void Save()
        {
            this.applicationDbContext.SaveChanges();
        }
        ///
        public void insertKhuvucs(Khuvucs khuvucs)
        {
            khuvucsRepository.insertKhuvucs(khuvucs);
            Save();
        }
        ///
        public List<Khuvucs> Getkv()
        {
            return applicationDbContext.Khuvucs.ToList();
        }
        //
        public Khuvucs GetKhuvucs(Guid id)
        {
            return applicationDbContext.Khuvucs.FirstOrDefault(x => x.idkv == id);
        }
        ///
        public void deleteKhuvucs(Guid id)
        {
           Khuvucs kv = applicationDbContext.Khuvucs.FirstOrDefault(x => x.idkv.Equals(id));

            khuvucsRepository.deleteKhuvucs(kv);
            Save();
        }
        //
        public void updateKhuvucs(Khuvucs khuvucs)
        {
            Khuvucs kv = applicationDbContext.Khuvucs.FirstOrDefault(x => x.idkv == khuvucs.idkv);
            khuvucsRepository.updateKhuvucs(kv);
            Save();

        }
    }
}