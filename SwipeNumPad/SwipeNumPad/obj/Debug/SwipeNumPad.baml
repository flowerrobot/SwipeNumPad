   M S B A M L   `   `   `  ����F  BSwipeNumPad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SwipeNumPadSwipeNumPad  5   	       SwipeNumPad.SwipeNumPad   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SwipeNumPad     5   	   -   5          �Name$  NumPad��5   	    � Title$ SwipeNumPad��5	   	   $	��300��5   	   $	��270��6    � 
ResizeMode$ NoResize=�5   	   $��0q�5   	    � WindowStyle$
 None=�5   	    � Topmost .  � AllowsTransparency . ��5   	   Z�  � 	Resources 5       	  Grids �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property �� Value��%�   &	        �� 5   
   " �6    5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � �� �	#FF6A6A6A63   5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:CustomCommands.Exit��5      6a   .��5      � $	��300��6   $	��270��6    � ColumnDefinitions 5    
   �� 5!      $��75 �6   �� 5"      $��60 �6   �� 5#      $��60 �6   �� 5$      $��75 �6    � RowDefinitions 5&   
   �� 5'      $��75 �6   �� 5(      $��60 �6   �� 5)      $��60 �6   �� 5*      $��75 �6   .+�5-   
      SwipeNumPad.SwipeButton  $��0��6   $��0��6,      
TopVisible .    LeftVisible .    DisplayButton$ 1��6^      KeyAsString$ 1��6p      InverseIcon 6�   �� *MouseIsOutside+ �� ElementName$ NumPad��  5.   
   $��1��6   $��0��6,    . $ 2��6L   $ 2��6^    6n   �� *MouseIsOutside+$ NumPad��  5/   
   $��2��6   $��0��6,    . $ 3��6L   $ 3��6^    6n   �� *MouseIsOutside+$ NumPad��  50   
   $��3��6   $��0��6,    .    RightVisible . $ 4��6_   $ 4��6q    6�   �� *MouseIsOutside+$ NumPad��  52   
   $��0��6   $��1��6,    . $ 5��6L   $ 5��6^    6n   �� *MouseIsOutside+$ NumPad��  53   
   $��0��6   $��2��6,    . $ 7��6L   $ 6��6^    6n   �� *MouseIsOutside+$ NumPad��  55   
   $��3��6   $��1��6,    . $ 6��6M   $ 7��6_    6o   �� *MouseIsOutside+$ NumPad��  56   
   $��3��6   $��2��6,    . $ 8��6M   $ 8��6_    6o   �� *MouseIsOutside+$ NumPad��  58   
   $��0��6   $��4��6,      
BtmVisible .  . $ 9��6^   $ 9��6p    6�   �� *MouseIsOutside+$ NumPad��  59   
   $��1��6   $��4��6,    . $ 0��6L   $ 0��6^    6n   �� *MouseIsOutside+$ NumPad��  5:   
   $��2��6   $��4��6,    . $ .��6L   $ .��6^    6n   �� *MouseIsOutside+$ NumPad��  5;   
   $��3��6   $��4��6,    .  . $ Enter��6_   $ Enter��6u    6�   �� *MouseIsOutside+$ NumPad��5<      5=      