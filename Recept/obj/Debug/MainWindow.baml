   M S B A M L   `   `   `  ����A  =Recept, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ReceptRecept  5   	       Recept.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Recept     5   	   -   5          �Name$  Recept��5   	    � Title$ Recept��5   	    � 
ResizeMode$ CanMinimize=�6    � WindowStartupLocation$ CenterScreen=�61   $��312.241��6V   $	��500��6f   .��5	      � $��0,0,-6,0q�6   .+�5
   
   �� -   5         ��Name$ 	RecipeBox��5
      $��29,51,29,105q�6&    �� View 5   
   �� 5      .P�5      ��  �� Width$	 122��6%    �� DisplayMemberBinding 61   ��  �� Path$ Title�.��5      �� -   5        	 ��Name$	 titleColumn��5   /   

 � Tag$
 Title��6D   $	��122��6s   .��6   Title6�   5      �� 5      $	 122��6%    61   �� $ Author�.��5      �� -   5        $	 authorColumn��5   /   $
 Author��6E   $	��122��6w   .��6�   Author6�   5      5      5      �� 5   
   $��Recipe:��6   $
��Left=�6"   $��	29,25,0,0q�6=   $	��Top=�6P   $��26��6h   $��57��6t   �� 5   
   -   5        $��Add new recipe��5      $
��Left=�6*   $��
29,371,0,0q�6E   $	��Top=�6Y   $	��121��6q   $��32��6}   6�   �� 5   
   -   5        $��Show recipe��5      $
��Left=�6'   $��164,371,0,0q�6B   $	��Top=�6W   $	��119��6o   $��32��6{   6�   5      5      