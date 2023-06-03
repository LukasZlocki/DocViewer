using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocViewer.Controls
{
    /// <summary>
    /// Interaction logic for ImgControl.xaml
    /// </summary>
    public partial class ImgControl : UserControl
    {
        public ImgControl()
        {
            InitializeComponent();
        }
    }
}


// ToDo:
// PotentiL Solution : https://www.codeproject.com/Questions/802466/Sharing-Common-View-model-object-to-user-controls
// https://www.google.com/search?q=wpf+mvvm+two+user+controls+one+viewmodel&sxsrf=APwXEdevxa__yzb-WmdYQxd-mvdnmFBAvA%3A1685652383959&ei=nwN5ZJSUOtOErgT0g5Zo&ved=0ahUKEwjU3728-KL_AhVTgosKHfSBBQ0Q4dUDCA8&uact=5&oq=wpf+mvvm+two+user+controls+one+viewmodel&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAzIECCMQJzoLCAAQigUQhgMQsAM6BQgAEKIESgQIQRgBUOkBWIkWYIIYaAFwAHgAgAF5iAGVApIBAzIuMZgBAKABAcABAcgBAg&sclient=gws-wiz-serp
