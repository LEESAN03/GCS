using EasyPlayerNetSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace VIKGroundStation
{
    public partial class Form1 : Form
    {
        private CRC mCrc = new CRC();

        private PlayerSdk.MediaSourceCallBack callBack = null;
        private bool isInit = false;
        private int channelID = -1;
        private bool isTCP = false;
        private bool isHardEncode = false;
        private PlayerSdk.RENDER_FORMAT RENDER_FORMAT = PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI;
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = PlayerSdk.EasyPlayer_CloseStream(channelID);
                if (ret == 0)
                {
                    channelID = -1;
                    this.panel1.Refresh();
                }

                string RTSPStreamURI = rtsp_addr_box.Text;// "rtsp://admin:admin@192.168.1.168/0:554/cam/realmonitor?channel=1&subtype=2&proto=Private3";
                channelID = PlayerSdk.EasyPlayer_OpenStream(RTSPStreamURI, this.panel1.Handle, RENDER_FORMAT, isTCP ? 1 : 0, "", "", callBack, IntPtr.Zero, isHardEncode);
                if (channelID > 0)
                {
                    PlayerSdk.EasyPlayer_SetFrameCache(channelID, 3);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("open vedio fail");
            }
        }
        

        private int MediaCallback(int _channelId, IntPtr _channelPtr, int _frameType, IntPtr pBuf, ref PlayerSdk.EASY_FRAME_INFO _frameInfo)
        {
            return 0;
        }

        private void PlaySound_MenuItem_Click(object sender, EventArgs e)
        {
            if (channelID <= 0)
                return;

            var checkState = (sender as ToolStripMenuItem).CheckState;
            if (checkState == CheckState.Unchecked)
            {
                int ret = PlayerSdk.EasyPlayer_PlaySound(channelID);
                (sender as ToolStripMenuItem).CheckState = CheckState.Checked;
            }
            if (checkState == CheckState.Checked)
            {
                int ret = PlayerSdk.EasyPlayer_StopSound();
                (sender as ToolStripMenuItem).CheckState = CheckState.Unchecked;
            }
        }

        private void PlayerForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (isInit)
            {
                try
                {
                    PlayerSdk.EasyPlayer_Release();
                    Page_Fly_Map.formWnd = null;
                }
                catch { }
            }
        }

        private void PlayerForm_Load(object sender, System.EventArgs e)
        {
            if (PlayerSdk.EasyPlayer_Init() == 0)
                isInit = true;
            callBack = new PlayerSdk.MediaSourceCallBack(MediaCallback);

            this.RightToLeft = RightToLeft.Inherit;
        }

        public string Get_Rtsp_Addr()
        {
            return (rtsp_addr_box.Text);
        }

        public void Set_Rtsp_Addr(string str)
        {
            rtsp_addr_box.Text = str;
        }
    }
}
