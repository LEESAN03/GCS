   M S B A M L   `   `   `  ����A  =VK_GCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  5      $    VIKGroundStation.Page_Pid_Para   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:VIKGroundStation     5        N� Title$  Page_Pid_Para��5	      .��5      � $��2q�6   
���   � � ColumnDefinitions 5   
   �� 5      $	��20* �6   �� 5      $
��250* �6   �� 5      $	��20* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $��5* �6    �� 5      $	��10* �6    �� 5      $	��10* �6    �� 5      $	��10* �6    �� 5      $��5* �6    �� 5      $	��10* �6    �� 5      $	��10* �6    �� 5      $	��10* �6    �� 5      $��5* �6    �� 5      $	��10* �6    �� 5      $	��10* �6    �� 5      $	��10* �6    �� 5      $��5* �6    �� 5       $	��10* �6    �� 5!      $	��10* �6    �� 5"      $	��10* �6    �� 5#      $	��10* �6    �� 5$      $��5* �6    �� 5%      $	��10* �6    �� 5&      $	��10* �6    �� 5'      $	��10* �6    �� 5(      $	��10* �6    �� 5)      $��5* �6    �� 5*      $	��10* �6    �� 5+      $��5* �6    �� 5,      $	��10* �6    �� 5-      $��5* �6    .+�5/      � $��1��6   $��3q�6!    50      �� 51      $	��30* �6'   �� 52      $	��10* �6'   �� 53      $
��100* �6'   �� 54      $	��10* �6'   �� 55      $	��10* �6'   .+�57      � $��0��6   .+�58      ��    TITLE_ROLL_GYRO_P#���   6!   $��14(�6L   $��SemiBold"�6Z   
�������$��Center=�6�   $��Center=�6�   59      � 5:      $��1��6   .+�5;      �� -   5         ��Name$ BTN_ROLL_GYRO_DECREASE��5;      $��-��6=   
����������	#00DDDDDD$��15(�6u   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5<      � 5=      $��2��6   .+�5>      �� -   5         ��Name$ SLIDER_ROLL_GYRO_P��5>   *   $��20��6    � Value$	 120Q�6H    �� Delay$ 0��6T    � Minimum$ 50Q�6^    � Maximum$	 300Q�6k   	 � SmallChange$	 1Q�6z   $��Center=�6�   5?      � 5@      $��3��6   .+�5A      �� -   5        $ BTN_ROLL_GYRO_INCREASE��5A      $��+��6=   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5B      � 5C      $��4��6   .+�5D      �� -   5        $��TextBlock_ROLL_GYRO_P��5D   !   $	��120��6>   $��14(�6I   $��SemiBold"�6W   
�������$��Center=�6�   $��Center=�6�   5E      5F      � 5G      $��2��6   $��3q�6!    5H      �� 5I      $	��30* �6'   �� 5J      $	��10* �6'   �� 5K      $
��100* �6'   �� 5L      $	��10* �6'   �� 5M      $	��10* �6'   .+�5O      � $��0��6   .+�5P      ��   TITLE_ROLL_ANGLE_P#���  6!   $��14(�6M   $��SemiBold"�6[   
�������$��Center=�6�   $��Center=�6�   5Q      � 5R      $��1��6   .+�5S      �� -   5        $ BTN_ROLL_ANGLE_DECREASE��5S      $��-��6>   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5T      � 5U      $��2��6   .+�5V      �� -   5        $ SLIDER_ROLL_ANGLE_P��5V   *   $��20��6   $	 450Q�6I   $ 0��6U   $	 200Q�6_   $	 700Q�6m   $	 1Q�6|   $��Center=�6�   5W      � 5X      $��3��6   .+�5Y      �� -   5        $ BTN_ROLL_ANGLE_INCREASE��5Y      $��+��6>   
����������	#00DDDDDD$��15(�6w   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5Z      � 5[      $��4��6   .+�5\      �� -   5        $��TextBlock_ROLL_ANGLE_P��5\   !   $	��450��6?   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5]      5^      � 5_      $��3��6   $��3q�6!    5`      �� 5a      $	��30* �6'   �� 5b      $	��10* �6'   �� 5c      $
��100* �6'   �� 5d      $	��10* �6'   �� 5e      $	��10* �6'   .+�5g      � $��0��6   .+�5h      ��   TITLE_ROLL_GYRO_D#���  6!   $��14(�6L   $��SemiBold"�6Z   
�������$��Center=�6�   $��Center=�6�   5i      � 5j      $��1��6   .+�5k      �� -	   5        $ BTN_ROLL_ZUNI_DECREASE��5k      $��-��6=   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5l      � 5m      $��2��6   .+�5n      �� -
   5        $ SLIDER_ROLL_ZUNI��5n   *   $��20��6   $ 6Q�6F   $ 0��6P   $ 0Q�6Z   $ 20Q�6f   $	 1Q�6t   $��Center=�6�   5o      � 5p      $��3��6   .+�5q      �� -   5        $ BTN_ROLL_ZUNI_INCREASE��5q      $��+��6=   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5r      � 5s      $��4��6   .+�5t      �� -   5        $��TextBlock_ROLL_ZUNI��5t   !   $��6��6<   $��14(�6E   $��SemiBold"�6S   
�������$��Center=�6|   $��Center=�6�   5u      5v      � 5w      $��5��6   $��3q�6!    5x      �� 5y      $	��30* �6'   �� 5z      $	��10* �6'   �� 5{      $
��100* �6'   �� 5|      $	��10* �6'   �� 5}      $	��10* �6'   .+�5      � $��0��6   .+�5�      ��   TITLE_PITCH_GYRO_P#���  6!   $��14(�6M   $��SemiBold"�6[   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� -   5        $ BTN_PITCH_GYRO_DECREASE��5�      $��-��6>   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��2��6   .+�5�      �� -   5        $ SLIDER_PITCH_GYRO_P��5�   *   $��20��6   $	 120Q�6I   $ 0��6U   $ 50Q�6_   $	 300Q�6l   $	 1Q�6{   $��Center=�6�   5�      � 5�      $��3��6   .+�5�      �� -   5        $ BTN_PITCH_GYRO_INCREASE��5�      $��+��6>   
����������	#00DDDDDD$��15(�6w   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��4��6   .+�5�      �� -   5        $��TextBlock_PITCH_GYRO_P��5�   !   $	��120��6?   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5�      5�      � 5�      $��6��6   $��3q�6!    5�      �� 5�      $	��30* �6'   �� 5�      $	��10* �6'   �� 5�      $
��100* �6'   �� 5�      $	��10* �6'   �� 5�      $	��10* �6'   .+�5�      � $��0��6   .+�5�      ��   TITLE_PITCH_ANGLE_P#���  6!   $��14(�6N   $��SemiBold"�6\   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� -   5        $ BTN_PITCH_ANGLE_DECREASE��5�      $��-��6?   
����������	#00DDDDDD$��15(�6w   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��2��6   .+�5�      �� -   5        $ SLIDER_PITCH_ANGLE_P��5�   *   $��20��6   $	 450Q�6J   $ 0��6V   $	 200Q�6`   $	 700Q�6n   $	 1Q�6}   $��Center=�6�   5�      � 5�      $��3��6   .+�5�      �� -   5        $ BTN_PITCH_ANGLE_INCREASE��5�      $��+��6?   
����������	#00DDDDDD$��15(�6x   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��4��6   .+�5�      �� -   5        $��TextBlock_PITCH_ANGLE_P��5�   !   $	��450��6@   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      5�      � 5�      $��7��6   $��3q�6!    5�      �� 5�      $	��30* �6'   �� 5�      $	��10* �6'   �� 5�      $
��100* �6'   �� 5�      $	��10* �6'   �� 5�      $	��10* �6'   .+�5�      � $��0��6   .+�5�      ��   TITLE_PITCH_GYRO_D#���  6!   $��14(�6M   $��SemiBold"�6[   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� -   5        $ BTN_PITCH_ZUNI_DECREASE��5�      $��-��6>   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��2��6   .+�5�      �� -   5        $ SLIDER_PITCH_ZUNI��5�   *   $��20��6   $ 6Q�6G   $ 0��6Q   $ 0Q�6[   $ 20Q�6g   $	 1Q�6u   $��Center=�6�   5�      � 5�      $��3��6   .+�5�      �� -   5        $ BTN_PITCH_ZUNI_INCREASE��5�      $��+��6>   
����������	#00DDDDDD$��15(�6w   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��4��6   .+�5�      �� -   5        $��TextBlock_PITCH_ZUNI��5�   !   $��6��6=   $��14(�6F   $��SemiBold"�6T   
�������$��Center=�6}   $��Center=�6�   5�      5�      � 5�      $��9��6   $��3q�6!    5�      �� 5�      $	��30* �6'   �� 5�      $	��10* �6'   �� 5�      $
��100* �6'   �� 5�      $	��10* �6'   �� 5�      $	��10* �6'   .+�5�      � $��0��6   .+�5�      ��   TITLE_YAW_GYRO_P#���  6!   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� -   5        $ BTN_YAW_GYRO_DECREASE��5�      $��-��6<   
����������	#00DDDDDD$��15(�6t   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��2��6   .+�5�      �� -   5        $ SLIDER_YAW_GYRO_P��5�   *   $��20��6   $	 350Q�6G   $ 0��6S   $	 100Q�6]   $	 600Q�6k   $	 1Q�6z   $��Center=�6�   5�      � 5�      $��3��6   .+�5�      �� -   5        $ BTN_YAW_GYRO_INCREASE��5�      $��+��6<   
����������	#00DDDDDD$��15(�6u   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��4��6   .+�5�      �� -   5        $��TextBlock_YAW_GYRO_P��5�   !   $	��350��6=   $��14(�6H   $��SemiBold"�6V   
�������$��Center=�6   $��Center=�6�   5�      5�      � 5�      $��10��6   $��3q�6"    5�      �� 5�      $	��30* �6'   �� 5�      $	��10* �6'   �� 5�      $
��100* �6'   �� 5�      $	��10* �6'   �� 5�      $	��10* �6'   .+�5�      � $��0��6   .+�5�      ��   TITLE_YAW_ANGLE_P#���  6!   $��14(�6L   $��SemiBold"�6Z   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� -   5        $ BTN_YAW_ANGLE_DECREASE��5�      $��-��6=   
����������	#00DDDDDD$��15(�6u   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��2��6   .+�5�      �� -   5        $ SLIDER_YAW_ANGLE_P��5�   *   $��20��6   $	 450Q�6H   $ 0��6T   $	 200Q�6^   $	 700Q�6l   $	 1Q�6{   $��Center=�6�   5�      � 5�      $��3��6   .+�5�      �� -   5        $ BTN_YAW_ANGLE_INCREASE��5�      $��+��6=   
����������	#00DDDDDD$��15(�6v   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��4��6   .+�5�      �� -    5        $��TextBlock_YAW_ANGLE_P��5�   !   $	��450��6>   $��14(�6I   $��SemiBold"�6W   
�������$��Center=�6�   $��Center=�6�   5�      5�      � 5�      $��11��6   $��3q�6"    5�      �� 5�      $	��30* �6'   �� 5�      $	��10* �6'   �� 5�      $
��100* �6'   �� 5�      $	��10* �6'   �� 5�      $	��10* �6'   .+�5�      � $��0��6   .+�5�      ��   TITLE_YAW_GYRO_D#���  6!   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   .+�5�      �� -!   5        $ BTN_YAW_ZUNI_DECREASE��5�      $��-��6<   
����������	#00DDDDDD$��15(�6t   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�      � 5�      $��2��6   .+�5�      �� -"   5        $ SLIDER_YAW_ZUNI��5�   *   $��20��6   $ 6Q�6E   $ 0��6O   $ 0Q�6Y   $ 20Q�6e   $	 1Q�6s   $��Center=�6�   5�      � 5      $��3��6   .+�5     �� -#   5        $ BTN_YAW_ZUNI_INCREASE��5     $��+��6<   
����������	#00DDDDDD$��15(�6u   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5     � 5     $��4��6   .+�5     �� -$   5        $��TextBlock_YAW_ZUNI��5  !   $��6��6;   $��14(�6D   $��SemiBold"�6R   
�������$��Center=�6{   $��Center=�6�   5     5     � 5     $��13��6   $��3q�6"    5     �� 5	     $	��30* �6'   �� 5
     $	��10* �6'   �� 5     $
��100* �6'   �� 5     $	��10* �6'   �� 5     $	��10* �6'   .+�5     � $��0��6   .+�5     ��  	 TITLE_ALT_DIST_P#��� 	 6!   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5     � 5     $��1��6   .+�5     �� -%   5        $" BTN_VERTICAL_DIST_P_DECREASE��5     $��-��6C   
����������	#00DDDDDD$��15(�6{   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5     � 5     $��2��6   .+�5     �� -&   5        $ SLIDER_VERTICAL_DIST_P��5  *   $��20��6   $ 80Q�6L   $ 0��6W   $ 20Q�6a   $	 150Q�6n   $	 1Q�6}   $��Center=�6�   5     � 5     $��3��6   .+�5     �� -'   5        $" BTN_VERTICAL_DIST_P_INCREASE��5     $��+��6C   
����������	#00DDDDDD$��15(�6|   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5     � 5     $��4��6   .+�5     �� -(   5        $��TextBlock_VERTICAL_DIST_P��5  !   $��80��6B   $��14(�6L   $��SemiBold"�6Z   
�������$��Center=�6�   $��Center=�6�   5     5     � 5     $��14��6   $��3q�6"    5      �� 5!     $	��30* �6'   �� 5"     $	��10* �6'   �� 5#     $
��100* �6'   �� 5$     $	��10* �6'   �� 5%     $	��10* �6'   .+�5'     � $��0��6   .+�5(     ��  
 TITLE_ALT_VEL_P#��� 
 6!   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5)     � 5*     $��1��6   .+�5+     �� -)   5        $# BTN_VERTICAL_SPEED_P_DECREASE��5+     $��-��6D   
����������	#00DDDDDD$��15(�6|   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5,     � 5-     $��2��6   .+�5.     �� -*   5        $ SLIDER_VERTICAL_SPEED_P��5.  *   $��20��6   $	 300Q�6M   $ 0��6Y   $	 200Q�6c   $	 500Q�6q   $	 1Q�6�   $��Center=�6�   5/     � 50     $��3��6   .+�51     �� -+   5        $# BTN_VERTICAL_SPEED_P_INCREASE��51     $��+��6D   
����������	#00DDDDDD$��15(�6}   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   52     � 53     $��4��6   .+�54     �� -,   5        $ ��TextBlock_VERTICAL_SPEED_P��54  !   $	��300��6C   $��14(�6N   $��SemiBold"�6\   
�������$��Center=�6�   $��Center=�6�   55     56     � 57     $��15��6   $��3q�6"    58     �� 59     $	��30* �6'   �� 5:     $	��10* �6'   �� 5;     $
��100* �6'   �� 5<     $	��10* �6'   �� 5=     $	��10* �6'   .+�5?     � $��0��6   .+�5@     ��   TITLE_ALT_ACC_P#���  6!   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5A     � 5B     $��1��6   .+�5C     �� --   5        $! BTN_VERTICAL_ACC_P_DECREASE��5C     $��-��6B   
����������	#00DDDDDD$��15(�6z   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5D     � 5E     $��2��6   .+�5F     �� -.   5        $ SLIDER_VERTICAL_ACC_P��5F  *   $��20��6   $ 25Q�6K   $ 0��6V   $ 10Q�6`   $	 100Q�6m   $	 1Q�6|   $��Center=�6�   5G     � 5H     $��3��6   .+�5I     �� -/   5        $! BTN_VERTICAL_ACC_P_INCREASE��5I     $��+��6B   
����������	#00DDDDDD$��15(�6{   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5J     � 5K     $��4��6   .+�5L     �� -0   5        $��TextBlock_VERTICAL_ACC_P��5L  !   $��25��6A   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5M     5N     � 5O     $��16��6   $��3q�6"    5P     �� 5Q     $	��30* �6'   �� 5R     $	��10* �6'   �� 5S     $
��100* �6'   �� 5T     $	��10* �6'   �� 5U     $	��10* �6'   .+�5W     � $��0��6   .+�5X     ��   TITLE_ALT_ACC_I#���  6!   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5Y     � 5Z     $��1��6   .+�5[     �� -1   5        $! BTN_VERTICAL_ACC_I_DECREASE��5[     $��-��6B   
����������	#00DDDDDD$��15(�6z   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5\     � 5]     $��2��6   .+�5^     �� -2   5        $ SLIDER_VERTICAL_ACC_I��5^  *   $��20��6   $ 15Q�6K   $ 0��6V   $ 5Q�6`   $ 50Q�6l   $	 1Q�6z   $��Center=�6�   5_     � 5`     $��3��6   .+�5a     �� -3   5        $! BTN_VERTICAL_ACC_I_INCREASE��5a     $��+��6B   
����������	#00DDDDDD$��15(�6{   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5b     � 5c     $��4��6   .+�5d     �� -4   5        $��TextBlock_VERTICAL_ACC_I��5d  !   $��15��6A   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5e     5f     � 5g     $��18��6   $��3q�6"    5h     �� 5i     $	��30* �6'   �� 5j     $	��10* �6'   �� 5k     $
��100* �6'   �� 5l     $	��10* �6'   �� 5m     $	��10* �6'   .+�5o     � $��0��6   .+�5p     ��   TITLE_HORIZON_DIST_P#���  6!   $��14(�6O   $��SemiBold"�6]   
�������$��Center=�6�   $��Center=�6�   5q     � 5r     $��1��6   .+�5s     �� -5   5        $! BTN_HORIZON_DIST_P_DECREASE��5s     $��-��6B   
����������	#00DDDDDD$��15(�6z   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5t     � 5u     $��2��6   .+�5v     �� -6   5        $ SLIDER_HORIZON_DIST_P��5v  *   $��20��6   $ 80Q�6K   $ 0��6V   $ 50Q�6`   $	 150Q�6m   $	 1Q�6|   $��Center=�6�   5w     � 5x     $��3��6   .+�5y     �� -7   5        $! BTN_HORIZON_DIST_P_INCREASE��5y     $��+��6B   
����������	#00DDDDDD$��15(�6{   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5z     � 5{     $��4��6   .+�5|     �� -8   5        $��TextBlock_HORIZON_DIST_P��5|  !   $��80��6A   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5}     5~     � 5     $��19��6   $��3q�6"    5�     �� 5�     $	��30* �6'   �� 5�     $	��10* �6'   �� 5�     $
��100* �6'   �� 5�     $	��10* �6'   �� 5�     $	��10* �6'   .+�5�     � $��0��6   .+�5�     ��   TITLE_HORIZON_VEL_P#���  6!   $��14(�6N   $��SemiBold"�6\   
�������$��Center=�6�   $��Center=�6�   5�     � 5�     $��1��6   .+�5�     �� -9   5        $" BTN_HORIZON_SPEED_P_DECREASE��5�     $��-��6C   
����������	#00DDDDDD$��15(�6{   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��2��6   .+�5�     �� -:   5        $ SLIDER_HORIZON_SPEED_P��5�  *   $��20��6   $	 120Q�6L   $ 0��6X   $ 80Q�6b   $	 200Q�6o   $	 1Q�6~   $��Center=�6�   5�     � 5�     $��3��6   .+�5�     �� -;   5        $" BTN_HORIZON_SPEED_P_INCREASE��5�     $��+��6C   
����������	#00DDDDDD$��15(�6|   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��4��6   .+�5�     �� -<   5        $��TextBlock_HORIZON_SPEED_P��5�  !   $	��120��6B   $��14(�6M   $��SemiBold"�6[   
�������$��Center=�6�   $��Center=�6�   5�     5�     � 5�     $��20��6   $��3q�6"    5�     �� 5�     $	��30* �6'   �� 5�     $	��10* �6'   �� 5�     $
��100* �6'   �� 5�     $	��10* �6'   �� 5�     $	��10* �6'   .+�5�     � $��0��6   .+�5�     ��   TITLE_HORIZON_ACC_P#���  6!   $��14(�6N   $��SemiBold"�6\   
�������$��Center=�6�   $��Center=�6�   5�     � 5�     $��1��6   .+�5�     �� -=   5        $  BTN_HORIZON_ACC_P_DECREASE��5�     $��-��6A   
����������	#00DDDDDD$��15(�6y   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��2��6   .+�5�     �� ->   5        $ SLIDER_HORIZON_ACC_P��5�  *   $��20��6   $ 25Q�6J   $ 0��6U   $ 10Q�6_   $	 100Q�6l   $	 1Q�6{   $��Center=�6�   5�     � 5�     $��3��6   .+�5�     �� -?   5        $  BTN_HORIZON_ACC_P_INCREASE��5�     $��+��6A   
����������	#00DDDDDD$��15(�6z   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��4��6   .+�5�     �� -@   5        $��TextBlock_HORIZON_ACC_P��5�  !   $��25��6@   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5�     5�     � 5�     $��21��6   $��3q�6"    5�     �� 5�     $	��30* �6'   �� 5�     $	��10* �6'   �� 5�     $
��100* �6'   �� 5�     $	��10* �6'   �� 5�     $	��10* �6'   .+�5�     � $��0��6   .+�5�     ��   TITLE_HORIZON_SPEED_I#���  6!   $��14(�6P   $��SemiBold"�6^   
�������$��Center=�6�   $��Center=�6�   5�     � 5�     $��1��6   .+�5�     �� -A   5        $  BTN_HORIZON_ACC_I_DECREASE��5�     $��-��6A   
����������	#00DDDDDD$��15(�6y   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��2��6   .+�5�     �� -B   5        $ SLIDER_HORIZON_ACC_I��5�  *   $��20��6   $ 20Q�6J   $ 0��6U   $ 0Q�6_   $ 50Q�6k   $	 1Q�6y   $��Center=�6�   5�     � 5�     $��3��6   .+�5�     �� -C   5        $  BTN_HORIZON_ACC_I_INCREASE��5�     $��+��6A   
����������	#00DDDDDD$��15(�6z   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��4��6    5�     �� 5�     $	��10* �6+   �� 5�     $��7* �6+   .+�5�     �� -D   5        $��TextBlock_HORIZON_ACC_I��5�  !   $��20��6@   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   $��2��6�   5�     5�     � 5�     $��23��6   $��3q�6"    5�     �� 5�     $	��30* �6'   �� 5�     $	��10* �6'   �� 5�     $
��100* �6'   �� 5�     $	��10* �6'   �� 5�     $	��10* �6'   .+�5�     � $��0��6   .+�5�     ��   TITLE_BRAKE_K#���  6!   $��14(�6H   $��SemiBold"�6V   
�������$��Center=�6   $��Center=�6�   5�     � 5�     $��1��6   .+�5�     �� -E   5        $  BTN_HORIZON_BREAK_DECREASE��5�     $��-��6A   
����������	#00DDDDDD$��15(�6y   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��2��6   .+�5�     �� -F   5        $ SLIDER_HORIZON_BREAK��5�  *   $��20��6   $ 20Q�6J   $ 0��6U   $ 10Q�6_   $ 20Q�6l   $	 1Q�6z   $��Center=�6�   5�     � 5�     $��3��6   .+�5�     �� -G   5        $  BTN_HORIZON_BREAK_INCREASE��5�     $��+��6A   
����������	#00DDDDDD$��15(�6z   $��SemiBold"�6�   
�������$��22��6�   $��20��6�   6�   5�     � 5�     $��4��6   .+�5�     �� -H   5        $��TextBlock_HORIZON_BREAK��5�  !   $��20��6@   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   5�     5�     � 5�     $��25��6    5�     �� 5�     $
��100* �6'   �� 5�     $
��100* �6'   �� 5�     $
��100* �6'   �� 5�     $	��10* �6'   �� 5�     $
��100* �6'   .+�5�     � $��2��6   .+�5�     �� -I   5        $ BTN_GET_BASIC_PID��5�       
TITLE_READ#���  68   $��2q�6_   
����������	#00DDDDDD$��14(�6�   $��SemiBold"�6�   
�������$��25��6�   $��80��6�   ��5�     �� 5�     
 �� 
TargetType"
 ��6.   .R�5�  "   �� $��PART_Background��6�   #��z��6)   $��1q�6]    �� CornerRadius$ 5,5,5,5��6q   ._�5�  &   �� #��z��67   $��Center=�6j   $��Center=�6�   5�  #    �� Triggers 5�  "   P� 5�  &    P� Property �@J�IsMouseOver P� Value . . �5�  *   ��  �� 
TargetName$ PART_Background��6N    �� Property � �� �� Value 5�  .   �� 5�  2    �� EndPoint$	 0,1&�6F    �� 
StartPoint$	 0,0&�6U   .��5�  6   �  � Color$
 Gray��6C    � Offset$	 0.5Q�6P   5�  3   5�  +   5�  '   5�     5�     5      � 5     $��4��6   .+�5     �� -J   5        $ BTN_SET_BASIC_PID��5       	TITLE_SET#���  68   $��2q�6^   
����������	#00DDDDDD$��14(�6�   $��SemiBold"�6�   
�������$��25��6�   $��80��6�   ��5     �� 5     "
 ��6.   .R�5  "   �� $��PART_Background��6�   #��z��6)   $��1q�6]   $ 5,5,5,5��6q   ._�5  &   �� #��z��67   $��Center=�6j   $��Center=�6�   5  #    5  "   P� 5	  &    �@J�IsMouseOver . . �5
  *   �� $ PART_Background��6N    � �� 5  .   �� 5  2   $	 0,1&�6F   $	 0,0&�6U   .��5  6   � $
 Gray��6C   $	 0.5Q�6P   5  3   5  +   5  '   5     5     5     5     5     5     5     