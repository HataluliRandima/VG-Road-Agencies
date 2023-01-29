using System;
using System.Collections.Generic;

namespace VG_ApiF.Models;

public partial class ReportComment
{
    public int RcId { get; set; }

    public string RcComment { get; set; } = null!;

    public DateTime? RcDate { get; set; }

    public TimeSpan? RcTime { get; set; }

    public int OfiId { get; set; }

    public int CitiId { get; set; }

    public int RId { get; set; }

    public virtual Citizen Citi { get; set; } = null!;

    public virtual Official Ofi { get; set; } = null!;

    public virtual Report RIdNavigation { get; set; } = null!;
}
