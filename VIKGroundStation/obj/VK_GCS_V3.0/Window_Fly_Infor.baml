   M S B A M L   `   `   `  ����>  :HUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&clr-namespace:HUD;assembly=HUDHUD  5   	   
 VK_GCS'   !VIKGroundStation.Window_Fly_Infor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .hudclr-namespace:HUD;assembly=HUD     5   	   -   5        $	��600��5   	   $	��300��6     � AllowsTransparency  .  � WindowStyle$
 None=�6>    � WindowStartupLocation$ Manual=�6Q    � 
ResizeMode$ NoResize=�6p   ���	#60300090.��5	      � 
������  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��0q�6   $	��Top=�6(   .+�5         HUD.HUDControl  -   5          Name$ ATTITUDE_PANEL��5      5      � 5   
   $��1��6   $��4q�6   .+�5       �� -   5         ��Name$ TextBlock_Attitude��5       $�� ��65   $��14(�6=   $��SemiBold"�6K   
������$��Center=�6y   $��Center=�6�   5!      � 5"   
   $��2��6   $��4q�6    � ColumnDefinitions 5#      �� 5$      $��1* �6#   �� 5%      $��0.015* �6#   �� 5&      $��1* �6#   .+�5(      � $��0��6   .+�5)      �� -   5        $" TextBlock_Alt_Control_Status��5)         TITLE_ALT_CONTROL_STATIC#���   6C   $��13(�6u   $��SemiBold"�6�   
�������$
��Left=�6�   $��Center=�6�   5*      � 5+      $��1��6   .+�5,      �� 
��� ���$��3q�6.   ._�5-      �� $��Center=�6(   $��Center=�6E   5.      5/      � 50      $��2��6   .+�51      �� -   5        $ TextBlock_Noise_Kx��51        TITLE_ZHEN_DONG_STATIC#���  69   $��13(�6i   $��SemiBold"�6w   
�������$��Right=�6�   $��Center=�6�   52      53      � 54   
   $��3��6   $��4q�6    55      �� 56      $��1* �6#   �� 57      $��0.015* �6#   �� 58      $��1* �6#   .+�5:      � $��0��6   .+�5;      �� -   5        $ TextBlock_Head_Type��5;        TITLE_HEAD_TYPE#���  6:   $��13(�6c   $��SemiBold"�6q   
�������$
��Left=�6�   $��Center=�6�   5<      � 5=      $��1��6   .+�5>      �� 
��� ���$��3q�6.   ._�5?      �� $��Center=�6(   $��Center=�6E   5@      5A      � 5B      $��2��6   .+�5C      �� -   5        $ TextBlock_Temperature��5C        TITLE_TEMPERATURE#���  6<   $��13(�6g   $��SemiBold"�6u   
�������$��Right=�6�   $��Center=�6�   5D      5E      � 5F   
   $��4��6   $��4q�6   
��� ���.+�5G      ��   TITLE_FLY_INFORMATION#���  6   $��14(�6H   $��SemiBold"�6V   
�������$��Center=�6   $��Center=�6�   5H      � 5I   
   $��5��6   $��4q�6    5J      �� 5K      $��1* �6#   �� 5L      $��0.015* �6#   �� 5M      $��1* �6#   .+�5O      � $��0��6   .+�5P      �� -   5        $ TextBlock_Flied_Time��5P        TITLE_FLIED_TIME#���  6;   $��13(�6e   $��SemiBold"�6s   
�������$
��Left=�6�   $��Center=�6�   5Q      � 5R      $��1��6   .+�5S      �� 
��� ���$��3q�6.   ._�5T      �� $��Center=�6(   $��Center=�6E   5U      5V      � 5W      $��2��6   .+�5X      �� -	   5        $ TextBlock_Flied_Dist��5X        TITLE_FLIED_DIST#���  6;   $��13(�6e   $��SemiBold"�6s   
�������$��Right=�6�   $��Center=�6�   5Y      5Z      � 5[   
   $��6��6   $��4q�6    5\      �� 5]      $��1* �6#   �� 5^      $��0.015* �6#   �� 5_      $��1* �6#   .+�5a      � $��0��6   .+�5b      �� -
   5        $ TextBlock_Total_Dist��5b        TITLE_WPT_TOTAL_DIST#���  6;   $��13(�6i   $��SemiBold"�6w   
�������$
��Left=�6�   $��Center=�6�   5c      � 5d      $��1��6   .+�5e      �� 
��� ���$��3q�6.   ._�5f      �� $��Center=�6(   $��Center=�6E   5g      5h      � 5i      $��2��6   .+�5j      �� -   5        $ TextBlock_Dist_Home��5j        TITLE_DIST_HOME_STATIC#���  6:   $��13(�6j   $��SemiBold"�6x   
�������$��Right=�6�   $��Center=�6�   5k      5l      � 5m   
   $��7��6   $��4q�6    5n      �� 5o      $��1* �6#   �� 5p      $��0.015* �6#   �� 5q      $��1* �6#   .+�5s      � $��0��6   .+�5t      �� -   5        $ TextBlock_Motor_Balance��5t       	 TITLE_MOTOR_BALANCE_STATIC#��� 	 6>   $��13(�6r   $��SemiBold"�6�   
�������$
��Left=�6�   $��Center=�6�   5u      � 5v      $��1��6   .+�5w      �� 
��� ���$��3q�6.   ._�5x      �� $��Center=�6(   $��Center=�6E   5y      5z      � 5{      $��2��6   .+�5|      �� -   5        $ TextBlock_Basic_Throttle��5|       
 TITLE_BASIC_STATIC#��� 
 6?   $��13(�6k   $��SemiBold"�6y   
�������$��Right=�6�   $��Center=�6�   5}      5~      � 5   
   $��8��6   $��4q�6   
��� ���.+�5�      ��   TITLE_GPS_INFORMATION#���  6   $��14(�6H   $��SemiBold"�6V   
�������$��Center=�6   $��Center=�6�   5�      � 5�   
   $��9��6   $��4q�6    5�      �� 5�      $��1* �6#   �� 5�      $��0.015* �6#   �� 5�      $��1* �6#   .+�5�      � $��0��6   .+�5�      �� -   5        $ TextBlock_Zhu_Gps_Status��5�      $��GPS-A:��6?   $��13(�6M   $��SemiBold"�6[   
�������$
��Left=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� 
��� ���$��3q�6.   ._�5�      �� $��Center=�6(   $��Center=�6E   5�      5�      � 5�      $��2��6   .+�5�      �� -   5        $ TextBlock_Cong_Gps_Status��5�      $��GPS-B:��6@   $��13(�6N   $��SemiBold"�6\   
�������$��Right=�6�   $��Center=�6�   5�      5�      � 5�   
   $��10��6   $��4q�6    5�      �� 5�      $��1* �6#   �� 5�      $��0.015* �6#   �� 5�      $��1* �6#   .+�5�      � $��0��6   .+�5�      �� -   5        $ TextBlock_MagA_Status��5�      $��MAG-A:��6<   $��13(�6J   $��SemiBold"�6X   
�������$
��Left=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� 
��� ���$��3q�6.   ._�5�      �� $��Center=�6(   $��Center=�6E   5�      5�      � 5�      $��2��6   .+�5�      �� -   5        $ TextBlock_MagB_Status��5�      $��MAG-B:��6<   $��13(�6J   $��SemiBold"�6X   
�������$��Right=�6�   $��Center=�6�   5�      5�      � 5�   
   $��11��6   $��4q�6    5�      �� 5�      $��1* �6#   �� 5�      $��0.015* �6#   �� 5�      $��1* �6#   .+�5�      � $��0��6   .+�5�      �� -   5        $ TextBlock_Plane_Lon��5�      $
��Lon:��6:   $��13(�6F   $��SemiBold"�6T   
�������$
��Left=�6}   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� 
��� ���$��3q�6.   ._�5�      �� $��Center=�6(   $��Center=�6E   5�      5�      � 5�      $��2��6   .+�5�      �� -   5        $ TextBlock_Plane_Lat��5�      $
��Lat:��6:   $��13(�6F   $��SemiBold"�6T   
�������$��Right=�6}   $��Center=�6�   5�      5�      � 5�   
   $��12��6   $��4q�6    5�      �� 5�      $��1* �6#   �� 5�      $��0.015* �6#   �� 5�      $��1* �6#   .+�5�      � $��0��6   .+�5�      �� -   5        $ TextBlock_GPS_Alt��5�        TITLE_GPS_ALT#���  68   $��13(�6_   $��SemiBold"�6m   
�������$
��Left=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� 
��� ���$��3q�6.   ._�5�      �� $��Center=�6(   $��Center=�6E   5�      5�      � 5�      $��2��6   .+�5�      �� -   5        $ TextBlock_Follow_Dist��5�        TITLE_FOLLOW_DIST#���  6<   $��13(�6g   $��SemiBold"�6u   
�������$��Right=�6�   $��Center=�6�   5�      5�      � 5�   
   $��13��6   $��4q�6   
��� ���.+�5�      ��   TITLE_RADAR_INFORMATION#���  6   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5�      � 5�   
   $��14��6   $��4q�6    5�      �� 5�      $��1* �6#   �� 5�      $��0.015* �6#   �� 5�      $��1* �6#   .+�5�      � $��0��6   .+�5�      �� -   5        $  TextBlock_Front_Radar_Dist��5�        TITLE_FRONT_RADAR_DIST#���  6A   $��13(�6q   $��SemiBold"�6   
�������$
��Left=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� 
��� ���$��3q�6.   ._�5�      �� $��Center=�6(   $��Center=�6E   5�      5�      � 5�      $��2��6   .+�5�      �� -   5        $ TextBlock_Back_Radar_Dist��5�        TITLE_BACK_RADAR_DIST#���  6@   $��13(�6o   $��SemiBold"�6}   
�������$��Right=�6�   $��Center=�6�   5�      5�      � 5�   
   $��15��6   $��4q�6    5�      �� 5�      $��1* �6#   �� 5�      $��0.015* �6#   �� 5�      $��1* �6#   .+�5�      � $��0��6   .+�5�      �� -   5        $ TextBlock_Alt_Radar_Dist��5�        TITLE_ALT_RADAR_DIST#���  6?   $��13(�6m   $��SemiBold"�6{   
�������$
��Left=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� 
��� ���$��3q�6.   ._�5�      �� $��Center=�6(   $��Center=�6E   5�      5�      5�      5�      5�      