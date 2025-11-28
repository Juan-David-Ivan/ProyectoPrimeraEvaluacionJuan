using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoPrimeraEvaluacionJuan.Models;
using ProyectoPrimeraEvaluacionJuan.Services;

namespace ProyectoPrimeraEvaluacionJuan.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
    [ObservableProperty] private string imageUrl;
    [ObservableProperty] private AvaloniaList<Usuario> listaUsuarios=new();
    [ObservableProperty]
    private NavigationService navigationService = new();

    public MainViewModel()
    {
        _ = ObtenerUsuariosAsync();
    }
    
    [RelayCommand]
    public async Task ObtenerUsuariosAsync()
    {
        ListaUsuarios = await new DBService().ObtenerTodosLosUsuarios();
    }
    
    [RelayCommand]
    public async Task LoginUsuarioAsync(Usuario user)
    {
        var authservice = new GoogleAuthService();
        await authservice.LoginAsync(user);
    }
    
    [RelayCommand]
    public async Task RegisterUserAsync()
    {
        var authservice = new GoogleAuthService();
        Usuario usuario = await authservice.LoginAsync(new Usuario());
        ImageUrl = usuario.ImageUrl;
    }
}