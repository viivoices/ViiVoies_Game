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

namespace myBuddies
{
    public partial class WorldMap : PhoneApplicationPage
    {
        IsoStorage petChose = new IsoStorage();
        Sound checkSound = new Sound();
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
        public WorldMap()
        {
            InitializeComponent();
            
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo))
            {
                petChose.TownWantingToGo.TryGetValue("townWantingToGo", out petChose.townWantingToGo);
            }
            //TryParse the for Everything Health,Magic,Level,Exp,Points
            int.TryParse(txtPlayersHealthPoints.Text, out Health);
            int.TryParse(txtMaxHealthPoints.Text, out maxHelth);
            int.TryParse(txtPlayerManaPoints.Text, out Mana);
            int.TryParse(txtMaxManaPoints.Text, out maxMana);
            int.TryParse(txtPlayerLevel.Text, out Level);
            int.TryParse(txtPlayerExp.Text, out Exp);
            int.TryParse(txtPlayersPoints.Text, out Points);










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
            if (petChose.PetSheild.TryGetValue("petSheild", out petChose.petSheild))
            {
                petChose.PetSheild.TryGetValue("petSheild", out petChose.petSheild);
                if (petChose.petSheild > 1)
                {
                    petChose.petSheild = 1;
                    //Save Sheild
                    petChose.PetSheild.Remove("petSheild");
                    petChose.PetSheild.Add("petSheild", petChose.petSheild);
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
            if (petChose.PetCureAll.TryGetValue("petCureAll", out petChose.petCureAll))
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
            if (petChose.PetFallenAngels.TryGetValue("petFallenAngels", out petChose.petFallenAngels))
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
            storyEyes.Begin();




            //EXP
            //Getting Pets EXP

            if (petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints))
            {
                petChose.ExpPoints.TryGetValue("expPoints", out petChose.expPoints);
                txtPlayerExp.Text = petChose.expPoints.ToString();
            }


            //The Level Ups
            if (petChose.expPoints >= 0 && petChose.expPoints <= 250)
            {
                txtPlayerLevel.Text = 1.ToString();
                txtPlayerNextLevel.Text = (250 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 251 && petChose.expPoints <= 800)
            {
                txtPlayerLevel.Text = 2.ToString();
                txtPlayerNextLevel.Text = (800 - petChose.expPoints).ToString();
            }
            if (petChose.expPoints >= 801 && petChose.expPoints <= 1500)
            {
                txtPlayerLevel.Text = 3.ToString();
                txtPlayerNextLevel.Text = (1500 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 1501 && petChose.expPoints <= 2500)
            {
                txtPlayerLevel.Text = 4.ToString();
                txtPlayerNextLevel.Text = (2500 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 2501 && petChose.expPoints <= 3500)
            {
                txtPlayerLevel.Text = 5.ToString();
                txtPlayerNextLevel.Text = (3500 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;

            }
            if (petChose.expPoints >= 3501 && petChose.expPoints <= 4700)
            {
                txtPlayerLevel.Text = 6.ToString();
                txtPlayerNextLevel.Text = (4700 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 4701 && petChose.expPoints <= 7500)
            {
                txtPlayerLevel.Text = 7.ToString();
                txtPlayerNextLevel.Text = (7500 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 7501 && petChose.expPoints <= 11000)
            {
                txtPlayerLevel.Text = 8.ToString();
                txtPlayerNextLevel.Text = (11000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 11001 && petChose.expPoints <= 18000)
            {
                txtPlayerLevel.Text = 9.ToString();
                txtPlayerNextLevel.Text = (18000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 18001 && petChose.expPoints <= 30000)
            {
                txtPlayerLevel.Text = 10.ToString();
                txtPlayerNextLevel.Text = (30000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 30001 && petChose.expPoints <= 45000)
            {
                txtPlayerLevel.Text = 11.ToString();
                txtPlayerNextLevel.Text = (45000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 45001 && petChose.expPoints <= 65000)
            {
                txtPlayerLevel.Text = 12.ToString();
                txtPlayerNextLevel.Text = (65000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 65001 && petChose.expPoints <= 87000)
            {
                txtPlayerLevel.Text = 13.ToString();
                txtPlayerNextLevel.Text = (85000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 85001 && petChose.expPoints <= 101777)
            {
                txtPlayerLevel.Text = 14.ToString();
                txtPlayerNextLevel.Text = (101777 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 101778 && petChose.expPoints <= 130000)
            {
                txtPlayerLevel.Text = 15.ToString();
                txtPlayerNextLevel.Text = (130000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 130001 && petChose.expPoints <= 1600000)
            {
                txtPlayerLevel.Text = 16.ToString();
                txtPlayerNextLevel.Text = (160000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 160001 && petChose.expPoints <= 200000)
            {
                txtPlayerLevel.Text = 17.ToString();
                txtPlayerNextLevel.Text = (200000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 200001 && petChose.expPoints <= 250000)
            {
                txtPlayerLevel.Text = 18.ToString();
                txtPlayerNextLevel.Text = (250000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 250001 && petChose.expPoints <= 310000)
            {
                txtPlayerLevel.Text = 19.ToString();
                txtPlayerNextLevel.Text = (310000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 310001 && petChose.expPoints <= 380000)
            {
                txtPlayerLevel.Text = 20.ToString();
                txtPlayerNextLevel.Text = (380000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 380001 && petChose.expPoints <= 470000)
            {
                txtPlayerLevel.Text = 21.ToString();
                txtPlayerNextLevel.Text = (470000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 470001 && petChose.expPoints <= 570000)
            {
                txtPlayerLevel.Text = 22.ToString();
                txtPlayerNextLevel.Text = (570000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 570001 && petChose.expPoints <= 680000)
            {
                txtPlayerLevel.Text = 23.ToString();
                txtPlayerNextLevel.Text = (680000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 680001 && petChose.expPoints <= 790000)
            {
                txtPlayerLevel.Text = 24.ToString();
                txtPlayerNextLevel.Text = (790000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
            if (petChose.expPoints >= 790001 && petChose.expPoints <= 1500000)
            {
                txtPlayerLevel.Text = 25.ToString();
                txtPlayerNextLevel.Text = (1500000 - petChose.expPoints).ToString();
                canvasLevelUp.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //End of Loading everything on page//
        /////////////////////////////////////////////////////////

        //////////////////Player Level Up///////////////////////
        //Level Up System     
        private void btnContinueLvlUp_Click(object sender, RoutedEventArgs e)
        {
            canvasLevelUp.Visibility = System.Windows.Visibility.Collapsed;
        }


























        //The Button for Store,Items and Fight//
        //////////////////////////////////////////////////////////////

        ///////////////////Start Of Shop Area//////////////////

        //Store Buttons
        //Open and Close Buttons
        private void btnShop_Click(object sender, RoutedEventArgs e)//OpenShop
        {

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

            canvasShop.Visibility = System.Windows.Visibility.Visible;


        }//
        private void btnCancelStore_Click(object sender, RoutedEventArgs e)//CloseShop
        { canvasShop.Visibility = System.Windows.Visibility.Collapsed; }//

        private void btnCancelBuy_Click(object sender, RoutedEventArgs e)//Close information of item canvas
        {
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
            txtItemAndDescription.Text = "A low end remedy that will replenish 100 Health";
            txtPointsForItemToBuy.Text = "150";
        }

        //XPotion
        private void btnButXPotion_Click(object sender, RoutedEventArgs e)
        {
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

            txtItemAndDescription.Text = "A Middle end remedy that will replenish 350 Health";
            txtPointsForItemToBuy.Text = "300";
        }

        //Mana Potion
        private void btnBuyManaPotion_Click(object sender, RoutedEventArgs e)
        {
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
            txtItemAndDescription.Text = "A blueish type of potion that replenishes 25 Mana";
            txtPointsForItemToBuy.Text = "150";
        }

        //Holy Water
        private void btnBuyHolyWater_Click(object sender, RoutedEventArgs e)
        {
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
            txtPointsForItemToBuy.Text = "500";
        }
        //Spells
        //Lightning
        private void btnBuyLigtning_Click(object sender, RoutedEventArgs e)
        {
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

            itemSelected = 21;
            txtItemName.Text = "Counter Attack Orb";
            canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Visible;
            txtItemAndDescription.Text = "(-Ability-) Counter attack almost every attack an enemy performs on you(Counter attack depends on your speed level. the higher your speed the better chance of a counter attack occuring).  ";
            txtPointsForItemToBuy.Text = "10000";

        }

        //FallenAngels
        private void btnBuyFallenAngels_Click(object sender, RoutedEventArgs e)
        {
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

            itemSelected = 10;
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
                if (Points < 150) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");
                //subtract the amount of potion 150 from points.    
                if (Points >= 150)
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    //Save potion
                    petChose.petPoints = petChose.petPoints - 150;
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
                if (Points < 300) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");
                //subtract the amount of potion 300 from points.    
                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 300;
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
                if (Points < 150) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 150;
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
                if (Points < 500) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");

                else
                {
                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 500;
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


                else
                {

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
            if (itemBeingUsed == 15)
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
            if (itemSelected == 16)
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
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

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
            if (itemSelected == 22)
            {
                int.TryParse(txtPlayersPoints.Text, out Points);
                if (Points < 5000) MessageBox.Show("Sorry, you don't have enough points to purchase this item.");


                else
                {

                    canvasItemBought.Visibility = System.Windows.Visibility.Visible;
                    canvasDescriptionOfItemAndToBuy.Visibility = System.Windows.Visibility.Collapsed;
                    petChose.petPoints = petChose.petPoints - 5000;

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
            canvasItemBought.Visibility = System.Windows.Visibility.Collapsed;
        }





        /////////End of Shop Area//////////
        ///////////////////////////////////////////////





        ///////////Your Item Inventory/////////////
        ////////////////////////////////////////////////////////

        private void btnItem_Click(object sender, RoutedEventArgs e)//OpenItems
        {

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
            if (petChose.manaPoints >= 1)
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
            itemBeingUsed = 1;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Potion: Replinish 100 Health.";
        }
        //XPotion
        private void btnXPotionItemInv_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 2;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "XPotion: Replinish 300 Health.";

        }
        //Mana Items
        //Mana Potion
        private void btnManaPotion_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 3;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Mana Potion: Replinish 25 Mana. ";
        }
        //Holy Water   
        private void btnHolyWater_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 4;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Holy Water: Cleanase your soul to replinish all Mana.";
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 5;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Cast Heal: For 5MP Heal a small amount of Health";
        }
        private void btnCureAll_Click(object sender, RoutedEventArgs e)
        {
            itemBeingUsed = 6;
            CanvasUseItem.Visibility = System.Windows.Visibility.Visible;
            txtUseItem.Text = "Cast Cure-All: Fully heal yourself 25MP ";
        }
        //Checks above to see which itembingused by the number given and does the action if player choses btnYesUseItem
        //Main Item Button that Holds all the items and sees if the user wants to use it and if so does all the actions    
        private void btnYesUseItem_Click(object sender, RoutedEventArgs e)
        {
            if (itemBeingUsed == 1)
            {
                int.TryParse(txtMaxHealthPoints.Text, out petChose.maxHealthPoints);
                int.TryParse(txtTotalPotion.Text, out petChose.petPotion);
                int.TryParse(txtPlayersHealthPoints.Text, out petChose.healthPoints);
                if (petChose.petPotion > 0 && petChose.healthPoints < petChose.maxHealthPoints)
                {
                    UsingPotions.Begin();
                    petChose.petPotion = petChose.petPotion - 1;
                    petChose.healthPoints = petChose.healthPoints + 100;

                    txtPlusHealth.Text = "+100";
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
                {
                    MessageBox.Show("Your already at full health");
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
                    petChose.healthPoints = petChose.healthPoints + 350;
                    txtPlusHealth.Text = "+350";
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
                {
                    MessageBox.Show("You're already at full health");
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
                    petChose.manaPoints = petChose.manaPoints + 25;
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
                    txtPlusMana.Text = "+" + petChose.maxManaPoints;
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


                if (petChose.manaPoints >= 5 && petChose.healthPoints < petChose.maxHealthPoints)
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
            CanvasUseItem.Visibility = System.Windows.Visibility.Collapsed;
        }


        //Simply closes item canvas cancel button to close
        private void btnItemCancel_Click(object sender, RoutedEventArgs e)//CloseItems
        {
            canvasItems.Visibility = System.Windows.Visibility.Collapsed;

        }





        /////End of Item Invetory////
        ///////////////////////////////////////////




        //Fight Button//Also saves any changes made with points by purchasing things Select an Enemy
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnFight_Click(object sender, RoutedEventArgs e)
        {



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

            canvasPetsHome.Visibility = System.Windows.Visibility.Collapsed;





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



        }
      













        //World Map Portion
        private void btnObar_Click(object sender, RoutedEventArgs e)
        {
            petChose.townWantingToGo = 1;
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnAndion_Click(object sender, RoutedEventArgs e)
        {
            petChose.townWantingToGo = 2;
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnTheLost_Click(object sender, RoutedEventArgs e)
        {
            petChose.townWantingToGo = 3;
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Visible;
        }
        private void btnEggnon_Click(object sender, RoutedEventArgs e)
        {
            petChose.townWantingToGo = 4;
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Visible;
        }
  private void btnGuardiansFortress_Click(object sender, RoutedEventArgs e)
        {
            petChose.townWantingToGo = 5;
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnLandOfFallen_Click(object sender, RoutedEventArgs e)
        {
            petChose.townWantingToGo = 6;
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Visible;
        }
//Canvas Asking Player If They Are Ready To Travel
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            canvasAreYouReadyToGoToTown.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnBeginJourneyWalk_Click(object sender, RoutedEventArgs e)
        {
            petChose.TownWantingToGo.Remove("townWantingToGo");
            petChose.TownWantingToGo.Add("townWantingToGo", petChose.townWantingToGo);
            petChose.TownWantingToGo.Save();
        }

        private void btnTeleport_Click(object sender, RoutedEventArgs e)
        {
            petChose.TownWantingToGo.Remove("townWantingToGo");
            petChose.TownWantingToGo.Add("townWantingToGo", petChose.townWantingToGo);
            petChose.TownWantingToGo.Save();
        }

        private void btnContinue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petChose.townIn == 1)
            {
                this.NavigationService.Navigate(new Uri("/WalkingObar", UriKind.Relative));
            }
                if(petChose.townIn==2)
                {
                //in Andion
                }
                if (petChose.townIn == 3)
                {
                    //in Fortress
                }
                if (petChose.townIn == 4)
                {
                    //The Lost
                }
                if (petChose.townIn == 5)
                {//in Eggnon
                }
                if (petChose.townIn == 6)
                { 
                //The Fallen
                }
            }

     

      
    }
}