namespace ApplianceRepair
{
    partial class Admin
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
            this.ordersUpdate = new System.Windows.Forms.Button();
            this.productsUpdate = new System.Windows.Forms.Button();
            this.executionsUpdate = new System.Windows.Forms.Button();
            this.employeesUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ordersUpdate
            // 
            this.ordersUpdate.Location = new System.Drawing.Point(42, 219);
            this.ordersUpdate.Name = "ordersUpdate";
            this.ordersUpdate.Size = new System.Drawing.Size(199, 67);
            this.ordersUpdate.TabIndex = 7;
            this.ordersUpdate.Text = "Orders";
            this.ordersUpdate.UseVisualStyleBackColor = true;
            this.ordersUpdate.Click += new System.EventHandler(this.ordersUpdate_Click);
            // 
            // productsUpdate
            // 
            this.productsUpdate.Location = new System.Drawing.Point(42, 146);
            this.productsUpdate.Name = "productsUpdate";
            this.productsUpdate.Size = new System.Drawing.Size(199, 67);
            this.productsUpdate.TabIndex = 6;
            this.productsUpdate.Text = "Products";
            this.productsUpdate.UseVisualStyleBackColor = true;
            this.productsUpdate.Click += new System.EventHandler(this.productsUpdate_Click);
            // 
            // executionsUpdate
            // 
            this.executionsUpdate.Location = new System.Drawing.Point(42, 292);
            this.executionsUpdate.Name = "executionsUpdate";
            this.executionsUpdate.Size = new System.Drawing.Size(199, 67);
            this.executionsUpdate.TabIndex = 5;
            this.executionsUpdate.Text = "Executions";
            this.executionsUpdate.UseVisualStyleBackColor = true;
            this.executionsUpdate.Click += new System.EventHandler(this.executionsUpdate_Click);
            // 
            // employeesUpdate
            // 
            this.employeesUpdate.Location = new System.Drawing.Point(42, 73);
            this.employeesUpdate.Name = "employeesUpdate";
            this.employeesUpdate.Size = new System.Drawing.Size(199, 67);
            this.employeesUpdate.TabIndex = 4;
            this.employeesUpdate.Text = "Employees";
            this.employeesUpdate.UseVisualStyleBackColor = true;
            this.employeesUpdate.Click += new System.EventHandler(this.employeesUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выбере таблицу для просмотра \r\n и/или редактирования";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ordersUpdate);
            this.Controls.Add(this.productsUpdate);
            this.Controls.Add(this.executionsUpdate);
            this.Controls.Add(this.employeesUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Admin";
            this.Text = "Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ordersUpdate;
        private System.Windows.Forms.Button productsUpdate;
        private System.Windows.Forms.Button executionsUpdate;
        private System.Windows.Forms.Button employeesUpdate;
        private System.Windows.Forms.Label label1;
    }
}