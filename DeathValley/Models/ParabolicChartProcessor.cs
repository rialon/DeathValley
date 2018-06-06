using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeathValley.Models.Abstract;
using Newtonsoft.Json;

namespace DeathValley.Models {

    public class ParabolicChartProcessor : IChartProcessor {

        public void SetChartPoints(Chart chart) {
            var _points = new List<Chart.Point>();
            for(int i = chart.LowerLimit; i <= chart.HigherLimit; i+=chart.Step) {
                _points.Add(new Chart.Point { X = i, Y = chart.CoefficientA * i * i + chart.CoefficientB * i + chart.CoefficientC });
            }
            chart.Points = _points;
        }
    }
}