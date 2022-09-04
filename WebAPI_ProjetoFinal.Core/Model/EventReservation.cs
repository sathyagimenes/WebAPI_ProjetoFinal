using System.ComponentModel.DataAnnotations;

namespace WebAPI_ProjetoFinal.Core.Model
{
    public class EventReservation
    {
        public long IdReservation { get; set; }

        [Required(ErrorMessage = "ID do evento é obrigatório")]
        public long IdEvent { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public long Quantity { get; set; }
    }
}
