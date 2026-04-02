using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniProjetoCadastroTarefa.Classes.Generico
{
    public static class clsApoio
    {
        public static void AbrirComboBox(ComboBox combo, KeyEventArgs e)
        {
            combo.Focus();

            combo.Dispatcher.InvokeAsync(() =>
            {
                combo.IsDropDownOpen = true;
            }, System.Windows.Threading.DispatcherPriority.Background);

            e.Handled = true;
        }
        public static void AbrirComboBox(ComboBox combo)
        {
            combo.Focus();

            combo.Dispatcher.InvokeAsync(() =>
            {
                combo.IsDropDownOpen = true;
            }, System.Windows.Threading.DispatcherPriority.Background);

        }
    }
}
