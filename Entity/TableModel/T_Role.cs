using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MySql.Data;
using MySql.Data.EntityFrameworkCore;

namespace Entity.TableModel
{
    public class T_Role
    {
        [Required]
        [MaxLength(32)]
        [Key]
        public string roleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string roleName { get; set; }

        [MaxLength(32)]
        public string menuCode { get; set; }

        public int operateType { get; set; }

        [MaxLength(200)]
        public string remark { get; set; }
    }
}
