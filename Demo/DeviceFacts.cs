using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions; //*
using Should;

namespace Demo {
    public class DeviceFacts {

        public class TheUnitsPerMonthProperty {
            private readonly ITestOutputHelper output;
            public TheUnitsPerMonthProperty(ITestOutputHelper output) {
                this.output = output;
                }
            [Fact]
            public void MyNotebook() {
                var d = new DeviceItem();
                d.Name = "Notebook";
                d.Watts = 65;
                d.HoursPerDay = 10;
                d.DaysPerMonth = 20;

                var units = d.UnitsPerMonth;
                units.ShouldEqual(13.0);
                //   Assert.Equal(13.0,units);

                }

            [Fact]
            public void MyTV() {
                var d = new DeviceItem();
                d.Name = "TV";
                d.Watts = 1000;
                d.HoursPerDay = 2;
                d.DaysPerMonth = 30;

                var units = d.UnitsPerMonth;

                Assert.Equal(60.0,units);

                }

            [Fact]
            public void AllSupportiveDataShouldNotBeNagative() {
                var d = new DeviceItem();
                d.Name = "TV";
                d.Watts = -1000;
                d.HoursPerDay = -2;
                d.DaysPerMonth = 30;

                var ex = Assert.ThrowsAny<Exception>(() => {
                    var units = d.UnitsPerMonth;
                });

                Assert.Equal("Invalid data.",ex.Message);
                }
            [Fact]
            public void NewDeviceGroup_ShouldBeEmpty() {
                var g1 = new DeviceGroup();

                Assert.Equal(0,g1.Children.Count);
                }

            [Fact]
            public void OneDeviceInTheGroup() {
                var g = new DeviceGroup();
                var d = new DeviceItem();
                d.Watts = 65;
                d.HoursPerDay = 10;
                d.DaysPerMonth = 20;

                g.Children.Add(d);

                Assert.Equal(1,g.Children.Count);
                Assert.Equal(13.0,g.UnitsPerMonth);
                }

            [Fact]
            public void AllowToAddSameObjectMultipleTimesInTheGroup() {
                var g = new DeviceGroup();
                var d = new DeviceItem();
                d.Watts = 65;
                d.HoursPerDay = 10;
                d.DaysPerMonth = 20;

                g.Children.Add(d);
                g.Children.Add(d);  // second notebook

                Assert.Equal(2,g.Children.Count);
                Assert.Equal(26.0,g.UnitsPerMonth);

                }
            private void listItems(DeviceGroup g) {
                foreach(var d in g.Children.OfType<DeviceItem>()) {
                    output.WriteLine("{0} {1} watts x {2} hours = {3} units",
                        d.Name,d.Watts,d.HoursPerDay * d.DaysPerMonth,d.UnitsPerMonth);
                    }
                //foreach(var d in g.Children.OfType()) {
                //    output.WriteLine("{0} {1} watts x {2} hours = {3} units",
                //      d.Name,d.Watts,d.HoursPerDay * d.DaysPerMonth,d.UnitsPerMonth);
                //    }
                }

            }
        }
    }
