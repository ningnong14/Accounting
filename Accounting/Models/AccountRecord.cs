using System;
using System.Collections.Generic;

namespace Accounting.Models;

public partial class AccountRecord
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string Voucher { get; set; }

    public string MainAccount { get; set; }

    public string Description { get; set; }

    public string Debit { get; set; }

    public string Credit { get; set; }
}
