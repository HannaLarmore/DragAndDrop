using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace DragAndDrop.Controls
{
    public enum LogicGateEnum
    {
        [Description("AND")]
        AND,
        [Description("OR")]
        OR,
        [Description("XOR")]
        XOR,
        [Description("NOT")]
        NOT,
        [Description("NofM")]
        NofM,
        [Description("NAND")]
        NAND,
        
    }
    /// <summary>
    /// Interaction logic for LogicGate.xaml
    /// </summary>
    public partial class LogicGate : UserControl
    {

        public LogicGate(LogicGateEnum gateType)
        {
            InitializeComponent();

            switch (gateType)
            {

                case LogicGateEnum.AND:
                case LogicGateEnum.NAND:
                case LogicGateEnum.OR:
                case LogicGateEnum.XOR:
                case LogicGateEnum.NOT:
                case LogicGateEnum.NofM://currently just setting up AND for time limit/proof of concept
                    {
                        LogicName.Text = GetEnumDescription((LogicGateEnum)gateType);
                        LogicTitleBackground.Background = Brushes.LightGreen;
                    }
                break;
            }

        }

        private void TargetGate_Drop(object sender, DragEventArgs e)
        {
            TargetGate1.Content = e.Data;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
