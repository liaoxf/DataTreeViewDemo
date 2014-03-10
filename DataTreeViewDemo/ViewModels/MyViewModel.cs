using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataTreeViewDemo.ViewModels {
    public class MyViewModel : INotifyPropertyChanged {
        private static int idCounter = 1;
        private string title;

        public MyViewModel() {
            this.Children = new ObservableCollection<MyViewModel>();
            this.Id = idCounter++;
        }

        public int Id {
            get;
            protected set;
        }

        public String Title {
            get {
                return this.title;
            }
            set {
                if(this.title != value) {
                    this.title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public IList<MyViewModel> Children {
            get;
            protected set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
