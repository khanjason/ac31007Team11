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
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace WindowsFormsApp
{
    public partial class map : Form
    {
        public map()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        
        }

        private object IntToStr(object position)
        {
            throw new NotImplementedException();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
        
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        //function to load address given, and show it on map
        private void btnLoadLatLong_Click(object sender, EventArgs e)
        {
            //set up map
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCgfKNFVdWfjXpEu29xUEjfekPIKBiHf1E";
            mapWindow.MapProvider = GMapProviders.GoogleMap;

            //if no input has been given, show error message
            if (txtAddress.Text.Trim().Equals(""))
            {
                MessageBox.Show("Error: Please enter address.");
            }
            //if input has been given, find location and place marker
            else
            {
                GeoCoderStatusCode statusCode;
                var pointLatLng = GoogleMapProvider.Instance.GetPoint(txtAddress.Text.Trim(), out statusCode);

                //if location is valid, find and place marker
                if (statusCode == GeoCoderStatusCode.OK)
                {
                    var location = createPoint(pointLatLng.Value.Lat, pointLatLng.Value.Lng);
                    setMapPosition(location);
                    placeMarker(location);
                }
                //if location is not valid, show error message
                else
                {
                    MessageBox.Show("Error: " + statusCode);
                }
            }
        }

        //function to create new point
        private PointLatLng createPoint(double lat, double lng)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            return point;
        }

        //function to set map position
        private void setMapPosition(PointLatLng point)
        {
            mapWindow.Position = new PointLatLng(point.Lat, point.Lng);
        }

        //function to place marker on map
        private void placeMarker(PointLatLng point)
        {
            //create marker and overlay for map, and add marker to it
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            mapWindow.Overlays.Add(markers);
        }
    }
}
