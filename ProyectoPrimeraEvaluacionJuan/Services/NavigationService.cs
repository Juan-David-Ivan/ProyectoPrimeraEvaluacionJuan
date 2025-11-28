using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using ProyectoPrimeraEvaluacionJuan.ViewModels;
using ProyectoPrimeraEvaluacionJuan.Views;

namespace ProyectoPrimeraEvaluacionJuan.Services;

public partial class NavigationService : ObservableObject
{
    public const string INICIO_VIEW = "inicio";
    public const string ALTA_VIEW = "alta";
    public const string CONSULTA_VIEW = "consulta";

    [ObservableProperty] private ContentControl currentView;

    [ObservableProperty] private NavigationViewItem selectedMenuItem;

    [ObservableProperty] private ObservableCollection<NavigationViewItem> menuItems = new();

    private NavigationViewItem inicio;
    private NavigationViewItem altas;
    private NavigationViewItem consultas;

    public NavigationService()
    {
        inicio = new NavigationViewItem
        {
            Content = "Inicio",
            Tag = INICIO_VIEW,
            IconSource = new SymbolIconSource { Symbol = Symbol.Home }
        };

        altas = new NavigationViewItem
        {
            Content = "Alta de petardos",
            Tag = ALTA_VIEW,
            IconSource = new SymbolIconSource { Symbol = Symbol.Add }
        };

        consultas = new NavigationViewItem
        {
            Content = "Consultas de petardos",
            Tag = CONSULTA_VIEW,
            IconSource = new SymbolIconSource { Symbol = Symbol.Find }
        };

        MenuItems.Add(inicio);
        MenuItems.Add(altas);
        MenuItems.Add(consultas);

        // IR A INICIO
        NavigateTo(INICIO_VIEW);
    }

    partial void OnSelectedMenuItemChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString());
    }

    public void NavigateTo(string tag)
    {
        if (tag.Equals(INICIO_VIEW))
        {
            InicioView inicioView = new InicioView();
            inicioView.DataContext = new InicioViewModel(this);
            CurrentView = inicioView;
            SelectedMenuItem = inicio; // Activar botón de inicio

        }
        else if (tag.Equals(ALTA_VIEW))
        {
            AltaView altaView = new AltaView();
            altaView.DataContext = new AltaViewModel(this);
            CurrentView = altaView;
            SelectedMenuItem = altas; // Activar botón
        }
        else if (tag.Equals(CONSULTA_VIEW))
        {
            CurrentView = new ConsultaView
            {
                DataContext = new ConsultaViewModel(this)
            };
            SelectedMenuItem = consultas;
        }
    }
}