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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace myBuddies
{   
    public partial class BossFightsQuests : PhoneApplicationPage
    {
        IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
        int addPetPoints;
        int addEXP;
        int Health;
        int Mana;
        int typeOfAttack;
        int spellSelected;
        int itemBeingUsed;
        int playerDamageFromPlayersAttack;
        int EnemyHealth;
        int EnemyDamageFromEnemysAttack;
        int EnemyDamageFromEnemysAttack2;
        int enemyTypeAttack;
        int playerHealthPoints;
        int playerManaPoints;
        int playersSpeed;
        int playerHealing;
        int manaDrainedFromEnemy;
        byte spellPage = 0;
        public BossFightsQuests()
        {
            InitializeComponent();
        }
 private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
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
            if (MediaPlayer.GameHasControl == true)
            {
                FrameworkDispatcher.Update();
                me.Stop();
                me.Volume = 11;
                me.Source = new Uri("Sounds/FightSong.mp3", UriKind.Relative);
            }


            //Player Health and Mana
            //Health Points
            if (petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints))
            {
                petChose.HealthPoints.TryGetValue("healthPoints", out petChose.healthPoints);
                txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
            }
            //Getting Player MaxHealth
            if (petChose.MaxHealthPoints.TryGetValue("maxHealthPoints", out petChose.maxHealthPoints))
            {
                petChose.MaxHealthPoints.TryGetValue("maxHealthPoints", out petChose.maxHealthPoints);
                txtMaxHealthPoints.Text = petChose.maxHealthPoints.ToString();
            }
            //ManaPoints
            if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
            {
                petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
            }
            //Getting Player MaxMana
            if (petChose.MaxManaPoints.TryGetValue("maxManaPoints", out petChose.maxManaPoints))
            {
                petChose.MaxManaPoints.TryGetValue("maxManaPoints", out petChose.maxManaPoints);
                txtMaxManaPoints.Text = petChose.maxManaPoints.ToString();
            }

            ////Getting Items
            ////Potion
            if (petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion))
            {

                petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion);
                txtTotalPotion.Text = petChose.petPotion.ToString();
            }
            //XPotion
            if (petChose.PetPotion.TryGetValue("petXPotion", out petChose.petXPotion))
            {
                petChose.PetXPotion.TryGetValue("petXPotion", out petChose.petXPotion);
                txtTotalXPotion.Text = petChose.petXPotion.ToString();
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
            //Ice
            if (petChose.PetIce.TryGetValue("petIce", out petChose.petIce))
            {
                petChose.PetIce.TryGetValue("petIce", out petChose.petIce);
            }
            //Quake
            if (petChose.PetQuake.TryGetValue("petQuake", out petChose.petQuake))
            {
                petChose.PetQuake.TryGetValue("petQuake", out petChose.petQuake);
            }
            //Blizzard
            if (petChose.PetBlizzard.TryGetValue("petBlizzard", out petChose.petBlizzard))
            {
                petChose.PetBlizzard.TryGetValue("petBlizzard", out petChose.petBlizzard);
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
            //Earth
            if (petChose.PetEarth.TryGetValue("petEarth", out petChose.petEarth)) 
            {
                petChose.PetEarth.TryGetValue("petEarth", out petChose.petEarth);
            }
            //Poison
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {
                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);
            }
            //CureAll
            if (petChose.PetCureAll.TryGetValue("petCureAll", out petChose.petCureAll))
            {
                petChose.PetCureAll.TryGetValue("petCureAll", out petChose.petCureAll);
            }
            //Fallen Angel
            if(petChose.PetFallenAngels.TryGetValue("petFallenAngels", out petChose.petFallenAngels))
            {
                petChose.PetFallenAngels.TryGetValue("petFallenAngels", out petChose.petFallenAngels);
            
            }

            //Dark
            if (petChose.PetDark.TryGetValue("petDark", out petChose.petDark))
            {
                petChose.PetDark.TryGetValue("petDark", out petChose.petDark);
            }
            //Sheild
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {

                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);
            }
            //CounterAttack
            if (petChose.PetCounterAttack.TryGetValue("petCounterAttack", out petChose.petCounterAttack))
            {
                petChose.PetCounterAttack.TryGetValue("petCounterAttack", out petChose.petCounterAttack);

            }


            //Getting Player Points and EXP
            //Player Points
            if (petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints))
            {
                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
            }
            //Player EXP
            if (petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints))
            {
                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
            }
            //Player SpiritBar
            if (petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
            {
                petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
                SpiritLimitBar.Width = petChose.spiritLimit;
            }
            if (petChose.spiritLimit >= 197)
            {

                storySpiritBarIsFull.Begin();
                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
            }
       //Ability
            if(petChose.PetScan.TryGetValue("petScan", out petChose.petScan))
            {
                petChose.PetScan.TryGetValue("petScan", out petChose.petScan);
            }
            if (petChose.petScan == 1)
            {
                canvasCreaturesHealth.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
            {
                petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
            }
            if (petChose.PetGunSlinger.TryGetValue("petGunSlinger", out petChose.petGunSlinger))
            {
                petChose.PetGunSlinger.TryGetValue("petGunSlinger", out petChose.petGunSlinger);

            }
            if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
            {
                petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
            }
            //Take to correct enemy selected
            EnemyLvlSelectedAndHealth();


            //Sound
            if (checkSound.SoundEffectOffOrOn.TryGetValue("soundOffOrOn", out checkSound.soundOffOrOn))
            {
                checkSound.SoundEffectOffOrOn.TryGetValue("soundOffOrOn", out checkSound.soundOffOrOn);
            
            }
            if(checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn))
            {
            checkSound.MusicOffOrOn.TryGetValue("musicOffOrOn", out checkSound.musicOffOrOn);
            
            }



        }


        //////////////////////////////END OF PAGE LOADING/////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////




 
        /////////////////////////////////////Player Section/////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////ITEM SECTION//////////////////////////////
        ///////////////////////////////////////////////////////

        ///////////Your Item Inventory/////////////

        //OPEN ITEM BOX
        private void btnOpenItems_Click(object sender, RoutedEventArgs e)
        {
            //Pre actions
            canvasItems.Visibility = System.Windows.Visibility.Visible;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
            ActionList.Visibility = System.Windows.Visibility.Collapsed;
            //Load Items
            if (petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion))//Reading Potion
            {
                int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                petChose.PetPotion.TryGetValue("petPotion", out petChose.petPotion);
                txtTotalPotion.Text = petChose.petPotion.ToString();
            }
            if (petChose.PetPotion.TryGetValue("petXPotion", out petChose.petXPotion))//Reading XPotion
            {
                int.TryParse(txtTotalXPotion.Text, out petChose.petXPotion);
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


        }


        // CLOSE ITEM BOX
        private void btnCancelItems_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
        }
        //////////////////////////////////////Give an item a number so it can be used//////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////                              

        //potion
        private void btnPotion_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 1;
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Visible;
            txtItemBeingUsed.Text = "Potion (500HP)";
        }
        //Xpotion
        private void btnXPotion_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 2;
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Visible;
            txtItemBeingUsed.Text = "XPotion (1000HP)";
        }
        private void btnManaPotion_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 3;
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Visible;
            txtItemBeingUsed.Text = "Mana Potion (50MP)";
        }

        private void btnHolyWater_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 4;
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Visible;
            txtItemBeingUsed.Text = "Holy Water (AllMP)";
        }


        ////////////////////Using  items///////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////   


        //READY TO USE BUTTON

        //BUTTON TO USE ITEMS 
        private void btnReadyToUseItem_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
            {
                petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
            }
            ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
            if (itemBeingUsed == 1)
            {
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                if (petChose.petPotion > 0 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                  
                    petChose.petPotion = petChose.petPotion - 1;
                    petChose.healthPoints = petChose.healthPoints + 500;
                    txtTotalPotion.Text = petChose.petPotion.ToString();
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save potion
                    int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                    petChose.PetPotion.Remove("petPotion");
                    petChose.PetPotion.Add("petPotion", petChose.petPotion);
                    petChose.PetPotion.Save();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out Health);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", Health);
                    petChose.HealthPoints.Save();
                  
                    if (petChose.healthPoints > petChose.maxHealthPoints)
                    {
                  
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save potion
                        int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                        petChose.PetPotion.Remove("petPotion");
                        petChose.PetPotion.Add("petPotion", petChose.petPotion);
                        petChose.PetPotion.Save();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out Health);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", Health);
                        petChose.HealthPoints.Save();
                        
                    }
                    txtPlusHealth.Text = "+500";
                    storyPlusHealth.Begin();
                }
                else if (petChose.petPotion == 0)
                {
                    MessageBox.Show("You have no more of this item. Buy some at the shop");
                }
                else if (petChose.healthPoints >= petChose.maxHealthPoints)
                { MessageBox.Show("Your already at full health"); }

            }
            if (itemBeingUsed == 2)
            {
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtTotalXPotion.Text, out petChose.petXPotion);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                if (petChose.petXPotion > 0 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;

                    }
                  
                    //UsingPotions.Begin();
                    petChose.petXPotion = petChose.petXPotion - 1;
                    petChose.healthPoints = petChose.healthPoints + 1000;
                    txtTotalXPotion.Text = petChose.petXPotion.ToString();
                    txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                    //Save XPotion
                    int.TryParse(txtTotalXPotion.Text, out petChose.petXPotion);
                    petChose.PetXPotion.Remove("petXPotion");
                    petChose.PetXPotion.Add("petXPotion", petChose.petXPotion);
                    petChose.PetXPotion.Save();
                    //Save playerHealth
                    int.TryParse(txtPlayersHealthPoints.Text, out Health);
                    petChose.HealthPoints.Remove("healthPoints");
                    petChose.HealthPoints.Add("healthPoints", Health);
                    petChose.HealthPoints.Save();
                    
                    if (petChose.healthPoints > petChose.maxHealthPoints)
                    {
                    
                        petChose.healthPoints = petChose.maxHealthPoints;
                        txtPlayersHealthPoints.Text = petChose.healthPoints.ToString();
                        //Save XPotion
                        int.TryParse(txtTotalXPotion.Text, out petChose.petXPotion);
                        petChose.PetXPotion.Remove("petXPotion");
                        petChose.PetXPotion.Add("petXPotion", petChose.petXPotion);
                        petChose.PetXPotion.Save();
                        //Save playerHealth
                        int.TryParse(txtPlayersHealthPoints.Text, out Health);
                        petChose.HealthPoints.Remove("healthPoints");
                        petChose.HealthPoints.Add("healthPoints", Health);
                        petChose.HealthPoints.Save();
                    }
                    txtPlusHealth.Text = "+1000";
                    storyPlusHealth.Begin();
                }
                else if (petChose.petXPotion == 0)
                {
                    MessageBox.Show("You have no more of this item. Buy some at the shop");
                }
                else if (petChose.healthPoints >= petChose.maxHealthPoints)
                { MessageBox.Show("You're already at full health"); }
            }
            if (itemBeingUsed == 3)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtTotalManaPotion.Text, out petChose.manaPotion);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPotion > 0 && petChose.manaPoints < petChose.maxManaPoints)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                   
                    petChose.manaPotion = petChose.manaPotion - 1;
                    petChose.manaPoints = petChose.manaPoints + 50;
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
                        ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
                        
                        
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
                    txtPlusMana.Text = "+25";
                    storyPlusMana.Begin();
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
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
              
                    petChose.holyWater = petChose.holyWater - 1;
                    petChose.manaPoints = petChose.maxManaPoints;
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
                    txtPlusMana.Text = "+" + petChose.maxManaPoints;
                    storyPlusMana.Begin();
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
        }
        //Completed StoryBoards
        private void storyPlusHealth_Completed(object sender, EventArgs e)
        {
            storyPlusHealth.Stop();
            playersSpeedUP(petChose.speedUP);
        }
        private void storyPlusMana_Completed(object sender, EventArgs e)
        {
            storyPlusMana.Stop();
            playersSpeedUP(petChose.speedUP);
        }













        //////////////////////////////////////////////MANA SECTION/////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  
        //BUTTON TO OPEN SPELLS
        private void btnManaOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }

            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            //canvas's
            canvasManaSpells.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Visible;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            ActionList.Visibility = System.Windows.Visibility.Collapsed;
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForAttack.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
            storyEnemyAttack1Damage.Stop();
            storyEnemyAttack2Damage.Stop();
            storyMonkeyAttackDamage.Stop();
            storyPlayerAttackDamage.Stop();
            storyArrowDown.Begin();
            storyArrowUp.Begin();
            //Check what spells user has bought from the shop and change visibility to true if spell was bought(make them visible to player).
            if (petChose.petLighting == 1) btnLighting.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petFire == 1) btnFire.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petIce == 1) btnIce.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petQuake == 1) btnQuake.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petHeal == 1) btnHeal.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petThunder == 1) btnThunder.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petInferno == 1) btnInferno.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petBlizzard == 1) btnBlizzard.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petDark == 1) btnDarkMatter2.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petEarth == 1) btnEarth.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petSheild >= 1) btnShield.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petPoison == 1) btnPoison.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petCureAll == 1) btnCureAll.Visibility = System.Windows.Visibility.Visible;
            if (petChose.petFallenAngels == 1) btnFallenAngels.Visibility = System.Windows.Visibility.Visible;
            if (spellPage >= 0)
            { 
                spellPage = 0;
            }
        }
 //Left      
        private void btnArrowUp_Click(object sender, RoutedEventArgs e)
        {
            if (spellPage == 0)
            {
                canvasMagicSpells4.Visibility = System.Windows.Visibility.Visible;
                canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
                spellPage= 3;
            }
            else if (spellPage == 1)
            {
                canvasManaSpells.Visibility = System.Windows.Visibility.Visible;
                canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
                spellPage = 0;
            }
         
            else if (spellPage == 2)
            {
                canvasMagicSpells2.Visibility = System.Windows.Visibility.Visible;
                canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
                spellPage = 1;
            }
            else if (spellPage == 3)
            {
                canvasMagicSpells3.Visibility = System.Windows.Visibility.Visible;
                canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
                spellPage = 2;
            }

        }
//Right
        private void btnArrowDown_Click(object sender, RoutedEventArgs e)
        {
            if (spellPage == 0)
            {
                
                canvasMagicSpells2.Visibility = System.Windows.Visibility.Visible;
                canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
                spellPage = 1;
            }
        
            else if (spellPage == 1)
            {
                
                canvasMagicSpells3.Visibility = System.Windows.Visibility.Visible;
                canvasMagicSpells2.Visibility= System.Windows.Visibility.Collapsed;
                spellPage = 2;
            }
            else if(spellPage==2)
            {

                canvasMagicSpells4.Visibility = System.Windows.Visibility.Visible;
                canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
                spellPage = 3;
            }
            else if (spellPage == 3)        
                {

                    canvasManaSpells.Visibility = System.Windows.Visibility.Visible;
                    canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
                    spellPage = 0;
                }
          


        }
        //SPELLS
        //LIGHTING
        private void btnLighting_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 1;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Lighting";
        }
        //FIRE
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 2;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Fire";
        }
        //Heal
        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 3;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Heal";
        }
        //Ice
        private void btnIce_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 4;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Ice";
        }

        private void btnQuake_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 5;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Quake";
        }
        private void btnShield_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 6;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Shield";
        }
        private void btnDarkMatter_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 7;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Dark Matter";
        }
        private void btnPoison_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 8;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Poison";
        }

        private void btnThunder_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 9;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Thunder";
        }

        private void btnInferno_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 10;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Inferno";
        }

        private void btnBlizzard_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 11;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Blizzard";
        }

        private void btnEarth_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 12;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Earth";
        }
        private void btnCureAll_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 13;
            canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Cure All";
        }
        private void btnFallenAngels_Click(object sender, RoutedEventArgs e)
        {
            spellSelected = 14;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowUp.Stop();
            storyArrowDown.Stop();
            canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Visible;
            txtSpellChosen.Text = "Fallen Angels";
        }
   
        /////////////////////////CASTING THE SPELLS/////////////////////////
        //Casting a Spell
        private void btnMagicAttack_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }


            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();
            canvasSpells.Visibility = System.Windows.Visibility.Visible;
            //Collapse all btns so player can't click them
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Collapsed;

            //Lightning
            if (spellSelected == 1)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 5)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                    sLighting.Visibility = System.Windows.Visibility.Visible;
                    storyLighting.Begin();
                    checkSound.LightningSound(checkSound.soundOffOrOn);                                                                                                                                             //Lighting Sound
                    Mana = petChose.manaPoints - 5;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                    storyHeal.Stop();
                    MessageBox.Show("Not Enough Mana");
                }
                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }


            }
            //Fire
            if (spellSelected == 2)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 5)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                    sFire.Visibility = System.Windows.Visibility.Visible;
                    storyFire.Begin();
                    checkSound.FireSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Fire Sound
                    Mana = petChose.manaPoints - 5;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                    storyHeal.Stop();
                    MessageBox.Show("Not Enough Mana");
                }
                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Heal
            if (spellSelected == 3)
            {
                if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
                {
                    petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
                }
                playerManaAttack(petChose.manaAttackUp, 3);
            }

            //Ice
            if (spellSelected == 4)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 5)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                    ice1.Visibility = System.Windows.Visibility.Visible;
                    ice2.Visibility = System.Windows.Visibility.Visible;
                    storyIce.Begin();
                    checkSound.IceSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Ice Sound
                    Mana = petChose.manaPoints - 5;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                    storyHeal.Stop();
                    MessageBox.Show("Not Enough Mana");
                }
                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Quake
            if (spellSelected == 5)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 10)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }

                    QuakeSpellCopy.Visibility = System.Windows.Visibility.Visible;
                    Quake.Visibility = System.Windows.Visibility.Visible;
                    storyQuake.Begin();
                    checkSound.QuakeSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Quake Sound
                    Mana = petChose.manaPoints - 10;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                    storyHeal.Stop();
                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Shield
            if (spellSelected == 6)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 10)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }


                    sShield.Visibility = System.Windows.Visibility.Visible;
                    storyShield.Begin();
                    Mana = petChose.manaPoints - 10;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                    storyHeal.Stop();
                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //DarkMatter
            if (spellSelected == 7)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 25)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }


                    DarkMatter.Visibility = System.Windows.Visibility.Visible;
                    storyDarkMatter.Begin();
                    checkSound.DarkSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Dark Sound
                    Mana = petChose.manaPoints - 25;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                    storyHeal.Stop();
                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Poison
            if (spellSelected == 8)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 15)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }

                    storyPoison.Begin();
                    PoisonSmoke1.Visibility = System.Windows.Visibility.Visible;
                    PoisonSmoke2.Visibility = System.Windows.Visibility.Visible;
                    PoisonSmoke3.Visibility = System.Windows.Visibility.Visible;
                    Mana = petChose.manaPoints - 15;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }

            //Thunder
            if (spellSelected == 9)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 20)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }



                    storyThunder.Begin();
                    checkSound.ThunderSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Thunder Sound
                    Mana = petChose.manaPoints - 20;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Inferno
            if (spellSelected == 10)
            {

                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 20)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();

                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }

                    storyInferno.Begin();
                    checkSound.InfernoSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Inferno Sound
                    Mana = petChose.manaPoints - 20;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Blizzard
            if (spellSelected == 11)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 20)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }

                    storyBlizzard.Begin();
                    Mana = petChose.manaPoints - 20;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }
            //Earth
            if (spellSelected == 12)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 20)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        checkSound.EarthSound(checkSound.soundOffOrOn);                                                                                                                                                                          //Earth Sound
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                    Quake.Visibility = System.Windows.Visibility.Visible;
                    Rock1.Visibility = System.Windows.Visibility.Visible;
                    Rock2.Visibility = System.Windows.Visibility.Visible;
                    storyEarth.Begin();
                    Mana = petChose.manaPoints - 20;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

                    MessageBox.Show("Not Enough Mana");
                }

                //ManaPoints
                if (petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints))
                {
                    petChose.ManaPoints.TryGetValue("manaPoints", out petChose.manaPoints);
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                }
            }

            //CureAll
            if (spellSelected == 13)
            {
                playerManaAttack(petChose.manaAttackUp, 13);
            }
            //Fallen Angels
            if (spellSelected == 14)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                if (petChose.manaPoints >= 50)
                {

                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        checkSound.FallenAngels(checkSound.soundOffOrOn);                                                                                                                                                                          //FallenAngel Sound
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                    FallenAngel.Visibility = System.Windows.Visibility.Visible;
                    storyFallenAngel.Begin();
                    Mana = petChose.manaPoints - 50;
                    int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                    petChose.ManaPoints.Remove("manaPoints");
                    petChose.ManaPoints.Add("manaPoints", Mana);
                    petChose.ManaPoints.Save();
                }
                else
                {
                    btnActions.Visibility = System.Windows.Visibility.Visible;
                    btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
                    canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
                    noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                    magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

                    MessageBox.Show("Not Enough Mana");
                }
            }
        }
        
        //Completed Spells StoryBoards
        private void storyLighting_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 1);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            sLighting.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyLighting.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }

        }

        private void storyFire_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 2);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            sFire.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyFire.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }

        private void storyIce_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 4);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            ice1.Visibility = System.Windows.Visibility.Collapsed;
            ice2.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyIce.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }
        private void storyQuake_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
               storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 5);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            QuakeSpellCopy.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyQuake.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        
        }
        private void storyShield_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if(petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
            petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);

            }
            if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
            {
                petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
            }
            if (petChose.manaAttackUp <= 2)
            {
                petChose.petSheild = 4;
            }
            if (petChose.manaAttackUp >= 3 && petChose.manaAttackUp <= 5)
            {
                petChose.petSheild = 5;
            
            }
            if (petChose.manaAttackUp >= 5 && petChose.manaAttackUp <= 10)
            {
                petChose.petSheild = 6;

            }
            petChose.PetSheild.Remove("petShield");
            petChose.PetSheild.Add("petShield", petChose.petSheild);
            petChose.PetSheild.Save();
            storyShield.Stop();
            playersSpeedUP(petChose.speedUP);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
        
        }
        private void storyHeal_Completed(object sender, EventArgs e)
        {
            storyHeal.Stop();
            if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
            {
                petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
            } 
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
           
         
        }

        private void storyDarkMatter_Completed(object sender, EventArgs e)
        {
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 7);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            DarkMatter.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyDarkMatter.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }

        private void storyPoison_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {
                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);

            }
            if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
            {
                petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
            }
            if (petChose.manaAttackUp <= 5)
            {
                petChose.petPoison = 9;
            }
            if (petChose.manaAttackUp >= 6 && petChose.manaAttackUp <= 8)
            {
                petChose.petPoison= 11;

            }
            if (petChose.manaAttackUp >= 9 && petChose.manaAttackUp <= 10)
            {
                petChose.petPoison= 17;

            }
            petChose.PetPoison.Remove("petPoison");
            petChose.PetPoison.Add("petPoison", petChose.petPoison);
            petChose.PetSheild.Save();
            storyPoison.Stop();
            playersSpeedUP(petChose.speedUP);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void storyThunder_Completed(object sender, EventArgs e)
        {
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 9);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            L1.Visibility = System.Windows.Visibility.Collapsed;
            L2.Visibility = System.Windows.Visibility.Collapsed;
            L3.Visibility = System.Windows.Visibility.Collapsed;
            L3_5.Visibility = System.Windows.Visibility.Collapsed;
            c1.Visibility = System.Windows.Visibility.Collapsed;
            c2.Visibility = System.Windows.Visibility.Collapsed;
            c3.Visibility = System.Windows.Visibility.Collapsed;
            cloud1purp.Visibility = System.Windows.Visibility.Collapsed;
            cloud2purp.Visibility = System.Windows.Visibility.Collapsed;
            cloud3purp.Visibility = System.Windows.Visibility.Collapsed;
            
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyThunder.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }

        private void storyInferno_Completed(object sender, EventArgs e)
        {
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 10);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            Inferno.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyInferno.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }

        private void storyBlizzard_Completed(object sender, EventArgs e)
        {
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 11);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            Blizzard.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyBlizzard.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }

        

        private void storyEarth_Completed(object sender, EventArgs e)
        {
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 12);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
           Quake.Visibility = System.Windows.Visibility.Collapsed;
           Rock1.Visibility = System.Windows.Visibility.Collapsed;
           Rock2.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyEarth.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }

        private void storyCureAll_Completed(object sender, EventArgs e)
        {
            storyCureAll.Stop();
            txtPlusHealth.Text = "All";
            storyPlusHealth.Begin();
            petChose.healthPoints = petChose.healthPoints + petChose.maxHealthPoints;
           
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
                magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;

            }
        }

        private void storyFallenAngel_Completed(object sender, EventArgs e)
        {
            storyPlayerAttackDamage.Begin();//Thinking of making own Mana Attack damage look at action section storyPlayerAttackDamageComplete
            //////////
            playerManaAttack(petChose.manaAttackUp, 14);
            btnActions.Visibility = System.Windows.Visibility.Visible;
            btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;
            canvasSpells.Visibility = System.Windows.Visibility.Collapsed;
            Quake.Visibility = System.Windows.Visibility.Collapsed;
            Rock1.Visibility = System.Windows.Visibility.Collapsed;
            Rock2.Visibility = System.Windows.Visibility.Collapsed;
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            storyFallenAngel.Stop();
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }
        }


















































 
        ///////////////////////////////////////////////ACTIONS SECTION//////////////////////////////////////////

        //BUTTON TO OPEN ACTION LIST (ATTACK AND ITEMS)
        private void btnActions_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }

            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
            ActionList.Visibility = System.Windows.Visibility.Visible;
            canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForAttack.Visibility = System.Windows.Visibility.Collapsed;
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowDown.Stop();
            storyArrowUp.Stop();
            storyEnemyAttack1Damage.Stop();
            storyEnemyAttack2Damage.Stop();
            storyMonkeyAttackDamage.Stop();
            storyPlayerAttackDamage.Stop();
        }
        //Attack Actions
        //REGULAR ATTACK
        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            ReadyForAttack.Visibility = System.Windows.Visibility.Visible;
            ActionList.Visibility = System.Windows.Visibility.Collapsed;
            txtAtctionSelected.Text = "Gun Shot";
            typeOfAttack = 1;
        }
        //SPIRITBAR IS FULL BUTTON
        private void btnSpiritBarIsFull_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }

            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 1);
            petChose.Pause.Save();
            if (petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP))
            {
                petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP);

            }
          
            ReadyForAttack.Visibility = System.Windows.Visibility.Visible;
            ActionList.Visibility = System.Windows.Visibility.Collapsed;
            canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
            magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
            ReadyForMagicAttack.Visibility = System.Windows.Visibility.Collapsed;
            ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
            storyArrowDown.Stop();
            storyArrowUp.Stop();
            canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
            canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
            canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowDown.Visibility = System.Windows.Visibility.Collapsed;
            btnArrowUp.Visibility = System.Windows.Visibility.Collapsed;
            typeOfAttack = 2;
//Show spirit Attacks Name
            if (petChose.spiritualAttackUP  >3)
            {
                txtAtctionSelected.Text = "Spirit Blast";
            }
            if (petChose.spiritualAttackUP ==3 || petChose.spiritualAttackUP==4)
            {
                txtAtctionSelected.Text = "Fallen Meteor";
            
            }
            if (petChose.spiritualAttackUP == 5|| petChose.spiritualAttackUP == 6)
            {
                txtAtctionSelected.Text = "Heaven Blades";

            }
            if (petChose.spiritualAttackUP == 7 || petChose.spiritualAttackUP ==8 )
            {
                txtAtctionSelected.Text = "Outer Body Exp";

            }
            if (petChose.spiritualAttackUP == 9 || petChose.spiritualAttackUP == 10)
            {
                txtAtctionSelected.Text = "Silence";

            }

                }
        
        //The Ready To Attack Body Holds StoryBoards (Button That Does The Attack Actions)
        private void btnReadyToAttack_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }

            petChose.Pause.Remove("pause");
            petChose.Pause.Add("pause", 0);
            petChose.Pause.Save();

            ReadyForAttack.Visibility = System.Windows.Visibility.Collapsed;
            if (SpiritLimitBar.Width >= 197)
            {
                storySpiritBarIsFull.Stop();
                ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;
               

            }
            if (SpiritLimitBar.Width < 197)
            {
                ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                ManaButton.Visibility = System.Windows.Visibility.Collapsed;

            }

            //ATTACKUP
            if (petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP))
            {
                petChose.AttackUP.TryGetValue("attackUP", out petChose.attackUP);
            }
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);
            }
            if(petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
            {
            petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
            }
            if (petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP))
            {
                petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP);
            
            }
            if (typeOfAttack == 1)//Normal Attack
            {

                checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                                                                                       //Sound Gun Shot

                if (petChose.enemyLvlSelected == 6)//Robot
                { //AttackUP Level
                    PlayerAttack(petChose.attackUP, 0);
                    ////////////////////////////////////////////////////////
                    storyPlayerAttackDamage.Begin();
                    storyGunShot.Begin();
                }
                else
                {
                    //AttackUP Level
                    PlayerAttack(petChose.attackUP, 0);
                    ////////////////////////////////////////////////////////
                    storyGunShot.Begin();

                    storyPlayerAttackDamage.Begin();
                    storyBloodShotEnemy.Begin();

                }
                
            }
            //SPIRIT ATTACKS
            if(typeOfAttack ==2)//Spirit Attack
                {
                   
                   storySpiritBarIsFull.Stop();
                   btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;
            SpiritBarColor.Visibility = System.Windows.Visibility.Visible;
            txtSpiritBar.Visibility = System.Windows.Visibility.Visible;
            SpiritLimitBar.Width = 0;
            petChose.SpiritLimit.Remove("spiritLimit");
            petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
            petChose.SpiritLimit.Save();
            PlayerAttack(0, petChose.spiritualAttackUP);
           
                }
        }
           
        //Completed Attack STORYBOARDS
        private void storyGunShot_Completed(object sender, EventArgs e)
        {
            
            storyGunShot.Stop();
            storyBloodShotEnemy.Stop();
            //Once enemy reaches 0 Health fight is over present exp and points recivied from fight
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
            }

        }
        private void storySpiritBreakAttack1_Completed(object sender, EventArgs e)
        {
            SpiritBarColor.Visibility = System.Windows.Visibility.Visible;
            txtSpiritBar.Visibility = System.Windows.Visibility.Visible;
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain))
            {
                petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain);
            }
            if (petChose.petDrain == 1)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                Random drainMana = new Random();
                manaDrainedFromEnemy = drainMana.Next(4);

                if (manaDrainedFromEnemy == 0)
                {
                    petChose.manaPoints = petChose.manaPoints + 7;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "7";
                }
                if (manaDrainedFromEnemy == 1)
                {
                    petChose.manaPoints = petChose.manaPoints + 14;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "14";
                }
                if (manaDrainedFromEnemy == 2)
                {
                    petChose.manaPoints = petChose.manaPoints + 21;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "21";
                }
                if (manaDrainedFromEnemy == 3)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "All";
                }


                if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                }
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                //Save Player Mana Points
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                petChose.ManaPoints.Save();
                storySpiritBreakAttack1.Stop();
            }
            if (EnemyHealth > 0)
            {
                //SPEEDUP
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }

          
               
                

                storySpiritBreakAttack1.Stop();
                
                if (petChose.petDrain == 0)
                { 
                    playersSpeedUP(petChose.speedUP);
                }
                   //Once enemy reaches 0 Health fight is over present exp and points recivied from fight
           
            }
            if (EnemyHealth <= 0)
            {
                storySpiritBreakAttack1.Stop();
                storyEnemyDefeated.Begin();
            }

        }
        private void storyPlayerAttackDamage_Completed(object sender, EventArgs e)
        {
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (EnemyHealth > 0)
            {
                //SPEEDUP
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }

                storyPlayerAttackDamage.Stop();
                playersSpeedUP(petChose.speedUP);
            }

        }
        private void storySpiritBreakAttack2_Completed(object sender, EventArgs e)
        {
            SpiritBarColor.Visibility = System.Windows.Visibility.Visible;
            txtSpiritBar.Visibility = System.Windows.Visibility.Visible;
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain))
            {
                petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain);
            }
            if (petChose.petDrain == 1)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                Random drainMana = new Random();
                manaDrainedFromEnemy = drainMana.Next(4);

                if (manaDrainedFromEnemy == 0)
                {
                    petChose.manaPoints = petChose.manaPoints + 7;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "7";
                }
                if (manaDrainedFromEnemy == 1)
                {
                    petChose.manaPoints = petChose.manaPoints + 14;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "14";
                }
                if (manaDrainedFromEnemy == 2)
                {
                    petChose.manaPoints = petChose.manaPoints + 21;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "21";
                }
                if (manaDrainedFromEnemy == 3)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "All";
                }


                if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                }
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                //Save Player Mana Points
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                petChose.ManaPoints.Save();
                storySpiritBreakAttack2.Stop();
            }
            if (EnemyHealth > 0)
            {
                //SPEEDUP
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }





                storySpiritBreakAttack2.Stop();
           
                if (petChose.petDrain == 0)
                {
                    playersSpeedUP(petChose.speedUP);
                }
                //Once enemy reaches 0 Health fight is over present exp and points recivied from fight

            }
            if (EnemyHealth <= 0)
            {
                storySpiritBreakAttack2.Stop();
                storyEnemyDefeated.Begin();
            }

        }
        private void storySpiritBreakAttack3_Completed(object sender, EventArgs e)
        {
            SpiritBarColor.Visibility = System.Windows.Visibility.Visible;
            txtSpiritBar.Visibility = System.Windows.Visibility.Visible;
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain))
            {
                petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain);
            }
            if (petChose.petDrain == 1)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                Random drainMana = new Random();
                manaDrainedFromEnemy = drainMana.Next(4);

                if (manaDrainedFromEnemy == 0)
                {
                    petChose.manaPoints = petChose.manaPoints + 7;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "7";
                }
                if (manaDrainedFromEnemy == 1)
                {
                    petChose.manaPoints = petChose.manaPoints + 14;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "14";
                }
                if (manaDrainedFromEnemy == 2)
                {
                    petChose.manaPoints = petChose.manaPoints + 21;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "21";
                }
                if (manaDrainedFromEnemy == 3)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "All";
                }


                if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                }
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                //Save Player Mana Points
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                petChose.ManaPoints.Save();
                storySpiritBreakAttack3.Stop();
            }
            if (EnemyHealth > 0)
            {
                //SPEEDUP
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }





                storySpiritBreakAttack3.Stop();

                if (petChose.petDrain == 0)
                {
                    playersSpeedUP(petChose.speedUP);
                }
                //Once enemy reaches 0 Health fight is over present exp and points recivied from fight

            }
            if (EnemyHealth <= 0)
            {
                storySpiritBreakAttack2.Stop();
                storyEnemyDefeated.Begin();
            }

        }

        private void storySpiritBreakAttack4_Completed(object sender, EventArgs e)
        {
            SpiritBarColor.Visibility = System.Windows.Visibility.Visible;
            txtSpiritBar.Visibility = System.Windows.Visibility.Visible;
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain))
            {
                petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain);
            }
            if (petChose.petDrain == 1)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                Random drainMana = new Random();
                manaDrainedFromEnemy = drainMana.Next(4);

                if (manaDrainedFromEnemy == 0)
                {
                    petChose.manaPoints = petChose.manaPoints + 7;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "7";
                }
                if (manaDrainedFromEnemy == 1)
                {
                    petChose.manaPoints = petChose.manaPoints + 14;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "14";
                }
                if (manaDrainedFromEnemy == 2)
                {
                    petChose.manaPoints = petChose.manaPoints + 21;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "21";
                }
                if (manaDrainedFromEnemy == 3)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "All";
                }


                if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                }
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                //Save Player Mana Points
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                petChose.ManaPoints.Save();
                storySpiritBreakAttack2.Stop();
            }
            if (EnemyHealth > 0)
            {
                //SPEEDUP
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }





                storySpiritBreakAttack4.Stop();

                if (petChose.petDrain == 0)
                {
                    playersSpeedUP(petChose.speedUP);
                }
                //Once enemy reaches 0 Health fight is over present exp and points recivied from fight

            }
            if (EnemyHealth <= 0)
            {
                storySpiritBreakAttack4.Stop();
                storyEnemyDefeated.Begin();
            }

        }

        private void storySpiritBreakAttack5_Completed(object sender, EventArgs e)
        {
            SpiritBarColor.Visibility = System.Windows.Visibility.Visible;
            txtSpiritBar.Visibility = System.Windows.Visibility.Visible;
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain))
            {
                petChose.PetDrain.TryGetValue("petDrain", out petChose.petDrain);
            }
            if (petChose.petDrain == 1)
            {
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                Random drainMana = new Random();
                manaDrainedFromEnemy = drainMana.Next(4);

                if (manaDrainedFromEnemy == 0)
                {
                    petChose.manaPoints = petChose.manaPoints + 7;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "7";
                }
                if (manaDrainedFromEnemy == 1)
                {
                    petChose.manaPoints = petChose.manaPoints + 14;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "14";
                }
                if (manaDrainedFromEnemy == 2)
                {
                    petChose.manaPoints = petChose.manaPoints + 21;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "21";
                }
                if (manaDrainedFromEnemy == 3)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                    storyPlusMana.Begin();
                    txtPlusMana.Text = "All";
                }


                if (petChose.manaPoints >= petChose.maxManaPoints)
                {
                    petChose.manaPoints = petChose.maxManaPoints;
                }
                txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                //Save Player Mana Points
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);
                petChose.ManaPoints.Remove("manaPoints");
                petChose.ManaPoints.Add("manaPoints", petChose.manaPoints);
                petChose.ManaPoints.Save();
                storySpiritBreakAttack2.Stop();
            }
            if (EnemyHealth > 0)
            {
                //SPEEDUP
                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }





                storySpiritBreakAttack5.Stop();

                if (petChose.petDrain == 0)
                {
                    playersSpeedUP(petChose.speedUP);
                }
                //Once enemy reaches 0 Health fight is over present exp and points recivied from fight

            }
            if (EnemyHealth <= 0)
            {
                storySpiritBreakAttack5.Stop();
                storyEnemyDefeated.Begin();
            }

        }


      

     

















































































































































































                                                /////////////////////////////////////////////////////////AttackUP and SpiritAttackUP/////////////////////////////////////////////////

        public void PlayerAttack(int attackUP, int spiritUP)
        {
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP))
            {
                petChose.SpiritualAttackUP.TryGetValue("spiritAttackUP", out petChose.spiritualAttackUP);

            }
            if(petChose.PetGunSlinger.TryGetValue("petGunSlinger" , out petChose.petGunSlinger))
            {
            petChose.PetGunSlinger.TryGetValue("petGunSlinger" , out petChose.petGunSlinger);
            
            }
            Random playerAttack = new Random();

            //REGULAR ATTACK

            if (typeOfAttack == 1)
            {
                if (petChose.petGunSlinger == 0)
                {
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttack.Next(0, 11);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (petChose.petGunSlinger == 1)
                {
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = (petChose.attackUP * 500) - playerAttack.Next(0, 11);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                
                
                }

           
            }
            //SPIRIT ATTACK
            if (typeOfAttack == 2)
            {
                if (spiritUP == 1)
                {
                    checkSound.SpiritAttack1Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                       //SpiritAttack1
                    storySpiritBreakAttack1.Begin();
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(800, 850);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (spiritUP == 2)
                {
                    storySpiritBreakAttack1.Begin();
                    checkSound.SpiritAttack1Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                       //SpiritAttack1
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(1000, 1100);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();

                }
                if (spiritUP == 3)
                {
                    storySpiritBreakAttack2.Begin();
                    checkSound.SmallExplosionSound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(2000, 2100);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (spiritUP == 4)
                {
                    storySpiritBreakAttack2.Begin();

                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(3200, 3300);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                
                }
                if (spiritUP == 5)
                {
                    storySpiritBreakAttack3.Begin();
                    checkSound.SpiritAttack1Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(5000, 5200);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }

                if (spiritUP == 6)
                {
                    storySpiritBreakAttack3.Begin();
                    checkSound.SpiritAttack2Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(6000,6200);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (spiritUP == 7)
                {
                    storySpiritBreakAttack4.Begin();
                    checkSound.SpiritAttack2Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(8000, 8200);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (spiritUP == 8)
                {
                    storySpiritBreakAttack4.Begin();
                    checkSound.SpiritAttack2Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(9999, 10000);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (spiritUP == 9)
                {
                    storySpiritBreakAttack5.Begin();
                    checkSound.SpiritAttack2Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(11111, 11112);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (spiritUP == 10)
                {
                    storySpiritBreakAttack5.Begin();
                    checkSound.SpiritAttack2Sound(checkSound.soundOffOrOn);                                                                                                                                                                                                     //SpiritAttack2
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = playerAttack.Next(20000, 21000);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
            }
           if (EnemyHealth <= 0)
            {
                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
        
        }

        
































        //MANA ATTACKS                                                  /////////////////////////////////////////////////ManaAttackUP///////////////////////////////////////////////////////////
        // See What Level And Take Away Enemy Health
        public void playerManaAttack(int manaAttackUp, int spell)
        {
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            Random playerAttack = new Random();
            Random Healing = new Random();
//Lightning
                if (spell == 1)
                {
                    if (petChose.enemyLvlSelected == 6)
                    {
                        int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                        playerDamageFromPlayersAttack =(petChose.manaAttackUp * 1000)- playerAttack.Next( 0, 11 )  ;
                        EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                        txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                        txtCreaturesHealth.Text = EnemyHealth.ToString();
                        petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                        petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                        petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                        petChose.EnemyHealthPoints.Save();
                    }
                    else
                    {
                        int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                        playerDamageFromPlayersAttack = (petChose.manaAttackUp * 100)- playerAttack.Next(0, 11)  ;
                        EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                        txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                        txtCreaturesHealth.Text = EnemyHealth.ToString();
                        petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                        petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                        petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                        petChose.EnemyHealthPoints.Save();
                    }
                }
//Inferno
                if (spell == 2)
                {
                    if (petChose.enemyLvlSelected < 6)
                    {
                        int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                        playerDamageFromPlayersAttack = (petChose.manaAttackUp * 100) -playerAttack.Next(0, 11);
                        EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                        txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                        txtCreaturesHealth.Text = EnemyHealth.ToString();
                        petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                        petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                        petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                        petChose.EnemyHealthPoints.Save();
                    }
                    if (petChose.enemyLvlSelected == 4)
                    {
                        int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                        playerDamageFromPlayersAttack = (petChose.manaAttackUp * 500) ;
                        EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                        txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                        txtCreaturesHealth.Text = EnemyHealth.ToString();
                        petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                        petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                        petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                        petChose.EnemyHealthPoints.Save();

                    }
                }
//Heal
                if (spell == 3)
                {
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);


                if (petChose.manaPoints >= 5 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                   storyHeal.Begin();
                    petChose.manaPoints = petChose.manaPoints - 5;
                    playerHealing = (petChose.manaAttackUp * 100) - Healing.Next(0, 11) ;
                    txtPlusHealth.Text ="+" +  playerHealing.ToString();
                    storyPlusHealth.Begin();
                    petChose.healthPoints = petChose.healthPoints + playerHealing;
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
//Ice   
                if (spell == 4)
                {
                    
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = (petChose.manaAttackUp * 100) -playerAttack.Next(0, 11) ;
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                
                }
//Quake
                if (spell == 5)
                {

                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = ((petChose.manaAttackUp * 100) + petChose.manaAttackUp * 50) - playerAttack.Next(0, 11);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();

                }
//DarkMatter
            if(spell==7)
            {

                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = (petChose.manaAttackUp * 1500) - playerAttack.Next(0, 11);
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();

            }
//Thunder
            if (spell == 9)
            {

                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = (petChose.manaAttackUp * 1000) - playerAttack.Next(0, 11);
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();        
            }
//Inferno
            if (spell == 10)
            {

                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = (petChose.manaAttackUp * 1000) - playerAttack.Next(0, 11);
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();
            }

//Blizzard
            if (spell == 11)
            {

                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = (petChose.manaAttackUp * 1000) - playerAttack.Next(0, 11);
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();
            }
//Earth
            if (spell == 12)
            {

                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = (petChose.manaAttackUp * 1000) - playerAttack.Next(0, 11);
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();
            }
//Cure All
            if (spell == 13)
            { 
             int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                int.TryParse(txtMaxManaPoints.Text, out petChose.maxManaPoints);
                int.TryParse(txtPlayerManaPoints.Text, out petChose.manaPoints);


                if (petChose.manaPoints >= 25 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    if (SpiritLimitBar.Width >= 197)
                    {
                        storySpiritBarIsFull.Stop();
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;
                        SpiritBarColor.Visibility = System.Windows.Visibility.Collapsed;
                        txtSpiritBar.Visibility = System.Windows.Visibility.Collapsed;
                        btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Collapsed;


                    }
                    if (SpiritLimitBar.Width < 197)
                    {
                        ActionButton.Visibility = System.Windows.Visibility.Collapsed;
                        ManaButton.Visibility = System.Windows.Visibility.Collapsed;

                    }
                   //storyHeal.Begin();
                    storyCureAll.Begin();
                    petChose.manaPoints = petChose.manaPoints - 25;
                    txtPlayerManaPoints.Text = petChose.manaPoints.ToString();
                   
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
            //Fallen Angel
            if (spell == 14)
            {

                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = 77777;
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();
            }


       
             if (EnemyHealth <= 0)
            {
                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
}
        
         


        ///////////END/////////////////////////////////////////////ManaAttackUP/////////////////////////////////////////////////////////










        //check players speed                                                      ///////////////////////////////////SpeedUP//////////////////////////////////////
        public void playersSpeedUP(int speedUP)
        {
            if (EnemyHealth > 0)
            {
                Random anotherAttackChance = new Random();

                if (petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP))
                {
                    petChose.SpeedUP.TryGetValue("speedUP", out petChose.speedUP);
                }

                if (speedUP == 0)
                {
                    EnemyAttack(petChose.enemyLvlSelected);
                }
                if (speedUP >= 1)
                {
                    playersSpeed = anotherAttackChance.Next(0, 1001);
                    if (playersSpeed < petChose.speedUP * 50)
                    {
                        if (SpiritLimitBar.Width >= 197)
                        {
                            btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Visible;
                            storySpiritBarIsFull.Begin();
                            ActionButton.Visibility = System.Windows.Visibility.Visible;
                            ManaButton.Visibility = System.Windows.Visibility.Visible;

                        }
                        if (SpiritLimitBar.Width < 197)
                        {
                            ActionButton.Visibility = System.Windows.Visibility.Visible;
                            ManaButton.Visibility = System.Windows.Visibility.Visible;

                        }
                    }
                    else
                    {
                        EnemyAttack(petChose.enemyLvlSelected);

                    }


                }
            }
        }
        ///END SPEEDUP//////////////////////////////////////////////////////////////////////////////////////////////////////////////






























        //FINISH BATTLE//
        private void storyEnemyDefeated_Completed(object sender, EventArgs e)
        {
            EnemyHealthIsZero();
            canvasCreatures.Visibility = System.Windows.Visibility.Collapsed;
            storyEnemyDefeated.Stop();
        }
                                       
        private void btnBattleFinish_Click(object sender, RoutedEventArgs e)
        {
            if (petChose.Quest.TryGetValue("quest", out petChose.quest))
            {
                petChose.Quest.TryGetValue("quest", out petChose.quest);

            }
            petChose.Quest.Remove("quest");
            petChose.Quest.Add("quest", 2);
            petChose.Quest.Save();
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            if (petChose.gameStarted == 13)
            {
             
            }
            else
            {
                this.NavigationService.GoBack();
            }
            }
        public void EnemyHealthIsZero()
        {
            EnemyHealth = 0;
            int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
            EnemyHealth = 0;
            txtCreaturesHealth.Text = EnemyHealth.ToString();
            int holdPlayersPoints;
            int holdPlayersEXP;
            //Level 1
            //Dog 
            if (petChose.enemyLvlSelected == 1)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(80,95);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(50, 60);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();


            }
            //Cat 
            if (petChose.enemyLvlSelected == 2)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(80, 95);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(25,27);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //Turtle
            if (petChose.enemyLvlSelected == 3)
            {
            canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(90, 100);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(30, 35);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //Monkey AKA Orc
            if (petChose.enemyLvlSelected == 4)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(1000, 1500);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(1000, 1200);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //Zombie 
            if (petChose.enemyLvlSelected == 5)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(250, 250);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(77, 78);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //Robot
            if (petChose.enemyLvlSelected == 6)
            {
             canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(180, 200);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(50,52);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //Spider
            if (petChose.enemyLvlSelected == 7)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(75, 80);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(20, 21);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //Pickie
            if (petChose.enemyLvlSelected == 8)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(90, 100);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(20, 28);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
            //EvilButterFly
            if (petChose.enemyLvlSelected == 10)
            {
                canvasBattleFinished.Visibility = System.Windows.Visibility.Visible;
                Random playerPoints = new Random();
                holdPlayersPoints = playerPoints.Next(100, 100);
                addPetPoints = holdPlayersPoints + petChose.petPoints;
                txtAmountOfPointsGained.Text = holdPlayersPoints.ToString();


                petChose.PetPoints.TryGetValue("petPoints", out petChose.petPoints);
                petChose.PetPoints.Remove("petPoints");
                petChose.PetPoints.Add("petPoints", addPetPoints);
                petChose.PetPoints.Save();
                Random playerEXP = new Random();
                holdPlayersEXP = playerEXP.Next(20, 21);

                addEXP = holdPlayersEXP + petChose.expPoints;

                txtAmountOfExperienceGained.Text = holdPlayersEXP.ToString();

                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                petChose.ExpPoints.Remove("expPoints");
                petChose.ExpPoints.Add("expPoints", addEXP);
                petChose.ExpPoints.Save();
            }
        }
        //END////////////////////////////////FinishBattle/////////////////////////////////////////////////////



















































































































































































        ////////////////////////////////////Enemy Section///////////////////////////////////


        // Set Health to an Enemy. FROM PETHOME STATS SECTION  /////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//Health and Weakness is put here for scan
        public void EnemyLvlSelectedAndHealth()
        {
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }

            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            //Level 1
            //Dog Stats
            if (petChose.enemyLvlSelected == 1)
            {

                dog.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();


            }
            //Cat Stats
            if (petChose.enemyLvlSelected == 2)
            {
                cat.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            //Turtle Stats
            if (petChose.enemyLvlSelected == 3)
            {
                turtle.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            //Monkey Stats
            if (petChose.enemyLvlSelected == 4)
            {
                Orc.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                txtEnemyWeakness.Text = "Fire";
            }
            //Zombie Stats
            if (petChose.enemyLvlSelected == 5)
            {
                zombie.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            //Robot Stats
            if (petChose.enemyLvlSelected == 6)
            {
                BattleRobot.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            //Spider
            if (petChose.enemyLvlSelected == 7)
            {
                spider.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            
            }
            //Spider
            if (petChose.enemyLvlSelected == 8)
            {
                pickie.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();

            }
            //Spider
            if (petChose.enemyLvlSelected == 9)
            {
                EvilButterfly.Visibility = System.Windows.Visibility.Visible;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = petChose.enemyHealthPoints;
                txtCreaturesHealth.Text = EnemyHealth.ToString();

            }
        }




        public void EnemyAttack(int enemyLevel)
        {
            Random enemyTypeOfAttack = new Random();
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            //Level 1 Attacks
            //Dog
            if (petChose.enemyLvlSelected == 1)
            {
                enemyTypeAttack = enemyTypeOfAttack.Next(1, 10);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();

                }
                if (enemyTypeAttack >= 8)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
            }
           
            //Spider
            if (petChose.enemyLvlSelected == 7)
            {
                enemyTypeAttack = enemyTypeOfAttack.Next(1, 10);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();

                }
                if (enemyTypeAttack >= 8)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
            }
          
            //Pickie
            if (petChose.enemyLvlSelected == 8)
            {
                enemyTypeAttack = enemyTypeOfAttack.Next(1, 10);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();

                }
                if (enemyTypeAttack >= 8)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
            }
           
            //EvilButterfly
            if (petChose.enemyLvlSelected == 9)
            {
                enemyTypeAttack = enemyTypeOfAttack.Next(1, 10);
                if (enemyTypeAttack <= 5)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();

                }
                if (enemyTypeAttack >= 6)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
            }
       
            //Cat
            if (petChose.enemyLvlSelected == 2)
            {
                enemyTypeAttack = enemyTypeOfAttack.Next(1, 10);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();
                }
                else if (enemyTypeAttack >= 8)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
            }
            //Turtle
            if (petChose.enemyLvlSelected == 3)
            {

                enemyTypeAttack = enemyTypeOfAttack.Next(1, 10);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();
                }
                else  if (enemyTypeAttack >= 8)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
            }

            //Monkey
            if (petChose.enemyLvlSelected == 4)
            {

                enemyTypeAttack = enemyTypeOfAttack.Next(1, 20);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();
                }
                if (enemyTypeAttack > 7 && enemyTypeAttack <= 11)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
                if (enemyTypeAttack >= 12)
                {
                    storyMonkeyAttack.Begin();
                    storyMonkeyAttackDamage.Begin();
                }
            }

            //Zombie
            if (petChose.enemyLvlSelected == 5)
            {

                enemyTypeAttack = enemyTypeOfAttack.Next(1, 25);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();
                }
                if (enemyTypeAttack >= 8 && enemyTypeAttack < 17)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
                if (enemyTypeAttack >= 17)
                {
                    storyZombieAttack.Begin();
                    storyZombieAttackDamage.Begin();
                }
            }

            //Robot
            if (petChose.enemyLvlSelected == 6)
            {

                enemyTypeAttack = enemyTypeOfAttack.Next(1, 25);
                if (enemyTypeAttack <= 7)
                {
                    storyEnemyAttack1.Begin();
                    storyEnemyAttack1Damage.Begin();
                }
                if (enemyTypeAttack >= 8 && enemyTypeAttack <= 17)
                {
                    storyEnemyAttack2.Begin();
                    storyEnemyAttack2Damage.Begin();
                }
                if (enemyTypeAttack > 17)
                {
                    storyRobotAttack.Begin();
                    storyRobotAttackDamage.Begin();
                }
            }
        }
/// <summary>
/// /////////////////Counter Attack and Poison story Complete
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>

        private void storyCounterAttackandPoison_Completed(object sender, EventArgs e)
        {
            storyCounterAttackandPoison.Stop();
        }
        private void storyPoisonAttackDamage_Completed(object sender, EventArgs e)
        {
            storyPoisonAttackDamage.Stop();
        }

        //SETS WHAT ATTACK ENEMY WILL DO AND THE DAMAGE ENEMY WILL GIVE PLAYERER and of the Enemy attacks STORYBOARDS
        //Attack 1
        private void storyEnemyAttack1Damage_Completed(object sender, EventArgs e)
        {
            int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
            Random enemyAttack = new Random();
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {

                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);
            }



            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);
            }
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);

            }
            if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
            {
                petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
            }
            Random playerAttackPoison = new Random();
            //Level 1
            //Attack 1
            //Dog
            if (petChose.enemyLvlSelected == 1)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack.Next(11, 13) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack.Next(20, 24) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }

            }
            //Spider
            if (petChose.enemyLvlSelected == 7)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack.Next(20, 21) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack.Next(30, 32) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }

            }
            //Pickie
            if (petChose.enemyLvlSelected == 8)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack.Next(50, 55) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack.Next(50, 55) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }
            }
                //EvilButterfly
                if (petChose.enemyLvlSelected == 9)
                {
                    if (petChose.petSheild <= 1)
                    {
                        sShield.Visibility = System.Windows.Visibility.Collapsed;
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = enemyAttack.Next(5, 7) - (petChose.defenseUP * 2);
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    }
                    if (petChose.petSheild > 1)
                    {
                        storyShieldBlock.Begin();
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = (enemyAttack.Next(10, 11) - petChose.defenseUP * 2) / 2;
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                        petChose.petSheild = petChose.petSheild - 1;
                        petChose.PetSheild.Remove("petShield");
                        petChose.PetSheild.Add("petShield", petChose.petSheild);
                        petChose.PetSheild.Save();


                    }

                }



                //Cat
                if (petChose.enemyLvlSelected == 2)
                {
                    if (petChose.petSheild <= 1)
                    {
                        sShield.Visibility = System.Windows.Visibility.Collapsed;
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = enemyAttack.Next(21, 25) - (petChose.defenseUP * 2);
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    }
                    if (petChose.petSheild > 1)
                    {
                        storyShieldBlock.Begin();
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = (enemyAttack.Next(30, 35) - petChose.defenseUP * 2) / 2;
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                        petChose.petSheild = petChose.petSheild - 1;
                        petChose.PetSheild.Remove("petShield");
                        petChose.PetSheild.Add("petShield", petChose.petSheild);
                        petChose.PetSheild.Save();


                    }

                }
                //Turtle
                if (petChose.enemyLvlSelected == 3)
                {
                    if (petChose.petSheild <= 1)
                    {
                        sShield.Visibility = System.Windows.Visibility.Collapsed;
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = enemyAttack.Next(21, 25) - (petChose.defenseUP * 2);
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    }
                    if (petChose.petSheild > 1)
                    {
                        storyShieldBlock.Begin();
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = (enemyAttack.Next(21, 25) - petChose.defenseUP * 2) / 2;
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();

                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                        petChose.petSheild = petChose.petSheild - 1;
                        petChose.PetSheild.Remove("petShield");
                        petChose.PetSheild.Add("petShield", petChose.petSheild);
                        petChose.PetSheild.Save();


                    }

                }
                //Monkey
                if (petChose.enemyLvlSelected == 4)
                {
                    if (petChose.petSheild <= 1)
                    {
                        sShield.Visibility = System.Windows.Visibility.Collapsed;
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = enemyAttack.Next(200, 210) - (petChose.defenseUP * 20);
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    }
                    if (petChose.petSheild > 1)
                    {
                        storyShieldBlock.Begin();
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = (enemyAttack.Next(150, 200) - petChose.defenseUP * 2) / 2;
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                        petChose.petSheild = petChose.petSheild - 1;
                        petChose.PetSheild.Remove("petShield");
                        petChose.PetSheild.Add("petShield", petChose.petSheild);
                        petChose.PetSheild.Save();


                    }

                }
                //Zombie
                if (petChose.enemyLvlSelected == 5)
                {
                    if (petChose.petSheild <= 1)
                    {
                        sShield.Visibility = System.Windows.Visibility.Collapsed;
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = enemyAttack.Next(30, 35) - (petChose.defenseUP * 2);
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    }
                    if (petChose.petSheild > 1)
                    {
                        storyShieldBlock.Begin();
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = (enemyAttack.Next(30, 35) - petChose.defenseUP * 2) / 2;
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                        petChose.petSheild = petChose.petSheild - 1;
                        petChose.PetSheild.Remove("petShield");
                        petChose.PetSheild.Add("petShield", petChose.petSheild);
                        petChose.PetSheild.Save();


                    }

                }
                //Robot
                if (petChose.enemyLvlSelected == 6)
                {
                    if (petChose.petSheild <= 1)
                    {
                        sShield.Visibility = System.Windows.Visibility.Collapsed;
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = enemyAttack.Next(350, 352) - (petChose.defenseUP * 20);
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    }
                    if (petChose.petSheild > 1)
                    {
                        storyShieldBlock.Begin();
                        int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                        EnemyDamageFromEnemysAttack = (enemyAttack.Next(350, 352) - petChose.defenseUP * 2) / 2;
                        playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                        txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                        txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                        petChose.petSheild = petChose.petSheild - 1;
                        petChose.PetSheild.Remove("petShield");
                        petChose.PetSheild.Add("petShield", petChose.petSheild);
                        petChose.PetSheild.Save();


                    }

                }
                if (petChose.petPoison > 1)
                {
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = (petChose.manaAttackUp * 100) - playerAttackPoison.Next(0, 11);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersPoisonSpell.Text = playerDamageFromPlayersAttack.ToString();
                    storyPoisonAttackDamage.Begin();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                    petChose.petPoison = petChose.petPoison - 1;
                    petChose.PetPoison.Remove("petPoison");
                    petChose.PetPoison.Add("petPoison", petChose.petPoison);
                    petChose.PetPoison.Save();

                }
                if (petChose.petCounterAttack == 1)
                {

                    Random anotherAttackChance = new Random();
                    playersSpeed = anotherAttackChance.Next(0, 10);
                    if (playersSpeed <= petChose.speedUP)
                    {

                        checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                  //Sound Gun Shot
                        if (petChose.petGunSlinger == 0)
                        {
                            int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                            playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                            EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                            txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                            storyGunShot.Begin();
                            storyCounterAttackandPoison.Begin();
                            txtCreaturesHealth.Text = EnemyHealth.ToString();
                            petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                            petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                            petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                            petChose.EnemyHealthPoints.Save();
                        }
                    }
                        if (petChose.petGunSlinger == 1)
                        {
                            int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                            playerDamageFromPlayersAttack = (petChose.attackUP * 100) - playerAttackPoison.Next(0, 11);
                            EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                            txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                            storyGunShot.Begin();
                            storyCounterAttackandPoison.Begin();
                            txtCreaturesHealth.Text = EnemyHealth.ToString();
                            petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                            petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                            petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                            petChose.EnemyHealthPoints.Save();


                        }


                    }
                
                if (EnemyHealth <= 0)
                {

                    EnemyHealth = 0;
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    EnemyHealth = 0;
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                }

                //Enemy Killed You....You have no more Health....
                if (playerHealthPoints <= 0)
                {
                    playerHealthPoints = 0;
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    VIIVoicesNoMoreHealth.Begin();
                }
            }
        
        




            //Attack 2
        private void storyEnemyAttack2Damage_Completed(object sender, EventArgs e)
        {
            Random enemyAttack2 = new Random();
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
              if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if(petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {

            petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);

            }
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);

            }
            if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
            {
                petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
            }
            Random playerAttackPoison = new Random();
            //Dog
            if (petChose.enemyLvlSelected == 1)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(21, 25) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild >= 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(21, 25) - petChose.defenseUP * 2)  / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();
                }
              
            }
            //Spider
            if (petChose.enemyLvlSelected == 2)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(11, 17) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild >= 7)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(11, 17) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();
                }

            }
            //Pickie
            if (petChose.enemyLvlSelected == 8)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(32, 37) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild >= 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(32, 37) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();
                }

            }
            //EvilButterfly
            if (petChose.enemyLvlSelected == 9)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(60,67 ) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild >= 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(65, 70) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();
                }

            }
            //Cat
            if (petChose.enemyLvlSelected == 2)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(30, 35) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(30, 35) - petChose.defenseUP * 2)  / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }
              
            }
            //Turtle
            if (petChose.enemyLvlSelected == 3)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(30, 35) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(30, 35) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }
                 
            }
            //Monkey
            if (petChose.enemyLvlSelected == 4)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(50, 55) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(50, 65) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }
              
            }
            //Zombie
            if (petChose.enemyLvlSelected == 5)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(50, 55) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(65, 70) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }
                 
            }
            //Robot
            if (petChose.enemyLvlSelected == 6)
            {
                if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(60, 70) - (petChose.defenseUP * 2);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
                if (petChose.petSheild > 1)
                {
                    storyShieldBlock.Begin();
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = (enemyAttack2.Next(65, 70) - petChose.defenseUP * 2) / 2;
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                    petChose.petSheild = petChose.petSheild - 1;
                    petChose.PetSheild.Remove("petShield");
                    petChose.PetSheild.Add("petShield", petChose.petSheild);
                    petChose.PetSheild.Save();


                }
              
            }
            if (petChose.petPoison > 1)
            {
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                playerDamageFromPlayersAttack = (petChose.manaAttackUp * 50) - playerAttackPoison.Next(0, 11);
                EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                txtDamageFromPlayersPoisonSpell.Text = playerDamageFromPlayersAttack.ToString();
                storyPoisonAttackDamage.Begin();
                txtCreaturesHealth.Text = EnemyHealth.ToString();
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                petChose.EnemyHealthPoints.Save();
                petChose.petPoison = petChose.petPoison - 1;
                petChose.PetPoison.Remove("petPoison");
                petChose.PetPoison.Add("petPoison", petChose.petPoison);
                petChose.PetPoison.Save();

            }
            if (petChose.petCounterAttack == 1)
            {

                 Random anotherAttackChance = new Random();
                   playersSpeed = anotherAttackChance.Next(0, 10);
                   if (playersSpeed <= petChose.speedUP )
                {
                    checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                  //Sound Gun Shot
                if (petChose.petGunSlinger == 0)
                {
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    storyGunShot.Begin();
                    storyCounterAttackandPoison.Begin();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                }
                if (petChose.petGunSlinger == 1)
                {
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    playerDamageFromPlayersAttack = (petChose.attackUP * 100) - playerAttackPoison.Next(0, 11);
                    EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                    txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                    storyGunShot.Begin();
                    storyCounterAttackandPoison.Begin();
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                    petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                    petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                    petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                    petChose.EnemyHealthPoints.Save();
                
                
                }


            }
            }
            if (EnemyHealth <= 0)
            {

                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            //Enemy Killed You....You have no more Health....
            if (playerHealthPoints <= 0)
            {
                playerHealthPoints = 0;
                txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                VIIVoicesNoMoreHealth.Begin();
            }

        }
        //Specfic enemies and special attacks
        //Monkey
        private void storyMonkeyAttackDamage_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {

                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);

            }
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);
            }
            if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
            {
                petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
            }
            
            Random playerAttackPoison = new Random();
            Random enemyAttack2 = new Random();
            if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                    EnemyDamageFromEnemysAttack = enemyAttack2.Next(250, 300) - (petChose.defenseUP * 20);
                    playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                    txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                    txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
             if (petChose.petSheild > 1)
             {
                 storyShieldBlock.Begin();
                 int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                 EnemyDamageFromEnemysAttack = (enemyAttack2.Next(265, 270) - petChose.defenseUP * 2) / 2;
                 playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                 txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                 txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                 petChose.petSheild = petChose.petSheild - 1;
                 petChose.PetSheild.Remove("petShield");
                 petChose.PetSheild.Add("petShield", petChose.petSheild);
                 petChose.PetSheild.Save();
             }
          if (petChose.petPoison > 1)
                    {
                        int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                        playerDamageFromPlayersAttack = (petChose.manaAttackUp * 100) - playerAttackPoison.Next(0, 11);
                        EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                        txtDamageFromPlayersPoisonSpell.Text = playerDamageFromPlayersAttack.ToString();
                        storyPoisonAttackDamage.Begin();
                        txtCreaturesHealth.Text = EnemyHealth.ToString();
                        petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                        petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                        petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                        petChose.EnemyHealthPoints.Save();
                        petChose.petPoison = petChose.petPoison -1;
                        petChose.PetPoison.Remove("petPoison");
                        petChose.PetPoison.Add("petPoison",petChose.petPoison);
                        petChose.PetPoison.Save();

                    }
          if (petChose.petCounterAttack == 1)
          {

              Random anotherAttackChance = new Random();
              playersSpeed = anotherAttackChance.Next(0, 10);
              if (playersSpeed <= petChose.speedUP)
              {

                  if (petChose.petGunSlinger == 0)
                  {
                      checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                  //Sound Gun Shot
                      int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                      playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                      EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                      txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                      storyGunShot.Begin();
                      storyCounterAttackandPoison.Begin();
                      txtCreaturesHealth.Text = EnemyHealth.ToString();
                      petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                      petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                      petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                      petChose.EnemyHealthPoints.Save();
                  }
                  if (petChose.petGunSlinger == 1)
                  {
                      int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                      playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                      EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                      txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                      storyGunShot.Begin();
                      storyCounterAttackandPoison.Begin();
                      txtCreaturesHealth.Text = EnemyHealth.ToString();
                      petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                      petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                      petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                      petChose.EnemyHealthPoints.Save();


                  }


              }
          }




                 if (EnemyHealth <= 0)
                 {

                     EnemyHealth = 0;
                     int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                     EnemyHealth = 0;
                     txtCreaturesHealth.Text = EnemyHealth.ToString();
                 }
             
    
             //Enemy Killed You....You have no more Health....
             if (playerHealthPoints <= 0)
             {
                 playerHealthPoints = 0;
                 txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                 VIIVoicesNoMoreHealth.Begin();
             }
        }
        //Zombie
        private void storyZombieAttackDamage_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {

                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);

            }
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);

            }
            if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
            {
                petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
            }
            
            Random playerAttackPoison = new Random();
            Random enemyAttack = new Random();
            if (petChose.petSheild <= 1)
                {
                    sShield.Visibility = System.Windows.Visibility.Collapsed;
                    int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
            int.TryParse(txtPlayerManaPoints.Text, out playerManaPoints);
            EnemyDamageFromEnemysAttack2 = enemyAttack.Next(60, 65) - (petChose.defenseUP * 2);
            playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack2;
            if (playerManaPoints >= 5)
            {
                playerManaPoints = playerManaPoints - 5;
            }
            txtPlayerManaPoints.Text = playerManaPoints.ToString();
            txtDamageFromEnemysAttack.Text = (EnemyDamageFromEnemysAttack2 + "   -5MP").ToString();
            txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                }
             if (petChose.petSheild > 1)
             {
                 storyShieldBlock.Begin();
                 int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                 int.TryParse(txtPlayerManaPoints.Text, out playerManaPoints);
                 EnemyDamageFromEnemysAttack2 = (enemyAttack.Next(65, 70) - petChose.defenseUP * 2) / 2;
                 playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack2;
                 playerManaPoints = playerManaPoints - 2;
                 txtPlayerManaPoints.Text = playerManaPoints.ToString();
                 txtDamageFromEnemysAttack.Text = (EnemyDamageFromEnemysAttack2 + "   -2MP").ToString();
                 txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                 petChose.petSheild = petChose.petSheild - 1;
                 petChose.PetSheild.Remove("petShield");
                 petChose.PetSheild.Add("petShield", petChose.petSheild);
                 petChose.PetSheild.Save();



             }
             if (petChose.petPoison > 1)
             {
                 int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                 playerDamageFromPlayersAttack = (petChose.manaAttackUp * 50) - playerAttackPoison.Next(0, 11);
                 EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                 txtDamageFromPlayersPoisonSpell.Text = playerDamageFromPlayersAttack.ToString();
                 storyPoisonAttackDamage.Begin();
                 txtCreaturesHealth.Text = EnemyHealth.ToString();
                 petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                 petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                 petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                 petChose.EnemyHealthPoints.Save();
                 petChose.petPoison = petChose.petPoison - 1;
                 petChose.PetPoison.Remove("petPoison");
                 petChose.PetPoison.Add("petPoison", petChose.petPoison);
                 petChose.PetPoison.Save();

             }
             if (petChose.petCounterAttack == 1)
             {

                 Random anotherAttackChance = new Random();
                 playersSpeed = anotherAttackChance.Next(0, 10);
                 if (playersSpeed <= petChose.speedUP)
                 {
                     checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                  //Sound Gun Shot
                     if (petChose.petGunSlinger == 0)
                     {
                         int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                         playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                         EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                         txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                         storyGunShot.Begin();
                         storyCounterAttackandPoison.Begin();
                         txtCreaturesHealth.Text = EnemyHealth.ToString();
                         petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                         petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                         petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                         petChose.EnemyHealthPoints.Save();
                     }
                     if (petChose.petGunSlinger == 1)
                     {
                         int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                         playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                         EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                         txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                         storyGunShot.Begin();
                         storyCounterAttackandPoison.Begin();
                         txtCreaturesHealth.Text = EnemyHealth.ToString();
                         petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                         petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                         petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                         petChose.EnemyHealthPoints.Save();


                     }


                 }
             }

             if (EnemyHealth <= 0)
             {

                 EnemyHealth = 0;
                 int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                 EnemyHealth = 0;
                 txtCreaturesHealth.Text = EnemyHealth.ToString();
             }
             //Enemy Killed You....You have no more Health....
             if (playerHealthPoints <= 0)
             {
                 playerHealthPoints = 0;
                 txtPlayersHealthPoints.Text = playerHealthPoints.ToString(); 
                 VIIVoicesNoMoreHealth.Begin();
             }
        }
        private void storyRobotAttackDamage_Completed(object sender, EventArgs e)
        {
            if (petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp))
            {
                petChose.ManaAttackUP.TryGetValue("manaAttackUp", out petChose.manaAttackUp);
            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            if (petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison))
            {

                petChose.PetPoison.TryGetValue("petPoison", out petChose.petPoison);

            }
            if (petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petShield", out petChose.petSheild);

            }
        
            if (petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP))
            {
                petChose.DefenseUP.TryGetValue("petDefenseUP", out petChose.defenseUP);
            }
           
            Random enemyAttack2 = new Random();
            Random playerAttackPoison = new Random();
            if (petChose.petSheild <= 1)
            {
                sShield.Visibility = System.Windows.Visibility.Collapsed;
                int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                EnemyDamageFromEnemysAttack = enemyAttack2.Next(300, 308) - (petChose.defenseUP*2);
                playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
            }
            if (petChose.petSheild > 1)
            {
                storyShieldBlock.Begin();
                int.TryParse(txtPlayersHealthPoints.Text, out playerHealthPoints);
                EnemyDamageFromEnemysAttack = (enemyAttack2.Next(307,308) - petChose.defenseUP * 2) / 2;
                playerHealthPoints = playerHealthPoints - EnemyDamageFromEnemysAttack;
                txtDamageFromEnemysAttack.Text = EnemyDamageFromEnemysAttack.ToString();
                txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                petChose.petSheild = petChose.petSheild - 1;
                petChose.PetSheild.Remove("petShield");
                petChose.PetSheild.Add("petShield", petChose.petSheild);
                petChose.PetSheild.Save();
            }
           if (petChose.petPoison > 1)
                    {
                        int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                        playerDamageFromPlayersAttack = (petChose.manaAttackUp * 100) - playerAttackPoison.Next(0, 11);
                        EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                        txtDamageFromPlayersPoisonSpell.Text = playerDamageFromPlayersAttack.ToString();
                        storyPoisonAttackDamage.Begin();
                        txtCreaturesHealth.Text = EnemyHealth.ToString();
                        petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                        petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                        petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                        petChose.EnemyHealthPoints.Save();
                        petChose.petPoison = petChose.petPoison -1;
                        petChose.PetPoison.Remove("petPoison");
                        petChose.PetPoison.Add("petPoison",petChose.petPoison);
                        petChose.PetPoison.Save();

                    }
           if (petChose.petCounterAttack == 1)
           {

               Random anotherAttackChance = new Random();
               playersSpeed = anotherAttackChance.Next(0, 10);
               if (playersSpeed <= petChose.speedUP)
               {
                   checkSound.gunShot(checkSound.soundOffOrOn);                                                                                                                                  //Sound Gun Shot
                   if (petChose.petGunSlinger == 0)
                   {
                       int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                       playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                       EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                       txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                       storyGunShot.Begin();
                       storyCounterAttackandPoison.Begin();
                       txtCreaturesHealth.Text = EnemyHealth.ToString();
                       petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                       petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                       petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                       petChose.EnemyHealthPoints.Save();
                   }
                   if (petChose.petGunSlinger == 1)
                   {
                       int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                       playerDamageFromPlayersAttack = (petChose.attackUP * 50) - playerAttackPoison.Next(0, 11);
                       EnemyHealth = EnemyHealth - playerDamageFromPlayersAttack;
                       txtDamageFromPlayersAttack.Text = playerDamageFromPlayersAttack.ToString();
                       storyGunShot.Begin();
                       storyCounterAttackandPoison.Begin();
                       txtCreaturesHealth.Text = EnemyHealth.ToString();
                       petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
                       petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                       petChose.EnemyHealthPoints.Add("enemyHealthPoints", EnemyHealth);
                       petChose.EnemyHealthPoints.Save();


                   }


               }
           }

                if (EnemyHealth <= 0)
                {
                  
                    EnemyHealth = 0;
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    EnemyHealth = 0;
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                }

            //Enemy Killed You....You have no more Health....
            if (playerHealthPoints <= 0)
            {
                playerHealthPoints = 0;
                txtPlayersHealthPoints.Text = playerHealthPoints.ToString();
                VIIVoicesNoMoreHealth.Begin();
            }
        }














     //SAVES AND SETS SPIRITBAR POINTS FROM THE ATTACK
        //Attack 1
        private void storyEnemyAttack1_Completed(object sender, EventArgs e)
        {
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }

            if (SpiritLimitBar.Width >= 197)
            {
                btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Visible;
                storySpiritBarIsFull.Begin();
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;
  
            }
            if (SpiritLimitBar.Width < 197)
            {
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;
         
            }
            storyEnemyAttack1.Stop();
            storyEnemyAttack1Damage.Stop();
            //Save playerHealth
            petChose.HealthPoints.Remove("healthPoints");
            petChose.HealthPoints.Add("healthPoints", playerHealthPoints);
            petChose.HealthPoints.Save();

         
                //spiritLimitIncrease by each attack
                SpiritLimitBar.Width = SpiritLimitBar.Width + 100;

                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();

                if (petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
                {
                    petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
                }
            if (petChose.spiritLimit >= 197)
            {

                storySpiritBarIsFull.Begin();
                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
            }
         
        }
        //Attack 2


        private void storyEnemyAttack2_Completed_1(object sender, EventArgs e)
        {
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            if (SpiritLimitBar.Width >= 197)
            {
                btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Visible;
                storySpiritBarIsFull.Begin();
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;
                
            }
            if (SpiritLimitBar.Width < 197)
            {
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;
                
            }
            storyEnemyAttack2.Stop();
            storyEnemyAttack2Damage.Stop();
            //Save playerHealth
            petChose.HealthPoints.Remove("healthPoints");
            petChose.HealthPoints.Add("healthPoints", playerHealthPoints);
            petChose.HealthPoints.Save();
         
                //spiritLimitIncrease by each attack
                SpiritLimitBar.Width = SpiritLimitBar.Width + 30;

                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
                if (petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
                {
                    petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
                }      
            
         
            if (petChose.spiritLimit >= 197)
            {

                storySpiritBarIsFull.Begin();
                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
            }
   
        }

        //Specfic enemies and special attacks
        //Monkey Attack
        private void storyMonkeyAttack_Completed(object sender, EventArgs e)
        {
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            if (SpiritLimitBar.Width >= 197)
            {
                btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Visible;
                storySpiritBarIsFull.Begin();
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;
              
            }
            if(SpiritLimitBar.Width <197)
            {
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;
              
            }
            storyMonkeyAttack.Stop();
            storyMonkeyAttackDamage.Stop();
            //Save playerHealth
            petChose.HealthPoints.Remove("healthPoints");
            petChose.HealthPoints.Add("healthPoints", playerHealthPoints);
            petChose.HealthPoints.Save();
            
            
                //spiritLimitIncrease by each attack
                SpiritLimitBar.Width = SpiritLimitBar.Width + 50;

                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
                if (petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
                {
                    petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
                }
            
            if (petChose.spiritLimit >= 197)
            {

                storySpiritBarIsFull.Begin();
                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
            }
        }
//Zombie Attack
        private void storyZombieAttack_Completed(object sender, EventArgs e)
        {
            if (EnemyHealth <= 0)
            {
                storyEnemyDefeated.Begin();
                EnemyHealth = 0;
                int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                EnemyHealth = 0;
                txtCreaturesHealth.Text = EnemyHealth.ToString();
            }
            if (SpiritLimitBar.Width >= 197)
            {
                btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Visible;
                storySpiritBarIsFull.Begin();
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;

            }
            if (SpiritLimitBar.Width < 197)
            {
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;

            }
            storyZombieAttack.Stop();
            storyZombieAttackDamage.Stop();
            //Save playerHealth
            petChose.HealthPoints.Remove("healthPoints");
            petChose.HealthPoints.Add("healthPoints", playerHealthPoints);
            petChose.HealthPoints.Save();

            petChose.ManaPoints.Remove("manaPoints");
            petChose.ManaPoints.Add("manaPoints", playerManaPoints);
            petChose.ManaPoints.Save();
            //spiritLimitIncrease by each attack
            SpiritLimitBar.Width = SpiritLimitBar.Width + 50;

            petChose.SpiritLimit.Remove("spiritLimit");
            petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
            petChose.SpiritLimit.Save();
            if (petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
            {
                petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
            }

            if (petChose.spiritLimit >= 197)
            {

                storySpiritBarIsFull.Begin();
                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
            }
        }
//Robot
        private void storyRobotAttack_Completed(object sender, EventArgs e)
            {
                if (EnemyHealth <= 0)
                {
                    storyEnemyDefeated.Begin();
                    EnemyHealth = 0;
                    int.TryParse(txtCreaturesHealth.Text, out EnemyHealth);
                    EnemyHealth = 0;
                    txtCreaturesHealth.Text = EnemyHealth.ToString();
                }
            if (SpiritLimitBar.Width >= 197)
            {
                btnSpiritBarIsFull.Visibility = System.Windows.Visibility.Visible;
                storySpiritBarIsFull.Begin();
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;

            }
            if (SpiritLimitBar.Width < 197)
            {
                ActionButton.Visibility = System.Windows.Visibility.Visible;
                ManaButton.Visibility = System.Windows.Visibility.Visible;

            }
            storyRobotAttack.Stop();
            storyRobotAttackDamage.Stop();
            //Save playerHealth
            petChose.HealthPoints.Remove("healthPoints");
            petChose.HealthPoints.Add("healthPoints", playerHealthPoints);
            petChose.HealthPoints.Save();


            //spiritLimitIncrease by each attack
            SpiritLimitBar.Width = SpiritLimitBar.Width + 50;

            petChose.SpiritLimit.Remove("spiritLimit");
            petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
            petChose.SpiritLimit.Save();
            if (petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit))
            {
                petChose.SpiritLimit.TryGetValue("spiritLimit", out petChose.spiritLimit);
            }

            if (petChose.spiritLimit >= 197)
            {

                storySpiritBarIsFull.Begin();
                petChose.SpiritLimit.Remove("spiritLimit");
                petChose.SpiritLimit.Add("spiritLimit", SpiritLimitBar.Width);
                petChose.SpiritLimit.Save();
            }
        }

     

      //Enemy Health
        public void  selectAndSetHealth()
        {
            if (petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected))
            {
                petChose.EnemyLvlSelected.TryGetValue("enemyLvlSelected", out petChose.enemyLvlSelected);

            }
            if (petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints))
            {
                petChose.EnemyHealthPoints.TryGetValue("enemyHealthPoints", out petChose.enemyHealthPoints);
            }
            int SelectLvl;
        
            Random enemyLvlSelect= new Random();
         

            SelectLvl = enemyLvlSelect.Next(1,10);
            if (SelectLvl == 1)
            {
                //When Chosing Lvl and Creature to battle give a number.
                petChose.EnemyLvlSelected.Remove("enemyLvlSelected");
                petChose.EnemyLvlSelected.Add("enemyLvlSelected", 1);//ENEMY NUMBER
                petChose.EnemyLvlSelected.Save();
                //Enemy Health Lvl 1 enemy 1
                petChose.EnemyHealthPoints.Remove("enemyHealthPoints");
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 250);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 250);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 375);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints",750);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 5000);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 5000);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 500);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 500);//ENEMY HEALTH
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
                petChose.EnemyHealthPoints.Add("enemyHealthPoints", 250);//ENEMY HEALTH
                petChose.EnemyHealthPoints.Save();
            }
        }
        //Media
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

        private void btnFlee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted))
            {
                petChose.GameStarted.TryGetValue("gameStarted", out petChose.gameStarted);

            }
            if (petChose.gameStarted == 13)
            {
                MessageBox.Show("Can't Flee");
            }
            else
            {
                MessageBoxResult results;
                results = MessageBox.Show("Try to flee?", "Flee...", MessageBoxButton.OKCancel);
                if (results == MessageBoxResult.OK)
                {

                    this.NavigationService.GoBack();

                }
            }
              
            
        }

        private void VIIVoicesNoMoreHealth_Completed(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (petChose.Pause.TryGetValue("pause", out petChose.pause))
            {
                petChose.Pause.TryGetValue("pause", out petChose.pause);
            }
            if (petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive))
            {
                petChose.PauseActive.TryGetValue("pauseActive", out petChose.pauseActive);
            }

            if (petChose.pause == 1)
            {
                e.Cancel = true;
                canvasItems.Visibility = System.Windows.Visibility.Collapsed;
                ReadyToUseItem.Visibility = System.Windows.Visibility.Collapsed;
                ReadyForAttack.Visibility = System.Windows.Visibility.Collapsed;
                ReadyForMagicAttack.Visibility = System.Windows.Visibility.Collapsed;


                canvasMagicSpells2.Visibility = System.Windows.Visibility.Collapsed;
                canvasMagicSpells3.Visibility = System.Windows.Visibility.Collapsed;
                canvasMagicSpells4.Visibility = System.Windows.Visibility.Collapsed;
                canvasManaSpells.Visibility = System.Windows.Visibility.Collapsed;
                ActionList.Visibility = System.Windows.Visibility.Collapsed;

                magicLeftHand.Visibility = System.Windows.Visibility.Collapsed;
                noMagicLeftHand.Visibility = System.Windows.Visibility.Visible;
                storyArrowDown.Stop();
                storyArrowUp.Stop();
                canvasSpells.Visibility = System.Windows.Visibility.Collapsed;



                btnActions.Visibility = System.Windows.Visibility.Visible;
                btnManaOpenMenu.Visibility = System.Windows.Visibility.Visible;


                petChose.Pause.Remove("pause");
                petChose.Pause.Add("pause", 0);
                petChose.Pause.Save();
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Can't Flee");


            }
        }
       


     

       

        

       

     

        

        

        
     

   
      

     

     

        

     

       

       
    }
}