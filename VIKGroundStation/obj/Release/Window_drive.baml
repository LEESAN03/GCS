   M S B A M L   `   `   `  ����   VIKGroundStation#    VIKGroundStation.Window_drive   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Window_Num_Point��$	��240��$	��300�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������� � ShowInTaskbar .  .��� -   .+��� -    ��Name$ drive_namelist��$��18(�$��Center=�$��23,30,155,174q��� -    ��Name$ connect��   TITLE_CONNECT#���   $��3q�
����������	#FFDDDDDD$��20(�
�������$��175,30,26,174q�����  �� 
TargetType" ��.R��� $��PART_Background��#��z��$��3q� �� CornerRadius$ 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=�	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ Silver�� � Offset$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P� 
 � �� . . ���  �@J�Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q��� -   $	 get��  TITLE_FETCH#���  $��3q�
����������	#FFDDDDDD$��20(�
�������$��175,83,26,121q����� " ��.R��� $��PART_Background��#��z��$��3q�$ 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P� 
 � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q��� -   $��tb_text��$�� �� �� TextAlignment$ Center=�$��28,83,160,121q�$��24(��� -   $ get_Copy��  TITLE_BEGIN#���  $��3q�
����������	#FFDDDDDD$��20(�
�������$��41,133,160,71q����� " ��.R���  ��Name$ PART_Background��#��z��$��3q�$ 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P� 
 � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q��� -   $ 	get_Copy1��  	TITLE_END#���  $��3q�
����������	#FFDDDDDD$��20(�
�������$��175,133,26,71q����� " ��.R��� $ PART_Background��#��z��$��3q�$ 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ PART_Background�� � �� �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P� 
 � �� . . ���  �@J�Effect   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q��� -    ��Name$ tb_text_Copy��$�� ��$ Center=�$��28,180,160,40q�$��14(��� -	   $ tb_text_Copy1��$�� ��$ Center=�$��169,180,19,40q�$��14(�