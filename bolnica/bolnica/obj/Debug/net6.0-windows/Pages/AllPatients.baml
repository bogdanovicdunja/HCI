   M S B A M L   `   `   `  ����B  >bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:bolnica.Pagesbolnica.Pages  5          bolnica.Pages.AllPatients   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:bolnica.Pages     5        N� Title$  AllPatients��5	       N� 
Background 5
      �� 5   
    �� ImageSource$ /images/homePage.jpeg��6    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundenButtonStyle	 �� 
TargetType
 �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5    
   $ 	#FF838383��6=   �� 5!   
   "	 ��6+   .�5"      ��  �@�FocusVisualStyle8   61   �� 5#       � ��8  6+   �� 5$       � ��8  6,   �� 5%       � ��# � ��6+   �� 5&       � ��$ 0q�60   �� 5'       � ��$ Center=�6;   �� 5(       � ��$ Center=�69   �� 5)       � ��$ 1q�6(   �� 5*       � �� 5+      �� 5,      "
 ��6&   .R�5-      �� $ border��6!   $ 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5.      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5/       50      P� 51       �@��IsDefaulted$
 true��6=   . �52   "   �� $ border��6@   # � ��6T    � ��53      P� 54       �@J�IsMouseOver$
 true��6=   . �55   "   �� $ border��6?    � �� �	#FF0F6FF46S   �� 56   "   $ border��6@    � �� �	#FF0F6FF46T   57      P� 58       � ��$
 true��6;   . �59   "   �� $ border��6?    � �� �	#FF5EB9DF6T   �� 5:   "   $ border��6@    � �� �	#FF5EB9DF6U   5;      P� 5<       � {�$ false��6;   . �5=   "   �� $ border��6?   8   � ��6S   �� 5>   "   $ border��6@   8   � ��6T   �� 5?   "   $ contentPresenter��6K   8   � ��6i   5@      5B      5D      5E      5F      .��5H      � .+�5I   
   �� $��Patient List��6   $��Center=�6'   $��0,46,0,0q�6D   $	��Top=�6V   $	��400��6n   $��Center=�6z   $��24(�6�   $��Medium"�6�   $��Center=�6�   $��Italic$�6�   $��50��6�   5M      �� 5O   
   -   5         ��Name$	 GRD��5O      $��34,101,34,34q�6D   ��6    �� *PatientList+��5Q      �� 5R      $ /images/bluredHall.jpeg��6   ��5U      �� 5V      .R�5W      � $	��670��6   $	��110��6+    � ColumnDefinitions 5Y      �� 5Z   "   $	��100 �63   �� 5[   "   $	��120 �63   �� 5\   "   $	��150 �63   �� 5^   "   $	��100 �63   �� 5_   "   $	��100 �63   �� 5`   "   $	��100 �63   .+�5i      � ��5j   "   �� 5k   &   $ /images/patient.png��61   5m      �� 5o      
����  �$��1��68    �� Padding$
 2, 0q�6I   $��
2, 0, 0, 0q�6X   ._�5p   "   �� $��
5, 5, 5, 5q�6-   .+�5r   &   �� $��Name: ��60   $
��Bold"�6>   �� 5s   &   $��	Surname: ��60   $
��Bold"�6A   �� 5t   &   $��Date Of Birth: ��60   $
��Bold"�6G   �� 5u   &   $��Adress: ��60   $
��Bold"�6@   �� 5v   &   $��Email: ��60   $
��Bold"�6?   �� 5w   &   $��
Username: ��60   $
��Bold"�6B   5x   #   5y      �� 5|      $��2��6!   $
 2, 0q�62   $��
2, 0, 0, 0q�6A   ._�5}      �� $��
5, 5, 5, 5q�6)   .+�5   "   �� ��6,   �� *Name+�� 5�   "   ��6,   �� *	Surname+�� 5�   "   ��6,   �� *DateOfBirth+�� 5�   "   ��6,   �� *Adress+�� 5�   "   ��6,   �� *Email+�� 5�   "   ��6,   �� *
Username+5�      5�      �� 5�      $��5��6!   ._�5�      �� -   5        #��� 
 5�   %   $��96��6R   $��30��6]   $��Show Allergens��6i   $
��Bold"�6�   $��Right=�6�   $��Center=�6�    J� Effect 5�   "   3  -System.Windows.Media.Effects.DropShadowEffect  5�   &   5�      5�      5�      5�      5�       � 5�   
   -   5          �Name$ PatientFile��5�      $��
0, 0, 0, 0q�6&   5�      5�      