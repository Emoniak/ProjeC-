namespace WindowsForms
{
    partial class ListeOptions
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.dataGridViewOptions = new System.Windows.Forms.DataGridView();
            this.Exit = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.richTextBoxOption = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(221, 9);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 2;
            this.search.Text = "rechercher";
            this.search.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions.Location = new System.Drawing.Point(12, 38);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.Size = new System.Drawing.Size(298, 232);
            this.dataGridViewOptions.TabIndex = 3;
            this.dataGridViewOptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOptions_CellContentClick);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(15, 415);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "sortir";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(221, 415);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 5;
            this.submit.Text = "valider";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOption
            // 
            this.richTextBoxOption.Location = new System.Drawing.Point(12, 276);
            this.richTextBoxOption.Name = "richTextBoxOption";
            this.richTextBoxOption.Size = new System.Drawing.Size(298, 133);
            this.richTextBoxOption.TabIndex = 6;
            this.richTextBoxOption.Text = "";
            // 
            // ListeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 450);
            this.Controls.Add(this.richTextBoxOption);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.dataGridViewOptions);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "ListeOptions";
            this.Text = "ListeOptions";
            this.Load += new System.EventHandler(this.ListeOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView dataGridViewOptions;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.RichTextBox richTextBoxOption;
    }
}