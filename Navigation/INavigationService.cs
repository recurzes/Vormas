namespace Vormas.Navigation
{
    public interface INavigationService
    {
        void Navigate(string route, object parameter = null);
        bool CanGoBack { get; }
        void GoBack();
    }
}