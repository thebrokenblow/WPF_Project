   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_ProjectWPF_Project  5          WPF_Project.TypeOfRooms   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPF_Project     5        N� ShowsNavigationUI  .   N� Title$ TypeOfRooms��5	      .��5
      � ���#371f60 � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� -   5        $��LViewTypeOfRooms��5   "   $��0��6   $��Disabled=�6<   $��Center=�6t   ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6    $��Center=�6;   5      ��5      �� 5      .R�5      � $
��1280��6    5      �� 5      $	��70* �6,   �� 5      $	��80* �6,    � ColumnDefinitions 5      �� 5      $	��10* �6/   �� 5      $	��20* �6/   .+�5!      �� $	��320��6    $
��auto��6.   $��UniformToFill=�6>   $
��Left=�6X   ��5"      �� 5#   "    �� Path$ ImagePreview�6*   5%      �� 5'      
�������$��20(�6U   $��40��6e   $	��720��6s   $��Center=�6�    �� TextAlignment$ Center=�5(   $   $��Center=�6=   $
��Wrap=�6\   $��0, 16, 0, 224q�6r   $��0��6�   $��1��6�   ��5'   $   �� *
roomName+5(   �   �� 5*      
�������$��20(�6s   $��40��6�   $	��720��6�   $��Center=�6�   $ Center=�5+   $   $��Center=�6=   $
��Wrap=�6\   $��0, 56, 0, 184q�6r   $��0��6�   $��1��6�   ��5*   $   �� *pricePerDay+ �� StringFormat$ {0:N2} $��5+   �   �� 5-      
�������$��20(�6\   $��40��6l   $	��720��6z   $��Center=�6�   $ Center=�5.   $   $��Center=�6=   $
��Wrap=�6\   $��0, 96, 0, 144q�6r   $��0��6�   $��1��6�   ��5-   $   �� *roomDescription+5.   �   �� 50      -   5        $��Enter��50   H   $	��120��6Z   $��30��6h   ���#371f60
�������$��15(�6�   $��1��6�   $��520, 250, 0, 0q�51   !   
 � Tag 50   !   �� ��6v   Z� 51   !   53      54      56      �� 57   
   -   5        $
��Back��57   #   $	��120��6N   $��30��6\   ���#371f60
�������$��15(�6�   $��20 0 0 0q�58   !   $��1��63   $
��Left=�6@    57      �� ��6j   Z� 58   @   59      5:      