   M S B A M L   `   `   `  ����   VIKGroundStation'    !VIKGroundStation.Window_Num_Point   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Window_Num_Point��$��40��$	��240�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ Manual=�
������� � ShowInTaskbar .  
���   �.���  � ColumnDefinitions �� $��5* ��� $��5* ��� $��5* �.+�� $��0��.+��� -   $��textBlock_message��$�� �� �� TextAlignment$ Center=�$��32(�
���  ��� $��0��$��2q�.+��� -    ��Name$ hangdianshu��$��24(�$��20�� �� TextAlignment$ Center=�� $��1��$��2q�.+��� -   $��	button_ok��   TITLE_CONFIRM#���   $��3q�
�������
���   �$��20(�
����������� 	 �� 
TargetType"	 ��.R��� $��PART_Background��#��z��$��1q�
 �� CornerRadius$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ Silver�� � Offset$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��2��$��2q�.+��� -   $��button_cancel��  TITLE_CANCEL#���  $��3q�
�������
���   �$��20(�
����������� "	 ��.R��� $��PART_Background��#��z��$��1q�$
 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $	 Red��$	 0.0Q�� $	 Red��$	 0.5Q�� $	 Red��$	 0.0Q�P�  � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�