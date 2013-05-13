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
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Marketplace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace myBuddies
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask reviewApp = new MarketplaceReviewTask();
            reviewApp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.GameHasControl == true)
            {
                FrameworkDispatcher.Update();
                me.Stop();
                me.Volume = 11;
                me.Source = new Uri("Sounds/Arcadia.mp3", UriKind.Relative);
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
    }
}