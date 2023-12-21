using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using System.Data.OleDb;


namespace LandReg2023
{
    public partial class Land_Registration : Form

    {
        string generateId = "";
        // creating a list to get latitudes and longitudea
        private List<PointLatLng>listofPoints;
        List<string> temporyList;
        public OleDbConnection connection = new OleDbConnection();

        public string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

        public Land_Registration()
        {
            InitializeComponent();
            //listofPoints = new List<PointLatLng>();
            getGPSLocations getGPSLocations = new getGPSLocations();
            listofPoints = new List<PointLatLng>();
            temporyList = new List<string>();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

        }
       
        private void Land_Registration_Load(object sender, EventArgs e)
        {
            map.ShowCenter = false;
            //loading map and controls

            map.DragButton = MouseButtons.Left;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            map.Dock = DockStyle.Fill;
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;

            map.MaxZoom = 100;
            map.MinZoom = 3;
            map.Zoom = 10;
           

        }

        private void BtnAddCoord(object sender, EventArgs e)
        {
            try
            {
                // getting latitudes and longitudes
                double lati = Convert.ToDouble(txtBoxLat.Text);
                double longi = Convert.ToDouble(txtBoxLong.Text);
                PointLatLng point = new PointLatLng(lati, longi);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_pushpin);

                lstBoxcord.Items.Add("latitude: " + lati + ", " + "Longitude: " + longi);
                temporyList.Add(Convert.ToString(lati + longi));

                map.Position = new GMap.NET.PointLatLng(lati, longi);
                listofPoints.Add(new PointLatLng(lati, longi));


                //create overlay
                GMapOverlay markers = new GMapOverlay("markers");

                //display all available markers
                markers.Markers.Add(marker);

                //cover the map
                map.Overlays.Add(markers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                var polygon = new GMapPolygon(listofPoints, "Land Area");
                polygon.Stroke = new Pen(Color.Red, 2);
                polygon.Fill = new SolidBrush(Color.FromArgb(30, Color.Red));


                var polygons = new GMapOverlay("Polygons");
                polygons.Polygons.Add(polygon);
                map.Overlays.Add(polygons);


                generateId = getGPSLocations.generateLandId(temporyList);// generate Id using tempory List 
                MessageBox.Show(generateId);// generated id need to saved in a database

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxLat.Clear();
            txtBoxLong.Clear();
            listofPoints.Clear();
            lstBoxcord.Items.Clear();
            map.Overlays.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(); // if this not work type useing oledbCommand
                command.Connection = connection;
                command.CommandText = "INSERT INTO Land_info (Land_ID, Cordinates) VALUES(@landid, @Cordinates)";
                command.Parameters.AddWithValue("@landid", generateId);
                command.Parameters.AddWithValue("@Cordinates", lstBoxcord.Text); // land id and cordinates need to enter only for 2 coordintes also works did not test this section
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("data saved");

                InsertLandDetails insertLandDetails = new InsertLandDetails();
                insertLandDetails.Show();
                this.Close();
               
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
