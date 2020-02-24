using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Resources;

namespace ItViteaVlaggen01
{
    class FlagDetails
    {
        /// <summary>
        /// The name of the country that will be used. (based of FileName)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The actual filename. Flag[country].png
        /// </summary>
        public string FileName { get; set; }

        public string ImgSource { get; set; }
        /// <summary>
        /// The image object.
        /// </summary>
        public object Img { get; set; }

        public int ID { get; set; }

        public void setNameAndImgSource()
        {
            Name = FileName.Replace("Flag", "");
            ImgSource = String.Format(@"Resources\{0}.png", FileName);
        }
    }

   
}
 