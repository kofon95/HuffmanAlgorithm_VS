using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Encode;
using System.Collections;
using ExampleWinForms.Properties;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

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
            dataGridViewTable.Font = new Font(dataGridViewTable.Font.FontFamily, _settings.ShowTableDGVFontSize);
            trackBarTextSize.Value = (int)(_settings.ShowTableDGVFontSize * 10);
            dataGridViewTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)_settings.ShowTableGridAutoSizeColumnMode;

            Text += " (" + accuracy + ")";
            Load += ShowTable_Load;
            butScroll.Click += ButScroll_Click;
            butScreenshotDGV.Click += ButScreenshotDGV_Click;
        }

        SaveFileDialog _screenSaver = new SaveFileDialog { Filter = "PNG|*.png|Jpeg|*.jpg|Bitmap Image|*.bmp" };
        private async void ButScreenshotDGV_Click(object sender, EventArgs e)
        {
            if (_screenSaver.ShowDialog() != DialogResult.OK) return;

            _screenSaver.DefaultExt = Path.GetExtension(_screenSaver.FileName);
            var control = (Control)sender;
            control.Enabled = false;
            await Task.Run(() =>
            {
                Thread.Sleep(200);
                Image image = new Bitmap(dataGridViewTable.Size.Width, dataGridViewTable.Size.Height, CreateGraphics());
                var g = Graphics.FromImage(image);
                g.CopyFromScreen(Location.X + dataGridViewTable.Location.X, Location.Y + dataGridViewTable.Location.Y, 0, 0, dataGridViewTable.Size);
                ImageFormat format = GetImageFormatFromExtension(Path.GetExtension(_screenSaver.FileName));
                image.Save(_screenSaver.FileName, format);
            });
            control.Enabled = true;
        }

        private static ImageFormat GetImageFormatFromExtension(string extension) => GetImageFormatFromExtension(extension, ImageFormat.Png);
        private static ImageFormat GetImageFormatFromExtension(string extension, ImageFormat defaultFormat)
        {
            switch (Path.GetExtension(extension))
            {
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".ico":
                    return ImageFormat.Icon;
                default:
                    return defaultFormat;
            }
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


            dataGridViewTable.Columns[0].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridViewTable.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewTable.Columns[2].DefaultCellStyle.BackColor = Color.YellowGreen;
        }

        private void trackBarTextSize_Scroll(object sender, EventArgs e)
        {
            dataGridViewTable.Font = new Font(dataGridViewTable.Font.FontFamily, trackBarTextSize.Value/10f);
            dataGridViewTable.AutoResizeRows();
            dataGridViewTable.AutoResizeColumns();
        }
    }
}
