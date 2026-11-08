
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto { Nome = "Suíte Master", ValorAdultos = 225.5, ValorCriancas = 200.3 },
        new Quarto { Nome = "Suíte Premium", ValorAdultos = 180.3, ValorCriancas = 110.3 },
        new Quarto { Nome = "Suíte Viajante", ValorAdultos = 140, ValorCriancas = 75 },
        new Quarto { Nome = "Suíte Crise", ValorAdultos = 100.3, ValorCriancas = 50.0 },
    };

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(3);

        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Today.AddMonths(4);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime dataCheckin = dtpck_checkin.Date ?? DateTime.Today;

        dtpck_checkout.MinimumDate = dataCheckin.AddDays(1);
    }

    private async void btn_calcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert("Atenção", "Selecione uma acomodação.", "OK");
                return;
            }

            DateTime checkin = dtpck_checkin.Date ?? DateTime.Today;
            DateTime checkout = dtpck_checkout.Date ?? DateTime.Today.AddDays(1);

            if (checkout <= checkin)
            {
                await DisplayAlert("Atenção", "O check-out deve ser posterior ao check-in.", "OK");
                return;
            }

            Quarto quarto = (Quarto)pck_quarto.SelectedItem;

            int adultos = Convert.ToInt32(stp_adultos.Value);
            int criancas = Convert.ToInt32(stp_criancas.Value);

            int dias = (checkout - checkin).Days;

            double valorAdultos = adultos * quarto.ValorAdultos;
            double valorCriancas = criancas * quarto.ValorCriancas;

            double total = (valorAdultos + valorCriancas) * dias;

            lbl_valor_total.Text = total.ToString("C2");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", ex.Message, "OK");
        }
    }
}
