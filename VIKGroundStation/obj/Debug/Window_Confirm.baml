   M S B A M L   `   `   `  ����A  =VK_GCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  5   	   %    VIKGroundStation.Window_Confirm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:VIKGroundStation     5   	     � Title$  Window_Confirm��5   	    � AllowsTransparency . $��50��6:   $	��200��6F    � WindowStyle$
 None=�6R    � WindowStartupLocation$ CenterScreen=�6e    � ShowInTaskbar .  ���	#00300090.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ BTN_Y��5         	TITLE_YES#���   6$   $��3q�6K   
�������$��20(�6t   $��SemiBold"�6�   
��� ���$��35��6�   $��80��6�   $��Center=�6�   ��5      �� 5       �� 
TargetType" ��6&   .R�5      �� $��PART_Background��6�   #��z��6!   $��2q�6U    �� CornerRadius$ 5,5,5,5��6i   
����� �._�5      �� #��z��6/   $��Center=�6b   $��Center=�6   5      	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value . . �5   "   ��  �� 
TargetName$ PART_Background��6F    �� Property � �� �� Value 5   &   �� 5   *    �� EndPoint$	 0,1&�6>    �� 
StartPoint$	 0,0&�6M   .��5   .   �  � Color$
 Gray��6;    � Offset$	 0.5Q�6H   5   +   5   #   5      5       5"      5#      � 5$   
   $��1��6   .+�5%      �� -   5        $ BTN_N��5%        TITLE_NO#���  6$   
�������$��20(�6`   $��SemiBold"�6n   
��� ���$��35��6�   $��80��6�   $��Center=�6�   ��5&      �� 5'      " ��6&   .R�5(      �� $��PART_Background��6�   #��z��6!   $��2q�6U   $ 5,5,5,5��6i   
����� �._�5)      �� #��z��6/   $��Center=�6b   $��Center=�6   5*      	 5+      P� 5,      
 �@J�IsMouseOver . . �5-   "   �� $ PART_Background��6F    � �� 5.   &   �� 5/   *   $	 0,1&�6>   $	 0,0&�6M   .��50   .   � $
 Gray��6;   $	 0.5Q�6H   51   +   53   #   54      56      58      59      5:      5;      