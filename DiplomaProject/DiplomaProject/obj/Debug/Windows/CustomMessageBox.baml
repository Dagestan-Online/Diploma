   M S B A M L   `   `   `  ����I  EDiplomaProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DiplomaProject.WindowsDiplomaProject.Windows  5   	   -    'DiplomaProject.Windows.CustomMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DiplomaProject.Windows     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ CustomMessageBox��5   	   $	��200��5   	   $	��350��6    � AllowsTransparency . 
������ .��5      �� ���	#FFEE9B43 �� CornerRadius$ 10��6$   ._�5   
   � 
������  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��1* �6    �� 5      $
��auto �6    .+�5      �� ���	#FFE0E0E0$��0��5      $��3��5      $ 10��5      $��5q�5      �� 5      ���	#FFC4C4C4$��1��5      $��5 3 5 3q�5      �� 5      -   5         ��Name$ tblTitle��5      $=��7заголовок для кастомного окна��5      $��0��5       $��0,0,0,0q�5!       �� Padding$ 15,6,0,0q�5#      �� 5$      	 �� Orientation$	 
Horizontal=�6   $��1��5%      $��3,5,3,10q�5&      .+�5'      �� -   5        
 ��Name$
 imgBox��5'      $��50��5(      $��50��5)      $��	20,0,10,0q�5*      $��\Images\NoImage.jpg��5+      �� 5,      $	��254��6   $	��118��5-      $
��Auto=�5.      .��5/      �� -   5        $ 
tblContent��5/       $��Center=�50      $5��/текст для кастомного окна��51      $
��Wrap=�52      53      54      �� 55      $	 
Horizontal=�6   $��Right=�56      $��Bottom=�57      $��2��58      $��	0,10,30,0q�59      .+�5:      �� -   5         ��Name$ btnNo��5:      $��80��5;      $��
Назад��5<      $��5,0,5,10q�5=      $��14(�5>         NegativeButton#��[  5?      5@      �� 5A      -   5        $ btnYes��5A      $��80��5B      $��OK��5C      $��5,0,5,10q�5D      $��14(�5E        PositiveButton#��[ 5F      5G      5H      5I      5J      5K      