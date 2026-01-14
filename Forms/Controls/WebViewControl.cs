using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Vormas.Forms.Controls
{
    public partial class WebViewControl : UserControl
    {
        private WebView2 _webView;
        private string _baseUrl = "http://localhost:5173";
        private string _initialRoute;

        public WebViewControl(string initialRoute = "")
        {
            _initialRoute = initialRoute;
            InitializeComponent();
            
            _webView = new WebView2();
            InitializeWebView();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WebViewControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
        }

        private async void InitializeWebView()
        {
            _webView.Dock = DockStyle.Fill;
            Controls.Add(_webView);

            try
            {
                await _webView.EnsureCoreWebView2Async(null);

                _webView.CoreWebView2.NavigationCompleted += (sender, e) =>
                {
                    if (!e.IsSuccess)
                    {
                        ShowErrorMessage($"WebErrorStatus: {e.WebErrorStatus}");
                    }
                };

                // Navigate to the initial route
                string fullUrl = $"{_baseUrl}/{_initialRoute.TrimStart('/')}";
                _webView.CoreWebView2.Navigate(fullUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"WebView2 initialization error: {ex.Message}");
                
                MessageBox.Show(
                    @$"Failed to initialize dashboard:\n{ex.Message}\n\n" +
                    @$"Please ensure:\n" +
                    @$"1. WebView2 Runtime is installed\n" +
                    @$"2. The dev server is running on {_baseUrl}",
                    @"Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                ShowErrorMessage(ex.Message);
            }
        }

        private void ShowErrorMessage(string details = null)
        {
            string errorHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: 'Segoe UI', sans-serif;
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
            margin: 0;
            background: #f8fafc;
            color: #1e293b;
        }}
        .container {{
            text-align: center;
            padding: 40px;
            max-width: 500px;
        }}
        h2 {{ color: #ef4444; margin-bottom: 16px; }}
        p {{ color: #64748b; line-height: 1.6; }}
        code {{
            background: #e2e8f0;
            padding: 2px 8px;
            border-radius: 4px;
            font-size: 14px;
        }}
        .steps {{
            text-align: left;
            background: #ffffff;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            padding: 20px;
            margin-top: 20px;
        }}
        .steps li {{ margin-bottom: 8px; }}
    </style>
</head>
<body>
    <div class='container'>
        <h2>⚠️ Dashboard Unavailable</h2>
        <p>The React dev server is not running.</p>
        <div class='steps'>
            <strong>To start the dashboard:</strong>
            <ol>
                <li>Open a terminal in the <code>Web</code> folder</li>
                <li>Run: <code>npm run dev</code></li>
            </ol>
        </div>
        {(details != null ? $"<p style='font-size:12px;margin-top:20px;'>Error: {details}</p>" : "")}
    </div>
</body>
</html>";

            try
            {
                _webView.CoreWebView2.NavigateToString(errorHtml);
            }
            catch
            {
                var label = new Label
                {
                    Text = @"Dashboard not available.\nPlease start the React dev server.",
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
                Controls.Add(label);
                label.BringToFront();
            }
        }
    }
}
