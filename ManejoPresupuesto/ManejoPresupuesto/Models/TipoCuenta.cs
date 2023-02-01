using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name ="Nombre del tipo Cuenta")]
        [Remote(action: "VerificarExisteTipoCuenta", controller:"TiposCuentas")]
        public string Nombre { get; set; }

        public int UsuarioId { get; set; }

        public int Orden { get; set; }



    //    [Required(ErrorMessage = "El campo {0} es requerido")]
    //    [EmailAddress(ErrorMessage ="Se debe ingresar una direccion de email valida")]
    //    public string Email { get; set; }
    //    [Required(ErrorMessage = "El campo {0} es requerido")]
    //    [Range(minimum:18,maximum:130,ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
    //    public int Edad { get; set; }
    //    [Required(ErrorMessage = "El campo {0} es requerido")]
    //    [Url(ErrorMessage = "Se debe ingresar una {0} valida")]
    //    public string URL { get; set; }
    //    [Required(ErrorMessage = "El campo {0} es requerido")]
    //    [CreditCard(ErrorMessage ="La tarjeta de credito no es valida")]
    //    [Display(Name = "Tarjeta de credito")]
    //    public string TarjetaDeCredito { get; set; }


    }
}
