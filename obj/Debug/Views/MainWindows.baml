   M S B A M L   `   `   `  ����P  LToolSetColorByFillter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ToolSetColorByFillter.ViewsToolSetColorByFillter.Views  5      -    'ToolSetColorByFillter.Views.MainWindows   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ToolSetColorByFillter.Views     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$  Bùi Thành Hiếu��5	      $	��585��5
      $	��690��6   $��	Agency FB)�5      $��14(�5      $
��Bold"�5      $��Italic$�5      ���	#FFE0DEDE.��5      ]� ��. .+�5   
   ]� $��Bottom=�6   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��66   .+�5      ��  � Cursor$
 Hand��6   $��5q�6+   $��25��66   $	��100��6B   $��Un Hide��6N   ��6`   �� *UnHideCommand+6�   �� 5      $
 Hand��6   $��5q�6+   $��25��66   $	��100��6B   $
��Hide��6N   ��6]   �� *HideElementCommand+6�   5      �� 5      $��Center=�6   $��1��69   .+�5      � -   5         �Name$ ProgressWindow��5   "    � IsIndeterminate .  $��20��5   "   5"      5#      �� 5$      $��Right=�6   $��2��69   $��Right=�6I   $ 
Horizontal=�6`   .+�5%      �� $
 Hand��6   $��5q�6+   $��25��66   $	��100��6B   $��Apply��6N   ��6^   �� *ApplyCommand+6�   �� 5&      $
 Hand��6   $��5q�6+   $��25��66   $	��100��6B   $��Canncel��6N   6c   5'      5(      5*      � 5+   
   $	��Top=�6    5,      �� 5-      �� 5.      .+�50      � $��0��6    � RowDefinitions 51      �� 52      �� 53      $��3* �6$   .+�55      � $��0��6   .+�56      �� -   5         ��Name$ 
lvCategory��56       
�������$��5,5,6,5q�6k   $��Normal"�6|   $��Normal$�6�   $��16(�6�   ��65   �� *
Categories+ � 	Resources 58      	 �� 
TargetType
 �� Property �� Value��%T   '��       �� 59      "	 ��6$   .�5:   "   �� 
 � ��$
 Left=�6O   5;      5<       �� View 5=      �� 5>      .P�5?   "   �� $��Catagory��6c    �� Width$	 180��6u    �� DisplayMemberBinding 61   �� *InfoObject.Name+6�   �� 5@   "   $��Count��6X   $ 40��6g    61   �� *Count+6v   5A      .  (System.Windows.Interactivity.Interaction   Triggers 5C      /  )System.Windows.Interactivity.EventTrigger  5D         	EventName$ SelectionChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5E   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 5F   %   �� *SelectionChangedCommand+5H      5J      5K      � 5M      $��1��6   .+�5N      �� -   5        $ lvParameters��5N       $��5,5,6,5q�6Y   $��Normal"�6j   $��Normal$�6~   $��16(�6�   ��66   �� *
Parameters+ 5O      ��%T   '��       �� 5P      "	 ��6$   .�5Q   "   �� 
 � ��$
 Left=�6O   5R      5S       5T      �� 5U      .P�5V   "   �� $��
Parameters��6b   $
 3000��6v    61   �� *Definition.Name+6�   5X       5Z        5[      $ SelectionChanged��6-   . 5\   "      5]   %   �� *" SelectionChangedParameterCommand+5_      5a      5c      5d      � 5f      $��1��6   .+�5g      �� -   5        $ 
lvElements��5g      $��0��6U   $��5,5,6,5q�6b   $��Normal"�6s   $��Normal$�6�   $��16(�6�   ��6/   �� *GruopsElement+ 5h      ��%T   '��       �� 5i      "	 ��6    .�5j      �� 
 � ��$
 Left=�6K   5k      5l       5m      �� 5n      .P�5o      �� -   5        
valueColum��$��Value��5o   B   $	 180��6Q    �� CellTemplate 5p   "   �� 5q   &   .R�5r   *   �� $��Center=�66   $
 Hand��6�    �� Padding$ 10,0,0,0q�6�   ��6S   ��  �� Path$ Width� �� ElementName$ 
valueColum�� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *
Background+��6�   �� *ValueParameter+6�   5s   '   5u      �� 5w      -   5        
countColum��$��Count��5w   B   $ 40��6Q    5x   "   �� 5y   &   .R�5z   *   �� $��Center=�65   $ 10,0,0,0q�6�   ��6R   �� $ Width�$ 
countColum��$ PropertyChanged=���6�   �� *Count+6�   5{   '   5}      5�       5�        5�      $ SelectionChanged��6)   . 5�         5�   %   �� *SelectionListElementsCommand+5�      5�      5�      5�      5�      5�      