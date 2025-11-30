using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoPrimeraEvaluacionJuan.Models;
using ProyectoPrimeraEvaluacionJuan.Services;

namespace ProyectoPrimeraEvaluacionJuan.ViewModels;

public partial class AltaViewModel : ViewModelBase
{
    
    [ObservableProperty]
    public string mensaje = string.Empty;
    
    private APIService apiservice { get; set; } = new();


    [ObservableProperty] private PetardoModel nuevoPetardo = new();
    private NavigationService navigationService;
    
    public List<string> ListaTipoPirotecnia{get;set;}


    public AltaViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
        CargarComboTipoPirotecnia();
        NuevoPetardo.fechaRecogida = DateTime.Today;

    }
    

    public AltaViewModel()
    {
        
    }
    
    [RelayCommand]
    public void IrAInicio()
    {
        navigationService.NavigateTo(NavigationService.INICIO_VIEW);
    }
    
    private void CargarComboTipoPirotecnia()
    {
        ListaTipoPirotecnia = new()
        {
            "Trueno", "Traca", "Bombeta", "Bengala", "Cohete", "Bateria"
        };
        NuevoPetardo.Tipo = ListaTipoPirotecnia[0];
    }
    
    
    [RelayCommand]
    
    public void ComprobarFecha()
    {
        CheckDate();
    }

    public bool CheckDate()
    {
        if (NuevoPetardo.fechaRecogida < DateTime.Today)
        {
            Mensaje = "No puedes seleccionar una fecha inferior a hoy";
            return false;
        }
        else
        {
            Mensaje = string.Empty;
            return true;
        }
    }

    private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(NuevoPetardo.nombre))
            {
                Mensaje = "El nombre del producto es obligatorio.";
                return false;
            }

            if (string.IsNullOrEmpty(NuevoPetardo.Tipo))
            {
                Mensaje = "Debes seleccionar un tipo para la pirotecnia.";
                return false;
            }

            if (NuevoPetardo.potencia < 1 || NuevoPetardo.potencia > 10)
            {
                Mensaje = "La potencia debe estar entre 1 y 10.";
                return false;
            }
            
            if (!CheckDate())
            {
                return false;
            }
            
            
            Mensaje = string.Empty;
            return true;
        }


        [RelayCommand]
        public async Task CrearPirotecnia()
        {
            if (!ValidarCampos())
            {
                return;
            }
            
            try
            {
                Mensaje = "Registrando producto...";
                
                await apiservice.CrearPetardo(NuevoPetardo);
                
                Mensaje = $"¡'{NuevoPetardo.nombre}' registrado con éxito!";
                
                NuevoPetardo = new PetardoModel();
                navigationService.NavigateTo(NavigationService.CONSULTA_VIEW);
            }
            catch (Exception ex)
            {
                Mensaje = $"ERROR: No se pudo registrar. {ex.Message}";
            }
        }
    
}