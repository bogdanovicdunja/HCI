   M S B A M L   `   `   `  ����B  >bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:bolnica.Pagesbolnica.Pages  5          bolnica.Pages.Equipment   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:bolnica.Pages     5        N� Title$  	Equipment��5	       � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundenButtonStyle �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6+   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��# � ��6+   �� 5#       � ��$ 0q�60   �� 5$       � ��$ Center=�6;   �� 5%       � ��$ Center=�69   �� 5&       � ��$ 1q�6(   �� 5'       � �� 5(      �� 5)      " ��6&   .R�5*      �� $	 border��6!   $
 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5+      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted$
 true��6=   . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 51       �@J�IsMouseOver$
 true��6=   . �52   "   �� $ border��6?    � �� �	#FFB0E0E66S   �� 53   "   $ border��6@    � �� �	#FFB0E0E66T   54      P� 55       � ��$
 true��6;   . �56   "   �� $ border��6?    � �� �	#FF87CEEB6T   �� 57   "   $ border��6@    � �� �	#FF87CEEB6U   58      P� 59       � {�$ false��6;   . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8   � ��6i   5=      5?      5A      5B      5C       N� 
Background 5E      �� 5F   
    �� ImageSource$ /images/drugs.jpg��6   .��5I      � .+�5J   
   �� $��Orders��6   
���   �$��Center=�64   $��0,46,0,0q�6Q   $	��Top=�6c   $	��400��6{   $��Center=�6�   $��24(�6�   $��Medium"�6�   $��Center=�6�   $��Italic$�6�   $��50��6  5L      �� 5O   
   -   5        #��� 
 5O      $��96��6>   $��30��6I   $��	New Order��6U   $
��Bold"�6i   $��10, 0, 77, 205q�6{   $��Right=�6�   $��Center=�6�    J� Effect 5P      3  -System.Windows.Media.Effects.DropShadowEffect  5Q      5S      �� 5U   
   -   5        #��� 
 5U      $��96��6>   $��30��6I   $��
Show Chart��6U   $
��Bold"�6j   $��0, 0, 630, 205q�6|   $��Right=�6�   $��Center=�6�    5V        5W      5Y      �� 5[   
   -   5         ��Name$	 GRD��5[      $��34,101,34,34q�6B   ��6    �� *	OrderList+��5]      �� 5^      $ /images/drugsBlur.jpg��6   ��5a      �� 5b      .R�5c      � $	��670��6   $��60��6'    � ColumnDefinitions 5e      �� 5f      $	��100 �6/   �� 5g      $	��120 �6/   �� 5h      $	��150 �6/   �� 5j      $	��100 �6/   �� 5k      $	��100 �6/   �� 5l      $	��100 �6/   .+�5p      � ��5q      �� 5r   "   $# /images/medical-equipment.png��6-   5t      �� 5v      
������$��1��6:    �� Padding$
 2, 0q�6K   $��
2, 0, 0, 0q�6Z   ._�5w      �� $��
5, 5, 5, 5q�6)   .+�5y   "   �� $��Name: ��6,   $
��Bold"�6:   �� 5z   "   $��
Quantity: ��6,   $
��Bold"�6>   5|      5}      �� 5�      $��2��6!   $
 2, 0q�62   $��
2, 0, 0, 0q�6A   ._�5�      �� $��
5, 5, 5, 5q�6)   .+�5�   "   �� ��6,   �� *Name+�� 5�   "   ��6,   �� *
Quantity+5�      5�      5�      5�      5�       � 5�   
   -   5          �Name$ EquipmentFile��5�      $��
0, 0, 0, 0q�6(   5�      5�      