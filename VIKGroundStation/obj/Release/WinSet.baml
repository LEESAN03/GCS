   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  X TAvionicsInstrumentControlDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltRclr-namespace:AvionicsInstrumentControlDemo;assembly=AvionicsInstrumentControlDemoAvionicsInstrumentControlDemo  VIKGroundStation   VIKGroundStation.WinSet   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     gzedgraphRclr-namespace:AvionicsInstrumentControlDemo;assembly=AvionicsInstrumentControlDemo     -     � Title$  
Window_Set��$	��600��$
��1000�� � WindowStyle$
 None=� � AllowsTransparency .  ���	#CD818181 � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType   listboxitem1 �� Property	 �� Value  listbox1  GrenalLabel  GrenalTextBox  GrenalCheckBox  GrenalTextBlock  GrenalButton
 �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� EndPoint �� 
StartPoint � Color � Offset3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   	Direction   Opacity   RenderingBias   ShadowDepth  BoxRadioButton33 �Name J� SnapsToDevicePixels  Expander ��Name �� ImageSource j� Stretch  ]�Name! � OverridesDefaultStyle" d� 	IsChecked# �� Path$ �� Mode% �� RelativeSource& �� ContentStringFormat' �� ContentStringFormat( j� 
AlignmentX) j� 
AlignmentY* j� TileMode+ �� Member 	 ExpandListItemStyle, 9� 
IsExpanded 
 
MostSimple  UploadButtonStyle- F�Name. �� Stretch/ ��Name��%  &	        &	 #     &	 �     &	 v    &	 :    &	 �    &	     &	 D    &	     &		 \
    7  &	
 -    7 	 &	 �    �� " ��.���  � ��	 Z� �� " ��.���  � ��$	 Center=���  � ��$	 Disabled=���  � ��$	 Disabled=���  � ��	 Z� ��  � ��$	 0q���  � ��$	 0q��� " ��.���  � ��
	 �   ���  � ��$	 18(���  � ��$	 Center=���  � ��	 �	#001D2A33��  � ��$	 0q���  � ��$	 0q���  � ��$		 220���� " ��.���  � ��
	 �������  � ��$	 18(���  � ��	 Z� ��  �@��TextAlignment$	 Center=���  � ��$	 Center=���  � ��$	 Center=���  � ��$		 100���� " ��.���  � ��
	 �������  � ��$	 18(���  � ��$
	 Left=���  � ��$	 Center=��� " ��.���  � ��
	 �������  � ��$	 18(���  � ��$
	 Left=���  � ��$	 Center=��� " ��.���  � ��
	 �������  � ��$	 18(���  � ��	 �	#00DDDDDD��  � ��	 �� "
 ��.R��� $��PART_Background��
�������$��1q�$ 10q�$ 5,5,5,5��$��Center=�$��Center=�._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � ��	 �� $	 0,1&�$	 0,0&�.��� $ Silver��$	 0.0Q�� $
 Gray��$	 0.5Q�� $ Silver��$	 0.0Q�P�  � �� . . ���  �@J�Effect	   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q��� " 	�.���  � ��
	 ���� ��  � ��
	 �������  � ��
	 ���� ��  � ��$	 3 2 3 2q���  � ��$	 18(���  � ��$	 2q���  � ��$
	 auto����  �@J�SnapsToDevicePixels	 . ��  � ��	 �� "
 	�.R�� $
 grid��.+��� #��z��$ 5,5,5,5��#��z��#��z��#��z��#��z��._��� $��Center=�$��Center=�#��z��# z  P�  �@J�IsMouseOver . . ���  � ��
	 �   ���  � ��	 �	#FF249AD4�� "
 9�.R��� $ bd��$��1q�$ 4,4,0,0������ $# Images/设置栏未选中.png��$
 Fill=���
� ._�]� $  ContentHeight��.+�d� $��
HeaderSite��! . #��z��
�������$��Center=�$��Center=�$��20��$��20��$��30��$��0q�" �� $# 
IsExpanded�$$ TwoWay=�% �� *TemplatedParent+���� " d�.���  � ��	 �� "
 d�.R��� ��.   . �� $��
ExpandSite��#��z��#��z��#' z& #��z��#��z��$y�	Collapsed=�|�.   P�  �@9�
IsExpanded . . ��� $ 
ExpandSite�� � y�$	 Visible=��� $ bd�� � ��	 �� $  Images/设置栏选中.png��$ Uniform=�$( Center=�$	) Top=�$* FlipX=�P�  �@9�ExpandDirection. ��� $ 
ExpandSite�� � ��	 �� $+ Dock.Bottom���� $ 
HeaderSite�� � ��	 �� $+ Dock.Top�� �� $+ ExpandDirection.Down���� " ��.���  � ��	 �� "
 ��.R��� ._��� ��Z� ._�9� #��z��8��  $��16(����� % �� *TemplatedParent+$# (ListBoxItem.Tag)�, �� *
IsSelected+% �� *TemplatedParent+�� " ��.���  �@��SelectionMode$	 Single=���  � ��
	 ���� ��  � ��$	 Disabled=���  � ��$	 Disabled=���  � ��8	   �� " ��.���  � ��	 �#627b9c��  � ��
	 �������  � ��$	 15(���  �@J�SnapsToDevicePixels	 . ��  � ��	 �� "
 ��.R��� $ 4��#��z��._�� .+��� $��Center=�.+�F� $- PathIcon��$��18��$��12��$
. Fill=����#1d2a33$��Center=�$��0q�F����@KL     �    ��� р� ��� р� ���� z ���� z ��� р�� ��� $��0��$	��Top=��� $/ TextContent��$��update�����#1d2a33$��Center=�$	��Top=� P�  �@J�IsMouseOver . . ���  � ��	 �#10a4e7��  � ��
	 ������� $ PathIcon�� � ��	 �#ffffff�� $ TextContent�� � ��	 �#ffffffP�  � �� . . ���  � ��	 �#10a4a7��  � ��
	 �����.��� $��2q�0 � RowDefinitions0 �� $
��1.3* ��� $	��24* �.+�� $��0�����	#FF1D2A331 � ColumnDefinitions1 �� $	��30* ��� $��1* �.+�� $��1��.+��� -   2 ��Name$2 CLose��$��X��$��3q�
���   ����	#33DDDDDD$��16(�
����������� "
 ��.R��� $��PART_Background��#��z��$��1q�$ 1,1,1,1��._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ PART_Background�� � ��	 �� $	 0,1&�$	 0,0&�.��� $	 Red��$	 0.0Q�� $	 Red��$	 0.5Q�� $	 Red��$	 0.0Q�P�  � �� . . ���  �@J�Effect	   $ 10Q�$ Black��$ 0Q�$	 0.6Q�$ Performance=�$ 0Q�� $��1��1 �� $��2* ��� $��7* �.+�� $��0��.+��� #��[
 ���	#20000000.@��� -   3 ��Name$3 	飞行器��  TITLE_PLANE
4 � Tag#4 �  .���� -   $��list1��$��Center=����	#CD818181$��0q�.@��� -   $/ button1��  TITLE_PLANE_TYPE_SETTINGS#���  $��20(����	#00DDDDDD�� -   $3 感度调节��  TITLE_PID_ADJUST#4 �  .���� $��Center=����	#CD818181.@��� -   $/ button5��  TITLE_GYRO_PID#���  $��20(�� $��1��.+��� -   $��tctlConfigMainPart��$��0q�
���   �.@��� -	   $��	tabCanshu��.��� .+�� .+���   TITLE_BASIC_SETTINGS#���  {�. 
�������$��10,10,10,76q�$��17(�
�������5 J� OpacityMask5 �	#FF462107.��� .+��� -
   6 ��Name$6 jixing��$��276,20,383,385q�$��18(�$��80��.@���   TITLE_USUAL_PLANE_TYPE#���  ��   TITLE_PLANE_TYPE_TRIGGLE#���  ��   TITLE_PLANE_TYPE_V_TAIL#���  �� $
��Wrap=�  TITLE_SELECT_PLANE_TYPE#���  
�������$��18(�$��35,21,511,390q��� -   $��txtCircleRadius��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��29��$
��Left=�$��	35,59,0,0q�$��转弯距离(m)��$	��Top=�$	��181���� -   $��txtLostContactTime��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��29��$
��Left=�$��	35,99,0,0q�$��自动横滚限幅(度)��$	��Top=�$	��236���� -   $��set_guding2��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��
276,59,0,0q�$��0��$	��Top=�$��80��$��Center=��� -   $��set_guding3��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��
276,99,0,0q�$��0��$	��Top=�$��80��$��Center=��� -   $��txtAlarmVoltage��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��31��$
��Left=�$��
35,138,0,0q�$��自动俯仰限幅(度)��$	��Top=�$	��214���� -   $��set_guding4��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��276,138,0,0q�$��0��$	��Top=�$��80��$��Center=��� -   $��txtOpenningHeight��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��28��$
��Left=�$��
399,23,0,0q�$��最小空速��$	��Top=�$	��193���� -   $��set_guding5��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��
617,21,0,0q�$��0��$	��Top=�$��80��$��Center=��� -   $��txtJixingPaizhaojiange��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��29��$
��Left=�$��
399,63,0,0q�$��巡航空速��$	��Top=�$	��213���� -   $��set_guding6��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��
617,63,0,0q�$��0��$	��Top=�$��80��$��Center=��� -   $/ txtAlarmVoltage_Copy��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��31��$
��Left=�$��398,100,0,0q�$��最大爬升速度��$	��Top=�$	��214���� -   $/ txtAlarmVoltage_Copy1��$��Microsoft YaHei)�$��18(�$��Normal"�
�������$��31��$
��Left=�$��399,141,0,0q�$��最大下降速度��$	��Top=�$	��193���� -   7 ��Name$7 set_guding7��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��616,103,0,0q�$��0��$	��Top=�$��80��$��Center=��� -   $7 set_guding8��$��Microsoft YaHei)�$��18(�$��Normal"����	#FF5B5B5B$��30��$
��Left=�$��617,142,0,0q�$��0��$	��Top=�$��80��$��Center=�� $��
0,582,0,39q�.+��� -   $��btnShangchuan��$��40��$��135,-82,500,42q�$��17(�$
��Bold"�
�������|�.    	TITLE_SET#���  
����������	#4C644A4A�� -   $��btnHuoqu��$��40��$��321,-82,308,42q�$��17(�$
��Bold"�
�������|�.    TITLE_FETCH#���  
����������	#4C644A4A�� -   $��
tabPIDGao3��8 �� 
IsSelected8 .  $	��Top=�$��0,0,0,0q�.��� .+�� $��24,43,553,124q�.+��� $��50��$��0,0,0,0q�$��横滚比例系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��0,42,0,0q�$��横滚积分系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��0,85,0,0q�$��横滚阻尼系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	0,128,0,0q�$��横滚积分限幅��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	0,177,0,0q�$��俯仰比例系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	0,224,0,0q�$��俯仰积分系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	3,273,0,0q�$��俯仰阻尼系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	5,314,0,0q�$��俯仰积分限幅��$
��Left=�$	��Top=�$��19(�
�������� $��388,43,189,124q�.+��� $��50��$��0,0,0,0q�$��高度比例系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��0,42,0,0q�$��垂直速度比例系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��0,85,0,0q�$��垂直速度积分系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	0,128,0,0q�$��油门比例系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	0,177,0,0q�$��油门积分系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	0,224,0,0q�$��偏航比例系数��$
��Left=�$	��Top=�$��19(�
��������� $��50��$��	3,273,0,0q�$��航向比例系数��$
��Left=�$	��Top=�$��19(�
�������� $��253,43,412,151q�.+��� -   $��txtpid1��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��0,2,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -   $��txtpid2��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��0,46,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -   $��txtpid3��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��0,90,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -   $��txtpid4��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,135,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -    $��txtpid5��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,181,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -!   $��txtpid6��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,227,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -"   $��txtpid7��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,272,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -#   $��txtpid8��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,318,0,0q�$	��Top=�$��85�����	#FF5B5B5B� $��608,43,57,151q�.+��� -$   $��txtpid9��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��0,2,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -%   $��txtpid10��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��0,46,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -&   $��txtpid11��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��0,90,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -'   $��txtpid12��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,135,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -(   $��txtpid13��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,181,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -)   $��txtpid14��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,227,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -*   $��txtpid15��$��Microsoft YaHei)�$��20(�$��Normal"�
��� � �$��30��$
��Left=�$��	0,272,0,0q�$	��Top=�$��85�����	#FF5B5B5B�� -+   $��btnSetAdvancedPid1��$��40��$��143,460,501,48q�$	��120��$��17(�$
��Bold"�
�������$��设定��|�.  
����������	#4C644A4A�� -,   $��btnGetAdvancedPid1��$��40��$��352,460,292,48q�$	��120��$��17(�$
��Bold"�
�������$��获取��|�.  
����������	#4C644A4A