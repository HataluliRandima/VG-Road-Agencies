namespace VG_ApiF.DTO
{
    public class AddReport
    {
        //public int RId { get; set; }

        public string RDescription { get; set; } = null!;

        //public string? RPics1 { get; set; }

        //public string? RPics2 { get; set; }

        //public string? RPics3 { get; set; }

        public string RType { get; set; } = null!;

        //public string RStatus { get; set; } = null!;

        public DateTime? RDatereported { get; set; }

        public TimeSpan? RTimereported { get; set; }

        //public TimeSpan? RViewtime { get; set; }

        //public DateTime? RViewdate { get; set; }

        //public DateTime? RDateupdated { get; set; }

       // public string? RLocationpoint { get; set; }

        public string RAddress { get; set; } = null!;

        public string? RLat { get; set; }

        public string? RLong { get; set; }

        public string RCity { get; set; } = null!;

        public string RProvince { get; set; } = null!;

        //public int OfiId { get; set; }

        //public int CitiId { get; set; }
    }
}
