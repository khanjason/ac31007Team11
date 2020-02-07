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
            if (procedureSearch() && hospitalDetailsList.Count > 0)
            {
                Hide();//然后关闭.
			    Form2_map frm2 = new Form2_map();//实例化第二个窗体.
			    frm2.Show();//然后显示出来.

                loadMap(frm2);

                if (rbtDistance.Checked)
                {
                    for (int i = 0; i < hospitalDetailsList.Count; i++)
                    {
                        string[] temp = hospitalDetailsList[i];
                        hospitalDetailsList[i] = new string[13];

                        for (int j = 0; j < hospitalDetailsList[i].Length - 1; j++)
                        {
                            hospitalDetailsList[i][j] = temp[j];
                        }

                        hospitalDetailsList[i][12] = hospitalDistanceList[i].ToString();
                    }
                    hospitalDetailsList = sortByDistance(hospitalDetailsList);
                    hospitalDistanceList = sortDistanceList(hospitalDistanceList);
                }

                displayResults(frm2);
            }
		}

		public void Close_page1_Click(object sender, EventArgs e)
		{
			Close();
		}

		//Dictionary constaining distance values
		public Dictionary<string, double> distanceValues = new Dictionary<string, double>();

		//Panel manager for form 2
		PanelManger panelManger;

		//Absolute minimum and maximum range of values
		public double priceFloor = 0;
		public double priceCeiling = 200000;
		public double distFloor = 0;
		public double distCeiling = 5000;

		//Active minimum and maximum range of values for searching
		public double priceMin = 0;
		public double priceMax = 10000;
		public double distMin = 0;
		public double distMax = 5000;

		public List<String[]> hospitalDetailsList = new List<String[]>();
		public List<double> hospitalDistanceList = new List<double>();
		public GeoCoderStatusCode statusCode;
        public bool firstLocation = true;


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

			string userLocation = txtUserZip.Text.Trim() + "," + txtUserState.Text.Trim().ToUpper();

			//if no input has been given, show error message
			if (userLocation.Equals(""))
			{
				MessageBox.Show("Error: Please enter address.");
			}
			//if input has been given, find location and place marker
			else
			{
				string[] addressString = userLocation.Split(',');
				//if location is not valid, show error message
				try
				{
					if (!checkzipandstate(addressString[0], addressString[1]))
					{
						MessageBox.Show("Please enter location in the correct format.");
					}
					else
					{
						var pointLatLng = GoogleMapProvider.Instance.GetPoint(txtUserZip.Text.Trim(), out statusCode);

						//if location is valid, find and place marker
						if (statusCode == GeoCoderStatusCode.OK)
						{
							var location = createPoint(pointLatLng.Value.Lat, pointLatLng.Value.Lng);
							setMapPosition(location, frm2);
							placeMarker(location, frm2);
							addPointToList(location, frm2);
							createHospitalRoutes(location, frm2);
						}
					}
				}
				catch (Exception)
				{
					//MessageBox.Show("Invalid input with address" + e.ToString());
				}
			}
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

					var route = GoogleMapProvider.Instance.GetRoute(frm2.pointsList[0], location, false, false, 5);

					if(checkDist(Math.Round(route.Distance, 2)))
					{
						addPointToList(location, frm2);
						placeMarker(location, frm2);
						hospitalDistanceList.Add(Math.Round(route.Distance, 2));
					}
					else
					{
						hospitalDetailsList.Remove(hospital);
					}
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
            GMapMarker marker;

            //create marker and overlay for map, and add marker to it
            if (firstLocation)
            {
                marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
                firstLocation = false;
            }
            else
            {
                marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
            }
			
			frm2.markers.Markers.Add(marker);
			frm2.updateMap();
		}

		//function to add point to point list
		public void addPointToList(PointLatLng point, Form2_map frm2)
		{
			frm2.pointsList.Add(new PointLatLng(point.Lat, point.Lng));
		}

		/// <summary>
		/// manages the maximum/minimum distance
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbDistance_SelectedIndexChanged_1(object sender, EventArgs e)
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
		public bool procedureSearch()
		{
            string searchTerm;
            bool valid = false;

            if(cmbSpecificProcedure.Items.Count == 0)
            {
                valid = validateUserInput(txtProcedure.Text);
                searchTerm = txtProcedure.Text;
            }
            else
            {
                valid = validateUserInput(cmbSpecificProcedure.SelectedItem.ToString().Substring(0, 3));
                searchTerm = cmbSpecificProcedure.SelectedItem.ToString().Substring(0, 3);
            }


			if (valid)
			{
				hospitalDetailsList = searchByCode(searchTerm);
            }
            else
            {
                hospitalDetailsList = searchByProcedure(searchTerm);

                if(hospitalDetailsList[0].Length == 1)
                {
                    foreach (string[] procedure in hospitalDetailsList)
                    {
                        cmbSpecificProcedure.Items.Add(procedure[0]);
                    }
                }
            }

            if (hospitalDetailsList[0].Length != 1)
            {
                hospitalDetailsList = checkRange(hospitalDetailsList);

                if (rbtPrice.Checked)
                {
                    hospitalDetailsList = sortByPrice(hospitalDetailsList);
                }

                return true;
            }

            return false;
        }

		/// <summary>
		/// Displays the hospital list
		/// </summary>
		/// <param name="frm2">A reference to the second form</param>
		public void displayResults(Form2_map frm2)
		{
			panelManger = new PanelManger(frm2, frm2.resultsPanel);
			List<string> allEntries = new List<string>();
			int i = 0;

			if (hospitalDistanceList.Count != 0)
			{
				foreach (string[] line in hospitalDetailsList)
				{
					string entry = "";

					if (line[2].Length > 35)
					{
						entry += line[2].Substring(0,35) + "\r\n";
					}
					else
					{
						entry += line[2] + "\r\n";
					}
					entry += "$" + string.Format("{0:0.00}", double.Parse(line[10])) + "\r\n";

                    entry += string.Format("{0:N2}", hospitalDistanceList[i]) + "km";

					allEntries.Add(entry);
					i++;
				}
				panelManger.generateEntries(allEntries);
			}
			else
			{
				MessageBox.Show("No results in range");
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
        //Searches by Code
		public List<string[]> searchByCode(string code)
		{
			List<string[]> listOfOptions = new List<string[]>();
            //opens file
			var lines = File.ReadLines("../../res/MEDICARE_PROVIDER_CHARGE_INPATIENT_DRGALL_FY2017.txt");
			foreach (var line in lines)
			{
                //preps data for search
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

        //Searches by procedure
        public List<string[]> searchByProcedure(string procedure)
        {
            procedure = procedure.ToUpper();
            List<string[]> listOfOptions = new List<string[]>();
            //opens file
            var lines = File.ReadLines("../../res/MEDICARE_PROVIDER_CHARGE_INPATIENT_DRGALL_FY2017.txt");
            //checks if the file contains the exact term
            foreach (var line in lines)
            {
                //preps data for search
                string[] fields = line.Split('\t');
                string procedureFromFile = fields[0];
                procedureFromFile = procedureFromFile.Replace("\"", "");
                if (procedureFromFile.Split('-')[1].Equals(procedure))
                {
                    for (int i = 0; i < fields.Count(); i++)
                    {
                        fields[i] = fields[i].Replace(@"\", @"\\");
                    }
                    listOfOptions.Add(fields);
                }
            }
            //split the search into words
            List<string> searchWords = procedure.Split(' ').ToList();
            //searchs for each word and if all words are found
            if (listOfOptions.Count == 0)
            {
                foreach (var line in lines)
                {
                    string[] fields = line.Split('\t');
                    string procedureFromFile = fields[0];
                    procedureFromFile = procedureFromFile.Replace("\"", "");
                    int count = 0;
                    foreach (string word in searchWords)
                    {
                        if (word.Length > 2)
                        {
                            if (procedureFromFile.Contains(word))
                            {
                                count++;
                            }
                        }
                    }
                    if (count == (searchWords.Count()) && count > 1)
                    {
                        for (int i = 0; i < fields.Count(); i++)
                        {
                            fields[i] = fields[i].Replace(@"\", @"\\");
                        }
                        listOfOptions.Add(fields);
                    }
                }
            }
            //search for each word
            if (listOfOptions.Count == 0)
            {
                //add search terms if relivant
                if (searchWords.Contains("HEART"))
                {
                    searchWords.Add("ECMO OR TRACH W MV >96 HRS OR PDX EXC FACE, MOUTH & NECK W MAJ O.R.");
                    searchWords.Add("TRACH W MV >96 HRS OR PDX EXC FACE, MOUTH & NECK W/O MAJ O.R.");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W MCC");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W CC");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W/O CC/MCC");
                    searchWords.Add("CAROTID ARTERY STENT PROCEDURE W CC");
                    searchWords.Add("CAROTID ARTERY STENT PROCEDURE W/O CC/MCC");
                    searchWords.Add("CORONARY BYPASS W PTCA W MCC");
                    searchWords.Add("CORONARY BYPASS W CARDIAC CATH W MCC");
                    searchWords.Add("CORONARY BYPASS W CARDIAC CATH W/O MCC");
                    searchWords.Add("CORONARY BYPASS W/O CARDIAC CATH W MCC");
                    searchWords.Add("CORONARY BYPASS W/O CARDIAC CATH W/O MCC");
                    searchWords.Add("AICD GENERATOR PROCEDURES");
                    searchWords.Add("OTHER VASCULAR PROCEDURES W MCC");
                    searchWords.Add("OTHER VASCULAR PROCEDURES W CC");
                    searchWords.Add("OTHER VASCULAR PROCEDURES W/O CC/MCC");
                    searchWords.Add("OTHER CIRCULATORY SYSTEM O.R. PROCEDURES");
                    searchWords.Add("ENDOVASCULAR CARDIAC VALVE REPLACEMENT W MCC");
                    searchWords.Add("ENDOVASCULAR CARDIAC VALVE REPLACEMENT W/O MCC");
                    searchWords.Add("OTHER MAJOR CARDIOVASCULAR PROCEDURES W MCC");
                    searchWords.Add("OTHER MAJOR CARDIOVASCULAR PROCEDURES W CC");
                    searchWords.Add("OTHER MAJOR CARDIOVASCULAR PROCEDURES W/O CC/MCC");
                    searchWords.Add("PERCUTANEOUS INTRACARDIAC PROCEDURES W MCC");
                    searchWords.Add("PERCUTANEOUS INTRACARDIAC PROCEDURES W/O MCC");
                    searchWords.Add("ACUTE MYOCARDIAL INFARCTION, DISCHARGED ALIVE W MCC");
                    searchWords.Add("ACUTE MYOCARDIAL INFARCTION, DISCHARGED ALIVE W CC");
                    searchWords.Add("ACUTE MYOCARDIAL INFARCTION, DISCHARGED ALIVE W/O CC/MCC");
                    searchWords.Add("ACUTE MYOCARDIAL INFARCTION, EXPIRED W MCC");
                    searchWords.Add("CIRCULATORY DISORDERS EXCEPT AMI, W CARD CATH W MCC");
                    searchWords.Add("CIRCULATORY DISORDERS EXCEPT AMI, W CARD CATH W/O MCC");
                    searchWords.Add("CARDIAC CONGENITAL & VALVULAR DISORDERS W MCC");
                    searchWords.Add("CARDIAC CONGENITAL & VALVULAR DISORDERS W/O MCC");
                }
                if (searchWords.Contains("LUNGS") || searchWords.Contains("LUNG"))
                {
                    searchWords.Add("ECMO OR TRACH W MV >96 HRS OR PDX EXC FACE, MOUTH & NECK W MAJ O.R.");
                    searchWords.Add("TRACH W MV >96 HRS OR PDX EXC FACE, MOUTH & NECK W/O MAJ O.R.");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W CC");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W/O CC/MCC");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W MCC");
                    searchWords.Add("PULMONARY EMBOLISM W MCC");
                    searchWords.Add("PULMONARY EMBOLISM W/O MCC");
                    searchWords.Add("PLEURAL EFFUSION W MCC");
                    searchWords.Add("PULMONARY EDEMA & RESPIRATORY FAILURE");
                    searchWords.Add("CHRONIC OBSTRUCTIVE PULMONARY DISEASE W MCC");
                    searchWords.Add("CHRONIC OBSTRUCTIVE PULMONARY DISEASE W CC");
                    searchWords.Add("CHRONIC OBSTRUCTIVE PULMONARY DISEASE W/O CC/MCCS");
                    searchWords.Add("PNEUMOTHORAX W MCC");
                    searchWords.Add("PNEUMOTHORAX W CC");
                    searchWords.Add("PNEUMOTHORAX W/O CC/MCC");
                }
                if (searchWords.Contains("BREATHING"))
                {
                    searchWords.Add("ECMO OR TRACH W MV >96 HRS OR PDX EXC FACE, MOUTH & NECK W MAJ O.R.");
                    searchWords.Add("TRACH W MV >96 HRS OR PDX EXC FACE, MOUTH & NECK W/O MAJ O.R.");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W CC");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W/O CC/MCC");
                    searchWords.Add("TRACHEOSTOMY FOR FACE,MOUTH & NECK DIAGNOSES W MCC");
                    searchWords.Add("OTHER RESP SYSTEM O.R. PROCEDURES W MCC");
                    searchWords.Add("OTHER RESP SYSTEM O.R. PROCEDURES W CC");
                    searchWords.Add("OTHER RESP SYSTEM O.R. PROCEDURES W/O CC/MCC");
                    searchWords.Add("RESPIRATORY INFECTIONS & INFLAMMATIONS W MCC");
                    searchWords.Add("RESPIRATORY INFECTIONS & INFLAMMATIONS W CC");
                    searchWords.Add("RESPIRATORY INFECTIONS & INFLAMMATIONS W/O CC/MCC");
                    searchWords.Add("RESPIRATORY SIGNS & SYMPTOMS");
                    searchWords.Add("OTHER RESPIRATORY SYSTEM DIAGNOSES W MCC");
                }
                if (searchWords.Contains("STROKE"))
                {
                    searchWords.Add("INTRACRANIAL VASCULAR PROCEDURES W PDX HEMORRHAGE W MCC");
                    searchWords.Add("NONSPECIFIC CVA & PRECEREBRAL OCCLUSION W/O INFARCT W/O MCC");
                    searchWords.Add("TRANSIENT ISCHEMIA");
                    searchWords.Add("NONSPECIFIC CEREBROVASCULAR DISORDERS W MCC");
                    searchWords.Add("NONSPECIFIC CEREBROVASCULAR DISORDERS W CC");
                }
                if (searchWords.Contains("BRAIN"))
                {
                    searchWords.Add("CRANIOTOMY W MAJOR DEVICE IMPLANT OR ACUTE CNS PDX W MCC OR CHEMOTHE");
                    searchWords.Add("CRANIO W MAJOR DEV IMPL/ACUTE COMPLEX CNS PDX W/O MCC");
                    searchWords.Add("CRANIOTOMY & ENDOVASCULAR INTRACRANIAL PROCEDURES W MCC");
                    searchWords.Add("CRANIOTOMY & ENDOVASCULAR INTRACRANIAL PROCEDURES W CC");
                    searchWords.Add("CRANIOTOMY & ENDOVASCULAR INTRACRANIAL PROCEDURES W/O CC/MCC");
                    searchWords.Add("PERIPH/CRANIAL NERVE & OTHER NERV SYST PROC W MCC");
                    searchWords.Add("PERIPH/CRANIAL NERVE & OTHER NERV SYST PROC W CC OR PERIPH NEUROSTIM");
                    searchWords.Add("PERIPH/CRANIAL NERVE & OTHER NERV SYST PROC W/O CC/MCC");
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W MCC");
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W/O MCC");
                    searchWords.Add("INTRACRANIAL HEMORRHAGE OR CEREBRAL INFARCTION W MCC");
                    searchWords.Add("INTRACRANIAL HEMORRHAGE OR CEREBRAL INFARCTION W CC OR TPA IN 24 HRS");
                    searchWords.Add("INTRACRANIAL HEMORRHAGE OR CEREBRAL INFARCTION W/O CC/MCC");
                    searchWords.Add("NONSPECIFIC CEREBROVASCULAR DISORDERS W/O CC/MCC");
                    searchWords.Add("CRANIAL & PERIPHERAL NERVE DISORDERS W MCC");
                    searchWords.Add("CRANIAL & PERIPHERAL NERVE DISORDERS W/O MCC");
                    searchWords.Add("HYPERTENSIVE ENCEPHALOPATHY W MCC");
                    searchWords.Add("HYPERTENSIVE ENCEPHALOPATHY W CC");
                    searchWords.Add("CRANIAL/FACIAL PROCEDURES W CC/MCC");
                    searchWords.Add("CRANIAL/FACIAL PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("SURGERY"))
                {
                    searchWords.Add("CRANIOTOMY W MAJOR DEVICE IMPLANT OR ACUTE CNS PDX W MCC OR CHEMOTHE");
                    searchWords.Add("CRANIO W MAJOR DEV IMPL/ACUTE COMPLEX CNS PDX W/O MCC");
                    searchWords.Add("CRANIOTOMY & ENDOVASCULAR INTRACRANIAL PROCEDURES W MCC");
                    searchWords.Add("CRANIOTOMY & ENDOVASCULAR INTRACRANIAL PROCEDURES W CC");
                    searchWords.Add("CRANIOTOMY & ENDOVASCULAR INTRACRANIAL PROCEDURES W/O CC/MCC");
                    searchWords.Add("EXTRAOCULAR PROCEDURES EXCEPT ORBIT");
                }
                if (searchWords.Contains("SPINE"))
                {
                    searchWords.Add("SPINAL PROCEDURES W MCC");
                    searchWords.Add("SPINAL PROCEDURES W CC OR SPINAL NEUROSTIMULATORS");
                    searchWords.Add("SPINAL PROCEDURES W/O CC/MCC");
                    searchWords.Add("SPINAL DISORDERS & INJURIES W CC/MCC");
                    searchWords.Add("SPINAL DISORDERS & INJURIES W/O CC/MCC");
                }
                if (searchWords.Contains("HYDROCEPHALUS"))
                {
                    searchWords.Add("VENTRICULAR SHUNT PROCEDURES W MCC");
                    searchWords.Add("VENTRICULAR SHUNT PROCEDURES W CC");
                    searchWords.Add("VENTRICULAR SHUNT PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("WATER"))
                {
                    searchWords.Add("VENTRICULAR SHUNT PROCEDURES W MCC");
                    searchWords.Add("VENTRICULAR SHUNT PROCEDURES W CC");
                    searchWords.Add("VENTRICULAR SHUNT PROCEDURES W/O CC/MCC");
                    searchWords.Add("PLEURAL EFFUSION W MCC");
                    searchWords.Add("PLEURAL EFFUSION W CC");
                }
                if (searchWords.Contains("HEAD"))
                {
                    searchWords.Add("EXTRACRANIAL PROCEDURES W MCC");
                    searchWords.Add("EXTRACRANIAL PROCEDURES W CC");
                    searchWords.Add("EXTRACRANIAL PROCEDURES W/O CC/MCC");
                    searchWords.Add("ORBITAL PROCEDURES W/O CC/MCC");
                    searchWords.Add("OTHER EAR, NOSE, MOUTH & THROAT O.R. PROCEDURES W CC/MCC");
                }
                if (searchWords.Contains("SKULL"))
                {
                    searchWords.Add("EXTRACRANIAL PROCEDURES W MCC");
                    searchWords.Add("EXTRACRANIAL PROCEDURES W CC");
                    searchWords.Add("EXTRACRANIAL PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("TUMOR"))
                {
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W MCC");
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W/O MCC");
                    searchWords.Add("RESPIRATORY NEOPLASMS W MCC");
                    searchWords.Add("RESPIRATORY NEOPLASMS W CC");
                    searchWords.Add("KIDNEY & URETER PROCEDURES FOR NEOPLASM W MCC");
                    searchWords.Add("KIDNEY & URETER PROCEDURES FOR NEOPLASM W CC");
                    searchWords.Add("KIDNEY & URETER PROCEDURES FOR NEOPLASM W/O CC/MCC");
                    searchWords.Add("KIDNEY & URINARY TRACT NEOPLASMS W MCC");
                    searchWords.Add("KIDNEY & URINARY TRACT NEOPLASMS W CC");
                    searchWords.Add("KIDNEY & URINARY TRACT INFECTIONS W MCC");
                    searchWords.Add("KIDNEY & URINARY TRACT INFECTIONS W/O MCC");
                    searchWords.Add("UTERINE & ADNEXA PROC FOR OVARIAN OR ADNEXAL MALIGNANCY W MCC");
                    searchWords.Add("UTERINE & ADNEXA PROC FOR OVARIAN OR ADNEXAL MALIGNANCY W CC");
                    searchWords.Add("UTERINE,ADNEXA PROC FOR NON-OVARIAN/ADNEXAL MALIG W CC");
                    searchWords.Add("UTERINE,ADNEXA PROC FOR NON-OVARIAN/ADNEXAL MALIG W/O CC/MCC");
                    searchWords.Add("MALIGNANCY, FEMALE REPRODUCTIVE SYSTEM W MCC");
                    searchWords.Add("MALIGNANCY, FEMALE REPRODUCTIVE SYSTEM W CC");
                    searchWords.Add("MYELOPROLIFERATIVE DISORDERS OR POORLY");
                }
                if (searchWords.Contains("NERVE"))
                {
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W MCC");
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W/O MCC");
                    searchWords.Add("DEGENERATIVE NERVOUS SYSTEM DISORDERS W MCC");
                    searchWords.Add("DEGENERATIVE NERVOUS SYSTEM DISORDERS W/O MCC");
                    searchWords.Add("OTHER DISORDERS OF NERVOUS SYSTEM W MCC");
                    searchWords.Add("OTHER DISORDERS OF NERVOUS SYSTEM W CC");
                    searchWords.Add("OTHER DISORDERS OF NERVOUS SYSTEM W/O CC/MCC");
                }
                if (searchWords.Contains("SHEATH"))
                {
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W MCC");
                    searchWords.Add("NERVOUS SYSTEM NEOPLASMS W/O MCC");
                }
                if (searchWords.Contains("BLOOD"))
                {
                    searchWords.Add("NONSPECIFIC CEREBROVASCULAR DISORDERS W/O CC/MCC");
                    searchWords.Add("HYPERTENSIVE ENCEPHALOPATHY W MCC");
                    searchWords.Add("HYPERTENSIVE ENCEPHALOPATHY W CC");
                    searchWords.Add("PERIPHERAL VASCULAR DISORDERS W MCC");
                    searchWords.Add("PERIPHERAL VASCULAR DISORDERS W CC");
                    searchWords.Add("PERIPHERAL VASCULAR DISORDERS W/O CC/MCC");
                    searchWords.Add("HYPERTENSION W MCC");
                    searchWords.Add("HYPERTENSION W/O MCC");
                    searchWords.Add("MAJOR HEMATOL/IMMUN DIAG EXC SICKLE CELL CRISIS & COAGUL W MCC");
                    searchWords.Add("MAJOR HEMATOL/IMMUN DIAG EXC SICKLE CELL CRISIS & COAGUL W CC");
                    searchWords.Add("COAGULATION DISORDERS");
                    searchWords.Add("SEPTICEMIA OR SEVERE SEPSIS W MV >96 HOURS");
                    searchWords.Add("SEPTICEMIA OR SEVERE SEPSIS W/O MV >96 HOURS W MCC");
                    searchWords.Add("SEPTICEMIA OR SEVERE SEPSIS W/O MV >96 HOURS W/O MCC");
                }
                if (searchWords.Contains("PRESSURE"))
                {
                    searchWords.Add("HYPERTENSIVE ENCEPHALOPATHY W MCC");
                    searchWords.Add("HYPERTENSIVE ENCEPHALOPATHY W CC");
                    searchWords.Add("HYPERTENSION W MCC");
                    searchWords.Add("HYPERTENSION W/O MCC");
                }
                if (searchWords.Contains("INFECTION"))
                {
                    searchWords.Add("NON-BACTERIAL INFECT OF NERVOUS SYS EXC VIRAL MENINGITIS W MCC");
                    searchWords.Add("NON-BACTERIAL INFECT OF NERVOUS SYS EXC VIRAL MENINGITIS W CC");
                    searchWords.Add("OSTEOMYELITIS W MCC");
                    searchWords.Add("OSTEOMYELITIS W CC");
                    searchWords.Add("CELLULITIS W MCC");
                    searchWords.Add("CELLULITIS W/O MCC");
                    searchWords.Add("INFECTIOUS & PARASITIC DISEASES W O.R. PROCEDURE W MCC");
                    searchWords.Add("INFECTIOUS & PARASITIC DISEASES W O.R. PROCEDURE W CC");
                }
                if (searchWords.Contains("MIGRAINE"))
                {
                    searchWords.Add("HEADACHES W/O MCC");
                }
                if (searchWords.Contains("EYE"))
                {
                    searchWords.Add("ORBITAL PROCEDURES W/O CC/MCC");
                    searchWords.Add("EXTRAOCULAR PROCEDURES EXCEPT ORBIT");
                }
                if (searchWords.Contains("CATARACT"))
                {
                    searchWords.Add("INTRAOCULAR PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("OFF-BALANCE"))
                {
                    searchWords.Add("DYSEQUILIBRIUM");
                }
                if (searchWords.Contains("NOSEBLEED"))
                {
                    searchWords.Add("EPISTAXIS W/O MCC");
                }
                if (searchWords.Contains("EAR") || searchWords.Contains("EARS"))
                {
                    searchWords.Add("OTITIS MEDIA & URI W MCC");
                    searchWords.Add("OTITIS MEDIA & URI W/O MCC");
                }
                if (searchWords.Contains("TEETH") || searchWords.Contains("TOOTH"))
                {
                    searchWords.Add("DENTAL & ORAL DISEASES W MCC");
                    searchWords.Add("DENTAL & ORAL DISEASES W CC");
                }
                if (searchWords.Contains("DISEASE"))
                {
                    searchWords.Add("MYELOPROLIF DISORD OR POORLY DIFF NEOPL W MAJ O.R. PROC W CC");
                    searchWords.Add("MYELOPROLIF DISORD OR POORLY DIFF NEOPL W MAJ O.R. PROC W/O CC/MCC");
                    searchWords.Add("MYELOPROLIFERATIVE DISORDERS OR POORLY DIFFERENTIATED NEOPLASMS W OT");
                }
                if (searchWords.Contains("COLLAPSED"))
                {
                    searchWords.Add("PNEUMOTHORAX W MCC");
                    searchWords.Add("PNEUMOTHORAX W CC");
                    searchWords.Add("PNEUMOTHORAX W/O CC/MCC");
                }
                if (searchWords.Contains("SKIN"))
                {
                    searchWords.Add("PERCUTANEOUS INTRACARDIAC PROCEDURES W MCC");
                    searchWords.Add("PERCUTANEOUS INTRACARDIAC PROCEDURES W/O MCC");
                    searchWords.Add("WND DEBRID & SKN GRFT EXC HAND, FOR MUSCULO-CONN TISS DIS W MCC");
                    searchWords.Add("WND DEBRID & SKN GRFT EXC HAND, FOR MUSCULO-CONN TISS DIS W CC");
                    searchWords.Add("WND DEBRID & SKN GRFT EXC HAND, FOR MUSCULO-CONN TISS DIS W/O CC/MCC");
                    searchWords.Add("CELLULITIS W MCC");
                    searchWords.Add("CELLULITIS W/O MCC");
                }
                if (searchWords.Contains("ARTERIES"))
                {
                    searchWords.Add("ATHEROSCLEROSIS W MCC");
                    searchWords.Add("ATHEROSCLEROSIS W/O MCC");
                }
                if (searchWords.Contains("HEARTBEAT"))
                {
                    searchWords.Add("CARDIAC ARRHYTHMIA & CONDUCTION DISORDERS W MCC");
                    searchWords.Add("CARDIAC ARRHYTHMIA & CONDUCTION DISORDERS W CC");
                    searchWords.Add("CARDIAC ARRHYTHMIA & CONDUCTION DISORDERS W/O CC/MCC");
                }
                if (searchWords.Contains("FAINTING"))
                {
                    searchWords.Add("SYNCOPE & COLLAPSE");
                }
                if (searchWords.Contains("INTESTINE"))
                {
                    searchWords.Add("STOMACH, ESOPHAGEAL & DUODENAL PROC W MCC");
                    searchWords.Add("STOMACH, ESOPHAGEAL & DUODENAL PROC W CC");
                    searchWords.Add("STOMACH, ESOPHAGEAL & DUODENAL PROC W/O CC/MCC");
                }
                if (searchWords.Contains("ABDOMEN"))
                {
                    searchWords.Add("PERITONEAL ADHESIOLYSIS W MCC");
                    searchWords.Add("PERITONEAL ADHESIOLYSIS W CC");
                    searchWords.Add("PERITONEAL ADHESIOLYSIS W/O CC/MCC");
                    searchWords.Add("MAJOR GASTROINTESTINAL DISORDERS & PERITONEAL INFECTIONS W MCC");
                    searchWords.Add("MAJOR GASTROINTESTINAL DISORDERS & PERITONEAL INFECTIONS W CC");
                    searchWords.Add("MAJOR GASTROINTESTINAL DISORDERS & PERITONEAL INFECTIONS W/O CC/MCC");
                    searchWords.Add("D&C, CONIZATION, LAPAROSCOPY & TUBAL INTERRUPTION W CC/MCC");
                }
                if (searchWords.Contains("APPENDIX"))
                {
                    searchWords.Add("APPENDECTOMY W COMPLICATED PRINCIPAL DIAG W CC");
                    searchWords.Add("APPENDECTOMY W COMPLICATED PRINCIPAL DIAG W/O CC/MCC");
                    searchWords.Add("APPENDECTOMY W/O COMPLICATED PRINCIPAL DIAG W/O CC/MCC");
                }
                if (searchWords.Contains("ESOPHAGUS"))
                {
                    searchWords.Add("MAJOR ESOPHAGEAL DISORDERS W MCC");
                    searchWords.Add("MAJOR ESOPHAGEAL DISORDERS W CC");
                    searchWords.Add("ESOPHAGITIS, GASTROENT & MISC DIGEST DISORDERS W MCC");
                }
                if (searchWords.Contains("BOWEL"))
                {
                    searchWords.Add("G.I. OBSTRUCTION W MCC");
                    searchWords.Add("G.I. OBSTRUCTION W CC");
                    searchWords.Add("G.I. OBSTRUCTION W/O CC/MCC");
                }
                if (searchWords.Contains("INFLAMMATION"))
                {
                    searchWords.Add("ESOPHAGITIS, GASTROENT & MISC DIGEST DISORDERS W MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W/O MCC");
                }
                if (searchWords.Contains("LIVER"))
                {
                    searchWords.Add("BILIARY TRACT PROC EXCEPT ONLY CHOLECYST W OR W/O C.D.E. W MCC");
                    searchWords.Add("HEPATOBILIARY DIAGNOSTIC PROCEDURES W MCC");
                    searchWords.Add("OTHER HEPATOBILIARY OR PANCREAS O.R. PROCEDURES W MCC");
                    searchWords.Add("CIRRHOSIS & ALCOHOLIC HEPATITIS W MCC");
                    searchWords.Add("CIRRHOSIS & ALCOHOLIC HEPATITIS W CC");
                    searchWords.Add("MALIGNANCY OF HEPATOBILIARY SYSTEM OR PANCREAS W MCC");
                    searchWords.Add("MALIGNANCY OF HEPATOBILIARY SYSTEM OR PANCREAS W CC");
                    searchWords.Add("MALIGNANCY OF HEPATOBILIARY SYSTEM OR PANCREAS W/O CC/MCC");
                    searchWords.Add("DISORDERS OF THE BILIARY TRACT W MCC");
                    searchWords.Add("DISORDERS OF THE BILIARY TRACT W CC");
                    searchWords.Add("DISORDERS OF THE BILIARY TRACT W/O CC/MCC");
                }
                if (searchWords.Contains("GALLBLADDER"))
                {
                    searchWords.Add("BILIARY TRACT PROC EXCEPT ONLY CHOLECYST W OR W/O C.D.E. W MCC");
                    searchWords.Add("CHOLECYSTECTOMY EXCEPT BY LAPAROSCOPE W/O C.D.E. W MCC");
                    searchWords.Add("CHOLECYSTECTOMY EXCEPT BY LAPAROSCOPE W/O C.D.E. W CC");
                    searchWords.Add("CHOLECYSTECTOMY EXCEPT BY LAPAROSCOPE W/O C.D.E. W/O CC/MCC");
                    searchWords.Add("LAPAROSCOPIC CHOLECYSTECTOMY W/O C.D.E. W MCC");
                    searchWords.Add("LAPAROSCOPIC CHOLECYSTECTOMY W/O C.D.E. W CC");
                    searchWords.Add("LAPAROSCOPIC CHOLECYSTECTOMY W/O C.D.E. W/O CC/MCC");
                }
                if (searchWords.Contains("BILE"))
                {
                    searchWords.Add("BILIARY TRACT PROC EXCEPT ONLY CHOLECYST W OR W/O C.D.E. W MCC");
                    searchWords.Add("DISORDERS OF THE BILIARY TRACT W MCC");
                    searchWords.Add("DISORDERS OF THE BILIARY TRACT W CC");
                    searchWords.Add("DISORDERS OF THE BILIARY TRACT W/O CC/MCC");
                }
                if (searchWords.Contains("LUMBAR"))
                {
                    searchWords.Add("COMBINED ANTERIOR/POSTERIOR SPINAL FUSION W MCC");
                    searchWords.Add("COMBINED ANTERIOR/POSTERIOR SPINAL FUSION W CC");
                    searchWords.Add("COMBINED ANTERIOR/POSTERIOR SPINAL FUSION W/O CC/MCC");
                }
                if (searchWords.Contains("LEG"))
                {
                    searchWords.Add("BILATERAL OR MULTIPLE MAJOR JOINT PROCS OF LOWER EXTREMITY W/O MCC");
                    searchWords.Add("LOWER EXTREM & HUMER PROC EXCEPT HIP,FOOT,FEMUR W MCC");
                    searchWords.Add("LOWER EXTREM & HUMER PROC EXCEPT HIP,FOOT,FEMUR W CC");
                    searchWords.Add("LOWER EXTREM & HUMER PROC EXCEPT HIP,FOOT,FEMUR W/O CC/MCC");
                }
                if (searchWords.Contains("GRAFT"))
                {
                    searchWords.Add("WND DEBRID & SKN GRFT EXC HAND, FOR MUSCULO-CONN TISS DIS W MCC");
                    searchWords.Add("WND DEBRID & SKN GRFT EXC HAND, FOR MUSCULO-CONN TISS DIS W CC");
                    searchWords.Add("WND DEBRID & SKN GRFT EXC HAND, FOR MUSCULO-CONN TISS DIS W/O CC/MCC");
                }
                if (searchWords.Contains("THIGHBONE"))
                {
                    searchWords.Add("HIP & FEMUR PROCEDURES EXCEPT MAJOR JOINT W MCC");
                    searchWords.Add("HIP & FEMUR PROCEDURES EXCEPT MAJOR JOINT W CC");
                    searchWords.Add("HIP & FEMUR PROCEDURES EXCEPT MAJOR JOINT W/O CC/MCC");
                    searchWords.Add("LOCAL EXCISION & REMOVAL INT FIX DEVICES OF HIP & FEMUR W CC/MCC");
                }
                if (searchWords.Contains("BONE"))
                {
                    searchWords.Add("OSTEOMYELITIS W MCC");
                    searchWords.Add("OSTEOMYELITIS W CC");
                    searchWords.Add("MYELOPROLIF DISORD OR POORLY DIFF NEOPL W MAJ O.R. PROC W CC");
                    searchWords.Add("MYELOPROLIF DISORD OR POORLY DIFF NEOPL W MAJ O.R. PROC W/O CC/MCC");
                    searchWords.Add("MYELOPROLIFERATIVE DISORDERS OR POORLY DIFFERENTIATED NEOPLASMS W OT");
                }
                if (searchWords.Contains("JOINT"))
                {
                    searchWords.Add("BONE DISEASES & ARTHROPATHIES W/O MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W/O MCC");
                }
                if (searchWords.Contains("TENNIS"))
                {
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W/O MCC");
                }
                if (searchWords.Contains("ELBOW"))
                {
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W/O MCC");
                }
                if (searchWords.Contains("MUSCLE"))
                {
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W MCC");
                    searchWords.Add("TENDONITIS, MYOSITIS & BURSITIS W/O MCC");
                    searchWords.Add("BENIGN PROSTATIC HYPERTROPHY W/O MCC");
                }
                if (searchWords.Contains("WOUND"))
                {
                    searchWords.Add("SKIN DEBRIDEMENT W MCC");
                    searchWords.Add("SKIN DEBRIDEMENT W CC");
                }
                if (searchWords.Contains("HYPODERMIS"))
                {
                    searchWords.Add("OTHER SKIN, SUBCUT TISS & BREAST PROC W/O CC/MCC");
                    searchWords.Add("TRAUMA TO THE SKIN, SUBCUT TISS & BREAST W MCC");
                    searchWords.Add("TRAUMA TO THE SKIN, SUBCUT TISS & BREAST W/O MCC");
                }
                if (searchWords.Contains("KIDNEY"))
                {
                    searchWords.Add("ADRENAL & PITUITARY PROCEDURES W CC/MCC");
                    searchWords.Add("ADRENAL & PITUITARY PROCEDURES W/O CC/MCC");
                    searchWords.Add("RENAL FAILURE W MCC");
                    searchWords.Add("RENAL FAILURE W CC");
                    searchWords.Add("RENAL FAILURE W/O CC/MCC");
                    searchWords.Add("URINARY STONES W/O ESW LITHOTRIPSY W MCC");
                    searchWords.Add("URINARY STONES W/O ESW LITHOTRIPSY W/O MCC");
                }
                if (searchWords.Contains("SISTRUNK"))
                {
                    searchWords.Add("THYROID, PARATHYROID & THYROGLOSSAL PROCEDURES W CC");
                    searchWords.Add("THYROID, PARATHYROID & THYROGLOSSAL PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("HORMONES"))
                {
                    searchWords.Add("OTHER ENDOCRINE, NUTRIT & METAB O.R. PROC W CC");
                    searchWords.Add("ENDOCRINE DISORDERS W MCC");
                    searchWords.Add("ENDOCRINE DISORDERS W CC");
                    searchWords.Add("ENDOCRINE DISORDERS W/O CC/MCC");
                }
                if (searchWords.Contains("PROSTATIC"))
                {
                    searchWords.Add("TRANSURETHRAL PROCEDURES W MCC");
                    searchWords.Add("TRANSURETHRAL PROCEDURES W CC");
                    searchWords.Add("TRANSURETHRAL PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("HYPERPLASIA"))
                {
                    searchWords.Add("TRANSURETHRAL PROCEDURES W MCC");
                    searchWords.Add("TRANSURETHRAL PROCEDURES W CC");
                    searchWords.Add("TRANSURETHRAL PROCEDURES W/O CC/MCC");
                }
                if (searchWords.Contains("GROWTH"))
                {
                    searchWords.Add("BENIGN PROSTATIC HYPERTROPHY W/O MCC");
                }
                if (searchWords.Contains("WOMB"))
                {
                    searchWords.Add("PELVIC EVISCERATION, RAD HYSTERECTOMY & RAD VULVECTOMY W CC/MCC");
                    searchWords.Add("PELVIC EVISCERATION, RAD HYSTERECTOMY & RAD VULVECTOMY W/O CC/MCC");
                    searchWords.Add("UTERINE & ADNEXA PROC FOR OVARIAN OR ADNEXAL MALIGNANCY W MCC");
                    searchWords.Add("UTERINE & ADNEXA PROC FOR OVARIAN OR ADNEXAL MALIGNANCY W CC");
                    searchWords.Add("UTERINE,ADNEXA PROC FOR NON-OVARIAN/ADNEXAL MALIG W CC");
                    searchWords.Add("UTERINE,ADNEXA PROC FOR NON-OVARIAN/ADNEXAL MALIG W/O CC/MCC");
                    searchWords.Add("UTERINE & ADNEXA PROC FOR NON-MALIGNANCY W CC/MCC");
                    searchWords.Add("UTERINE & ADNEXA PROC FOR NON-MALIGNANCY W/O CC/MCC");
                }
                if (searchWords.Contains("BIOPSY"))
                {
                    searchWords.Add("D&C, CONIZATION, LAPAROSCOPY & TUBAL INTERRUPTION W CC/MCC");
                }
                if (searchWords.Contains("VULVA"))
                {
                    searchWords.Add("PELVIC EVISCERATION, RAD HYSTERECTOMY & RAD VULVECTOMY W CC/MCC");
                    searchWords.Add("PELVIC EVISCERATION, RAD HYSTERECTOMY & RAD VULVECTOMY W/O CC/MCC");
                }
                if (searchWords.Contains("PERIOD"))
                {
                    searchWords.Add("MENSTRUAL & OTHER FEMALE REPRODUCTIVE SYSTEM DISORDERS W CC/MCC");
                }
                if (searchWords.Contains("C-SECTION"))
                {
                    searchWords.Add("CESAREAN SECTION W CC/MCC");
                    searchWords.Add("CESAREAN SECTION W/O CC/MCC");
                }
                if (searchWords.Contains("BIRTH"))
                {
                    searchWords.Add("VAGINAL DELIVERY W COMPLICATING DIAGNOSES");
                    searchWords.Add("VAGINAL DELIVERY W/O COMPLICATING DIAGNOSES");
                    searchWords.Add("OTHER ANTEPARTUM DIAGNOSES W MEDICAL COMPLICATIONS");
                }
                if (searchWords.Contains("PREGNANCY"))
                {
                    searchWords.Add("VAGINAL DELIVERY W COMPLICATING DIAGNOSES");
                    searchWords.Add("VAGINAL DELIVERY W/O COMPLICATING DIAGNOSES");
                }
                if (searchWords.Contains("CLOTTING"))
                {
                    searchWords.Add("COAGULATION DISORDERS");
                }
                if (searchWords.Contains("RES"))
                {
                    searchWords.Add("RETICULOENDOTHELIAL & IMMUNITY DISORDERS W MCC");
                    searchWords.Add("RETICULOENDOTHELIAL & IMMUNITY DISORDERS W CC");
                    searchWords.Add("RETICULOENDOTHELIAL & IMMUNITY DISORDERS W/O CC/MCC");
                }
                if (searchWords.Contains("CANCER"))
                {
                    searchWords.Add("DIGESTIVE MALIGNANCY W MCC");
                    searchWords.Add("DIGESTIVE MALIGNANCY W CC");
                    searchWords.Add("MALIGNANT BREAST DISORDERS W MCC");
                    searchWords.Add("MALIGNANT BREAST DISORDERS W CC");
                    searchWords.Add("LYMPHOMA & LEUKEMIA W MAJOR O.R. PROCEDURE W MCC");
                    searchWords.Add("LYMPHOMA & LEUKEMIA W MAJOR O.R. PROCEDURE W CC");
                    searchWords.Add("LYMPHOMA & LEUKEMIA W MAJOR O.R. PROCEDURE W/O CC/MCC");
                    searchWords.Add("LYMPHOMA & NON-ACUTE LEUKEMIA W OTHER PROC W MCC");
                    searchWords.Add("LYMPHOMA & NON-ACUTE LEUKEMIA W OTHER O.R. PROC W CC");
                    searchWords.Add("ACUTE LEUKEMIA W/O MAJOR O.R. PROCEDURE W MCC");
                    searchWords.Add("ACUTE LEUKEMIA W/O MAJOR O.R. PROCEDURE W CC");
                    searchWords.Add("CHEMO W ACUTE LEUKEMIA AS SDX OR W HIGH DOSE CHEMO AGENT W MCC");
                    searchWords.Add("CHEMO W ACUTE LEUKEMIA AS SDX W CC OR HIGH DOSE CHEMO AGENT");
                    searchWords.Add("CHEMO W ACUTE LEUKEMIA AS SDX W/O CC/MCC");
                    searchWords.Add("LYMPHOMA & NON-ACUTE LEUKEMIA W MCC");
                    searchWords.Add("LYMPHOMA & NON-ACUTE LEUKEMIA W CC");
                    searchWords.Add("LYMPHOMA & NON-ACUTE LEUKEMIA W/O CC/MCC");
                    searchWords.Add("OTHER MYELOPROLIF DIS OR POORLY DIFF NEOPL DIAG W MCC");
                    searchWords.Add("OTHER MYELOPROLIF DIS OR POORLY DIFF NEOPL DIAG W CC");
                    searchWords.Add("CHEMOTHERAPY W/O ACUTE LEUKEMIA AS SECONDARY DIAGNOSIS W MCC");
                    searchWords.Add("CHEMOTHERAPY W/O ACUTE LEUKEMIA AS SECONDARY DIAGNOSIS W CC");
                    searchWords.Add("849 - RADIOTHERAPY");
                }
                if (searchWords.Contains("PARASITE"))
                {
                    searchWords.Add("INFECTIOUS & PARASITIC DISEASES W O.R. PROCEDURE W MCC");
                    searchWords.Add("INFECTIOUS & PARASITIC DISEASES W O.R. PROCEDURE W CC");
                }
                if (searchWords.Contains("VIRUS"))
                {
                    searchWords.Add("VIRAL ILLNESS W MCC");
                    searchWords.Add("VIRAL ILLNESS W/O MCC");
                }
                if (searchWords.Contains("POISONING"))
                {
                    searchWords.Add("SEPTICEMIA OR SEVERE SEPSIS W MV >96 HOURS");
                    searchWords.Add("SEPTICEMIA OR SEVERE SEPSIS W/O MV >96 HOURS W MCC");
                    searchWords.Add("SEPTICEMIA OR SEVERE SEPSIS W/O MV >96 HOURS W/O MCC");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE, LEFT AMA");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE W REHABILITATION THERAPY");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE W/O ");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE W/O REHABILITATION THERAPY W/O MCC");
                }
                if (searchWords.Contains("MENTAL"))
                {
                    searchWords.Add("ACUTE ADJUSTMENT REACTION & PSYCHOSOCIAL DYSFUNCTION");
                    searchWords.Add("DEPRESSIVE NEUROSES");
                    searchWords.Add("NEUROSES EXCEPT DEPRESSIVE");
                    searchWords.Add("DISORDERS OF PERSONALITY & IMPULSE CONTROL");
                    searchWords.Add("ORGANIC DISTURBANCES & INTELLECTUAL DISABILITY");
                    searchWords.Add("PSYCHOSES");
                }
                if (searchWords.Contains("CRAZY"))
                {
                    searchWords.Add("O.R. PROCEDURE W PRINCIPAL DIAGNOSES OF MENTAL ILLNESS");
                    searchWords.Add("ACUTE ADJUSTMENT REACTION & PSYCHOSOCIAL DYSFUNCTION");
                    searchWords.Add("DEPRESSIVE NEUROSES");
                    searchWords.Add("NEUROSES EXCEPT DEPRESSIVE");
                    searchWords.Add("DISORDERS OF PERSONALITY & IMPULSE CONTROL");
                    searchWords.Add("ORGANIC DISTURBANCES & INTELLECTUAL DISABILITY");
                    searchWords.Add("PSYCHOSES");
                    searchWords.Add("OTHER MENTAL DISORDER DIAGNOSES");
                }
                if (searchWords.Contains("INSANE"))
                {
                    searchWords.Add("DEPRESSIVE NEUROSES");
                    searchWords.Add("NEUROSES EXCEPT DEPRESSIVE");
                    searchWords.Add("DISORDERS OF PERSONALITY & IMPULSE CONTROL");
                    searchWords.Add("ORGANIC DISTURBANCES & INTELLECTUAL DISABILITY");
                    searchWords.Add("PSYCHOSES");
                    searchWords.Add("OTHER MENTAL DISORDER DIAGNOSES");
                }
                if (searchWords.Contains("SOCIAL"))
                {
                    searchWords.Add("ACUTE ADJUSTMENT REACTION & PSYCHOSOCIAL DYSFUNCTION");
                }
                if (searchWords.Contains("DEPRESSION"))
                {
                    searchWords.Add("DEPRESSIVE NEUROSES");
                }
                if (searchWords.Contains("STRESS"))
                {
                    searchWords.Add("DEPRESSIVE NEUROSES");
                    searchWords.Add("NEUROSES EXCEPT DEPRESSIVE");
                }
                if (searchWords.Contains("ANXIETY"))
                {
                    searchWords.Add("DEPRESSIVE NEUROSES");
                    searchWords.Add("NEUROSES EXCEPT DEPRESSIVE");
                }
                if (searchWords.Contains("OBSESSIVE"))
                {
                    searchWords.Add("DEPRESSIVE NEUROSES");
                    searchWords.Add("NEUROSES EXCEPT DEPRESSIVE");
                }
                if (searchWords.Contains("DRUNK"))
                {
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE, LEFT AMA");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE W REHABILITATION THERAPY");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE W/O REHABILITATION THERAPY W MCC");
                    searchWords.Add("ALCOHOL/DRUG ABUSE OR DEPENDENCE W/O REHABILITATION THERAPY W/O MCC");
                }
                if (searchWords.Contains("ALLERGY"))
                {
                    searchWords.Add("ALLERGIC REACTIONS W/O MCC");
                }

                foreach (var line in lines)
                {
                    string[] fields = line.Split('\t');
                    string procedureFromFile = fields[0];
                    procedureFromFile = procedureFromFile.Replace("\"", "");
                    int count = 0;
                    foreach (string word in searchWords)
                    {
                        if (word.Length > 2)
                        {
                            if (procedureFromFile.Contains(word))
                            {
                                count++;
                            }
                        }
                    }
                    if (count == (searchWords.Count()))
                    {
                        for (int i = 0; i < fields.Count(); i++)
                        {
                            fields[i] = fields[i].Replace(@"\", @"\\");
                        }
                        listOfOptions.Add(fields);
                    }
                }
            }
            //searches for each word
            if (listOfOptions.Count == 0)
            {
                foreach (var line in lines)
                {
                    string[] fields = line.Split('\t');
                    string procedureFromFile = fields[0];
                    procedureFromFile = procedureFromFile.Replace("\"", "");
                    int count = 0;
                    foreach (string word in searchWords)
                    {
                        if (word.Length > 2)
                        {
                            if (procedureFromFile.Contains(word))
                            {
                                count++;
                            }
                        }
                    }
                    if (count >= 1)
                    {
                        for (int i = 0; i < fields.Count(); i++)
                        {
                            fields[i] = fields[i].Replace(@"\", @"\\");
                        }
                        listOfOptions.Add(fields);
                    }
                }
            }
            //checks if only one procedure is found
            string code = listOfOptions[0][0].Split(' ')[0];
            bool check = true;
            for (var i = 0; i < listOfOptions.Count; i++)
            {
                if (!listOfOptions[i][0].Split(' ')[0].Equals(code))
                {
                    check = false;
                }
            }
            
            if (check == true)
            {
                List<String[]> previous = new List<string[]>();
                for (var i = listOfOptions.Count - 1; i >= 0; i--)
                {
                    foreach (string[] row in previous)
                    {
                        if (listOfOptions[i][2].Equals(row[2]))
                        {
                            listOfOptions.RemoveAt(i);
                        }
                    }

                    previous.Add(listOfOptions[i]);
                }
                return listOfOptions;
            }
            else
            {
                List<string[]> temp = new List<string[]>();
                foreach (string[] option in listOfOptions)
                {
                    temp.Add(option);
                }
                listOfOptions.Clear();
                String previous2 = "";

                for (var i = 0; i < temp.Count; i++)
                {
                    string[] test = new string[1] { temp[i][0] };
                    if (!temp[i][0].Equals(previous2))
                    {
                        listOfOptions.Add(test);
                    }
                    previous2 = temp[i][0];
                }
                return listOfOptions;
            }
        }
        //Function to sort list of details by price
        public List<string[]> sortByPrice(List<string[]> detailList)
		{
			detailList = detailList.OrderBy(arr => Decimal.Parse(arr[10])).ToList();//.ThenBy(arr => Decimal.Parse(arr[10])).ToList();


			if (detailList.Count > 10)
			{
				detailList.RemoveRange(10, detailList.Count-10);
			}

			return detailList;
		}
        //Function to sort the list of details by distance
        public List<string[]> sortByDistance(List<string[]> detailList)
        {
            detailList = detailList.OrderBy(arr => Double.Parse(arr[12])).ToList();

            if (detailList.Count > 10)
            {
                detailList.RemoveRange(10, detailList.Count - 10);
            }

            return detailList;
        }

        
        public List<double>  sortDistanceList(List<double> distanceList)
        {
            distanceList = distanceList.OrderBy(arr => arr).ToList();

            if (distanceList.Count > 10)
            {
                distanceList.RemoveRange(10, distanceList.Count - 10);
            }

            return distanceList;
        }

        public bool validateUserInput(string userInput)
		{
			if (userInput.Length != 3)
			{
				Console.WriteLine("Please enter a three digit number.");
				//for dev purposes only
                //MessageBox.Show("ERROR: Incorrect input");
				return false;
			}
			else if (!userInput.All(char.IsDigit))
			{
				Console.WriteLine("Please enter a three digit number.");
                //for dev purposes only
                //MessageBox.Show("ERROR: Incorrect input");
                return false;
			}
			else
			{
				return true;
			}
		}

        //function to check if string only contains numbers
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

        //function for detecting special characters
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

        //checks to see if zipcode matches state
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



        //function to check if zipcode is valid
		public bool checkZip(string zip)
		{
			if (zip.Length != 5)
			{
				return false;
			}
			if (containsnumbers(zip) != true)
			{
				return false;
			}
			return true;
		}

        //function to check if state postal code is valid
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

        private void Form1_searchandhistory_Load(object sender, EventArgs e)
        {

        }
    }
}
