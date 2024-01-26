using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    public delegate void ContainerContentUpdateEvent(ListViewBase listViewBase, ContainerContentChangingEventArgs args);
    public sealed partial class CustomList : UserControl
    {
        public event RoutedEventHandler ListSelected;
        public event ContainerContentUpdateEvent ListUpdated;
        public CustomList()
        {
            this.InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, ItemClickEventArgs e)=>ListSelected?.Invoke(sender, e);

        private void ListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args) => ListUpdated?.Invoke(sender,args);

       
    }
}
