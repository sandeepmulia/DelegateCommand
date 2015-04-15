using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DelegateCommand
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> o = new ObservableCollection<string>();
        public ViewModel()
        {            
            o.Add("Sandeep");
            o.Add("Sharath");
            o.Add("Manasa");
            o.Add("Vijaya");
            o.Add("Shankar");
            o.Add("Ram");
            o.Add("Savithri");

            ButtonCommand = new RoutedCommand(Execute, CanExecute);
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrEmpty(TextData);
        }

        private void Execute(object obj)
        {
            MessageBox.Show(String.Format("Command executed {0}", obj.ToString()));
        }

        public ICommand ButtonCommand
        {
            get; set; 
        }

        public ICommand Check { get; set; }

        public ObservableCollection<string> Item
        {
            get { return o; }
            set { o = value; }
        }

        private string _textData = string.Empty;

        public String TextData
        {
            get
            {
               return _textData;
            }

            set
            {
                _textData = value;
                if (PropertyChanged != null)
                    PropertyChanged(this,new PropertyChangedEventArgs("TextData"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
