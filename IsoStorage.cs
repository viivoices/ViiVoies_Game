using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.IO.IsolatedStorage;
namespace myBuddies
{
    public class IsoStorage
    {

                                                    //Main Attributes of the Player and Enemy
                                                   ///////////////////////////////////////////////////////////////
        public IsolatedStorageSettings GameStarted= IsolatedStorageSettings.ApplicationSettings;
        public int gameStarted;

        public IsolatedStorageSettings Quest = IsolatedStorageSettings.ApplicationSettings;
        public int quest;

        public IsolatedStorageSettings ChurchCreature = IsolatedStorageSettings.ApplicationSettings;
        public int churchCreature;
               
        public IsolatedStorageSettings PetLevel = IsolatedStorageSettings.ApplicationSettings;
        public int petLevel;

        public IsolatedStorageSettings HealthPoints = IsolatedStorageSettings.ApplicationSettings;
        public int healthPoints;

        public IsolatedStorageSettings MaxHealthPoints = IsolatedStorageSettings.ApplicationSettings;
        public int maxHealthPoints;


        public IsolatedStorageSettings ManaPoints = IsolatedStorageSettings.ApplicationSettings;
        public int manaPoints;

        public IsolatedStorageSettings MaxManaPoints = IsolatedStorageSettings.ApplicationSettings;
        public int maxManaPoints;

        public IsolatedStorageSettings EnemyHealthPoints = IsolatedStorageSettings.ApplicationSettings;
        public int enemyHealthPoints;

        public IsolatedStorageSettings EnemyLvlSelected = IsolatedStorageSettings.ApplicationSettings;
        public int enemyLvlSelected;

        public IsolatedStorageSettings SpiritLimit = IsolatedStorageSettings.ApplicationSettings;
        public double spiritLimit;



                                                                    //The Level Up Pieces
                                                                   ////////////////////////////////////
        public IsolatedStorageSettings UpgradePoints = IsolatedStorageSettings.ApplicationSettings;
        public int upgradePoints;
                                                       
        public IsolatedStorageSettings AttackUP = IsolatedStorageSettings.ApplicationSettings;
        public int attackUP;

        public IsolatedStorageSettings ManaAttackUP = IsolatedStorageSettings.ApplicationSettings;
        public int manaAttackUp;

        public IsolatedStorageSettings SpiritualAttackUP = IsolatedStorageSettings.ApplicationSettings;
        public int spiritualAttackUP;

        public IsolatedStorageSettings DefenseUP = IsolatedStorageSettings.ApplicationSettings;
        public int defenseUP;

        public IsolatedStorageSettings SpeedUP = IsolatedStorageSettings.ApplicationSettings;
        public int speedUP;



        
                                                                        ////Gain From Figting////
                                                                        /////////////////////////////////////// 

        public IsolatedStorageSettings ExpPoints = IsolatedStorageSettings.ApplicationSettings;
        public int expPoints;

        public IsolatedStorageSettings PetPoints = IsolatedStorageSettings.ApplicationSettings;
        public int petPoints;

        
                                                                                             //Items
                                                                                             ////////////
        //Health
        public IsolatedStorageSettings PetPotion = IsolatedStorageSettings.ApplicationSettings;
        public int petPotion;

        public IsolatedStorageSettings PetXPotion = IsolatedStorageSettings.ApplicationSettings;
        public int petXPotion;
        //Mana
            //Mana Potion
        public IsolatedStorageSettings ManaPotion = IsolatedStorageSettings.ApplicationSettings;
        public int manaPotion;
            //Holy Water
        public IsolatedStorageSettings HolyWater = IsolatedStorageSettings.ApplicationSettings;
        public int holyWater;


        //Magic Spell
        public IsolatedStorageSettings PetLighting = IsolatedStorageSettings.ApplicationSettings;
        public int petLighting;

        public IsolatedStorageSettings PetFire = IsolatedStorageSettings.ApplicationSettings;
        public int petFire;

        public IsolatedStorageSettings PetQuake = IsolatedStorageSettings.ApplicationSettings;
        public int petQuake;

        public IsolatedStorageSettings PetIce = IsolatedStorageSettings.ApplicationSettings;
        public int petIce;

        public IsolatedStorageSettings PetDark = IsolatedStorageSettings.ApplicationSettings;
        public int petDark;

        public IsolatedStorageSettings PetHeal = IsolatedStorageSettings.ApplicationSettings;
        public int petHeal;

        public IsolatedStorageSettings PetSheild = IsolatedStorageSettings.ApplicationSettings;
        public int petSheild;

        public IsolatedStorageSettings PetPoison= IsolatedStorageSettings.ApplicationSettings;
        public int petPoison;

        public IsolatedStorageSettings PetThunder = IsolatedStorageSettings.ApplicationSettings;
        public int petThunder;

        public IsolatedStorageSettings PetInferno= IsolatedStorageSettings.ApplicationSettings;
        public int petInferno;

        public IsolatedStorageSettings PetBlizzard= IsolatedStorageSettings.ApplicationSettings;
        public int petBlizzard;

        public IsolatedStorageSettings PetCureAll = IsolatedStorageSettings.ApplicationSettings;
        public int petCureAll;

        public IsolatedStorageSettings PetEarth = IsolatedStorageSettings.ApplicationSettings;
        public int petEarth;

        public IsolatedStorageSettings PetFallenAngels = IsolatedStorageSettings.ApplicationSettings;
        public int petFallenAngels;
 //Abilities no mana needed
        public IsolatedStorageSettings PetScan = IsolatedStorageSettings.ApplicationSettings;
        public int petScan;

        public IsolatedStorageSettings PetDrain = IsolatedStorageSettings.ApplicationSettings;
        public int petDrain;

        public IsolatedStorageSettings PetGunSlinger = IsolatedStorageSettings.ApplicationSettings;
        public int petGunSlinger;

        public IsolatedStorageSettings PetCounterAttack= IsolatedStorageSettings.ApplicationSettings;
        public int petCounterAttack;

     //Town
        public IsolatedStorageSettings TownIn = IsolatedStorageSettings.ApplicationSettings;
        public int townIn;
        public IsolatedStorageSettings TownWantingToGo = IsolatedStorageSettings.ApplicationSettings;
        public int townWantingToGo;


        public IsolatedStorageSettings DistanceWalked = IsolatedStorageSettings.ApplicationSettings;
        public int distanceWalked;
        public IsolatedStorageSettings DistanceToTown = IsolatedStorageSettings.ApplicationSettings;
        public int distanceToTown;

        //Pause
        public IsolatedStorageSettings Pause = IsolatedStorageSettings.ApplicationSettings;
        public int pause;

        public IsolatedStorageSettings PauseActive = IsolatedStorageSettings.ApplicationSettings;
        public int pauseActive;



    }
    

}
