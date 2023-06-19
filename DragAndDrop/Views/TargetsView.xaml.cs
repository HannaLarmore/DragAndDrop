using DragAndDrop.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TargetsView.xaml
    /// </summary>
    public partial class TargetsView : UserControl
    {
        public Target primaryTarget;
        public TargetsView()
        {
            InitializeComponent();
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var target = TargetsList.SelectedItem as Target;
                if(target != null)
                {
                    DraggedTarget.Content = new Target(target.TargetName.Text);
                    DraggedTarget.Visibility = Visibility.Visible;
                    DragDrop.DoDragDrop(DraggedTarget, DraggedTarget, DragDropEffects.Move);
                }
            }
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (DraggedTarget != null)
            {
                DraggedTarget.Visibility = Visibility.Hidden;
            }
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            Point dropPosition = e.GetPosition(canvas);

                Canvas.SetLeft(DraggedTarget, dropPosition.X);
                Canvas.SetTop(DraggedTarget, dropPosition.Y);
            
        }
    }
}
