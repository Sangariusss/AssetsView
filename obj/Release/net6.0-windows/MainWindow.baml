   M S B A M L   `   `   `  ���� E  AAssetsView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AssetsView.MVVM.ViewModelAssetsView.MVVM.ViewModel      AssetsView.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =	viewModel'clr-namespace:AssetsView.MVVM.ViewModel     -     � Title$  
AssetsView��$	��811��$
��1024�� � AllowsTransparency$
 True�����#000000 � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� J� InputBindings �� 
 �� Key$ S�� �� 	Modifiers$ Controlf� �� Command �� *DashboardViewCommand+�� $ E��$ Controlf� �� *SettingsViewCommand+�� $ G��$	 Altf� �� *HelpViewCommand+	 � DataContext	 -  'AssetsView.MVVM.ViewModel.MainViewModel  .��� 
 � RowDefinitions
 �� $��30 ��� $��* � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ TitleBar��$��1��$��30��$��Center=� K� ZIndex$ 1��
���   ��� -    ��Name$ VerticalPanel��$��2��$��0��$	��100��$��Stretch=����#0E0E0E.+�� 
 �� $��97 ��� $	��373 ��� $��* �$	��461���� $
��Auto �.+��� -    ��Name$ 	LogoImage��$��0��$��55��$��45��$��
22,52,23,0q�$��/Data/Icons/logo.png��	� -    	�Name$ DashboardButton��$��1��$��93��$��
0,93,0,186q����#0E0E0E
������  � Cursor$
 Hand��   RadioButtonHoverStyle#���   ���� *DashboardViewCommand+ d� 	IsChecked �� *IsDashboardSelected+ �� Mode$ TwoWay=�.��� .+��� $��25��$��25��$��/Data/Icons/dashboard.png���� -    ��Name$ DashboardRectangle��${�False��  OpacityStyle#���   � ToolTip _�   ButtonToolTipStyle#��[  _� PlacementTarget ��  �� ElementName$ DashboardButton��.���� -    ��Name$% DashboardRadioButtonToolTipText��$��13,8,0,0q�$��13(�$��Regular"�  TextBlockGrayStyle#��[ $��	Dashboard��	� -   $ SettingButton��$��1��$��93��$��
0,186,0,93q����#0E0E0E
������ $
 Hand��#���   ���� *SettingsViewCommand+ �� *IsSettingsSelected+$ TwoWay=�.��� .+��� $��25��$��25��$��/Data/Icons/settings.png���� -	   $ SettingRectangle��$��22��$��21��${�False��#���   _� #��[  �� $ DashboardButton��.���� -
   $$ SettingsRadioButtonToolTipText��$��19,8,0,0q�$��13(�$��Regular"�#��[ $��Settings��	� -   $ 
HelpButton��$��1��$��93��$��	0,280,0,0q����#0E0E0E
������ $
 Hand��#���   ���� *HelpViewCommand+ �� *IsHelpSelected+$ TwoWay=�.��� .+��� $��25��$��25��$��/Data/Icons/help.png���� -   $ HelpRectangle��${�False��#���   _� #��[  �� $ DashboardButton��.���� -   $  HelpRadioButtonToolTipText��$��28,8,0,0q�$��13(�$��Regular"�#��[ $
��Help���� -    ��Name$ 
ExitButton��$��3��$	��100��$��93��$��Bottom=����#0E0E0E
������ $
 Hand��  ButtonHoverStyle#���  .��� .+��� $��25��$��25��$��/Data/Icons/logout.png�� _� #��[  �� $ DashboardButton��.���� $��31,8,0,0q�$��13(�$��Regular"�#��[ $
��Exit���� $��1��$��2��$��1������ *CurrentView+