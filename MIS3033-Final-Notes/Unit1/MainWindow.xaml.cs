using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace Unit1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables
        List<Car> CarList = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();

            // We split our code into using methods
            LoadListBox();
            ImportCarColor();


        }

        private void LoadListBox()
        {
            //use a var of lines from read all lines, then foreach skipping 1. 
            var lines = File.ReadAllLines("car_sales.csv");
            foreach (var line in lines.Skip(1)) //use this to skip
            {
                var columns = line.Split(',');
                Car car = new Car(columns[0], columns[1], columns[2], int.Parse(columns[3]), columns[4], decimal.Parse(columns[5], NumberStyles.Currency));
                CarList.Add(car);
            }
            DisplayCars(CarList);
            // Adding the sorting signs to the combobox.
            cboxSign.Items.Add("=");
            cboxSign.Items.Add("≤");
            cboxSign.Items.Add("≥");
            cboxSign.SelectedIndex = 0;
        }
        private void ImportCarColor()
        {

            // Add "All" option
            cboxColor.Items.Add("All");

            // Retrieve unique colors from CarList
            var uniqueColors = CarList.Select(c => c.Color).Distinct();

            foreach (var color in uniqueColors)
            {
                cboxColor.Items.Add(color);
            }

            cboxColor.SelectedIndex = 0; // Select "All" by default
        }


        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            // 1. Get the user's input
            string color = cboxColor.Text;
            string year = tboxYear.Text;
            string sign = cboxSign.Text;

            // 2. Filter the data
            List<Car> filteredCars = FilterCars(color, year, sign);
            DisplayCars(filteredCars);


        }

        private void DisplayCars(List<Car> filteredCars)
        {
            listCars.Items.Clear();

            foreach (Car car in filteredCars)
                listCars.Items.Add(car);
            lblCount.Content = filteredCars.Count.ToString();
        }

        private List<Car> FilterCars(string color, string year, string sign)
        {

            List<Car> filteredCars = CarList; // Start with all cars.

            // Validate and convert the year to integer.
            if (!int.TryParse(year, out int parsedYear))
            {
                MessageBox.Show("Invalid year value provided.");
                return CarList;
            }


            // Filter by color if it's not "All"
            if (!string.Equals(color, "All"))
            {
                filteredCars = filteredCars.Where(c => string.Equals(c.Color, color)).ToList();
            }

            // Filter by year based on the sign
            switch (sign)
            {
                case "=":
                    filteredCars = filteredCars.Where(car => car.Year == parsedYear).ToList();
                    break;
                case "≤":
                    filteredCars = filteredCars.Where(car => car.Year <= parsedYear).ToList();
                    break;
                case "≥":
                    filteredCars = filteredCars.Where(car => car.Year >= parsedYear).ToList();
                    break;
                default:
                    break;
            }

            return filteredCars.ToList();

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            // Convert ListBox items to a list of Car objects.
            List<Car> carsToExport = listCars.Items.OfType<Car>().ToList();

            // Serialize the list to JSON.
            string jsonData = JsonConvert.SerializeObject(carsToExport, Formatting.Indented);

            // Define the file path. This saves the file to the application's current directory.
            // You can modify this path as necessary.
            string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "exportedCars.json");

            // Write the JSON data to the file.
            File.WriteAllText(filePath, jsonData);

            MessageBox.Show($"Data exported to {filePath}");
        }
    }
}
