using System.Collections.ObjectModel;

namespace DataTreeViewDemo.Models {
    public class Customer {
        public int Id {
            get;
            set;
        }

        public double Count {
            get;
            set;
        }

        public string Code {
            get;
            set;
        }

        public string Status {
            get;
            set;
        }

        public ObservableCollection<Customer> Customers {
            get;
            set;
        }

        public Customer(int id, int count, string code, string status) {
            this.Id = id;
            this.Count = count;
            this.Code = code;
            this.Status = status;
        }
    }
}
