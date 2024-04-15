using Common.business;
using Common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClientForm
{
    internal partial class Form1 : Form
    {
        private IService service;
        private Employee responsibleEmployee;

        public Form1(IService service,Employee responsibleEmployee)
        {
            InitializeComponent();
            this.service = service;
            this.responsibleEmployee = responsibleEmployee;
           // InitModel();
           // InitClientModel();
        }
        private string pattern = "yyyy-MM-dd HH:mm";


        private void InitModel()
        {
            List<Trip> trips = (List<Trip>)service.getAllTrip();

            foreach (Trip trip in trips)
            {
                int rowIndex = allTripsGrid.Rows.Add();
                DataGridViewRow row = allTripsGrid.Rows[rowIndex];
                int availableSeats = trip.TotalSeats - service.getAllReservationsAt(trip.Id);

                row.Cells["allTripsGridPlace"].Value = trip.Place;
                row.Cells["allTripsGridTransportCompanyName"].Value = trip.TransportCompanyName;
                row.Cells["allTripsGridDeparture"].Value = trip.Departure.ToString(pattern);
                row.Cells["allTripsGridPrice"].Value = trip.Price;
                row.Cells["allTripsGridNoSeats"].Value = availableSeats;

                row.Tag = trip.Id;
            }
        }
        private void InitClientModel()
        {
            List<Common.model.Client> clienti = (List<Common.model.Client>)service.getAllClients();
            foreach (Common.model.Client client in clienti)
            {
                int rowIndex = clientsGrid.Rows.Add();
                DataGridViewRow row = clientsGrid.Rows[rowIndex];

                row.Cells["clientsGridUsername"].Value = client.Username;

                row.Tag = client.Id;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void allTripsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void filterButton_Click(object sender, EventArgs e)
        {

            if (placeField.Text == "" || hour1Combo.Text == "" || hour2Combo.Text == "" || startDatePicker.Text == "" || endDatePicker.Text == "")
                MessageBox.Show("empty fields for filtering");
            else
            {
                string place = placeField.Text;
                DateTime startDate = startDatePicker.Value;
                DateTime endDate = endDatePicker.Value;
                int hour1 = int.Parse(hour1Combo.Text);
                int hour2 = int.Parse(hour2Combo.Text);
                startDate = startDate.AddHours(hour1).AddMinutes(0).AddSeconds(0); // DateTime is immutable=> new instance with modified values 
                endDate = endDate.AddHours(hour2).AddMinutes(0).AddSeconds(0);

                List<Trip> trips = (List<Trip>)service.getAllFilteredTris(place, startDate, endDate);

                foreach (Trip trip in trips)
                {
                    int rowIndex = filteredTripsGrid.Rows.Add();
                    DataGridViewRow row = filteredTripsGrid.Rows[rowIndex];
                    int availableSeats = trip.TotalSeats - service.getAllReservationsAt(trip.Id);

                    row.Cells["filteredTripsGridPlace"].Value = trip.Place;
                    row.Cells["filteredTripsGridTransportCompany"].Value = trip.TransportCompanyName;
                    row.Cells["filteredTripsGridDeparture"].Value = trip.Departure;
                    row.Cells["filteredTripsGridPrice"].Value = trip.Price;
                    row.Cells["filteredTripsGridNoSeats"].Value = availableSeats;
                    row.Tag = trip.Id;
                }
            }
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            if (nameField.Text.ToString() == "" || phoneNumberField.Text.ToString() == "" || noSeatsField.Text.ToString() == "")
                MessageBox.Show("empty field");
            else
            {
                if (allTripsGrid.SelectedRows.Count == 0 )
                {
                    MessageBox.Show("No trip selection");
                    return;
                }
                DataGridViewRow selection2 = allTripsGrid.SelectedRows[0];
                
                if (clientsGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No client selection");
                    return;
                }
                DataGridViewRow clientiselection = clientsGrid.SelectedRows[0];

                // create the trip
                long id = (long)allTripsGrid.SelectedRows[0].Tag;
                string place = allTripsGrid.SelectedRows[0].Cells["allTripsGridPlace"].Value.ToString();
                string company = allTripsGrid.SelectedRows[0].Cells["allTripsGridTransportCompanyName"].Value.ToString();
                DateTime departure = DateTime.Parse(allTripsGrid.SelectedRows[0].Cells["allTripsGridDeparture"].Value.ToString());
                float price = float.Parse(allTripsGrid.SelectedRows[0].Cells["allTripsGridPrice"].Value.ToString());
                int seats =int.Parse( allTripsGrid.SelectedRows[0].Cells["allTripsGridNoSeats"].Value.ToString());
                Trip trip = new Trip(place, company, departure, price, seats);
                trip.Id = id;

                //create client
                long id_client= (long)clientsGrid.SelectedRows[0].Tag;
                string username = clientsGrid.SelectedRows[0].Cells["clientsGridUsername"].Value.ToString();
                 Common.model.Client client = new Common.model.Client(username, DateTime.Now);
                client.Id = id_client;

                // fields 
                string clientName = nameField.Text;
                int noSeats = int.Parse(noSeatsField.Text);
                string phoneNumber=phoneNumberField.Text;
               
                
                try
                {
                    service.saveReservation(clientName, phoneNumber, noSeats, trip, responsibleEmployee, client);
                    MessageBox.Show("Ticket taken successfully!");
                    InitModel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }
    }
}
;