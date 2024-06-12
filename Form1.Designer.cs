namespace tarkov_server_finder
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(159, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "딸각";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCountryName
            // 
            this.labelCountryName.AutoSize = true;
            this.labelCountryName.Font = new System.Drawing.Font("굴림", 16F);
            this.labelCountryName.Location = new System.Drawing.Point(178, 144);
            this.labelCountryName.Name = "labelCountryName";
            this.labelCountryName.Size = new System.Drawing.Size(114, 22);
            this.labelCountryName.TabIndex = 1;
            this.labelCountryName.Text = "국가: None";
            this.labelCountryName.Click += new System.EventHandler(this.labelCountryName_Click);
            // 
            // labelCityName
            // 
            this.labelCityName.AutoSize = true;
            this.labelCityName.Font = new System.Drawing.Font("굴림", 16F);
            this.labelCityName.Location = new System.Drawing.Point(180, 227);
            this.labelCityName.Name = "labelCityName";
            this.labelCityName.Size = new System.Drawing.Size(114, 22);
            this.labelCityName.TabIndex = 2;
            this.labelCityName.Text = "도시: None";
            // 
            // labelRegionName
            // 
            this.labelRegionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRegionName.AutoSize = true;
            this.labelRegionName.Font = new System.Drawing.Font("굴림", 16F);
            this.labelRegionName.Location = new System.Drawing.Point(180, 184);
            this.labelRegionName.Name = "labelRegionName";
            this.labelRegionName.Size = new System.Drawing.Size(114, 22);
            this.labelRegionName.TabIndex = 3;
            this.labelRegionName.Text = "지역: None";
            // 
            // labelIpAddress
            // 
            this.labelIpAddress.AutoSize = true;
            this.labelIpAddress.Font = new System.Drawing.Font("굴림", 12F);
            this.labelIpAddress.Location = new System.Drawing.Point(181, 110);
            this.labelIpAddress.Name = "labelIpAddress";
            this.labelIpAddress.Size = new System.Drawing.Size(111, 16);
            this.labelIpAddress.TabIndex = 4;
            this.labelIpAddress.Text = "IP 주소 : None";
            this.labelIpAddress.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.labelCityName);
            this.Controls.Add(this.labelIpAddress);
            this.Controls.Add(this.labelRegionName);
            this.Controls.Add(this.labelCountryName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Tarkov Server Finder (v1.0)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCountryName;
        private System.Windows.Forms.Label labelCityName;
        private System.Windows.Forms.Label labelRegionName;
        private System.Windows.Forms.Label labelIpAddress;
    }
}

