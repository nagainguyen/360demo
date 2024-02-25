using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libs.Entity
{
    public class Khuvucs
    {
        public Khuvucs(Guid idkv, string tenkv, string makv)
        {
            this.idkv = idkv;
            this.tenkv = tenkv;
            this.makv = makv;

        }
        public Khuvucs()
        {
            this.idkv = Guid.Empty;
            this.tenkv = string.Empty;
            this.makv = string.Empty;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idkv { get; set; }
        public string tenkv { get; set; }
        public string makv { get; set; }

    }
}
