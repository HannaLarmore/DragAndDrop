using DragAndDrop.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DragAndDrop.ViewModels
{
    public class TargetsViewModel : BaseViewModel
    {
        #region private

        private int title;

        #endregion

        #region properties
        ///The Title/Header of the list of targets
        public int Title
        {
            get 
            {
                return title; 
            }
            set 
            {
                title = value; 
            }
        }

        public ObservableCollection<Target> TargetList
        {
            get;
            set;
        }
        #endregion

        #region constructor
        public TargetsViewModel()
        {
            TargetList = new ObservableCollection<Target>();
            TargetList.Add(new Target("Person1"));
            TargetList.Add(new Target("Person2"));
            TargetList.Add(new Target("Person3"));
            TargetList.Add(new Target("Person4"));
            NotifyOfPropertyChange(() => TargetList);
        }
        public void Targets_MouseMove(object sender, MouseEventArgs e)
        {
            //if()
        }
        #endregion



    }
}
