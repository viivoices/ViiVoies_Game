using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.IO.IsolatedStorage;

namespace myBuddies
{
    public partial class The_End : PhoneApplicationPage
    {
        IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
        int storyX = 0;
        public The_End()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
        
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);
            }
            if (petChose.gameStarted == 50)
            {
                Start.Begin();
            }
            
        }

        private void Start_Completed(object sender, EventArgs e)
        {
            
        }

        private void Start_Copy1_Completed(object sender, EventArgs e)
        {

        }

        private void Start_Copy2_Completed(object sender, EventArgs e)
        {

        }

        private void Start_Copy3_Completed(object sender, EventArgs e)
        {

        }

        private void Start_Copy4_Completed(object sender, EventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }

            Start_Copy4.Stop();
            petChose.GameStarted.Remove("gameStarted");
            petChose.GameStarted.Add("gameStarted", 51);
            petChose.GameStarted.Save();
            this.NavigationService.GoBack();
        }

        private void btnNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
   

            if (storyX == 0)
            {
                Start.Stop();
                Start_Copy1.Begin();
                storyX = storyX + 1;
            }
            else if (storyX == 1)
            {

                Start_Copy1.Stop();
                Start_Copy2.Begin();
                storyX = storyX + 1;
            }
            else if (storyX ==2)
            {

                Start_Copy2.Stop();
                Start_Copy3.Begin();
                storyX = storyX + 1;
            }
            else if (storyX == 3)
            {

                Start_Copy3.Stop();
                Start_Copy4.Begin();
                storyX = storyX + 1;
            }
          
        }
    }
}