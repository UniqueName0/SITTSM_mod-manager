   M S B A M L   `   `   `  ����M  ISITTSM_mod-manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SITTSM_mod_managerSITTSM_mod_manager  5   	   #    SITTSM_mod_manager.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SITTSM_mod_manager     5   	     � 
ResizeMode$  NoResize=�5   1    � Title$ SITTSM mod manager��5   	   $	��390��6$   $	��800��61   .��5	      � .+�5
   
   �� $	��784��6   $��50��6    $��30(�6,   $��DemiBold"�6:    �� TextAlignment$ Center=�6P   SITTSM mod manager6{   �� 5   
   -   5        $��exeText��5   8   $	��600��6   $��25��6   $��15(�6*   .��6G   select the game's exe6^   �� 5   
   -   5        $��browseExeBtn��5      $	��184��67   $��25��6C   .��6O   Browse6W   �� 5   
   $
��Auto=�6   $	��392��6:   $	��100��6F   z�5      �� 5       �� CenterX$ 0Q�6!    �� CenterY$ 0Q�6-    �� ScaleX$ 2Q�69    �� ScaleY$ 2Q�6D   .��5      �� -   5        $
��mods��5      5      5      ]� 5   
   $	��784��6   $��50��6    $��Center=�6,   $��	0 110 0 0q�6I   .+�5      �� -   5        $
��Left=�5      $
��Left=�6@   $	��100��6[   $��50��6g   $��10 0 0 0q�6s   $��activate mods��6�   �� 5      -   5        $��Right=�5      $��right=�6>   $	��100��6Z   $��50��6f   $��0 0 10 0q�6r   $��
start game��6�   �� 5      -   5         ��Name$ status��5   o   $��Right=�6   $��Center=�6/   $ Center=�6J   $��15(�6a   $	��550��6   5      5      5      