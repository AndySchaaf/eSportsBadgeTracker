   M S B A M L   `   `   `  ���� m  iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting  N JeSportsBadgeTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:eSportsBadgeTrackereSportsBadgeTracker $   eSportsBadgeTracker.Statistics   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     �winformchartmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     3local!clr-namespace:eSportsBadgeTracker       N� Title$  
Statistics��$��268.398��.��� $��0,41,0,0q�.+��� .+��� -    ��Name$ label7_Copy��$��Check In Statistics��$��Center=�$	��Top=�$��5,0,0,0q�$��13.333(�7  1System.Windows.Forms.Integration.WindowsFormsHost  -     Name$
 host��$	��Top=�$��90��$
��20,5q�   Child. ;   5System.Windows.Forms.DataVisualization.Charting.Chart  -   CheckIn��[ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control   Dock$
 Fill=�   BorderlineColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$ 	SlateGray    Series <   6System.Windows.Forms.DataVisualization.Charting.Series     Name$ CheckinTime��   	ChartType$
 Line=�	   
XValueType$
	 Time=�
   	ChartAreaM   GSystem.Windows.Forms.DataVisualization.Charting.SeriesAreaNameConverter$
 Checkin    
ChartAreas ?   9System.Windows.Forms.DataVisualization.Charting.ChartArea     Name$ Checkin����  �� Orientation$ 
Horizontal=�$	��Top=�$��Center=�$��	37,0,21,0q�$	��461��.+��� -   $ 
Registered��$��Registered:��$
��Left=�$	��Top=�$	��5,5q�$��9(��� -   $ reg_val��$
��Left=�$	��Top=�$	��5,5q�$��9(����� *
Registered+�� -   $ 
checked_in��$��Checked-in:��$
��Left=�$	��Top=�$	��5,5q�$��9(��� -   $ checked_in_val��$
��Left=�$	��Top=�$	��5,5q�$��9(����� *	Checkedin+�� -   $
 VIPs��$��VIPs:��$
��Left=�$	��Top=�$	��5,5q�$��9(��� -	   $ VIPs_val��$
��Left=�$	��Top=�$	��5,5q�$��9(����� *Vip+�� -
   $ Regular_Guests��$��Regular Guests:��$
��Left=�$	��Top=�$	��5,5q�$��9(��� -   $ Regular_Guest_val��$
��Left=�$	��Top=�$	��5,5q�$��9(����� *	Regular+�� -   $ walk_ins��$��Walk-in Guests:��$
��Left=�$	��Top=�$	��5,5q�$��9(��� -   $ walk_in_val��$��Center=�$	��5,5q�$	��Top=�$��9(����� *Walkin+�� $ 
Horizontal=�$	��Top=�$��Center=�$��8.243,0q�.+��� -   $ males1��$��Males:��$��9(�$��5q��� -   $ 
males_val1��$��9(�$��5q�$
��Left=�$	��Top=����� *Male+�� -   $ Females1��$��Females:��$��9(�$��5q��� -   $ 
femal_val1��$��9(�$��5q�$
��Left=�$	��Top=����� *Female+�� -   $ Other1��$��Other:��$��9(�$��5q��� -   $ 
other_val1��$��9(�$��5q�$
��Left=�$	��Top=����� *Other+