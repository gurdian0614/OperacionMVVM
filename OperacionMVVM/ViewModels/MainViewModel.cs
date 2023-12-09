using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OperacionMVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private double valor1;
        
        [ObservableProperty] 
        private double valor2;

        [ObservableProperty]
        private double resultado;

        [RelayCommand]
        private void Division()
        {
            try
            {
                if (Valor2 != 0)
                {
                    Resultado = Valor1 / Valor2;
                } else
                {
                    MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert("ERROR", "No se puede dividir entre cero", "Aceptar"));
                }
            } catch (Exception ex)
            {
                MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert("ERROR", ex.Message, "Aceptar"));
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Valor1 = Valor2 = Resultado = 0;
        }    }
}
