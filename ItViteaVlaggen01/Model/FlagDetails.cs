using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Resources;
using System.ComponentModel;

namespace ItViteaVlaggen01
{
    public class FlagDetails : INotifyPropertyChanged
    {
        private string _name, _imgSource, _fileName;
        /// <summary>
        /// The name of the country that will be used. (based of FileName)
        /// </summary>
        public string Name
        {
            get => _name;
            //set => _name = BaseReplace(value).Replace("Flag", "").Replace("_", " ");
            set
            {
                _name = BaseReplace(value).Replace("Flag", "").Replace("_", " ");
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// The actual filename. Flag[country].png
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public string ImgSource
        {
            get => _imgSource;
            //set => _imgSource = String.Format(@"Resources\{0}.png", BaseReplace(value));
            set
            {
                _imgSource = String.Format(@"Resources\{0}.png", BaseReplace(value));
                OnPropertyChanged("ImgSource");
            }
        }
        private string BaseReplace(string str)
        {
            return str.Replace("1", "'").Replace("2", "-");
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }


}
 