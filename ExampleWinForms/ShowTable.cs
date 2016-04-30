using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Encode;
using System.Collections;
using ExampleWinForms.Properties;

namespace ExampleWinForms
{
    public partial class ShowTable : Form
    {
        private ITable _table;
        private IDictionary<char, double> _coefs;
        private Settings _settings = new Settings();

        public ShowTable(ITable table, IDictionary<char, double> coefs, int accuracy)
        {
            _table = table;
            _coefs = coefs;
            InitializeComponent();
            Size = _settings.ShowTableSize;
            Location = _settings.ShowTableLocation;
            dataGridViewTable.Font = new System.Drawing.Font(dataGridViewTable.Font.FontFamily, _settings.ShowTableDGVFontSize);
            trackBarTextSize.Value = (int)(_settings.ShowTableDGVFontSize * 10);
            dataGridViewTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)_settings.ShowTableGridAutoSizeColumnMode;

            Text += " (" + accuracy + ")";
            Load += ShowTable_Load;
            butScroll.Click += ButScroll_Click;
        }

        protected override void OnClosed(EventArgs e)
        {
            _settings.ShowTableLocation = Location;
            _settings.ShowTableSize = Size;
            _settings.ShowTableDGVFontSize = dataGridViewTable.Font.Size;
            _settings.ShowTableGridAutoSizeColumnMode = (int)dataGridViewTable.AutoSizeColumnsMode;
            _settings.Save();
            base.OnClosed(e);
        }

        private void ButScroll_Click(object sender, EventArgs e)
        {
            dataGridViewTable.AutoSizeColumnsMode ^= DataGridViewAutoSizeColumnsMode.Fill | DataGridViewAutoSizeColumnsMode.None;
            dataGridViewTable.AutoResizeColumns();
        }

        private void ShowTable_Load(object sender, EventArgs e)
        {
            dataGridViewTable.Columns.Add("symbols", "V");
            int len = _table.Bytes.Length; // or _table.Coef.Length
            for (int j = 0; j < len; j++)
            {
                dataGridViewTable.Columns.Add("symbols_p" + j, "P" + j);
                dataGridViewTable.Columns.Add("symbols_g" + j, "G" + j);
            }

            int i = 0;

            foreach (var coef in _coefs)
            {
                ArrayList values = new ArrayList((len + 1)*2);
                values.Add(coef.Key);
                for (int j = 0; j < _table.Bytes.Length; j++)
                {
                    if (i >= _table.Bytes[j].Length) break;

                    values.Add(_table.Coefs[j][i]);
                    values.Add(string.Join("", _table.Bytes[j][i]));
                }
                dataGridViewTable.Rows.Add(values.ToArray());
                ++i;
            }

            dataGridViewTable.AutoResizeColumns();
            dataGridViewTable.AutoResizeRows();
        }

        private void trackBarTextSize_Scroll(object sender, EventArgs e)
        {
            dataGridViewTable.Font = new System.Drawing.Font(dataGridViewTable.Font.FontFamily, trackBarTextSize.Value/10f);
            dataGridViewTable.AutoResizeRows();
            dataGridViewTable.AutoResizeColumns();
        }
    }
}
