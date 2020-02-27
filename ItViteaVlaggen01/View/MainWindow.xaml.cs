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
using System.Windows.Threading;

namespace ItViteaVlaggen01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Dictionary<int, FlagDetails> FlagDict { get; set; }
        //Declare variables
        //private Random random = new Random();
        //string answerButton = "";
        //public List<int> keyList;

        public MainWindow()
        {
            InitializeComponent();
            //FlagDict = new Dictionary<int, FlagDetails>();
            //FillFlagDictionary();
            //keyList = new List<int>(FlagDict.Keys);
        }

        //private void FillFlagDictionary()
        //{
        //    ResourceSet rsrcSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, false, true);

        //    var images = typeof(Properties.Resources)
        //            .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
        //                                                 BindingFlags.Public)
        //            .Where(p => p.PropertyType == typeof(Bitmap))
        //            .Select(x => new { x.Name, Image = x.GetValue(null, null) })
        //            .ToList();

        //    int intID = 0;
        //    foreach (var x in images)
        //    {
        //        FlagDict.Add(intID, new FlagDetails { FileName = x.Name, Name = x.Name, ImgSource = x.Name });
        //        intID++;
        //    }
        //}
        //private BitmapImage ReturnImage(string imgSource)
        //{
        //    BitmapImage image = new BitmapImage();
        //    image.BeginInit();
        //    image.UriSource = new Uri(imgSource, UriKind.Relative);
        //    image.EndInit();
        //    return image;
        //}
        //private void DisplayAllImages()
        //{
        //    imgTestButton.IsEnabled = false;
        //    int i = 30;
        //    DispatcherTimer timer = new DispatcherTimer();
        //    timer.Interval = TimeSpan.FromMilliseconds(300);
        //    timer.Tick += timer_Tick;
        //    timer.Start();

        //    void timer_Tick(object sender, EventArgs e)
        //    {
        //        if (i >= FlagDict.Count)
        //        {
        //            timer.Stop();
        //            labelDisplay.Content = null;
        //            imgTestButton.IsEnabled = true;
        //        }
        //        else
        //        {
        //            image1.Source = ReturnImage(FlagDict[i].ImgSource);
        //            labelDisplay.Content = FlagDict[i].Name;
        //            i++;
        //        }
        //    }
        //}

        //private void Radiobutton_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (startButton.IsEnabled == false)
        //        confirmButton.IsEnabled = true;
        //}

        //private void AssignAnswers()
        //{
        //    int randomKey = random.Next(keyList.Count);
        //    var currentFlag = FlagDict[keyList[randomKey]];

        //    image1.Source = ReturnImage(currentFlag.ImgSource);
        //    keyList.RemoveAt(randomKey);
        //    switch (random.Next(1, 5))
        //    {
        //        case 1:
        //            rButton1.Content = currentFlag.Name;
        //            answerButton = "rButton1";
        //            break;

        //        case 2:
        //            rButton2.Content = currentFlag.Name;
        //            answerButton = "rButton2";
        //            break;

        //        case 3:
        //            rButton3.Content = currentFlag.Name;
        //            answerButton = "rButton3";
        //            break;

        //        case 4:
        //            rButton4.Content = currentFlag.Name;
        //            answerButton = "rButton4";
        //            break;

        //        default:
        //            break;
        //    }
        //    foreach (Control control in grid1.Children)
        //    {
        //        RadioButton radio = control as RadioButton;
        //        if (radio != null)
        //        {
        //            if (radio.Name != answerButton)
        //            {
        //                randomKey = random.Next(keyList.Count);
        //                radio.Content = FlagDict[keyList[randomKey]].Name;
        //                keyList.RemoveAt(randomKey);
        //            }
        //        }
        //    }
        //}
        //private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        //{

        //    foreach (Control control in grid1.Children)
        //    {
        //        RadioButton radio = control as RadioButton;
        //        if (radio != null)
        //        {
        //            if (radio.IsChecked == true)
        //            {
        //                if (radio.Name == answerButton)
        //                    startButton.Content = "Correct! Play Again?";
        //                else
        //                    startButton.Content = "Wrong! Try Again?";
        //                break;
        //            }
        //        }
        //    }
        //    startButton.IsEnabled = true;
        //    confirmButton.IsEnabled = false;
        //}
        ///// <summary>
        ///// Resets the game, unChecking each radioButton and clearing all content.
        ///// </summary>
        //private void ResetGame()
        //{
        //    image1.Source = null;
        //    foreach (Control control in grid1.Children)
        //    {
        //        RadioButton radio = control as RadioButton;
        //        if (radio != null)
        //        {
        //            radio.IsChecked = false;
        //            radio.Content = "";
        //        }
        //    }
        //    startButton.IsEnabled = true;
        //}
        //private void StartButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ResetGame();
        //    AssignAnswers();
        //    startButton.IsEnabled = false;
        //}

        //private void ImgTest_Click(object sender, RoutedEventArgs e)
        //{
        //    DisplayAllImages();
        //}
    }
}

