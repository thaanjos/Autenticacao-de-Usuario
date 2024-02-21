using System.ComponentModel.DataAnnotations;

namespace projeto_asp_net_cor.Models;

public class LoginModel
{
    public string UserName { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

}
