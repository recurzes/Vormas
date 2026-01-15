using System;
using System.Drawing;
using System.Windows.Forms;
using Vormas.Helpers;
using Vormas.Navigation;

namespace Vormas.Forms
{
    /// <summary>
    /// Base class for Master-Detail forms following the Vormas Design System.
    /// Provides consistent layout, styling, and common controls.
    /// </summary>
    public abstract class MasterDetailPageBase : PageControl
    {
        // === LAYOUT PANELS ===
        protected Panel LeftPanel;
        protected Panel RightPanel;
        protected Panel FormFieldsPanel;
        protected Panel ButtonPanel;
        
        // === COMMON CONTROLS ===
        protected TextBox SearchBox;
        protected DataGridView MainGrid;
        protected Button BtnSave, BtnDelete, BtnClear;
        
        /// <summary>
        /// Call this in constructor after InitializeComponent to set up the standard layout.
        /// </summary>
        protected virtual void SetupMasterDetailLayout()
        {
            BackColor = Color.White;
            Padding = new Padding(0);
            
            // === LEFT PANEL (Form Side) ===
            LeftPanel = new Panel
            {
                Width = DesignTokens.LeftPanelWidth,
                Dock = DockStyle.Left,
                Padding = new Padding(DesignTokens.FormPadding),
                BackColor = DesignTokens.PanelBackground,
                BorderStyle = BorderStyle.None
            };

            // Separator line between panels
            var separator = new Panel
            {
                Width = 1,
                Dock = DockStyle.Left,
                BackColor = DesignTokens.BorderColor
            };

            // === RIGHT PANEL (Grid Side) ===
            RightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(DesignTokens.FormPadding),
                BackColor = DesignTokens.PanelBackground
            };

            // Search Box (Top of Left Panel)
            SearchBox = new TextBox
            {
                Dock = DockStyle.Top,
                Height = DesignTokens.SearchBarHeight,
                Font = DesignTokens.InputFont,
                Margin = new Padding(0, 0, 0, DesignTokens.SearchBarMarginBottom)
            };
            SearchBox.TextChanged += (s, e) => OnSearchTextChanged(SearchBox.Text);

            // Form Fields Container (Middle of Left Panel)
            FormFieldsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0, DesignTokens.SearchBarMarginBottom, 0, 0)
            };

            // Button Panel (Bottom of Left Panel)
            ButtonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = DesignTokens.ButtonHeight + DesignTokens.FieldGroupSpacing,
                Padding = new Padding(0)
            };

            BtnSave = CreateStandardButton("Save", DesignTokens.PrimaryButton, DesignTokens.TextOnPrimary);
            BtnDelete = CreateStandardButton("Delete", DesignTokens.DestructiveButton, DesignTokens.TextOnPrimary);
            BtnClear = CreateStandardButton("Clear", DesignTokens.NeutralButton, DesignTokens.TextOnNeutral);

            BtnSave.Click += (s, e) => OnSaveClicked();
            BtnDelete.Click += (s, e) => OnDeleteClicked();
            BtnClear.Click += (s, e) => OnClearClicked();

            var btnFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0)
            };
            btnFlow.Controls.Add(BtnSave);
            btnFlow.Controls.Add(BtnDelete);
            btnFlow.Controls.Add(BtnClear);
            ButtonPanel.Controls.Add(btnFlow);

            // Assemble Left Panel (order matters for docking)
            LeftPanel.Controls.Add(FormFieldsPanel);
            LeftPanel.Controls.Add(ButtonPanel);
            LeftPanel.Controls.Add(SearchBox);

            // Main Grid (in Right Panel)
            MainGrid = CreateStandardGrid();
            MainGrid.SelectionChanged += (s, e) => OnGridSelectionChanged();
            RightPanel.Controls.Add(MainGrid);

            // Add panels to form (order matters for docking)
            Controls.Add(RightPanel);
            Controls.Add(separator);
            Controls.Add(LeftPanel);
        }

        /// <summary>
        /// Creates a standard button with consistent styling.
        /// </summary>
        protected Button CreateStandardButton(string text, Color backColor, Color foreColor)
        {
            return new Button
            {
                Text = text,
                Width = DesignTokens.ButtonWidth,
                Height = DesignTokens.ButtonHeight,
                FlatStyle = FlatStyle.Flat,
                BackColor = backColor,
                ForeColor = foreColor,
                Font = DesignTokens.InputFont,
                Margin = new Padding(0, 0, DesignTokens.ButtonSpacing, 0),
                Cursor = Cursors.Hand
            };
        }

        /// <summary>
        /// Creates a DataGridView with standard styling.
        /// </summary>
        protected DataGridView CreateStandardGrid()
        {
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoGenerateColumns = false,
                EnableHeadersVisualStyles = false
            };

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = DesignTokens.GridHeaderFont,
                BackColor = DesignTokens.GridHeaderBackground,
                ForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = DesignTokens.GridCellFont,
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = DesignTokens.GridSelection,
                SelectionForeColor = Color.White,
                Padding = new Padding(8, 0, 0, 0)
            };

            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = DesignTokens.GridAltRow
            };

            return grid;
        }

        /// <summary>
        /// Creates a form row with label and input control.
        /// </summary>
        protected Panel CreateFormRow(string labelText, Control input)
        {
            var row = new Panel
            {
                Height = DesignTokens.FormRowHeight,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, DesignTokens.LabelToInputSpacing)
            };

            var lbl = new Label
            {
                Text = labelText,
                Font = DesignTokens.LabelFont,
                Width = DesignTokens.StandardLabelWidth,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Left,
                Padding = new Padding(0, 0, 8, 0)
            };

            input.Font = DesignTokens.InputFont;
            input.Dock = DockStyle.Fill;

            row.Controls.Add(input);
            row.Controls.Add(lbl);
            return row;
        }

        /// <summary>
        /// Adds a spacer between field groups.
        /// </summary>
        protected Panel CreateSpacer()
        {
            return new Panel
            {
                Height = DesignTokens.FieldGroupSpacing,
                Dock = DockStyle.Top
            };
        }

        // === ABSTRACT METHODS (Override in derived classes) ===
        protected virtual void OnSearchTextChanged(string searchText) { }
        protected virtual void OnSaveClicked() { }
        protected virtual void OnDeleteClicked() { }
        protected virtual void OnClearClicked() { }
        protected virtual void OnGridSelectionChanged() { }
    }
}
