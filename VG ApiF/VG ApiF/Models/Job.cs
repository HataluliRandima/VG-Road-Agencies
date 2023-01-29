using System;
using System.Collections.Generic;

namespace VG_ApiF.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string? JobStatus { get; set; }

    public DateTime? JobDatestart { get; set; }

    public TimeSpan? JobTimestart { get; set; }

    public DateTime? JobDateend { get; set; }

    public TimeSpan? JobTimeend { get; set; }

    public int RId { get; set; }

    public int OfiId { get; set; }

    public virtual Official Ofi { get; set; } = null!;

    public virtual Report RIdNavigation { get; set; } = null!;
}
