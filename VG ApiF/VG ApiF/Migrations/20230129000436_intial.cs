using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VGApiF.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    citiid = table.Column<int>(name: "citi_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    citiname = table.Column<string>(name: "citi_name", type: "varchar(max)", unicode: false, nullable: false),
                    citilastname = table.Column<string>(name: "citi_lastname", type: "varchar(max)", unicode: false, nullable: false),
                    citiemail = table.Column<string>(name: "citi_email", type: "varchar(max)", unicode: false, nullable: false),
                    citipassword = table.Column<string>(name: "citi_password", type: "varchar(max)", unicode: false, nullable: false),
                    citistatus = table.Column<string>(name: "citi_status", type: "varchar(max)", unicode: false, nullable: true),
                    citicontactdetails = table.Column<string>(name: "citi_contactdetails", type: "varchar(max)", unicode: false, nullable: false),
                    citiaddress = table.Column<string>(name: "citi_address", type: "varchar(max)", unicode: false, nullable: false),
                    citicity = table.Column<string>(name: "citi_city", type: "varchar(max)", unicode: false, nullable: false),
                    citiprovince = table.Column<string>(name: "citi_province", type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.citiid);
                });

            migrationBuilder.CreateTable(
                name: "Officials",
                columns: table => new
                {
                    ofiid = table.Column<int>(name: "ofi_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ofiname = table.Column<string>(name: "ofi_name", type: "varchar(max)", unicode: false, nullable: false),
                    ofilastname = table.Column<string>(name: "ofi_lastname", type: "varchar(max)", unicode: false, nullable: false),
                    ofiemail = table.Column<string>(name: "ofi_email", type: "varchar(max)", unicode: false, nullable: false),
                    ofipassword = table.Column<string>(name: "ofi_password", type: "varchar(max)", unicode: false, nullable: false),
                    ofistatus = table.Column<string>(name: "ofi_status", type: "varchar(max)", unicode: false, nullable: true),
                    ofitype = table.Column<string>(name: "ofi_type", type: "varchar(max)", unicode: false, nullable: false),
                    ofibadge = table.Column<string>(name: "ofi_badge", type: "varchar(max)", unicode: false, nullable: false),
                    ofiaddress = table.Column<string>(name: "ofi_address", type: "varchar(max)", unicode: false, nullable: false),
                    ofipic = table.Column<string>(name: "ofi_pic", type: "varchar(max)", unicode: false, nullable: true),
                    oficontactdetails = table.Column<string>(name: "ofi_contactdetails", type: "varchar(max)", unicode: false, nullable: false),
                    ofipasssend = table.Column<string>(name: "ofi_passsend", type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officials", x => x.ofiid);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    rid = table.Column<int>(name: "r_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rdescription = table.Column<string>(name: "r_description", type: "varchar(max)", unicode: false, nullable: false),
                    rpics1 = table.Column<string>(name: "r_pics1", type: "varchar(max)", unicode: false, nullable: true),
                    rpics2 = table.Column<string>(name: "r_pics2", type: "varchar(max)", unicode: false, nullable: true),
                    rpics3 = table.Column<string>(name: "r_pics3", type: "varchar(max)", unicode: false, nullable: true),
                    rtype = table.Column<string>(name: "r_type", type: "varchar(max)", unicode: false, nullable: false),
                    rstatus = table.Column<string>(name: "r_status", type: "varchar(max)", unicode: false, nullable: false),
                    rdatereported = table.Column<DateTime>(name: "r_datereported", type: "date", nullable: true),
                    rtimereported = table.Column<TimeSpan>(name: "r_timereported", type: "time", nullable: true),
                    rviewtime = table.Column<TimeSpan>(name: "r_viewtime", type: "time", nullable: true),
                    rviewdate = table.Column<DateTime>(name: "r_viewdate", type: "date", nullable: true),
                    rdateupdated = table.Column<DateTime>(name: "r_dateupdated", type: "date", nullable: true),
                    rlocationpoint = table.Column<string>(name: "r_locationpoint", type: "varchar(max)", unicode: false, nullable: true),
                    raddress = table.Column<string>(name: "r_address", type: "varchar(max)", unicode: false, nullable: false),
                    rlat = table.Column<string>(name: "r_lat", type: "varchar(max)", unicode: false, nullable: true),
                    rlong = table.Column<string>(name: "r_long", type: "varchar(max)", unicode: false, nullable: true),
                    rcity = table.Column<string>(name: "r_city", type: "varchar(max)", unicode: false, nullable: false),
                    rprovince = table.Column<string>(name: "r_province", type: "varchar(max)", unicode: false, nullable: false),
                    ofiid = table.Column<int>(name: "ofi_id", type: "int", nullable: false),
                    citiid = table.Column<int>(name: "citi_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.rid);
                    table.ForeignKey(
                        name: "FK_Report_Citizens",
                        column: x => x.citiid,
                        principalTable: "Citizens",
                        principalColumn: "citi_id");
                    table.ForeignKey(
                        name: "FK_Report_Officials",
                        column: x => x.ofiid,
                        principalTable: "Officials",
                        principalColumn: "ofi_id");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    jobid = table.Column<int>(name: "job_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobstatus = table.Column<string>(name: "job_status", type: "varchar(max)", unicode: false, nullable: true),
                    jobdatestart = table.Column<DateTime>(name: "job_datestart", type: "date", nullable: true),
                    jobtimestart = table.Column<TimeSpan>(name: "job_timestart", type: "time", nullable: true),
                    jobdateend = table.Column<DateTime>(name: "job_dateend", type: "date", nullable: true),
                    jobtimeend = table.Column<TimeSpan>(name: "job_timeend", type: "time", nullable: true),
                    rid = table.Column<int>(name: "r_id", type: "int", nullable: false),
                    ofiid = table.Column<int>(name: "ofi_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.jobid);
                    table.ForeignKey(
                        name: "FK_Job_Officials",
                        column: x => x.ofiid,
                        principalTable: "Officials",
                        principalColumn: "ofi_id");
                    table.ForeignKey(
                        name: "FK_Job_Report",
                        column: x => x.rid,
                        principalTable: "Report",
                        principalColumn: "r_id");
                });

            migrationBuilder.CreateTable(
                name: "ReportComment",
                columns: table => new
                {
                    rcid = table.Column<int>(name: "rc_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rccomment = table.Column<string>(name: "rc_comment", type: "varchar(max)", unicode: false, nullable: false),
                    rcdate = table.Column<DateTime>(name: "rc_date", type: "date", nullable: true),
                    rctime = table.Column<TimeSpan>(name: "rc_time", type: "time", nullable: true),
                    ofiid = table.Column<int>(name: "ofi_id", type: "int", nullable: false),
                    citiid = table.Column<int>(name: "citi_id", type: "int", nullable: false),
                    rid = table.Column<int>(name: "r_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportComment", x => x.rcid);
                    table.ForeignKey(
                        name: "FK_ReportComment_Citizens",
                        column: x => x.citiid,
                        principalTable: "Citizens",
                        principalColumn: "citi_id");
                    table.ForeignKey(
                        name: "FK_ReportComment_Officials",
                        column: x => x.ofiid,
                        principalTable: "Officials",
                        principalColumn: "ofi_id");
                    table.ForeignKey(
                        name: "FK_ReportComment_Report",
                        column: x => x.rid,
                        principalTable: "Report",
                        principalColumn: "r_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_ofi_id",
                table: "Job",
                column: "ofi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_r_id",
                table: "Job",
                column: "r_id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_citi_id",
                table: "Report",
                column: "citi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ofi_id",
                table: "Report",
                column: "ofi_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportComment_citi_id",
                table: "ReportComment",
                column: "citi_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportComment_ofi_id",
                table: "ReportComment",
                column: "ofi_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportComment_r_id",
                table: "ReportComment",
                column: "r_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "ReportComment");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Officials");
        }
    }
}
