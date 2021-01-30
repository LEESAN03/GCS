namespace VIKGroundStation
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Confirm;
        private System.Windows.Forms.TextBox rtsp_addr_box;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            Window_Video_Control.getInstance().Save_All_Usb_Hid_Device();
            Window_Video_Control.getInstance().Hide_Wnd();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new System.Windows.Forms.Panel();
            Btn_Confirm = new System.Windows.Forms.Button();            
            rtsp_addr_box = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel1.BackColor = System.Drawing.Color.Black;
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            //panel1.ContextMenuStrip = this.contextMenuStrip1;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(920, 600);
            panel1.TabIndex = 0;

            Btn_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            Btn_Confirm.Location = new System.Drawing.Point(810, 600);
            Btn_Confirm.Name = "Btn_Confirm";
            Btn_Confirm.Size = new System.Drawing.Size(100, 40);
            Btn_Confirm.TabIndex = 17;
            Btn_Confirm.Text = "播放";
            Btn_Confirm.UseVisualStyleBackColor = true;
            Btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);

            rtsp_addr_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            rtsp_addr_box.Location = new System.Drawing.Point(10, 610);
            rtsp_addr_box.Name = "TextBox_Rtsp_Addr";
            rtsp_addr_box.Size = new System.Drawing.Size(600, 30);
            rtsp_addr_box.TabIndex = 17;
            //rtsp_addr.Text = "rtsp://admin:zingto123@192.168.1.108:554/type=0&id=1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(920, 640);
            Controls.Add(this.panel1);
            Controls.Add(this.Btn_Confirm);
            Controls.Add(this.rtsp_addr_box);
            Font = new System.Drawing.Font("Courier New", 10F);

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            Name = "Form1";
            TopMost = true;
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            Load += new System.EventHandler(this.PlayerForm_Load);
            //contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(true);
        }
        #endregion
    }
}
