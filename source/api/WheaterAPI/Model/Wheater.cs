using System.ComponentModel.DataAnnotations;

namespace WheaterAPI.Model
{
    public class Wheater 
    {
        [Required(ErrorMessage = "Algo errado ocorreu, tenta novamento mais tarde !!")]
        public string City { get; set; }
        public string Sensation { get; set; }
        public int Humidity { get; set; }
        public string Pressure { get; set; }
        public string Wind { get; set; }

        [Required(ErrorMessage = "Necessário Temperatura Miníma")]
        public string MinTemperature { get; set; }

        [Required(ErrorMessage = "Necessário Temperatura Máxima")]
        public string MaxTemperature { get; set; }

        [Required(ErrorMessage = "Algo errado ocorreu, tenta novamento mais tarde !!")]
        public int IdUser { get; set; }
    }
}
