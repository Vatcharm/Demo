using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo {
    public class DeviceItem : Device {
        public string Name { get; set; }
        public int Watts { get; set; }
        public double HoursPerDay { get; set; }
        public double DaysPerMonth { get; set; }

        public override double UnitsPerMonth {
            get {
                // throw new NotImplementedException();  //not coding yet
                if(Watts < 0 || HoursPerDay < 0 || DaysPerMonth < 0) {
                    throw new Exception("Invalid data.");
                    }
                var units = (Watts * HoursPerDay * DaysPerMonth) / 1000;
                return units;
                }
            }
        }
    }
