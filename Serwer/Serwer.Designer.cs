namespace Serwer
{
    partial class Serwer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.PortInput = new System.Windows.Forms.NumericUpDown();
            this.HostButton = new System.Windows.Forms.Button();
            this.AddressInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(9, 97);
            this.PortInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(120, 20);
            this.PortInput.TabIndex = 0;
            // 
            // HostButton
            // 
            this.HostButton.Location = new System.Drawing.Point(9, 373);
            this.HostButton.Name = "HostButton";
            this.HostButton.Size = new System.Drawing.Size(183, 47);
            this.HostButton.TabIndex = 1;
            this.HostButton.Text = "Host";
            this.HostButton.UseVisualStyleBackColor = true;
            this.HostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // AddressInput
            // 
            this.AddressInput.Location = new System.Drawing.Point(6, 49);
            this.AddressInput.Name = "AddressInput";
            this.AddressInput.Size = new System.Drawing.Size(100, 20);
            this.AddressInput.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HostButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PortInput);
            this.groupBox1.Controls.Add(this.AddressInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 426);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type Address:";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(222, 24);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(549, 398);
            this.LogBox.TabIndex = 4;
            this.LogBox.Text = "";
            // 
            // Serwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Serwer";
            this.Text = "Server Boży";
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PortInput;
        private System.Windows.Forms.Button HostButton;
        private System.Windows.Forms.TextBox AddressInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox LogBox;
    }
}

