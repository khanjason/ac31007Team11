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

namespace WindowsFormsApp
{
    public partial class map : Form
    {
        //Dictionary constaining distance values
        private Dictionary<string, double> distanceValues = new Dictionary<string, double>();

        //Absolute minimum and maximum range of values
        private double priceFloor = 0;
        private double priceCeiling = 200000;
        private double distFloor = 0;
        private double distCeiling = 3000;

        //Active minimum and maximum range of values for searching
        private double priceMin = 0;
        private double priceMax = 200000;
        private double distMin = 0;
        private double distMax = 3000;

        public map()
        {
            InitializeComponent();
            initDistanceValues();
        }

        private void initDistanceValues()
        {
            distanceValues.Add("Within 1 Mile", 1);
            distanceValues.Add("Within 5 Miles", 5);
            distanceValues.Add("Within 10 Miles", 10);
            distanceValues.Add("Within 20 Miles", 20);
            distanceValues.Add("Within 40 Miles", 40);
            distanceValues.Add("Within 80 Miles", 80);
            distanceValues.Add("Within 120 Miles", 120);
            distanceValues.Add("Within 150 Miles", 150);
            distanceValues.Add("Over 150 Miles", distCeiling);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void TrbPrice_Scroll(object sender, EventArgs e)
        {
            lblPrice.Text = (trbPrice.Value * 5000).ToString();
            setPriceMax(trbPrice.Value * 5000);
        }

        private void CmbDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            double distance = distanceValues[cmbDistance.SelectedItem.ToString()];

            if(distance < 3000)
            {
                setDistRange(0, distance);
            }
            else
            {
                setDistRange(151, distance);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            bool valid = validateUserInput(txbCodeSearch.Text);
            if (valid)
            {
                List<String[]> list = searchByCode(txbCodeSearch.Text); //To-Do input validation
                list = checkRange(list);
                list = sortByPrice(list);

                txbInfo.Clear();
                string s = "";
                foreach (string[] line in list)
                {
                    txbInfo.Text += ConvertStringArrayToString(line);
                    txbInfo.Text += "\r\n";
                }
            }
        }

        private string ConvertStringArrayToString(string[] array)
        {
            //Concatenate all the elements into a StringBuilder.
            string builder = "";

            for(int i = 2; i < 7; i++)
            {
                builder += array[i];
                builder += "\r\n";
            }
            CultureInfo us = CultureInfo.GetCultureInfo("en-US");
            builder += string.Format(us, "{0:C2}", double.Parse(array[10]));
            builder += "\r\n";

            return builder;
        }




        ////**** PRICE AND DISTANCE RANGE ****////

        private List<string[]> checkRange(List<string[]> list)
        {
            List<string[]> valid = new List<string[]>();

            foreach (string[] t in list)
            {
                if (checkPrice(double.Parse(t[10])))
                {
                    valid.Add(t);
                }
            }

            return valid;
        }

        /// <summary>
        /// Sets the minimum and maximum values for both price and distance
        /// </summary>
        /// <param name="pMin">The minimum value for the price</param>
        /// <param name="pMax">The maximum value for the price</param>
        /// <param name="dMin">The minimum value for the distance</param>
        /// <param name="dMax">The maximum value for the distance</param>
        public void setAllRange(double pMin, double pMax, double dMin, double dMax)
        {
            setPriceRange(pMin, pMax);
            setDistRange(dMin, dMax);
        }

        /// <summary>
        /// Sets the minimum and maximum values for the price
        /// </summary>
        /// <param name="min">The minimum value for the price</param>
        /// <param name="max">The maximum value for the price</param>
        public void setPriceRange(double min, double max)
        {
            if (min >= priceFloor && min <= priceCeiling && min <= max) { priceMin = min; } else { throw new PriceOutOfRangeException("Minimum price is out of range, or greater than max price"); }
            if (max >= priceFloor && max <= priceCeiling && max >= min) { priceMax = max; } else { throw new PriceOutOfRangeException("Maximum price is out of range, or lesser than min price"); }
        }

        /// <summary>
        /// Sets the minimum and maximum values for the distance
        /// </summary>
        /// <param name="min">The minimum value for the price</param>
        /// <param name="max">The maximum value for the price</param>
        public void setDistRange(double min, double max)
        {
            if (min >= distFloor && min <= distCeiling && min <= max) { distMin = min; } else { throw new DistanceOutOfRangeException("Minimum distance is out of range, or greater than max distance"); }
            if (max >= distFloor && max <= distCeiling && max >= min) { distMax = max; } else { throw new DistanceOutOfRangeException("Maximum distance is out of range, or lesser than min distance"); }
        }


        /// <summary>
        /// Checks if the given price and distance fall within their respective range
        /// </summary>
        /// <param name="price">The value to check against the price range</param>
        /// <param name="dist">The value to check against the distance range</param>
        /// <returns>Return true if both values fall within their respective ranges, false otherwise</returns>
        public bool checkAll(double price, double dist)
        {
            bool p = checkPrice(price);
            bool d = checkDist(dist);

            if (p && d) { return true; } else { return false; }
        }

        /// <summary>
        /// Checks if a given value falls within the price range
        /// </summary>
        /// <param name="val">The value to check against the distance range</param>
        /// <returns>Returns true if the value falls within the price range</returns>
        public bool checkPrice(double val)
        {
            if (val >= priceMin && val <= priceMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if a given value falls within the distance range
        /// </summary>
        /// <param name="val">The value to check against the distance range</param>
        /// <returns>Returns true if the value falls within the distance range</returns>
        public bool checkDist(double val)
        {
            if (val >= distMin && val <= distMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //** Getters And Setters **//
        public void setPriceMin(double val)
        {
            if (val >= priceFloor && val <= priceCeiling && val <= priceMax) { priceMin = val; } else { throw new PriceOutOfRangeException("Minimum price is out of range, or greater than max price"); }
        }
        public void setPriceMax(double val)
        {
            if (val >= priceFloor && val <= priceCeiling && val >= priceMin) { priceMax = val; } else { throw new PriceOutOfRangeException("Maximum price is out of range, or lesser than min price"); }
        }
        public void setDistMin(double val)
        {
            if (val >= distFloor && val <= distCeiling && val <= distMax) { distMin = val; } else { throw new DistanceOutOfRangeException("Minimum distance is out of range, or greater than max distance"); }
        }
        public void setDistMax(double val)
        {
            if (val >= distFloor && val <= distCeiling && val >= distMin) { distMax = val; } else { throw new DistanceOutOfRangeException("Maximum distance is out of range, or lesser than min distance"); }
        }
        public double getPriceMin()
        {
            return priceMin;
        }
        public double getPriceMax()
        {
            return priceMax;
        }
        public double getDistMin()
        {
            return distMin;
        }
        public double getDistMax()
        {
            return distMax;
        }

        //** Searching & Sorting **//
        public List<string[]> searchByCode(string code)
        {
            List<string[]> listOfOptions = new List<string[]>();
            var lines = File.ReadLines("../../res/MEDICARE_PROVIDER_CHARGE_INPATIENT_DRGALL_FY2017.txt");
            foreach (var line in lines)
            {
                string[] fields = line.Split('\t');
                string codeFromFile = fields[0].Split(' ')[0];
                codeFromFile = codeFromFile.Replace("\"", "");
                if (codeFromFile.Equals(code))
                {
                    for (int i = 0; i < fields.Count(); i++)
                    {
                        fields[i] = fields[i].Replace(@"\", @"\\");
                    }
                    listOfOptions.Add(fields);
                }
            }
            return listOfOptions;
        }

        public List<string[]> sortByPrice(List<string[]> detailList)
        {
            detailList = detailList.OrderBy(arr => Decimal.Parse(arr[10])).ToList();//.ThenBy(arr => Decimal.Parse(arr[10])).ToList();
            return detailList;
        }

        public bool validateUserInput(string userInput)
        {
            if (userInput.Length != 3)
            {
                Console.WriteLine("Please enter a three digit number.");
                MessageBox.Show("ERROR: Incorrect input");
                return false;
            }
            else if (!userInput.All(char.IsDigit))
            {
                Console.WriteLine("Please enter a three digit number.");
                MessageBox.Show("ERROR: Incorrect input");
                return false;
            }
            else
            {
                return true;
            }
        }

    }


    
}
