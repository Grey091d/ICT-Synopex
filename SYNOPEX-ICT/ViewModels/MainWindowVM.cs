using SYNOPEX_ICT.Commands;
using SYNOPEX_ICT.Services;
using SYNOPEX_ICT.Stored;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SYNOPEX_ICT.ViewModels
{
    class MainWindowVM : BaseVM
    {
        #region Properties
        private readonly NavigationStore _navigationStore;
        public BaseVM CurrentViewModel => _navigationStore.CurrentViewModel;        
        #endregion

        #region Commands
        public ICommand NavigateAnalysisCadModeCommand { get; }
        public ICommand NavigateScreenWorkCommand { get; }        
        #endregion
        public MainWindowVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            NavigateScreenWorkCommand = new NavigateCommand<ScreenWorkVM>(new NavigationService<ScreenWorkVM>(
               navigationStore, () => new ScreenWorkVM(navigationStore)));
            NavigateAnalysisCadModeCommand = new NavigateCommand<AnalysisCadVM>(new NavigationService<AnalysisCadVM>(
               navigationStore, () => new AnalysisCadVM(navigationStore)));            
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public MainWindowVM()
        {
            #region Commands
            
            #endregion
        }

       
    }
}
