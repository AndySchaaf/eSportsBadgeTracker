   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.104, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    eSportsBadgeTracker$   eSportsBadgeTracker.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          � Title$  eSports Badge Tracker��5   	   $��694.876��6'   $��925.025��68   $
��Left=�6H   ���	#FF404040
���   �.��5      � ���	#FF3F3F46.+�5   
   �� -   5         ��Name$ 
tabControl��5      $��10,10,10,71q�6)   .@�5      �� -   5         ��Name$ 	assignTab��5      $��Check In��6)   $��0q�6;   $
��17,2q�6F   .��5	      � ���	#FFE6E6E6.+�5
      (� .��5       � -   5          �Name$ frame2��5       $��Frame��60     � Source$4 ./eSportsBadgeTracker;component/SearchUser.xaml?�6@   $	��350��6x   $	��520��6�   5      5      5      �� 5      -   5        $ registerTab��5      $��Registration��6+   $��0q�6A   $
��17,2q�6L   .��5      � ���	#FFE6E6E6.+�5      (� .��5       � -   5        $ frame1��5       $��Frame��60   $: 4/eSportsBadgeTracker;component/RegistrationPage.xaml?�6@   $	��250��6~   $	��350��6�   5      5      5      �� 5      -   5        $ statsTab��5      $��
Statistics��6(   $��0q�6<   $
��17,2q�6G   .��5       � ���	#FFE6E6E6 � ColumnDefinitions 5!      �� 5"      $
��265* �6+   �� 5#      $
��622* �6+   .+�5%      (� $��2��6   .��5&       � -   5        $ frame4��5&       $��Frame��60   $4 ./eSportsBadgeTracker;component/Statistics.xaml?�6@   $	��350��6x   $	��520��6�   5'      5(      5)      �� 5*      -	   5        $ 	raffleTab��5*      $��Raffle��6)   $��0q�69   $
��17,2q�6D   .��5+      � ���	#FFE6E6E6 5,      �� 5-      $
��265* �6+   �� 5.      $
��622* �6+   .+�50      (� $��2��6   .��51       � -
   5        $ frame5��51       $��Frame��60   $4 ./eSportsBadgeTracker;component/RafflePage.xaml?�6@   $	��350��6x   $	��520��6�   52      53      54      5B      (� 5C   
   $	��665��6   $��Bottom=�6   .��5D      � $��15,599,17,10q�6   $	��890��6)   .+�5E      �� -   5         ��Name$ btnExit��5E   L      AccentedSquareButtonStyle#��[  6   $��Logout��6]   ���	#FFDC4545$��24(�6�   $
��Left=�6�   $	��210��6�   �� 5F      $��Themes/esportsLogo.png��6   $��Right=�68   $��56��6T   $��56��6_   $��Bottom=�6k   5G      5H      5I      5J      