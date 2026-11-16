using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto { Nome = "Suíte Master", ValorAdultos = 225.50, ValorCriancas = 200.3 },
        new Quarto { Nome = "Suíte Premium", ValorAdultos = 180.30, ValorCriancas = 110.30 },
        new Quarto { Nome = "Suíte Standard", ValorAdultos = 140, ValorCriancas = 75 },
        new Quarto { Nome = "Suíte Crise", ValorAdultos = 100, ValorCriancas = 50 }
    };

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PickerQuarto.ItemsSource = lista_quartos;

        DataCheckin.MinimumDate = DateTime.Now;
        DataCheckin.MaximumDate = DateTime.Now.AddMonths(3);

        DataCheckout.MinimumDate = DateTime.Now.AddDays(1);
        DataCheckout.MaximumDate = DateTime.Now.AddMonths(4);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            int adultos = Convert.ToInt32(StepperAdultos.Value);
            int criancas = Convert.ToInt32(StepperCriancas.Value);

            Hospedagem h = new()
            {
                QntAdultos = adultos,
                QntCriancas = criancas,
                QuartoEscolhido = (Quarto)PickerQuarto.SelectedItem,
                Data_Check_In = DataCheckin.Date,
                Data_Check_out = DataCheckout.Date,
            };

            Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }

    private void DataCheckin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DataCheckout.MinimumDate = e.NewDate.AddDays(1);
    }
}