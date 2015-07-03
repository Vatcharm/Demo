using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Should;

namespace Demo {
    public class Demo2Fixture {
        public DeviceGroup House { get; set; }

        public Demo2Fixture() {
            House = new DeviceGroup();
            }

        }
    public class Demo2 : IClassFixture<Demo2Fixture> {
        private Demo2Fixture fixture;

        public Demo2(Demo2Fixture fixture) {
            this.fixture = fixture;
            fixture.House.Children.Clear();
            }

        [Fact]
        public void Test1() {
            var d = new DeviceItem();
            d.Name = "Lamp";
            d.Watts = 20;
            d.HoursPerDay = 6;
            d.DaysPerMonth = 30;

            fixture.House.Children.Add(d);

            Assert.Equal(1,fixture.House.Children.Count);
            }

        [Fact]
        public void Test2() {
            var d = new DeviceItem();
            d.Name = "Lamp";
            d.Watts = 20;
            d.HoursPerDay = 6;
            d.DaysPerMonth = 30;

            fixture.House.Children.Add(d);

            Assert.Equal(1,fixture.House.Children.Count);
            }
        }
    }
