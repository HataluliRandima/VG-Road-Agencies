using System;
using System.Collections.Generic;

namespace VG_ApiF.Models;

public partial class Official
{
    public int OfiId { get; set; }

    public string OfiName { get; set; } = null!;

    public string OfiLastname { get; set; } = null!;

    public string OfiEmail { get; set; } = null!;

    public string OfiPassword { get; set; } = null!;

    public string? OfiStatus { get; set; }

    public string OfiType { get; set; } = null!;

    public string OfiBadge { get; set; } = null!;

    public string OfiAddress { get; set; } = null!;

    public string? OfiPic { get; set; }

    public string OfiContactdetails { get; set; } = null!;

    public string? OfiPasssend { get; set; }

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();

    public virtual ICollection<ReportComment> ReportComments { get; } = new List<ReportComment>();

    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
