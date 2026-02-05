using Ornytolog.Model;
using Ornytolog.Service;
using Ornytolog.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ornytolog.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private IOrnytologyService OrnytologyService;

        public MainViewModel(IOrnytologyService service)
        {
            OrnytologyService = service;
            Birds = new ObservableCollection<Bird>(OrnytologyService.GetAll());
        }

        private ObservableCollection<Bird> _birds = [];
        public ObservableCollection<Bird> Birds
        {
            get => _birds; set
            {
                _birds = value;
                OnPropertyChanged(nameof(Birds));
            }
        }

        private string _name = "";
        public string Name
        {
            get => _name; set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        private Bird? _selectedBird;
        public Bird? SelectedBird
        {
            get => _selectedBird; set
            {
                _selectedBird = value;
                OnPropertyChanged(nameof(SelectedBird));
            }
        }

        private RelayCommand? addBirdCommand = null;
        public RelayCommand AddBirdCommand
        {
            get
            {
                return addBirdCommand ??
                  (addBirdCommand = new RelayCommand(obj =>
                  {
                      OrnytologyService.AddBird(
                              new Bird(
                                  null,
                                  Name
                                  ));

                      Birds = new ObservableCollection<Bird>(OrnytologyService.GetAll());
                  }
                  ));
            }
        }

        private RelayCommand? editBirdCommand = null;
        public RelayCommand EditBirdCommand
        {
            get
            {
                return editBirdCommand ??
                  (editBirdCommand = new RelayCommand(obj =>
                  {
                      if (SelectedBird != null)
                      {
                          OrnytologyService.Update(
                                new Bird(SelectedBird.Id, Name)
                                );

                          Birds = new ObservableCollection<Bird>(
                              OrnytologyService.GetAll());

                      }
                  }));
            }
        }

        private RelayCommand? deleteBirdCommand;
        public RelayCommand DeleteBirdCommand
        {
            get
            {
                return deleteBirdCommand ??
                  (deleteBirdCommand = new RelayCommand(obj =>
                  {
                      if (SelectedBird != null)
                      {
                          OrnytologyService.Delete((Guid)SelectedBird.Id!);
                          Birds = new ObservableCollection<Bird>(OrnytologyService.GetAll());
                      }

                  }));
            }
        }

    }
}
