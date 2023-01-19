using System;
using System.Collections.Generic;

namespace Accounting.Models;

public partial class RecordAccounting
{
    public int TagVoucher { get; set; }

    public string CodeVoucher { get; set; }

    public string MainAccount { get; set; }

    public string Description { get; set; }

    public int? Credit { get; set; }

    public int? Debit { get; set; }

    public DateTime DateTimeTo { get; set; }
}
