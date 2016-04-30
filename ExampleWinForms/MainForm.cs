using Encode;
using ExampleWinForms.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace ExampleWinForms
{
    public partial class MainForm : Form
    {
        Settings _settings = new Settings();
        public MainForm()
        {
            InitializeComponent();
            Size = _settings.MainFormSize;
            Location = _settings.MainFormLocation;
            numericUpDownAccuracy.Value = _settings.MainFormAccuracy;
            fieldEncodingText.Font = new System.Drawing.Font(fieldEncodingText.Font.FontFamily, _settings.MainFormFieldFontSize);
            trackBarTextSize.Value =(int)(_settings.MainFormFieldFontSize*10);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            _settings.MainFormLocation = Location;
            _settings.MainFormSize = Size;
            _settings.MainFormFieldFontSize = fieldEncodingText.Font.Size;
            _settings.MainFormAccuracy = (int)numericUpDownAccuracy.Value;
            _settings.Save();
            base.OnClosed(e);
        }

        OpenFileDialog _openEncodeFile = new OpenFileDialog();
        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_openEncodeFile.ShowDialog() != DialogResult.OK) return;

            fieldEncodingText.Text = File.ReadAllText(_openEncodeFile.FileName);
        }

        private void butEncode_Click(object sender, EventArgs e)
        {
            int accuracy = (int)numericUpDownAccuracy.Value;
            var coefs = Huffman.GetCoefs(fieldEncodingText.Text, accuracy);
            if (coefs.Count <= 1) return;
            var table = Huffman.Execute(coefs, accuracy);

            new ShowTable(table, coefs, accuracy).ShowDialog();
        }

        private void butUpText_Click(object sender, EventArgs e)
        {
            fieldEncodingText.Text = fieldEncodingText.Text.ToUpper();
        }

        private void butDownText_Click(object sender, EventArgs e)
        {
            fieldEncodingText.Text = fieldEncodingText.Text.ToLower();
        }

        private void trackBarTextSize_Scroll(object sender, EventArgs e)
        {
            fieldEncodingText.Font = new System.Drawing.Font(fieldEncodingText.Font.FontFamily, trackBarTextSize.Value / 10.0f);
        }
    }
}
