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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using System.Xml;

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
                   // string data = target.;
                    DraggedTarget.Content = new Target(target.TargetName.Text);
                    DraggedTarget.Visibility = Visibility.Visible;

                    DragDrop.DoDragDrop(this, SerializeControlToXaml(DraggedTarget.Content as Target), DragDropEffects.Move);//need to figure out how to serialize
                }
            }
        }
        public string SerializeControlToXaml(FrameworkElement control)
        {
            StringBuilder outstr = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            XamlDesignerSerializationManager dsm =
                    new XamlDesignerSerializationManager(XmlWriter.Create(outstr, settings));
            dsm.XamlWriterMode = XamlWriterMode.Expression;
            System.Windows.Markup.XamlWriter.Save(control, dsm);

            string xaml = outstr.ToString();
            return xaml;
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

        private void canvas_DragLeave(object sender, DragEventArgs e)
        {
            if (DraggedTarget != null)
            {
                DraggedTarget.Visibility = Visibility.Hidden;
            }
        }

        private void canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (DraggedTarget != null)
            {
                DraggedTarget.Visibility = Visibility.Visible;
            }
        }
    }
}
