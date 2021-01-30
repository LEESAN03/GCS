using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace VIKGroundStation
{
    public struct MyUSBJoy
    {
        public float dXpos;
        public float dYpos;
        public float dZpos;
        public float dwRpos;
        public float dwUpos;
        public float dwVpos;
        public int ndXpos;
        public int ndYpos;
        public int ndZpos;
        public int ndwRpos;
        public int ndwUpos;
        public int ndwVpos;
        public UInt32 dButton;
        /// <summary>
        /// 苦力帽，顺时针1~8 8个方向，0表示中位
        /// </summary>
        public int nPOV;
    }
    class USB_Joy
    {
        #region API
        /// 手柄当前状态
        /// </summary>
        public struct JOYINFO
        {
            public uint wXpos;
            public uint wYpos;
            public uint wZpos;
            public uint wButtons;
        }
        /// <summary>
        /// 手柄当前状态(6自由度)
        /// </summary>
        [StructLayout(LayoutKind.Sequential)] //顺序布局
        public struct JOYINFOEX
        {
            /// <summary>
            /// Size, in bytes, of this structure.//大小，以字节为单位
            /// </summary>
            public int dwSize;
            /// <summary>
            /// Flags indicating the valid information returned in this structure. Members that do not contain valid information are set to zero.标志，指示在该结构返回的有效信息。构件不包含有效信息被设定为零
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// Current X-coordinate.
            /// </summary>
            public int dwXpos;//X坐标
            /// <summary>
            /// Current Y-coordinate.
            /// </summary>
            public int dwYpos;
            /// <summary>
            /// Current Z-coordinate.
            /// </summary>
            public int dwZpos;
            /// <summary>
            /// Current position of the rudder or fourth joystick axis.
            /// </summary>
            public int dwRpos;
            /// <summary>
            /// Current fifth axis position.
            /// </summary>
            public int dwUpos;
            /// <summary>
            /// Current sixth axis position.
            /// </summary>
            public int dwVpos;
            /// <summary>
            /// Current state of the 32 joystick buttons. The value of this member can be set to any combination of JOY_BUTTONn flags, where n is a value in the range of 1 through 32 corresponding to the button that is pressed.当前32个按钮的状态
            /// </summary>
            public uint dwButtons;
            /// <summary>
            /// Current button number that is pressed. //当前那些按钮被按下
            /// </summary>
            public int dwButtonNumber;
            /// <summary>
            /// Current position of the point-of-view control. Values for this member are in the range 0 through 35,900. These values represent the angle, in degrees, of each view multiplied by 100.
            /// </summary>
            public int dwPOV;
            /// <summary>
            /// Reserved; do not use.
            /// </summary>
            public int dwReserved1;
            /// <summary>
            /// Reserved; do not use.
            /// </summary>
            public int dwReserved2;
        }

        #region 游戏手柄的参数信息
        /// <summary>
        /// 游戏手柄的参数信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JOYCAPS
        {
            public ushort wMid;
            public ushort wPid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPname;
            public int wXmin;
            public int wXmax;
            public int wYmin;
            public int wYmax;
            public int wZmin;
            public int wZmax;
            public int wNumButtons;
            public int wPeriodMin;
            public int wPeriodMax;
            public int wRmin;
            public int wRmax;
            public int wUmin;
            public int wUmax;
            public int wVmin;
            public int wVmax;
            public int wCaps;
            public int wMaxAxes;
            public int wNumAxes;
            public int wMaxButtons;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szRegKey;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szOEMVxD;
        }
        #endregion
        /// <summary>
        /// win API
        /// </summary>
        /// <param name="uJoyID">手柄好</param>
        /// <param name="pji">JOYINFO指针</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int joyGetPos(uint uJoyID, ref JOYINFO pji);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uJoyID">ID</param>
        /// <param name="pji">JOYINFOEX</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int joyGetPosEx(uint uJoyID, ref JOYINFOEX pji);

        /// <summary>
        /// 检查系统是否配置了游戏端口和驱动程序。如果返回值为零，表明不支持操纵杆功能。如果返回值不为零，则说明系统支持游戏操纵杆功能。
        /// </summary>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int joyGetNumDevs();

        /// <summary>
        /// 获取某个游戏手柄的参数信息
        /// </summary>
        /// <param name="uJoyID">指定游戏杆(0-15)，它可以是JOYSTICKID1或JOYSTICKID2</param>
        /// <param name="pjc"></param>
        /// <param name="cbjc">JOYCAPS结构的大小</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int joyGetDevCaps(int uJoyID, ref JOYCAPS pjc, int cbjc);

        #region JOYINFOEX.dwFlags值的定义
        public const uint JOY_RETURNX = 0x1;
        public const uint JOY_RETURNY = 0x2;
        public const uint JOY_RETURNZ = 0x4;
        public const uint JOY_RETURNR = 0x8;
        public const uint JOY_RETURNU = 0x10;
        public const uint JOY_RETURNV = 0x20;
        public const uint JOY_RETURNPOV = 0x40;
        public const uint JOY_RETURNBUTTONS = 0x80;
        public const uint JOY_RETURNRAWDATA = 0x100;
        public const uint JOY_RETURNPOVCTS = 0x200;
        public const uint JOY_RETURNCENTERED = 0x400;
        public const uint JOY_USEDEADZONE = 0x800;
        public const uint JOY_RETURNALL = (JOY_RETURNX | JOY_RETURNY | JOY_RETURNZ | JOY_RETURNR | JOY_RETURNU | JOY_RETURNV | JOY_RETURNPOV 
                                            | JOY_RETURNBUTTONS | JOY_RETURNRAWDATA | JOY_RETURNPOVCTS | JOY_RETURNCENTERED | JOY_USEDEADZONE);
        public const uint JOY_CAL_READALWAYS = 0x10000;
        public const uint JOY_CAL_READRONLY = 0x2000000;
        public const uint JOY_CAL_READ3 = 0x40000;
        public const uint JOY_CAL_READ4 = 0x80000;
        public const uint JOY_CAL_READXONLY = 0x100000;
        public const uint JOY_CAL_READYONLY = 0x200000;
        public const uint JOY_CAL_READ5 = 0x400000;
        public const uint JOY_CAL_READ6 = 0x800000;
        public const uint JOY_CAL_READZONLY = 0x1000000;
        public const uint JOY_CAL_READUONLY = 0x4000000;
        public const uint JOY_CAL_READVONLY = 0x8000000;
        #endregion
        #endregion

        /// <summary>
        /// Joy使能
        /// </summary>
        public static bool JoyEnable = true;
        /// <summary>
        /// Joy 状态
        /// </summary>
        public static bool JoyMark = false;
        /// <summary>
        /// 计数器
        /// </summary>
        public static int nCount = 0;
        /// <summary>
        /// 获取Joy 摇杆及按键状态
        /// </summary>
        /// <param name="Joy"></param>
        /// <returns></returns>
        public static int GetUSB_Joy(ref MyUSBJoy Joy)
        {
            int mark = 0;
            //JOYINFO status = new JOYINFO();
            JOYINFOEX status2 = new JOYINFOEX();
            status2.dwSize = Marshal.SizeOf(typeof(JOYINFOEX));
            status2.dwFlags = JOY_RETURNALL;
            // joyGetPos(0, ref status);
            mark = joyGetPosEx(0, ref status2);
            if (mark == 0)
            {
                Joy.dXpos = status2.dwXpos;// (status2.dwXpos - MidofJoy) / (float)MidofJoy;
                Joy.dYpos = status2.dwYpos;//(status2.dwYpos - MidofJoy) / (float)MidofJoy;
                                           // Joy.dZpos = 1 - Ldz.answer(status2.dwZpos);//(status2.dwZpos ) / 65535.0F;
                Joy.dZpos = status2.dwZpos;                    // Joy.dwRpos = LwR.answer(status2.dwRpos);//(status2.dwRpos - MidofJoy) / (float)MidofJoy;
                                                               // Joy.dwUpos = LwU.answer(status2.dwUpos);
                                                               //Joy.dwVpos = LwV.answer(status2.dwVpos);
                Joy.ndXpos = status2.dwXpos;
                Joy.ndYpos = status2.dwYpos;
                Joy.ndZpos = status2.dwZpos;
                Joy.ndwRpos = status2.dwRpos;
                Joy.ndwUpos = status2.dwUpos;
                Joy.ndwVpos = status2.dwVpos;
                Joy.dButton = status2.dwButtons; //status.wButtons;
                switch (status2.dwPOV)
                {
                    case 0xFFFF:
                        {
                            Joy.nPOV = 0;
                        }
                        break;
                    case 0x0000:
                        {
                            Joy.nPOV = 1;
                        }
                        break;
                    case 0x1194:
                        {
                            Joy.nPOV = 2;
                        }
                        break;
                    case 0x2328:
                        {
                            Joy.nPOV = 3;
                        }
                        break;
                    case 0x34BC:
                        {
                            Joy.nPOV = 4;
                        }
                        break;
                    case 0x4650:
                        {
                            Joy.nPOV = 5;
                        }
                        break;
                    case 0x57E4:
                        {
                            Joy.nPOV = 6;
                        }
                        break;
                    case 0x6978:
                        {
                            Joy.nPOV = 7;
                        }
                        break;
                    case 0x7B0C:
                        {
                            Joy.nPOV = 8;
                        }
                        break;
                    default:
                        {
                            Joy.nPOV = 0;
                        }
                        break;
                }
                JoyMark = true;
            }
            else
            {
                // JOYCAPS pjc=new JOYCAPS();
                //  mark= joyGetDevCaps(0, ref  pjc, Marshal.SizeOf(typeof(JOYCAPS)));
                JoyMark = false;
                // Joy.ndXpos = (LdX.N0f + LdX.N0f) / 2;
                // Joy.ndYpos = (LdX.N0f + LdX.N0f) / 2;
                // Joy.ndZpos = (LdX.N0f + LdX.N0f) / 2;
                // Joy.ndwRpos = (LdX.N0f + LdX.N0f) / 2;
                // Joy.ndwUpos = (LdX.N0f + LdX.N0f) / 2;
                // Joy.ndwVpos = (LdX.N0f + LdX.N0f) / 2;
                Joy.dXpos = 0;// LdX.answer((LdX.N0f + LdX.N0f) / 2);
                Joy.dYpos = 0;// LdY.answer((LdX.N0f + LdX.N0f) / 2);
                Joy.dZpos = 0;// 1 - Ldz.answer((LdX.N0f + LdX.N0f) / 2);
                Joy.dwRpos = 0;//  LwR.answer((LdX.N0f + LdX.N0f) / 2);
                Joy.dwUpos = 0;//  LwU.answer((LdX.N0f + LdX.N0f) / 2);
                Joy.dwVpos = 0;//  LwV.answer((LdX.N0f + LdX.N0f) / 2);
                Joy.dButton = 0x00;

                Joy.nPOV = 0;
            }
            return mark;
        }

        public static int GetJoyNumDevs()
        {
            return joyGetNumDevs();
        }

    }
}
