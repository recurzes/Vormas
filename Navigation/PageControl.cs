using System.Windows.Forms;

namespace Vormas.Navigation
{
    public class PageControl: UserControl
    {
        public string RouteName { get; internal set; }
        public object Parameter { get; internal set; }

        public virtual void OnNavigatedTo()
        {
            
        }

        public virtual void OnNavigatedFrom()
        {
            
        }
    }
}