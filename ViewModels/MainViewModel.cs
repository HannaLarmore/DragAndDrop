using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DragAndDrop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //Controls.LogicGate LogicGate { get; set; }
        #region properties
        public TargetsViewModel TargetsVM
        {
            get;
            set;
        }
        public GatesViewModel LogicGatesVM
        {
            get;
            set;
        }
        public LogicTreeViewModel LogicTreeVM
        {
            get;
            set;
        }
        #endregion

        #region contructor
        public MainViewModel()
        {
            TargetsVM = new TargetsViewModel();
            LogicTreeVM = new LogicTreeViewModel();
            LogicGatesVM = new GatesViewModel();
        }


        #endregion
    }
}
