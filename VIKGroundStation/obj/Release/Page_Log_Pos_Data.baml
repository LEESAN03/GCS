   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  (    "VIKGroundStation.Page_Log_Pos_Data   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation       N� Title$  Page_Log_Pos_Data�� � 	Resources  �� 
TargetType   SimpleProgressBar �� Property �� Value �� 
TargetType �Name ��Name J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName �� Angle��%�  &	        �� " �.���  �@�Maximum$ 1Q���  �@�Value$ 0Q���  � ��$ 10����  � �� .  ��  �@J�SnapsToDevicePixels . ��  � �� �� " �.R�� $
 Root��.+��� $ 
PART_Track��#��z��# z �� $ PART_Indicator��$
��Left=�#��z��# z 	 P� 
 �@�Orientation$ Vertical=�. ��� $
 Root�� �@�LayoutTransform �� $	 -90Q�.��� 
���   �$��2q� � RowDefinitions �� $
��300* ��� $
��100* ��� $
��100* ��� $
��100* ��� $
��300* �.+�� $��1��$��	30,0,30,0q� � ColumnDefinitions �� $	��20* ��� $
��100* ��� $	��20* ��� $	��20* �.+�� $��0��$��5q�.+��� -   $��Btn_Download_Pos��  TITLE_DOWN_LOAD_PIC_POS#���  $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q� �� CornerRadius$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$
 Gray�� � Offset$	 0.5Q�� $��1��.+�� -    �Name$ ProgressBar_Download_Pos��$��20��
����İ�
��� E��#��[  � $��2��$��	10,0,10,0q�.+��� -    ��Name$ TextBlock_Pos_Percent��$��0%��$��16(�
�������$��Center=�$��Center=�� $��2��$��	30,0,30,0q� �� $	��20* ��� $
��100* ��� $	��20* ��� $	��10* ��� $	��10* �.+�� $��0��$��5q�.+��� -   $��Btn_Download_Fly_Data��  TITLE_DOWN_LOAD_FLY_DATA#���  $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��1��.+�� -   $# ProgressBar_Download_FLy_Data��$��20��
����İ�
��� E��#��[  � $��2��$��	10,0,10,0q�.+��� -   $  TextBlock_Fly_Data_Percent��$��0%��$��16(�
�������$��Center=�$��Center=�� $��3��$��0,0,0,0q�.+��� -   $ TextBlock_Jiaci��$	��NO.��$��16(�
�������$��Center=�$��Center=�� $��4��$��2,5,2,5q�.+��� -   $��Combox_Jiaci��$��Center=�$��Center=�$��16(�$��50��� $��3��$��	30,0,30,0q� �� $	��20* ��� $
��100* ��� $	��20* ��� $	��20* �.+�� $��0��$��5q�.+��� -	   $��Btn_Download_Fly_Log��  TITLE_DOWN_LOAD_LOG#���  $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��1�� �� $	��43* ��� $
��236* �.+�� -
   $" ProgressBar_Download_FLy_Log��$��20��
����İ�
��� E��#��[  $��2��$	��0,6q�� $��2��$��	10,0,10,0q�.+��� -   $ TextBlock_Fly_Log_Percent��$��0%��$��16(�
�������$��Center=�$��Center=�