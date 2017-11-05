using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class UserModel
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(10, ErrorMessage = "长度限制！")]
        public string name { get; set; }
        [DisplayName("年龄")]
        [Required(ErrorMessage = "请输入{0}")]
        public string age { get; set; }
    }
}