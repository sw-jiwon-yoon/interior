namespace interior.Dialogs
{
    partial class DlgObjCreate
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
            this.listType = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtObjname = new System.Windows.Forms.TextBox();
            this.txtUsrObj = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listType
            // 
            this.listType.FormattingEnabled = true;
            this.listType.ItemHeight = 15;
            this.listType.Items.AddRange(new object[] {
            "문",
            "창문",
            "컴퓨터",
            "장롱"});
            this.listType.Location = new System.Drawing.Point(44, 57);
            this.listType.Name = "listType";
            this.listType.Size = new System.Drawing.Size(139, 94);
            this.listType.TabIndex = 0;
            this.listType.Click += new System.EventHandler(this.listType_Click);
            this.listType.SelectedIndexChanged += new System.EventHandler(this.listType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "객체 타입";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "가로";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "세로";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(298, 67);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 25);
            this.txtX.TabIndex = 4;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(298, 96);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 25);
            this.txtY.TabIndex = 5;
            this.txtY.TextChanged += new System.EventHandler(this.txtY_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(240, 195);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "추가";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(298, 127);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(100, 25);
            this.txtZ.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "높이";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(237, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 15);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "이름";
            // 
            // txtObjname
            // 
            this.txtObjname.Location = new System.Drawing.Point(298, 29);
            this.txtObjname.Name = "txtObjname";
            this.txtObjname.Size = new System.Drawing.Size(100, 25);
            this.txtObjname.TabIndex = 11;
            // 
            // txtUsrObj
            // 
            this.txtUsrObj.Location = new System.Drawing.Point(44, 164);
            this.txtUsrObj.Name = "txtUsrObj";
            this.txtUsrObj.Size = new System.Drawing.Size(139, 25);
            this.txtUsrObj.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "사용자 객체 추가";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DlgObjCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 230);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUsrObj);
            this.Controls.Add(this.txtObjname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listType);
            this.Name = "DlgObjCreate";
            this.Text = "객체 추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtObjname;
        private System.Windows.Forms.TextBox txtUsrObj;
        private System.Windows.Forms.Button button1;
    }
}