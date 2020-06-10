using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FiveNumberSummary
{
    public class MainViewModel : ViewModelBase
    {

        private string _input;
        private Results _previousResult;
        private ObservableCollection<Results> _previousResults;
        private ICommand _submitCommand;

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }

        public Results PreviousResult 
        {
            get { return _previousResult; } 
            set 
            { 
                _previousResult = value;
                OnPropertyChanged();
            } 
        }
        public ObservableCollection<Results> PreviousResults
        {
            get { return _previousResults; }
            set
            {
                _previousResults = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(param => this.Submit(), null);
                }
                return _submitCommand;
            }
        }

        public ICommand CalculateCommand { get; set; }

        public MainViewModel()
        {
            //CalculateCommand = new CalculateCommandDef(this);
            PreviousResult = new Results();
            PreviousResults = new ObservableCollection<Results>();
            PreviousResults.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(PreviousResults_CollectionChanged);

        }

        void PreviousResults_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }


        private void Submit()
        {
            var obj = new Calculations();

            obj.UserInput = Input;
            MessageBox.Show(Input);
            double[] inputArray = obj.UserInput.Split(',').Select(n => Convert.ToDouble(n)).ToArray();
            Array.Sort(inputArray);
            PreviousResult.Min = obj.Min(inputArray);
            PreviousResult.Q1 = obj.Percentile(inputArray, 25);
            PreviousResult.Med = obj.Percentile(inputArray, 50);
            PreviousResult.Q3 = obj.Percentile(inputArray, 75);
            PreviousResult.Max = obj.Max(inputArray);
            PreviousResults.Add(PreviousResult);
            PreviousResult = new Results();


        }
    }
}
