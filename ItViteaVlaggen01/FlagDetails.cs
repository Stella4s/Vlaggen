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
    public class FlagDetails
    {
        private string _name, _imgSource;
        /// <summary>
        /// The name of the country that will be used. (based of FileName)
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value.Replace("Flag", "").Replace("_", " ");
        }
        /// <summary>
        /// The actual filename. Flag[country].png
        /// </summary>
        public string FileName { get; set; }

        public string ImgSource
        {
            get => _imgSource;
            set => _imgSource = String.Format(@"Resources\{0}.png", value);
        }
    }

   
}
 