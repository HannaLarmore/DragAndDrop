using DragAndDrop.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop.ViewModels
{

    public class GatesViewModel : BaseViewModel
    {
        public LogicGate TempANDGate;

        public GatesViewModel()
        {
            TempANDGate = new LogicGate(LogicGateEnum.AND);
            NotifyOfPropertyChange(() => TempANDGate);
        }

    }
}
