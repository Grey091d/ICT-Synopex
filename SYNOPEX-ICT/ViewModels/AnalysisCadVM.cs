using SYNOPEX_ICT.Stored;
using System;
using ACadSharp.IO;
using ACadSharp.IO.DWG;
using ACadSharp.IO.DXF;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ACadSharp;
using System.Windows.Input;
using SYNOPEX_ICT.Models;

namespace SYNOPEX_ICT.ViewModels
{
    class AnalysisCadVM : BaseVM
    {
        #region Commands
        public ICommand BrowseCommand { get; set; }
        public ICommand ReadFileCadCommand { get; set; }        
        #endregion

        #region Properties
        private ObservableCollection<PointCheck> _ListData;
        public ObservableCollection<PointCheck> ListData
        {
            get => _ListData;
            set
            {
                _ListData = value;
                OnPropertyChanged();
            }
        }
        private string _path;
        public string Path { get => _path; set { _path = value; OnPropertyChanged("Path"); } }
        #endregion
        public AnalysisCadVM(NavigationStore navigationStore)
        {

        }
        public AnalysisCadVM()
        {
            #region Commands
            BrowseCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "AutoCad DWG file|*.dwg";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string source = dlg.FileName;
                    Path = source;
                }
            });
            ReadFileCadCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ListData = ReadMOdelsCodeInExcel(Path);
            });
            #endregion
        }
        public static ObservableCollection<PointCheck> ReadMOdelsCodeInExcel(string Path)
        {
            ObservableCollection<PointCheck> ListData = new ObservableCollection<PointCheck>();           
            string path = Path;
            try 
            {
                using (DwgReader reader = new DwgReader(Path))
                {
                    CadDocument doc = reader.Read(onProgress);
                }
                PointCheck readedPoint = new PointCheck();
                readedPoint.ID = 1;
                readedPoint.Ycoordinates = 12;
                readedPoint.Xcoordinates = 18;
                ListData.Add(readedPoint);
            }
            catch { }         

            return ListData;
        }
        private static void onProgress(object sender, ProgressEventArgs e)
        {
            
        }
    }
}
