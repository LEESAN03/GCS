   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  *    $VIKGroundStation.Page_Plane_Settings   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation       N� Title$  Page_Plane_Settings��.��� 
���   � � ColumnDefinitions �� $��8* ��� $
��200* ��� $
��100* �.+�� $��0�� � RowDefinitions �� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��30* �.+�� $��0��
���   �$��0,2,0,2q�.+��� -    ��Name$ BTN_PLANE_TYPE_SETTINGS��$��0q�
���   �$��30(�
�����������  �� 
TargetType" ��.R��� #��z��$��3q� �� CornerRadius$ 0������  �� ImageSource$ Images/机型.png��._��� #��z��$��Center=�$��Center=� �� Triggers P�  P� Property � ��	 P� Value	 . . ��� 
 �� Property
 �@J�Effect �� Value 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��1��
���   �$��0,2,0,2q�.+��� -   $ BTN_DIRECT_SELECT��$��0q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/fix_direction.png��._��� #��z��$��Center=�$��Center=� P�  � ��	 . . ��� 
 �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��2��
���   �$��0,2,0,2q�.+��� -   $ BTN_REMOTER_CALIBRATE��$��5q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $# Images/遥控设置选中.png��._��� #��z��$��Center=�$��Center=� P�  � ��	 . . ��� 
 �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��3��
���   �$��0,2,0,2q�.+��� -   $ BTN_MOTOR_TEST��$��5q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $# Images/飞行检测选中.png��._��� #��z��$��Center=�$��Center=� P�  � ��	 . . ��� 
 �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��4��
���   �$��0,2,0,2q�.+��� -   $ BTN_PID_SETTINGS��$��5q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/PID.png��._��� #��z��$��Center=�$��Center=� P�  � ��	 . . ��� 
 �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��5��
���   �$��0,2,0,2q�.+��� -   $ BTN_PAR_SETTINGS��$��5q�
���   �$��30(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/PAR.png��._��� #��z��$��Center=�$��Center=� P�  � ��	 . . ��� 
 �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��1��.+��� ���	#ff00b7ee$��2q�$ 5,5,5,5��$��3��._��� $��Center=�$��Center=� � -   $��Frm_Plane_Para��  � NavigationUIVisibility$ Hidden=�$��3��� $��2��.+��� ���	#ff00b7ee$��2q�$ 5,5,5,5��._��� $��Center=�$��Center=� � -   $ ��Frm_Plane_Para_Instruction��$ Hidden=�