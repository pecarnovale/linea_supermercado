   M S B A M L   `   `   `  ����  LineaSupermercado"    LineaSupermercado.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Linea de Supermercado��5   	   $	��500��6'   $
��1200��64   $��Center=�6A   $��Center=�6^    � Icon$ AppIcon.png��6y    � 	Resources 5         DataGridStyle1 �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  ColumnHeaderStyle1 �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%+  &	        &	 X     �� 5   
   "  6'   .�5	      ��  �@ ColumnHeaderStyle# �  62   5
      �� 5   
   "  6+   .�5      ��  � ��$ 50��6'   �� 5       � �� �	#FFB1D1F06+   �� 5       � �� �#3336+   �� 5       � ��$ 14(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��90* �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   .+�5   
     -   5        $��dgCajas��5   	   #���   5         AlternatingRowBackground �#dadada	   AutoGenerateColumns	 .  ���#FFF
   CanUserAddRows
 .     CanUserResizeColumns .    ColumnHeaderHeight$ 30Q�5%   	   $��13(�5'   	   
�������   	RowHeight$ 25Q�5)         RowBackground
 ��������	#FFB1D1F0   HorizontalGridLinesBrush �#FFF   VerticalGridLinesBrush �#FFF � DataContext 5&   	   �� ��5+   	   ��    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5.         Header$ Numero de Caja��50         
IsReadOnly .    
Visibility$ Visible=�52      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5/      �� *
NumeroCaja+52        53      $ 1* 54      $ Nombre del Cajero��56       . $ Visible=�58       55      �� *Cajero+58        59      $ 1* 5:      $ Clientes por Antender��5<       . $ Visible=�5>       5;      �� *ClientesPorAtender+5>        5?      $ 1* 5@      $ Clientes Atendidos��5B       . $ Visible=�5D       5A      �� *ClientesAtendidos+5D        5F      $ 1* 5G      $  ��5I       . $ Visible=�5K       5H      �� *ProgramPath+5K      4  .System.Windows.Controls.DataGridTemplateColumn  5L      $  ��6)   $ 1* 63      CellTemplate 5M      �� 5N      .R�5O      ��  ��Name$ btnCerrarCaja��5P      -   5        $	��150��5Q      $
��Auto��5R      $��
CerrarCaja��5S      62   5T      5V        5W      $  ��6)   $ 1* 63    5X      �� 5Y      .R�5Z      �� $ btnAtenderCliente��5[      -   5        $	��150��5\      $
��Auto��5]      $��Atender Cliente��5^      {�6W   ��  �� Path$ ClientesPorAtender�5_      5a      5c      � 5d   
    � Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6<   .+�5e      �� -   5        $��
Abrir Caja��5e      $��46��6H   $��77��6T   ���	#FF4489CF���	#FF1F2F51
�������6�   �� 5f      -   5        $��Agregar Cliente��5f      $��46��6P   ���	#FF4489CF���	#FFF7F7F7$��99��6�   5g      5i      5k      