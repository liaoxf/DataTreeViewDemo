
namespace DataTreeViewDemo.Models {
    public class Vehicle {
        public Vehicle(string make, string model, string variant, string power, string fuel, string usd, string category) {
            this.Make = make;
            this.Model = model;
            this.Variant = variant;
            this.Power = power;
            this.Fuel = fuel;
            this.USD = usd;
            this.Category = category;
        }

        public Vehicle() {
        }

        public string Make {
            get;
            set;
        }
        public string Model {
            get;
            set;
        }
        public string Variant {
            get;
            set;
        }
        public string Power {
            get;
            set;
        }
        public string Fuel {
            get;
            set;
        }
        public string USD {
            get;
            set;
        }
        public string Category {
            get;
            set;
        }
    }
}
