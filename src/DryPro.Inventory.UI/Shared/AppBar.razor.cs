using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DryPro.Inventory.UI.Shared
{
    public partial class AppBar
    {
        private bool _isLightMode = true;
        private bool _isMenuCollapsed = true;
        private MudTheme _currentTheme = new();

        [Parameter] public EventCallback OnSidebarToggled { get; set; }
        [Parameter] public EventCallback<MudTheme> OnThemeToggled { get; set; }

        private async Task ToggleTheme()
        {
            _isLightMode = !_isLightMode;

            _currentTheme = !_isLightMode ? GenerateDarkTheme() : new MudTheme();

            await OnThemeToggled.InvokeAsync(_currentTheme);
        }

        private async Task ToggleSideBar()
        {
            _isMenuCollapsed = !_isMenuCollapsed;

            await OnSidebarToggled.InvokeAsync();
        }

        private static MudTheme GenerateDarkTheme() =>
            new()
            {
                Palette = new Palette()
                {
                    Black = "#27272f",
                    Background = "#32333d",
                    BackgroundGrey = "#27272f",
                    Surface = "#373740",
                    TextPrimary = "#ffffffb3",
                    TextSecondary = "rgba(255,255,255, 0.50)",
                    AppbarBackground = "#27272f",
                    AppbarText = "#ffffffb3",
                    DrawerBackground = "#27272f",
                    DrawerText = "#ffffffb3",
                    DrawerIcon = "#ffffffb3"
                }
            };
    }
}