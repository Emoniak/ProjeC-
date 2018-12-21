namespace WindowsForms
{
    partial class Form1
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
            this.dataGridViewVoiture = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewOptions = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.createVoiture = new System.Windows.Forms.Button();
            this.devis = new System.Windows.Forms.Button();
            this.btnRafraichir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoiture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVoiture
            // 
            this.dataGridViewVoiture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoiture.Location = new System.Drawing.Point(12, 130);
            this.dataGridViewVoiture.Name = "dataGridViewVoiture";
            this.dataGridViewVoiture.Size = new System.Drawing.Size(433, 308);
            this.dataGridViewVoiture.TabIndex = 0;
            this.dataGridViewVoiture.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVoiture_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liste Voiture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions.Location = new System.Drawing.Point(451, 130);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.Size = new System.Drawing.Size(337, 308);
            this.dataGridViewOptions.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Option Voiture";
            // 
            // createVoiture
            // 
            this.createVoiture.Location = new System.Drawing.Point(678, 12);
            this.createVoiture.Name = "createVoiture";
            this.createVoiture.Size = new System.Drawing.Size(110, 37);
            this.createVoiture.TabIndex = 6;
            this.createVoiture.Text = "Créer une voiture";
            this.createVoiture.UseVisualStyleBackColor = true;
            this.createVoiture.Click += new System.EventHandler(this.createVoiture_Click);
            // 
            // devis
            // 
            this.devis.Location = new System.Drawing.Point(12, 12);
            this.devis.Name = "devis";
            this.devis.Size = new System.Drawing.Size(106, 37);
            this.devis.TabIndex = 7;
            this.devis.Text = "Devis en cours";
            this.devis.UseVisualStyleBackColor = true;
            this.devis.Click += new System.EventHandler(this.devis_Click);
            // 
            // btnRafraichir
            // 
            this.btnRafraichir.Location = new System.Drawing.Point(370, 12);
            this.btnRafraichir.Name = "btnRafraichir";
            this.btnRafraichir.Size = new System.Drawing.Size(75, 37);
            this.btnRafraichir.TabIndex = 8;
            this.btnRafraichir.Text = "Rafraichir";
            this.btnRafraichir.UseVisualStyleBackColor = true;
            this.btnRafraichir.Click += new System.EventHandler(this.btnRafraichir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRafraichir);
            this.Controls.Add(this.devis);
            this.Controls.Add(this.createVoiture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewOptions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewVoiture);
            this.Name = "Form1";
            this.Text = "Acceuil";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoiture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVoiture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createVoiture;
        private System.Windows.Forms.Button devis;
        private System.Windows.Forms.Button btnRafraichir;
    }
}