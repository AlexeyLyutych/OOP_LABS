   M S B A M L   `   `   `  ����>  :Zoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZooZoo  5   	       Zoo.Employees   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Zoo     5   	     � Title$  	Employees��5   	   $	��350��6   $	��500��6(   
�����w� � 	Resources 5       �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow&   System.Windows.Controls.DataGrid��%~  '��       '  �     '  �    '  �    �� 5   
   " ��6   .�5      ��  � ��
 ��İ�6D   �� 5       � ��$ Comic Sans MS)�6+   6C   �� 5       � ��$ 2q�60   6<   �� 5       � ��
 �   �6<   5      �� 5   
   "  6   .�5      ��  � ��
 ��·�6B   �� 5       � ��$ 1q�60   6<   �� 5       � ��
 �   �6<   �� 5       � ��$ 23��6'   64   5      �� 5   
   "  6   .�5      ��  � ��
 ��İ�6D   5      �� 5   
   "  6   .�5      ��  � ��
 ���w�6D   �� 5       � ��$ century gothic)�6+   6D   5      5       .��5!      �  � RowDefinitions 5"   
   �� 5#      $��25 �6   �� 5$      �� 5%      $��50 �6   .+�5'   
     -   5          Name$ EmployeesGrid��5'   /      AutoGenerateColumns .  $��1��6F      HeadersVisibility$ Column=�6S   	   Columns	 5(      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Имя��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6K     5+      $
 Должность��6B   $	 100 6U    6%   �� *
Position+6U     5,      $
 Стаж��6D   $ 50 6R    6%   �� *
Experience+6R     5-      $
 Дата Рождения��6V   $ 95 6m    6%   �� *BDAY+ �� StringFormat$ 
dd.MM.yyyy��6m     5.      $!
 Номер телефона��6E   $	 110 6]    6%   �� *PhoneNumber+6]   50      �� 51   
   -   5         ��Name$ updateButton��51      $��2��6   $��Обновить��64   $��272,0,146,0q�6b   �� 52   
   -   5        $ deleteButton��52      $��2��6   $��Удалить��65   $��120,0,296,0q�6b   �� 53   
   -   5         ��Name$ 
searchtext��53   Y   $��0��6   $��Right=�6   $	��150��6;   $��0,0,70,0q�6G   6Y   �� 54   
   -   5        $ Clearbtn��54   V   $��20��6   $��Right=�6   $��X��68   $��0,0,70,0q�6D   6�   �� 55   
   -   5        $ 	Searchbtn��55   I   $��70��6   $��Right=�6   $��Найти!��68   6v   56      57      