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

    public class DistanceMatrix
    {
    }
}