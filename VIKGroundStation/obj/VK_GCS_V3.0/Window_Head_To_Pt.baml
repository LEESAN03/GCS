   M S B A M L   `   `   `  ����A  =VK_GCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  5   	   (    "VIKGroundStation.Window_Head_To_Pt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:VIKGroundStation     5   	     � Title$  Window_Head_To_Pt��5   	   $	��170��6#   $	��200��60    � WindowStyle$
 None=�6<    � 
ResizeMode$ NoResize=�6O   
������� � ShowInTaskbar .  ���	#60300090.��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   .+�5   
   � $��0��6   
��� ���.+�5      ��    TITLE_SET_FOCUS_PT#���   6   $��14(�6E   $��SemiBold"�6S   
�������$��Center=�6|   $��Center=�6�   5      � 5   
   $��1��6   $��2q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��5* �6#   �� 5      $��1* �6#   .+�5      � $��0��6   $��0q�6#   .+�5      ��   TITLE_LONGITUDE#���  6   $��14(�6F   $��SemiBold"�6T   
�������$��Center=�6}   $��Center=�6�   5      � 5      $��1��6   $��0q�6#   .+�5      �� -   5         ��Name$ TextBox_HOT_PT_LON��5      $��14(�66   $��SemiBold"�6D   $��116.2344232��6[    �� TextAlignment$ Center=�6n   $��Center=�6�   ���	#60300090
�������6�   5       5!      � 5"   
   $��2��6   $��2q�6    5#      �� 5$      $��3* �6#   �� 5%      $��5* �6#   �� 5&      $��1* �6#   .+�5(      � $��0��6   $��0q�6#   .+�5)      ��   TITLE_LATITUDE#���  6   $��14(�6E   $��SemiBold"�6S   
�������$��Center=�6|   $��Center=�6�   5*      � 5+      $��1��6   $��0q�6#   .+�5,      �� -   5        $ TextBox_HOT_PT_LAT��5,      $��14(�66   $��SemiBold"�6D   $��
40.2344232��6Z   $ Center=�6l   $��Center=�6�   ���	#60300090
�������6�   5-      5.      � 5/   
   $��3��6   $��2q�6    50      �� 51      $��3* �6#   �� 52      $��5* �6#   �� 53      $��1* �6#   .+�55      � $��0��6   $��0q�6#   .+�56      ��   TITLE_SEA_LEVEL_ALT#���  6   $��14(�6J   $��SemiBold"�6X   
�������$��Center=�6�   $��Center=�6�   57      � 58      $��1��6   $��0q�6#   .+�59      �� -   5        $ TextBox_HOT_PT_LEVEL_ALT��59      $��14(�6<   $��SemiBold"�6J   $��0��6`   $ Center=�6i   $��Center=�6�   ���	#60300090
�������6�   5:      � 5;      $��2��6   $��0q�6#   .+�5<      �� $��m��6   $��14(�6&   $��SemiBold"�64   
�������$��Center=�6]   $��Center=�6z   5=      5>      � 5?   
   $��4��6   $��2q�6    5@      �� 5A      $��3* �6#   �� 5B      $��5* �6#   �� 5C      $��1* �6#   .+�5E      � $��0��6   $��0q�6#   .+�5F      ��   TITLE_FOCUS#���  6   $��14(�6B   $��SemiBold"�6P   
�������$��Center=�6y   $��Center=�6�   5G      � 5H      $��1��6   $��0q�6#   .+�5I      �� -   5        $��Combox_Hot_Style��5I      $��Center=�65   $��Center=�6S   $	��100��6n   $��25��6{   $��14(�6�   $��SemiBold"�6�   5J      5K      � 5L   
   $��5��6   $��2q�6    5M      �� 5N      $��1* �6#   �� 5O      $��1* �6#   �� 5P      $��3* �6#   �� 5Q      $��3* �6#   .+�5S      � $��2��6   $��2q�6#   .+�5T      �� -   5        $��BTN_CONFIRM_HOT_PT_POS��5T        TITLE_OK#���  6:   $��3q�6_   
�������$��60��6�   $��14(�6�   $��SemiBold"�6�   
���������5U      �� 5V       �� 
TargetType" ��6*   .R�5W      �� $��PART_Background��6�   #��z��6%   $��1q�6Y   	 �� CornerRadius$	 5,5,5,5��6m   ._�5X   "   �� #��z��63   $��Center=�6f   $��Center=�6�   5Y      
 �� Triggers
 5Z      P� 5[   "    P� Property � �� P� Value . . �5\   &   ��  �� Property �@J�Effect �� Value 5]   *   3  -System.Windows.Media.Effects.DropShadowEffect  5^   .      
BlurRadius$ 8Q�6?      Color$ Orange��6N      	Direction$ 0Q�6]      Opacity$	 100Q�6k      RenderingBias$ Performance=�6y      ShadowDepth$ 0Q�6�   5`   '   5a   #   5c      5e      5f      � 5g      $��3��6   $��2q�6#   .+�5h      �� -   5        $��BTN_EXIT_HOT_PT_POS��5h        TITLE_CANCEL#���  66   $��3q�6_   
�������$��60��6�   $��14(�6�   $��SemiBold"�6�   
���������5i      �� 5j      " ��6*   .R�5k      �� $��PART_Background��6�   #��z��6%   $��1q�6Y   $	 5,5,5,5��6m   ._�5l   "   �� #��z��63   $��Center=�6f   $��Center=�6�   5m      
 5n      P� 5o   "    � �� . . �5p   &   ��  �@J�Effect 5q   *     5r   .   $ 8Q�6?   $ Orange��6N   $ 0Q�6]   $	 100Q�6k   $ Performance=�6y   $ 0Q�6�   5t   '   5u   #   5w      5y      5z      5{      5|      5}      