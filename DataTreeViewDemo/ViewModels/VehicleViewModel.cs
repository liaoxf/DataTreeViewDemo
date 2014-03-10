using System.Collections.Generic;
using DataTreeViewDemo.Models;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.ViewModels {
    public class VehicleViewModel : ViewModelBase {
        public static List<Vehicle> GetSampleListOfVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>
			              	{
								new Vehicle("AA Romeo","159","Sportwagon","88 kW (120 PS)","Diesel","18000","QQ"),
								new Vehicle("AA","A4 ","Avant","88 kW (120 PS)","Petrol","26649","QQ"),
								new Vehicle("BB","318i","Touring","105 kW (143 PS)","Petrol","26890","QQ"),
								new Vehicle("BB","MUSA","Gold","70 kW (95 PS)","Petrol","18990","Estate Cars"),
								new Vehicle("CC","Focus","CV 115","85 kW (116 PS)","Diesel","9900","Estate Cars"),
								new Vehicle("CC-Benz","C200","CDI","100 kW (136 PS)","Diesel","28645","Estate Cars"),
								new Vehicle("CC","Veyron","","736 kW (1001 PS)","Petrol","1290000","瑞虎"),
								new Vehicle("DD","C6","HDi 240","177 kW (241 PS)","Petrol","47990","瑞虎"),
								new Vehicle("DD","F430","SCUDERIA","375 kW (510 PS)","Petrol","215000","瑞虎"),
								new Vehicle("DD","S80","D5","158 kW (215 PS)","Diesel","53715","Limousine"),
								new Vehicle("DD","Gallardo","LP550-2","405 kW (551 PS)","Petrol","166450","Sport Cars"),
								new Vehicle("AA","Acura","MDX","94 kW (128 PS)","Petrol","31800","Sport Cars"),
								new Vehicle("BB","RCZ","HDi FAP 165","120 kW (163 PS)","Diesel","33990","Sport Cars"),
								new Vehicle("BB","Lancer","Evolution","217 kW(295 PS)","Petrol","35839","Sport Cars"),
								new Vehicle("CC Martin","V8","Vantage","313 kW (426 PS)","Petrol","99900","Sport Cars"),
								new Vehicle("CC","MP4-12C","","441 kW (600 PS)","Petrol","259900","Sport Cars"),
			              	};

            return vehicles;
        }

        private List<Vehicle> _sampleList;

        public List<Vehicle> SampleList {
            get {
                if(this._sampleList == null) {
                    this._sampleList = GetSampleListOfVehicles();
                }

                return this._sampleList;
            }
        }
    }
}
