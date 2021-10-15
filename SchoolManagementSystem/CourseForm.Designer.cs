
namespace SchoolManagementSystem
{
    partial class CourseForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_State = new System.Windows.Forms.ComboBox();
            this.cmb_Name = new System.Windows.Forms.ComboBox();
            this.cmb_Church = new System.Windows.Forms.ComboBox();
            this.cmb_Superint = new System.Windows.Forms.ComboBox();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.btn_Clear = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_Add = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Superintendency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Church";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Amount";
            // 
            // cmb_State
            // 
            this.cmb_State.FormattingEnabled = true;
            this.cmb_State.Location = new System.Drawing.Point(77, 80);
            this.cmb_State.Name = "cmb_State";
            this.cmb_State.Size = new System.Drawing.Size(156, 26);
            this.cmb_State.TabIndex = 5;
            // 
            // cmb_Name
            // 
            this.cmb_Name.FormattingEnabled = true;
            this.cmb_Name.Location = new System.Drawing.Point(634, 137);
            this.cmb_Name.Name = "cmb_Name";
            this.cmb_Name.Size = new System.Drawing.Size(156, 26);
            this.cmb_Name.TabIndex = 6;
            // 
            // cmb_Church
            // 
            this.cmb_Church.FormattingEnabled = true;
            this.cmb_Church.Location = new System.Drawing.Point(81, 138);
            this.cmb_Church.Name = "cmb_Church";
            this.cmb_Church.Size = new System.Drawing.Size(156, 26);
            this.cmb_Church.TabIndex = 7;
            // 
            // cmb_Superint
            // 
            this.cmb_Superint.FormattingEnabled = true;
            this.cmb_Superint.Location = new System.Drawing.Point(634, 79);
            this.cmb_Superint.Name = "cmb_Superint";
            this.cmb_Superint.Size = new System.Drawing.Size(156, 26);
            this.cmb_Superint.TabIndex = 8;
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(343, 192);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(156, 26);
            this.txt_amount.TabIndex = 9;
            // 
            // btn_Clear
            // 
            this.btn_Clear.CheckedState.Parent = this.btn_Clear;
            this.btn_Clear.CustomImages.Parent = this.btn_Clear;
            this.btn_Clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Clear.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Clear.DisabledState.Parent = this.btn_Clear;
            this.btn_Clear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.HoverState.Parent = this.btn_Clear;
            this.btn_Clear.Location = new System.Drawing.Point(77, 306);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.ShadowDecoration.Parent = this.btn_Clear;
            this.btn_Clear.Size = new System.Drawing.Size(75, 40);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "Clear";
            // 
            // btn_Add
            // 
            this.btn_Add.CheckedState.Parent = this.btn_Add;
            this.btn_Add.CustomImages.Parent = this.btn_Add;
            this.btn_Add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Add.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Add.DisabledState.Parent = this.btn_Add;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.HoverState.Parent = this.btn_Add;
            this.btn_Add.Location = new System.Drawing.Point(437, 306);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.ShadowDecoration.Parent = this.btn_Add;
            this.btn_Add.Size = new System.Drawing.Size(75, 40);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "Add";
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 555);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.cmb_Superint);
            this.Controls.Add(this.cmb_Church);
            this.Controls.Add(this.cmb_Name);
            this.Controls.Add(this.cmb_State);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_State;
        private System.Windows.Forms.ComboBox cmb_Name;
        private System.Windows.Forms.ComboBox cmb_Church;
        private System.Windows.Forms.ComboBox cmb_Superint;
        private System.Windows.Forms.TextBox txt_amount;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Clear;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Add;
    }
}