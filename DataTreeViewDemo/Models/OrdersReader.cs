
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
namespace DataTreeViewDemo.Models {
    public class OrdersReader : IEnumerable<Order> {
        private Uri _UriSource;

        public OrdersReader() {
            this.UriSource = new Uri("/DataTreeViewDemo;component/Models/Orders01.txt", UriKind.RelativeOrAbsolute);
        }

        public Uri UriSource {
            get {
                return this._UriSource;
            }
            set {
                if(this._UriSource != value) {
                    this._UriSource = value;
                }
            }
        }

        public IEnumerator<Order> GetEnumerator() {
            //StreamResourceInfo sri = null;
            //try {
            //    sri = Application.GetResourceStream(this.UriSource);
            //} catch(Exception) {
            //}

            //if(sri != null && sri.Stream != null) {
            //    Stream stream = sri.Stream;
            //    StreamReader reader = new StreamReader(stream);

            //    while(!reader.EndOfStream) {
            //        string[] items = reader.ReadLine().Split('\t');
            //        yield return new Order() {
            //            Date = DateTime.Parse(items[0], CultureInfo.InvariantCulture),
            //            Product = items[1],
            //            Quantity = int.Parse(items[2], CultureInfo.InvariantCulture),
            //            Net = double.Parse(items[3], CultureInfo.InvariantCulture),
            //            Promotion = items[4],
            //            Advertisement = items[5]
            //        };
            //    }
            //}
            int i = 9;
            while(i-- > 0) {
                yield return new Order {
                    Date = DateTime.Parse(System.DateTime.Now.ToShortTimeString(), CultureInfo.InvariantCulture),
                    Product = string.Format("Code" + i, CultureInfo.InvariantCulture),
                    Quantity = i,
                    Net = i,
                    Promotion = string.Format("Promotion" + i.ToString(), CultureInfo.InvariantCulture),
                    Advertisement = string.Format("Advertisement" + i.ToString(), CultureInfo.InvariantCulture)
                };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}
