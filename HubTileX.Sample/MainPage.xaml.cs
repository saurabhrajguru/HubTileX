using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HubTileX.Sample.Resources;
using System.Collections.ObjectModel;

namespace HubTileX.Sample
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ObservableCollection<TileData> tileCollection = new ObservableCollection<TileData>();
            TileData tileData = new TileData();
            tileData.ImageUri = "/Assets/Tile1.jpg";
            tileData.Name = "Tile 1";
            tileData.Address = "Test 1 Address";
            tileData.ShouldFlip = true;

            TileData tileData1 = new TileData();
            tileData1.ImageUri = "/Assets/Tile2.jpg";
            tileData1.Name = "Tile 2";
            tileData1.Address = "Test 2 Address";
            tileData1.ShouldFlip = false;

            tileCollection.Add(tileData);
            tileCollection.Add(tileData1);

            this.DataContext = tileCollection;
        }
    }
}