   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  X TAvionicsInstrumentControlDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltRclr-namespace:AvionicsInstrumentControlDemo;assembly=AvionicsInstrumentControlDemoAvionicsInstrumentControlDemo K GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation !   VIKGroundStation.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     gzedgraphRclr-namespace:AvionicsInstrumentControlDemo;assembly=AvionicsInstrumentControlDemo     /Viewclr-namespace:VIKGroundStation     -     � Title$$  微克智飞多旋翼地面站��$	��768��$
��1366�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � Icon$ VK_DESKTOP.ico�� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $	��10* ��� $
��200* �.+�� $��0��
���   � � ColumnDefinitions �� $	��15* ��� $	��15* ��� $	��15* ��� $	��15* ��� $	��15* ��� $	��15* ��� $	��15* ��� $��5* ��� $��5* ��� $��5* ��� $��5* ��� $��5* ��� $	��15* ��� $	��15* �.+�� -    �Name$ MENUE_PLANE_SETTING��$��0��.+��� -    ��Name$ MENUE_BTN_PLANE_SETTINGS��   TITLE_MENUE_FLY_SETTINGS#���   $��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� 	 �� 
TargetType"	 ��.R��� $��PART_Background��#��z��$��3q�
 �� CornerRadius$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$
 Gray�� � Offset$	 0.0Q�� -   $ MENUE_WPT_PLAN��$��1��.+��� -   $ MENUE_BTN_WPT_PLAN��  TITLE_MENUE_WPT_PLAN#���  $��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.0Q�� -   $ MENUE_FLY_INFO��$��2��.+��� -   $ MENUE_BTN_FLY_INFO��  TITLE_MENUE_FLY_INFOR#���  $��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.0Q�� -   $ MENUE_TASK_SETTING��$��3��.+��� -	   $ MENUE_BTN_TASK_SETTING��  TITLE_MENUE_TASK_FUNCTION#���  $��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.0Q�� -
   $ MENUE_SYSTEM_FUNCTION��$��4��.+��� -   $ MENUE_BTN_SYSTEM_FUNCTION��  TITLE_MENUE_SYSTEM_MANAGE#���  $��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.0Q�� -   $ MENUE_2D_3D��$��5��.+��� -   $ MENUE_BTN_2D_3D��$��2D��$��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.0Q�� -   $ 
MENUE_EXIT��$��6��.+��� -   $ MENUE_BTN_EXIT��  TITLE_MENUE_EXIT#���  $��3q�
����������	#FFDDDDDD$��16(�
�������$��Center=����� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.0Q�� -   $ CENTRAL_VIEW��$��8��$��2,2,2,1q�.+��� -   $ MENUE_BTN_CENTRAL_VIEW��$��0q�
���   �$��16(�
����������� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 0������  �� ImageSource$ Images/centralView.png��._��� #��z��$��Center=�$��Center=�� $��9��$��2,2,2,1q�.+��� -   $ MENUE_BTN_DIST_MEASUTR��$��0q�
���   �$��16(�
����������� "	 ��.R��� $��PART_Background��#��z��$��3q�$
 0������ $ Images/measure.png��._��� #��z��$��Center=�$��Center=�� $��12��$��2,2,2,1q�.+�� $��1��.+��� -   $��combox_language��$
��Left=�$��Center=�$	��100��$��16(�� $��1�� �� $
��165* ��� $
��189* ��� $	��58* ��� $
��271* �.+� � -   $��frmMainShow��  � NavigationUIVisibility$ Hidden=�$��4��