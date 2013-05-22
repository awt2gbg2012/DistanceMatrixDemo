using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DistanceMatrixDemo.Models
{
    public class DistanceMatrixResult
    {
        public List<String> destination_addresses {get;set;}
        public List<String> origin_addresses {get; set;}
        public List<DistanceMatrixRow> rows { get;set;}
        public string status { get; set; }
    }

    public class DistanceMatrixRow
    {
        public List<DistanceMatrixElement> elements { get; set; }
    }

    public class DistanceMatrixElement
    {
        public DistanceMatrixDistance distance { get; set; }
        public DistanceMatrixDuration duration { get; set; }
        public String status { get; set; }
    }

    public class DistanceMatrixDistance
    {
        public int value { get; set; }
        public string text { get; set; }
    }

    public class DistanceMatrixDuration
    {
        public int value { get; set; }
        public string text { get; set; }
    }

    public class DistanceMatrix
    {
        public static List<string> DeserializeDistanceMatrixTest()
        {
            string json = @"{
   'destination_addresses' : [ 'San Francisco, Californie, États-Unis', 'Victoria, BC, Canada' ],
   'origin_addresses' : [ 'Vancouver, BC, Canada', 'Seattle, État de Washington, États-Unis' ],
   'rows' : [
      {
         'elements' : [
            {
               'distance' : {
                  'text' : '1 681 km',
                  'value' : 1680725
               },
               'duration' : {
                  'text' : '3 jours 20 heures',
                  'value' : 332484
               },
               'status' : 'OK'
            },
            {
               'distance' : {
                  'text' : '135 km',
                  'value' : 134542
               },
               'duration' : {
                  'text' : '6 heures 37 minutes',
                  'value' : 23835
               },
               'status' : 'OK'
            }
         ]
      },
      {
         'elements' : [
            {
               'distance' : {
                  'text' : '1 431 km',
                  'value' : 1430798
               },
               'duration' : {
                  'text' : '3 jours 6 heures',
                  'value' : 281889
               },
               'status' : 'OK'
            },
            {
               'distance' : {
                  'text' : '146 km',
                  'value' : 146291
               },
               'duration' : {
                  'text' : '3 heures 12 minutes',
                  'value' : 11502
               },
               'status' : 'OK'
            }
         ]
      }
   ],
   'status' : 'OK'
}
";

            DistanceMatrixResult distanceMatrixData = new JavaScriptSerializer()
                          .Deserialize<DistanceMatrixResult>(json);

            List<string> routes = new List<string>();
            string origin;
            for (int originIndex = 0;
                originIndex < distanceMatrixData.origin_addresses.Count;
                originIndex++)
            {
                origin = distanceMatrixData.origin_addresses[originIndex];
                for (int destinationIndex = 0;
                    destinationIndex < distanceMatrixData.destination_addresses.Count;
                    destinationIndex++)
                {
                    routes.Add(string.Format("From: {0} To: {1} Distance: {2}"
                       , origin
                       , distanceMatrixData.destination_addresses[destinationIndex]
                       , distanceMatrixData
                            .rows[originIndex]
                            .elements[destinationIndex]
                            .distance
                            .text
                    ));
                }
            }

            return routes;
        }

    }
}