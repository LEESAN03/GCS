   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  #    VIKGroundStation.Window_Chart   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:VIKGroundStation     [ WDynamicDataDisplay, Version=0.2.1.401, Culture=neutral, PublicKeyToken=5b7d744a7263923f<c4http://research.microsoft.com/DynamicDataDisplay/1.0  -   $	��600��$
��1000��  � Title$  Data Analysis��$��18(�
�������
���   � � WindowStartupLocation$ CenterScreen=�.���� .��� $
��2000�� � RowDefinitions �� $��1* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* �.+�� $��0�� � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $	��25* �.+�� $��0��$��2q�.+��� -    ��Name$ MENUE_BTN_CHART_CENTRAL��$��0q�
���   �$��16(�
�����������  �� 
TargetType" ��.R��� #��z��$��3q� �� CornerRadius$ 0������  �� ImageSource$ Images/centralView.png��._��� #��z��$��Center=�$��Center=�� $��1��$��2q�.+��� -   $ MENUE_BTN_CHART_ZOOM_IN��$��0q�
���   �$��16(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/zoom_in.png��._��� #��z��$��Center=�$��Center=�� $��2��$��2q�.+��� -   $ MENUE_BTN_CHART_ZOOM_OUT��$��0q�
���   �$��16(�
����������� " ��.R��� #��z��$��3q�$ 0������ $ Images/zoom_out.png��._��� #��z��$��Center=�$��Center=�� $��1��.+�8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  -   $��plotter_attitude��
�������3  -Microsoft.Research.DynamicDataDisplay.Plotter   Children. 2  ,Microsoft.Research.DynamicDataDisplay.Header  $��横滚俯仰��� $��2��.+�  -   $��plotter_xyGyro��
�������.   $��横滚俯仰陀螺��� $��3��.+�  -   $��plotter_yaw��
�������.   $��航向��� $��4��.+�  -   $��plotter_mag��
�������.   $��	磁力计��� $��5��.+�  -	   $��plotter_climb_rate��
�������.   $��高度��� $��6��.+�  -
   $��plotter_speed��
�������.   $��速度��� $��7��.+�  -   $��plotter_pwm_input��
�������.   $��遥控器输入��� $��8��.+�  -   $��plotter_pwm_output��
�������.   $��电机输出��