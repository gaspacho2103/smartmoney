   M S B A M L   `   `   `  ����E  ASmartMoney, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SmartMoney
SmartMoney  5          SmartMoney.ProfilePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:SmartMoney     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        N� Title$  ProfilePage��5
      .��5      �    ProfilePageGrid#���   6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $
��Left=�6F   $��	45 45 0 0q�6a   .+�5      ��  �� CornerRadius$	 250��6   $	��150��6(   $	��135��64   ��5      �� 5       �� ImageSource$ /avatar.png��6    j� Stretch$
 None=�67    j� TileMode$
 None=�6F   5      �� 5      -   5         ��Name$ SurnameProfileBox��5      $��31(�63   $
��Bold"�6A   $��Center=�6S   ���#d11144$��55 0 0 0q�6�   
Горин6�   �� 5      -   5        $ NameProfileBox��5      $��31(�60   $
��Bold"�6>   $��Center=�6P   ���#d11144$��10 0 0 0q�6�   Генадий6�   5      �� 5   
   $ 
Horizontal=�6   $��
15 -40 0 0q�6.   .+�5      ��  # InformationBorderBoxProfilePage#���  6   ���#d11144$	��3.5q�6e   $ 30��6{   $	��170��6�   $
��Auto��6�   $	��160��6�   $
��Left=�6�   $��3 0 0 0q�6�    �� Padding$ 	15 5 15 5q�6�   ._�5      �� $��Center=�6   .+�5      ��   ProfileInformationText#���  6   $��SemiBold"�6M   $��22(�6c   $��Center=�6q   Телефон:6�   �� 5      -   5        $ TelephoneProfileBox��5       #���  6=   ���#d11144$
��Bold"�6�   $��24(�6�   $��Center=�6�   $��0 7 0 0q�6�   +791721851136�   5      5      �� 5       ! OperationBorderBoxProfilePage#���  6   ���#d11144$	��3.5q�6c   $ 30��6y   $	��220��6�   $
��Auto��6�   $	��160��6�   $��Center=�6�   $��25 0 0 0q�6�   $ 	15 0 15 5q�6�   ._�5      �� .+�5      �� #���  6   $��20(�6M   $��SemiBold"�6[   $��Center=�6q   $��0 5 0 0q�6�   Пополнено:6�   �� 5       -   5        $ ReplenishProfileBox��5       #���  69   $
��Bold"�6j   $��22(�6|   ���#d11144$��Center=�6�   $��0 10 0 0q�6�   5 412 643 215 ₽6�   �� 5!      #���  6   $��20(�6M   $��SemiBold"�6[   $��Center=�6q   $��0 5 0 0q�6�   Выведено:6�   �� 5"      -   5        $ WithdrawProfileBox��5"      #���  68   $
��Bold"�6i   $��22(�6{   ���#d11144$��Center=�6�   $��0 10 0 0q�6�   9 346 251 918 ₽6�   5#      5$      �� 5%        CountBorderBoxProfilePage#���  6   ���#d11144$	��3.5q�6_   $ 30��6u   $	��160��6�   $
��Auto��6�   $	��160��6�   $ 	15 5 15 5q�6�   $
��Left=�6�   $��25 0 0 0q�6�   ._�5&      �� .+�5'      �� #���  6    $��19(�6Q   $��SemiBold"�6_   $��Center=�6u   $��0 10 0 0q�6�   Акции:6�   �� 5(      -   5        $ StocksBuyCount��5(      #���  64   $
��Bold"�6e   $��39(�6w   ���#d11144$��Center=�6�   $��0 22 0 0q�6�   1166�   5)      5*      5+      �� 5,   
   $ 
Horizontal=�6   $��Bottom=�6.   $��0 0 0 75q�6I   .+�5-      �� $ Vertical=�6   $��15 0 0 0q�60   .+�5.      �� -   5         ��Name$ 	Replenish��5.      $��SemiBold"�6,     ReplenishButtonProfilePage#���  6B   $	��175��6w   $��68��6�   $��Center=�6�   $	��Top=�6�   $��
20 2.5 0 0q�6�   $��21(�6�   $��Пополнить��6�   6  �� 5/      -   5        $ Withdraw��5/      $��SemiBold"�6+     WithdrawButtonProfilePage#���  6A   $	��175��6u   $��68��6�   $��Center=�6�   $��Bottom=�6�   $��	20 20 0 0q�6�   $��21(�6�   $��Вывести��6�   6  50      �� 51        BalanceBorderBoxProfilePage#���  6   ���#d11144$	��3.5q�6a   $ 30��6w   $
��Auto��6�   $	��402��6�   $	��160��6�   $��Right=�6�   $��45 0 0 0q�6�   $ 	20 5 20 5q�6�   $	��Top=�6�   ._�52      �� -	   5        $ BalanceProfileBox��52      $��42(�67   $
��Bold"�6E   ���#d11144$��Center=�6l   $��Center=�6�   $��Verdana)�6�   	6 123 ₽6�   53      54      55      56      