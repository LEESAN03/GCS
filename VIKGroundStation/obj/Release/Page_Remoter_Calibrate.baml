   M S B A M L   `   `   `  ���� K  GVIKGroundStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VIKGroundStationVIKGroundStation  ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration X TAvionicsInstrumentControlDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltRclr-namespace:AvionicsInstrumentControlDemo;assembly=AvionicsInstrumentControlDemoAvionicsInstrumentControlDemo -    'VIKGroundStation.Page_Remoter_Calibrate   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:VIKGroundStation     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     gzedgraphRclr-namespace:AvionicsInstrumentControlDemo;assembly=AvionicsInstrumentControlDemo       N� Title$  Page_Remoter_Calibrate��.��� $��2q�
���   � � ColumnDefinitions �� $	��20* ��� $
��100* ��� $
��100* �.+�� $��1�� � RowDefinitions �� $	��50* ��� $	��89* ��� $	��80* ��� $	��50* �.+�� $��1�� �� $
��100* ��� $
��100* �.+�� $��0��$��10q�.+�7  1System.Windows.Forms.Integration.WindowsFormsHost  -   $��yibiao_head��   Child. D  >AvionicsInstrumentControlDemo.TurnCoordinatorInstrumentControl  -   Turn_Elevator_Direction��� $��1��$��10q�.+�  -   $��pad_yaokong2��.   -   Turn_Aileron_Throttle��� $��2�� �� $
��160* ��� $
��100* ��� $
��100* ��� $
��140* �.+�� $��1�� �� $	��20* ��� $	��80* ��� $	��80* ��� $	��20* �.+�� $��1��.+��� -   $��Text_Block_Elevator��   TITLE_ELEVATOR#���   $��16(�
�������$
��Left=�$��Center=�� $��2��.+��� -   $��Text_Block_Aileron��  TITLE_AILERON#���  $��16(�
�������$
��Left=�$��Center=�� $��2�� �� $	��20* ��� $	��80* ��� $	��80* ��� $	��20* �.+�� $��1��.+��� -   $��Text_Block_Throttle��  TITLE_THROTTLE#���  $��16(�
�������$
��Left=�$��Center=�� $��2��.+��� -   $��Text_Block_Rudder��  TITLE_RUDDER#���  $��16(�
�������$
��Left=�$��Center=�� $��2�� �� $
��100* ��� $
��120* ��� $	��80* ��� $
��120* ��� $	��80* ��� $
��120* ��� $	��80* ��� $	��50* ��� $
��150* ��� $
��200* �.+�� $��0��� $��1��$��5q�.+�  -	   $
��pad1��. K  EAvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl  -
   Turn_Channel5��� $��2�� �� $
��100* ��� $
��100* ��� $
��100* �.+�� $��0��.+���   	TITLE_GPS#���  $��16(�
�������$��Center=�$	��Top=�� $��1��� $��2��.+���   TITLE_ATTITUDE#���  $��16(�
�������$��Center=�$	��Top=�� $��3��$��5q�.+�  -   $
��pad2��.   -   Turn_Channel6��� $��4�� �� $
��100* ��� $
��100* ��� $
��100* �.+�� $��0��.+���   TITLE_CIRCLE_ONE_POINT#���  $��16(�
�������$��Center=�$	��Top=�� $��1��.+���   TITLE_AUTO_HEAD#���  $��16(�
�������$��Center=�$	��Top=�� $��2��.+���   TITLE_LOCK_HEAD#���  $��16(�
�������$��Center=�$	��Top=�� $��5��$��5q�.+�  -   $
��pad3��.   -   Turn_Channel7��� $��6�� �� $
��100* ��� $
��100* ��� $
��100* �.+�� $��0��.+���  	 TITLE_REMOTOR_LOST#��� 	 $��16(�
�������$��Center=�$	��Top=�� $��1��.+���  
 TITLE_BACK_HOME#��� 
 $��16(�
�������$��Center=�$	��Top=�� $��2��.+���   TITLE_ALL_RIGHT#���  $��16(�
�������$��Center=�$	��Top=�� $��7��� $��8�� �� $
��100* ��� $
��100* �.+�� $��0��$��20q�.+��� -   $��BTN_RC_CALIBRATE_START��  TITLE_START_CALIBRATION#���  $��3q����	#00DDDDDD$��18(�
�������� $��1��$��20q�.+��� -   $��BTN_RC_CALIBRATE_END��  TITLE_END_CALIBRATION#���  $��3q����	#00DDDDDD$��18(�
�������