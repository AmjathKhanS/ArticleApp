using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    public sealed partial class LabelField : UserControl
    {
        private string labeltext;
        public string LabelText { get { return labeltext; } set {labeltext = value; updatevaluevariable(labeltext, "Label", TextBlock.TextProperty); } }

        private void updatevaluevariable(string value,string name,DependencyProperty dp)
        {
            ((TextBlock)this.FindName(name)).SetValue(dp, value);
        }
        public string Binding { set { ((TextBlock)this.FindName("LabelValue")).SetBinding(TextBlock.TextProperty, new Binding { Path = new PropertyPath(value) }); } }

        public LabelField()
        {
            this.InitializeComponent();
            
        }
    }
}
