using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.DragEnter += DragAndDropContainer_DragEnter;
            this.DragLeave += DragAndDropContainer_DragLeave;
            this.DragOver += DragAndDropContainer_DragOver;
        }

        private void DragAndDropContainer_DragOver(object sender, DragEventArgs e)
        {
            //DragAndDropContainer dadc = GetDragAndDropContainer((FrameworkElement)e.Source);
            //if(dadc!=null&&dadc)
            //{
                
            //}
        }
        //public DragAndDropContainer GetDragAndDropContainer(FrameworkElement fe)
        //{
        //    //var element = fe;
        //    //while (!(element is DragAndDropContainer) && element != null)
        //    //{
        //    //    if (element.Parent is FrameworkElement)
        //    //        element = (FrameworkElement)element.Parent;
        //    //    else return null;
        //    //}
        //    //return (DragAndDropContainer)element;
        //}

        private void DragAndDropContainer_DragLeave(object sender, DragEventArgs e)
        {
            
        }

        private void DragAndDropContainer_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Source is Rectangle)
            {

            }
            if(e.RoutedEvent.OwnerType == typeof(DragAndDropContainer))
            { 

            }
        }

        public event EventHandler<BeforeDragEventArgs> BeforeDrag;
        public event EventHandler<AfterDragEventArgs> AfterDrag;

        #region Drag

        public static readonly DependencyProperty DragDataProperty = DependencyProperty.Register("DragData", typeof(object), typeof(DragAndDropContainer), new PropertyMetadata(null, DragDataPropertyChanged));
        private static void DragDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DragDataPropertyChanged(e.NewValue);
        private void DragDataPropertyChanged(object val)
        {
            //...
        }

        public object DragData
        {
            get { return GetValue(DragDataProperty); }
            set { SetValue(DragDataProperty, value); }
        }

        public static readonly DependencyProperty AllowDragProperty = DependencyProperty.Register("AllowDrag", typeof(bool), typeof(DragAndDropContainer), new PropertyMetadata(true, AllowDragPropertyChanged));
        private static void AllowDragPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).AllowDragPropertyChanged((bool)e.NewValue);
        private void AllowDragPropertyChanged(bool val)
        {
            //...
        }

        public bool AllowDrag
        {
            get { return (bool)GetValue(AllowDragProperty); }
            set { SetValue(AllowDragProperty, value); }
        }

        public static readonly DependencyProperty DDEffectsProperty = DependencyProperty.Register("DDEffects", typeof(DragDropEffects), typeof(DragAndDropContainer), new PropertyMetadata(DragDropEffects.All, DDEffectsPropertyChanged));
        private static void DDEffectsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DDEffectsPropertyChanged((DragDropEffects)e.NewValue);
        private void DDEffectsPropertyChanged(DragDropEffects val)
        {
            //...
        }

        public DragDropEffects DDEffects
        {
            get { return (DragDropEffects)GetValue(DDEffectsProperty); }
            set { SetValue(DDEffectsProperty, value); }
        }

        private bool IsMouseButtonPressed { get; set; }

        #endregion

        #region Drop

        public static readonly DependencyProperty DropDataProperty = DependencyProperty.Register("DropData", typeof(object), typeof(DragAndDropContainer), new PropertyMetadata(null, DropDataPropertyChanged));
        private static void DropDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DragAndDropContainer)d).DropDataPropertyChanged(e.NewValue);
        private void DropDataPropertyChanged(object val)
        {

        }

        public object DropData
        {
            get { return GetValue(DropDataProperty); }
            set { SetValue(DropDataProperty, value); }
        }

        #endregion

        private void ContentControl_Drop(object sender, DragEventArgs e)
        {
            DropData = e.Data.GetData("Data");
        }

        private void ContentControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //IsMouseButtonPressed = true;
        }

        private void ContentControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //IsMouseButtonPressed = false;
        }

        private void ContentControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && AllowDrag&&DragData!=null)
            {
                DataObject dataObj = new DataObject();
                dataObj.SetData("Data", DragData);
                BeforeDrag?.Invoke(this, new BeforeDragEventArgs(DragData));
                DragDropEffects effect = DragDrop.DoDragDrop(this, dataObj, DDEffects);
                AfterDrag?.Invoke(this, new AfterDragEventArgs(effect, DragData));
            }
        }

        private void ContentControl_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            
        }

        private void ContentControl_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
        }
    }
    public class AfterDragEventArgs:EventArgs
    {
        public AfterDragEventArgs(DragDropEffects effects, object data)
        {
            Effects = effects;
            Data = data;
        }
        public DragDropEffects Effects { get; set; }
        public object Data { get; set; }
    }
    public class BeforeDragEventArgs : EventArgs
    {
        public BeforeDragEventArgs(object data)
        {
            Data = data;
        }
        public object Data { get; set; }
    }
}
