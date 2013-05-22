using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}