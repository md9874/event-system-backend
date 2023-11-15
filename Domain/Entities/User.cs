using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nick { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public List<Conversation> Conversations { get; set; }
        public List<Message> Messages { get; set; }
    }
}
