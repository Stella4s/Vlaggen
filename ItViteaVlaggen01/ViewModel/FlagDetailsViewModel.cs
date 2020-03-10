using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.Globalization;

namespace ItViteaVlaggen01.ViewModel
{
    class FlagDetailsViewModel
    {
        public Dictionary<int, FlagDetails> FlagDict { get; set; }

        public FlagDetailsViewModel()
        {
            FlagDict = new Dictionary<int, FlagDetails>();
            FillFlagDictionary();
        }
        private void FillFlagDictionary()
        {
            ResourceSet rsrcSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, false, true);

            var images = typeof(Properties.Resources)
                    .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                         BindingFlags.Public)
                    .Where(p => p.PropertyType == typeof(Bitmap))
                    .Select(x => new { x.Name, Image = x.GetValue(null, null) })
                    .ToList();

            int intID = 0;
            foreach (var x in images)
            {
                FlagDict.Add(intID, new FlagDetails { FileName = x.Name, Name = x.Name, ImgSource = x.Name });
                intID++;
            }
        }




        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }
}
