   M S B A M L   `   `   `  ����I  ESammlungsListe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SammlungsListeSammlungsListe  5   	       SammlungsListe.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SammlungsListe     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $
��1080��6   $
��1920��6*   .��5      � .+�5   
   �� $
��Left=�6   $
��1049��60   $	��Top=�6>   $
��1912��6V   .@�5      �� $��
Collection��6   .��5      � ���#FFF � ColumnDefinitions 5      �� 5      $	��25* �6+   �� 5      $	��25* �6+   �� 5      $	��50* �6+   .+�5      �� -   5        $��CardName��5      $��	50,40,0,0q�6.   $
��Left=�6A   $	��Top=�6\   $��Center=�6t   $��0��6�   $��35��6�   $	��350��6�   $
��Bold"�6�   $��18(�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Card Name��6�   �� 5      -   5        $��	Expansion��5      $��0��60   $
��Left=�6A   $	��Top=�6\   $
��Bold"�6t   $��35��6�   $	��350��6�   $��
50,100,0,0q�6�    �� 
IsEditable . $��18(�6�   $ 	Expansion��6�   ��5      �� 5       �� Path$ ExpansionNames�6&    �� UpdateSourceTrigger$ PropertyChanged=�6<    �� SelectedItem 5       �� 5!      $ SelectedExpansion�6&   $ PropertyChanged=�6?   5#      �� 5$      $��Selected expansion id:��6   $��0��6=   $
��Left=�6M   $	��Top=�6h   $��30��6�   $��
50,170,0,0q�6�   $��15(�6�   $
��Bold"�6�   �� 5%      -   5        $��ExpansionId��5%      $��0��6/   $
��Left=�6?   $	��Top=�6Z   $��25��6r   $	��100��6~   $��
50,190,0,0q�6�   ��5&      �� 5'      $ SelectedExpanisonId�6&   $ PropertyChanged=�6A   5)      �� 5*      -   5        $��
SearchCard��5*      $��0��6/   $
��Left=�6?   $	��Top=�6Z   $��Search Card��6r   $��35��6�   $	��350��6�   $��18(�6�   $
��Bold"�6�   $��
50,230,0,0q�6�   � 5,      $��0��6   y�5-      �� 5.      $ 
Visibility�6&   $ PropertyChanged=�68   .+�50      �� -   5        $��Language��50   #   $
��Left=�63   $	��Top=�6N   $��35��6f   $��18(�6r   $
��Bold"�6�   $	��350��6�   $��
50,300,0,0q�6�   $ Language��6�   ��51      �� 52   "   $ SelectedExpansionLanguage�6*   $ PropertyChanged=�6K   54      �� 55      -   5        $��	CardImage��55       $��0��61   $
��Fill=�6A   $��G:/Ayara.jpg��6P   $
��Left=�6f   $	��Top=�6�   $	��361��6�   $	��255��6�   $��
50,370,0,0q�6�   �� 56      $��Selected card id:��6    $��0��6<   $
��Left=�6L   $	��Top=�6g   $��30��6   $��
50,770,0,0q�6�   $��15(�6�   $
��Bold"�6�   �� 57      -   5        $��CardId��57       $��0��6.   $
��Left=�6>   $	��Top=�6Y   $��25��6q   $	��100��6}   $��
50,800,0,0q�6�   ��58      �� 59   "   $ SelectedCardId�6*   $ PropertyChanged=�6@   5;      �� 5<      -   5        $��AddCard��5<   !   $��0��60   $
��Left=�6@   $	��Top=�6[   $��Add Card��6s   $��35��6�   $	��350��6�   $��18(�6�   $
��Bold"�6�   $��
50,870,0,0q�6�   �� 5=      -	   5        $��ExportExcel��5=   !   $��0��64   $
��Left=�6D   $	��Top=�6_   $��Export to Excel��6w   $��35��6�   $	��350��6�   $��18(�6�   $
��Bold"�6�   $��
50,950,0,0q�6�   5>      � 5@      $��1��6   y�5A      �� 5B      $ 
Visibility�6&   $ PropertyChanged=�68   .+�5E      �� -
   5        $��
GetSingles��5E   !   $��1��63   $
��Left=�6C   $	��Top=�6^   $��Get Singles��6v   $��40��6�   $	��350��6�   $��18(�6�   $
��Bold"�6�   $��	50,40,0,0q�6�   ��5F      �� 5G   "   $ GetSinglesClicked�6*   $ PropertyChanged=�6C   5I      5J      5L      5M      �� 5N      $��Add New Expansion��6   .��5O      � ���#FFF 5P      �� 5Q      $	��50* �6+   �� 5R      $	��50* �6+   5W      5X      �� 5Y      $��Update Prices��5Z      .��5[      � ���#FFF6   5\      �� 5]      $��TabItem��6   .��5^      � ���	#FFE5E5E56   5_      �� 5`      $��TabItem��6   .��5a      � ���	#FFE5E5E56   5b      �� 5c      $��Console��6   .��5d      � ���#FFF.+�5e      �� -   5        $��ConsoleOutput��5e      $��0,0,0,0q�63   .��6D   ��5f      �� 5g      $ ConsoleOutput�6&   $ PropertyChanged=�6;   .��5h   (   5i      5j      5k      5l      5m      5n      