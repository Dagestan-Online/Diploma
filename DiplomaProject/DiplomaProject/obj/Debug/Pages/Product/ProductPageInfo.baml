   M S B A M L   `   `   `  ����I  EDiplomaProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DiplomaProject.Pages.ProductDiplomaProject.Pages.Product  5      2    ,DiplomaProject.Pages.Product.ProductPageInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:DiplomaProject.Pages.Product     5      -   5          N� Title$  ProductPageInfo��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��auto �6   .+�5   
   �� ���	#FFC4C4C4$��0��5      $��0,0,0,10q�5      ._�5      (�  (� Stretch$ Uniform=�6   .��5      �� -   5         ��Name$ tblTitle��5      $8��2Создание нового сотрудника��5      $��0��5      $	��600��5      $��20��6(   $��Center=�5      $��Center=�5       �� TextAlignment$ Center=�5      5      5      �� 5   
   ���	#FFC4C4C4$��1��5       $��0,0,0,10q�5!      ._�5"      (� .��5#      � $	��780��6   $	��380��6#    � ColumnDefinitions 5$      �� 5%      �� 5&      .+�5(      A�  A� Columns$ 2��6"   $��0��5)      .+�5*      �� $��Наименование:��6$   $��Center=�5+      $��Right=�5,      �� 5-      -   5         ��Name$ tbName��5-   "   $��Center=�5.      $
��Left=�5/       �� 	MaxLength$ 50��50   "   $	��120��52      $��10,0,0,0q�53      ��51      �� *name+53      �� 55      $��Количество:��6$   $��Center=�56       $��Right=�57       �� 58      -   5        $ tbCount��58   "   $��Center=�59      $
��Left=�5:      $ 7��5;   "   $	��120��5=      $��10,0,0,0q�5>      ��5<      �� *count+5?      �� 5A      $��Материал:��6$   $��Center=�5B       $��Right=�5C       �� 5D      -   5        	 ��Name$	 cmbMaterial��5D   #      CustomComboBoxTemplate#���   5E      $��Center=�5F      $
��Left=�5G      
 �� DisplayMemberPath$

 name��5I      $	��120��5J      $��10,0,0,0q�5K       �� SelectedItem 5H      �� *
Material+5K      �� 5M      $��Тип изделия:��6$   $��Center=�5N       $��Right=�5O       �� 5P      -   5        $	 cmbProductType��5P   #   #���   5Q      $��Center=�5R      $
��Left=�5S      $

 name��5U      $	��120��5V      $��10,0,0,0q�5W       5T      �� *ProductType+5W      5X      � 5Z      $��1��6    5[      �� 5\      �� 5]      .+�5_      ��  �� Orientation$ 
Horizontal=�6%   $��0��5`   !   .+�5a      �� $��Описание:��6(   $	��Top=�5b   $   $��Right=�5c   $   $��0,40,0,0q�5d   $   �� 5e      -   5        $ tbDescription��5e   &   $	��Top=�5f   "   $
��Left=�5g   "   $	 200��5h   &    �� TextWrapping$
 Wrap=�5i   "   $
��Auto=�5j   "    �� MinLines$ 1��5k   "    �� MaxLines$ 10��5l   "   $	��290��5n   "   $��	10,40,0,0q�5o   "   ��5m   "   �� *description+5o   "   5p      �� 5r      $ 
Horizontal=�6%   $��1��5s   !   .+�5t      �� -   5         ��Name$	 img��5t   $   $	��160��5v       $	��160��5w       ��5u       �� *image+5w       �� 5x      -	   5        $��10,0,0,0q�5x   %   $��Center=�5y      $
��Left=�5z      $	��120��5{      $��Выбрать фото��5|        NeutralButton#��[ 5}      5~      5      5�      5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $��2��5�      $��Center=�5�      $��Center=�5�      .+�5�      �� -
   5        $��2q�5�      $��Отменить��5�      $	��100��5�        NegativeButton#��[ 5�      5�      �� 5�      -   5         ��Name$ BtnEmplayeeAdd��5�      $��60,2,2,2q�5�      $��Сохранить��5�      $	��100��5�        PositiveButton#��[ 5�      5�      5�      5�      5�      