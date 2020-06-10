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

        //Private Variables
        private string _input;
        private double _min;
        private double _q1;
        private double _med;
        private double _q3;
        private double _max;

        private ObservableCollection<Results> _previousResult;

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }
        public double Min
        {
            get => _min;
            set
            {
                _min = value;
                OnPropertyChanged();
            }
        }
        public double Q1
        {
            get => _q1;
            set
            {
                _q1 = value;
                OnPropertyChanged();
            }
        }
        public double Med
        {
            get => _med;
            set
            {
                _med = value;
                OnPropertyChanged();
            }
        }
        public double Q3
        {
            get => _q3;
            set
            {
                _q3 = value;
                OnPropertyChanged();
            }
        }
        public double Max
        {
            get => _max;
            set
            {
                _max = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Results> PreviousResult
        {
            get
            {

                this._previousResult = new ObservableCollection<Results>();
                this._previousResult.Add(new Results() { Min = _min, Q1 = 4, Med = 3, Q3 = 2, Max = 1 });
                return this._previousResult;
            }
        }


        public ICommand CalculateCommand { get; set; }


        public MainViewModel()
        {
            CalculateCommand = new CalculateCommandDef(this);

        }

        public void Calculate()
        {
            var obj = new Calculations();
            obj.UserInput = Input;
            double[] inputArray = obj.UserInput.Split(',').Select(n => Convert.ToDouble(n)).ToArray();

            Array.Sort(inputArray);

            Min = obj.Min(inputArray);
            Q1 = obj.Percentile(inputArray, 25);
            Med = obj.Percentile(inputArray, 50);
            Q3 = obj.Percentile(inputArray, 75);
            Max = obj.Max(inputArray);

            var Result = new Results();
            Result.Min = Min;
            Result.Q1 = Q1;
            Result.Med = Med;
            Result.Q3 = Q3;
            Result.Max = Max;

        }
    }
}
