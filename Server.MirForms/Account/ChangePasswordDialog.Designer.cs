
namespace Server
{
    partial class ChangePasswordDialog
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
            PasswordTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            //
            // PasswordTextBox
            //
            PasswordTextBox.Location = new Point(18, 18);
            PasswordTextBox.Margin = new Padding(4, 5, 4, 5);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(272, 27);
            PasswordTextBox.TabIndex = 0;
            //
            // okButton
            //
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(18, 58);
            okButton.Margin = new Padding(4, 5, 4, 5);
            okButton.Name = "okButton";
            okButton.Size = new Size(112, 35);
            okButton.TabIndex = 1;
            okButton.Text = "确定";
            okButton.UseVisualStyleBackColor = true;
            //
            // cancelButton
            //
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(180, 58);
            cancelButton.Margin = new Padding(4, 5, 4, 5);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 35);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            //
            // ChangePasswordDialog
            //
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 108);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(PasswordTextBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ChangePasswordDialog";
            Text = "设置密码";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.TextBox PasswordTextBox;
    }
}
