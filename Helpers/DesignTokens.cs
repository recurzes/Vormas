using System.Drawing;

namespace Vormas.Helpers
{
    /// <summary>
    /// Centralized design tokens for consistent UI across all forms.
    /// Based on Vormas Design System Specification v1.0
    /// </summary>
    public static class DesignTokens
    {
        // ===== LAYOUT =====
        public const int LeftPanelWidth = 400;
        public const int FormPadding = 15;
        public const int LabelToInputSpacing = 5;
        public const int FieldGroupSpacing = 15;
        public const int ButtonHeight = 35;
        public const int ButtonWidth = 80;
        public const int ButtonSpacing = 10;
        public const int SearchBarHeight = 30;
        public const int SearchBarMarginBottom = 10;
        public const int StandardInputWidth = 200;
        public const int StandardLabelWidth = 120;
        public const int FormRowHeight = 30;
        
        // ===== FONTS =====
        public static Font LabelFont => new Font("Segoe UI", 9F, FontStyle.Regular);
        public static Font InputFont => new Font("Segoe UI", 9F, FontStyle.Regular);
        public static Font GridHeaderFont => new Font("Segoe UI", 9F, FontStyle.Regular);
        public static Font GridCellFont => new Font("Segoe UI", 9F, FontStyle.Regular);
        public static Font TitleFont => new Font("Segoe UI", 12F, FontStyle.Bold);
        
        // ===== COLORS =====
        public static Color PrimaryButton => ColorTranslator.FromHtml("#0066FF");
        public static Color DestructiveButton => ColorTranslator.FromHtml("#D9534F");
        public static Color NeutralButton => ColorTranslator.FromHtml("#E0E0E0");
        public static Color GridSelection => ColorTranslator.FromHtml("#0078D7");
        public static Color GridAltRow => ColorTranslator.FromHtml("#F5F5F5");
        public static Color GridHeaderBackground => Color.FromArgb(240, 240, 240);
        public static Color TextOnPrimary => Color.White;
        public static Color TextOnNeutral => Color.Black;
        public static Color PanelBackground => Color.White;
        public static Color BorderColor => Color.FromArgb(220, 220, 220);
    }
}
