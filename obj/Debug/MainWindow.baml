   M S B A M L   `   `   `  ����O  KStoreWithDataSources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:StoreWithDataSourcesStoreWithDataSources  5   	   %    StoreWithDataSources.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:StoreWithDataSources     5   	   -   5          � Title$  LogIn��5   	   
�������$	��418��5
   	   $	��418��5   	   $	��418��5   	   $	��617��5   	   $	��617��5   	   $	��617��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��0,0,0.4,0.4q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ tbRegistrationForm��5      $��
LogIn form��5      $��28(�5      $
��Bold"�5      $��Center=�5       �� TextAlignment$ Center=�5      $��117,32,120.2,0q�5      $	��374��5      $��37��5       $	��Top=�5!      �� 5"   
   $��UserName��6   $��20(�5#      $
��Left=�5$      $��	50,98,0,0q�5%      $��72,0,0,0q�5&      $	��Top=�5'      $	��181��6(   �� 5(   
   -   5         ��Name$ 
tbUserName��5(      $��40��5)      $��20(�5*      $��5,2,47,0q�5+      $
��Left=�5,      $��254,95,-24.8,0q�5-      $	��Top=�5.      $	��274��5/      �� 50   
   $��Password��6   $��20(�51      $
��Left=�52      $��
50,172,0,0q�53      $��82,0,0,0q�54      $	��Top=�55      $	��181��56      �� 57   
   -   5        $ txtVisiblePassword��57      $��40��58      $��20(�59      $��5,2,47,0q�5:      $
��Left=�5;      $��254,160,0,0q�5<      $	��Top=�5=      $	��274��5>      .��6   5@      G� 5A   
   -   5         G�Name$ txtPassword��5A      $��40��5B      $��20(�5C      $��5,2,47,0q�5D      $��254,160,0,0q�5E      $	��Top=�5F      $
��Left=�5H      $	��274��5I      �� 5J   
   -   5         ��Name$ cbEyePassword��5J      $y�Hidden=�5K      $��25��5L      $��25��5M      $��
400,0,0,20q�5P      ��5Q      �� 5R       �� 
TargetType" ��6"   .R�5S      �� 	 �� Orientation$	 
Horizontal=�6!   .+�5T      �� 
 ��Name$
 	CheckMark��6    $-��'pack://application:,,,/Img/CloseEye.jpg��63   $��25��5U       $��25��5V       �� 5W      5X       �� Triggers 5Y      P� 5Z       P� Property �@d�	IsChecked P� Value$
 TrueY�67   . �5[      ��  �� 
TargetName$ 	CheckMark��6%    �� Property � �� �� Value$, &pack://application:,,,/Img/OpenEye.jpg��5\   %   5]      5_      5a      �� 5c   
   -   5         ��Name$ bLogIn��5c      $��LogIn��5d       � Cursor$
 Hand��5e      $��20(�5f      $
��Left=�5g      $��254,238,0,0q�5h      $	��Top=�5i      $��89��5j      $��30��5k      5l      �� 5m   
   -   5        $ bRegistration��5m      $��Registration��5n      $
 Hand��5o      $��20(�5p      $
��Left=�5q      $��373,238,0,0q�5r      $	��Top=�5s      $	��155��5t      $��30��5u      5v      5w      5x      