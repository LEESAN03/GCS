   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5      A =VK_GCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation 5      &    VIKGroundStation.Page_Motor_Test   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:VIKGroundStation     5        N� Title$  Page_Motor_Test��5
       � 	Resources 5       �� 
TargetType   SimpleProgressBar �� Property �� Value �� 
TargetType �Name ��Name J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName �� Angle��%�  &	        �� 5   
   " �6   .�5      ��  �@�Maximum$ 1Q�6(   �� 5       �@�Value$ 0Q�6&   �� 5       � ��$ 10��6'   �� 5       � �� .  6*   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      " �6&   .R�5      � $
 Root��6   .+�5      �� $ 
PART_Track��6%   #��z��69   # z 5   !   �� 5      $ PART_Indicator��6&   $
��Left=�6>   #��z��6Y   # z 5   !   5      	 5       P� 5!      
 �@�Orientation$ Vertical=�6=   . �5"   "   �� $
 Root��6D    �@�LayoutTransform 5#   &   �� 5$   *   $	 -90Q�6:   5&   #   5'      5)      5+      5,      5-      .��5.      � $��2q�6   
���   � � ColumnDefinitions 5/   
   �� 50      $��0* �6   �� 51      $
��300* �6   .+�53   
   � $��1��6    � RowDefinitions 54      �� 55      $
��100* �6    60   �� 56      $
��600* �6    60   �� 57      $
��100* �6    60   .+�59      � $��1��6    5:      �� 5;      $
��100* �6$   64   �� 5<      $
��100* �6$   64   �� 5=      $
��100* �6$   64   �� 5>      $
��100* �6$   64   .+�5@      � $��0��6    5A      �� 5B      $	��10* �6+   �� 5C      $
��100* �6+   �� 5D      $	��20* �6+   �� 5E      $	��10* �6+   �� 5F      $
��100* �6+   �� 5G      $	��20* �6+   .+�5I      � $��0��6   $��2,0,2,0q�6,   .+�5J      ��   TITLE_MOTOR1#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5K      � 5L      $��1��6   $��2,0,2,0q�6+   .+�5M      � -   5         �Name$ Motor1_Output��5M   3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5N      � 5O      $��2��6   $��25��6+   $��2,0,2,0q�67   .+�5P      �� -   5         ��Name$ Btn_Motor1_Test��5P   !     
TITLE_TEST#���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5Q      �� 5R   "   " ��62   .R�5S   &   �� $��PART_Background��6�   #��z��6-   $��1q�6a    �� CornerRadius$ 5,5,5,5��6u   ._�5T   *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5U   '   	 5V   &   P� 5W   *   
 �@J�IsMouseOver . . �5X   .   �� $ PART_Background��6R    � �� 5Y   2   �� 5Z   6    �� EndPoint$	 0,1&�6J    �� 
StartPoint$	 0,0&�6Y   .��5[   :   �  � Color$
 Gray��6G    � Offset$	 0.5Q�6T   5\   7   5^   /   5_   +   5a   #   5c      5d      � 5e      $��3��6   $��2,0,2,0q�6+   .+�5f      ��   TITLE_MOTOR2#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5g      � 5h      $��4��6   $��2,0,2,0q�6+   .+�5i      � -   5        $ Motor2_Output��5i   3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5j      � 5k      $��5��6   $��25��6+   $��2,0,2,0q�67   .+�5l      �� -   5        $ Btn_Motor2_Test��5l   !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5m      �� 5n   "   " ��62   .R�5o   &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�5p   *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5q   '   	 5r   &   P� 5s   *   
 �@J�IsMouseOver . . �5t   .   �� $ PART_Background��6R    � �� 5u   2   �� 5v   6   $	 0,1&�6J   $	 0,0&�6Y   .��5w   :   � $
 Gray��6G   $	 0.5Q�6T   5x   7   5z   /   5{   +   5}   #   5      5�      5�      � 5�      $��1��6    5�      �� 5�      $	��10* �6+   �� 5�      $
��100* �6+   �� 5�      $	��20* �6+   �� 5�      $	��10* �6+   �� 5�      $
��100* �6+   �� 5�      $	��20* �6+   .+�5�      � $��0��6   $��2,0,2,0q�6+   .+�5�      ��   TITLE_MOTOR3#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   $��2,0,2,0q�6+   .+�5�      � -   5        $ Motor3_Output��5�   3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5�      � 5�      $��2��6   $��25��6+   $��2,0,2,0q�67   .+�5�      �� -   5        $ Btn_Motor3_Test��5�   !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5�      �� 5�   "   " ��62   .R�5�   &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�5�   *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5�   '   	 5�   &   P� 5�   *   
 �@J�IsMouseOver . . �5�   .   �� $ PART_Background��6R    � �� 5�   2   �� 5�   6   $	 0,1&�6J   $	 0,0&�6Y   .��5�   :   � $
 Gray��6G   $	 0.5Q�6T   5�   7   5�   /   5�   +   5�   #   5�      5�      � 5�      $��3��6   $��2,0,2,0q�6+   .+�5�      ��   TITLE_MOTOR4#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��4��6   $��2,0,2,0q�6+   .+�5�      � -   5        $ Motor4_Output��5�   3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5�      � 5�      $��5��6   $��25��6+   $��2,0,2,0q�67   .+�5�      �� -   5        $ Btn_Motor4_Test��5�   !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5�      �� 5�   "   " ��62   .R�5�   &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�5�   *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5�   '   	 5�   &   P� 5�   *   
 �@J�IsMouseOver . . �5�   .   �� $ PART_Background��6R    � �� 5�   2   �� 5�   6   $	 0,1&�6J   $	 0,0&�6Y   .��5�   :   � $
 Gray��6G   $	 0.5Q�6T   5�   7   5�   /   5�   +   5�   #   5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $	��10* �6+   �� 5�      $
��100* �6+   �� 5�      $	��20* �6+   �� 5�      $	��10* �6+   �� 5�      $
��100* �6+   �� 5�      $	��20* �6+   .+�5�      � $��0��6   $��2,0,2,0q�6+   .+�5�      ��   TITLE_MOTOR5#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��1��6   $��2,0,2,0q�6+   .+�5�      � -	   5        $ Motor5_Output��5�   3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5�      � 5�      $��2��6   $��25��6+   $��2,0,2,0q�67   .+�5�      �� -
   5        $ Btn_Motor5_Test��5�   !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5�      �� 5�   "   " ��62   .R�5�   &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�5�   *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5�   '   	 5�   &   P� 5�   *   
 �@J�IsMouseOver . . �5�   .   �� $ PART_Background��6R    � �� 5�   2   �� 5�   6   $	 0,1&�6J   $	 0,0&�6Y   .��5�   :   � $
 Gray��6G   $	 0.5Q�6T   5�   7   5�   /   5�   +   5�   #   5�      5�      � 5�      $��3��6   $��2,0,2,0q�6+   .+�5�      ��   TITLE_MOTOR6#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5�      � 5�      $��4��6   $��2,0,2,0q�6+   .+�5�      � -   5        $ Motor6_Output��5�   3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5�      � 5�      $��5��6   $��25��6+   $��2,0,2,0q�67   .+�5�      �� -   5        $ Btn_Motor6_Test��5�   !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5�      �� 5�   "   " ��62   .R�5�   &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�5�   *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5�   '   	 5�   &   P� 5�   *   
 �@J�IsMouseOver . . �5�   .   �� $ PART_Background��6R    � �� 5�   2   �� 5�   6   $	 0,1&�6J   $	 0,0&�6Y   .��5�   :   � $
 Gray��6G   $	 0.5Q�6T   5�   7   5   /   5  +   5  #   5     5     5     � 5     $��3��6    5	     �� 5
     $	��10* �6+   �� 5     $
��100* �6+   �� 5     $	��20* �6+   �� 5     $	��10* �6+   �� 5     $
��100* �6+   �� 5     $	��20* �6+   .+�5     � $��0��6   $��2,0,2,0q�6+   .+�5     ��   TITLE_MOTOR7#���  6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5     � 5     $��1��6   $��2,0,2,0q�6+   .+�5     � -   5        $ Motor7_Output��5  3   $��20��6'   
����İ�
��� E��#��[  6}   6�   5     � 5     $��2��6   $��25��6+   $��2,0,2,0q�67   .+�5     �� -   5        $ Btn_Motor7_Test��5  !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������5     �� 5  "   " ��62   .R�5  &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�5  *   �� #��z��6;   $��Center=�6n   $��Center=�6�   5  '   	 5  &   P� 5  *   
 �@J�IsMouseOver . . �5   .   �� $ PART_Background��6R    � �� 5!  2   �� 5"  6   $	 0,1&�6J   $	 0,0&�6Y   .��5#  :   � $
 Gray��6G   $	 0.5Q�6T   5$  7   5&  /   5'  +   5)  #   5+     5,     � 5-     $��3��6   $��2,0,2,0q�6+   .+�5.     ��  	 TITLE_MOTOR8#��� 	 6%   $��14(�6K   $��SemiBold"�6Y   
�������$��Center=�6�   $��Center=�6�   5/     � 50     $��4��6   $��2,0,2,0q�6+   .+�51     � -   5        $ Motor8_Output��51  3   $��20��6'   
����İ�
��� E��#��[  6}   6�   52     � 53     $��5��6   $��25��6+   $��2,0,2,0q�67   .+�54     �� -   5        $ Btn_Motor8_Test��54  !   #���  6:   $��2q�6a   
�������
���   �$��14(�6�   $��SemiBold"�6�   
���������55     �� 56  "   " ��62   .R�57  &   �� $��PART_Background��6�   #��z��6-   $��1q�6a   $ 5,5,5,5��6u   ._�58  *   �� #��z��6;   $��Center=�6n   $��Center=�6�   59  '   	 5:  &   P� 5;  *   
 �@J�IsMouseOver . . �5<  .   �� $ PART_Background��6R    � �� 5=  2   �� 5>  6   $	 0,1&�6J   $	 0,0&�6Y   .��5?  :   � $
 Gray��6G   $	 0.5Q�6T   5@  7   5B  /   5C  +   5E  #   5G     5H     5I     5J     5K     5L     5M     