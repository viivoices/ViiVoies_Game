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
namespace myBuddies
{
    public partial class WalkingAndion : PhoneApplicationPage
    {    IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
        Random Fight = new Random();
       
        int whichConversation;
        //TryParse Values
        int Health;
        int maxHelth;
        int Mana;
        int maxMana;
        int Level;
        int Exp;
        int Points;
        int itemSelected;
        int totalPotion;
        int totalXPotion;
        int itemBeingUsed;
        int playerHealing;
        bool buttonEnable = false;
        int NeviQuest;
        
        int upgrade;
        public WalkingAndion()
        {
            InitializeComponent();
        }



         //Loaded
        private void phoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo))
            {
                petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo);
            }




            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive))
            {
                petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive);
            }

            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            
            
            //TryParse the for Everything Health,Magic,Level,Exp,Points
            int.TryParse(txtPlayersHealthPoints.Text, out Health);
            int.TryParse(txtMaxHealthPoints.Text, out maxHelth);
            int.TryParse(txtPlayerManaPoints.Text, out Mana);
            int.TryParse(txtMaxManaPoints.Text, out maxMana);
            int.TryParse(txtPlayerLevel.Text, out Level);
            int.TryParse(txtPlayerExp.Text, out Exp);
            int.TryParse(txtPlayersPoints.Text, out Points);



            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }

            if (petChose.gameStarted >= 30)
            {
                petChose.GameStarted.Remove("gameStarted");
                petChose.GameStarted.Add("gameStarted", 31);
                petChose.GameStarted.Save();
                
                this.NavigationService.GoBack();
            }
            if (petChose.gameStarted == 25)
            {
                Eli.Visibility = System.Windows.Visibility.Collapsed;
                btnTalkToMasterAdalmun.Visibility = System.Windows.Visibility.Collapsed;
            
            }



            if (MediaPlayer.GameHasControl == true)
            {
                
                FrameworkDispatcher.Update();
                me.Stop();
                me.Volume = 11;
                me.Source = new Uri("Sounds/Serpentine Trek.mp3", UriKind.Relative);
            }

          




            //Player Health and Mana
            //Health
            //Getting Player Health
            if (petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints))
            {

                petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints);
                if (petChose.healthPoints <= 0)
                {
                    petChose.healthPoints = 1;
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                    petChose.HealthPoints.Save();

                }
                else
                {
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                }

            }
            //Getting Player MaxHealth
            if (petChose.MaxHealthPoints.TryGetValue("maxHealthPoints", out petChose.maxHealthPoints))
            {
                petChose.MaxHealthPoints.TryGetValue("maxHealthPoints", out petChose.maxHealthPoints);
                txtMaxHealthPoints.Text = petChose.maxHealthPoints.ToString();
            }

            //Mana
            //Getting Player Mana
            if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
            {
                petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                if (petChose.manaPoints <= 0)
                {
                    petChose.manaPoints = 0;
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                    petChose.ManaPoints.Save();

                }
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
            }
            //Getting Player MaxMana
            if (petChose.MaxManaPoints.TryGetValue("maxManaPoints", out petChose.maxManaPoints))
            {
                petChose.MaxManaPoints.TryGetValue("maxManaPoints", out petChose.maxManaPoints);
                txtMaxManaPoints.Text = petChose.maxManaPoints.ToString();
            }


            //Getting Players Points
            if (petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints))
            {
                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                txtPlayersPoints.Text = petChose.petPoints.ToString();
            }
            //Getting Players Items
            //Potion
            if (petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion))
            {

                petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion);
                txtTotalPotion.Text = petChose.petPotion.ToString();
            }
            //XPotion
            if (petChose.PetPotion.TryGetValue("petXPotion", out petChose.petXPotion))
            {
                int.TryParse(txtTotalXPotion.Text, out totalXPotion);
                petChose.PetXPotion.TryGetValue("petXPotion", out petChose.petXPotion);

            }
            //Mana Potion
            if (petChose.ManaPotion.TryGetValue("manaPotion", out petChose.manaPotion))
            {
                petChose.ManaPotion.TryGetValue("manaPotion", out petChose.manaPotion);
                txtTotalManaPotion.Text = petChose.manaPotion.ToString();

            }
            //Holy Water
            if (petChose.HolyWater.TryGetValue("holyWater", out petChose.holyWater))
            {
                petChose.HolyWater.TryGetValue("holyWater", out petChose.holyWater);
                txtTotalHolyWater.Text = petChose.holyWater.ToString();
            }
            //Spells
            //Lighting
            if (petChose.PetLighting.TryGetValue("petLighting", out petChose.petLighting))
            {
                petChose.PetLighting.TryGetValue("petLighting", out petChose.petLighting);
            }
            //Fire
            if (petChose.PetFire.TryGetValue("petFire", out petChose.petFire))
            {
                petChose.PetFire.TryGetValue("petFire", out petChose.petFire);
            }
            //Heal
            if (petChose.PetHeal.TryGetValue("petHeal", out petChose.petHeal))
            {
                petChose.PetHeal.TryGetValue("petHeal", out petChose.petHeal);

            }
            //Quake
            if (petChose.PetQuake.TryGetValue("petQuake", out petChose.petQuake))
            {
                petChose.PetQuake.TryGetValue("petQuake", out petChose.petQuake);
            }
            //Ice
            if (petChose.PetIce.TryGetValue("petIce", out petChose.petIce))
            {
                petChose.PetIce.TryGetValue("petIce", out petChose.petIce);
            }
            //Shield
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);
                if (petChose.petSheild > 1)
                {
                    petChose.petSheild = 1;
                    //Save Sheild
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();
                }

            }
            //Scan
            if (petChose.PetScan.TryGetValue("petScan", out petChose.petScan))
            {
                petChose.PetScan.TryGetValue("petScan", out petChose.petScan);
            }
            //Dark Matter
            if (petChose.PetDark.TryGetValue("petDark", out petChose.petDark))
            {
                petChose.PetDark.TryGetValue("petDark", out petChose.petDark);
            }
            //Drain
            if (petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain))
            {
                petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain);
            }
            //GunSlinger
            if (petChose.PetGunSlinger.TryGetValue("petGunSlinger", out petChose.petGunSlinger))
            {
                petChose.PetGunSlinger.TryGetValue("petGunSlinger", out petChose.petGunSlinger);
            }
            //Poison
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {
                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);
                if (petChose.petPoison > 1)
                {
                    petChose.petPoison = 1;

                 
                    //Save Poison
                    petChose.PetPoison.Remove("petPoison");
                    petChose.PetPoison.Add("petPoison", petChose.petPoison);
                    petChose.PetPoison.Save();

                }
            }
            //Thunder
            if (petChose.PetThunder.TryGetValue("petThunder", out petChose.petThunder))
            {
                petChose.PetThunder.TryGetValue("petThunder", out petChose.petThunder);

            }
            //Inferno
            if (petChose.PetInferno.TryGetValue("petInferno", out petChose.petInferno))
            {
                petChose.PetInferno.TryGetValue("petInferno", out petChose.petInferno);
            }
            //CureAll
            if(petChose.PetCureAll.TryGetValue("petCureAll", out petChose.petCureAll))
            {
                petChose.PetCureAll.TryGetValue("petCureAll", out petChose.petCureAll);
            
            }
            //Blizzard
            if (petChose.PetBlizzard.TryGetValue("petBlizzard", out petChose.petBlizzard)) 
            {
                petChose.PetBlizzard.TryGetValue("petBlizzard", out petChose.petBlizzard);

            }
            //Earth
            if (petChose.PetEarth.TryGetValue("petEarth", out petChose.petEarth)) 
            {
                petChose.PetEarth.TryGetValue("petEarth", out petChose.petEarth);

            }
            //Counter Attack
            if (petChose.PetCounterAttack.TryGetValue("petCounterAttack", out petChose.petCounterAttack)) 
            {
                petChose.PetCounterAttack.TryGetValue("petCounterAttack", out petChose.petCounterAttack);
            }
            //Fallen Angels
            if(petChose.PetFallenAngels.TryGetValue("petFallenAngels", out petChose.petFallenAngels))
            {
            petChose.PetFallenAngels.TryGetValue("petFallenAngels", out petChose.petFallenAngels);
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


           

            //STORYBOARD EYES
            //storyEyes.Begin();




            //EXP
            //Getting Pets EXP

            if (petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints))
            {
                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                txtPlayerExp.Text = petChose.expPoints.ToString();
            }
            if (petChose.PetLevel.TryGetValue("petLevel", out petChose.petLevel))
            {
                petChose.PetLevel.TryGetValue("petLevel", out petChose.petLevel);
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
            {
                petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
            }
            if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
            {
                petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
            }
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if (petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP))
            {
                petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP);

            }
            if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
            {
                petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
            }


            txtAttackLevel.Text = petChose.attackUP.ToString();
            txtManaAttackLevel.Text = petChose.manaAttackUp.ToString();
            txtSpeedLevel.Text = petChose.speedUP.ToString();
            txtSpritualPowerLevel.Text = petChose.spiritualAttackUP.ToString();
            txtDefenseLevel.Text = petChose.defenseUP.ToString();

            if (petChose.petLevel > 1 && petChose.townWantingToGo ==0 )
            {
                if(petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo))
                {
                    petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo);
                }
                MessageBoxResult reset;
                reset = MessageBox.Show("You will now find a reset stats button under stats, which is found in your profile, . This allows you to redistribute your power points. Also, Having trouble leveling up? Click the reset button, you will need to redistribute your points again, but the problem will be fixed. Thank you for all the feedback.", "Stats", MessageBoxButton.OKCancel);
               
                if (reset == MessageBoxResult.OK)
                {
                    petChose.TownWantingToGo.Remove("townWantingToGo");
                  petChose.TownWantingToGo.Add("townWantingToGo",1);
                    petChose.TownWantingToGo.Save();
                }
            }


            //The Level Ups
            if (petChose.expPoints >= 0 && petChose.expPoints <= 250)
            {

                txtPlayerLevel.Text = 1.ToString();
                txtPlayerNextLevel.Text = (250 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 500);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 10);
                petChose.MaxManaPoints.Save();

            }
            if (petChose.expPoints >= 251 && petChose.expPoints <= 800)
            {
                txtPlayerLevel.Text = 2.ToString();
                txtPlayerNextLevel.Text = (800 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 550);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 15);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 0)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();


                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 1);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 801 && petChose.expPoints <= 1500)
            {
                txtPlayerLevel.Text = 3.ToString();
                txtPlayerNextLevel.Text = (1500 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 600);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 20);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 1)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();

                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 2);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 1501 && petChose.expPoints <= 2500)
            {
                txtPlayerLevel.Text = 4.ToString();
                txtPlayerNextLevel.Text = (2500 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 650);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 25);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 2)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 3);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 2501 && petChose.expPoints <= 3500)
            {
                txtPlayerLevel.Text = 5.ToString();
                txtPlayerNextLevel.Text = (3500 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 700);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 30);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 3)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 4);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 3501 && petChose.expPoints <= 4700)
            {
                txtPlayerLevel.Text = 6.ToString();
                txtPlayerNextLevel.Text = (4700 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 800);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 35);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 4)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 5);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 4701 && petChose.expPoints <= 7500)
            {
                txtPlayerLevel.Text = 7.ToString();
                txtPlayerNextLevel.Text = (7500 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 900);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 40);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 5)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 6);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 7501 && petChose.expPoints <= 11000)
            {
                txtPlayerLevel.Text = 8.ToString();
                txtPlayerNextLevel.Text = (11000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1000);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 45);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 6)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 7);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 11001 && petChose.expPoints <= 18000)
            {
                txtPlayerLevel.Text = 9.ToString();
                txtPlayerNextLevel.Text = (18000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1100);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 50);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 7)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 8);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 18001 && petChose.expPoints <= 30000)
            {
                txtPlayerLevel.Text = 10.ToString();
                txtPlayerNextLevel.Text = (30000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1200);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 55);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 8)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 9);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 30001 && petChose.expPoints <= 45000)
            {
                txtPlayerLevel.Text = 11.ToString();
                txtPlayerNextLevel.Text = (45000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1300);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 60);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 9)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 10);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 45001 && petChose.expPoints <= 65000)
            {
                txtPlayerLevel.Text = 12.ToString();
                txtPlayerNextLevel.Text = (65000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1400);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 65);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 10)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 11);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 65001 && petChose.expPoints <= 87000)
            {
                txtPlayerLevel.Text = 13.ToString();
                txtPlayerNextLevel.Text = (85000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1500);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 70);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 11)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 12);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 85001 && petChose.expPoints <= 101777)
            {
                txtPlayerLevel.Text = 14.ToString();
                txtPlayerNextLevel.Text = (101777 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1600);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 75);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 12)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 13);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 101778 && petChose.expPoints <= 130000)
            {
                txtPlayerLevel.Text = 15.ToString();
                txtPlayerNextLevel.Text = (130000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 1800);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 80);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 13)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 14);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 130001 && petChose.expPoints <= 1600000)
            {
                txtPlayerLevel.Text = 16.ToString();
                txtPlayerNextLevel.Text = (160000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 2000);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 85);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 14)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 15);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 160001 && petChose.expPoints <= 200000)
            {
                txtPlayerLevel.Text = 17.ToString();
                txtPlayerNextLevel.Text = (200000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 2200);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 90);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 15)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 16);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 200001 && petChose.expPoints <= 250000)
            {
                txtPlayerLevel.Text = 18.ToString();
                txtPlayerNextLevel.Text = (250000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 2500);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 90);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 16)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 17);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 250001 && petChose.expPoints <= 310000)
            {
                txtPlayerLevel.Text = 19.ToString();
                txtPlayerNextLevel.Text = (310000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 2800);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 95);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 17)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 18);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 310001 && petChose.expPoints <= 380000)
            {
                txtPlayerLevel.Text = 20.ToString();
                txtPlayerNextLevel.Text = (380000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 3100);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 100);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 18)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 19);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 380001 && petChose.expPoints <= 470000)
            {
                txtPlayerLevel.Text = 21.ToString();
                txtPlayerNextLevel.Text = (470000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 3500);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 110);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 19)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 20);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 470001 && petChose.expPoints <= 570000)
            {
                txtPlayerLevel.Text = 22.ToString();
                txtPlayerNextLevel.Text = (570000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 4000);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 115);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 20)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 21);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 570001 && petChose.expPoints <= 680000)
            {
                txtPlayerLevel.Text = 23.ToString();
                txtPlayerNextLevel.Text = (680000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 4500);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 120);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 21)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 22);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 1);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 680001 && petChose.expPoints <= 790000)
            {
                txtPlayerLevel.Text = 24.ToString();
                txtPlayerNextLevel.Text = (790000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 4800);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 125);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 22)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 23);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 1);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
            if (petChose.expPoints >= 790001 && petChose.expPoints <= 1500000)
            {
                txtPlayerLevel.Text = 25.ToString();
                txtPlayerNextLevel.Text = (1500000 - petChose.expPoints).ToString();
                petChose.MaxHealthPoints.Remove("maxHealthPoints");
                petChose.MaxHealthPoints.Add("maxHealthPoints", 5000);
                petChose.MaxHealthPoints.Save();
                petChose.MaxManaPoints.Remove("maxManaPoints");
                petChose.MaxManaPoints.Add("maxManaPoints", 130);
                petChose.MaxManaPoints.Save();
                if (petChose.petLevel == 23)
                {
                    if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                    {
                        petChose.Pause.TryGetValue("pause", out petChose.pause);
                    }


                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 1);
                    petChose.Pause.Save();
                    canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 24);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 1);
                    petChose.UpgradePoints.Save();
                    if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                    {
                        petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                    }
                    txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                }
            }
   
   
   //Walking Obar Section  
            if (petChose.petPoints < 100 && petChose.healthPoints == 1)
            {
                MessageBox.Show("Do not fear, I shall help you.");
                petChose.healthPoints = petChose.maxHealthPoints;
                txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                //Save playerHealth
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                petChose.HealthPoints.Remove("healthPoints");
                petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                petChose.HealthPoints.Save();
                petChose.healthPoints = petChose.maxHealthPoints;
                txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
            } 
            dog.Visibility = System.Windows.Visibility.Collapsed;
            cat.Visibility = System.Windows.Visibility.Collapsed;
            evilButterfly.Visibility = System.Windows.Visibility.Collapsed;
            pickie.Visibility = System.Windows.Visibility.Collapsed;
            monkey.Visibility = System.Windows.Visibility.Collapsed;
            iceWizard.Visibility = System.Windows.Visibility.Collapsed;
            fireWizard.Visibility = System.Windows.Visibility.Collapsed;
            zombie.Visibility = System.Windows.Visibility.Collapsed;
            robot.Visibility = System.Windows.Visibility.Collapsed;
            eye.Visibility = System.Windows.Visibility.Collapsed;
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            if (petChose.Quest.TryGetValue("quest", out petChose.quest))
            {
                petChose.Quest.TryGetValue("quest", out petChose.quest);

            }
            if (petChose.ChurchCreature.TryGetValue("churchCreature", out petChose.quest))
            {
                petChose.ChurchCreature.TryGetValue("churchCreature", out petChose.quest);
            }
            if (petChose.quest == 2)
            {
                ViewObar_Copy.Visibility = System.Windows.Visibility.Collapsed;
                GiantOrc.Visibility = System.Windows.Visibility.Collapsed;
            
            }
            VeraMoving.Begin();
            if (petChose.gameStarted == 21)
            {
                storyWelcomeToObar.Begin();
              

            }
            if (petChose.gameStarted == 2)
            {
                storyWelcomeToObar.Begin();


            }
            if (petChose.gameStarted == 15)
            {
                storyVeraSpeak1.Begin();
            
            }
            //if (petChose.gameStarted >= 16)
            //{
            //    Nevi.Visibility = System.Windows.Visibility.Visible;
            //    btnNevi.Visibility = System.Windows.Visibility.Visible ;
            //}
            if (petChose.DistanceWalked.TryGetValue("distanceWalked", out petChose.distanceWalked))
            {
                petChose.DistanceWalked.TryGetValue("distanceWalked", out petChose.distanceWalked);
            
            }
            if (petChose.DistanceToTown.TryGetValue("distanceToTown", out petChose.distanceToTown))
            {
                petChose.DistanceToTown.TryGetValue("distanceToTown", out petChose.distanceToTown);
               
            }
            if (petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo))
            {
                petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo);
            }
            if (petChose.TownIn.TryGetValue("townIn", out petChose.townIn)) 
            {
                petChose.TownIn.TryGetValue("townIn", out petChose.townIn);
            }
            canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Collapsed;
            canvasChurch.Visibility = System.Windows.Visibility.Collapsed;
        }
       
                                          //End of Loading everything on page//
                                        /////////////////////////////////////////////////////////












        //Level Up System     
        private void btnContinueLvlUp_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 1)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 0);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 1);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.upgradePoints == 0)
            {
                canvasLevelUp.Visibility = System.Windows.Visibility.Collapsed;
                btnVigorUp.Visibility = System.Windows.Visibility.Visible;
                btnAttackUp.Visibility = System.Windows.Visibility.Visible;
                btnManaUp.Visibility = System.Windows.Visibility.Visible;
                btnDefenseUp.Visibility = System.Windows.Visibility.Visible;
                btnSpeedUp.Visibility = System.Windows.Visibility.Visible;
            }
            else 
            {
                MessageBox.Show("You still need to upgrade.");
            }
            }

        private void btnAttackUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            //Upgrade limit 10
            if (petChose.attackUP == 10)
            {
                if (petChose.Pause.TryGetValue("pause", out petChose.pause))
                {
                    petChose.Pause.TryGetValue("pause", out petChose.pause);
                }
                if (petChose.pause == 1)
                {
                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 2);
                    petChose.Pause.Save();
                }
                else if (petChose.pause == 2)
                {
                    petChose.Pause.Remove("pause");
                    petChose.Pause.Add("pause", 3);
                    petChose.Pause.Save();
                }
                btnUpgrade.Visibility = System.Windows.Visibility.Collapsed;
                upgrade = 1;
                txtUpgradeDecription.Text = "Upgrade  Attack: Increases your regular attack.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                upgrade = 1;
                btnUpgrade.Visibility = System.Windows.Visibility.Visible;
                txtUpgradeDecription.Text = "Upgrade  Attack: Increases your regular attack.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnManaUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 1)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 3);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.manaAttackUp == 10)
            {
                btnUpgrade.Visibility = System.Windows.Visibility.Collapsed;
                upgrade = 2;
                txtUpgradeDecription.Text = "Upgrade Mana Spells: Increase damage and healing";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                upgrade = 2;
                btnUpgrade.Visibility = System.Windows.Visibility.Visible;
                txtUpgradeDecription.Text = "Upgrade Mana Spells: Increase damage and healing";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnDefenseUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 1)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 3);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.defenseUP == 10)
            {
                btnUpgrade.Visibility = System.Windows.Visibility.Collapsed;
                upgrade = 4;
                txtUpgradeDecription.Text = "Upgrade Defense: Take less damge.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                upgrade = 4;
                btnUpgrade.Visibility = System.Windows.Visibility.Visible;
                txtUpgradeDecription.Text = "Upgrade Defense: Take less damge.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnVigorUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 1)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 3);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.spiritualAttackUP == 10)
            {
                btnUpgrade.Visibility = System.Windows.Visibility.Collapsed;
                upgrade = 5;
                txtUpgradeDecription.Text = "Upgrade Spirit: Increase spirit damage and unlock new spirit attacks.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                upgrade = 5;
                btnUpgrade.Visibility = System.Windows.Visibility.Visible;
                txtUpgradeDecription.Text = "Upgrade Spirit: Increase spirit damage and unlock new spirit attacks.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnSpeedUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 1)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 3);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.speedUP == 10)
            {
                btnUpgrade.Visibility = System.Windows.Visibility.Collapsed;
                upgrade = 3;
                txtUpgradeDecription.Text = "Upgrade Speed: Increasing speed allows you a better chance to perform back to back attacks.";
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                upgrade = 3;
                txtUpgradeDecription.Text = "Upgrade Speed: Increasing speed allows you a better chance to perform back to back attacks.";
                btnUpgrade.Visibility = System.Windows.Visibility.Visible;
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void btnCancelUpgrade_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 1);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 3)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Collapsed;
        }
//Upgrade Button
        private void btnUpgrade_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 2)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 1);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 3)
            {
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
            {
                petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
            }
            if (petChose.upgradePoints > 0)
            {
                if (upgrade == 1)
                {
                    if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                    {
                        petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                    }
                    //attackUP
                    petChose.AttackUP.Remove("attackUP");
                    petChose.AttackUP.Add("attackUP",petChose.attackUP + 1);
                    petChose.AttackUP.Save();
                    
                }
                if (upgrade == 2)
                {
                    if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                    {
                        petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                    }
                    //ManaUp
                    petChose.ManaAttackUP.Remove("manaAttackUp");
                    petChose.ManaAttackUP.Add("manaAttackUp", petChose.manaAttackUp + 1);
                    petChose.ManaAttackUP.Save();
                 
                }
                if (upgrade == 3)
                {
                    if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                    {
                        petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                    }
                    //speedUP
                    petChose.SpeedUP.Remove("speedUP");
                    petChose.SpeedUP.Add("speedUP",petChose.speedUP+ 1);
                    petChose.SpeedUP.Save();
                
                }
                if (upgrade == 4)
                {
                    if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                    {
                        petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                    }
                    //Defense
                    petChose.DefenseUP.Remove("petDefenseUP");
                    petChose.DefenseUP.Add("petDefenseUP",petChose.defenseUP + 1);
                    petChose.DefenseUP.Save();
                   
                }
                if (upgrade == 5)
                {
                    if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                    {
                        petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                    }
                    //Spirit
                    petChose.SpiritualAttackUP.Remove("spiritAttackUP");
                    petChose.SpiritualAttackUP.Add("spiritAttackUP",petChose.spiritualAttackUP + 1);
                    petChose.SpiritualAttackUP.Save();
                 
                }

                petChose.UpgradePoints.Remove("upgradePoints");
                petChose.UpgradePoints.Add("upgradePoints", petChose.upgradePoints - 1);
                petChose.UpgradePoints.Save();
                txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
                if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                {
                    petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                }
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }
                if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                {
                    petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                }
                if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
                {
                    petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
                }
                if (petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP))
                {
                    petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP);

                }
                if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
                {
                    petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
                }
                //Updating The Levels
                txtAttackLevel.Text = petChose.attackUP.ToString();
                txtManaAttackLevel.Text = petChose.manaAttackUp.ToString();
                txtSpeedLevel.Text = petChose.speedUP.ToString();
                txtSpritualPowerLevel.Text = petChose.spiritualAttackUP.ToString();
                txtDefenseLevel.Text = petChose.defenseUP.ToString();
                txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();

                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Collapsed;
            }
            else 
            {
                MessageBox.Show("You don't have anymore upgrade points");
            }
        }
          private void btnStats_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
        }
        
                                    //The Button for Store,Items and Fight//
                                   //////////////////////////////////////////////////////////////

                                 ///////////////////Start Of Shop Area//////////////////

   //Store Buttons
        //Open and Close Buttons
        private void btnShop_Click(object sender, RoutedEventArgs e)//OpenShop
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            if (petChose.petLighting == 1) { btnBuyLigtning.IsHitTestVisible = buttonEnable; LightningDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtLightning.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petFire == 1) { btnBuyFire.IsHitTestVisible = buttonEnable; FireDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtFire.Visibility= System.Windows.Visibility.Visible;}
            if (petChose.petIce == 1) { btnBuyIce.IsHitTestVisible = buttonEnable; IceDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtIce.Visibility= System.Windows.Visibility.Visible; }
            if (petChose.petHeal == 1) {btnBuyHeal.IsHitTestVisible = buttonEnable; HealDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtHeal.Visibility = System.Windows.Visibility.Visible;}
            if (petChose.petQuake == 1) {btnBuyQuake.IsHitTestVisible = buttonEnable; QuakeDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtQuake.Visibility = System.Windows.Visibility.Visible;}
            if (petChose.petScan == 1) { btnBuyScan.IsHitTestVisible = buttonEnable; ScanDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtScan.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petDrain == 1) { btnBuyDrain.IsHitTestVisible = buttonEnable; drainDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtDrain.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petSheild == 1) { btnBuyShield.IsHitTestVisible = buttonEnable; ShieldDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtShield.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petGunSlinger == 1) { btnGunSlinger.IsHitTestVisible = buttonEnable; GunSlingerDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtGunSlinger.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petPoison == 1) { btnBuyPoison.IsHitTestVisible = buttonEnable; PoisonDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtPoison.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petThunder == 1) { btnBuyThunder.IsHitTestVisible = buttonEnable; ThunderDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtThunder.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petInferno == 1) { btnBuyInferno.IsHitTestVisible = buttonEnable; InfernoDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtInferno.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petBlizzard == 1) { btnBuyBlizzard.IsHitTestVisible = buttonEnable; BlizzardDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtBlizzard.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petCureAll == 1) { btnBuyCureAll.IsHitTestVisible = buttonEnable; CureAllDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtCureAll.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petEarth == 1) { btnBuyEarth.IsHitTestVisible = buttonEnable; EarthDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtEarth.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petCounterAttack == 1) { btnBuyCounterAttack.IsHitTestVisible = buttonEnable; CounterAttackDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtCounterAttack.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petFallenAngels == 1) { btnBuyFallenAngels.IsHitTestVisible = buttonEnable; FallenAngelDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtFallenAngel.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petDark == 1) { btnDarkMatter.IsHitTestVisible = buttonEnable; DarkDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtDarkMatter.Visibility = System.Windows.Visibility.Visible; }
            txtShopPlayerPoints.Text = petChose.petPoints.ToString();
           
            canvasShop.Visibility = System.Windows.Visibility.Visible;
        
        
        }//
        private void btnCancelStore_Click(object sender, RoutedEventArgs e)//CloseShop
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            canvasShop.Visibility = System.Windows.Visibility.Collapsed;}//

        private void btnCancelBuy_Click(object sender, RoutedEventArgs e)//Close information of item canvas
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
    //Pictures of the Items
        HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
        Xpotion.Visibility = System.Windows.Visibility.Collapsed;
        ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
        HolyWater.Visibility = System.Windows.Visibility.Collapsed;
        Lightning.Visibility = System.Windows.Visibility.Collapsed;
        Fire.Visibility = System.Windows.Visibility.Collapsed;
        Ice.Visibility = System.Windows.Visibility.Collapsed;
        Heal.Visibility = System.Windows.Visibility.Collapsed;
        Quake.Visibility = System.Windows.Visibility.Collapsed;
        Scan.Visibility = System.Windows.Visibility.Collapsed;
        Dark.Visibility = System.Windows.Visibility.Collapsed;
        Shield.Visibility = System.Windows.Visibility.Collapsed;
        GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
        Poison.Visibility = System.Windows.Visibility.Collapsed;
        Thunder.Visibility = System.Windows.Visibility.Collapsed;
        Inferno.Visibility = System.Windows.Visibility.Collapsed;
        Blizzard.Visibility = System.Windows.Visibility.Collapsed;
        CureAll.Visibility = System.Windows.Visibility.Collapsed;
        CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
        Earth.Visibility = System.Windows.Visibility.Collapsed;
        FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

        canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
        }   
    
                                             //Actual Items to buy(When user clicks on the items).
                                            //////////////////////////////////////////////////////////////////////////////
//Items Health and Mana
        //Potion
        private void btnBuyPoition_Click(object sender, RoutedEventArgs e)//opens buying option
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Visible;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
                //Gives information about potion
            itemSelected = 1;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "A low end remedy that will replenish 500 Health";
            txtPointsForItemToBuy.Text = "50";
        }
                  
         //XPotion
        private void btnButXPotion_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Visible;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            //Gives information about potion
            itemSelected = 2;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
           
            txtItemAndDescription.Text = "A Middle end remedy that will replenish 1000 Health";
            txtPointsForItemToBuy.Text = "125";
        }
                   
        //Mana Potion
        private void btnBuyManaPotion_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Visible;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 3;
           
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
                txtItemAndDescription.Text = "A potion that replenishes 50 Mana";
                txtPointsForItemToBuy.Text = "75";
        }
                     
        //Holy Water
        private void btnBuyHolyWater_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Visible;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 4;
            
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Fully repenishes Mana by cleansing the soul  ";
            txtPointsForItemToBuy.Text = "150";
        }
//Spells
        //Lightning
        private void btnBuyLigtning_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Visible;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 5;
            txtItemName.Text = "Lightning Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Once this orb is released, the orb will enter the user who released it. Once the orb enters the body, casting Lightning will be learned. ";
            txtPointsForItemToBuy.Text = "500";
        }
       //Fire
        private void btnBuyFire_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Visible;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 6;
            txtItemName.Text = "Fire Orb";
            Fire.Visibility = System.Windows.Visibility.Visible;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Once this orb is released, the orb will enter the user who released it. Once the orb enters the body, casting Fire will be learned. ";
            txtPointsForItemToBuy.Text = "500";
        }
        //Ice
        private void btnBuyIce_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Visible;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 7;
            txtItemName.Text = "Ice Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Once this orb is released, the orb will enter the user who released it. Once the orb enters the body, casting Ice will be learned. ";
            txtPointsForItemToBuy.Text = "500";
        }
        //Heal
        private void btnBuyHeal_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Visible;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 8;
            txtItemName.Text = "Heal Orb";
            Heal.Visibility = System.Windows.Visibility.Visible;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Once this orb is released, the orb will enter the user who released it. Once the orb enters the body, the power of Healing will be learned. ";
            txtPointsForItemToBuy.Text = "500";
        }
        //Quake
        private void btnBuyQuake_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Visible;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 9;
            txtItemName.Text = "Quake Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Once this orb is released, the orb will enter the user who released it. Once the orb enters the body, casting Quake will be learned. ";
            txtPointsForItemToBuy.Text = "1000";
        }
        //Dark Matter
        private void btnDarkMatter_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Visible;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 10;
            txtItemName.Text = "Dark Matter Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = " This orb has been kept in a bottle. The effects are unkown . ";
            txtPointsForItemToBuy.Text = "10000";
        }
        //Scan
        private void btnBuyScan_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Visible;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
           Drain.Visibility = System.Windows.Visibility.Collapsed;
           GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
           Poison.Visibility = System.Windows.Visibility.Collapsed;
           Thunder.Visibility = System.Windows.Visibility.Collapsed;
           Inferno.Visibility = System.Windows.Visibility.Collapsed;
           Blizzard.Visibility = System.Windows.Visibility.Collapsed;
           CureAll.Visibility = System.Windows.Visibility.Collapsed;
           CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
           Earth.Visibility = System.Windows.Visibility.Collapsed;
           FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 11;
           
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemName.Text = "Scan Orb";
            txtItemAndDescription.Text = "(-Ability-)  No Mana needed. Once the orb is realeased and enters the body, the user will learn the ability to scan. This allows you to enter every battle knowing the enemies Health and Weakness";
            txtPointsForItemToBuy.Text = "1000";
        }
        //Drain
        private void btnBuyDrain_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Visible;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 12;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemName.Text = "Drain Orb";
            txtItemAndDescription.Text = "(-Ability-)  No Mana needed. Once the orb is realeased and enters the body, the user will learn the ability to drain. This allows your soul to randomly drain from the enemy and gain either 7, 14, 21, or All mana points every time you perform a spirit attack. ";
            txtPointsForItemToBuy.Text = "1000";

        }
        //Shield
        private void btnBuyShield_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Visible;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 13;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemName.Text = "Shield Orb";
            txtItemAndDescription.Text = "Once this orb is released, the orb will enter the user who released it. Once the orb enters the body, casting Shield will be learned.  Block about half the damage inflicted by an enemy attack.  How long the spell lasts depends on your mana Level.  ";
            txtPointsForItemToBuy.Text = "2000";
        }
    //GunSlinger
        private void btnGunSlinger_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Visible;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 14;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemName.Text = "GunSlinger Orb";
            txtItemAndDescription.Text = "(-Ability-)  No Mana needed. Once the orb is realeased and enters the body, the user will become a master Gunslinger. This orb will double the damage you inflict on to an enemy when using your gun(Regular Attack)";
            txtPointsForItemToBuy.Text = "5000";
        }
    //Poison
        private void btnBuyPoison_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Visible;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 15;
            txtItemName.Text = "Poison Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = " Poison your enemies .  Everytime your enemy attacks you the enemy will be inflicted with damage.  How long the spell lasts and how much damage is inflicted depends on your mana Level.  ";
            txtPointsForItemToBuy.Text = "5000";
        }
        //Thunder
        private void btnBuyThunder_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Visible;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 16;
            txtItemName.Text = "Thunder Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Call upon a thunderstrom like no other. This is a ThunderStorm that is only heard about in storybooks, but with this orb you can make it a reality. This orb will only enter a user if the user has already taken in the lightning orb. ";
            txtPointsForItemToBuy.Text = "5000";
        }
        //Inferno
        private void btnBuyInferno_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Visible;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 17;
            txtItemName.Text = "Inferno Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Call upon a Fire that will devour your enimies. This orb will only enter a user if the user has already taken in the Fire Orb.";
            txtPointsForItemToBuy.Text = "5000";
        }
        //Blizzard
        private void btnBuyBlizzard_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Visible;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 18;
            txtItemName.Text = "Blizzard Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Call upon a blizzard that will give even the greatest of enemies the chills. This orb will only enter a user if the user has already taken in the Ice Orb. ";
            txtPointsForItemToBuy.Text = "5000";
        }
        //CureAll
        private void btnBuyCureAll_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Visible;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 19;
            txtItemName.Text = "Cure-All Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = " Call upon the hands of  an angel to come and replinish all your health. This orb will only enter a user if the user has already taken in the Heal Orb. ";
            txtPointsForItemToBuy.Text = "5000";
        }
        //Earth
        private void btnBuyEarth_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Visible;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            itemSelected = 20;
            txtItemName.Text = "Earth Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Call upon the Earth making your enemies fear that the end of days has arrived . This orb will only enter a user if the user has already taken in the Earth Orb. ";
            txtPointsForItemToBuy.Text = "5000";
        }
//CounterAttack
        private void btnBuyCounterAttack_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Visible;
            FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
            Earth.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected =21;
            txtItemName.Text = "Counter Attack Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "(-Ability-) Counter attack almost every attack an enemy performs on you(Counter attack depends on your speed level. the higher your speed the better chance of a counter attack occuring).  ";
            txtPointsForItemToBuy.Text = "10000";

        }

        //FallenAngels
        private void btnBuyFallenAngels_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
            Xpotion.Visibility = System.Windows.Visibility.Collapsed;
            ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
            HolyWater.Visibility = System.Windows.Visibility.Collapsed;
            Lightning.Visibility = System.Windows.Visibility.Collapsed;
            Fire.Visibility = System.Windows.Visibility.Collapsed;
            Ice.Visibility = System.Windows.Visibility.Collapsed;
            Heal.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Scan.Visibility = System.Windows.Visibility.Collapsed;
            Dark.Visibility = System.Windows.Visibility.Collapsed;
            Drain.Visibility = System.Windows.Visibility.Collapsed;
            Shield.Visibility = System.Windows.Visibility.Collapsed;
            GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
            Poison.Visibility = System.Windows.Visibility.Collapsed;
            Thunder.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            CureAll.Visibility = System.Windows.Visibility.Collapsed;
            CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
            FallenAngel.Visibility = System.Windows.Visibility.Visible;
            Earth.Visibility = System.Windows.Visibility.Collapsed;

            itemSelected = 22;
            txtItemName.Text = "Fallen Angels Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "Once this orb enters a worthy user, the user will be able to call upon the angels. Trumpets will play and angels will come.";
            txtPointsForItemToBuy.Text = "77777";
        }

   
 //Buy Button
        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
           
            
        
            
        
        
           
            
       
            //Potion
            if (itemSelected == 1)
            {
                //if not enough points show messeagebox
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 50) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");
                //subtract the amount of potion 150 from points.    
                if (Points >= 50)
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    //Save potion
                    petChose.petPoints = petChose.petPoints - 50;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    int.TryParse(txtTotalPotion.Text, out totalPotion);
                    petChose.petPotion = petChose.petPotion + 1;
                    petChose.PetPotion.Remove("petPotion");
                    petChose.PetPotion.Add("petPotion", petChose.petPotion);
                    petChose.PetPotion.Save();
                    txtTotalPotion.Text = petChose.petPotion.ToString();
                    HealthPotion.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            //XPotion
            if (itemSelected == 2)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 125) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");
                //subtract the amount of potion 1000 from points.    
                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 125;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    petChose.petXPotion = petChose.petXPotion + 1;
                    petChose.PetXPotion.Remove("petXPotion");
                    petChose.PetXPotion.Add("petXPotion", petChose.petXPotion);
                    petChose.PetXPotion.Save();
                    txtTotalXPotion.Text = petChose.petXPotion.ToString();
                    Xpotion.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            //Mana Potion
            if (itemSelected == 3)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 75) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 75;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    petChose.manaPotion = petChose.manaPotion + 1;
                    petChose.ManaPotion.Remove("manaPotion");
                    petChose.ManaPotion.Add("manaPotion", petChose.manaPotion);
                    petChose.ManaPotion.Save();
                    txtTotalManaPotion.Text = petChose.manaPotion.ToString();
                    ManaPotion.Visibility = System.Windows.Visibility.Collapsed;
                
                }
            }
            //Holy Water
            if (itemSelected == 4)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 150) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 150;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    petChose.holyWater = petChose.holyWater + 1;
                    petChose.HolyWater.Remove("holyWater");
                    petChose.HolyWater.Add("holyWater", petChose.holyWater);
                    petChose.HolyWater.Save();
                    txtTotalHolyWater.Text = petChose.holyWater.ToString();
                    HolyWater.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            //Spells
            //Lightning
            if (itemSelected == 5)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 500) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 500;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyLigtning.IsHitTestVisible = buttonEnable; 
                  
            
                    
                
                  
                    LightningDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    txtBoughtLightning.Visibility = System.Windows.Visibility.Visible;
                    petChose.petLighting = 1;
                    petChose.PetLighting.Remove("petLighting");
                    petChose.PetLighting.Add("petLighting", petChose.petLighting);
                    petChose.PetLighting.Save();
                    Lightning.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            //Fire
            if (itemSelected == 6)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 500) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 500;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyFire.IsHitTestVisible = buttonEnable; 
                    FireDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    txtBoughtFire.Visibility = System.Windows.Visibility.Visible;
                    petChose.petFire = 1;
                    petChose.PetFire.Remove("petFire");
                    petChose.PetFire.Add("petFire", petChose.petFire);
                    petChose.PetFire.Save();
                    Fire.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 7)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 500) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 500;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyIce.IsHitTestVisible = buttonEnable;
                    IceDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    txtBoughtIce.Visibility = System.Windows.Visibility.Visible;
                    petChose.petIce = 1;
                    petChose.PetIce.Remove("petIce");
                    petChose.PetIce.Add("petIce", petChose.petIce);
                    petChose.PetIce.Save();
                    Ice.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 8)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 500) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 500;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyHeal.IsHitTestVisible = buttonEnable;
                    HealDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    txtBoughtHeal.Visibility = System.Windows.Visibility.Visible;
                    petChose.petHeal = 1;
                    petChose.PetHeal.Remove("petHeal");
                    petChose.PetHeal.Add("petHeal", petChose.petHeal);
                    petChose.PetHeal.Save();
                    Heal.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 9)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 1000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 1000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyQuake.IsHitTestVisible = buttonEnable;	
                    txtBoughtQuake.Visibility = System.Windows.Visibility.Visible;
                    QuakeDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petQuake = 1;
                    petChose.PetQuake.Remove("petQuake");
                    petChose.PetQuake.Add("petQuake", petChose.petQuake);
                    petChose.PetQuake.Save();
                    Quake.Visibility = System.Windows.Visibility.Collapsed;
                 
                    
                }
            }
            if (itemSelected == 10)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 10000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 10000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnDarkMatter.IsHitTestVisible = buttonEnable;
                    txtBoughtDarkMatter.Visibility = System.Windows.Visibility.Visible;  
                    DarkDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petDark = 1;
                    petChose.PetDark.Remove("petDark");
                    petChose.PetDark.Add("petDark", petChose.petDark);
                    petChose.PetDark.Save();
                    Dark.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 11)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 1000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 1000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyScan.IsHitTestVisible = buttonEnable;
                    ScanDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    btnBuyScan.IsHitTestVisible = buttonEnable;
                    txtBoughtScan.Visibility = System.Windows.Visibility.Visible;
                    petChose.petScan = 1;
                    petChose.PetScan.Remove("petScan");
                    petChose.PetScan.Add("petScan", petChose.petScan);
                    petChose.PetScan.Save();
                    
                    Scan.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 12)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 1000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 1000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyDrain.IsHitTestVisible = buttonEnable;
                    drainDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    btnBuyDrain.IsHitTestVisible = buttonEnable;
                    txtBoughtDrain.Visibility = System.Windows.Visibility.Visible;
                    petChose.petDrain = 1;
                    petChose.PetDrain.Remove("petDrain");
                    petChose.PetDrain.Add("petDrain", petChose.petDrain);
                    petChose.PetDrain.Save();
                    Drain.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 13)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 2000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 2000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnBuyShield.IsHitTestVisible = buttonEnable;
                    txtBoughtShield.Visibility = System.Windows.Visibility.Visible;
                    ShieldDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petSheild = 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();
                    Shield.Visibility = System.Windows.Visibility.Collapsed;


                }
            
            
            }
            if (itemSelected == 14)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");
            
            
                else{

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                    btnGunSlinger.IsHitTestVisible = buttonEnable;
                    txtBoughtGunSlinger.Visibility = System.Windows.Visibility.Visible;
                    GunSlingerDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petGunSlinger = 1;
                    petChose.PetGunSlinger.Remove("petGunSlinger");
                    petChose.PetGunSlinger.Add("petGunSlinger", petChose.petGunSlinger);
                    petChose.PetGunSlinger.Save();
                    GunSlinger.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 15)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;
                    txtPlayersPoints.Text = petChose.petPoints.ToString();
                   btnBuyPoison.IsHitTestVisible = buttonEnable;
                    txtBoughtPoison.Visibility = System.Windows.Visibility.Visible;
                    PoisonDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoison = 1;
                    petChose.PetPoison.Remove("petPoison");
                    petChose.PetPoison.Add("petPoison", petChose.petPoison);
                    petChose.PetPoison.Save();
                    Poison.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if(itemSelected==16)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyThunder.IsHitTestVisible = buttonEnable;

                    txtBoughtThunder.Visibility = System.Windows.Visibility.Visible;

                    ThunderDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petThunder = 1;

                    petChose.PetThunder.Remove("petThunder");
                    petChose.PetThunder.Add("petThunder", petChose.petThunder);
                    petChose.PetThunder.Save();
                    Thunder.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 17)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyInferno.IsHitTestVisible = buttonEnable;

                    txtBoughtInferno.Visibility = System.Windows.Visibility.Visible;

                    InfernoDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petInferno = 1;

                    petChose.PetInferno.Remove("petInferno");
                    petChose.PetInferno.Add("petInferno", petChose.petInferno);
                    petChose.PetInferno.Save();
                    Inferno.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 18)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyBlizzard.IsHitTestVisible = buttonEnable;

                    txtBoughtBlizzard.Visibility = System.Windows.Visibility.Visible;

                   BlizzardDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petBlizzard = 1;

                    petChose.PetBlizzard.Remove("petBlizzard");
                    petChose.PetBlizzard.Add("petBlizzard", petChose.petBlizzard);
                    petChose.PetBlizzard.Save();
                    Blizzard.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 19)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyCureAll.IsHitTestVisible = buttonEnable;

                    txtBoughtCureAll.Visibility = System.Windows.Visibility.Visible;

                   CureAllDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petCureAll = 1;

                    petChose.PetCureAll.Remove("petCureAll");
                    petChose.PetCureAll.Add("petCureAll", petChose.petCureAll);
                    petChose.PetCureAll.Save();
                    CureAll.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 20)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyEarth.IsHitTestVisible = buttonEnable;

                    txtBoughtEarth.Visibility = System.Windows.Visibility.Visible;

                    EarthDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petEarth = 1;

                    petChose.PetEarth.Remove("petEarth");
                    petChose.PetEarth.Add("petEarth", petChose.petThunder);
                    petChose.PetEarth.Save();
                    Earth.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if (itemSelected == 21)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 10000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 10000;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyCounterAttack.IsHitTestVisible = buttonEnable;

                    txtBoughtCounterAttack.Visibility = System.Windows.Visibility.Visible;

                    CounterAttackDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petCounterAttack = 1;

                    petChose.PetCounterAttack.Remove("petCounterAttack");
                    petChose.PetCounterAttack.Add("petCounterAttack", petChose.petCounterAttack);
                    petChose.PetCounterAttack.Save();
                    CounterAttack.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            if(itemSelected ==22)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 77777) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 77777;

                    txtPlayersPoints.Text = petChose.petPoints.ToString();

                    btnBuyFallenAngels.IsHitTestVisible = buttonEnable;

                    txtBoughtFallenAngel.Visibility = System.Windows.Visibility.Visible;

                    FallenAngelDisplay.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petFallenAngels = 1;

                    petChose.PetFallenAngels.Remove("petFallenAngels");
                    petChose.PetFallenAngels.Add("petFallenAngels", petChose.petFallenAngels);
                    petChose.PetFallenAngels.Save();
                    FallenAngel.Visibility = System.Windows.Visibility.Collapsed;
                }
            }


            int.TryParse(txtPlayersPoints.Text, out Points);
            //Save Points
            petChose.PetPoints.Remove("petPoints");
            petChose.PetPoints.Add("petPoints", Points);
            petChose.PetPoints.Save();
            txtShopPlayerPoints.Text = petChose.petPoints.ToString();
        }
       
            
            
        //Confirms Bought Item;
        private void btnThankYou_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            canvasItemBought.Visibility = System.Windows.Visibility.Collapsed;
        }

        
      
    

                                      /////////End of Shop Area//////////
                                     ///////////////////////////////////////////////





                                    ///////////Your Item Inventory/////////////
                                   ////////////////////////////////////////////////////////
        
        private void btnItem_Click(object sender, RoutedEventArgs e)//OpenItems
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
        if (petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion))//Reading Potion
            {
                int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion);
                txtTotalPotion.Text = petChose.petPotion.ToString();      
            }
        if (petChose.PetPotion.TryGetValue("petXPotion", out petChose.petXPotion))//Reading XPotion
        {
            int.TryParse(txtTotalXPotion.Text, out totalXPotion);
            petChose.PetXPotion.TryGetValue("petXPotion", out petChose.petXPotion);
            txtTotalXPotion.Text = petChose.petXPotion.ToString();
        }

        if (petChose.ManaPotion.TryGetValue("manaPotion", out petChose.manaPotion)) //Reading Mana Potion 
        {
            int.TryParse(txtTotalManaPotion.Text, out petChose.manaPotion);
            petChose.ManaPotion.TryGetValue("manaPotion", out petChose.manaPotion);
            txtTotalManaPotion.Text = petChose.manaPotion.ToString();
            
        }

        if (petChose.HolyWater.TryGetValue("holyWater", out petChose.holyWater))//Reading Holy Water 
        {
            int.TryParse(txtTotalHolyWater.Text, out petChose.holyWater);
            petChose.HolyWater.TryGetValue("holyWater", out petChose.holyWater);
            txtTotalHolyWater.Text = petChose.holyWater.ToString();
        }
        
            if (petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints))//Getting Healthpoints
        {
            int.TryParse(txtPlayersHealthPoints.Text, out Health);
            petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints);
            txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
        }
            if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))//Getting ManaPoints
            {
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
            }
//Spells
            if (petChose.petLighting == 1) txtSpellLighting.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petFire == 1) txtSpellFire.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petIce == 1) txtSpellIce.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petQuake == 1) txtSpellQuake.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petDark == 1) txtSpellDarkMatter.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petSheild == 1) txtSpellShield.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petThunder == 1) txtSpellThunder.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petInferno == 1) txtSpellInferno.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petBlizzard == 1) txtSpellBlizzard.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petPoison == 1) txtSpellPoison.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petEarth == 1) txtSpellEarth.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petFallenAngels == 1) txtSpellFallenAngel.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petHeal == 1)
            {
                
                btnHeal.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.petCureAll == 1)
            {
                btnCureAll.Visibility = System.Windows.Visibility.Visible;
            }
           
 //Abillities           
            canvasItems.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petScan == 1) btnScanAbility.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petDrain == 1) btnDrainAbility.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petGunSlinger == 1) btnGunSlingerAbility.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petCounterAttack == 1) btnCounterAttack.Visibility = System.Windows.Visibility.Visible;
//Potions    
            if (petChose.petPotion >= 1)
            {
                btnPotionItemInv.Visibility = System.Windows.Visibility.Visible;
                txtTotalPotion.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.petXPotion >= 1)
            {
                btnXPotionItemInv.Visibility = System.Windows.Visibility.Visible;
                txtTotalXPotion.Visibility = System.Windows.Visibility.Visible;
            
            }
            if (petChose.manaPotion >= 1)
            {
                btnManaPotion.Visibility = System.Windows.Visibility.Visible;
                txtTotalManaPotion.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.holyWater >= 1)
            {
                btnHolyWater.Visibility = System.Windows.Visibility.Visible;
                txtTotalHolyWater.Visibility = System.Windows.Visibility.Visible;
            }
        }
 
        

                                       ////////////////////Using  items/////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////// 

       //Sets number to item to see which one the player pics
        //Health Items
        //Potion
        private void btnPotionItemInv_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 3);
            petChose.Pause.Save();
            itemBeingUsed = 1;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Potion: Replinish 500 Health.";
        }
        //XPotion
        private void btnXPotionItemInv_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 3);
            petChose.Pause.Save();
            itemBeingUsed = 2;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "XPotion: Replinish 1000 Health.";

        }
        //Mana Items
        //Mana Potion
        private void btnManaPotion_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 3);
            petChose.Pause.Save();
            itemBeingUsed = 3;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Mana Potion: Replinish 50 Mana. ";
        }
        //Holy Water   
        private void btnHolyWater_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 3);
            petChose.Pause.Save();
            itemBeingUsed = 4;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Holy Water: Cleanase your soul to replinish all Mana.";
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 3);
            petChose.Pause.Save();
            itemBeingUsed = 5;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Cast Heal: For 5MP Heal a small amount of Health";
        }
        private void btnCureAll_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 3);
            petChose.Pause.Save();
            itemBeingUsed = 6;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Cast Cure-All: Fully heal yourself 25MP ";
        }
    //Checks above to see which itembingused by the number given and does the action if player choses btnYesUseItem
       //Main Item Button that Holds all the items and sees if the user wants to use it and if so does all the actions    
        private void btnYesUseItem_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            if (itemBeingUsed == 1)
            {
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                if (petChose.petPotion > 0 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    UsingPotions.Begin();
                    petChose.petPotion = petChose.petPotion - 1;
                    petChose.healthPoints = petChose.healthPoints + 500;
                    
                    txtPlusHealth.Text = "+500" ;
                    storyPlusHealth.Begin();
                    petChose.healthPoints = petChose.healthPoints + playerHealing;
                    txtTotalPotion.Text = petChose.petPotion.ToString();
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save potion
                    int.TryParse(txtTotalPotion.Text, out totalPotion);
                    petChose.PetPotion.Remove("petPotion");
                    petChose.PetPotion.Add("petPotion", totalPotion);
                    petChose.PetPotion.Save();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out Health);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", Health);
                    petChose.HealthPoints.Save();
                    if (petChose.healthPoints > petChose.maxHealthPoints)
                    {
                        UsingPotions.Begin();
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save potion
                        int.TryParse(txtTotalPotion.Text, out totalPotion);
                        petChose.PetPotion.Remove("petPotion");
                        petChose.PetPotion.Add("petPotion", totalPotion);
                        petChose.PetPotion.Save();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out Health);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", Health);
                        petChose.HealthPoints.Save();
                    }
                }
                else if (petChose.petPotion == 0)
                {
                    MessageBox.Show("You have no more of this item. Buy some at the shop");
                }
                else if (petChose.healthPoints >= petChose.maxHealthPoints)
                { MessageBox.Show("Your already at full health"); 
                }      
            }
            if (itemBeingUsed == 2)
            {
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtTotalXPotion.Text, out petChose.petXPotion);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                if (petChose.petXPotion > 0 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    UsingPotions.Begin();
                    petChose.petXPotion = petChose.petXPotion - 1;
                    petChose.healthPoints = petChose.healthPoints + 1000;
                    txtPlusHealth.Text = "+1000";
                    storyPlusHealth.Begin();
                    txtTotalXPotion.Text = petChose.petXPotion.ToString();
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save XPotion
                    int.TryParse(txtTotalXPotion.Text, out totalXPotion);
                    petChose.PetXPotion.Remove("petXPotion");
                    petChose.PetXPotion.Add("petXPotion", totalXPotion);
                    petChose.PetXPotion.Save();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out Health);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", Health);
                    petChose.HealthPoints.Save();
                    if (petChose.healthPoints > petChose.maxHealthPoints)
                    {
                        UsingPotions.Begin();
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save XPotion
                        int.TryParse(txtTotalXPotion.Text, out totalXPotion);
                        petChose.PetXPotion.Remove("petXPotion");
                        petChose.PetXPotion.Add("petXPotion", totalXPotion);
                        petChose.PetXPotion.Save();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out Health);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", Health);
                        petChose.HealthPoints.Save();
                    }
                }
                else if (petChose.petXPotion == 0)
                {
                    MessageBox.Show("You have no more of this item. Buy some at the shop");
                }
                else if (petChose.healthPoints >= petChose.maxHealthPoints)
                { MessageBox.Show("You're already at full health"); 
                }
            }
            if (itemBeingUsed == 3)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtTotalManaPotion.Text, out petChose.manaPotion);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPotion > 0 && petChose.manaPoints < petChose.maxManaPoints)
                {
                    petChose.manaPotion = petChose.manaPotion - 1;
                    petChose.manaPoints = petChose.manaPoints + 50;
                    txtPlusMana.Text = "+50";
                    storyPlusMana.Begin();
                    txtTotalManaPotion.Text = petChose.manaPotion.ToString();
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                    //Save Mana Potion
                    int.TryParse(txtTotalManaPotion.Text, out petChose.manaPotion);
                    petChose.ManaPotion.Remove("manaPotion");
                    petChose.ManaPotion.Add("manaPotion", petChose.manaPotion);
                    petChose.ManaPotion.Save();
                    //Save Player Mana Points
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                    petChose.ManaPoints.Save();
                    if (petChose.manaPoints > petChose.maxManaPoints)
                    {
                        petChose.manaPoints = petChose.maxManaPoints;
                        txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                        //Save Mana Potion
                        int.TryParse(txtTotalManaPotion.Text, out petChose.manaPotion);
                        petChose.ManaPotion.Remove("manaPotion");
                        petChose.ManaPotion.Add("manaPotion", petChose.manaPotion);
                        petChose.ManaPotion.Save();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();
                    }
                }
                else if (petChose.manaPotion == 0)
                {
                    MessageBox.Show("You have no more of this item. Buy some at the shop");
                }
                else if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    MessageBox.Show("You're already at full Mana");
                }
            }
            if (itemBeingUsed == 4)
            {
                int.TryParse(txtTotalHolyWater.Text, out petChose.holyWater);
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);


                if (petChose.holyWater > 0 && petChose.manaPoints < petChose.maxManaPoints)
                {

                    petChose.holyWater = petChose.holyWater - 1;
                    petChose.manaPoints = petChose.maxManaPoints;
                    txtPlusMana.Text = "+"+ petChose.maxManaPoints;
                    storyPlusMana.Begin();
                    txtTotalHolyWater.Text = petChose.holyWater.ToString();
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                    //Holy Water
                    int.TryParse(txtTotalHolyWater.Text, out petChose.holyWater);
                    petChose.HolyWater.Remove("holyWater");
                    petChose.HolyWater.Add("holyWater", petChose.holyWater);
                    petChose.HolyWater.Save();
                    //Save Player Mana Points
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                    petChose.ManaPoints.Save();
                    if (petChose.manaPoints > petChose.maxManaPoints)
                    {
                        petChose.manaPoints = petChose.maxManaPoints;
                        txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                        //Holy Water
                        int.TryParse(txtTotalHolyWater.Text, out petChose.holyWater);
                        petChose.HolyWater.Remove("holyWater");
                        petChose.HolyWater.Add("holyWater", petChose.holyWater);
                        petChose.HolyWater.Save();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();
                    }
                }
                else if (petChose.holyWater == 0)
                {
                    MessageBox.Show("You have no more of this item. Buy some at the shop");
                }
                else if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    MessageBox.Show("You're already at full Mana");
                }
            }
            //Using Heal
            if (itemBeingUsed == 5)
            {
                Random Healing = new Random();
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);


                if (petChose.manaPoints >= 5 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    UsingPotions.Begin();
                    petChose.manaPoints = petChose.manaPoints - 5;
                    playerHealing = Healing.Next(95, 105);
                    txtPlusHealth.Text = "+" + playerHealing.ToString();
                    storyPlusHealth.Begin();
                    petChose.healthPoints = petChose.healthPoints +playerHealing *petChose.manaAttackUp;
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save Player Mana Points
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                    petChose.ManaPoints.Save();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                    petChose.HealthPoints.Save();
                    if (petChose.healthPoints > petChose.maxHealthPoints)
                    {
                        
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                        petChose.HealthPoints.Save();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();

                        if (petChose.manaPoints > petChose.maxManaPoints)
                        {
                            
                            petChose.manaPoints = petChose.maxManaPoints;
                            txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                            //Save Player Mana Points
                            int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                            petChose.ManaPoints.Remove("manaPoints");
                            petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                            petChose.ManaPoints.Save();
                            //Save playerHealth
                            int.TryParse(txtPlayersHealthPoints.Text, out Health);
                            petChose.HealthPoints.Remove("healthPoints");
                            petChose.HealthPoints.Add("healthPoints", Health);
                            petChose.HealthPoints.Save();
                        }
                    }
                }
                else if (petChose.manaPoints <= 5)
                {
                    MessageBox.Show("Not enough Mana");
                }
                else if (petChose.healthPoints >= petChose.maxHealthPoints)
                {
                    MessageBox.Show("You're already at full Health");
                }
            }
            //Using Cure All
            if (itemBeingUsed == 6)
            {
                Random Healing = new Random();
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);


                if (petChose.manaPoints >= 25 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    UsingPotions.Begin();
                    petChose.manaPoints = petChose.manaPoints - 25;
                   
                    txtPlusHealth.Text = "All";
                    storyPlusHealth.Begin();
                    petChose.healthPoints = petChose.maxHealthPoints;
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save Player Mana Points
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                    petChose.ManaPoints.Save();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                    petChose.HealthPoints.Save();
                    if (petChose.healthPoints > petChose.maxHealthPoints)
                    {

                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                        petChose.HealthPoints.Save();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();

                        if (petChose.manaPoints > petChose.maxManaPoints)
                        {

                            petChose.manaPoints = petChose.maxManaPoints;
                            txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                            //Save Player Mana Points
                            int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                            petChose.ManaPoints.Remove("manaPoints");
                            petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                            petChose.ManaPoints.Save();
                            //Save playerHealth
                            int.TryParse(txtPlayersHealthPoints.Text, out Health);
                            petChose.HealthPoints.Remove("healthPoints");
                            petChose.HealthPoints.Add("healthPoints", Health);
                            petChose.HealthPoints.Save();
                        }
                    }
                }
                else if (petChose.manaPoints <= 25)
                {
                    MessageBox.Show("Not enough Mana");
                }
                else if (petChose.healthPoints >= petChose.maxHealthPoints)
                {
                    MessageBox.Show("You're already at full Health");
                }
            }

        }
        //Complete StoryHealth
        private void UsingPotions_Completed(object sender, EventArgs e)
        {
            UsingPotions.Stop();
        }
        private void storyPlusHealth_Completed(object sender, EventArgs e)
        {
            storyPlusHealth.Stop();
        }
        private void storyPlusMana_Completed(object sender, EventArgs e)
        {
            storyPlusMana.Stop();
        }


        //Close the Item Use Canvas
        private void btnNoUseItem_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 2);
            petChose.Pause.Save();
            CanvasUseItem.Visibility = System.Windows.Visibility.Collapsed;
        }


        //Simply closes item canvas cancel button to close
        private void btnItemCancel_Click(object sender, RoutedEventArgs e)//CloseItems
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
      
        }
        




                                                              /////End of Item Invetory////
                                                             ///////////////////////////////////////////




                              //Fight Button//Also saves any changes made with points by purchasing things Select an Enemy
                                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        private void btnFight_Click(object sender, RoutedEventArgs e)

        {

            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();

            btnIconFight.Visibility = System.Windows.Visibility.Visible ;
            btnIconShop.Visibility = System.Windows.Visibility.Visible;
            btnProfile.Visibility = System.Windows.Visibility.Visible;
            
            
            int.TryParse(txtPlayersPoints.Text, out Points);
            //Save Points
            petChose.PetPoints.Remove("petPoints");
            petChose.PetPoints.Add("petPoints", Points);
            petChose.PetPoints.Save();
            //Close Shop and Item
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
            canvasShop.Visibility = System.Windows.Visibility.Collapsed;
            CanvasUseItem.Visibility = System.Windows.Visibility.Collapsed;
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
            //Save potion
            int.TryParse(txtTotalPotion.Text, out totalPotion);
            petChose.PetPotion.Remove("petPotion");
            petChose.PetPotion.Add("petPotion", totalPotion);
            petChose.PetPotion.Save();
            //Save XPotion
            int.TryParse(txtTotalXPotion.Text, out totalXPotion);
            petChose.PetXPotion.Remove("petXPotion");
            petChose.PetXPotion.Add("petXPotion", totalXPotion);
            petChose.PetXPotion.Save();
            //Save Mana Potion
            int.TryParse(txtTotalManaPotion.Text, out petChose.manaPotion);
            petChose.ManaPotion.Remove("manaPotion");
            petChose.ManaPotion.Add("manaPotion", petChose.manaPotion);
            petChose.ManaPotion.Save();
            //Holy Water
            int.TryParse(txtTotalHolyWater.Text, out petChose.holyWater);
            petChose.HolyWater.Remove("holyWater");
            petChose.HolyWater.Add("holyWater", petChose.holyWater);
            petChose.HolyWater.Save();
            //Save playerHealth
            int.TryParse(txtPlayersHealthPoints.Text, out Health);
            petChose.HealthPoints.Remove("healthPoints");
            petChose.HealthPoints.Add("healthPoints", Health);
            petChose.HealthPoints.Save();
            //Save playerMaxHealth
            int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
            petChose.MaxHealthPoints.Remove("maxHealthPoints");
            petChose.MaxHealthPoints.Add("maxHealthPoints", petChose.maxHealthPoints);
            petChose.MaxHealthPoints.Save();
            //Save playerMana
            int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
            petChose.ManaPoints.Remove("manaPoints");
            petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
            petChose.ManaPoints.Save();
            //Save playerMaxMana
            int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
            petChose.MaxManaPoints.Remove("maxManaPoints");
            petChose.MaxManaPoints.Add("maxManaPoints", petChose.maxManaPoints);
            petChose.MaxManaPoints.Save();
            PetsHome.Visibility = System.Windows.Visibility.Collapsed;
            HealthandMana.Visibility = System.Windows.Visibility.Collapsed;
            
            
           
            


            /////////////End of Fighting Button////////////
    
        
            
        }
    //Turn Sound Off or On
        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            if (checkSound.SoundEffectOffOrOn.TryGetValue("soundOffOrOn", out checkSound.soundOffOrOn))
            {
                checkSound.SoundEffectOffOrOn.TryGetValue("soundOffOrOn", out checkSound.soundOffOrOn);

            }
            if (checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn))
            {
                checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn);

            }
            if (checkSound.soundOffOrOn == 0)
            {
                checkSound.SoundEffectOffOrOn.Remove("soundOffOrOn");
                checkSound.SoundEffectOffOrOn.Add("soundOffOrOn", 1);
                checkSound.SoundEffectOffOrOn.Save();
                checkSound.MusicOffOrOn.Remove("musicOffOrOn");
                checkSound.MusicOffOrOn.Add("musicOffOrOn", 1);
                checkSound.MusicOffOrOn.Save();
                txtHealth.Visibility = System.Windows.Visibility.Collapsed;
            }

            if (checkSound.soundOffOrOn == 1)
            {
                checkSound.SoundEffectOffOrOn.Remove("soundOffOrOn");
                checkSound.SoundEffectOffOrOn.Add("soundOffOrOn", 0);
                checkSound.SoundEffectOffOrOn.Save();
                checkSound.MusicOffOrOn.Remove("musicOffOrOn");
                checkSound.MusicOffOrOn.Add("musicOffOrOn", 0);
                checkSound.MusicOffOrOn.Save();
                txtHealth.Visibility = System.Windows.Visibility.Visible;
            }
            
}
        
        
                                                     
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {

            e.Cancel = true;

        }

    
          
        
        
       
       

      

        

    
      

     

      

   

        

      

      


  
    

//Completed StoryBoards
        private void storyVeraSpeak1_Completed(object sender, EventArgs e)
        {
            storyVeraSpeak1.Stop();
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
          
        }
    //Button Action
        private void btnTalkToMasterAdalmun_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            if (petChose.gameStarted == 20 || petChose.gameStarted == 21 || petChose.gameStarted == 22)
            {
                storyIntro.Stop();
                storyConvo1.Begin();
            }
            if (petChose.gameStarted == 15)
            {
                storyConvo3.Begin();
                
            }
            if (petChose.gameStarted == 16)
            {
                storyConvo7.Begin();
            }
            }
        //StoryBoard
        private void storyBattleCreatureOfTheFallen_Completed(object sender, EventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            VeraMoving.Stop();
            petChose.GameStarted.Remove("gameStarted");
            petChose.GameStarted.Add("gameStarted", 12);
            petChose.GameStarted.Save();

      

            storyConvo2_8.Stop();
            storyBattleCreatureOfTheFallen.Stop();
            this.NavigationService.GoBack();
            
        }
        //Intro
        private void storyIntro_Completed(object sender, EventArgs e)
        {
            storyWelcomeToObar.Stop();
            storyIntro.Stop();
        }
        private void storyWelcomeToObar_Completed(object sender, EventArgs e)
        {
            storyIntro.Begin();
        }

        //Button Action
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }

            if (petChose.Quest.TryGetValue("quest", out petChose.quest))
            {
                petChose.Quest.TryGetValue("quest", out petChose.quest);

            }
            if (petChose.gameStarted == 20 || petChose.gameStarted == 21 || petChose.gameStarted == 22)
            {
                if (whichConversation == 0)
                {
                    storyConvo1.Stop();
                    storyConvo2.Begin();
                    whichConversation = whichConversation + 1;
                }
                else if (whichConversation == 1)
                {
                    storyConvo2.Stop();
                    StoryConvo2_1.Begin();
                    whichConversation = whichConversation + 1;
                }
                else if (whichConversation == 2)
                {
                    StoryConvo2_1.Stop();
                    storyConvo2_2.Begin();
                    whichConversation = whichConversation + 1;

                }
                else if (whichConversation == 3)
                {
                    storyConvo2_2.Stop();
                    storyConvo2_3.Begin();
                    whichConversation = whichConversation + 1;

                }
                else if (whichConversation == 4)
                {
                    storyConvo2_3.Stop();
                    petChose.GameStarted.Remove("gameStarted");
                    petChose.GameStarted.Add("gameStarted", 25);
                    petChose.GameStarted.Save();
                    Eli.Visibility = System.Windows.Visibility.Collapsed;
                    btnTalkToMasterAdalmun.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
///////////////////////////////////////////////////////////////////////
             //Second Part
            if (petChose.gameStarted == 23
               )
                {
                    storyVeraSpeak1.Stop();
                    if (whichConversation == 0)
                    {
                        storyConvo3.Stop();
                        storyConvo3_5.Begin();
                        whichConversation = whichConversation + 1;
                    }
                    else if (whichConversation == 1)
                    {
                        storyConvo3_5.Stop();
                        storyConvo3_6.Begin();
                        whichConversation = whichConversation + 1;
                    }
                    else if (whichConversation == 2)
                    {
                        storyConvo3_6.Stop();
                        storyConvo4.Begin();
                        whichConversation = whichConversation + 1;

                    }
                    else if (whichConversation == 3)
                    {
                        storyConvo4.Stop();
                        storyConvo5.Begin();
                        whichConversation = whichConversation + 1;

                    }
                    else if (whichConversation == 4)
                    {
                        storyConvo5.Stop();
                        storyConvo5_1.Begin();
                        whichConversation = whichConversation + 1;

                    }
                    else if (whichConversation == 5)
                    {
                        storyConvo5_1.Stop();
                        storyConvo6.Begin();
                        whichConversation = whichConversation + 1;
                    }
                    else if (whichConversation == 6)
                    {
                        whichConversation = 0;
                    
        }
                
                }
            
    //Third  part of talking to Master and NeviQuest

            if (petChose.gameStarted == 24)
            {
                if (petChose.Quest.TryGetValue("quest", out petChose.quest))
                {
                    petChose.Quest.TryGetValue("quest", out petChose.quest);

                }
             
                
                    storyConvo7.Stop();

                    if (NeviQuest == 1)
                    {
                        if (whichConversation == 0)
                        {
                            TalkingToNevi1.Stop();
                            TalkingToNevi2.Begin();

                        }
                    }
                    if (NeviQuest == 2)
                    {
                        TalkingToNeviYesHelp.Stop();
                        ViewObar.Visibility = System.Windows.Visibility.Collapsed;
                        ViewObar_Copy.Visibility = System.Windows.Visibility.Visible;
                        VeraTalkingQuest1.Begin();
                    }
                    if (NeviQuest == 3)
                    {
                        TalkingToNeviNoHelp.Stop();
                    }
                    if (NeviQuest == 4)
                    {
                        NeviQuest = 0;
                        TalkingToNevi3.Stop();
                        ViewObar.Visibility = System.Windows.Visibility.Collapsed;
                        ViewObar_Copy.Visibility = System.Windows.Visibility.Visible;
                        VeraTalkingQuest1.Begin();
                    }
                
            }
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
         
            btnIconFight.Visibility = System.Windows.Visibility.Collapsed;
            btnIconShop.Visibility = System.Windows.Visibility.Collapsed;
            btnProfile.Visibility = System.Windows.Visibility.Collapsed;
           
            HealthandMana.Visibility = System.Windows.Visibility.Visible;
            PetsHome.Visibility = System.Windows.Visibility.Visible;

        }
//Nevi
        private void btnActivateWaterWell_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GiantOrcQuest1.Begin();
            VeraTalkingQuest1.Stop();
            VeraTalkingQuest1pt2.Begin();
            canvasHelp_Copy.Visibility = System.Windows.Visibility.Visible;
        }
        private void GiantOrcQuest1_Completed(object sender, EventArgs e)
        {
            
        }
        private void btnBackToTownCenter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewObar_Copy.Visibility = System.Windows.Visibility.Collapsed;
            ViewObar.Visibility = System.Windows.Visibility.Visible;
            GiantOrcQuest1.Stop();
            VeraTalkingQuest1.Stop();
            VeraTalkingQuest1pt2.Stop();
        }

        private void btnNevi_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Quest.TryGetValue("quest", out petChose.quest))
            {
                petChose.Quest.TryGetValue("quest", out petChose.quest);

            }
            if (petChose.quest == 0)
            {
                NeviQuest = 1;
                TalkingToNevi1.Begin();
            }
            if (petChose.quest == 1)
            {
                NeviQuest = 4;
                TalkingToNevi3.Begin();
            }
            if (petChose.quest == 2)
            {
                TalkingToNeviAfterQuest.Begin();
            }
            }
        private void TalkingToNeviAfterQuest_Completed(object sender, EventArgs e)
        {
            TalkingToNeviAfterQuest.Stop();
        }
    //Decsion 1
        private void btnHelp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            canvasHelp.Visibility = System.Windows.Visibility.Collapsed;
            //Potion
            if (petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion))
            {

                petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion);
               
            }
            //XPotion
            if (petChose.PetPotion.TryGetValue("petXPotion", out petChose.petXPotion))
            {
                int.TryParse(txtTotalXPotion.Text, out totalXPotion);
             

            }
            //Mana Potion
            if (petChose.ManaPotion.TryGetValue("manaPotion", out petChose.manaPotion))
            {
                petChose.ManaPotion.TryGetValue("manaPotion", out petChose.manaPotion);
            

            }
            if (petChose.Quest.TryGetValue("quest", out petChose.quest))
            {
                petChose.Quest.TryGetValue("quest", out petChose.quest);

            }
            if (petChose.quest == 0)
            { 
            //petChose.petPotion = petChose.petPotion  +1;
            //petChose.PetPotion.Remove("petPotion");
            //petChose.PetPotion.Add("petPotion", petChose.petPotion);
            //petChose.PetPotion.Save();

            petChose.petXPotion = petChose.petXPotion + 2;
            petChose.PetXPotion.Remove("petXPotion");
            petChose.PetXPotion.Add("petXPotion", petChose.petXPotion);

            petChose.manaPotion = petChose.manaPotion +1;
            petChose.ManaPotion.Remove("manaPotion");
            petChose.ManaPotion.Add("manaPotion", petChose.manaPotion);
            petChose.ManaPotion.Save();

            petChose.Quest.Remove("quest");
            petChose.Quest.Add("quest", 1);
            petChose.Quest.Save();
        
            }
            TalkingToNeviYesHelp.Begin();
            NeviQuest = 2;
        }

        private void btnDontHelp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            canvasHelp.Visibility = System.Windows.Visibility.Collapsed;
            NeviQuest = 3;
            TalkingToNeviNoHelp.Begin();
        }
        //Decision 2
            //Starting Boss Fight
        private void btnHelp1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GiantOrcQuest1.Stop();
            VeraTalkingQuest1pt2.Stop();
            canvasHelp_Copy.Visibility = System.Windows.Visibility.Collapsed;
            //When Chosing Lvl and Creature to battle give a number.
            petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
            petChose.EnemyLvlSelected.Add("enemyLvlSelected", 4);//ENEMY NUMBER
            petChose.EnemyLvlSelected.Save();
            //Enemy Health Lvl 1 enemy 1
            petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
            petChose.EnemyHealthPoints.Add("enemyHealthPoints", 7000);//ENEMY HEALTH
            petChose.EnemyHealthPoints.Save();
            this.NavigationService.Navigate(new Uri("/BossFightsQuests.xaml", UriKind.Relative));

        }

        private void btnDontHelp1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewObar_Copy.Visibility = System.Windows.Visibility.Collapsed;
            ViewObar.Visibility = System.Windows.Visibility.Visible;
            GiantOrcQuest1.Stop();
            VeraTalkingQuest1.Stop();
            VeraTalkingQuest1pt2.Stop();
            canvasHelp_Copy.Visibility = System.Windows.Visibility.Collapsed;
        }
//Shop
        private void btnIconShop_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
           
            if (petChose.petLighting == 1) { btnBuyLigtning.IsHitTestVisible = buttonEnable; LightningDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtLightning.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petFire == 1) { btnBuyFire.IsHitTestVisible = buttonEnable; FireDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtFire.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petIce == 1) { btnBuyIce.IsHitTestVisible = buttonEnable; IceDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtIce.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petHeal == 1) { btnBuyHeal.IsHitTestVisible = buttonEnable; HealDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtHeal.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petQuake == 1) { btnBuyQuake.IsHitTestVisible = buttonEnable; QuakeDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtQuake.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petScan == 1) { btnBuyScan.IsHitTestVisible = buttonEnable; ScanDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtScan.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petDrain == 1) { btnBuyDrain.IsHitTestVisible = buttonEnable; drainDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtDrain.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petSheild == 1) { btnBuyShield.IsHitTestVisible = buttonEnable; ShieldDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtShield.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petGunSlinger == 1) { btnGunSlinger.IsHitTestVisible = buttonEnable; GunSlingerDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtGunSlinger.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petPoison == 1) { btnBuyPoison.IsHitTestVisible = buttonEnable; PoisonDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtPoison.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petThunder == 1) { btnBuyThunder.IsHitTestVisible = buttonEnable; ThunderDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtThunder.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petInferno == 1) { btnBuyInferno.IsHitTestVisible = buttonEnable; InfernoDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtInferno.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petBlizzard == 1) { btnBuyBlizzard.IsHitTestVisible = buttonEnable; BlizzardDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtBlizzard.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petCureAll == 1) { btnBuyCureAll.IsHitTestVisible = buttonEnable; CureAllDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtCureAll.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petEarth == 1) { btnBuyEarth.IsHitTestVisible = buttonEnable; EarthDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtEarth.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petCounterAttack == 1) { btnBuyCounterAttack.IsHitTestVisible = buttonEnable; CounterAttackDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtCounterAttack.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petFallenAngels == 1) { btnBuyFallenAngels.IsHitTestVisible = buttonEnable; FallenAngelDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtFallenAngel.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petDark == 1) { btnDarkMatter.IsHitTestVisible = buttonEnable; DarkDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtDarkMatter.Visibility = System.Windows.Visibility.Visible; }
            txtShopPlayerPoints.Text = petChose.petPoints.ToString();

            PetsHome.Visibility = System.Windows.Visibility.Visible;
            canvasShop.Visibility = System.Windows.Visibility.Visible;
            HealthandMana.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnEnterShop_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            if (petChose.petLighting == 1) { btnBuyLigtning.IsHitTestVisible = buttonEnable; LightningDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtLightning.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petFire == 1) { btnBuyFire.IsHitTestVisible = buttonEnable; FireDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtFire.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petIce == 1) { btnBuyIce.IsHitTestVisible = buttonEnable; IceDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtIce.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petHeal == 1) { btnBuyHeal.IsHitTestVisible = buttonEnable; HealDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtHeal.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petQuake == 1) { btnBuyQuake.IsHitTestVisible = buttonEnable; QuakeDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtQuake.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petScan == 1) { btnBuyScan.IsHitTestVisible = buttonEnable; ScanDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtScan.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petDrain == 1) { btnBuyDrain.IsHitTestVisible = buttonEnable; drainDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtDrain.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petSheild == 1) { btnBuyShield.IsHitTestVisible = buttonEnable; ShieldDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtShield.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petGunSlinger == 1) { btnGunSlinger.IsHitTestVisible = buttonEnable; GunSlingerDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtGunSlinger.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petPoison == 1) { btnBuyPoison.IsHitTestVisible = buttonEnable; PoisonDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtPoison.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petThunder == 1) { btnBuyThunder.IsHitTestVisible = buttonEnable; ThunderDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtThunder.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petInferno == 1) { btnBuyInferno.IsHitTestVisible = buttonEnable; InfernoDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtInferno.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petBlizzard == 1) { btnBuyBlizzard.IsHitTestVisible = buttonEnable; BlizzardDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtBlizzard.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petCureAll == 1) { btnBuyCureAll.IsHitTestVisible = buttonEnable; CureAllDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtCureAll.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petEarth == 1) { btnBuyEarth.IsHitTestVisible = buttonEnable; EarthDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtEarth.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petCounterAttack == 1) { btnBuyCounterAttack.IsHitTestVisible = buttonEnable; CounterAttackDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtCounterAttack.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petFallenAngels == 1) { btnBuyFallenAngels.IsHitTestVisible = buttonEnable; FallenAngelDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtFallenAngel.Visibility = System.Windows.Visibility.Visible; }
            if (petChose.petDark == 1) { btnDarkMatter.IsHitTestVisible = buttonEnable; DarkDisplay.Visibility = System.Windows.Visibility.Collapsed; txtBoughtDarkMatter.Visibility = System.Windows.Visibility.Visible; }
            txtShopPlayerPoints.Text = petChose.petPoints.ToString();

            PetsHome.Visibility = System.Windows.Visibility.Visible;
            canvasShop.Visibility = System.Windows.Visibility.Visible;
            HealthandMana.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnIconFight_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            canvasWhichFight.Visibility = System.Windows.Visibility.Visible;
          
        }

        private void btnTrain_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            VeraMoving.Stop();
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
         



            int SelectLvl;

            Random enemyLvlSelect = new Random();


            SelectLvl = enemyLvlSelect.Next(1,10);
            if (SelectLvl == 1)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 2000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 2)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 2);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 3000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 3)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 3);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 4000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 4)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 4);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 8000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 5)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 5);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 6000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 6)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 6);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 6000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 7)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 7);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 4000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 8)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 8);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 6000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            if (SelectLvl == 9)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 9);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 7000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
            this.NavigationService.Navigate(new Uri("/AndionFightTrain.xaml", UriKind.Relative));
        }

        private void btnCancelFight_Click(object sender, RoutedEventArgs e)
        {
            canvasWhichFight.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void me_MediaOpened(object sender, RoutedEventArgs e)
        {
            FrameworkDispatcher.Update();
            MediaElement m = (MediaElement)sender;

            m.Play();
        }

        private void me_MediaEnded(object sender, RoutedEventArgs e)
        {
             FrameworkDispatcher.Update();
                MediaElement m = (MediaElement)sender;

                m.Play();
        }

   
//Church////////////////////////////////////////////////////
       
        private void btnChurch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.ChurchCreature.TryGetValue("churchCreature", out petChose.churchCreature))
            {
                petChose.ChurchCreature.TryGetValue("churchCreature", out petChose.churchCreature);
            }
            canvasChurch.Visibility = System.Windows.Visibility.Visible;

            if (petChose.churchCreature == 0)
            {
                txtCreaturesName.Text = "Pickie";
                pickie.Visibility = System.Windows.Visibility.Visible;
            }
 if (petChose.churchCreature == 1)
            {
                txtCreaturesName.Text = "Evilbutterfly";
                evilButterfly.Visibility = System.Windows.Visibility.Visible;
                
            }
 if (petChose.churchCreature == 2)
            {
                txtCreaturesName.Text = "FireBall";
                FireBallEnemy.Visibility = System.Windows.Visibility.Visible;
       
            
            }
 if (petChose.churchCreature == 3)
            {
                txtCreaturesName.Text = "Eyeee";
                EyeBlob.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.churchCreature == 4)
            {
                txtCreaturesName.Text = "Blob";
                Blob.Visibility = System.Windows.Visibility.Visible;
               
            }
            if (petChose.churchCreature == 5)
            {
                txtCreaturesName.Text = "Kego";
                kego.Visibility = System.Windows.Visibility.Visible;
                
            }
            if (petChose.churchCreature == 6)
            {
                txtCreaturesName.Text = "Snail";
                Snail.Visibility = System.Windows.Visibility.Visible;
            

            }
            if (petChose.churchCreature == 7)
            {
                txtCreaturesName.Text = "Goblin";
                smallgoblin.Visibility = System.Windows.Visibility.Visible;
          

            }
            if (petChose.churchCreature == 8)
            {
                txtCreaturesName.Text = "Snug";
                snug.Visibility = System.Windows.Visibility.Visible;
              
            }
            if (petChose.churchCreature == 9)
            {
                txtCreaturesName.Text = "The Fallen";
                Boss.Visibility = System.Windows.Visibility.Visible;
          

            }
        }
        private void btnCancel1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            canvasChurch.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnFight1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            pickie.Visibility = System.Windows.Visibility.Collapsed;
            evilButterfly.Visibility = System.Windows.Visibility.Collapsed;
            FireBallEnemy.Visibility = System.Windows.Visibility.Collapsed;
            EyeBlob.Visibility = System.Windows.Visibility.Collapsed;
            Blob.Visibility = System.Windows.Visibility.Collapsed;
            kego.Visibility = System.Windows.Visibility.Collapsed;
            Snail.Visibility = System.Windows.Visibility.Collapsed;
            smallgoblin.Visibility = System.Windows.Visibility.Collapsed;
            snug.Visibility = System.Windows.Visibility.Collapsed;
            Boss.Visibility = System.Windows.Visibility.Collapsed;





            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            if (petChose.churchCreature == 0)
            {
              
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 50000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
                
            }
            if (petChose.churchCreature == 1)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 2);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 50000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
            }
            if (petChose.churchCreature == 2)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 3);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 50000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));

            }
            if (petChose.churchCreature == 3)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 4);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 60000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
            }
            if (petChose.churchCreature == 4)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 5);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 65000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
            }
            if (petChose.churchCreature == 5)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 6);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 80000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
            }
            if (petChose.churchCreature == 6)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 7);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 80000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));

            }
            if (petChose.churchCreature == 7)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 8);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 85000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
            }
            if (petChose.churchCreature == 8)
            {
                
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 9);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 95000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                this.NavigationService.Navigate(new Uri("/AndionChurchFightxaml.xaml", UriKind.Relative));
            }
            if (petChose.churchCreature == 9)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 6);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 120000);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
                    this.NavigationService.Navigate(new Uri("/ObarChurchBoss.xaml", UriKind.Relative));
           

            }
           
        }

//Hotel/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void btnHotel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            canvasHotel.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnHealthHotel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints))
            {

                petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints);
            }
            if (petChose.MaxHealthPoints.TryGetValue("maxHealthPoints", out petChose.maxHealthPoints))
            {
                petChose.MaxHealthPoints.TryGetValue("maxHealthPoints", out petChose.maxHealthPoints);
            }
            //Getting Players Points
            if (petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints))
            {
                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                txtPlayersPoints.Text = petChose.petPoints.ToString();
            }
            int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
            int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
            int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
            int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
            //if not enough points show messeagebox
            int.TryParse(txtPlayersPoints.Text, out Points);
            if (petChose.petPoints < 100) MessageBox.Show("Your VII Voices? Boy, the things people will say to get a free room. Get out of here. Come back when you have 100 Points.");
            //subtract the amount of potion 100 from points.    
            if (petChose.petPoints >= 100 &&petChose.healthPoints < petChose.maxHealthPoints)
            {
                   
                    if (petChose.healthPoints < petChose.maxHealthPoints)
                    {
                        UsingPotions.Begin();


                        txtPlusHealth.Text = "All";
                        storyPlusHealth.Begin();
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                        petChose.HealthPoints.Save();
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", petChose.healthPoints);
                        petChose.HealthPoints.Save();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();
                        //Save Player Mana Points
                        int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                        petChose.ManaPoints.Remove("manaPoints");
                        petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                        petChose.ManaPoints.Save();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out Health);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", Health);
                        petChose.HealthPoints.Save();
                        canvasHotel.Visibility = System.Windows.Visibility.Collapsed;

                        petChose.petPoints = petChose.petPoints - 100;
                        txtPlayersPoints.Text = petChose.petPoints.ToString();
                        if (petChose.healthPoints> petChose.maxHealthPoints)
                        {

                            petChose.manaPoints = petChose.maxManaPoints;
                            txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                          


                            int.TryParse(txtPlayersPoints.Text, out Points);
                            //Save Points
                            petChose.PetPoints.Remove("petPoints");
                            petChose.PetPoints.Add("petPoints", petChose.petPoints);
                            petChose.PetPoints.Save();
                            txtShopPlayerPoints.Text = petChose.petPoints.ToString();
                        }
                    }
                }
            else if (petChose.healthPoints >= petChose.maxHealthPoints)
            {
                MessageBox.Show("You're already at full Health");
            }
            
        }

        private void btnManaHotel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
            {
                petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
            }
            if (petChose.MaxManaPoints.TryGetValue("maxManaPoints", out petChose.maxManaPoints))
            {
                petChose.MaxManaPoints.TryGetValue("maxManaPoints", out petChose.maxManaPoints);
            }
            if (petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints))
            {
                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                txtPlayersPoints.Text = petChose.petPoints.ToString();
            }
        	int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
            int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
            int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
            int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
            //if not enough points show messeagebox
            int.TryParse(txtPlayersPoints.Text, out Points);
            if (petChose.petPoints < 100) MessageBox.Show("Your VII Voices? Boy, the things people will say to get a free room. Get out of here. Come back when you have 100 Points.");
            //subtract the amount of potion 100 from points.    
            if (petChose.petPoints >= 100 && petChose.manaPoints < petChose.maxManaPoints)
            {
                petChose.manaPoints = petChose.maxManaPoints;
                txtPlusMana.Text = "+" + petChose.maxManaPoints;
                storyPlusMana.Begin();
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                //Save Player Mana Points
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                petChose.ManaPoints.Save();
                petChose.petPoints = petChose.petPoints - 100;
                txtPlayersPoints.Text = petChose.petPoints.ToString();
                //Save Points
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", petChose.petPoints);
                petChose.PetPoints.Save();
                txtShopPlayerPoints.Text = petChose.petPoints.ToString();
                canvasHotel.Visibility = System.Windows.Visibility.Collapsed;
                if (petChose.manaPoints > petChose.maxManaPoints)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                    int.TryParse(txtPlayersPoints.Text, out Points);

                    //Save Player Mana Points
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                    petChose.ManaPoints.Save();
                }
            }
            else if (petChose.manaPoints >= petChose.maxManaPoints)
            {
                MessageBox.Show("You're already at full Mana");
            }
            
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            canvasHotel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void PhoneApplicationPage_BackKeyPress_1(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.pause == 3)
            {
                e.Cancel = true;
                CanvasUseItem.Visibility = System.Windows.Visibility.Collapsed;
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Collapsed;
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 2);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 2)
            {
                e.Cancel = true;
                canvasDescriptionOfLevelUp.Visibility = System.Windows.Visibility.Collapsed;
                canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                canvasItems.Visibility = System.Windows.Visibility.Collapsed;
                canvasLevelUp.Visibility = System.Windows.Visibility.Collapsed;

                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 1);
                petChose.Pause.Save();
            }

            else if (petChose.pause == 1)
            {
                e.Cancel = true;
                canvasLevelUp.Visibility = System.Windows.Visibility.Collapsed;
                canvasShop.Visibility = System.Windows.Visibility.Collapsed;
                HealthandMana.Visibility = System.Windows.Visibility.Collapsed;
                PetsHome.Visibility = System.Windows.Visibility.Collapsed;
                canvasWhichFight.Visibility = System.Windows.Visibility.Collapsed;
                canvasChurch.Visibility = System.Windows.Visibility.Collapsed;
                canvasHotel.Visibility = System.Windows.Visibility.Collapsed;

                btnIconFight.Visibility = System.Windows.Visibility.Visible;
                btnIconShop.Visibility = System.Windows.Visibility.Visible;
                btnProfile.Visibility = System.Windows.Visibility.Visible;
                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 0);
                petChose.Pause.Save();
            }
            else if (petChose.pause == 0)
            {
                this.NavigationService.GoBack();

            }
        }

        private void resetStats_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult results;
            results = MessageBox.Show("Restore Stats?", "This will allow you to redistribute your points.", MessageBoxButton.OKCancel);

            if (results == MessageBoxResult.OK)
            {

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

                if (txtPlayerLevel.Text == 2.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 550);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 15);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 1);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 2);
                    petChose.UpgradePoints.Save();
                  
                }
                if (txtPlayerLevel.Text == 3.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 600);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 20);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 2);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 4);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 4.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 650);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 25);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 3);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 6);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 5.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 700);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 30);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 4);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 8);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 6.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 800);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 35);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 5);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 10);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 7.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 900);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 40);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 6);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 12);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 8.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1000);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 45);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 7);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 14);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 9.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1100);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 50);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 8);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 16);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 10.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1200);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 55);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 9);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 18);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 11.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1300);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 60);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 10);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 20);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 12.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1400);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 65);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 11);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 22);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 13.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1500);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 70);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 12);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 24);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 14.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1600);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 75);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 13);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 26);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 15.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 1700);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 80);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 14);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 28);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 16.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 2000);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 85);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 15);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 30);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 17.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 2200);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 90);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 16);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 32);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 18.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 2500);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 90);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 17);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 34);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 19.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 2800);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 95);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 18);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 36);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 20.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 3100);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 100);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 19);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 38);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 21.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 3500);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 110);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 20);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 40);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 22.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 4000);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 115);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 21);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 42);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 23.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 4500);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 120);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 22);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 43);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 24.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 4800);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 125);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 23);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 44);
                    petChose.UpgradePoints.Save();

                }
                if (txtPlayerLevel.Text == 25.ToString())
                {
                    petChose.MaxHealthPoints.Remove("maxHealthPoints");
                    petChose.MaxHealthPoints.Add("maxHealthPoints", 5000);
                    petChose.MaxHealthPoints.Save();
                    petChose.MaxManaPoints.Remove("maxManaPoints");
                    petChose.MaxManaPoints.Add("maxManaPoints", 130);
                    petChose.MaxManaPoints.Save();
                    petChose.PetLevel.Remove("petLevel");
                    petChose.PetLevel.Add("petLevel", 24);
                    petChose.PetLevel.Save();
                    petChose.UpgradePoints.Remove("upgradePoints");
                    petChose.UpgradePoints.Add("upgradePoints", 45);
                    petChose.UpgradePoints.Save();

                }
                if (petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints))
                {
                    petChose.UpgradePoints.TryGetValue("upgradePoints", out petChose.upgradePoints);
                }
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }
                if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
                {
                    petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
                }
                if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
                {
                    petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
                }
                if (petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP))
                {
                    petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP);

                }
                if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
                {
                    petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
                }



                //Updating The Levels
                txtAttackLevel.Text = petChose.attackUP.ToString();
                txtManaAttackLevel.Text = petChose.manaAttackUp.ToString();
                txtSpeedLevel.Text = petChose.speedUP.ToString();
                txtSpritualPowerLevel.Text = petChose.spiritualAttackUP.ToString();
                txtDefenseLevel.Text = petChose.defenseUP.ToString();
                txtUserUpgradePoints.Text = petChose.upgradePoints.ToString();
            }
        }


















    }
}