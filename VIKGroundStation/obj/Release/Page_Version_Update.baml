   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  *    $VIKGroundStation.Page_Version_Update   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation       N� Title$  Page_Version_Update�� � 	Resources  �� 
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
��150* ��� $
��100* ��� $
��100* ��� $
��100* ��� $
��100* ��� $
��100* ��� $
��100* ��� $
��100* ��� $
��150* �.+�� $��1�� � ColumnDefinitions �� $
��100* ��� $
��100* ��� $	��50* �.+�� $��0��$��	20,0,20,0q�.+��� -    ��Name$ TextBlock_Feikong_Name��  TITLE_EQUIPMENT_NAME#���  $��16(�
�������$��Center=�$��Center=�� $��1��$��	20,0,20,0q�.+��� -   $  TextBlock_Feikong_Xuliehao��  TITLE_EQUIPMENT_NO#���  $��16(�
�������$��Center=�$��Center=�� $��2�� �� $
��100* ��� $
��100* ��� $	��50* �.+�� $��0��$��	20,0,20,0q�.+��� -   $* $TextBlock_Current_Controller_Version�� $  TITLE_CONTROLLER_CURRENT_VERSION#���  $��16(�
�������$��Center=�$��Center=�� $��1��$��	20,0,20,0q�.+��� -   $&  TextBlock_New_Controller_Version��   TITLE_CONTROLLER_NEW_VERSION#���  $��16(�
�������$��Center=�$��Center=�� $��2��$��	50,0,50,0q�.+��� -   $��Btn_Get_Control_Version��  TITLE_FETCH#���  $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q� �� CornerRadius$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$
 Gray�� � Offset$	 0.5Q�� $��3��$��	30,0,30,0q� �� $	��20* ��� $
��100* ��� $	��20* �.+�� $��0��$��5q�.+��� -   $��Btn_Update_Controller��  TITLE_UPDATE_CONTROLLER#���  $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��1��.+�� -    �Name$  ProgressBar_Update_Control��$��20��
����İ�
��� E��#��[  � $��2��$��	10,0,10,0q�.+��� -   $&  TextBlock_Control_Update_Percent��$��0%��$��14(�
�������$��Center=�$��Center=�� $��6�� �� $
��100* ��� $
��100* ��� $	��50* �.+�� $��0��$��	20,0,20,0q�.+��� -	   $# TextBlock_Current_IMU_Version��  TITLE_IMU_CURRENT_VERSION#���  $��16(�
�������$��Center=�$��Center=�� $��1��$��	20,0,20,0q�.+��� -
   $ TextBlock_New_IMU_Version��  TITLE_IMU_NEW_VERSION#���  $��16(�
�������$��Center=�$��Center=�� $��2��$��	50,0,50,0q�.+��� -   $��Btn_Get_IMU_Version��#���  $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��7��$��	30,0,30,0q� �� $	��20* ��� $
��100* ��� $	��20* �.+�� $��0��$��5q�.+��� -   $��Btn_Update_IMU�� 	 TITLE_UPDATE_IMU#��� 	 $��1q�
����������	#00DDDDDD$��16(�
�������$��30������ " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��1��.+�� -   $ ProgressBar_Update_IMU��$��20��
����İ�
��� E��#��[  � $��2��$��	10,0,10,0q�.+��� -   $" TextBlock_Update_IMU_Percent��$��0%��$��14(�
�������$��Center=�$��Center=�