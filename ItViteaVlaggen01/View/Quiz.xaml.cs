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
using System.Windows.Threading;



namespace ItViteaVlaggen01.View
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : UserControl, ISwitchable
    {
        IDictionary<int, FlagDetails> FlagDict;
        private DispatcherTimer dispatcherTimer;
        public Quiz()
        {
            InitializeComponent();
            FlagDetailsViewModel flagDetailsVM = new FlagDetailsViewModel();
            FlagDict = flagDetailsVM.FlagDict;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
            
        }
 
        public List<int> KeyList { get; set; }

        /// <summary>
        /// For creating a bitmap image to be displayed.
        /// Imgsource being the pathway to the image to be used.
        /// </summary>
        private BitmapImage ReturnImage(string imgSource)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(imgSource, UriKind.Relative);
            image.EndInit();
            return image;
        }
        /// <summary>
        /// Method for testintg if all images are displayed correctly.
        /// Will cycle through all flag images and display them along with their name.
        /// </summary>
        /*private void DisplayAllImages()
        {
            imgTestButton.IsEnabled = false;
            int i = 30;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Tick += timer_Tick;
            timer.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                if (i >= FlagDict.Count)
                {
                    timer.Stop();
                    labelDisplay.Content = null;
                    imgTestButton.IsEnabled = true;
                }
                else
                {
                    image1.Source = ReturnImage(FlagDict[i].ImgSource);
                    labelDisplay.Content = FlagDict[i].Name;
                    i++;
                }
            }
        }*/

        //Variables needed in this method.
        private Random random = new Random();
        string answerButton = "";
        List<int> randomKeys = new List<int>();
        bool boolRepeat;
        private void AssignAnswers()
        {
            int randomKey = random.Next(KeyList.Count);
            var currentFlag = FlagDict[KeyList[randomKey]];

            image1.Source = ReturnImage(currentFlag.ImgSource);
            KeyList.RemoveAt(randomKey);
            switch (random.Next(1, 5))
            {
                case 1:
                    rButton1.Content = currentFlag.Name;
                    answerButton = "rButton1";
                    break;

                case 2:
                    rButton2.Content = currentFlag.Name;
                    answerButton = "rButton2";
                    break;

                case 3:
                    rButton3.Content = currentFlag.Name;
                    answerButton = "rButton3";
                    break;

                case 4:
                    rButton4.Content = currentFlag.Name;
                    answerButton = "rButton4";
                    break;

                default:
                    break;
            }
            
            foreach (Control control in grid1.Children)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null)
                {
                    if (radio.Name != answerButton)
                    {
                        /// To make sure that it won't choose double answers.
                        /// Whilst keeping the Keylist unaltered.
                        do
                        {
                            randomKey = random.Next(KeyList.Count);
                            if (randomKeys.Contains(randomKey))
                                boolRepeat = true;
                            else
                                boolRepeat = false;
                        }
                        while (boolRepeat);
                        randomKeys.Add(randomKey);
                        radio.Content = FlagDict[KeyList[randomKey]].Name;
                    }
                }
            }
            randomKeys.Clear();
        }
        /// <summary>
        /// Resets the game, unChecking each radioButton and clearing all content.
        /// </summary>
        private void ResetGame()
        {
            intCounter++;
            counterLabel.Content = intCounter;
            image1.Source = null;
            labelDisplay.Content = null;
            foreach (Control control in grid1.Children)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null)
                {
                    radio.IsChecked = false;
                    radio.Content = "";
                    radio.Foreground = Brushes.Black;
                }
            }
            //startButton.IsEnabled = true;
        }
        private void CheckAnswer()
        {
            foreach (Control control in grid1.Children)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null)
                {
                    if (radio.Name == answerButton)
                        radio.Foreground = Brushes.Green;
                    else
                        radio.Foreground = Brushes.DarkRed;

                    if (radio.IsChecked == true)
                    {
                        if (radio.Name == answerButton)
                        {
                            intPoints++;
                            labelDisplay.Content = "Correct!";
                        }
                        else
                            labelDisplay.Content = "Wrong!";
                        //break;
                    }
                }
            }
            
        }
        //Variables for rounds and points.
        int intRounds = 25, intCounter, intPoints;
        /// <summary>
        /// Makes new KeyList, resets points and counter. 
        /// </summary>
        private void NewGame()
        {
            KeyList = new List<int>(FlagDict.Keys);
            intPoints = 0; intCounter = 0;
            totalRoundLabel.Content = intRounds;
        }
        private void NextRound()
        {
            if (intCounter < intRounds)
            {
                ResetGame();
                AssignAnswers();
                confirmButton.IsEnabled = true;
            }
            else
            {
                startButton.IsEnabled = true;
                labelDisplay.Content = String.Format("You finished! You got {0} out of {1} correct.", intPoints, intRounds);
            }
        }
        private void Confirm()
        {
            //Things which happen before the timer starts
            CheckAnswer();
            
            //Start the timer
            dispatcherTimer.Start();
        }
        
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            confirmButton.IsEnabled = false;
            Confirm();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Things which happen after 1 timer interval
            NextRound();

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            ResetGame();
            AssignAnswers();
            StackMenu1.Height = 0;
            startButton.IsEnabled = false;
        }
        /*private void ImgTest_Click(object sender, RoutedEventArgs e)
        {
            DisplayAllImages();
        }*/

        private void Radiobutton_Checked(object sender, RoutedEventArgs e)
        {
            if (fastMode)
                Confirm();
            else if (startButton.IsEnabled == false)
                confirmButton.IsEnabled = true;
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (StackMenu1.Height == 0)
                StackMenu1.Height = Double.NaN;
            else
                StackMenu1.Height = 0;
        }

        private void RoundsButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.IsChecked == true)
            {
                switch (radioBtn.Name)
                {
                    case "R25":
                        intRounds = 25;
                        break;

                    case "R50":
                        intRounds = 50;
                        break;

                    case "R100":
                        intRounds = 100;
                        break;

                    case "RAll":
                        intRounds = FlagDict.Count;
                        break;
                }
            }
        }
        bool fastMode;
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            fastMode = true;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            fastMode = false;
        }

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
