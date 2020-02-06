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
using Xunit;

namespace WindowsFormsApp0203
{
	public partial class Form1_searchandhistory : Form
	{
		public void Go_page1_Click(object sender, EventArgs e)
		{
			Hide();//然后关闭.
			Form2_map frm2 = new Form2_map();//实例化第二个窗体.
			frm2.Show();//然后显示出来.

			procedureSearch();
			loadMap(frm2);
			displayReults(frm2);
		}

		public void Close_page1_Click(object sender, EventArgs e)
		{
			Close();
		}

		//Dictionary constaining distance values
		public Dictionary<string, double> distanceValues = new Dictionary<string, double>();

		//Absolute minimum and maximum range of values
		public double priceFloor = 0;
		public double priceCeiling = 200000;
		public double distFloor = 0;
		public double distCeiling = 3000;

		//Active minimum and maximum range of values for searching
		public double priceMin = 0;
		public double priceMax = 10000;
		public double distMin = 0;
		public double distMax = 3000;

		public List<String[]> hospitalDetailsList = new List<String[]>();
		public List<PointLatLng> pointsList = new List<PointLatLng>();
		public GeoCoderStatusCode statusCode;

		public Form1_searchandhistory()
		{
			InitializeComponent();
			initDistanceValues();
		}

		public void initDistanceValues()
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

		/// <summary>
		/// function to load address given, and show it on map
		/// </summary>
		public void loadMap(Form2_map frm2)
		{
			//set up map
			GMapProviders.GoogleMap.ApiKey = @"AIzaSyCgfKNFVdWfjXpEu29xUEjfekPIKBiHf1E";
			frm2.mapWindow.MapProvider = GMapProviders.GoogleMap;

			//if no input has been given, show error message
			if (txtUserPosition.Text.Trim().Equals(""))
			{
				MessageBox.Show("Error: Please enter address.");
			}
			//if input has been given, find location and place marker
			else
			{
				string[] addressString = txtUserPosition.Text.Split(',');
				//if location is not valid, show error message
				try
				{
					if (!checkzipandstate(addressString[0], addressString[1]))
					{
						MessageBox.Show("Please enter location in the correct format.");
					}
					else
					{
						var pointLatLng = GoogleMapProvider.Instance.GetPoint(txtUserPosition.Text.Trim(), out statusCode);

						//if location is valid, find and place marker
						if (statusCode == GeoCoderStatusCode.OK)
						{
							var location = createPoint(pointLatLng.Value.Lat, pointLatLng.Value.Lng);
							setMapPosition(location, frm2);
							placeMarker(location, frm2);
							addPointToList(location);
							createHospitalRoutes(location, frm2);
						}
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Invalid input with address");
				}
			}

			//if input also given in destination box, create route
			//if (!txtDestination.Text.Trim().Equals(""))
			//{
			//	string[] destinationString = txtDestination.Text.Split(',');
			//	try
			//	{
			//		//add destination point to list
			//		if (!checkzipandstate(destinationString[0], destinationString[1]))
			//		{
			//			MessageBox.Show("Please enter destination in the correct format.");
			//		}
			//		else
			//		{
			//			var pointLatLng = GoogleMapProvider.Instance.GetPoint(txtDestination.Text.Trim(), out statusCode);

			//			//if location is valid, find and place marker
			//			if (statusCode == GeoCoderStatusCode.OK)
			//			{
			//				var location = createPoint(pointLatLng.Value.Lat, pointLatLng.Value.Lng);
			//				setMapPosition(location);
			//				placeMarker(location);
			//				addPointToList(location);

			//				//create route variable to hold root info
			//				var route = GoogleMapProvider.Instance.GetRoute(pointsList[0], pointsList[1], false, false, 5);

			//				//create variable for adding route to map
			//				var routeToAdd = new GMapRoute(route.Points, "Route just added");

			//				//add routes to overlay
			//				var routeOverlay = new GMapOverlay();
			//				routeOverlay.Routes.Add(routeToAdd);
			//				mapWindow.Overlays.Add(routeOverlay);

			//				//show distnce between locations on the map
			//				lblDistance.Text += Math.Round(route.Distance, 2) + "km";
			//			}
			//		}
			//	}
			//	catch (Exception)
			//	{
			//		MessageBox.Show("Invalid input with destination");
			//	}

			//}
		}

		//function to create nodes on each hospital returned
		public void createHospitalRoutes(PointLatLng userLocation, Form2_map frm2)
		{
			foreach (string[] hospital in hospitalDetailsList)
			{
				var hospitalAddress = hospital[6] + ',' + hospital[5];

				var pointLatLng = GoogleMapProvider.Instance.GetPoint(hospitalAddress, out statusCode);
				if (statusCode == GeoCoderStatusCode.OK)
				{
					var location = createPoint(pointLatLng.Value.Lat, pointLatLng.Value.Lng);
					setMapPosition(location, frm2);
					placeMarker(location, frm2);
					addPointToList(location);
				}

			}
		}

		//function to create new point
		public PointLatLng createPoint(double lat, double lng)
		{
			PointLatLng point = new PointLatLng(lat, lng);
			return point;
		}

		//function to set map position
		public void setMapPosition(PointLatLng point, Form2_map frm2)
		{
			frm2.mapWindow.Position = new PointLatLng(point.Lat, point.Lng);
		}

		//function to place marker on map
		public void placeMarker(PointLatLng point, Form2_map frm2)
		{
			//create marker and overlay for map, and add marker to it
			GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
			GMapOverlay markers = new GMapOverlay("markers");
			markers.Markers.Add(marker);
			frm2.mapWindow.Overlays.Add(markers);
		}

		//function to add point to point list
		public void addPointToList(PointLatLng point)
		{
			pointsList.Add(new PointLatLng(point.Lat, point.Lng));
		}

		/// <summary>
		/// manages the maximum/minimum distance
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void CmbDistance_SelectedIndexChanged(object sender, EventArgs e)
		{
			double distance = distanceValues[cmbDistance.SelectedItem.ToString()];

			if (distance < 3000)
			{
				setDistRange(0, distance);
			}
			else
			{
				setDistRange(151, distance);
			}
		}

		/// <summary>
		/// manages the maximum price
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void trbPrice_Scroll_1(object sender, EventArgs e)
		{
			lblPrice.Text = (trbPrice.Value * 5000).ToString();
			setPriceMax(trbPrice.Value * 5000);
		}

		/// <summary>
		/// Search for treatments matching medical code
		/// </summary>
		public void procedureSearch()
		{
			bool valid = validateUserInput(txtProcedure.Text);
			if (valid)
			{
				hospitalDetailsList = searchByCode(txtProcedure.Text);
				hospitalDetailsList = checkRange(hospitalDetailsList);
				hospitalDetailsList = sortByPrice(hospitalDetailsList);
			}
		}

		/// <summary>
		/// Displays the hospital list
		/// </summary>
		/// <param name="frm2">A reference to the second form</param>
		public void displayReults(Form2_map frm2)
		{
			frm2.lstHospitalDetails.Items.Clear();
			string s = "";
			foreach (string[] line in hospitalDetailsList)
			{
				frm2.lstHospitalDetails.Items.Add(ConvertStringArrayToString(line));
				frm2.lstHospitalDetails.Items.Add("\r\n");
			}
		}

		/// <summary>
		/// Converts a string array holding hospital details into it's own stirng
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public string ConvertStringArrayToString(string[] array)
		{
			//Concatenate all the elements into a StringBuilder.
			string builder = "";

			for (int i = 2; i < 7; i++)
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

		public List<string[]> checkRange(List<string[]> list)
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

		public bool containsnumbers(string zip)

		{

			char[] ziparr = zip.ToCharArray();
			char[] nums = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
			for (int i = 0; i < ziparr.Length; i++)
			{
				if (!(nums.Contains(ziparr[i])))
				{
					return false;
				}

			}

			return true;

		}

		public bool nospecialcharacters(string buildnum)
		{
			char[] buildnumarr = buildnum.ToCharArray();
			char[] speiChars = new char[] { '!', ',', '.', '?', '#', '£', '$', '^', '&', '*', '(', ')' };
			foreach (var t in buildnumarr)
			{
				if ((speiChars.Contains(t)))
				{
					return false;
				}
			}

			return true;

		}

		public bool checkzipandstate(string zip, string state)
		{

			if (!stateCheck(state))
			{
				return false;
			}
			else if (!checkZip(zip))
			{
				return false;
			}
			else
			{
				Dictionary<string, string> statezipDictionary =
					new Dictionary<string, string>();
				statezipDictionary.Add("CT", "0");
				statezipDictionary.Add("MA", "0");
				statezipDictionary.Add("ME", "0");
				statezipDictionary.Add("NH", "0");
				statezipDictionary.Add("NJ", "0");
				statezipDictionary.Add("RI", "0");
				statezipDictionary.Add("NY", "01");
				statezipDictionary.Add("VT", "0");
				statezipDictionary.Add("VI", "0");
				statezipDictionary.Add("DE", "1");
				statezipDictionary.Add("PA", "1");
				statezipDictionary.Add("MD", "2");
				statezipDictionary.Add("NC", "2");
				statezipDictionary.Add("SC", "2");
				statezipDictionary.Add("VA", "2");
				statezipDictionary.Add("WV", "2");
				statezipDictionary.Add("AL", "3");
				statezipDictionary.Add("FL", "3");
				statezipDictionary.Add("GA", "3");
				statezipDictionary.Add("MS", "3");
				statezipDictionary.Add("TN", "3");
				statezipDictionary.Add("IN", "4");
				statezipDictionary.Add("KY", "4");
				statezipDictionary.Add("MI", "4");
				statezipDictionary.Add("OH", "4");
				statezipDictionary.Add("IA", "5");
				statezipDictionary.Add("MN", "5");
				statezipDictionary.Add("MT", "5");
				statezipDictionary.Add("ND", "5");
				statezipDictionary.Add("SD", "5");
				statezipDictionary.Add("WI", "5");
				statezipDictionary.Add("IL", "6");
				statezipDictionary.Add("KS", "6");
				statezipDictionary.Add("MO", "6");
				statezipDictionary.Add("NE", "6");
				statezipDictionary.Add("AR", "7");
				statezipDictionary.Add("LA", "7");
				statezipDictionary.Add("OK", "7");
				statezipDictionary.Add("TX", "7");
				statezipDictionary.Add("AZ", "8");
				statezipDictionary.Add("CO", "8");
				statezipDictionary.Add("ID", "8");
				statezipDictionary.Add("NM", "8");
				statezipDictionary.Add("NV", "8");
				statezipDictionary.Add("UT", "8");
				statezipDictionary.Add("WY", "8");
				statezipDictionary.Add("AK", "9");
				statezipDictionary.Add("CA", "9");
				statezipDictionary.Add("OR", "9");
				statezipDictionary.Add("WA", "9");

				char[] pre = zip.ToCharArray();
				string prefix = pre[0].ToString();

				if (!(statezipDictionary[state].Contains(prefix)))
				{
					return false;
				}
				return true;
			}

		}




		public bool checkZip(string zip)
		{
			if (zip.Length != 5)
			{
				return false;
				//throw new System.ArgumentException("zip code must be 5 characters long");
			}
			if (containsnumbers(zip) != true)
			{
				return false;
				//throw new System.ArgumentException("zip code must only contain numbers");
			}


			return true;


		}

		public bool stateCheck(string State)
		{

			if (State.Length != 2)
			{
				throw new System.ArgumentException("state code must be 2 characters long");

			}
			string[] statelist =
			{
				"AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY",
				"LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
				"OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
			};

			if (!(statelist.Contains(State)))
			{
				return false;
				throw new System.ArgumentException("state code must be valid US state postal code");


			}
			return true;
		}
	}
}
