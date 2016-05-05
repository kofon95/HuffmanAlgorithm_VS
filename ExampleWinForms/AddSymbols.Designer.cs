namespace ExampleWinForms
{
    partial class AddSymbols
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAdditionSymbols = new System.Windows.Forms.TextBox();
            this.numericUpDownCountAdditionSymbol = new System.Windows.Forms.NumericUpDown();
            this.butAddSymbols = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountAdditionSymbol)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxAdditionSymbols
            // 
            this.textBoxAdditionSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAdditionSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxAdditionSymbols.Location = new System.Drawing.Point(13, 14);
            this.textBoxAdditionSymbols.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAdditionSymbols.Name = "textBoxAdditionSymbols";
            this.textBoxAdditionSymbols.Size = new System.Drawing.Size(341, 29);
            this.textBoxAdditionSymbols.TabIndex = 0;
            // 
            // numericUpDownCountAdditionSymbol
            // 
            this.numericUpDownCountAdditionSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCountAdditionSymbol.Location = new System.Drawing.Point(201, 49);
            this.numericUpDownCountAdditionSymbol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownCountAdditionSymbol.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountAdditionSymbol.Name = "numericUpDownCountAdditionSymbol";
            this.numericUpDownCountAdditionSymbol.Size = new System.Drawing.Size(153, 26);
            this.numericUpDownCountAdditionSymbol.TabIndex = 1;
            this.numericUpDownCountAdditionSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownCountAdditionSymbol.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // butAddSymbols
            // 
            this.butAddSymbols.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.butAddSymbols.Location = new System.Drawing.Point(79, 98);
            this.butAddSymbols.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butAddSymbols.Name = "butAddSymbols";
            this.butAddSymbols.Size = new System.Drawing.Size(199, 38);
            this.butAddSymbols.TabIndex = 2;
            this.butAddSymbols.Text = "Добавить";
            this.butAddSymbols.UseVisualStyleBackColor = true;
            this.butAddSymbols.Click += new System.EventHandler(this.butAddSymbols_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество символов:";
            // 
            // AddSymbols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butAddSymbols);
            this.Controls.Add(this.numericUpDownCountAdditionSymbol);
            this.Controls.Add(this.textBoxAdditionSymbols);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddSymbols";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Добавление символов";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountAdditionSymbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAdditionSymbols;
        private System.Windows.Forms.NumericUpDown numericUpDownCountAdditionSymbol;
        private System.Windows.Forms.Button butAddSymbols;
        private System.Windows.Forms.Label label1;
    }
}