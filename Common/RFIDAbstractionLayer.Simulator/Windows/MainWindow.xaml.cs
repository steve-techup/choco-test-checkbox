using Caretag_Class.Model;
using RFIDAbstractionLayer.Readers;
using RFIDAbstractionLayer.Simulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Caretag_Class;
using RFIDAbstractionLayer.Simulator.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace RFIDAbstractionLayer.Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CaretagModelFactory _dbContextFactory;
        private List<SimulatorItem> _fullRFIDList = new();
        private List<SimulatorItem> _uiList = new();
        private List<SimulatorItem> _searchList = new();
        private const int MaxSessionHistory = 4;
        private SimulatorServer _server;
        private RecentList _recent = new("recent.txt");

        public MainWindow(CaretagModelFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            InitializeComponent();
        }

        public void InitWindow(List<SimulatorItem> apiItems)
        {
            _fullRFIDList.AddRange(apiItems);
            if (_fullRFIDList.Count == 0)
            {
                // Load Hardcoded values
                BuildConfirmedItems();
            }
            
            ShowStatusDisconnected();
            _server = new SimulatorServer(new IPAddress(new byte[] { 127, 0, 0, 1 }), 23513, this);
            _server.Start();

            itemLV.ItemsSource = _uiList;
        }

        private void Search(string searchString)
        {
            using var uow = new SimulatorUnitOfWork(_dbContextFactory);
            searchString = searchString.ToLower();

            _searchList = uow.InstrumentRepository.Get(filter: i =>
                i.Description_ID.ToLower().StartsWith(searchString) ||
                i.Description_Text.ToLower().StartsWith(searchString) ||
                i.InstrumentDescription.Description_Name.ToLower().StartsWith(searchString) ||
                i.InstrumentDescription.D.ToLower().Contains(searchString) ||
                i.InstrumentDescription.E.ToLower().Contains(searchString)
                ).ToList().ConvertAll(i => new SimulatorItem(i));

            ShowSearch();
        }
        
        private void SendItem(SimulatorItem item, bool addToRecent = true)
        {
            if (item == null || item.EPC == null)
            {
                MessageBox.Show(App.Translate("qdNullEpcMsg"), App.Translate("qdInformation"), MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddToSessionHistory(item);
            if (addToRecent)
                _recent.Add(item);
            _server.Multicast(item.EPC);
        }

        private void AddToSessionHistory(SimulatorItem item)
        {

            string message = String.Format("{0}: {1} [{2}: {3}]", App.Translate("Sent"), item.Description, App.Translate("EPC"), item.EPC);
            AddToSessionHistory(message);
        }

        private void AddToSessionHistory(string message)
        {
            if (sessionHistoryListBox.Items.Count == MaxSessionHistory)
            {
                sessionHistoryListBox.Items.RemoveAt(MaxSessionHistory - 1);
            }

            sessionHistoryListBox.Items.Insert(0, message);
        }

        #region Window Event Handlers
        private void searchImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowSearch();
        }

        private void recentImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowRecent();
        }

        private void loginCardImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PaintHighlightedMenuItem(SimulatorItemType.CardID);
            UpdateUI(SimulatorItemType.CardID);
        }

        private void scalpelImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PaintHighlightedMenuItem(SimulatorItemType.Instrument);
            UpdateUI(SimulatorItemType.Instrument);
        }

        private void trayImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PaintHighlightedMenuItem(SimulatorItemType.Tray);
            UpdateUI(SimulatorItemType.Tray);
        }

        private void containerImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PaintHighlightedMenuItem(SimulatorItemType.Container);
            UpdateUI(SimulatorItemType.Container);
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            Search(searchBox.Text);
        }

        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            SimulatorItem simItem = ((ListViewItem)sender).Content as SimulatorItem;

            if (simItem == null)
            {
                return;
            }

            SendItem(simItem);
        }

        private void quickBtn_Click(object sender, RoutedEventArgs e)
        {
            SendQuickSearchItem();
        }

        private void SendQuickSearchItem()
        {
            SimulatorItem item = new SimulatorItem(String.Format("|{0}||", quickBox.Text));
            quickBox.Text = "";
            SendItem(item, false);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search(searchBox.Text);
                e.Handled = true;
            }
        }

        private void quickBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendQuickSearchItem();
                e.Handled = true;
            }
        }

        private void newVirtualTagImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {/*
            if (!App.ApiLoader.IsLoaded)
            {
                MessageBox.Show(App.Translate("qdVirtualTagDBNeeded"), App.Translate("qdNotAvail"), MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            */
            string newId = "";

            var dialog = new NewVirtualTagWindow();

            if (dialog.Execute(this, ref newId))
            {
                SimulatorItem simItem = new SimulatorItem("Virtual Tag", newId, "Virtual Tag", SimulatorItemType.Unknown);
                SendItem(simItem);
            }
        }
        #endregion

        #region UI Paint/Update Methods
        void PaintSearchMenuItem(bool highlighted)
        {
            var res = @"\Assets\search.png";
            if (highlighted)
                res = @"\Assets\searchInv.png";
            searchImg.Source = GetAsset(res);
        }
        void PaintRecentMenuItem(bool highlighted)
        {
            var res = @"\Assets\clock.png";
            if (highlighted)
                res = @"\Assets\clockInv.png";
            recentImg.Source = GetAsset(res);
        }
        void PaintIDCardMenuItem(bool highlighted)
        {
            var res = @"\Assets\creditCard.png";
            if (highlighted)
                res = @"\Assets\creditCardInv.png";
            loginCardImg.Source = GetAsset(res);
        }
        void PaintInstrumentMenuItem(bool highlighted)
        {
            var res = @"\Assets\Scalpel.png";
            if (highlighted)
                res = @"\Assets\ScalpelInv.png";
            scalpelImg.Source = GetAsset(res);
        }
        void PaintTrayMenuItem(bool highlighted)
        {
            var res = @"\Assets\Tray.png";
            if (highlighted)
                res = @"\Assets\TrayInv.png";
            trayImg.Source = GetAsset(res);
        }
        void PaintContainerMenuItem(bool highlighted)
        {
            var res = @"\Assets\container.png";
            if (highlighted)
                res = @"\Assets\containerInv.png";
            containerImg.Source = GetAsset(res);
        }

        private BitmapImage GetAsset(string path)
        {
            var result = new BitmapImage(new Uri(path, UriKind.Relative));
            return result;
        }

        private void UpdateUI(SimulatorItemType sit)
        {
            _uiList.Clear();
            foreach (var item in _fullRFIDList)
            {
                if (item.ItemType == sit)
                {
                    _uiList.Add(item);
                }
            }

            itemLV.ItemsSource = _uiList;
            itemLV.Items.Refresh();
        }

        private void PaintHighlightedMenuItem(SimulatorItemType sit)
        {
            PaintSearchMenuItem(sit == SimulatorItemType.Search);
            PaintRecentMenuItem(sit == SimulatorItemType.Recent);
            PaintIDCardMenuItem(sit == SimulatorItemType.CardID);
            PaintInstrumentMenuItem(sit == SimulatorItemType.Instrument);
            PaintTrayMenuItem(sit == SimulatorItemType.Tray);
            PaintContainerMenuItem(sit == SimulatorItemType.Container);
        }

        public void SetConnection(bool connected)
        {
            if (connected)
            {
                ShowStatusConnected();
            }
            else
            {
                ShowStatusDisconnected();
            }
        }

        public void SetPower(int powerLevel)
        {
            var msg = String.Format(App.Translate("PowerChange"), (PowerLevel) powerLevel);
            string assetname = @"\Assets\connected_" + powerLevel.ToString() + ".png";
            connectionImg.Source = GetAsset(assetname);
            AddToSessionHistory(msg);
        }

        private void ShowStatusConnected()
        {
            connectionImg.Source = GetAsset(@"\Assets\connected.png");
            AddToSessionHistory("App Connected!");
        }

        private void ShowStatusDisconnected()
        {
            connectionImg.Source = GetAsset(@"\Assets\disconnected.png");
            AddToSessionHistory("App Disconnected!");
        }

        private void ShowSearch()
        {
            _uiList.Clear();
            foreach (var item in _searchList)
            {
                _uiList.Add(item);
            }

            itemLV.Items.Refresh();

            PaintHighlightedMenuItem(SimulatorItemType.Search);
        }

        private void ShowRecent()
        {
            _uiList.Clear();
            foreach (var item in _recent.Items)
            {
                _uiList.Add(item);
            }

            itemLV.Items.Refresh();

            PaintHighlightedMenuItem(SimulatorItemType.Recent);
        }
        #endregion

        #region Fake Data creation
        private void BuildConfirmedItems()
        {

            // These are all valid tools in the Database used by the development team
            //
            // Valid Surgical tools

            _fullRFIDList.Add(new SimulatorItem("0|57012341AA10001100000253|Präp.-klemme overhold geb. 13,5|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("1|57012341AA10001100000315|Mikro-Mosquitoklemme GER. 10 cm.|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("2|57012341AA10001100000319|Tumorfasszange Landolt stumpf 20 cm|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("3|570123412010000000000217|13-451-23-07, DISSECTING FORCEPS|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("4|570123412010000000000264|25-510-12-07, BIEGEZANGE 12CM|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("5|570123412010000000000142|13-052-04-07, VASCULAR CLIP|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("6|34155BF9C8001940000002A2|12-321-20-07, PINZETTE  CHIR.  1X2 Z.  SCHMAL  20,5 CM|Instrument"));
            _fullRFIDList.Add(new SimulatorItem("7|34155BF9C8001940000002BD|10-100-04-07, SKALPELLGRIFF  NR. 4  13.5 CM  |Instrument"));
            
            _fullRFIDList.Add(new SimulatorItem("0|57012341AA12001200000290|Artery|Tray"));
            _fullRFIDList.Add(new SimulatorItem("1|57012341AA12001200000340|SmallDemo Tray|Tray"));
            _fullRFIDList.Add(new SimulatorItem("2|34155BF9C80019400000016F|Leuven Tray|Tray"));
            _fullRFIDList.Add(new SimulatorItem("3|34155BF9C800194000000001|Leuven Tray 2|Tray"));
            _fullRFIDList.Add(new SimulatorItem("3|34155BF9C800194000000742|Leuven Tray 3|Tray"));
            
            _fullRFIDList.Add(new SimulatorItem("4|57012341AA09000000000008|DemoUser4|CardID"));
            _fullRFIDList.Add(new SimulatorItem("5|57012341AA09282700000010|DemoUser2|CardID"));
            _fullRFIDList.Add(new SimulatorItem("2|E20092012071000001000251|Working .........|Container"));
            _fullRFIDList.Add(new SimulatorItem("3|57012341AA14001400000506|ML Text Container|Container"));
            _fullRFIDList.Add(new SimulatorItem("12|570123412014000000000331|KLS Martin|Container"));
        }
        #endregion

    }
}
