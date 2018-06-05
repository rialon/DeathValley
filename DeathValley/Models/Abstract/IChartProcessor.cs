using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.Models;

namespace DeathValley.Models.Abstract {

    public interface IChartProcessor {

        void SetChartPoints(Chart chart);
    }
}
