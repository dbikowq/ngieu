   M S B A M L   `   `   `  ����@  <ngieu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ngieungieu  5   	       ngieu.login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:ngieu     5   	     � Title$  ngieu��5   	   $	��154��6   $	��251��6$    � 
ResizeMode$ NoResize=�60    � WindowStyle$
 None=�6F    � WindowStartupLocation$ CenterScreen=�6Y    � 	Resources 5	         font �� 
TargetType �� Property �� Value��%z   &	        �� 5
   
   " ��6   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ Italic$�6*   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��72 �6   �� 5      $��40 �6   .+�5   
   � -   5        $��upper��5      $��0��6   ���	#FFBDB4B4	 J� Opacity$		 0.7Q�6@   6N   �� 5   
   
 �� Orientation$
 
Horizontal=�6   $��Right=�6.   $��0��6J   .+�5      �� -   5        $��8(�5      $��13��6"   $	��–��6-   $��13��69   $��Center=�6E   $��Center=�6`   $��1q�6}   $��Black"�6�   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6�      TextHintingMode$ Fixed=�6�   $��Center=�6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 2Q�6!   5      �� 5      -   5        $��6(�5      $��13��6"   $��X��6-   $��13��69   $��Center=�6E   $��Center=�6`   $��6q�6}   $��Black"�6�   $��Center=�6�    5         5!      $ 2Q�6!   5#      5$      �� 5'   
   $��1��6   $��Авторизация��6!   $��Center=�64   $��Center=�6Q   $��15(�6l   $��Italic$�6z   �� 5)   
   $
 Vertical=�6   $��2��6,   .+�5*      �� $
 
Horizontal=�6   .+�5+      �� #���   6   $��
Логин��6;   $��10q�6H   �� 5,      -   5         ��Name$ tbLogin��5,      $	��150��6+   $��25��67   $��10,0,0,0q�6C   $��itiss_2019_19izs_02��6U   5-      �� 5.      $
 
Horizontal=�6   $��0,-7,0,0q�62   .+�5/      �� #���   6   $��Пароль��6;   $��10q�6I   �� 50      -   5        $ tbPass��50      $	��150��6*   $��25��66   $��535E231r-2019��6B   51      53      �� 54   
   -   5        $��3��54      $��65��6   $��23��6)   $��
Войти��65   $��15(�6E   $��Italic$�6S   $��Center=�6f   $	��Top=�6�   6�   57      58      