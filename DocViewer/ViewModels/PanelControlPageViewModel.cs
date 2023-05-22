using DocViewer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DocViewer.ViewModels
{
    class PanelControlPageViewModel
    {

        public ICommand MoveDocumentsLeftCommand { get; set; }

        public ICommand MoveDocumentsRightCommand { get; set; }

        public PanelControlPageViewModel()
        {
            MoveDocumentsLeftCommand = new RelayCommand(MoveDocumentsLeft);
            MoveDocumentsRightCommand = new RelayCommand(MoveDocumentsRight);
        }


        private void MoveDocumentsLeft()
        {

        }

        private void MoveDocumentsRight()
        {

        }

    }
}
