using System.ComponentModel.DataAnnotations;

namespace WebAPI_ProjetoFinal.Core.Model
{
    public class CityEvent
    {
        public long IdEvent { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Data e Hora são obrigatórias")]
        public DateTime DateHourEvent { get; set; }

        [Required(ErrorMessage = "Local é obrigatório")]
        public string Local { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public bool Status { get; set; }
    }
}
