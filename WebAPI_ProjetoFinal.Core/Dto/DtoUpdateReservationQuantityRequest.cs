using System.ComponentModel.DataAnnotations;

namespace WebAPI_ProjetoFinal.Core.Dto
{
    public class DtoUpdateReservationQuantityRequest
    {
        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public long Quantity { get; set; }
    }
}
