using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;
using Tracker_Test.Models;
using Tracker_Test.Data;
using System.Windows.Forms;

namespace Tracker_Test.ViewModel
{
    class PersonsViewModel : DependencyObject  
    {


        public ICollectionView Persons
        {
            get { return (ICollectionView)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Persons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersonsProperty =
            DependencyProperty.Register("Persons", typeof(ICollectionView), typeof(PersonsViewModel), new PropertyMetadata(null));



        public PersonsViewModel()
        {
            Persons = CollectionViewSource.GetDefaultView(DataHandler.GetAllPersons());
        }
    }
}
