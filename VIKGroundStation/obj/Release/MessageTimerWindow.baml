   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Input;assembly=PresentationCoreSystem.Windows.Input   VIKGroundStation)   #VIKGroundStation.MessageTimerWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      Ninput<clr-namespace:System.Windows.Input;assembly=PresentationCore      -     � Title$  MessageTimerWindow��$��40��$	��880�� � AllowsTransparency . ���	#00000000 � WindowStyle$
 None=� � WindowStartupLocation$ Manual=�
������� � ShowInTaskbar .  .���  � ColumnDefinitions �� $	��20* ��� $��5* ��� $��5* ��� $��5* �.+�� $��0��.+��� -   $��textBlock_message��$�� �� �� TextAlignment$ Center=�$��24(�
���  ��� $��1��$��2q�.+��� -    ��Name$ hangxianjianju��$��24(�$��20�� �� IsInputMethodEnabled .  	 �� TextAlignment$	 Center=�� $��2��$��2q�.+��� -   $��button_wpt_confirm��   TITLE_CONFIRM#���   $��3q�
�������
���   �$��24(�
����������� 
 �� 
TargetType"
 ��.R��� $��PART_Background��#��z��$��1q� �� CornerRadius$ 5,5,5,5��
���   �._��� #��z��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ PART_Background�� �� Property � �� �� Value ��  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ Silver�� � Offset$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect 3   -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black��   	Direction$ 0Q�   Opacity$	 0.6Q�   RenderingBias$ Performance=�   ShadowDepth$ 0Q�� $��3��$��2q�