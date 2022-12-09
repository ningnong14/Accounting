using System;
using System.Collections.Generic;

namespace Accounting.Models;

public partial class UserLogin
{
    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? FirstLogin { get; set; }

    public DateTime? LastLogin { get; set; }
}
