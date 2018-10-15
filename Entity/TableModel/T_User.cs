using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MySql.Data;
using MySql.Data.EntityFrameworkCore;

namespace Entity.TableModel
{
     public class T_User
    {
         
        [Required]
        [MaxLength(32)]
        public string userId { get; set; }

        [Required]
        [MaxLength(32)]
        [Key]
        public string userName { get; set; }

        [Required]
        [MaxLength(32)]
        public string passWord { get; set; }

        [MaxLength(32)]
        public string userRole { get; set; }

        public int loginCount { get; set; }

        public int wrongCount { get; set; }

        public DateTime lastLoginTime { get; set; }

        [Required]
        public int status { get; set; }


    }
}
