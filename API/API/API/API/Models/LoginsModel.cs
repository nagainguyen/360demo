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
    public class LoginsModel
    {
        public LoginsModel(Guid idName, string taikhoan, string matkhau)
        {
            this.idName = idName;
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;

        }
        public LoginsModel()
        {
            this.idName = Guid.Empty;
            this.taikhoan = string.Empty;
            this.matkhau = string.Empty;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid idName { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }

    }
}
