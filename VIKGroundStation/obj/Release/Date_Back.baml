   M S B A M L   `   `   `  ����   VIKGroundStation     VIKGroundStation.Date_Back   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$   ��$	��120��$	��800�� � AllowsTransparency .  � WindowStyle$
 None=����	#00000000 � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $
��100* ��� $	��10* �.+�� $��0�� � RowDefinitions �� $	��20* ��� $	��20* ��� $	��20* �.+�� $��0��$��5q�
���   � �� $	��20* ��� $	��15* ��� $	��15* ��� $
��100* �.+�� $��0��.+��� -    ��Name$ BTN_OPEN_REPLAY_DATA��   TITLE_PLAY_BACK_DATA#���   $��2q�
�������
���   �$��16(�
�������� $��1��$��0,3,0,3q�.+��� -   $��CHECK_BOX_PRO��$	��PRO��
�������$��16(�� $��2��$��0,3,0,3q�.+��� -   $��CHECK_BOX_AG��$��AG��
�������$��16(�� $��3��$��8q�
���   �.+��� -    ��Name$  TextBlock_Replay_Data_Path��$�� ��$��16(�
�������$
��Left=�$��Center=�� $��1��
���   �$��5q� �� $	��20* ��� $
��100* �.+�� $��0��$��5q�.+��� -   $ TextBlock_Replay_Progress��  TITLE_REPLAY_PROGRESS#���  $��16(�
�������
���   �$��Center=�$��Center=�� $��1��$��5q�.+��� -    ��Name$ Slider_Replay_Progress��$��23��	 �� Delay$	 0��
 � Maximum$	
 100Q� � SmallChange$ 0.001Q�� $��2��
���   �$��5q� �� $	��20* ��� $
��100* �.+�� $��0��$��5q�.+��� -   $ TextBlock_Replay_Speed��  TITLE_REPLAY_RATE#���  $��16(�
�������
���   �$��Center=�$��Center=�� $��1��$��5q�.+��� -	   $ Slider_Replay_Rate��$��23��$	 0�� � Value$ 50Q�$	
 100Q�� $��1�� �� $	��20* ��� $	��20* ��� $	��20* �.+�� $��0��$��5q�.+��� -
   $ BTN_REPLAY_CONTINUE��  TITLE_BEGIN#���  $��2q�
�������
���   �$��16(�
�������� $��1��$��5q�.+��� -   $ BTN_REPLAY_PAUSE��  TITLE_PAUSE#���  $��2q�
�������
���   �$��16(�
�������� $��2��$��5q�.+��� -   $ BTN_REPLAY_EXIT��  	TITLE_END#���  $��2q�
�������
���   �$��16(�
�������