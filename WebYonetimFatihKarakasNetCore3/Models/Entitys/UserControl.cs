using System;
using System.ComponentModel.DataAnnotations;

namespace KarakasWenAdmin.Models.Entitys
{
    public class UserControl
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kulanıcı Adı Boş Olamaz")]
        public string UserName { get; set; } = "";
        [Required(ErrorMessage = "Parola boş Olamaz")]
        [MinLength(6,ErrorMessage ="Parolanız 6 karakaterden fazla olmaldır.")]
        public string Password { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public string FullName { get; set; } 
        public string Role { get; set; } 
        public string emailAddresss { get; set; }
        public bool IsActive { get; set; }= true;
       
    }
}
