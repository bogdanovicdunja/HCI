   M S B A M L   `   `   `  ����B  >bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:bolnica.Pagesbolnica.Pages  5      !    bolnica.Pages.UpdateMeeting   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:bolnica.Pages     5        N� Title$  UpdateMeeting��5	       N� 
Background 5      �� 5   
    �� ImageSource$  /images/conferenceBlur.jpg��6    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
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
 true��6=   . �56   "   �� $ border��6?    � �� �	#FF95725F6S   �� 57   "   $ border��6@    � �� �	#FF95725F6T   58      P� 59       � ��$
 true��6;   . �5:   "   �� $ border��6?    � �� �	#FFD6AD976T   �� 5;   "   $ border��6@    � �� �	#FFD6AD976U   5<      P� 5=       � {�$ false��6;   . �5>   "   �� $ border��6?   8   � ��6S   �� 5?   "   $ border��6@   8   � ��6T   �� 5@   "   $ contentPresenter��6K   8   � ��6i   5A      5C      5E      5F      5G      .��5I      � 
������� J� Opacity$	 0.8Q�6   $	��400��6-   $	��400��6:   $��200,10,200,10q�6G   .+�5J   
   �� $��Update Meeting��6   $��Center=�6)   $��0,46,0,0q�6F   $	��Top=�6X   $	��400��6p   $��Center=�6|   $��24(�6�   $��Medium"�6�   $��Center=�6�   $��Italic$�6�   $��50��6�    J� Effect 5K      3  -System.Windows.Media.Effects.DropShadowEffect  5L      5N      �� 5P   
   $��Date:��6   $
��Left=�6    $��
30,107,0,0q�6;   $	��Top=�6O   $
��Bold"�6g    5Q        5R      5T      �� 5U   
   $��Time:��6   $
��Left=�6    $��
30,144,0,0q�6;   $	��Top=�6O   $
��Bold"�6g    5V        5W      5Y      �� 5Z   
   $��Room:��6   $
��Left=�6    $��
30,181,0,0q�6;   $	��Top=�6O   $
��Bold"�6g    5[        5\      5^      �� 5_   
   $��Topic:��6   $
��Left=�6!   $��
30,218,0,0q�6<   $	��Top=�6P   $
��Bold"�6h    5`        5a      5c      (  "System.Windows.Controls.DatePicker  5e   
   -   5          Name$	 DP1��5e      $��Center=�6P   $��	0,108,0,0q�6m   $	��Top=�6�   $��25��6�   $	��196��6�    5f        5g      5i      �� 5j   
   -   5         ��Name$ cboTP��5j      $��Center=�6L   $��	0,145,0,0q�6i   $	��Top=�6|   $��25��6�   $	��196��6�   .@�5k      �� $��08:00��6   �� 5l      $��08:30��6   �� 5m      $��09:00��6   �� 5n      $��09:30��6   �� 5o      $��10:00��6   �� 5p      $��10:30��6   �� 5q      $��11:00��6   �� 5r      $��11:30��6    5s        5t      5v      �� 5w   
   -   5        $ Rooms��5w      $��Center=�6A   $��	0,182,0,0q�6^   $	��Top=�6q   $��25��6�   $	��196��6�    �� Text 6"   ��  �� Path$ roomname���5x      �� 5y      .R�5z      �� ��6    �� *Name+5{       5}        5~      5�      �� 5�   
   -   5         ��Name$ Topics��5�      $��Center=�6"   $��	0,219,0,0q�6?    �� TextWrapping$
 Wrap=�6R   $	��Top=�6�   $��25��6�   $	��196��6�   ��6f   �� $ topic�.��6�    5�        5�      .��5�      5�      �� 5�   
   -   5        #��� 
 5�      $��Update��6>   $��Center=�6O   $��	0,256,0,0q�6l   $	��Top=�6   $��30��6�   $��96��6�   $
��Bold"�6�    5�        5�      5�      �� 5�   
   -   5        #��� 
 5�      $	 1.0Q�6>   $��	PDFReport��6L   $��Center=�6`   $��	0,300,0,0q�6}   $	��Top=�6�   $��30��6�   $��96��6�   $
��Bold"�6�    5�        5�      5�       � 5�   
   -   5          �Name$ NewMeet��5�      $��
0, 0, 0, 0q�6!   67   5�      5�      