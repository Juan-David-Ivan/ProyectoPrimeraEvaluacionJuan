using CommunityToolkit.Mvvm.Input;
using ProyectoPrimeraEvaluacionJuan.Services;

namespace ProyectoPrimeraEvaluacionJuan.ViewModels;

public partial class ConsultaViewModel : ViewModelBase
{
    private NavigationService navigationService;

    public ConsultaViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public ConsultaViewModel()
    {
        
    }
    
    [RelayCommand]
    public void IrAInicio()
    {
        navigationService.NavigateTo(NavigationService.INICIO_VIEW);
    }
    
    [RelayCommand]
    public void IrAAltas()
    {
        navigationService.NavigateTo(NavigationService.ALTA_VIEW);
    }
}