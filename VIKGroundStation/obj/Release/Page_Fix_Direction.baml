   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  )    #VIKGroundStation.Page_Fix_Direction   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation       N� Title$  Page_Fix_Direction��.��� $��2q�
���   � � ColumnDefinitions �� $��5* ��� $	��10* ��� $��5* ��� $	��20* �.+�� $��1�� � RowDefinitions �� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* �.+�� $��1��$��20q�.+��� -    ��Name$ MAG_CALIBRATE��   TITLE_CI_CALIBRATE#���   $��2q�
�������
���   �$��18(�
�������� $��2��$��20q�.+��� -   $ HORIZONTAL_CALIBRATE��  TITLE_HORIZONTAL_CALIBRATE#���  $��2q�
�������
���   �$��18(�
�������� $��3��$��20q�.+��� -   $ FORWARD_AN_ZHUANG��  TITLE_FORWARD_AN_ZHUANG#���  $��2q�
����������	#00DDDDDD$��18(�
�������� $��4��$��20q�.+��� -   $ RIGHT_AN_ZHUANG��  TITLE_RIGHT_AN_ZHUANG#���  $��2q�
����������	#00DDDDDD$��18(�
�������� $��5��$��20q�.+��� -   $ BACK_AN_ZHUANG��  TITLE_BACK_AN_ZHUANG#���  $��2q�
����������	#00DDDDDD$��18(�
�������� $��6��$��20q�.+��� -   $ LEFT_AN_ZHUANG��  TITLE_LEFT_AN_ZHUANG#���  $��2q�
����������	#00DDDDDD$��18(�
�������� $��2�� �� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* �.+�� $��3��.+��� -   $��Image_Fix_Direction_Head��$'��!Images/fix_direction_headward.png��{�.  � $��4��.+��� -   $��Image_Fix_Direction_Right��$(��"Images/fix_direction_rightward.png��{�.  � $��5��.+��� -	   $��Image_Fix_Direction_Back��$'��!Images/fix_direction_backward.png��{�.  � $��6��.+��� -
   $��Image_Fix_Direction_Left��$'��!Images/fix_direction_leftward.png��{�.  � $��3�� �� $
��100* ��� $
��100* ��� $
��400* ��� $
��100* ��� $
��100* ��� $
��100* �.+�� $��1��.+���   TITLE_GPS_BIAS#���  $��18(�
�������$��Center=�$��Bottom=�� $��2��$��20q�.+��� -   $��Image_Fix_Direction��$��Images/gps_fix_pos.png��{�.  � $��3�� �� $
��100* ��� $
��200* ��� $
��100* ��� $
��100* ��� $
��200* ��� $
��100* ��� $
��100* ��� $
��200* ��� $
��100* �.+�� $��0��.+��� $��X:��$��16(�
�������$��Center=�$��Center=�� $��1��$��	0,30,0,30q�.+��� -   $��TextBox_GPS_X_BIAS��.��� $��2��.+��� $��cm��$��16(�
�������$��Center=�$��Center=�� $��3��.+��� $��Y:��$��16(�
�������$��Center=�$��Center=�� $��4��$��	0,30,0,30q�.+��� -   $��TextBox_GPS_Y_BIAS��.��� $��5��.+��� $��cm��$��16(�
�������$��Center=�$��Center=�� $��6��.+��� $��Z:��$��16(�
�������$��Center=�$��Center=�� $��7��$��	0,30,0,30q�.+��� -   $��TextBox_GPS_Z_BIAS��.��� $��8��.+��� $��cm��$��16(�
�������$��Center=�$��Center=�� $��4�� �� $
��300* ��� $
��100* ��� $
��100* �.+�� $��1��$��	5,20,5,20q�.+��� -   $ BTN_GET_GPS_BIAS��  TITLE_FETCH#���  $��2q�
�������
���   �$��18(�
�������� $��2��$��	5,20,5,20q�.+��� -   $ BTN_SET_GPS_BIAS��  	TITLE_SET#���  $��2q�
�������
���   �$��18(�
�������