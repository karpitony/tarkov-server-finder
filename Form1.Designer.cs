﻿namespace tarkov_server_finder
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.labelCountryName = new System.Windows.Forms.Label();
            this.labelCityName = new System.Windows.Forms.Label();
            this.labelRegionName = new System.Windows.Forms.Label();
            this.labelIpAddress = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonChangePath = new System.Windows.Forms.Button();
            this.linkLabelHowToUse = new System.Windows.Forms.LinkLabel();
            this.linkLabelBugReport = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(105, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "딸각";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCountryName
            // 
            this.labelCountryName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCountryName.Font = new System.Drawing.Font("굴림", 16F);
            this.labelCountryName.Location = new System.Drawing.Point(105, 197);
            this.labelCountryName.Name = "labelCountryName";
            this.labelCountryName.Size = new System.Drawing.Size(266, 22);
            this.labelCountryName.TabIndex = 1;
            this.labelCountryName.Text = "국가: None";
            this.labelCountryName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCityName
            // 
            this.labelCityName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCityName.Font = new System.Drawing.Font("굴림", 16F);
            this.labelCityName.Location = new System.Drawing.Point(105, 279);
            this.labelCityName.Name = "labelCityName";
            this.labelCityName.Size = new System.Drawing.Size(266, 22);
            this.labelCityName.TabIndex = 2;
            this.labelCityName.Text = "도시: None";
            this.labelCityName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRegionName
            // 
            this.labelRegionName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRegionName.Font = new System.Drawing.Font("굴림", 16F);
            this.labelRegionName.Location = new System.Drawing.Point(105, 238);
            this.labelRegionName.Name = "labelRegionName";
            this.labelRegionName.Size = new System.Drawing.Size(266, 22);
            this.labelRegionName.TabIndex = 3;
            this.labelRegionName.Text = "지역: None";
            this.labelRegionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIpAddress
            // 
            this.labelIpAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelIpAddress.Font = new System.Drawing.Font("굴림", 16F);
            this.labelIpAddress.Location = new System.Drawing.Point(105, 156);
            this.labelIpAddress.Name = "labelIpAddress";
            this.labelIpAddress.Size = new System.Drawing.Size(266, 22);
            this.labelIpAddress.TabIndex = 4;
            this.labelIpAddress.Text = "IP 주소 : None";
            this.labelIpAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxFolderPath.Font = new System.Drawing.Font("굴림", 12F);
            this.textBoxFolderPath.Location = new System.Drawing.Point(15, 41);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.ReadOnly = true;
            this.textBoxFolderPath.Size = new System.Drawing.Size(376, 26);
            this.textBoxFolderPath.TabIndex = 5;
            // 
            // buttonChangePath
            // 
            this.buttonChangePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonChangePath.Font = new System.Drawing.Font("굴림", 14F);
            this.buttonChangePath.Location = new System.Drawing.Point(397, 41);
            this.buttonChangePath.Name = "buttonChangePath";
            this.buttonChangePath.Size = new System.Drawing.Size(75, 26);
            this.buttonChangePath.TabIndex = 6;
            this.buttonChangePath.Text = "변경";
            this.buttonChangePath.UseVisualStyleBackColor = true;
            this.buttonChangePath.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // linkLabelHowToUse
            // 
            this.linkLabelHowToUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelHowToUse.AutoSize = true;
            this.linkLabelHowToUse.Font = new System.Drawing.Font("굴림", 12F);
            this.linkLabelHowToUse.Location = new System.Drawing.Point(12, 336);
            this.linkLabelHowToUse.Name = "linkLabelHowToUse";
            this.linkLabelHowToUse.Size = new System.Drawing.Size(76, 16);
            this.linkLabelHowToUse.TabIndex = 7;
            this.linkLabelHowToUse.TabStop = true;
            this.linkLabelHowToUse.Text = "사용 방법";
            this.linkLabelHowToUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelHowToUse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabelBugReport
            // 
            this.linkLabelBugReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelBugReport.AutoSize = true;
            this.linkLabelBugReport.Font = new System.Drawing.Font("굴림", 12F);
            this.linkLabelBugReport.Location = new System.Drawing.Point(358, 336);
            this.linkLabelBugReport.Name = "linkLabelBugReport";
            this.linkLabelBugReport.Size = new System.Drawing.Size(114, 16);
            this.linkLabelBugReport.TabIndex = 8;
            this.linkLabelBugReport.TabStop = true;
            this.linkLabelBugReport.Text = "버그/오류 제보";
            this.linkLabelBugReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelBugReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBugReport_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.linkLabelBugReport);
            this.Controls.Add(this.linkLabelHowToUse);
            this.Controls.Add(this.buttonChangePath);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.labelCityName);
            this.Controls.Add(this.labelIpAddress);
            this.Controls.Add(this.labelRegionName);
            this.Controls.Add(this.labelCountryName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Tarkov Server Finder (v1.1)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCountryName;
        private System.Windows.Forms.Label labelCityName;
        private System.Windows.Forms.Label labelRegionName;
        private System.Windows.Forms.Label labelIpAddress;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonChangePath;
        private System.Windows.Forms.LinkLabel linkLabelHowToUse;
        private System.Windows.Forms.LinkLabel linkLabelBugReport;
    }
}

