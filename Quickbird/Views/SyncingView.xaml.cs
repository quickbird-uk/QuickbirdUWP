﻿// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Quickbird.Views
{
    using System;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using Util;

    /// <summary>
    ///     Forces the user to wait while a sync is performed, then navigates to the shell.
    /// </summary>
    public sealed partial class SyncingView : Page
    {
        public SyncingView()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Hold this vire open for a minimum time to avoid flicker on fast syncs.
            var x = Task.Run(() => Task.Delay(TimeSpan.FromSeconds(5)));
            await DatabaseHelper.Instance.GetUpdatesFromServerAsync();
            await x;

            Frame.Navigate(typeof(Shell));
        }
    }
}