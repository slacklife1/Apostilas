using System;
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//:::                                                                         :::
//:::  This routine calculates the distance between two points (given the     :::
//:::  latitude/longitude of those points). It is being used to calculate     :::
//:::  the distance between two ZIP Codes or Postal Codes using our           :::
//:::  ZIPCodeWorld(TM) and PostalCodeWorld(TM) products.                     :::
//:::                                                                         :::
//:::  Definitions:                                                           :::
//:::    South latitudes are negative, east longitudes are positive           :::
//:::                                                                         :::
//:::  Passed to function:                                                    :::
//:::    lat1, lon1 = Latitude and Longitude of point 1 (in decimal degrees)  :::
//:::    lat2, lon2 = Latitude and Longitude of point 2 (in decimal degrees)  :::
//:::    unit = the unit you desire for results                               :::
//:::           where: 'M' is statute miles                                   :::
//:::                  'K' is kilometers (default)                            :::
//:::                  'N' is nautical miles                                  :::
//:::                                                                         :::
//:::  United States ZIP Code/ Canadian Postal Code databases with latitude   :::
//:::  & longitude are available at http://www.zipcodeworld.com               :::
//:::                                                                         :::
//:::  For enquiries, please contact sales@zipcodeworld.com                   :::
//:::                                                                         :::
//:::  Official Web site: http://www.zipcodeworld.com                         :::
//:::                                                                         :::
//:::  Hexa Software Development Center � All Rights Reserved 2004            :::
//:::                                                                         :::
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
private double distance(double lat1, double lon1, double lat2, double lon2, char unit) {
  double theta = lon1 - lon2;
  double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
  dist = Math.Acos(dist);
  dist = rad2deg(dist);
  dist = dist * 60 * 1.1515;
  if (unit == 'K') {
    dist = dist * 1.609344;
  } else if (unit == 'N') {
  	dist = dist * 0.8684;
    }
  return (dist);
}

//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//::  This function converts decimal degrees to radians             :::
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
private double deg2rad(double deg) {
  return (deg * Math.PI / 180.0);
}

//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//::  This function converts radians to decimal degrees             :::
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
private double rad2deg(double rad) {
  return (rad / Math.PI * 180.0);
}

Console.WriteLine(distance(32.9697, -96.80322, 29.46786, -98.53506, "M"));
Console.WriteLine(distance(32.9697, -96.80322, 29.46786, -98.53506, "K"));
Console.WriteLine(distance(32.9697, -96.80322, 29.46786, -98.53506, "N"));