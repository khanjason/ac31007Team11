using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAndDistanceRange
{
    public class RangeManager
    {
        //Absolute minimum and maximum range of values
        private double priceFloor = 0;
        private double priceCeiling = 999999;
        private double distFloor = 0;
        private double distCeiling = 4000;

        //Active minimum and maximum range of values for searching
        private double priceMin;
        private double priceMax;
        private double distMin;
        private double distMax;

         
        /// <summary>
        /// Constructor which takes in default values for range
        /// </summary>
        /// <param name="pMin">The minimum value for the price</param>
        /// <param name="pMax">The maximum value for the price</param>
        /// <param name="dMin">The minimum value for the distance</param>
        /// <param name="dMax">The maximum value for the distance</param>
        public RangeManager(double pMin, double pMax, double dMin, double dMax)
        {
            setAllRange(pMin, pMax, dMin, dMax);
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


        /// <summary>
        /// A ToString() override that concatonates the minimum and maximum values for the price and distance ranges
        /// </summary>
        /// <returns>The minimum and maximum values for price and distance, comma seperated</returns>
        public override string ToString()
        {
            return priceMin + "," + priceMax + "," + distMin + "," + distMax;
        }
    }
}
