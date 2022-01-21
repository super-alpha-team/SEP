namespace SEP.DEMO
{
    partial class Dashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.products = new System.Windows.Forms.Button();
            this.categories = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEP";
            // 
            // products
            // 
            this.products.Location = new System.Drawing.Point(436, 207);
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(112, 34);
            this.products.TabIndex = 1;
            this.products.Text = "Categories";
            this.products.UseVisualStyleBackColor = true;
            this.products.Click += new System.EventHandler(this.categories_Click);
            // 
            // categories
            // 
            this.categories.Location = new System.Drawing.Point(190, 207);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(112, 34);
            this.categories.TabIndex = 2;
            this.categories.Text = "Products";
            this.categories.UseVisualStyleBackColor = true;
            this.categories.Click += new System.EventHandler(this.products_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 404);
            this.button1.Name = "admin";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Admin Board";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.categories);
            this.Controls.Add(this.products);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button products;
        private Button categories;
        private Button button1;
    }
}