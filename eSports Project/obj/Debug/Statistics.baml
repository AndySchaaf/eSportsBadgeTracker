   M S B A M L   `   `   `  ����m  iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting  5      N JeSportsBadgeTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:eSportsBadgeTrackereSportsBadgeTracker 5      $   eSportsBadgeTracker.Statistics   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      �winformchartmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5      3local!clr-namespace:eSportsBadgeTracker     5        N� Title$  
Statistics��5	      $��268.398��6   .��5      � $��0,41,0,0q�6   .+�5   
   �� .+�5      �� -   5         ��Name$ label7_Copy��5      $��Check In Statistics��6)   $��Center=�6G   $	��Top=�6d   $��5,0,0,0q�6|   $��13.333(�6�   7  1System.Windows.Forms.Integration.WindowsFormsHost  5      -   5          Name$
 host��5      $	��Top=�6-   $��90��6E   $
��20,5q�6Q      Child. 5      ;   5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        CheckIn��[ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control   Dock$
 Fill=�5   6      BorderlineColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$ 	SlateGray 6B      Series 5      <   6System.Windows.Forms.DataVisualization.Charting.Series  5         Name$ CheckinTime��6.      	ChartType$
 Line=�6A   	   
XValueType$
	 Time=�6R   
   	ChartAreaM   GSystem.Windows.Forms.DataVisualization.Charting.SeriesAreaNameConverter$
 Checkin 6d      
ChartAreas 5      ?   9System.Windows.Forms.DataVisualization.Charting.ChartArea  5         Name$ Checkin��61   5      5      �� 5       �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��Center=�6J   $��	37,0,21,0q�6g   $	��461��6z   .+�5      �� -   5        $ 
Registered��5      $��Registered:��6,   $
��Left=�6B   $	��Top=�6]   $	��5,5q�6u   $��9(�6�   �� 5      -   5        $ reg_val��5      $
��Left=�6H   $	��Top=�6c   $	��5,5q�6{   $��9(�6�   ��6)   �� *
Registered+6�   �� 5      -   5        $ 
checked_in��5      $��Checked-in:��6,   $
��Left=�6B   $	��Top=�6]   $	��5,5q�6u   $��9(�6�   �� 5      -   5        $ checked_in_val��5      $
��Left=�6N   $	��Top=�6i   $	��5,5q�6�   $��9(�6�   ��60   �� *	Checkedin+6�   �� 5      -   5        $
 VIPs��5      $��VIPs:��6&   $
��Left=�66   $	��Top=�6Q   $	��5,5q�6i   $��9(�6v   �� 5      -	   5        $ VIPs_val��5      $
��Left=�6B   $	��Top=�6]   $	��5,5q�6u   $��9(�6�   ��6*   �� *Vip+6�   �� 5       -
   5        $ Regular_Guests��5       $��Regular Guests:��60   $
��Left=�6J   $	��Top=�6e   $	��5,5q�6}   $��9(�6�   �� 5!      -   5        $ Regular_Guest_val��5!      $
��Left=�6O   $	��Top=�6j   $	��5,5q�6�   $��9(�6�   ��63   �� *	Regular+6�   �� 5"      -   5        $ walk_ins��5"      $��Walk-in Guests:��6*   $
��Left=�6D   $	��Top=�6_   $	��5,5q�6w   $��9(�6�   �� 5#      -   5        $ walk_in_val��5#      $��Center=�6H   $	��5,5q�6e   $	��Top=�6r   $��9(�6�   ��6-   �� *Walkin+6�   5$      �� 5%      $ 
Horizontal=�6   $	��Top=�62   $��Center=�6J   $��8.243,0q�6g   .+�5&      �� -   5        $ males1��5&      $��Males:��6(   $��9(�69   $��5q�6F   �� 5'      -   5        $ 
males_val1��5'      $��9(�6E   $��5q�6R   $
��Left=�6]   $	��Top=�6x   ��6,   �� *Male+6x   �� 5(      -   5        $ Females1��5(      $��Females:��6*   $��9(�6=   $��5q�6J   �� 5)      -   5        $ 
femal_val1��5)      $��9(�6G   $��5q�6T   $
��Left=�6_   $	��Top=�6z   ��6,   �� *Female+6z   �� 5*      -   5        $ Other1��5*      $��Other:��6(   $��9(�69   $��5q�6F   �� 5+      -   5        $ 
other_val1��5+      $��9(�6F   $��5q�6S   $
��Left=�6^   $	��Top=�6y   ��6,   �� *Other+6y   5,      5-      5.      5/      