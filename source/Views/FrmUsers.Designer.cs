
namespace cadalzo.demo
{
    partial class FrmUser
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
            this.LblEncoder = new System.Windows.Forms.Label();
            this.GrdUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnUserCreate = new System.Windows.Forms.Button();
            this.BtnUsersUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrdUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encoder";
            // 
            // LblEncoder
            // 
            this.LblEncoder.AutoSize = true;
            this.LblEncoder.Location = new System.Drawing.Point(66, 275);
            this.LblEncoder.Name = "LblEncoder";
            this.LblEncoder.Size = new System.Drawing.Size(0, 13);
            this.LblEncoder.TabIndex = 1;
            // 
            // GrdUsers
            // 
            this.GrdUsers.AllowUserToAddRows = false;
            this.GrdUsers.AllowUserToDeleteRows = false;
            this.GrdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdUsers.Location = new System.Drawing.Point(12, 50);
            this.GrdUsers.Name = "GrdUsers";
            this.GrdUsers.ReadOnly = true;
            this.GrdUsers.Size = new System.Drawing.Size(478, 209);
            this.GrdUsers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "List of Users";
            // 
            // BtnUserCreate
            // 
            this.BtnUserCreate.Location = new System.Drawing.Point(328, 13);
            this.BtnUserCreate.Name = "BtnUserCreate";
            this.BtnUserCreate.Size = new System.Drawing.Size(78, 34);
            this.BtnUserCreate.TabIndex = 4;
            this.BtnUserCreate.Text = "New User";
            this.BtnUserCreate.UseVisualStyleBackColor = true;
            // 
            // BtnUsersUpdate
            // 
            this.BtnUsersUpdate.Enabled = false;
            this.BtnUsersUpdate.Location = new System.Drawing.Point(412, 13);
            this.BtnUsersUpdate.Name = "BtnUsersUpdate";
            this.BtnUsersUpdate.Size = new System.Drawing.Size(78, 34);
            this.BtnUsersUpdate.TabIndex = 5;
            this.BtnUsersUpdate.Text = "Update User";
            this.BtnUsersUpdate.UseVisualStyleBackColor = true;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 300);
            this.Controls.Add(this.BtnUsersUpdate);
            this.Controls.Add(this.BtnUserCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GrdUsers);
            this.Controls.Add(this.LblEncoder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblEncoder;
        private System.Windows.Forms.DataGridView GrdUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnUserCreate;
        private System.Windows.Forms.Button BtnUsersUpdate;
    }
}