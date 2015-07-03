using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo {
    public class DeviceGroup : Device {

        public ICollection<Device> Children { get; set; }

        public override double UnitsPerMonth {
            get {
                return this.Children.Sum(x => x.UnitsPerMonth);
                }
            }

        public DeviceGroup() {
            Children = new List<Device>();
            }

        }
    }
