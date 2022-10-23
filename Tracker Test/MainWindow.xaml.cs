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
using Tracker_Test.Data;
using Tracker_Test.Utility;
using Tracker_Test.ViewModel;
using Tracker_Test.Models;
using System.Collections.ObjectModel;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;

namespace Tracker_Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Day> allDays;
        private ObservableCollection<Person> allPersons;
        private ChartDrawer chartDrawer = new ChartDrawer();
        private Person selectedPerson;

        public MainWindow()
        {
            InitializeComponent();
            DataHandler.AddDays(JsonParser.ParseDaysFromJson());

            allDays = new ObservableCollection<Day>(DataHandler.GetAllDays());
            allPersons = new ObservableCollection<Person>(DataHandler.GetAllPersons());

            chartDrawer = new ChartDrawer(chart);
            DataHandler.AnalyseAllSteps();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new PersonsViewModel();

        }


        private void personDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGrid currentGrid = sender as DataGrid;
            if (currentGrid.CurrentCell.IsValid)
            {
                selectedPerson = currentGrid.CurrentCell.Item as Person;
                if (selectedPerson != null)
                {
                    int[] axisYData = selectedPerson.AllSteps;
                    int[] axisXData = Enumerable.Range(1, selectedPerson.AllSteps.Length).ToArray();

                    chartDrawer.UpdateData(axisXData, axisYData);
                }
            }
            
        }

        private void exportBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (selectedPerson != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".json";
                saveFileDialog.FileName = selectedPerson.User;
                saveFileDialog.Filter = "Json (*.json)|*json";
                saveFileDialog.InitialDirectory = JsonParser.DataPath;
                if (saveFileDialog.ShowDialog() == true)
                {
                    JsonParser.ParsePersonToJson(selectedPerson,saveFileDialog.FileName);
                    MessageBox.Show("Пользователь успешно сохранен.");
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите пользователя.","Вы должны выбрать пользователя");
            }


        }
    }
}
