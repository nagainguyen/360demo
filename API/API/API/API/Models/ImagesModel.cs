using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class ImagesModel
    {
        public ImagesModel(Guid IdScence, String Name, string Title, String linkImage, float pitch, float yaw)
        {
            this.IdScence = IdScence;
            this.Name = Name;
            this.title=Title;
            this.linkImage = linkImage;
            this.pitch = pitch;
            this.yaw = yaw;
        }
        public ImagesModel()
        {
            this.IdScence = Guid.Empty;
            this.Name = String.Empty;
            this.title = String.Empty;
            this.linkImage = string.Empty;
            this.pitch = 0;
            this.yaw = 0;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdScence { get; set; }

        public String? Name { get; set; }
        public string title { get; set; }
        public String? linkImage { get; set; }
        public double pitch { get; set; }
        public double yaw { get; set; }



    }


}
