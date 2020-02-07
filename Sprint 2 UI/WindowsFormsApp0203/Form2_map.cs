using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PriceAndDistanceRange;

namespace WindowsFormsApp0203
{
    public partial class Form2_map : Form
    {
        public List<PointLatLng> pointsList = new List<PointLatLng>();
        public GMapOverlay markers = new GMapOverlay("markers");
        public int oldHighlightIndex = -1;

        public Form2_map()
        {
            InitializeComponent();
        }

        private void Back_page2_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form1_searchandhistory frm = new Form1_searchandhistory();//实例化第二个窗体.
            frm.Show();//然后显示出来.
        }

        private void Continue_page2_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form3_information frm3 = new Form3_information();//实例化第二个窗体.
            frm3.Show();//然后显示出来.
        }

        private void Continue_page1_Click(object sender, EventArgs e)
        {
            //Hide();//然后关闭.
            //Form3_information frm3 = new Form3_information();//实例化第二个窗体.
            //frm3.Show();//然后显示出来.

            drawRoute();
            refreshMap();
        }

        private void Form2_map_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void refreshMap()
        {
            mapWindow.Zoom--;
            mapWindow.Zoom++;
        }

        private void drawRoute()
        {
            //create route variable to hold root info
            var route = GoogleMapProvider.Instance.GetRoute(pointsList[0], pointsList[oldHighlightIndex], false, false, 5);

            //create variable for adding route to map
            var routeToAdd = new GMapRoute(route.Points, "Route just added");

            //add route to overlay
            var routeOverlay = new GMapOverlay();
            routeOverlay.Routes.Add(routeToAdd);
            mapWindow.Overlays.Add(routeOverlay);

        }

        /// <summary>
        /// Highlights a particular pointer, given the reference index
        /// </summary>
        /// <param name="pointerReference"></param>
        public void highlightPointer(int pointerReference)
        {
            markers.Markers[pointerReference + 1].IsVisible = false; //Make the default red marker invisible

            if (oldHighlightIndex != -1) //If there is another highlighted marker already on the map
            {
                if (oldHighlightIndex != pointerReference + 1) //If the old highlighted marker is not the same as the new marker
                {
                    markers.Markers[oldHighlightIndex].IsVisible = true; //Make the currently invisible default marker visible again
                }
                markers.Markers.RemoveAt(markers.Markers.Count - 1); //Remove the old highlighted marker
            }

            oldHighlightIndex = pointerReference + 1; //Remember the index of this new highlighted marker
            placeMarker(pointsList[pointerReference+1]); //Add the new marker to the map
        }

        //function to place marker on map
        public void placeMarker(PointLatLng point)
        {
            //create marker and overlay for map, and add marker to it
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue);
            markers.Markers.Add(marker);
            updateMap();
        }

        //Update the map
        public void updateMap()
        {
            mapWindow.Overlays.Clear();
            mapWindow.Overlays.Add(markers);
        }
    }
}
