   M S B A M L   `   `   `  ����B  >bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:bolnica.Pagesbolnica.Pages  5          bolnica.Pages.Guesst   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:bolnica.Pages     5        N� Title$  Guesst��5	       N� 
Background 5      �� 5   
    �� ImageSource$ /images/emergency.jpg��6    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundenButtonStyle	 �� 
TargetType
 �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5    
   $ 	#FFADB2B5��69   �� 5!   
   $ 	#FF838383��6=   �� 5"   
   "	 ��6+   .�5#      ��  �@�FocusVisualStyle8   61   �� 5$       � ��8  6+   �� 5%       � ��8  6,   �� 5&       � ��# � ��6+   �� 5'       � ��$ 0q�60   �� 5(       � ��$ Center=�6;   �� 5)       � ��$ Center=�69   �� 5*       � ��$ 1q�6(   �� 5+       � �� 5,      �� 5-      "
 ��6&   .R�5.      �� $ border��6!   $ 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5/      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  50       51      P� 52       �@��IsDefaulted$
 true��6=   . �53   "   �� $ border��6@   # � ��6T    � ��54      P� 55       �@J�IsMouseOver$
 true��6=   . �56   "   �� $ border��6?    � �� �	#FFF416166S   �� 57   "   $ border��6@    � �� �	#FFF416166T   58      P� 59       � ��$
 true��6;   . �5:   "   �� $ border��6?    � �� �	#FFAF24246S   �� 5;   "   $ border��6@    � �� �	#FFAF24246T   5<      P� 5=       � {�$ false��6;   . �5>   "   �� $ border��6?   8   � ��6S   �� 5?   "   $ border��6@   8   � ��6T   �� 5@   "   $ contentPresenter��6K   8   � ��6i   5A      5C      5E      5F      5G      .��5I      � 
������� J� Opacity$	 0.7Q�6#   $	��400��62   $	��400��6>   $��200,10,200,10q�6K    J� Effect 5J   
   3  -System.Windows.Media.Effects.DropShadowEffect  5K      .+�5M   
   �� $��Guesst Account��6   $	 1.0Q�6)   
�������$��Center=�6J   $��0,46,0,0q�6g   $	��Top=�6y   $	��400��6�   $��50��6�   $��Heavy"�6�   $��Italic$�6�   $��24(�6�   $��Center=�6�   ��5N      �� 5O       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5P      �  � Color$ Black��6#   � 5Q      $ 	#FFB80034��6#    � Offset$ 1Q�65   5R      5T      �� 5U   
   -   5         ��Name$
 User��5U       �� TextWrapping$
 Wrap=�6!   $	 1.0Q�65   $�� ��6C   $��Center=�6K   $��	0,110,0,0q�6h   $	��Top=�6{   $	��195��6�   $��25��6�   .��6�    5V        5W      .��5X      5Y      �� 5\   
   $��	Username:��6   $	 1.0Q�6$   
�������$
��Left=�6E   $��
30,110,0,0q�6`   $	��Top=�6t   $
��Bold"�6�    5]        5^      5`      �� 5b   
   -   5        #��� 
 5b      $	 1.0Q�6>   $��Create��6L   $��Center=�6]   $��	0,147,0,0q�6z   $	��Top=�6�   $��30��6�   $��96��6�   $
��Bold"�6�    5c        5d      5f       � 5h      -   5          �Name$ 	GuesstAcc��5h      $��
0, 0, 0, 0q�6'   5j      5k      