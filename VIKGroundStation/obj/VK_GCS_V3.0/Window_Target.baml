   M S B A M L   `   `   `  ����A  =VK_GCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  5   	   $    VIKGroundStation.Window_Target   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:VIKGroundStation     5   	     � Title$  Window_Target��5   	   $��80��6   $	��200��6+    � AllowsTransparency .  � WindowStyle$
 None=�6S    � WindowStartupLocation$ CenterScreen=�6f    � ShowInTaskbar .  ���	#00000000.��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��5q�6   
����� � � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��2* �6#   �� 5      $��2* �6#   .+�5      � $��0��6   $��3q�6#   .+�5      �� -   5        $��TextBlock_Target_Value��5      $��目标高度��6;   $��14(�6G   $��SemiBold"�6U   
�������$��Center=�6~   $��Center=�6�   5      � 5      $��1��6   $��3q�6#   .+�5      �� -   5        $��TextBox_Target_Value��5      $��20��66   $��14(�6B   $��SemiBold"�6P   $��15��6f   
����� �
������� �� TextAlignment$ Center=�6�   $��Center=�6�   5      � 5      $��2��6   $��3q�6#   .+�5      �� -   5        $��TextBlock_Target_Unit��5      $��20��69   $��14(�6E   $��SemiBold"�6S   $��m��6i   
����� �
������� �� TextAlignment$ Center=�6�   $��Center=�6�   5      5      � 5   
   $��1��6   $��5q�6   
����� � 5       �� 5!      $��2* �6#   �� 5"      $��2* �6#   �� 5#      $��2* �6#   .+�5&      � $��0��6   $��3q�6#   .+�5'      �� -   5        	 ��Name$	 BTN_TARGET_OK��5'         TITLE_OK#���   60   $��23��6V   $��50��6b   $��1q�6m   
�������$��14(�6�   $��SemiBold"�6�   
�������
��� ���6�   5(      � 5)      $��1��6   $��3q�6#   .+�5*      �� -   5        $	 BTN_TARGET_CANCEL��5*        TITLE_CANCEL#���  64   $��23��6^   $��50��6k   $��1q�6v   
�������$��14(�6�   $��SemiBold"�6�   
�������
��� ���6�   5+      � 5,      $��2��6   $��3q�6#   .+�5-      �� -   5        $	 BTN_TARGET_EXIT��5-        
TITLE_EXIT#���  62   $��23��6[   $��50��6g   $��1q�6r   
�������$��14(�6�   $��SemiBold"�6�   
�������
��� ���6�   5.      5/      50      51      