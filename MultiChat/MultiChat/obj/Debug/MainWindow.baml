   M S B A M L   `   `   `  ����D  @MultiChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MultiChat	MultiChat  5   	       MultiChat.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MultiChat     5   	   -   5          � Title$  MultiUser UDP Chat��5   	   $	��450��6$   $	��600��61   $	��350��5	   	   $	��500��6    � Icon$ Images/favico.ico��6(    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��2.5* �6   .+�5   
   �� $��Sending of Messages��6   $��0��60   $��0��6=   .��5      ]� .+�5      �� $��My NickName:��6   $	��Top=�6/   �� 5      -   5         ��Name$ NickNameField��5      $	��Top=�61   $��4q�6F   �� 5      $��My Message:��6   $	��Top=�6.   �� 5      -   5         ��Name$ ClearButton��5   %   $��Clear��5      $��Bottom=�6)   $��5q�5      5      �� 5      -   5        $ 
SendButton��5   3   $
��Send��5      $��Bottom=�6(   $
��0, 5q�5      $��5q�6'   5      �� 5!      -   5        $ MessageField��5!       �� TextWrapping$
 Wrap=�60    �� AcceptsReturn . 6D   5"      5$      �� 5&   
   $��Review of Messages��6   $��0��6/   $��1��6<   .��5'      � .+�5(      �� -   5        $ ChatBox��5(      $
 Wrap=�6+    .  �� 
IsReadOnly . 6T   5)      5*      5+      5,      