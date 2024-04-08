using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagsDemo.Core.Entities.Weather
{
    public class Condition
    {
        public string Text { get; set; }

        public string Icon { get; set; }

        public int Code { get; set; }
    }
}
