using ItViteaVlaggen01.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItViteaVlaggen01.View
{
    /// <summary>
    /// Interaction logic for ListAll.xaml
    /// </summary>
    public partial class ListAll : UserControl
    {
        IDictionary<int, FlagDetails> FlagDict;
        public ListAll()
        {
            InitializeComponent();
            FlagDetailsViewModel flagDetailsVM = new FlagDetailsViewModel();
            FlagDict = flagDetailsVM.FlagDict;

            FlagList = new List<FlagDetails>(FlagDict.Values);
            this.FlagBox.ItemsSource = FlagList;
        }
        public List<FlagDetails> FlagList { get; set; }

        //Switcher section.
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        #region ISwitchable Members

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
