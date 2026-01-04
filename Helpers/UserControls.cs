using System.Windows.Forms;

namespace Vormas.Helpers
{
    public class UserControls
    {
        public void LoadUserControl(Panel panelContainer, UserControl userControl)
        {
            panelContainer.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
    }
}