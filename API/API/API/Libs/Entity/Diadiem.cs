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
    public class Diadiem
    {
        public Diadiem(Guid idddiem, string tenddiem, string maddiem)
        {
            this.idddiem = idddiem;
            this.tenddiem = tenddiem;
            this.maddiem = maddiem;

        }
        public Diadiem()
        {
            this.idddiem = Guid.Empty;
            this.tenddiem = string.Empty;
            this.maddiem = string.Empty;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idddiem { get; set; }
        public string tenddiem { get; set; }
        public string maddiem { get; set; }

    }
}
