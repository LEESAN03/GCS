   M S B A M L   `   `   `  ����   VIKGroundStation#    VIKGroundStation.WindowBanben   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Window_Num_Point��$	��160��$	��240�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������� � ShowInTaskbar .  ����  �� ImageSource$, &Images/高度模式编辑框背景.png��.��� .+��  � RowDefinitions �� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* �.+�� $��0��$��	10,5,10,5q� � ColumnDefinitions �� $	��20* ��� $��3* �.+�� $��0��.+���    TITLE_VERSION_SETTINGS#���   $��18(�� $��1��.+��� -    ��Name$ CLose��$��X��$��3q�
����������	#33DDDDDD$��18(�
����������� 	 �� 
TargetType"	 ��.R��� $��PART_Background��#��z��$��2q�
 �� CornerRadius$
 5,5,5,5��._��� #��z��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$	 Red�� � Offset$	 0.0Q�� $	 Red��$	 0.5Q�� $	 Red��$	 0.0Q�P�  � �� . . ���  �@J�Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��1��$��	20,4,10,4q�� $��1��$��	20,4,10,4q�.+��� -   $��hangpai��  TITLE_VERSION_MULTI_MOTORS#���  
�������$��16(�� $��2��$��	20,4,10,4q�.+��� -   $��gudingyi��  TITLE_VERSION_FIX_WING#���  
�������$��16(�� $��3��$��	20,4,10,4q�