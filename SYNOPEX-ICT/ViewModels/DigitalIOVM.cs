using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNOPEX_ICT.ViewModels
{
    public class DigitalIOVM : BaseVM
    {
        #region ValuesBinding
        private double _X;
        public double Xcoordinates
        {
            get => _X;
            set { _X = value; OnPropertyChanged("Xcoordinates"); }
        }
        private double _Y;
        public double Ycoordinates
        {
            get => _Y;
            set { _Y = value; OnPropertyChanged("Ycoordinates"); }
        }
        private double _Z;
        public double Zcoordinates
        {
            get => _Z;
            set { _Z = value; OnPropertyChanged("Zcoordinates"); }
        }
        private double _U;
        public double Ucoordinates
        {
            get => _U;
            set { _U = value; OnPropertyChanged("Ucoordinates"); }
        }
        private double _V;
        public double Vcoordinates
        {
            get => _V;
            set { _V = value; OnPropertyChanged("Vcoordinates"); }
        }
        private double _M;
        public double Mcoordinates
        {
            get => _M;
            set { _M = value; OnPropertyChanged("Mcoordinates"); }
        }
        private double _Joint1;
        public double Joint1
        {
            get => _Joint1;
            set { _Joint1 = value; OnPropertyChanged("_Joint1"); }
        }
        private double _Joint2;
        public double Joint2
        {
            get => _Joint2;
            set { _Joint2 = value; OnPropertyChanged("Joint2"); }
        }
        private double _Joint3;
        public double Joint3
        {
            get => _Joint3;
            set { _Joint3 = value; OnPropertyChanged("Joint3"); }
        }
        private double _Joint4;
        public double Joint4
        {
            get => _Joint4;
            set { _Joint4 = value; OnPropertyChanged("Joint4"); }
        }
        #endregion
        public DigitalIOVM()
        {
            Xcoordinates = 123;
            Vcoordinates = 255;
            Joint1 = 25.12353543456546654664;
        }
    }
}
