   M S B A M L   `   `   `  ����   VIKGroundStation)    #VIKGroundStation.Connect_Set_Window   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     $	��400��$	��600��  � WindowStyle$
  None=� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�����  �� ImageSource$ Images/设置框.png�� � 	Resources    ControlBorderBrush �� Color  ItemsContentBackground �� 
TargetType  SimpleProgressBar �� Property �� Value	 �� 
TargetType
 �Name ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Angle  DefaultListView��%+  &	        &	      &	 &     &	 �    7   7  �� $ #999C9F���� $ #1389D7���� " �.���  �@�Maximum$ 1Q���  �@�Value$ 0Q���  � ��$ 10����  � �� .  ��  �@J�SnapsToDevicePixels . ��  � �� �� "	 �.R�� $

 Root��.+��� $ 
PART_Track��#��z��# z �� $ PART_Indicator��$
��Left=�#��z��# z  P�  �@�Orientation$ Vertical=�. ��� $
 Root�� �@�LayoutTransform �� $	 -90Q��� " ��.���  � ��8   ��  � ��8  ��  � ��$ 1q���  � �� . ��  �@%�IsVirtualizing . ��  �@%�VirtualizationMode$ 	Recycling=��� " �@��IsDeferredScrollingEnabled .  ��  �@��AlternationCount$ 2����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ Center=���  �@��SelectionMode$ Single=���  � �� �� "	 ��.R��� $ Border��#��z��#��z��#��z�� .  P�  �@��
IsGrouping . . ���  � �� .  .��� $��10q� � RowDefinitions �� $	��70* ��� $
��700* ��� $	��70* �.+�� $��0�� � ColumnDefinitions �� $
��100* ��� $
��100* ��� $	��15* �.+�� $��0��$��2q�.+��� -   $��NameSet��  TITLE_LINK_SETTING#���  $��3q�
������ ���	#00DDDDDD$��18(�
�������$
��Left=����� "	 ��.R��� $��PART_Background��#��z��$��3q� �� CornerRadius$ 5,5,5,5��._��� #��z��$��Center=�$��Center=�� $��1��� $��2��$��2q�.+��� -    ��Name$ CLose��$��X��$��3q�
����������	#33DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��2q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$	 Red�� � Offset$	 0.0Q�� $	 Red��$	 0.5Q�� $	 Red��$	 0.0Q�P�  � �� . . ���  �@J�Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��1��$��3q�.+��� -   $��Connect_TB_Set�����	#00000000���� .���  � y�$ 	Collapsed=�.@��� .��� $��10q� �� $	��30* ��� $	��30* ��� $
��100* �.+�� $��0��$��10q�.+��� -   $ zidonglianjie_btn��  TITLE_AUTO_LINK#���  $��3q�
�������
���   �$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�� $��2��$��10q�.+��� -   $��combox��$��	60,10,0,0q�$
��Left=�$	��Top=�$	��109��$��37���� -   $ zidonglianjie_btn1��  TITLE_CONNECT#���  $��3q�
�������
���   �$��18(�
�������$��204,10,231,107q����� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q��� .��� .+��� -   $!��lvwOverallViewWayPointInfo1��$��18(�
���   �
�������
���   �  �� View  �� .P��� ! �� Width$	! 250��  TITLE_NET_NAME#���  " �� DisplayMemberBinding" �� # �� Path$
# str1��� $	! 250��  TITLE_NET_STATUS#���  " �� $
# str2��� .���  �� $	��20* ��� $	��20* ��� $	��30* ��� $	��20* ��� $	��20* ��� $	��50* �.+�� $��0��$��10q�.+��� -   $��WlanContect�� 	 TITLE_NET_SELECT#��� 	 
�������$��16(�� $��1��$��10q�.+��� -	   $��
ComContect�� 
 TITLE_COM_SELECT#��� 
 
�������$��16(�� $��2��$��10q�.+��� -
   $��
disContect��  TITLE_NOT_AVAILABLE#���  
�������$��16(�� $��3��$��10q�.+��� -   $��CheckBox_Chinese��  TITLE_LANGUAGE_CH#���  
�������$��16(�� $��4��$��10q�.+��� -   $��CheckBox_English��  TITLE_LANGUAGE_EN#���  
�������$��16(�� $��2�� �� $
��250* ��� $	��50* ��� $
��100* �.+�� $��0�� �� $
��100* ��� $
��100* ��� $
��100* ��� $
��100* �.+�� $��0��$��2q�.+��� -   $ shuchuantongxun_btn��  TITLE_TELE_COM_LINK#���  $��3q�
����������	#00DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��1��$��2q�.+��� -   $ wangluotongxun_btn��  TITLE_NET_LINK#���  $��3q�
����������	#00DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��2��$��2q�.+��� -   $ kaijitongxun_btn��  TITLE_LINK_TYPE_START#���  $��3q�
����������	#00DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��1��� $��2�� �� $
��100* ��� $
��100* ��� $
��100* �.+�� $��0��$��2q�.+��� -   $ Cheng1��$��X1��$��3q�
����������	#00DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��1��$��2q�.+��� -   $ Cheng2��$��X2��$��3q�
����������	#00DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��2��$��2q�.+��� -   $ Cheng3��$��X3��$��3q�
����������	#00DDDDDD$��18(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�