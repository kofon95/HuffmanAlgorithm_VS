using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExampleWinForms
{
    public partial class AddSymbols : Form
    {
        public string Symbols { get; private set; }
        public AddSymbols()
        {
            InitializeComponent();
            Location = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 55);
        }

        private void butAddSymbols_Click(object sender, EventArgs e)
        {
            Symbols = MultiplyString(textBoxAdditionSymbols.Text, (int)numericUpDownCountAdditionSymbol.Value);
            DialogResult = DialogResult.OK;
            //Close();
        }

        static string MultiplyString(string str, int count)
        {
            var builder = new StringBuilder(str.Length*count);
            for (int i = 0; i < count; i++)
                builder.Append(str);
            return builder.ToString();
        }
    }
}
