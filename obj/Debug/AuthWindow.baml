   M S B A M L   `   `   `  ����E  ASmartMoney, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SmartMoney
SmartMoney  5   	       SmartMoney.AuthWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:SmartMoney  5   	     � WindowStyle$
  None=�5	   	    � WindowState$ Normal=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � Title$ 
AuthWindow��5   	   $	��550��6   $	��425��6)   ��5   	   Z� .��5      #  MaterialDesignThemes.Wpf.Card  -   5           UniformCornerRadius$ 20Q�5      .��5   
   � .+�5      �� -   5         ��Name$ xMarkButton��5         xMarkButtonStyle#���   6*   $��45��6U   $��25��6`   $��Right=�6l   $	��Top=�6�   $��X��6�   $
��Bold"�6�   $��18(�6�   $
��1.75q�6�   $��1��6�   6  �� 5      -   5        $ collapseMarkButton��5        collapseMarkButtonStyle#���  61   $��45��6c   $��25��6n   $��Right=�6z   $	��Top=�6�   $	��—��6�   $
��Bold"�6�   $��16(�6�   $
��1.75q�6�   $��1��6  $��0 0 50 0q�6   64  �� 5      $��
20 80 20 0q�6   .+�5      �� $��25(�6   ���#d11144$
��Bold"�6;   $��10 0 0 0q�6M   " Приветствуем вас!6r   �� 5      -   5        $ 	RegButton��5       " MaterialDesignFlatAccentButton#���  6(   $	��110��6a   $��30��6m   $��Регистрация��6y   ���#d11144$��12(�6�   $��SemiBold"�6�   $��Right=�6�   $��	0 26 10 0q�6�   6  �� 5      -   5         ��Name$ TelephoneTextBox��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$0	 *Введите номер телефона��60    ! MaterialDesignOutlinedTextBox#��[ 6h   $��0 40 0 0q�6�   ���#222028���#d11144
 �� 
CaretBrush
 �#222028 �� SelectionBrush �#222028$��2q�6
  $	��365��6  $��45��6*  $��10 8 8 4q�66  $��18(�6I  6Y  G� 5      -   5         G�Name$ PassBox��5      $!	 Введите пароль��6+    % !MaterialDesignOutlinedPasswordBox#��[ 6[   $��0 30 0 0q�6�   ���#222028���#d11144 G� 
CaretBrush �#222028 G� SelectionBrush �#222028$��2q�6  $	��365��6  $��45��6!  $��10 8 8 4q�6-  $��18(�6@  6P  �� 5      -   5        $ 
AuthButton��5        SenderButtonStyle#��[ 6)   $��0 52 0 0q�6T   $	��365��6f   $��38��6r   $��SemiBold"�6~   $��18(�6�   $��
Войти��6�   6�   5      5      5      5      