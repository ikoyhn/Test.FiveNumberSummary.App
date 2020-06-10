using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace FiveNumberSummary
{
    public class Results : ViewModelBase
    {
        private double _min;
        private double _q1;
        private double _med;
        private double _q3;
        private double _max;

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
    }
}
