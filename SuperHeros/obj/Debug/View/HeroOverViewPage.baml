   M S B A M L   `   `   `  ����E  ASuperHeros, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperHeros.ViewSuperHeros.View  5      ;"clr-namespace:SuperHeros.ViewModelSuperHeros.ViewModel  5      &     SuperHeros.View.HeroOverViewPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SuperHeros.View     5      1vm"clr-namespace:SuperHeros.ViewModel     5        N� Title$  HeroOverViewPage��5
       N� 
Background
 ����� � DataContext 5      )  #SuperHeros.ViewModel.HeroOverViewVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��25 �6   �� 5      $��* �6   .+�5'   
   �� $��0��6   $��0��6   $��4��6-   $��3��6A   $&�� /Resources/Images/BackGround.jpg��5(      $��UniformToFill=�5)      �� 5+   
   $��0��6   $��0��6!   $��4��61   $��3��6E   
������� J� Opacity$	 0.2Q�5,      �� 5.   
   
���   �$	 0.7Q�6!   �� 5/   
   $��0��6   $��Super Heroes��6!   $��30(�65   $��Center=�6C   $��Center=�6`   
�������6{   � 51   
   $��1��6   $��25��6   $	��Top=�6(    � ColumnDefinitions 53      �� 54      $��* �6#   �� 55      $��* �6#   .+�58      �� 
���   �$	 0.7Q�6%   �� 5:      -   5         ��Name$ 
FilterList��5:       �� SelectedIndex$ 0��5<   .    �� SelectionMode$ Single=�5=   0   
������ ��5<   
   �� *FilterTypes+	 �� SelectedItem	 5=   
   �� *SelectedType+��5>      �� 5?      
 �� 
TargetType"
 ��6   .�5@      ��  �� Property � �� �� Value
 �����67   5A      ��5C      �� 5D      .R�5E      A�  A� Columns$ 5��6&   5G      5I      �� 5J      $��1��6   
���   �
�������$	 0.8Q�5L   T   $��1��6b   ��5K      �� *SwitchDataMode+��5L      �� *
DataText+6b   5O      � 5Q   
   $��2��6   .+�5V      �� -   5        $ HeroList��5V      $ 0��5W   (   $ Single=�5X   0   
������ ��5W   
   �� *Heros+	 5X   
   �� *SelectedHero+��5Y      �� 5Z      .R�5[      A� $ 4��6&    A� Rows$ 2��62   5\      ��5^      �� 5_      .R�5`      �  5a      �� 5b   "   $��* �60   �� 5c   "   $��30 �60   .+�5e      �� $��0��6$   $��2��62   $��Stretch=�6g   $��UniformToFill=�6�   $	��170��6�   ��6D   �� *ImageImage.url+6�   �� 5f      $��1��6(   $��0��65   $��4��6E   
���   �$	 0.7Q�5g   *   �� 5h      $��1��6(   
�������$��21(�6^   $��Center=�6l   ��65   �� *Name+6l   5j      5k      ��5m      �� 5n      "
 ��6   .�5o      ��  � ��$	 200��63   �� 5p       � ��$	 200��62   5q      5s      5t      5w      5y      