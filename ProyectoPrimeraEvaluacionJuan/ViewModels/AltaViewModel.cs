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
    }

    public AltaViewModel()
    {
        CargarComboTipoPirotecnia();
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

    [RelayCommand]
    public async Task CrearPirotecnia(object parameter)
    {
        CheckBox check = (CheckBox)parameter;
        
        if (string.IsNullOrWhiteSpace(NuevoPetardo.nombre))
        {
            Mensaje = "Debes indicar el nombre de la pirotecnia...";
        }
        else if (int.IsNegative(NuevoPetardo.potencia))
        {
            Mensaje = "Debes indicar la potencia de la pirotecnia...";
        }
        
        else if (!CheckDate())
        {
            Mensaje = "La fecha debe ser hoy o posterior...";
        } else if (check.IsChecked is false)
        {
            NuevoPetardo.peligroso = false;
            
        }else if (check.IsChecked is true)
        {
            NuevoPetardo.peligroso = true;
        }else if (string.IsNullOrEmpty(NuevoPetardo.Tipo))
        {
            Mensaje = "DEBES SELECCIONAR UN TIPO PARA LA PIROTECNIA";
        }
        else
        {
            await apiservice.CrearPetardo(NuevoPetardo);
            NuevoPetardo = new PetardoModel();
        }
    }
    
    
    [RelayCommand]
    public void IrAConsultas()
    {
        navigationService.NavigateTo(NavigationService.CONSULTA_VIEW);
    }
}