   M S B A M L   `   `   `  ����
  VK_GCS     VIKGroundStation.winSplash   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	winSplash��5   	   $	��450��6   $	��700��6(   
���   �$��1q�6J    � WindowStyle$
 None=�5       � 
ResizeMode$ NoResize=�6/    � ShowInTaskbar .   � Topmost .  � WindowStartupLocation$ CenterScreen=�6j   .��5      �  � RowDefinitions 5   
   �� 5	      $
��100* �6   �� 5
      $��5* �6   �� 5      $	��10* �6   .+�5   
   � $��0��6   ��5      �� 5       �� ImageSource$ Images/启动界面.bmp��6   5      � 5   
   $��1��6   .+�5      �� -   5        $��TextBlock_Wait��5      
��� ���$I��C请选择飞机类型和工作模式，再点击 OK 进入系统...��6B    �� TextAlignment$
 Left=�6g   $��15(�6}   $��SemiBold"�6�   5      � 5   
   $��2��6   
������	 � ColumnDefinitions	 5      �� 5      $	��15* �6#   �� 5      $	��10* �6#   �� 5      $��5* �6#   �� 5      $��5* �6#   .+�5      � $��0��6   .+�5      �� -   5        $��combox_plane_type��5      $��Center=�66   $��Center=�6S   $	��250��6n   $��16(�6z   $��SemiBold"�6�   |�.  6�   5      � 5      $��1��6   .+�5       �� -   5        $��combox_single_many��5       $��Center=�67   $��Center=�6T   $	��200��6o   $��16(�6{   $��SemiBold"�6�   |�.  6�   5!      � 5"      $��2��6   $��3q�6#   .+�5#      �� -   5        
 ��Name$
 BTN_START_UP��5#      $��2q�6/   $��OK��6C   $��30��6Q   $��16(�6]   $��SemiBold"�6k   
�������
������ $��Center=�6�   ��5$      �� 5%       �� 
TargetType" ��6*   .R�5&      �� $��PART_Background��6�   #��z��6%   $��2q�6Y    �� CornerRadius$ 5,5,5,5��6m   ._�5'   "   �� #��z��63   $��Center=�6f   $��Center=�6�   5(       �� Triggers 5)      P� 5*   "    P� Property �@J�IsMouseOver P� Value . . �5+   &   ��  �� 
TargetName$ PART_Background��6J    �� Property � �� �� Value 5,   *   �� 5-   .    �� EndPoint$	 0,1&�6B    �� 
StartPoint$	 0,0&�6Q   .��5.   2   �  � Color$
 Gray��6?    � Offset$	 0.5Q�6L   5/   /   51   '   52   #   54      56      57      � 58      $��3��6   $��3q�6#   .+�59      �� -   5        $
 BTN_SHUT_DOWN��59      $��2q�60   $
��EXIT��6D   $��30��6T   $��16(�6`   $��SemiBold"�6n   
�������
������ $��Center=�6�   ��5:      �� 5;      " ��6*   .R�5<      �� $��PART_Background��6�   #��z��6%   $��2q�6Y   $ 5,5,5,5��6m   ._�5=   "   �� #��z��63   $��Center=�6f   $��Center=�6�   5>       5?      P� 5@   "    �@J�IsMouseOver . . �5A   &   �� $ PART_Background��6J    � �� 5B   *   �� 5C   .   $	 0,1&�6B   $	 0,0&�6Q   .��5D   2   � $
 Gray��6?   $	 0.5Q�6L   5E   /   5G   '   5H   #   5J      5L      5M      5N      5O      5P      