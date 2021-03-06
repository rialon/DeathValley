﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeathValley.Models {

    public class Chart {

        [Required(ErrorMessage = "Please enter coefficient A")]
        public int CoefficientA { get; set; }
        [Required(ErrorMessage = "Please enter coefficient B")]
        public int CoefficientB { get; set; }
        [Required(ErrorMessage = "Please enter coefficient C")]
        public int CoefficientC { get; set; }

        [Required(ErrorMessage = "Please enter step value")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive step (greater than 0.0001)")]
        public double Step { get; set; }

        [Required(ErrorMessage = "Please enter lower limit")]
        public int LowerLimit { get; set; }
        [Required(ErrorMessage = "Please enter higher limit")]
        public int HigherLimit { get; set; }

        public List<Point> Points { get; set; }

        public struct Point {
            public double X { get; set; }
            public double Y { get; set; }
        }
    }
}