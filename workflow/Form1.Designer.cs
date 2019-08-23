namespace workflow
{
    partial class login_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.a_sign_in_box = new System.Windows.Forms.GroupBox();
            this.a_sign_up_page_button = new System.Windows.Forms.Button();
            this.a_sign_in_button = new System.Windows.Forms.Button();
            this.a_sign_in_password_label = new System.Windows.Forms.Label();
            this.a_sign_in_password_text_box = new System.Windows.Forms.TextBox();
            this.a_sign_in_login_label = new System.Windows.Forms.Label();
            this.a_sign_in_login_text_box = new System.Windows.Forms.TextBox();
            this.a_sign_up_box = new System.Windows.Forms.GroupBox();
            this.a_sign_in_page_button = new System.Windows.Forms.Button();
            this.a_sign_up_button = new System.Windows.Forms.Button();
            this.a_sign_up_password_label = new System.Windows.Forms.Label();
            this.a_sign_up_password_text_box = new System.Windows.Forms.TextBox();
            this.a_sign_up_login_label = new System.Windows.Forms.Label();
            this.a_sign_up_login_text_box = new System.Windows.Forms.TextBox();
            this.a_sign_up_info_box = new System.Windows.Forms.Label();
            this.a_sign_in_info_box = new System.Windows.Forms.Label();
            this.a_sign_in_forgot_password_button = new System.Windows.Forms.Label();
            this.a_forgot_password_box = new System.Windows.Forms.GroupBox();
            this.a_forgot_password_login_label = new System.Windows.Forms.Label();
            this.a_forgot_password_login_text_box = new System.Windows.Forms.TextBox();
            this.a_forgot_password_send_button = new System.Windows.Forms.Button();
            this.a_forgot_password_info_box = new System.Windows.Forms.Label();
            this.a_sign_in_box.SuspendLayout();
            this.a_sign_up_box.SuspendLayout();
            this.a_forgot_password_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // a_sign_in_box
            // 
            this.a_sign_in_box.Controls.Add(this.a_sign_in_info_box);
            this.a_sign_in_box.Controls.Add(this.a_sign_in_forgot_password_button);
            this.a_sign_in_box.Controls.Add(this.a_sign_up_page_button);
            this.a_sign_in_box.Controls.Add(this.a_sign_in_button);
            this.a_sign_in_box.Controls.Add(this.a_sign_in_password_label);
            this.a_sign_in_box.Controls.Add(this.a_sign_in_password_text_box);
            this.a_sign_in_box.Controls.Add(this.a_sign_in_login_label);
            this.a_sign_in_box.Controls.Add(this.a_sign_in_login_text_box);
            this.a_sign_in_box.Location = new System.Drawing.Point(0, 0);
            this.a_sign_in_box.Name = "a_sign_in_box";
            this.a_sign_in_box.Size = new System.Drawing.Size(448, 265);
            this.a_sign_in_box.TabIndex = 0;
            this.a_sign_in_box.TabStop = false;
            this.a_sign_in_box.Text = "Sign in";
            this.a_sign_in_box.Visible = false;
            this.a_sign_in_box.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // a_sign_up_page_button
            // 
            this.a_sign_up_page_button.FlatAppearance.BorderSize = 0;
            this.a_sign_up_page_button.Location = new System.Drawing.Point(9, 110);
            this.a_sign_up_page_button.Name = "a_sign_up_page_button";
            this.a_sign_up_page_button.Size = new System.Drawing.Size(204, 23);
            this.a_sign_up_page_button.TabIndex = 5;
            this.a_sign_up_page_button.Text = "sign up";
            this.a_sign_up_page_button.UseVisualStyleBackColor = false;
            this.a_sign_up_page_button.Click += new System.EventHandler(this.a_sign_up_page_button_Click);
            // 
            // a_sign_in_button
            // 
            this.a_sign_in_button.Location = new System.Drawing.Point(9, 80);
            this.a_sign_in_button.Name = "a_sign_in_button";
            this.a_sign_in_button.Size = new System.Drawing.Size(204, 23);
            this.a_sign_in_button.TabIndex = 4;
            this.a_sign_in_button.Text = "send";
            this.a_sign_in_button.UseVisualStyleBackColor = true;
            this.a_sign_in_button.Click += new System.EventHandler(this.a_sign_in_button_Click);
            // 
            // a_sign_in_password_label
            // 
            this.a_sign_in_password_label.AutoSize = true;
            this.a_sign_in_password_label.Location = new System.Drawing.Point(6, 48);
            this.a_sign_in_password_label.Name = "a_sign_in_password_label";
            this.a_sign_in_password_label.Size = new System.Drawing.Size(58, 13);
            this.a_sign_in_password_label.TabIndex = 3;
            this.a_sign_in_password_label.Text = "password :";
            // 
            // a_sign_in_password_text_box
            // 
            this.a_sign_in_password_text_box.Location = new System.Drawing.Point(78, 45);
            this.a_sign_in_password_text_box.Name = "a_sign_in_password_text_box";
            this.a_sign_in_password_text_box.Size = new System.Drawing.Size(135, 20);
            this.a_sign_in_password_text_box.TabIndex = 2;
            this.a_sign_in_password_text_box.TextChanged += new System.EventHandler(this.a_password_text_box_TextChanged);
            // 
            // a_sign_in_login_label
            // 
            this.a_sign_in_login_label.AutoSize = true;
            this.a_sign_in_login_label.Location = new System.Drawing.Point(6, 22);
            this.a_sign_in_login_label.Name = "a_sign_in_login_label";
            this.a_sign_in_login_label.Size = new System.Drawing.Size(35, 13);
            this.a_sign_in_login_label.TabIndex = 1;
            this.a_sign_in_login_label.Text = "login :";
            // 
            // a_sign_in_login_text_box
            // 
            this.a_sign_in_login_text_box.Location = new System.Drawing.Point(78, 19);
            this.a_sign_in_login_text_box.Name = "a_sign_in_login_text_box";
            this.a_sign_in_login_text_box.Size = new System.Drawing.Size(135, 20);
            this.a_sign_in_login_text_box.TabIndex = 0;
            this.a_sign_in_login_text_box.TextChanged += new System.EventHandler(this.a_login_text_box_TextChanged);
            // 
            // a_sign_up_box
            // 
            this.a_sign_up_box.Controls.Add(this.a_sign_up_info_box);
            this.a_sign_up_box.Controls.Add(this.a_sign_in_page_button);
            this.a_sign_up_box.Controls.Add(this.a_sign_up_button);
            this.a_sign_up_box.Controls.Add(this.a_sign_up_password_label);
            this.a_sign_up_box.Controls.Add(this.a_sign_up_password_text_box);
            this.a_sign_up_box.Controls.Add(this.a_sign_up_login_label);
            this.a_sign_up_box.Controls.Add(this.a_sign_up_login_text_box);
            this.a_sign_up_box.Location = new System.Drawing.Point(12, 12);
            this.a_sign_up_box.Name = "a_sign_up_box";
            this.a_sign_up_box.Size = new System.Drawing.Size(448, 265);
            this.a_sign_up_box.TabIndex = 1;
            this.a_sign_up_box.TabStop = false;
            this.a_sign_up_box.Text = "Sign up";
            // 
            // a_sign_in_page_button
            // 
            this.a_sign_in_page_button.FlatAppearance.BorderSize = 0;
            this.a_sign_in_page_button.Location = new System.Drawing.Point(9, 110);
            this.a_sign_in_page_button.Name = "a_sign_in_page_button";
            this.a_sign_in_page_button.Size = new System.Drawing.Size(204, 23);
            this.a_sign_in_page_button.TabIndex = 11;
            this.a_sign_in_page_button.Text = "sign in";
            this.a_sign_in_page_button.UseVisualStyleBackColor = false;
            this.a_sign_in_page_button.Click += new System.EventHandler(this.a_sign_in_page_button_Click);
            // 
            // a_sign_up_button
            // 
            this.a_sign_up_button.Location = new System.Drawing.Point(9, 80);
            this.a_sign_up_button.Name = "a_sign_up_button";
            this.a_sign_up_button.Size = new System.Drawing.Size(204, 23);
            this.a_sign_up_button.TabIndex = 10;
            this.a_sign_up_button.Text = "send";
            this.a_sign_up_button.UseVisualStyleBackColor = true;
            this.a_sign_up_button.Click += new System.EventHandler(this.a_sign_up_button_Click);
            // 
            // a_sign_up_password_label
            // 
            this.a_sign_up_password_label.AutoSize = true;
            this.a_sign_up_password_label.Location = new System.Drawing.Point(6, 48);
            this.a_sign_up_password_label.Name = "a_sign_up_password_label";
            this.a_sign_up_password_label.Size = new System.Drawing.Size(58, 13);
            this.a_sign_up_password_label.TabIndex = 9;
            this.a_sign_up_password_label.Text = "password :";
            // 
            // a_sign_up_password_text_box
            // 
            this.a_sign_up_password_text_box.Location = new System.Drawing.Point(78, 45);
            this.a_sign_up_password_text_box.Name = "a_sign_up_password_text_box";
            this.a_sign_up_password_text_box.Size = new System.Drawing.Size(135, 20);
            this.a_sign_up_password_text_box.TabIndex = 8;
            // 
            // a_sign_up_login_label
            // 
            this.a_sign_up_login_label.AutoSize = true;
            this.a_sign_up_login_label.Location = new System.Drawing.Point(6, 22);
            this.a_sign_up_login_label.Name = "a_sign_up_login_label";
            this.a_sign_up_login_label.Size = new System.Drawing.Size(35, 13);
            this.a_sign_up_login_label.TabIndex = 7;
            this.a_sign_up_login_label.Text = "login :";
            // 
            // a_sign_up_login_text_box
            // 
            this.a_sign_up_login_text_box.Location = new System.Drawing.Point(78, 19);
            this.a_sign_up_login_text_box.Name = "a_sign_up_login_text_box";
            this.a_sign_up_login_text_box.Size = new System.Drawing.Size(135, 20);
            this.a_sign_up_login_text_box.TabIndex = 6;
            // 
            // a_sign_up_info_box
            // 
            this.a_sign_up_info_box.AutoSize = true;
            this.a_sign_up_info_box.ForeColor = System.Drawing.Color.Red;
            this.a_sign_up_info_box.Location = new System.Drawing.Point(9, 140);
            this.a_sign_up_info_box.Name = "a_sign_up_info_box";
            this.a_sign_up_info_box.Size = new System.Drawing.Size(0, 13);
            this.a_sign_up_info_box.TabIndex = 12;
            // 
            // a_sign_in_info_box
            // 
            this.a_sign_in_info_box.AutoSize = true;
            this.a_sign_in_info_box.ForeColor = System.Drawing.Color.Red;
            this.a_sign_in_info_box.Location = new System.Drawing.Point(15, 140);
            this.a_sign_in_info_box.Name = "a_sign_in_info_box";
            this.a_sign_in_info_box.Size = new System.Drawing.Size(0, 13);
            this.a_sign_in_info_box.TabIndex = 13;
            // 
            // a_sign_in_forgot_password_button
            // 
            this.a_sign_in_forgot_password_button.AutoSize = true;
            this.a_sign_in_forgot_password_button.ForeColor = System.Drawing.Color.Lime;
            this.a_sign_in_forgot_password_button.Location = new System.Drawing.Point(15, 162);
            this.a_sign_in_forgot_password_button.Name = "a_sign_in_forgot_password_button";
            this.a_sign_in_forgot_password_button.Size = new System.Drawing.Size(91, 13);
            this.a_sign_in_forgot_password_button.TabIndex = 13;
            this.a_sign_in_forgot_password_button.Text = "Забыли пароль?";
            this.a_sign_in_forgot_password_button.Visible = false;
            this.a_sign_in_forgot_password_button.Click += new System.EventHandler(this.a_sign_in_forgot_password_button_Click);
            // 
            // a_forgot_password_box
            // 
            this.a_forgot_password_box.Controls.Add(this.a_forgot_password_send_button);
            this.a_forgot_password_box.Controls.Add(this.a_forgot_password_info_box);
            this.a_forgot_password_box.Controls.Add(this.a_forgot_password_login_label);
            this.a_forgot_password_box.Controls.Add(this.a_forgot_password_login_text_box);
            this.a_forgot_password_box.Location = new System.Drawing.Point(12, 15);
            this.a_forgot_password_box.Name = "a_forgot_password_box";
            this.a_forgot_password_box.Size = new System.Drawing.Size(448, 262);
            this.a_forgot_password_box.TabIndex = 2;
            this.a_forgot_password_box.TabStop = false;
            this.a_forgot_password_box.Text = "Forgot password";
            // 
            // a_forgot_password_login_label
            // 
            this.a_forgot_password_login_label.AutoSize = true;
            this.a_forgot_password_login_label.Location = new System.Drawing.Point(6, 22);
            this.a_forgot_password_login_label.Name = "a_forgot_password_login_label";
            this.a_forgot_password_login_label.Size = new System.Drawing.Size(35, 13);
            this.a_forgot_password_login_label.TabIndex = 2;
            this.a_forgot_password_login_label.Text = "login :";
            // 
            // a_forgot_password_login_text_box
            // 
            this.a_forgot_password_login_text_box.Location = new System.Drawing.Point(78, 19);
            this.a_forgot_password_login_text_box.Name = "a_forgot_password_login_text_box";
            this.a_forgot_password_login_text_box.Size = new System.Drawing.Size(135, 20);
            this.a_forgot_password_login_text_box.TabIndex = 3;
            // 
            // a_forgot_password_send_button
            // 
            this.a_forgot_password_send_button.Location = new System.Drawing.Point(12, 48);
            this.a_forgot_password_send_button.Name = "a_forgot_password_send_button";
            this.a_forgot_password_send_button.Size = new System.Drawing.Size(201, 23);
            this.a_forgot_password_send_button.TabIndex = 4;
            this.a_forgot_password_send_button.Text = "Отправить пароль";
            this.a_forgot_password_send_button.UseVisualStyleBackColor = true;
            this.a_forgot_password_send_button.Click += new System.EventHandler(this.a_forgot_password_send_button_Click);
            // 
            // a_forgot_password_info_box
            // 
            this.a_forgot_password_info_box.AutoSize = true;
            this.a_forgot_password_info_box.ForeColor = System.Drawing.Color.Red;
            this.a_forgot_password_info_box.Location = new System.Drawing.Point(15, 77);
            this.a_forgot_password_info_box.Name = "a_forgot_password_info_box";
            this.a_forgot_password_info_box.Size = new System.Drawing.Size(0, 13);
            this.a_forgot_password_info_box.TabIndex = 14;
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 450);
            this.Controls.Add(this.a_sign_in_box);
            this.Controls.Add(this.a_forgot_password_box);
            this.Controls.Add(this.a_sign_up_box);
            this.Name = "login_form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.a_sign_in_box.ResumeLayout(false);
            this.a_sign_in_box.PerformLayout();
            this.a_sign_up_box.ResumeLayout(false);
            this.a_sign_up_box.PerformLayout();
            this.a_forgot_password_box.ResumeLayout(false);
            this.a_forgot_password_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox a_sign_in_box;
        private System.Windows.Forms.TextBox a_sign_in_login_text_box;
        private System.Windows.Forms.Button a_sign_in_button;
        private System.Windows.Forms.Label a_sign_in_password_label;
        private System.Windows.Forms.TextBox a_sign_in_password_text_box;
        private System.Windows.Forms.Label a_sign_in_login_label;
        private System.Windows.Forms.Button a_sign_up_page_button;
        private System.Windows.Forms.GroupBox a_sign_up_box;
        private System.Windows.Forms.Button a_sign_in_page_button;
        private System.Windows.Forms.Button a_sign_up_button;
        private System.Windows.Forms.Label a_sign_up_password_label;
        private System.Windows.Forms.TextBox a_sign_up_password_text_box;
        private System.Windows.Forms.Label a_sign_up_login_label;
        private System.Windows.Forms.TextBox a_sign_up_login_text_box;
        private System.Windows.Forms.Label a_sign_up_info_box;
        private System.Windows.Forms.Label a_sign_in_info_box;
        private System.Windows.Forms.Label a_sign_in_forgot_password_button;
        private System.Windows.Forms.GroupBox a_forgot_password_box;
        private System.Windows.Forms.Button a_forgot_password_send_button;
        private System.Windows.Forms.Label a_forgot_password_login_label;
        private System.Windows.Forms.TextBox a_forgot_password_login_text_box;
        private System.Windows.Forms.Label a_forgot_password_info_box;
    }
}

