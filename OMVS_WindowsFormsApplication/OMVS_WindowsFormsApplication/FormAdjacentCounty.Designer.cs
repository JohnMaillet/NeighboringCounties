namespace OMVS_WindowsFormsApplication
{
    partial class FormAdjacentValidation
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
            this.buttonValidateAdjacency = new System.Windows.Forms.Button();
            this.textBoxCounty1 = new System.Windows.Forms.TextBox();
            this.textBoxCounty2 = new System.Windows.Forms.TextBox();
            this.labelCounty1 = new System.Windows.Forms.Label();
            this.labelCounty2 = new System.Windows.Forms.Label();
            this.labelResultDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonValidateAdjacency
            // 
            this.buttonValidateAdjacency.Location = new System.Drawing.Point(70, 111);
            this.buttonValidateAdjacency.Name = "buttonValidateAdjacency";
            this.buttonValidateAdjacency.Size = new System.Drawing.Size(75, 23);
            this.buttonValidateAdjacency.TabIndex = 0;
            this.buttonValidateAdjacency.Text = "Validate";
            this.buttonValidateAdjacency.UseVisualStyleBackColor = true;
            this.buttonValidateAdjacency.Click += new System.EventHandler(this.buttonValidateAdjacency_Click);
            // 
            // textBoxCounty1
            // 
            this.textBoxCounty1.Location = new System.Drawing.Point(70, 30);
            this.textBoxCounty1.Name = "textBoxCounty1";
            this.textBoxCounty1.Size = new System.Drawing.Size(100, 20);
            this.textBoxCounty1.TabIndex = 1;
            this.textBoxCounty1.Enter += new System.EventHandler(this.textBoxCounty1_Enter);
            // 
            // textBoxCounty2
            // 
            this.textBoxCounty2.Location = new System.Drawing.Point(70, 73);
            this.textBoxCounty2.Name = "textBoxCounty2";
            this.textBoxCounty2.Size = new System.Drawing.Size(100, 20);
            this.textBoxCounty2.TabIndex = 2;
            this.textBoxCounty2.Enter += new System.EventHandler(this.textBoxCounty2_Enter);
            // 
            // labelCounty1
            // 
            this.labelCounty1.AutoSize = true;
            this.labelCounty1.Location = new System.Drawing.Point(70, 13);
            this.labelCounty1.Name = "labelCounty1";
            this.labelCounty1.Size = new System.Drawing.Size(110, 13);
            this.labelCounty1.TabIndex = 3;
            this.labelCounty1.Text = "County 1 map number";
            // 
            // labelCounty2
            // 
            this.labelCounty2.AutoSize = true;
            this.labelCounty2.Location = new System.Drawing.Point(70, 57);
            this.labelCounty2.Name = "labelCounty2";
            this.labelCounty2.Size = new System.Drawing.Size(110, 13);
            this.labelCounty2.TabIndex = 4;
            this.labelCounty2.Text = "County 2 map number";
            // 
            // labelResultDisplay
            // 
            this.labelResultDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultDisplay.Location = new System.Drawing.Point(205, 30);
            this.labelResultDisplay.Name = "labelResultDisplay";
            this.labelResultDisplay.Size = new System.Drawing.Size(500, 168);
            this.labelResultDisplay.TabIndex = 5;
            // 
            // FormAdjacentValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 353);
            this.Controls.Add(this.labelResultDisplay);
            this.Controls.Add(this.labelCounty2);
            this.Controls.Add(this.labelCounty1);
            this.Controls.Add(this.textBoxCounty2);
            this.Controls.Add(this.textBoxCounty1);
            this.Controls.Add(this.buttonValidateAdjacency);
            this.Name = "FormAdjacentValidation";
            this.Text = "County Adjacency Validation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormAdjacentValidation_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonValidateAdjacency;
        private System.Windows.Forms.TextBox textBoxCounty1;
        private System.Windows.Forms.TextBox textBoxCounty2;
        private System.Windows.Forms.Label labelCounty1;
        private System.Windows.Forms.Label labelCounty2;
        private System.Windows.Forms.Label labelResultDisplay;
    }
}

