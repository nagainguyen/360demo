using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class HotSpot
    {
        public HotSpot(Guid idHsp,string NameScene, string NameNextScene, string Text, float pitch, float yaw)
        {
            this.idHsp = idHsp;
            this.NameScene = NameScene;
            this.NameNextScene = NameNextScene;
            this.text = Text;
            this.pitch = pitch;
            this.yaw = yaw;

        }
        public HotSpot()
        {
            this.idHsp = Guid.Empty;
            this.NameScene = string.Empty;
            this.NameNextScene = string.Empty;
            this.text = string.Empty;
            this.pitch = 0;
            this.yaw = 0;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idHsp { get; set; }
        public string NameScene { get; set; }
        public string NameNextScene { get; set; }
        public string text { get; set; }
        public double pitch { get; set; }
        public double yaw { get; set; }
    }


}
