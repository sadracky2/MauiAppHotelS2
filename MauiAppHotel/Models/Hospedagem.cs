namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public required Quarto QuartoEscolhido { get; set; }

        public int QntAdultos { get; set; }

        public int QntCriancas { get; set; }

        public DateTime Data_Check_In { get; set; }
        public DateTime Data_Check_out { get; set; }

        public int Estadia
        {
            get => Data_Check_out.Subtract(Data_Check_In).Days;
        }

        public double TotalHospedagem
        {
            get
            {
                double total_adultos = QntAdultos * QuartoEscolhido.ValorAdultos;
                double total_criancas = QntCriancas * QuartoEscolhido.ValorCriancas;
                return (total_adultos + total_criancas)*Estadia;
            }
        }
    }
}
