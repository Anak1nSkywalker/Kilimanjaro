using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha a descrição do Tipo de Usuário")]
        public string Description { get; set; }

        public virtual IEnumerable<User> User { get; set; }
    }
}
