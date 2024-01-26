using App1.Model;
using App1.ViewModel;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1
{
   
    public sealed partial class MainPage : Page
    {
        private readonly MainViewModel viewModel = new MainViewModel();
        public MainViewModel ViewModel => viewModel;
        private Border displayWidget;
        private bool istab = false;
        public MainPage()
        {
            Loaded += (sender, e) => viewModel.LoadDataAsync();
            this.InitializeComponent();
            DataContext = viewModel;           
            displayWidget = navigationelement;
            displayWidget.Child = null;
        }
        private void ListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            var listview = (ListView)sender;
            var items = listview.ItemsSource as List<ArticleModel>;
            if (args.InRecycleQueue == false && args.ItemIndex == listview.Items.Count - 1)
            {
                viewModel.LoadMoreDataAsync();
                return;
            }
        }
        
        private async void ListView_SelectionChanged(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            displayWidget.Child = null;
            BackButton.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            if (istab)
            {
                DeskTopLayout.ColumnDefinitions[0].MaxWidth = 0;
                DeskTopLayout.ColumnDefinitions[1].MaxWidth = double.MaxValue;
                Text1.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
            ring.IsActive = true;
            await Task.Delay(3000);
            if (sender is ListView listview && listview.SelectedItem is ArticleModel selectedArticle)
            {
                ViewModel.SelectedArticle = selectedArticle;
                displayWidget.Child = Details;
                if(istab)
                    BackButton.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
             ring.IsActive = false;
        

        }
        private void RootGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            double minwidth = 700;
            double availabewidth = RootGrid.ActualWidth;
            if (!(availabewidth >= minwidth))
            {
                istab = true;
                //BackButton.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                Text1.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }
            if (istab)
                DeskTopLayout.ColumnDefinitions[1].MaxWidth = 0;
        }

        private void BackButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            
            RootGrid_Loaded(sender,e);
            Task.Delay(3000);
            ring.IsActive = false;

            DeskTopLayout.ColumnDefinitions[0].MaxWidth = double.MaxValue;
        }
    }
}
