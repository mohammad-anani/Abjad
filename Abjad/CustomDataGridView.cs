using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abjad
{
    public partial class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            InitializeComponent();
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray ;
            this.RowsDefaultCellStyle.BackColor = Color.White;
            this.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            this.RowsDefaultCellStyle.ForeColor= Color.Black;
            this.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.ForestGreen;
            this.RowsDefaultCellStyle.SelectionBackColor = Color.ForestGreen;
            this.AlternatingRowsDefaultCellStyle.SelectionForeColor= Color.Black;
            this.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersVisible = false;
            this.ReadOnly = true;
            this.BackgroundColor = SystemColors.Control;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 15);
            this.RowsDefaultCellStyle.Font = new Font("Segoe UI", 15);
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.ForestGreen;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black ;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 15);
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor= Color.ForestGreen;
            this.GridColor= SystemColors.Control;
            this.BorderStyle=BorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersHeight = 60;
            this.RowTemplate.Height = 50;
            this.SelectionChanged += CustomDataGridView_SelectionChanged;

        }

        private void CustomDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.ClearSelection();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
