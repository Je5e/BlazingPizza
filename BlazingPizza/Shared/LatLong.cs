using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BlazingPizza.Shared
{
   public class LatLong
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public LatLong(double latitude,double longitude):base()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public LatLong()
        {

        }

        public static LatLong Interpolate(LatLong start,LatLong end,double proportion)
        {
            return new LatLong(start.Latitude + (end.Latitude - start.Latitude) * proportion,
                start.Longitude + (end.Longitude - start.Longitude) * proportion);
        }
    }
}
