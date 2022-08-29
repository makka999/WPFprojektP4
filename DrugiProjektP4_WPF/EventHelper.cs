//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Input;
////https://stackoverflow.com/questions/25842208/adding-a-click-event-to-all-textboxes-in-wpf
//namespace DrugiProjektP4_WPF
//{
//    class EventHelper
//    {
//        public static ICommand GetLeftClick(DependencyObject obj)
//        {
//            return (ICommand)obj.GetValue(LeftClickProperty);
//        }

//        public static void SetLeftClick(DependencyObject obj, ICommand value)
//        {
//            obj.SetValue(LeftClickProperty, value);
//        }

//        public static readonly DependencyProperty LeftClickProperty = DependencyProperty.RegisterAttached("LeftClick", typeof(ICommand), typeof(EventHelper), new PropertyMetadata(null, OnLeftClickChanged));

//        private static void OnLeftClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            FrameworkElement elem = d as FrameworkElement;
//            ICommand command = e.NewValue as ICommand;
//            if (command != null)
//            {
//                elem.InputBindings.Add(new MouseBinding(command, new MouseGesture(MouseAction.LeftClick)));
//            }

//        }
//    }
//}
