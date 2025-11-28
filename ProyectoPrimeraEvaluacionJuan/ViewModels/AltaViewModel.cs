using CommunityToolkit.Mvvm.Input;
using ProyectoPrimeraEvaluacionJuan.Services;

namespace ProyectoPrimeraEvaluacionJuan.ViewModels;

public partial class AltaViewModel : ViewModelBase
{
    private NavigationService navigationService;

    public AltaViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public AltaViewModel()
    {
        
    }
    
    [RelayCommand]
    public void IrAInicio()
    {
        navigationService.NavigateTo(NavigationService.INICIO_VIEW);
    }
    
    [RelayCommand]
    public void IrAConsultas()
    {
        navigationService.NavigateTo(NavigationService.CONSULTA_VIEW);
    }
}