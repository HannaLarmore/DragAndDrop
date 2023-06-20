using DragAndDrop.Controls;
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

namespace DragAndDrop.Views
{
    /// <summary>
    /// Interaction logic for LogicTreeView.xaml
    /// </summary>
    public partial class LogicTreeView : UserControl
    {
        public LogicTreeView()
        {
            InitializeComponent();
            TempPlaceHolder = new Target("PlaceHolder");
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
           object data = e.Data.GetData(DataFormats.Serializable);
            //DragDrop.DoDragDrop(TempPlaceHolder, TempPlaceHolder.Content, DragDropEffects.Move);

            Point dropPosition = e.GetPosition(canvas);

            Canvas.SetLeft(TempPlaceHolder, dropPosition.X);
            Canvas.SetTop(TempPlaceHolder, dropPosition.Y);
            if (data is UIElement target)
                canvas.Children.Add(target);
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            // TempPlaceHolder = e.Data as Target;
           //TempPlaceHolder.Content = e.Data.GetData(DataFormats.Serializable);
           // DragDrop.DoDragDrop(TempPlaceHolder, TempPlaceHolder.Content, DragDropEffects.Move);
           // Point dropPosition = e.GetPosition(canvas);

           // Canvas.SetLeft(TempPlaceHolder, dropPosition.X);
           // Canvas.SetTop(TempPlaceHolder, dropPosition.Y);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //if(e.LeftButton==MouseButtonState.Pressed)
            //{
            //    DragDrop.DoDragDrop(TempPlaceHolder, TempPlaceHolder.Content, DragDropEffects.Move);
            //}
        }
    }
}
