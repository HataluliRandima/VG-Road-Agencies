using System;
using System.Collections.Generic;

namespace VG_ApiF.Models;

public partial class Citizen
{
    public int CitiId { get; set; }

    public string CitiName { get; set; } = null!;

    public string CitiLastname { get; set; } = null!;

    public string CitiEmail { get; set; } = null!;

    public string CitiPassword { get; set; } = null!;

    public string? CitiStatus { get; set; }

    public string CitiContactdetails { get; set; } = null!;

    public string CitiAddress { get; set; } = null!;

    public string CitiCity { get; set; } = null!;

    public string CitiProvince { get; set; } = null!;

    public virtual ICollection<ReportComment> ReportComments { get; } = new List<ReportComment>();

    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
