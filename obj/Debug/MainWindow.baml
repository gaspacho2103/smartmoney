   M S B A M L   `   `   `  ����E  ASmartMoney, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SmartMoney
SmartMoney  5   	       SmartMoney.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:SmartMoney  5   	     � WindowStyle$
  None=�5	   	    � WindowState$ Normal=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .    WindowStyle#���   5   	    � Title$ 
MainWindow��5   	   $	��650��6   $	��950��6)   ��5   	   Z� .��5      #  MaterialDesignThemes.Wpf.Card  -   5           UniformCornerRadius$ 20Q�5      .��5   
   �   	GridStyle#���  6    � ColumnDefinitions 5      �� 5      $	��100 �6#   61   �� 5      $	��850 �6#   61   .+�5   
   �� -   5         ��Name$ xMarkButton��5        xMarkButtonStyle#���  6&   $��1��6Q   $��45��6a   $��25��6l   $��Right=�6x   $	��Top=�6�   $��X��6�   $
��Bold"�6�   $��18(�6�   $
��1.75q�6�   6  �� 5   
   -   5        $ collapseMarkButton��5        collapseMarkButtonStyle#���  6-   $��1��6_   $��45��6o   $��25��6z   $��Right=�6�   $	��Top=�6�   $	��—��6�   $
��Bold"�6�   $��16(�6�   $
��1.75q�6�   $��0 0 50 0q�6  6/  �� 5   
   $��0��6   $��0��6!   $��Center=�6.     BorderStyle#���  6K   ._�5      �� .+�5      �   BorderGridStyle#���  6   .+�5      �� $��90��6    $��90��6,   $��/BorderLogo.png��67   $��Center=�6P   $��0 20 0 0q�6m   5      �� 5      -   5        $
 Main��5      $��Center=�6D   $��0 30 0 0q�6a    , (MaterialDesignFlatSecondaryLightBgButton#���  6s   .��5       '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$
	 Menu=�62   $��42��6>   $��38��6I   6W   5!      �� 5"      -   5        $ Profile��5"      $��Center=�6E   $��0 35 0 0q�6b   #���  6t   .��5#        $	 Account=�62   $��42��6A   $��38��6L   6Z   5$      �� 5%      -   5        $ Stocks��5%      $��Center=�6C   $��0 35 0 0q�6`   #���  6r   .��5&        $	 StairsUp=�62   $��42��6B   $��38��6M   6[   5'      �� 5(      -   5        $
 Chat��5(      $��Center=�6?   $��0 35 0 0q�6\   #���  6n   .��5)        $	 About=�62   $��45��6?   $��40��6J   6X   5*      �� 5+      -   5        $
 Exit��5+      $��Center=�6?   $��0 35 0 0q�6\   #���  6n   .��5,        $	 ExitRun=�62   $��42��6A   $��38��6L   6Z   5-      d� 5.      -	   5        
 d�Name$
 ThemeButton��5.   #   $��Bottom=�6S   $��Center=�6n   $��0 50 0 0q�6�   $��42��6�   $��38��6�   ���#222028���#222028���#2220286�   �� 5/      -
   5        $ Admin��5/   !   $��Center=�6E   $��0 15 0 0q�6b   #���  6t   $y�Hidden=�6�   .��50        $	 Administrator=�66   $��42��6K   $��38��6V   6d   51      52      53       � 54   
   -   5        $��	MainFrame��54   f     
FrameStyle#���  6   $��1��65   $��1��6I   $��0��6Y   $��Center=�6w     � NavigationUIVisibility$ Hidden=�6�   6�   55      56      57      