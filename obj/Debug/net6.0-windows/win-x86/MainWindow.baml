   M S B A M L   `   `   `  ����E  AAssetsView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AssetsView.MVVM.ViewModelAssetsView.MVVM.ViewModel  5          AssetsView.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      =	viewModel'clr-namespace:AssetsView.MVVM.ViewModel     5      -   5          � Title$  
AssetsView��5      $	��811��5	      $
��1024��5
       � AllowsTransparency$
 True��5      ���#000000 � 
ResizeMode$ CanMinimize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       J� InputBindings 5      �� 5   
   
 �� Key$ S��5       �� 	Modifiers$ Controlf�5       �� Command 5      �� *DashboardViewCommand+5      �� 5   
   $ E��5      $ Controlf�5       5      �� *SettingsViewCommand+5      �� 5   
   $ G��5      $	 Altf�5       5      �� *HelpViewCommand+5      	 � DataContext	 5!      -  'AssetsView.MVVM.ViewModel.MainViewModel  5"   
   .��5%      � 
 � RowDefinitions
 5&   
   �� 5'      $��30 �6   �� 5(      $��* �6    � ColumnDefinitions 5*   
   �� 5+      $
��Auto �6   �� 5,      $��* �6   .+�50   
   �� -   5         ��Name$ TitleBar��51      $��1��52      $��30��53      $��Center=�54       K� ZIndex$ 1��55      
���   �57      �� 59   
   -   5         ��Name$ VerticalPanel��5:      $��2��5;      $��0��5<      $	��100��5=      $��Stretch=�5>      ���#0E0E0E.+�5@      � 
 5A      �� 5B      $��97 �6$   �� 5C      $	��373 �6$   �� 5D      $��* �6$   $	��461��6/   �� 5E      $
��Auto �6$   .+�5G      �� -   5         ��Name$ 	LogoImage��5H      $��0��5I      $��55��5J      $��45��5K      $��
22,52,23,0q�5L      $��/Data/Icons/logo.png��5M      	� 5P      -   5         	�Name$ DashboardButton��5Q      $��1��5R      $��93��5S      $��
0,93,0,186q�5T      ���#0E0E0E
������  � Cursor$
 Hand��5X         RadioButtonHoverStyle#���   5Z      ��5W      �� *DashboardViewCommand+ d� 	IsChecked 5Y      �� *IsDashboardSelected+ �� Mode$ TwoWay=�.��5[      � .+�5\      �� $��25��5]      $��25��5^      $��/Data/Icons/dashboard.png��5_      �� 5`      -   5         ��Name$ DashboardRectangle��5a      ${�False��5b        OpacityStyle#���  5c      5d       � ToolTip 5e      _� 5f        ButtonToolTipStyle#��[ 6Z    _� PlacementTarget 6"   ��  �� ElementName$ DashboardButton��.��5g      �� -   5         ��Name$% DashboardRadioButtonToolTipText��5h   !   $��13,8,0,0q�5i   !   $��13(�5j   !   $��Regular"�5k   !     TextBlockGrayStyle#��[ 5l   !   $��	Dashboard��5m   !   5n      5p      	� 5s      -   5        $ SettingButton��5t      $��1��5u      $��93��5v      $��
0,186,0,93q�5w      ���#0E0E0E
������ $
 Hand��5{      #���   5}      ��5z      �� *SettingsViewCommand+ 5|      �� *IsSettingsSelected+$ TwoWay=�.��5~      � .+�5      �� $��25��5�      $��25��5�      $��/Data/Icons/settings.png��5�      �� 5�      -	   5        $ SettingRectangle��5�      $��22��5�      $��21��5�      ${�False��5�      #���  5�      5�       5�      _� 5�      #��[ 6Z    6"   �� $ DashboardButton��.��5�      �� -
   5        $$ SettingsRadioButtonToolTipText��5�   !   $��19,8,0,0q�5�   !   $��13(�5�   !   $��Regular"�5�   !   #��[ 5�   !   $��Settings��5�   !   5�      5�      	� 5�      -   5        $ 
HelpButton��5�      $��1��5�      $��93��5�      $��	0,280,0,0q�5�      ���#0E0E0E
������ $
 Hand��5�      #���   5�      ��5�      �� *HelpViewCommand+ 5�      �� *IsHelpSelected+$ TwoWay=�.��5�      � .+�5�      �� $��25��5�      $��25��5�      $��/Data/Icons/help.png��5�      �� 5�      -   5        $ HelpRectangle��5�      ${�False��5�      #���  5�      5�       5�      _� 5�      #��[ 6Z    6"   �� $ DashboardButton��.��5�      �� -   5        $  HelpRadioButtonToolTipText��5�   !   $��28,8,0,0q�5�   !   $��13(�5�   !   $��Regular"�5�   !   #��[ 5�   !   $
��Help��5�   !   5�      5�      �� 5�      -   5         ��Name$ 
ExitButton��5�      $��3��5�      $	��100��5�      $��93��5�      $��Bottom=�5�      ���#0E0E0E
������ $
 Hand��5�        ButtonHoverStyle#���  5�      .��5�      � .+�5�      �� $��25��5�      $��25��5�      $��/Data/Icons/logout.png��5�      5�       5�      _� 5�      #��[ 6Z    6"   �� $ DashboardButton��.��5�      �� $��31,8,0,0q�5�   !   $��13(�5�   !   $��Regular"�5�   !   #��[ 5�   !   $
��Exit��5�   !   5�      5�      5�      5�      �� 5�   
   $��1��5�      $��2��5�      $��1��5�      ��5�      �� *CurrentView+5�      5�      