namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		DisplayAlertAsync("Programador: Sadracky Antunes da Silva", "Obrigado por usar este app", "Voltar");
    }
}