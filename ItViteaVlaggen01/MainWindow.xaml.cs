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
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;


namespace ItViteaVlaggen01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ResourceSet rsrcSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, false, true);


            var images = typeof(Properties.Resources)
                    .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                         BindingFlags.Public)
                    .Where(p => p.PropertyType == typeof(Bitmap))
                    .Select(x => new { Name = x.Name, Image = x.GetValue(null, null) })
                    .ToList();

            List<FlagDetails> flagsList = new List<FlagDetails>();
            int intID = 1;
            foreach (var x in images)
            {
                flagsList.Add(new FlagDetails { FileName = x.Name, Img = x.Image, ID = intID});
                intID++;
            }
            foreach (FlagDetails x in flagsList){
                x.setNameAndImgSource();
            }

            BitmapImage bimage = new BitmapImage();
            bimage.BeginInit();
            bimage.UriSource = new Uri(flagsList[4].ImgSource, UriKind.Relative);
            bimage.EndInit();
            image1.Source = bimage;

            textBlock1.Text = flagsList[4].Name;
        }

    }
}
