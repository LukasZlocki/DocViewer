using DocViewer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DocViewer.ViewModels
{
    class PanelControlPageViewModel
    {

        public int page { get; set; }
        public int maxPages { get; set; }
        string Counter { get; set; }

        public ICommand MoveDocumentsLeftCommand { get; set; }

        public ICommand MoveDocumentsRightCommand { get; set; }

        public PanelControlPageViewModel()
        {
            MoveDocumentsLeftCommand = new RelayCommand(MoveDocumentsLeft);
            MoveDocumentsRightCommand = new RelayCommand(MoveDocumentsRight);
        }


        private void MoveDocumentsLeft()
        {
            // ToDo: code moving betwen documents here  
        }

        private void MoveDocumentsRight()
        {
            // ToDo: code moving betwen documents here  
        }

    }
}
