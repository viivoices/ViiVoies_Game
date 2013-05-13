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
using Microsoft.Phone.Marketplace;
using Microsoft.Xna.Framework.GamerServices;
namespace myBuddies
{
    public partial class HomeScreen : PhoneApplicationPage
    {
        IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
        int whichConversation;
		int playButton;
       
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           // backWhichStoryToPause = 0;
            
            canvasLoading.Visibility = System.Windows.Visibility.Collapsed;


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //PLAYER STATS NEED TO CHANGE THIS AROUND TESTING RIGHT NOW

            //petChose.PetFallenAngels.Remove("petFallenAngels");
            //petChose.PetFallenAngels.Add("petFallenAngels", 1);
            //petChose.PetFallenAngels.Save();
            //petChose.PetSheild.Remove("petShield");
            //petChose.PetSheild.Add("petShield", 1);
            //petChose.PetSheild.Save();

            //petChose.ManaAttackUP.Remove("manaAttackUp");
            //petChose.ManaAttackUP.Add("manaAttackUp", 10);
            //petChose.ManaAttackUP.Save();

            //petChose.SpeedUP.Remove("speedUP");
            //petChose.SpeedUP.Add("speedUP", 1);
            //petChose.SpeedUP.Save();


            //petChose.AttackUP.Remove("attackUP");
            //petChose.AttackUP.Add("attackUP", 10);
            //petChose.AttackUP.Save();

            //petChose.SpiritualAttackUP.Remove("spiritAttackUP");
            //petChose.SpiritualAttackUP.Add("spiritAttackUP", 8);
            //petChose.SpiritualAttackUP.Save();


            //petChose.DefenseUP.Remove("petDefenseUP");
            //petChose.DefenseUP.Add("petDefenseUP", 1);
            //petChose.DefenseUP.Save();

            //petChose.ExpPoints.Remove("expPoints");
            //petChose.ExpPoints.Add("expPoints", 0);
            //petChose.ExpPoints.Save();


            //petChose.ChurchCreature.Remove("churchCreature");
            //petChose.ChurchCreature.Add("churchCreature", 8);
            //petChose.ChurchCreature.Save();

            //petChose.HealthPoints.Remove("healthPoints");
            //petChose.HealthPoints.Add("healthPoints", 8500);
            //petChose.HealthPoints.Save();
            //petChose.ManaPoints.Remove("manaPoints");
            //petChose.ManaPoints.Add("manaPoints", 810);
            //petChose.ManaPoints.Save();
            //petChose.MaxHealthPoints.Remove("maxHealthPoints");
            //petChose.MaxHealthPoints.Add("maxHealthPoints", 8500);
            //petChose.MaxHealthPoints.Save();
            //petChose.MaxManaPoints.Remove("maxManaPoints");
            //petChose.MaxManaPoints.Add("maxManaPoints", 10);
            //petChose.MaxManaPoints.Save();

        
           
           

           

//////////////////////////////////////////////////////////////////////////////////////////////////////



            button.Visibility = System.Windows.Visibility.Visible;
            if (petChose.TownIn.TryGetValue("townIn", out petChose.townIn))
            {
                petChose.TownIn.TryGetValue("townIn", out petChose.townIn);
            }
            //Sound
            if (checkSound.SoundEffectOffOrOn.TryGetValue("soundOffOrOn", out checkSound.soundOffOrOn))
            {
                checkSound.SoundEffectOffOrOn.TryGetValue("soundOffOrOn", out checkSound.soundOffOrOn);

            }
            if (checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn))
            {
                checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn);

            }
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }

            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive))
            {
                petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive);
            }

       




            //petChose.GameStarted.Remove("gameStarted");
            //petChose.GameStarted.Add("gameStarted", 24);
            //petChose.GameStarted.Save();

            //Pause
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();

            petChose.PauseActive.Remove("pauseActive");
            petChose.PauseActive.Add("pauseActive", 0);
            petChose.PauseActive.Save();
            
/////////////////////////////////////////////////////////////////////////////////////////////////     


           
            if (petChose.gameStarted == 2)
            {
                if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
                {
                    petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

                }
                canvasLoading.Visibility = System.Windows.Visibility.Visible;


                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 3);
                petChose.GameStarted.Save();
                
                this.NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));


             


                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;

            }

            if (petChose.gameStarted == 4)
            {
                if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
                {
                    petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

                }
                canvasLoading.Visibility = System.Windows.Visibility.Visible;

                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 5);
                petChose.GameStarted.Save();
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 250);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();

                


                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
                this.NavigationService.Navigate(new Uri("/Page1AfterHomeScreen.xaml", UriKind.Relative));
               
            }
            if (petChose.gameStarted == 6)
            {
                canvasLoading.Visibility = System.Windows.Visibility.Visible;

                

                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 7);
                petChose.GameStarted.Save();
                this.NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
                
            }
            if (petChose.gameStarted == 9)
            {

                canvasLoading.Visibility = System.Windows.Visibility.Visible;


                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 11);
                petChose.GameStarted.Save();
                petChose.TownIn.Remove("townIn");
                petChose.TownIn.Add("townIn", 1);
                petChose.TownIn.Save();
                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
                this.NavigationService.Navigate(new Uri("/WalkingObar.xaml", UriKind.Relative));

          

            }
            if(petChose.gameStarted==12)
            {
                canvasLoading.Visibility = System.Windows.Visibility.Visible;


                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 13);
                petChose.GameStarted.Save();
                petChose.TownIn.Remove("townIn");
                petChose.TownIn.Add("townIn", 1);      
                petChose.TownIn.Save();
                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 150);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
              
                this.NavigationService.Navigate(new Uri("/FightLevel1.xaml", UriKind.Relative));
            }
            if (petChose.gameStarted == 14)
            {
                canvasLoading.Visibility = System.Windows.Visibility.Visible;

                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 15);
                petChose.GameStarted.Save();
                petChose.TownIn.Remove("townIn");
                petChose.TownIn.Add("townIn", 1);
                petChose.TownIn.Save();
                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
                this.NavigationService.Navigate(new Uri("/WalkingObar.xaml", UriKind.Relative));
            }
            if (petChose.gameStarted == 21)
            {
                canvasLoading.Visibility = System.Windows.Visibility.Visible;


                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 22);
                petChose.GameStarted.Save();
                petChose.TownIn.Remove("townIn");
                petChose.TownIn.Add("townIn", 1);
                petChose.TownIn.Save();
                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
                this.NavigationService.Navigate(new Uri("/WalkingAndion.xaml", UriKind.Relative));
            }
            if (petChose.gameStarted == 31)
            {

                canvasLoading.Visibility = System.Windows.Visibility.Visible;

                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 32);
                petChose.GameStarted.Save();
                petChose.TownIn.Remove("townIn");
                petChose.TownIn.Add("townIn", 1);
                petChose.TownIn.Save();
                txtPlay.Visibility = System.Windows.Visibility.Collapsed;
                txtContinue.Visibility = System.Windows.Visibility.Collapsed;
                this.NavigationService.Navigate(new Uri("/WalkingEggnon.xaml", UriKind.Relative));
            }



             if (petChose.gameStarted >=1)
            {
                txtPlay.Text = "Continue Journey";
                btnNewGame.Visibility = System.Windows.Visibility.Visible;
               
            }
          
         

            FrameworkDispatcher.Update();
            if (MediaPlayer.GameHasControl == false)
            {
                MessageBoxResult results;
                results = MessageBox.Show("The Voices say that you are playing music. Would you like to stop your music and play music from Project VII Voices", "Music", MessageBoxButton.OKCancel);
                if (results == MessageBoxResult.OK)
                {

                    FrameworkDispatcher.Update();
                    me.Stop();                
                    me.Source = new Uri("Sounds/MainMenu.mp3", UriKind.Relative);
                    checkSound.MusicOffOrOn.Remove("musicOffOrOn");
                    checkSound.MusicOffOrOn.Add("musicOffOrOn", 0);
                    checkSound.MusicOffOrOn.Save();
                    storyPlayButton.Begin();

                }

                else
                {
                    checkSound.MusicOffOrOn.Remove("musicOffOrOn");
                    checkSound.MusicOffOrOn.Add("musicOffOrOn", 1);
                    checkSound.MusicOffOrOn.Save();
                    storyPlayButton.Begin();
                }
            }
            if (MediaPlayer.GameHasControl == true)
            {
                
                    storyPlayButton.Begin();
                    FrameworkDispatcher.Update();
                    me.Stop();
                    me.Volume = 4;
                    me.Source = new Uri("Sounds/MainMenu.mp3", UriKind.Relative);

                    checkSound.MusicOffOrOn.Remove("musicOffOrOn");
                    checkSound.MusicOffOrOn.Add("musicOffOrOn", 0);
                    checkSound.MusicOffOrOn.Save();
              

            }
            btnAbout.Visibility = System.Windows.Visibility.Visible;
            txtVIIVoices.Visibility = System.Windows.Visibility.Visible;
            button.Visibility = System.Windows.Visibility.Visible;
            storyPlayButton.Begin();
            txtPlay.Visibility = System.Windows.Visibility.Visible;
        }

     
//Play Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);
               
            }
            button.Visibility = System.Windows.Visibility.Collapsed;
            txtVIIVoices.Visibility = System.Windows.Visibility.Collapsed;
            btnAbout.Visibility = System.Windows.Visibility.Collapsed;
            btnNewGame.Visibility = System.Windows.Visibility.Collapsed;
            playButton = 1;
            storyPlayButton.Stop();
            if (checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn))
            {
                checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn);

            }
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.gameStarted == 0)
            {
                
                btnAbout.Visibility = System.Windows.Visibility.Collapsed;
                txtVIIVoices.Visibility = System.Windows.Visibility.Collapsed;

                //Pause
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 1);
                petChose.Pause.Save();

                //PLAYER STATS //NEED TO CHANGE THIS AROUND TESTING RIGHT NOW
                petChose.ManaAttackUP.Remove("manaAttackUp");
                petChose.ManaAttackUP.Add("manaAttackUp", 1);
                petChose.ManaAttackUP.Save();
                //speedUP
                petChose.SpeedUP.Remove("speedUP");
                petChose.SpeedUP.Add("speedUP", 1);
                petChose.SpeedUP.Save();

                //attackUP
                petChose.AttackUP.Remove("attackUP");
                petChose.AttackUP.Add("attackUP", 1);
                petChose.AttackUP.Save();
                //Spirit
                petChose.SpiritualAttackUP.Remove("spiritAttackUP");
                petChose.SpiritualAttackUP.Add("spiritAttackUP", 1);
                petChose.SpiritualAttackUP.Save();

                //Defense
                petChose.DefenseUP.Remove("petDefenseUP");
                petChose.DefenseUP.Add("petDefenseUP", 1);
                petChose.DefenseUP.Save();


                //Lighting
                petChose.petLighting = 1;
                petChose.PetLighting.Remove("petLighting");
                petChose.PetLighting.Add("petLighting", petChose.petLighting);
                petChose.PetLighting.Save();
                //Health and Mana
                petChose.HealthPoints.Remove("healthPoints");
                petChose.HealthPoints.Add("healthPoints", 500);
                petChose.HealthPoints.Save();
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", 10);
                petChose.ManaPoints.Save();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 500);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 10);
                petChose.MaxManaPoints.Save();

                me.Stop();

                if (checkSound.musicOffOrOn < 1)
                {
                    FrameworkDispatcher.Update();
                    me.Stop();
                    me.Source = new Uri("Sounds/Intro.mp3", UriKind.Relative);

                    whichConversation = 1;



                    storyIntro.Begin();
                    button.Visibility = System.Windows.Visibility.Collapsed;

                }
                else
                {
                    MessageBox.Show("You are about to take part in a epic adventure but we need control of the music- It'll be worth it...Good Luck VII Voices");
                }
            }
            //Which Game State Player Is At Take them there
            if (petChose.gameStarted == 1)
            {
                this.NavigationService.Navigate(new Uri("/Page1AfterHomeScreen.xaml", UriKind.Relative));
            }
            else if (petChose.gameStarted == 3)
            {
                this.NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }

            else if (petChose.gameStarted == 5)
            {

                this.NavigationService.Navigate(new Uri("/Page1AfterHomeScreen.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            else if (petChose.gameStarted == 7)
            {
                this.NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            else if (petChose.gameStarted == 8)
            {
                this.NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            //Obar
            else if (petChose.gameStarted == 11)
            {
                this.NavigationService.Navigate(new Uri("/WalkingObar.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            else if (petChose.gameStarted == 13)
            {
                this.NavigationService.Navigate(new Uri("/FightLevel1.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            else if (petChose.gameStarted == 15)
            {
                this.NavigationService.Navigate(new Uri("/WalkingObar.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            else if (petChose.gameStarted >= 16 && petChose.gameStarted <20)
            {
                this.NavigationService.Navigate(new Uri("/WalkingObar.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
            //Andion
            else if (petChose.gameStarted == 20)
            {
                petChose.gameStarted = 22;
                this.NavigationService.Navigate(new Uri("/WalkingAndion.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();

            }
            else if (petChose.gameStarted == 21)
            {
                petChose.gameStarted = 22;
                this.NavigationService.Navigate(new Uri("/WalkingAndion.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();
            }
           
            else if (petChose.gameStarted >= 22 && petChose.gameStarted < 30)
            {
                this.NavigationService.Navigate(new Uri("/WalkingAndion.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();

            }
    

            else if (petChose.gameStarted >=30)
            {
                this.NavigationService.Navigate(new Uri("/WalkingEggnon.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();

            }
            else if (petChose.gameStarted == 50)
            {
                this.NavigationService.Navigate(new Uri("/The End.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();

            }
            else if (petChose.gameStarted == 51)
            {
                this.NavigationService.Navigate(new Uri("/WalkingEggnon.xaml", UriKind.Relative));
                storyPlayButton.Stop();
                storyPlayButtonIsDown.Stop();

            }
        }
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            storyPlayButton.Stop();
            storyPlayButtonIsDown.Begin();
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
			if(playButton==0)
			{
            storyPlayButton.Begin();
            storyPlayButtonIsDown.Stop();
			}
			else{storyPlayButtonIsDown.Stop();}
			}
			

        //Completed StoryBoards
        private void storyIntro_Completed(object sender, EventArgs e)
        {
           
            storyIntro.Stop();
            //Pause
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            storyConvo1.Begin();
            btnNext.Visibility = System.Windows.Visibility.Collapsed;
           


        
        }
        private void storyPlayButtonIsDown_Completed(object sender, EventArgs e)
        {
            storyPlayButtonIsDown.Stop();
          

        }
        private void storyConvo1_Completed(object sender, EventArgs e)
        {

        }

        private void storyConvo2_Completed(object sender, EventArgs e)
        {

        }

//Controls the Dialog Boxes       
        //Next Button
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (whichConversation == 1)
            {
                storyConvo1.Stop(); storyConvo2.Begin(); whichConversation = whichConversation + 1; 
            }

            else if (whichConversation == 2)
            {
                storyConvo2.Stop();
                storyConvo3.Begin();
                whichConversation = whichConversation + 1;
                
            }
     	else if(whichConversation == 3)
		{
            storyConvo3.Stop();
            storyConvo4.Begin();
            whichConversation = whichConversation + 1;
		}
            else if (whichConversation == 4)
            {
                storyConvo4.Stop();
                storyScene1.Begin();
                storyScene1Convo1.Begin();
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 5)
            {
                storyScene1Convo1.Stop();
                storyScene1Convo2.Begin();
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 6)
            {
                storyScene1Convo2.Stop();
                storyScene1Convo3.Begin();
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 7)
            {
                storyScene1Convo3.Stop();
                storyScene1Convo4.Begin();
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 8)
            {
                storyScene1Convo4.Stop();
                storyScene1Convo5.Begin();
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 9)
            {
                storyScene1Convo5.Stop();
                storyScene1Convo6.Begin();
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 10)
            {
                storyScene1Convo6.Stop();
                storyScene1_1.Begin();
                storyScene1.Stop();
                whichConversation = whichConversation + 1;
     

            }
            else if (whichConversation == 11)
            {
                storyScene1_1.Stop();
                storyScene2.Begin();
                FrameworkDispatcher.Update();
                me.Stop();
                me.Source = new Uri("Sounds/Scene2.mp3", UriKind.Relative);
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 12)
            {
                storyScene2.Stop();
                storyScene3.Begin();
                checkSound.SmallExplosionSound(checkSound.soundOffOrOn);                                                                                                                                                                 //Small Explosion Sound
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 13)
            {
                storyScene3.Stop();
                storyScene3_1.Begin();
                checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                                                 //GunShot Sound
                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 14)
            {
                storyScene3_1.Stop();
                storyScene4.Begin();
                FrameworkDispatcher.Update();
                me.Stop();
                me.Source = new Uri("Sounds/Alarm.mp3", UriKind.Relative);

                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 15)
            {
                storyScene4.Stop();
                storyScene4_1.Begin();

                whichConversation = whichConversation + 1;
            }
            else if (whichConversation == 16)
            {
                storyScene4_1.Stop();
                storyScene5.Begin();
                whichConversation = whichConversation + 1;

            }
            else if (whichConversation == 17)
            {
                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 1);
                petChose.GameStarted.Save();



                storyScene5.Stop();
                //petChose.ManaAttackUP.Remove("manaAttackUp");
                //petChose.ManaAttackUP.Add("manaAttackUp", 1);
                //petChose.ManaAttackUP.Save();

                ////speedUP
                //petChose.SpeedUP.Remove("speedUP");
                //petChose.SpeedUP.Add("speedUP", 1);
                //petChose.SpeedUP.Save();

                ////attackUP
                //petChose.AttackUP.Remove("attackUP");
                //petChose.AttackUP.Add("attackUP", 1);
                //petChose.AttackUP.Save();
                ////Spirit
                //petChose.SpiritualAttackUP.Remove("spiritAttackUP");
                //petChose.SpiritualAttackUP.Add("spiritAttackUP", 1);
                //petChose.SpiritualAttackUP.Save();

                ////Defense
                //petChose.DefenseUP.Remove("defenseUP");
                //petChose.DefenseUP.Add("defenseUP", 1);
                //petChose.DefenseUP.Save();

                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 250);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();

                this.NavigationService.Navigate(new Uri("/Page1AfterHomeScreen.xaml", UriKind.Relative));
                
            }
        }
 
     








//Media Opened
    
        private void me_MediaOpened(object sender, RoutedEventArgs e)
        {
            FrameworkDispatcher.Update();
            MediaElement m = (MediaElement)sender;
           
            m.Play();
        }

        private void me_MediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (whichConversation == 0 || whichConversation >= 14)
            {
                FrameworkDispatcher.Update();
                MediaElement m = (MediaElement)sender;

                m.Play();
            }
            else
            {
                FrameworkDispatcher.Update();
                MediaElement m = (MediaElement)sender;

                m.Stop();
            
            }
            
            }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            storyPlayButton.Stop();
            storyPlayButtonIsDown.Stop();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive))
            {
                petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive);
            }
           
            petChose.PauseActive.Remove("pauseActive");
            petChose.PauseActive.Add("pauseActive", 7);
            petChose.PauseActive.Save();
            canvasNewGame.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnStartNewGame_Click(object sender, RoutedEventArgs e)
        {
            canvasNewGame.Visibility = System.Windows.Visibility.Collapsed;
            this.NavigationService.Navigate(new Uri("/WalkingTheWorld.xaml", UriKind.Relative));
        }

        private void btnNoWay_Click(object sender, RoutedEventArgs e)
        {
            canvasNewGame.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }

            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            if (petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive))
            {
                petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive);
            }

            
            if (petChose.pause==1 || petChose.pause==2)
            {
                e.Cancel = true;
                
                if (petChose.pauseActive == 0)
                {
                    storyIntro.Pause();
                    storyConvo1.Pause();
                    storyConvo2.Pause();
                    storyConvo3.Pause();
                    storyConvo4.Pause();
                    storyScene1.Pause();
                    storyScene1_1.Pause();
                    storyScene1Convo1.Pause();
                    storyScene1Convo2.Pause();
                    storyScene1Convo3.Pause();
                    storyScene1Convo4.Pause();
                    storyScene1Convo5.Pause();
                    storyScene1Convo6.Pause();
                    storyScene2.Pause();
                    storyScene3.Pause();
                    storyScene3_1.Pause();
                    storyScene4.Pause();
                    storyScene4_1.Pause();
                    storyScene5.Pause();
                    me.Pause();

                    canvasPaused.Visibility = System.Windows.Visibility.Visible;
                    petChose.PauseActive.Remove("pauseActive");
                    petChose.PauseActive.Add("pauseActive", 1);
                    petChose.PauseActive.Save();
                }
               if(petChose.pauseActive ==1)
               {
                   e.Cancel = true;
                 
                   canvasPaused.Visibility = System.Windows.Visibility.Collapsed;
                   storyIntro.Resume();
                   storyConvo1.Resume();
                   storyConvo2.Resume();
                   storyConvo3.Resume();
                   storyConvo4.Resume();
                   storyScene1.Resume();
                   storyScene1_1.Resume();
                   storyScene1Convo1.Resume();
                   storyScene1Convo2.Resume();
                   storyScene1Convo3.Resume();
                   storyScene1Convo4.Resume();
                   storyScene1Convo5.Resume();
                   storyScene1Convo6.Resume();
                   storyScene2.Resume();
                   storyScene3.Resume();
                   storyScene3_1.Resume();
                   storyScene4.Resume();
                   storyScene4_1.Resume();
                   storyScene5.Resume();
                   petChose.PauseActive.Remove("pauseActive");
                   petChose.PauseActive.Add("pauseActive", 0);
                   petChose.PauseActive.Save();
                   if (petChose.pause == 1 || whichConversation == 12 || whichConversation == 15)
                   {
                       e.Cancel = true;
                       me.Play();
                   }
               }
            }
                    if (petChose.pauseActive == 7)
                   {
                       e.Cancel = true;
                       canvasNewGame.Visibility = System.Windows.Visibility.Collapsed;
                       petChose.PauseActive.Remove("pauseActive");
                       petChose.PauseActive.Add("pauseActive", 0);
                       petChose.PauseActive.Save();
                   }
             
                
                
               
            }

        

        private void btnContinue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            canvasPaused.Visibility = System.Windows.Visibility.Collapsed;
            petChose.PauseActive.Remove("pauseActive");
            petChose.PauseActive.Add("pauseActive", 0);
            petChose.PauseActive.Save();
            storyIntro.Resume();
            storyConvo1.Resume();
            storyConvo2.Resume();
            storyConvo3.Resume();
            storyConvo4.Resume();
            storyScene1.Resume();
            storyScene1_1.Resume();
            storyScene1Convo1.Resume();
            storyScene1Convo2.Resume();
            storyScene1Convo3.Resume();
            storyScene1Convo4.Resume();
            storyScene1Convo5.Resume();
            storyScene1Convo6.Resume();
            storyScene2.Resume();
            storyScene3.Resume();
            storyScene3_1.Resume();
            storyScene4.Resume();
            storyScene4_1.Resume();
            storyScene5.Resume();
            if (petChose.pause == 1 || whichConversation ==11 || whichConversation == 14)
            {
                me.Play();
            }
            }

     

      

        

      

       
    }
}