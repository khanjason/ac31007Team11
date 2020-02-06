using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WindowsFormsApp0203
{
	public class Testing
	{
		Form1_searchandhistory frm1 = new Form1_searchandhistory();

		[Fact]
		public void testSearchComponentExistence()
		{
			Assert.NotNull(frm1.txtProcedure);
			Assert.NotNull(frm1.btnClosePage1);
			Assert.NotNull(frm1.btnContPage1);
			Assert.NotNull(frm1.trbPrice);
		}

		[Fact]
		public void testHospitalRoutesAdded()
		{
			bool valid = frm1.validateUserInput("501");
			int expected = 0;
			frm1.setPriceMax(10000);
			if (valid)
			{
				frm1.hospitalDetailsList = frm1.searchByCode("501");
				frm1.hospitalDetailsList = frm1.checkRange(frm1.hospitalDetailsList);
				frm1.hospitalDetailsList = frm1.sortByPrice(frm1.hospitalDetailsList);
			}
			expected = frm1.hospitalDetailsList.Count;

			GMapProviders.GoogleMap.ApiKey = @"AIzaSyCgfKNFVdWfjXpEu29xUEjfekPIKBiHf1E";

			frm1.Hide();//然后关闭.
			Form2_map frm2 = new Form2_map();//实例化第二个窗体.
			frm2.Show();//然后显示出来.
			frm2.mapWindow.MapProvider = GMapProviders.GoogleMap;

			int actual = 0;
			GMap.NET.GeoCoderStatusCode statusCode;
			var pointLatLng = GoogleMapProvider.Instance.GetPoint("90210,CA", out frm1.statusCode);

			//if (frm1.statusCode == GeoCoderStatusCode.OK)
			{
				var location = frm1.createPoint(pointLatLng.Value.Lat, pointLatLng.Value.Lng);
				frm1.setMapPosition(location, frm2);
				frm1.placeMarker(location, frm2);
				frm1.addPointToList(location);
				frm1.createHospitalRoutes(location, frm2);
			}

			actual = frm1.pointsList.Count - 1;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void testHospitalListCreated()
		{
			bool valid = frm1.validateUserInput("501");
			int expected = 4;
			frm1.setPriceMax(10000);
			if (valid)
			{
				frm1.hospitalDetailsList = frm1.searchByCode("501");
				frm1.hospitalDetailsList = frm1.checkRange(frm1.hospitalDetailsList);
				frm1.hospitalDetailsList = frm1.sortByPrice(frm1.hospitalDetailsList);
			}
			int actual = frm1.hospitalDetailsList.Count;

			Assert.Equal(expected, actual);
		}
	}
}
