using System;
using System.Device.Location;

namespace LiveLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            GetLocationProperty();
        }

        static void GetLocationProperty()
        {
            GeoCoordinateWatcher watcher;
            watcher = new GeoCoordinateWatcher();

            watcher.PositionChanged += (sender, e) =>
            {
                var coordinate = e.Position.Location;
                Console.WriteLine("Latitude: {0}, Longtitude: {1}", coordinate.Latitude, coordinate.Longitude);
                //One Event
                watcher.Stop();
            };

            // Listening for location updates
            watcher.Start();
            Console.ReadLine();
        }
    }
}