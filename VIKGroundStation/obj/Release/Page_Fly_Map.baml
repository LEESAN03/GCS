   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  #    VIKGroundStation.Page_Fly_Map   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation       N� Title$  Page_Fly_Map��.���  � RowDefinitions �� $
��100* ��� $��4* ��� $��4* �.+�� $��0�� � ColumnDefinitions �� $��8* ��� $
��300* �.+�� -    �Name$ Grid_FLy_Show��$��0��
���   � �� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* �.+�� $��0��.+��� -    ��Name$ BTN_Show_FLy_Info��$��0q�
���   �$��30(�
�����������  �� 
TargetType" ��.R��� #��z��$��3q� �� CornerRadius$ 0������  �� ImageSource$ Images/fly_infor.png��._��� #��z��$��Center=�$��Center=� �� Triggers P� 	 P� Property	 � ��
 P� Value
 . . ���  �� Property �@J�Effect �� Value 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��1��.+��� -   $ BTN_Show_FLy_Indicator��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/fly_indication.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��2��.+��� -   $! BTN_Show_Function_Indicator��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $$ Images/function_indication.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��3��.+��� -   $ BTN_Show_FLy_Point��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/fly_point.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��4��.+��� -   $ BTN_Show_Yun_Tai��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/YunTai_Control.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��6��.+��� -   $ BTN_DOWNLOAD_MAP��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/map_download.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��16��.+��� -   $ BTN_Show_Wnd_Chat��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/chart.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��14��.+��� -	   $ 
BTN_REPLAY��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/replay.png��._��� #��z��$��Center=�$��Center=� P� 	 � ��
 . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� -
   $ Grid_Map_Show��$��1��.+� � -   $��Frm_Map_Show2��  � NavigationUIVisibility$ Hidden=�� $��1��
���   � �� $��8* ��� $��8* ��� $��9* ��� $��9* ��� $	��15* ��� $��8* ��� $��9* ��� $	��17* �.+�� $��0��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -    ��Name$ TextBlock_Gps��$
��GPS:��$��15(�
�������$��Center=�$��Center=�� $��1��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Alt��   TITLE_ALTITUDE#���   $��15(�
�������$��Center=�$��Center=�� $��2��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Speed��  TITLE_HORIZONTAL_VEL_STATIC#���  $��15(�
�������$��Center=�$��Center=�� $��3��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Climb_Rate��  TITLE_VERTICAL_VEL_STATIC#���  $��15(�
�������$��Center=�$��Center=�� $��4��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Fly_Mode��  TITLE_FLY_MODE#���  $��17(����	#ff00b7ee$��Center=�$��Center=�� $��5��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Battery_Volt��  TITLE_VOLT_STATIC#���  $��15(�
�������$��Center=�$��Center=�� $��6��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Air_Speed��  TITLE_AIR_SPEED#���  $��15(�
�������$��Center=�$��Center=�� $��7��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Position��$��Lon/Lat:��$��15(�
�������$��Center=�$��Center=�� $��2��
���   � �� $��8* ��� $��8* ��� $��9* ��� $��9* ��� $	��15* ��� $��8* ��� $��9* ��� $��9* ��� $��8* �.+�� $��0��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Target_Wpt��  TITLE_TARGET_WPT_NUM#���  $��15(�
�������$��Center=�$��Center=�� $��1��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Target_Wpt_Dist��  TITLE_TARGET_WPT_DIST#���  $��15(�
�������$��Center=�$��Center=�� $��2��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Flied_Dist��  TITLE_FLIED_DIST#���  $��15(�
�������$��Center=�$��Center=�� $��3��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Flied_Time�� 	 TITLE_FLIED_TIME#��� 	 $��15(�
�������$��Center=�$��Center=�� $��4��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Attitude�� 
 TITLE_ATTITUDE#��� 
 $��17(����	#ff00b7ee$��Center=�$��Center=�� $��5��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Total_Dist��  TITLE_WPT_TOTAL_DIST#���  $��15(�
�������$��Center=�$��Center=�� $��6��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Dist_Home��  TITLE_DIST_HOME_STATIC#���  $��15(�
�������$��Center=�$��Center=�� $��7��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Total_Pic_Num��  TITLE_PIC_NUM#���  $��15(�
�������$��Center=�$��Center=�� $��8��$��1,0,1,0q�.+��� ���	#ff404040$��1q�._��� $��Center=�$��Center=��� -   $ TextBlock_Temperature��  TITLE_TEMPERATURE#���  $��15(�
�������$��Center=�$��Center=�