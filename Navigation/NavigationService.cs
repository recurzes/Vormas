using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vormas.Navigation
{
    public class NavigationService: INavigationService
    {
        private readonly Panel _hostPanel;
        private readonly Dictionary<string, Func<PageControl>> _routes;
        private readonly Stack<PageControl> _historyStack = new Stack<PageControl>();

        public NavigationService(Panel hostPanel, Dictionary<string, Func<PageControl>> routes)
        {
            _hostPanel = hostPanel ?? throw new ArgumentNullException(nameof(hostPanel));
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
        }
        
        public void Navigate(string route, object parameter = null)
        {
            if (!_routes.TryGetValue(route, out var factory))
                throw new InvalidOperationException($"Route '{route}' is not registered");
            
            // Current page
            PageControl current = _hostPanel.Controls.Count > 0 ? _hostPanel.Controls[0] as PageControl : null;

            if (current != null)
            {
                current.OnNavigatedFrom();
            }
            
            // Create new page
            PageControl newPage = factory();
            newPage.RouteName = route;
            newPage.Parameter = parameter;
            newPage.Dock = DockStyle.Fill;
            
            // Replace host contents
            _hostPanel.Controls.Clear();
            _hostPanel.Controls.Add(newPage);
            
            // Push new page on stack
            _historyStack.Push(newPage);
            
            newPage.OnNavigatedTo();
        }

        public bool CanGoBack => _historyStack.Count > 1;
        public void GoBack()
        {
            if (!CanGoBack)
                return;
            
            // Pop current
            PageControl current = _historyStack.Pop();
            current.OnNavigatedFrom();
            
            // Previous page becomes active
            PageControl previous = _historyStack.Peek();
            
            _hostPanel.Controls.Clear();
            previous.Dock = DockStyle.Fill;
            _hostPanel.Controls.Add(previous);
            previous.OnNavigatedTo();
        }
    }
}