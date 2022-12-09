using System;
using System.Collections.Generic;

namespace Accounting.Models;

public partial class BillRecord
{
    public int BillId { get; set; }

    public DateTime? Date { get; set; }

    public string Voucher { get; set; }

    public string MainAccount { get; set; }

    public string Description { get; set; }

    public int? Debit { get; set; }

    public int? Credit { get; set; }
}
