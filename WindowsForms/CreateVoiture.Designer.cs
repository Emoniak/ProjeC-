namespace WindowsForms
{
    partial class CreateVoiture
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
            this.comboBoxMarques = new System.Windows.Forms.ComboBox();
            this.comboBoxModeles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewOptions = new System.Windows.Forms.DataGridView();
            this.AddOption = new System.Windows.Forms.Button();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMarques
            // 
            this.comboBoxMarques.FormattingEnabled = true;
            this.comboBoxMarques.Location = new System.Drawing.Point(126, 46);
            this.comboBoxMarques.Name = "comboBoxMarques";
            this.comboBoxMarques.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMarques.TabIndex = 0;
            this.comboBoxMarques.TextChanged += new System.EventHandler(this.comboBoxMarques_TextChanged);
            // 
            // comboBoxModeles
            // 
            this.comboBoxModeles.FormattingEnabled = true;
            this.comboBoxModeles.Location = new System.Drawing.Point(126, 73);
            this.comboBoxModeles.Name = "comboBoxModeles";
            this.comboBoxModeles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModeles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marque";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modèle";
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions.Location = new System.Drawing.Point(18, 112);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.Size = new System.Drawing.Size(240, 326);
            this.dataGridViewOptions.TabIndex = 4;
            // 
            // AddOption
            // 
            this.AddOption.Location = new System.Drawing.Point(264, 112);
            this.AddOption.Name = "AddOption";
            this.AddOption.Size = new System.Drawing.Size(81, 54);
            this.AddOption.TabIndex = 5;
            this.AddOption.Text = "Ajouter une/des option(s)";
            this.AddOption.UseVisualStyleBackColor = true;
            this.AddOption.Click += new System.EventHandler(this.AddOption_Click);
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(126, 15);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypes.TabIndex = 0;
            this.comboBoxTypes.TextChanged += new System.EventHandler(this.comboBoxTypes_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type de véhicule";
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(18, 457);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(81, 34);
            this.exit.TabIndex = 6;
            this.exit.Text = "Annuler";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(264, 457);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(81, 34);
            this.Submit.TabIndex = 7;
            this.Submit.Text = "Valider";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(145, 457);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 34);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Rafraichir";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // CreateVoiture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 503);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.AddOption);
            this.Controls.Add(this.dataGridViewOptions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTypes);
            this.Controls.Add(this.comboBoxModeles);
            this.Controls.Add(this.comboBoxMarques);
            this.Name = "CreateVoiture";
            this.Text = "CreateVoiture";
            this.Load += new System.EventHandler(this.CreateVoiture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMarques;
        private System.Windows.Forms.ComboBox comboBoxModeles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewOptions;
        private System.Windows.Forms.Button AddOption;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button btnRefresh;
    }
}