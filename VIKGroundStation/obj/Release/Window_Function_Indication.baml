   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  1    +VIKGroundStation.Window_Function_Indication   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:VIKGroundStation     -   $	��200��$	��450��  � AllowsTransparency  .  � WindowStyle$
 None=� � WindowStartupLocation$ Manual=�
������� � ShowInTaskbar .  ���	#00000000.���  � RowDefinitions �� $��1* ��� $��1* ��� $��1* �.+�� $��0��$��5q�
���   � � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* �.+�� $��0��$��5q�.+��� -   $��TextBlock_Target_Wpt��   TITLE_TARGET_WPT_NUM#���   $��16(�
�������$��Center=�$��Center=�� $��1��$��5q�.+��� -   $��TextBox_Target_Wpt��$��16(�.��� $��2��$��5q�.+��� -    ��Name$ BTN_SET_TARGET_WPT��  TITLE_CONFIRM#���  $��0q�
����������	#00DDDDDD$��16(�
�����������  �� 
TargetType" ��.R��� $��PART_Background��#��z��$��2q� �� CornerRadius$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ Silver�� � Offset$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�� $��1��$��5q�
���   � �� $��1* ��� $��1* ��� $��1* �.+�� $��0��$��5q�.+��� -   $��TextBlock_Target_Alt��  TITLE_TARGET_ALT_STATIC#���  $��16(�
�������$��Center=�$��Center=�� $��1��$��5q�.+��� -   $��TextBox_Target_Alt��$��16(�.��� $��2��$��5q�.+��� -   $ BTN_SET_TARGET_ALT��#���  $��0q�
����������	#00DDDDDD$��16(�
����������� " ��.R��� $��PART_Background��#��z��$��2q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�� $��2��$��5q�
���   � �� $��1* ��� $��1* ��� $��1* �.+�� $��0��$��5q�.+��� -   $��TextBlock_Pic_Num��  TITLE_PIC_NUM#���  $��16(�
�������$��Center=�$��Center=�� $��1��$��5q�.+��� -	   $��TextBlock_Pic_Num_Show��$��16(�
�������$��Center=�$��Center=�� $��2��$��5q�.+��� -
   $ BTN_TAKE_PIC��  TITLE_TAKE_PIC#���  $��0q�
����������	#00DDDDDD$��16(�
����������� " ��.R��� $��PART_Background��#��z��$��2q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�