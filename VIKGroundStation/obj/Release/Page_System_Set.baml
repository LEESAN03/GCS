   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  &     VIKGroundStation.Page_System_Set   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation       N� Title$  Page_System_Set��.��� 
���   � � ColumnDefinitions �� $	��20* ��� $
��100* �.+�� $��1�� � RowDefinitions �� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* �.+�� $��1��.+��� -   $��CheckBox_Wlan��   TITLE_NET_SELECT#���   
�������$��18(�� $��2��.+��� -   $��CheckBox_Com��  TITLE_COM_SELECT#���  
�������$��18(�� $��3��.+��� -   $��CheckBox_Mult��  TITLE_VERSION_MULTI_MOTORS#���  
�������$��18(�� $��4��.+��� -   $��CheckBox_FixWing��  TITLE_VERSION_FIX_WING#���  
�������$��18(�� $��7�� �� $
��100* ��� $
��100* ��� $
��100* ��� $
��300* �.+�� $��0��.+��� -   $��TextBlock_Serial��  TITLE_SELECT_COM_NUM#���  $��18(�
�������$
��Left=�$��Center=�� $��1��.+��� -   $��combox��$
��Left=�$��Center=�$��87��$��16(�� $��2��$��5q�.+��� -    ��Name$ Btn_Manual_Connect��  TITLE_CONNECT#���  $��3q�
�������$��30��$��18(�
�����������  �� 
TargetType" ��.R��� $��PART_Background��#��z��$��1q� �� CornerRadius$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ��� 	 �� 
TargetName$	 PART_Background��
 �� Property
 � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ Silver�� � Offset$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�� $��8�� �� $	��20* ��� $
��100* ��� $	��30* ��� $	��50* ��� $	��70* ��� $
��150* �.+�� $��0��.+��� -   $��TextBlock_WIFI��$	��IP:��$��18(�
�������$��Center=�$��Center=�� $��1��.+��� -	   $��
TextBox_IP��$��25��$��16(�.��� $��2��.+��� -
   $��TextBlock_PORT��$��port:��$��18(�
�������$��Center=�$��Center=�� $��3��.+��� -   $��TextBox_port��$��25��$��16(�.��� $��4��$��5q�.+��� -   $ Btn_WIFI_Connect��  	TITLE_SET#���  $��3q�
�������$��30��$��18(�
����������� " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $	 PART_Background��
 � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�