   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_ProjectWPF_Project  5          WPF_Project.AddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPF_Project     5        N� ShowsNavigationUI  .   N� Title$ AddEditPage��5	      .��5
      � 
������� � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� ���#371f60$��14(�6+   $
��Bold"�6;   $��Name Of Country��6O   $��Center=�6i   $��Center=�6�   �� 5   
   -   5         ��Name$ ComboCountry��5      $��1��6)    �� DisplayMemberPath$ nameOfCountry��6;   �� 5   
   ���#371f60$��14(�6+   $
��Bold"�6;   $��Name Of City��6O   $��Center=�6f   $��Center=�6�   $��1��6�   �� 5    
   -   5        $ 	ComboCity��5       $��1��6&   $��1��68   $ 
nameOfCity��6E   �� 5"   
   -   5         ��Name$ textBoxNameOfHotel��5"       �� 	MaxLength$	 100��6O   $��30��6a   $��2��6o   $��1��6~   ��60   �� *nameOfHotel+6~   �� 5#   
   ���#371f60$��14(�6+   $
��Bold"�6;   $��Name Of Hotel��6O   $��Center=�6g   $��Center=�6�   $��2��6�   �� 5%   
   -   5        $ textBoxCountOfStars��5%      $	 100��6O   $��30��6a   $��3��6o   $��1��6~   ��6/   �� *countOfStars+6~   �� 5&   
   ���#371f60$��14(�6+   $
��Bold"�6;   $��Count Of Stars��6O   $��Center=�6h   $��Center=�6�   $��3��6�   �� 5(   
   -   5        $ textBoxAddressOfHotel��5(      $	 100��6N   $��30��6`   $��4��6n   $��1��6}   ��63   �� *	address+6}   �� 5)   
   ���#371f60$��14(�6+   $
��Bold"�6;   $��Address Of Hotel��6O   $��Center=�6j   $��Center=�6�   $��4��6�   �� 5+   
   -   5        $ textBoxPhoneNumber��5+      $	 100��6O   $��30��6a   $��5��6o   $��1��6~   ��60   �� *phoneNumber+6~   �� 5,   
   ���#371f60$��14(�6+   $
��Bold"�6;   $��Phone Of Hotel��6O   $��Center=�6h   $��Center=�6�   $��5��6�   �� 5.   
   -   5        $ textBoxHotelDescription��5.      $	 100��6W   $��30��6g   $��6��6s   $��1��6�   ��65   �� *hotelDescription+6�   �� 5/   
   ���#371f60$��14(�6+   $
��Bold"�6;   $��Hotel Description��6O   $��Center=�6i   $��Center=�6�   $��6��6�   �� 51   
   -   5        $��BtnSave��51   A   $
��Save��6   $��2��6    $��7��64   $��15(�6f    �� 	IsDefault . ���#371f60
�������$
��Bold"�52   T   $��30��6h   $	��150��6t   $��Right=�6�   ��6&   Z� 6�   �� 54   
   -	   5        $
��Back��54      $��2��6    $��7��64   $��15(�6W   	 �� IsCancel	 . ���#371f60
�������$
��Bold"�55   T   $��30��6h   $	��150��6t   $
��Left=�6�   ��6&   Z� 6�   56      57      