using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using Tracker_Test.Data;

namespace Tracker_Test.ViewModel
{
    class DaysViewModel : DependencyObject
    {
        public ICollectionView Days
        {
            get { return (ICollectionView)GetValue(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Days.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaysProperty =
            DependencyProperty.Register("Days", typeof(ICollectionView), typeof(DaysViewModel), new PropertyMetadata(null));

        public DaysViewModel()
        {
            Days = CollectionViewSource.GetDefaultView(DataHandler.GetAllDays()); 
        }


    }
}
