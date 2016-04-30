namespace ExampleWinForms
{
    partial class ShowTable
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
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.butScroll = new System.Windows.Forms.Button();
            this.trackBarTextSize = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTextSize)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToAddRows = false;
            this.dataGridViewTable.AllowUserToDeleteRows = false;
            this.dataGridViewTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.ReadOnly = true;
            this.dataGridViewTable.Size = new System.Drawing.Size(624, 391);
            this.dataGridViewTable.TabIndex = 0;
            // 
            // butScroll
            // 
            this.butScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butScroll.Location = new System.Drawing.Point(12, 405);
            this.butScroll.Name = "butScroll";
            this.butScroll.Size = new System.Drawing.Size(126, 32);
            this.butScroll.TabIndex = 1;
            this.butScroll.Text = "Смена режима";
            this.butScroll.UseVisualStyleBackColor = true;
            // 
            // trackBarTextSize
            // 
            this.trackBarTextSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTextSize.Location = new System.Drawing.Point(442, 398);
            this.trackBarTextSize.Maximum = 400;
            this.trackBarTextSize.Minimum = 50;
            this.trackBarTextSize.Name = "trackBarTextSize";
            this.trackBarTextSize.Size = new System.Drawing.Size(183, 45);
            this.trackBarTextSize.TabIndex = 6;
            this.trackBarTextSize.Value = 120;
            this.trackBarTextSize.Scroll += new System.EventHandler(this.trackBarTextSize_Scroll);
            // 
            // ShowTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 449);
            this.Controls.Add(this.trackBarTextSize);
            this.Controls.Add(this.butScroll);
            this.Controls.Add(this.dataGridViewTable);
            this.Name = "ShowTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Результат";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTextSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Button butScroll;
        private System.Windows.Forms.TrackBar trackBarTextSize;
    }
}