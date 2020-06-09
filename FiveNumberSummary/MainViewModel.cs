using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ICommand CalculateCommand { get; set; }


        public MainViewModel()
        {
            CalculateCommand = new CalculateCommandDef(this);
            var testList = new List<Calculations>();
            foreach (var calc in testList)
            {

            }
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

        }
    }
}
