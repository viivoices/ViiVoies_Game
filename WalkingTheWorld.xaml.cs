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
    public partial class WalkingTheWorld : PhoneApplicationPage
    {
        IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
        Random Fight = new Random();
        int Battle;
       
        public WalkingTheWorld()
        {
            InitializeComponent();
        }

        //Loaded
        private void phoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            if (petChose.DistanceWalked.TryGetValue("distanceWalked", out petChose.distanceWalked))
            {
                petChose.DistanceWalked.TryGetValue("distanceWalked", out petChose.distanceWalked);
                txtDistanceWalked.Text = petChose.distanceWalked.ToString();
            }
            if (petChose.DistanceToTown.TryGetValue("distanceToTown", out petChose.distanceToTown))
            {
                petChose.DistanceToTown.TryGetValue("distanceToTown", out petChose.distanceToTown);
                txtUntilArrival.Text = petChose.distanceToTown.ToString();
            }
            if (petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo))
            {
                petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo);
            }
            if (petChose.TownIn.TryGetValue("townIn", out petChose.townIn)) 
            {
                petChose.TownIn.TryGetValue("townIn", out petChose.townIn);
            }
        }

//Completed StoryBoards
        private void moveRight_Completed(object sender, EventArgs e)
        {
            if (petChose.DistanceWalked.TryGetValue("distanceWalked", out petChose.distanceWalked))
            {
                petChose.DistanceWalked.TryGetValue("distanceWalked", out petChose.distanceWalked);
                txtDistanceWalked.Text = petChose.distanceWalked.ToString();
            }
            
            moveRight.Begin();
            Canvas.SetLeft(grass, Canvas.GetLeft(grass) - 2);
            if (petChose.distanceWalked >=petChose.distanceToTown)
            {
                Town.Begin();
                if (petChose.townWantingToGo== 1)
                {
                    Obar.Visibility = System.Windows.Visibility.Visible;
                    petChose.TownIn.Remove("townIn");
                    petChose.TownIn.Add("townIn",1);
                    petChose.TownIn.Save();
                }
                if (petChose.townWantingToGo == 2)
                {
                    Andion.Visibility = System.Windows.Visibility.Visible;
                    petChose.TownIn.Remove("townIn");
                    petChose.TownIn.Add("townIn", 2);
                    petChose.TownIn.Save();
                }
                if (petChose.townWantingToGo == 3)
                {
                    The_Lost.Visibility = System.Windows.Visibility.Visible;
                    petChose.TownIn.Remove("townIn");
                    petChose.TownIn.Add("townIn", 3);
                    petChose.TownIn.Save();

                }
                if (petChose.townWantingToGo == 4)
                {
                    Eggnon.Visibility = System.Windows.Visibility.Visible;
                    petChose.TownIn.Remove("townIn");
                    petChose.TownIn.Add("townIn", 4);
                    petChose.TownIn.Save();

                }
                if (petChose.townWantingToGo == 5)
                {
                    Gurdain_Fortres.Visibility = System.Windows.Visibility.Visible;
                    petChose.TownIn.Remove("townIn");
                    petChose.TownIn.Add("townIn", 5);
                    petChose.TownIn.Save();
                }
                if (petChose.townWantingToGo == 6)
                {
                    The_Fallen.Visibility = System.Windows.Visibility.Visible;
                    petChose.TownIn.Remove("townIn");
                    petChose.TownIn.Add("townIn", 6);
                    petChose.TownIn.Save();
                }
            }
            if (petChose.distanceWalked < petChose.distanceToTown)
            {
                petChose.distanceWalked = petChose.distanceWalked + 1;
                txtDistanceWalked.Text = petChose.distanceWalked.ToString();
                petChose.DistanceWalked.Remove("distanceWalked");
                petChose.DistanceWalked.Add("distanceWalked", petChose.distanceWalked);
                petChose.DistanceWalked.Save();

                Battle = Fight.Next(0, 1000);
                if (Battle <= 21)
                {
                    storyBeginFight.Begin();
                    moveRight.Stop();

                }

            }
        }
        private void storyBeginFight_Completed(object sender, EventArgs e)
        { 
            //When Chosing Lvl and Creature to battle give a number.
            petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
            petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
            petChose.EnemyLvlSelected.Save();
            //Enemy Health Lvl 1 enemy 1
            petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
            petChose.EnemyHealthPoints.Add("enemyHealthPoints", 250);//ENEMY HEALTH
            petChose.EnemyHealthPoints.Save();
            
            this.NavigationService.Navigate(new Uri("/FightLevel1.xaml", UriKind.Relative));
            storyBeginFight.Stop();
        }
        private void moveLeft_Completed(object sender, EventArgs e)
        {
            
        }

        private void MoveRightVII_Completed(object sender, EventArgs e)
        {
            MoveRightVII.Begin();
        }
//Click Events

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            petChose.GameStarted.Remove("gameStarted");
            petChose.GameStarted.Add("gameStarted", 0);
            petChose.GameStarted.Save();



            this.NavigationService.GoBack();
        }
        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void btnRight_MouseEnter(object sender, MouseEventArgs e)
        {
            moveRight.Begin();
            MoveRightVII.Begin();
        }

        private void btnRight_MouseLeave(object sender, MouseEventArgs e)
        {
            moveRight.Stop();
         
            MoveRightVII.Stop();
        }

        private void btnLeft_MouseLeave(object sender, MouseEventArgs e)
        {
            moveLeft.Stop();
        }

        private void btnLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            moveLeft.Begin();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        
    }
}