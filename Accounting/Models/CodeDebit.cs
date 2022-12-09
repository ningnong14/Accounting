using System;
using System.Collections.Generic;

namespace Accounting.Models;

public partial class CodeDebit
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }
}
