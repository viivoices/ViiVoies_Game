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
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
namespace myBuddies
{
    public partial class Page2 : PhoneApplicationPage
    {
        IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
        int WhichConvo = 0;
        public Page2()
        {
            InitializeComponent();
        }

        private void story1_Completed(object sender, EventArgs e)
        {
           
            
            story1.Stop();
            this.NavigationService.GoBack();
            
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
        
                if (petChose.gameStarted == 3)
            {
                if (MediaPlayer.GameHasControl == true)
                {
                    FrameworkDispatcher.Update();
                    me.Stop();
                    me.Source = new Uri("Sounds/Alarm.mp3", UriKind.Relative);
                }
                story1.Begin();
                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 4);
                petChose.GameStarted.Save();
            }
else  if (petChose.gameStarted == 7)
            {
                
                Scene5.Visibility = System.Windows.Visibility.Collapsed;
                LayoutRoot.Visibility = System.Windows.Visibility.Visible;
                story2FinishFirstPartOfGame.Begin();
                
            }
            else if (petChose.gameStarted == 8)
            {
                SongTimer.Begin();
                storyTitleProjectVIIVoices.Begin();
            }
            }

        private void me_MediaOpened(object sender, RoutedEventArgs e)
        {
            FrameworkDispatcher.Update();
            MediaElement m = (MediaElement)sender;

            m.Play();
        }

        private void me_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (petChose.gameStarted == 8)
            {
                FrameworkDispatcher.Update();
                me.Stop();
                me.Source = new Uri("Sounds/MainMenu.mp3", UriKind.Relative);
            }
            
            }
   
        private void story2FinishFirstPartOfGame_Completed(object sender, EventArgs e)
        {
           
            story2FinishFirstPartOfGame.Stop();
            storyFallenAngel.Begin();
            storyMusicAngels.Begin();
         
           
            
           
        }
        private void storyMusicAngels_Completed(object sender, EventArgs e)
        {
            FrameworkDispatcher.Update();
            me.Stop();
            me.Volume = 4;
            me.Source = new Uri("Sounds/FallenAngels.mp3", UriKind.Relative);
          

        }
        private void storyTimer_Completed(object sender, EventArgs e)
        {
            storyTimer.Stop();
          
            }

        private void storyFallenAngel_Completed(object sender, EventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            storyFallenAngel.Stop();
            storyTitleProjectVIIVoices.Begin();
            
            if (petChose.gameStarted == 7)
            {
                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 8);
                petChose.GameStarted.Save();

            }
              
           
            FrameworkDispatcher.Update();
            me.Stop();
            if (MediaPlayer.GameHasControl == true)
            {
                FrameworkDispatcher.Update();
                me.Stop();
                me.Source = new Uri("Sounds/MainMenu.mp3", UriKind.Relative);
            }
            }
//Continue Button
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
          
             if (WhichConvo == 0)
            {
                storyBeginGame.Stop();
                storyBeginGame_Copy1.Begin();
                WhichConvo = WhichConvo + 1;
            }
            else if (WhichConvo == 1)
            {
                storyBeginGame_Copy1.Stop();
                storyBeginGame_Copy2.Begin();
                WhichConvo = WhichConvo + 1;
            }
            else if (WhichConvo == 2)
            {
                storyBeginGame_Copy2.Stop();
                storyBeginGame_Copy3.Begin();
                WhichConvo = WhichConvo + 1;
            }
            else if (WhichConvo == 3)
            {
                storyBeginGame_Copy3.Stop();
                storyBeginGame_Copy4.Begin();
                      WhichConvo = WhichConvo + 1;
            }
           else if (WhichConvo ==4)
                {
                    storyBeginGame_Copy4.Stop();
                    Scene5.Visibility = System.Windows.Visibility.Collapsed;
               if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
                    if (petChose.gameStarted == 8)
            {
            
                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 9);
                petChose.GameStarted.Save();
                VeraFlying.Stop();
  this.NavigationService.GoBack();
            }
                
                }
              
            
        }

        private void SongTimer_Completed(object sender, EventArgs e)
        {
            //if (MediaPlayer.GameHasControl == true)
            //{
                FrameworkDispatcher.Update();
                me.Stop();
                me.Source = new Uri("Sounds/MainMenu.mp3", UriKind.Relative);

            //}
        }

        private void storyTitleProjectVIIVoices_Completed(object sender, EventArgs e)
        {
            storyTitleProjectVIIVoices.Stop();
            storyBeginGame.Begin();
        }

        private void storyBeginGame_Completed(object sender, EventArgs e)
        {
            VeraFlying.Begin();
        }

    

     

    

        
        }
    }

