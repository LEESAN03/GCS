   M S B A M L   `   `   `  ����   VIKGroundStation#    VIKGroundStation.Window_Route   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $	��582��$	��388��  � WindowStyle$
  None=� � ShowInTaskbar .   � AllowsTransparency . ����  �� ImageSource$ Images/设置框.png��.��� $��10q� � RowDefinitions �� $	��10* ��� $
��140* ��� $	��20* ��� $	��10* �.+�� $��0�� � ColumnDefinitions �� $
��100* ��� $
��180* ��� $	��26* �.+�� $��0��.+��� -   $��header��   TITLE_WPT_PLAN#���   $��3q�
������ ���	#00DDDDDD$��18(�
�������$
��Left=�$	��121������  �� 
TargetType" ��.R��� $��PART_Background��#��z��$��3q� �� CornerRadius$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 .  P� 	 � ��
 .  � $��2��.+��� -    ��Name$ CLose��$��X��$��3q�
����������	#33DDDDDD$��18(�
����������� " ��.R��� $��PART_Background��#��z��$��2q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$	 Red�� � Offset$	 0.0Q�� $	 Red��$	 0.5Q�� $	 Red��$	 0.0Q�P� 	 � ��
 . . ���  �@J�Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��1��$��3q�.+��� -   $��wpt_list_box��$��18(�
�������
�������
���   � �� View �� .P���  �� Width$ 40��  TITLE_ID#���   �� DisplayMemberBinding ��  �� Path$ NumberId��� $ 40��  TITLE_ALTITUDE#���   �� $	 alt��� $ 40��  TITLE_SPEED#���   �� $ speed��� $ 80��  TITLE_WPT_TASK_FUNCTION#���   �� $ 	str_renwu��� $ 40��  TITLE_TASK_TIME#���   �� $ renwujiange��� $ 80��  TITLE_FLY_MODE#���   �� $ str_zhuanwan���   TITLE_WPT_STOP_TIME#���   �� $ 
moshiItime�� $��2��.+��  �� $
��100* ��� $
��100* ��� $
��100* ��� $
��100* �.+�� $��0��$��	2,10,2,10q�.+��� -   $��DelPt��  TITLE_DELETE_WPT#���  $��1q�
����������	#00DDDDDD$��18(�
����������� " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��1��$��	2,10,2,10q�.+��� -   $��hangdianshuxing�� 	 TITLE_WPT_PROPERTY#��� 	 $��1q�
����������	#00DDDDDD$��18(�
����������� " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��2��$��	2,10,2,10q�.+��� -   $��hangxianbaocun�� 
 TITLE_WPT_SAVE#��� 
 $��1q�
����������	#00DDDDDD$��18(�
����������� " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��3��$��	2,10,2,10q�.+��� -   $��ShangchuanPt��  TITLE_WPT_UPLOAD#���  $��1q�
����������	#00DDDDDD$��18(�
����������� " ��.R��� $��PART_Background��#��z��$��1q�$ 5,5,5,5��._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $
 Gray��$	 0.5Q�� $��3��.+��  �� $
��100* ��� $
��100* �.+�� $��0��.+��� -	   $��yujishijian��  TITLE_ESTIMATED_TIME#���   �� TextAlignment$
 Left=�
�������$��12(�� $��1��.+��� -
   $��zongjuli��  TITLE_WPT_TOTAL_DIST#���  $ Center=�
�������$��12(�