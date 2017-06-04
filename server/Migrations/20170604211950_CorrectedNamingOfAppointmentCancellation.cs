using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class CorrectedNamingOfAppointmentCancellation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CancelationReason",
                table: "Appointment",
                newName: "CancellationReason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CancellationReason",
                table: "Appointment",
                newName: "CancelationReason");
        }
    }
}
