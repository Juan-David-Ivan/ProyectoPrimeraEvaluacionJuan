using System;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoPrimeraEvaluacionJuan.Models;
using ProyectoPrimeraEvaluacionJuan.Services;

namespace ProyectoPrimeraEvaluacionJuan.ViewModels;

public partial class ConsultaViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
        private readonly APIService _apiService;

        [ObservableProperty] 
        private AvaloniaList<PetardoModel> listaPetardos = new();
        
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EliminarPetardoCommand))] 
        private PetardoModel petardoSeleccionado;

        [ObservableProperty]
        private bool isDialogHostOpen = false; 
        

        public ConsultaViewModel(NavigationService navigationService) 
        {
             
             _ = ObtenerPetardoAsync(); 
             _navigationService = navigationService;
        }

        public ConsultaViewModel()
        {
            
        }
    

        [RelayCommand]
        public async Task ObtenerPetardoAsync()
        {
            
            ListaPetardos = new AvaloniaList<PetardoModel>(await _apiService.ObtenerPetardos());
        }
        
        [RelayCommand]
        public void IrAInicio()
        {
            _navigationService.NavigateTo(NavigationService.INICIO_VIEW);
        }
        
        [RelayCommand]
        public void IrAAltas()
        {
            _navigationService.NavigateTo(NavigationService.ALTA_VIEW);
        }

        
        [RelayCommand]
        public void ConfirmarEliminacion()
        {
            
            IsDialogHostOpen = true; 
        }

        
        private bool PuedeEliminarPetardo() => PetardoSeleccionado != null;


        
        [RelayCommand]
        public async Task EliminarPetardoAsync(bool confirmacion)
        {
            
            IsDialogHostOpen = false; 

            if (confirmacion && PetardoSeleccionado != null)
            {
                try
                {
                    
                    await _apiService.EliminarPetardo(PetardoSeleccionado);
                    
                    
                    ListaPetardos.Remove(PetardoSeleccionado);
                    
                    
                    PetardoSeleccionado = null;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Error al eliminar: {ex.Message}");
                }
            }
        }
    }
