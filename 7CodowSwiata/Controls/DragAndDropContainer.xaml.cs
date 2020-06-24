using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
using static _7CodowSwiata.Controls.DragAndDropContainer;

namespace _7CodowSwiata.Controls
{
    /// <summary>
    /// Interaction logic for DragAndDropContainer.xaml
    /// </summary>
    public partial class DragAndDropContainer : ContentControl
    {
        public DragAndDropContainer()
        {
            InitializeComponent();
        }
  
        public event EventHandler<DDEventArgs> BeforeDrag;
        public event EventHandler<DDEventArgs> AfterDrag;

        private Window _DragDropWindow => (Window)FindResource("DragWindow");

        public static readonly DependencyProperty DropDataTemplateProperty = DependencyProperty.Register("DropDataTemplate", typeof(DataTemplate), typeof(DragAndDropContainer), new PropertyMetadata(null, DropDataTemplatePropertyChanged));
        private static void DropDataTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DropDataPropertyChanged(e.NewValue);
        private void DropDataTemplatePropertyChanged(DataTemplate val)
        {

        }

        public DataTemplate DropDataTemplate
        {
            get => (DataTemplate)GetValue(DropDataTemplateProperty);
            set => SetValue(DropDataTemplateProperty, value);
        }

        #region Drag

        public static readonly DependencyProperty DragDataProperty = DependencyProperty.Register("DragData", typeof(object), typeof(DragAndDropContainer), new PropertyMetadata(null, DragDataPropertyChanged));
        private static void DragDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DragDataPropertyChanged(e.NewValue);
        private void DragDataPropertyChanged(object val)
        {
            //...
        }

        public object DragData
        {
            get => GetValue(DragDataProperty);
            set => SetValue(DragDataProperty, value);
        }

        public static readonly DependencyProperty AllowDragProperty = DependencyProperty.Register("AllowDrag", typeof(bool), typeof(DragAndDropContainer), new PropertyMetadata(true, AllowDragPropertyChanged));
        private static void AllowDragPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).AllowDragPropertyChanged((bool)e.NewValue);
        private void AllowDragPropertyChanged(bool val)
        {
            //...
        }

        public bool AllowDrag
        {
            get => (bool)GetValue(AllowDragProperty);
            set => SetValue(AllowDragProperty, value);
        }

        public static readonly DependencyProperty DDEffectsProperty = DependencyProperty.Register("DDEffects", typeof(DragDropEffects), typeof(DragAndDropContainer), new PropertyMetadata(DragDropEffects.All, DDEffectsPropertyChanged));
        private static void DDEffectsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DDEffectsPropertyChanged((DragDropEffects)e.NewValue);
        private void DDEffectsPropertyChanged(DragDropEffects val)
        {
            //...
        }

        public DragDropEffects DDEffects
        {
            get => (DragDropEffects)GetValue(DDEffectsProperty);
            set => SetValue(DDEffectsProperty, value);
        }

        #endregion

        #region Drop

        public static readonly DependencyProperty DropDataProperty = DependencyProperty.Register("DropData", typeof(object), typeof(DragAndDropContainer), new PropertyMetadata(null, DropDataPropertyChanged));
        private static void DropDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DropDataPropertyChanged(e.NewValue);
        private void DropDataPropertyChanged(object val)
        {

        }

        public object DropData
        {
            get => GetValue(DropDataProperty);
            set => SetValue(DropDataProperty, value);
        }

        #endregion

        private void ContentControl_Drop(object sender, DragEventArgs e)
        {
            DropData = e.Data.GetData("Data");
        }

        private void ContentControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && AllowDrag && DragData!=null)
            {
                var data = DragData;
                DataObject dataObj = new DataObject();
                dataObj.SetData("Data", data);
                BeforeDrag?.Invoke(this, new DDEventArgs(DDEffects, data));
                CreateDragDropWindow(data);
                DragDropEffects effect = DragDrop.DoDragDrop(this, dataObj, DDEffects);
                if (_DragDropWindow.IsVisible)
                    _DragDropWindow.Hide();
                AfterDrag?.Invoke(this, new DDEventArgs(effect, data));
            }
        }

        private void ContentControl_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Win32Point w32Mouse = new Win32Point();
            NativeMethods.GetCursorPos(ref w32Mouse);

            _DragDropWindow.Left = w32Mouse.X;
            _DragDropWindow.Top = w32Mouse.Y;
        }

        private void CreateDragDropWindow(object data)
        {
            if (DropDataTemplate != null)
            {
                var ctrl = DropDataTemplate.LoadContent() as FrameworkElement;
                ctrl.DataContext = data;

                _DragDropWindow.Content = ctrl;

                Win32Point w32Mouse = new Win32Point();
                NativeMethods.GetCursorPos(ref w32Mouse);

                _DragDropWindow.Left = w32Mouse.X;
                _DragDropWindow.Top = w32Mouse.Y;
                _DragDropWindow.Show();
            }
        }   

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
    }
    public class DDEventArgs:EventArgs
    {
        public DDEventArgs(DragDropEffects effects, object data)
        {
            Effects = effects;
            Data = data;
        }
        public DragDropEffects Effects { get; set; }
        public object Data { get; set; }
    }

    public class NativeMethods
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);
    }
}
