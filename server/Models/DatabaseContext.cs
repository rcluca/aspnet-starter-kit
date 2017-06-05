// Copyright © 2014-present Kriasoft, LLC. All rights reserved.
// This source code is licensed under the MIT license found in the
// LICENSE.txt file in the root directory of this source tree.

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Models;
using server.Models.Interfaces;
using System;
using System.Linq;

namespace Server.Models
{
    public class DatabaseContext : IdentityDbContext<User>, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Patient>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentPurpose> AppointmentPurpose { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Physician> Physician { get; set; }
    }

    public static class DatabaseContextExtensions
    {
        public static void EnsureSeedData(this DatabaseContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { Id = "1a105dd3-7d8d-4e85-9509-cbcd043600c9", AccessFailedCount = 0, ConcurrencyStamp = "4ab0eb6e-f843-4446-99a4-4fb78ef59b3a", Email = "caesar@rome.com", EmailConfirmed = false, LockoutEnabled = true, LockoutEnd = null, NormalizedEmail = "CAESAR@ROME.COM", NormalizedUserName = "CAESAR@ROME.COM", PasswordHash = @"AQAAAAEAACcQAAAAENxuyU1MnTBdrxM9QbkfiykyPz56RCQ5A8xBUycvYJDgUkP8qWlizleeJStojMvCZw==", PhoneNumber = null, PhoneNumberConfirmed = false, SecurityStamp = "8382586d-f52e-4ba3-ab34-d7089aeafdf1", TwoFactorEnabled = false, UserName = "caesar@rome.com" },
                        new User { Id = "41cbf6cc-90b8-46d1-8b79-d4fca4c53f88", AccessFailedCount = 0, ConcurrencyStamp = "f9e50626-2753-4bce-a030-445a9f0dd1b1", Email = "cleopatra@egypt.com", EmailConfirmed = false, LockoutEnabled = true, LockoutEnd = null, NormalizedEmail = "CLEOPATRA@EGYPT.COM", NormalizedUserName = "CLEOPATRA@EGYPT.COM", PasswordHash = @"AQAAAAEAACcQAAAAEI/5Ic55rHBCrO11CpCgGO9zWXovTIET1SvYy8DCG7i+f0VgiByGJkkeNZDVa6rruw==", PhoneNumber = null, PhoneNumberConfirmed = false, SecurityStamp = "690b1ed7-80e2-44a2-aaa5-dd8ca4792150", TwoFactorEnabled = false, UserName = "cleopatra@egypt.com" },
                        new User { Id = "4bb7569f-a399-4d34-ae14-f90bc371f1f2", AccessFailedCount = 0, ConcurrencyStamp = "5770ac1c-8c5b-49fb-8202-a65e8045f2a3", Email = "hippocrates@oath.com", EmailConfirmed = false, LockoutEnabled = true, LockoutEnd = null, NormalizedEmail = "HIPPOCRATES@OATH.COM", NormalizedUserName = "HIPPOCRATES@OATH.COM", PasswordHash = @"AQAAAAEAACcQAAAAEMjYZGH+N9xaDs2GRsOSOWvJuqPwdv6D/Chfx+NsVM0vrhvKUZFMrPsB6An2s0nm7Q==", PhoneNumber = null, PhoneNumberConfirmed = false, SecurityStamp = "f204a6cc-eae8-4833-b802-57c89171208d", TwoFactorEnabled = false, UserName = "hippocrates@oath.com" },
                        new User { Id = "f65d9caf-6ff2-445e-ba2c-dbbf3018ace1", AccessFailedCount = 0, ConcurrencyStamp = "27dbac60-76b4-48b1-9ad6-7420e6f8026a", Email = "herophilos@anatomy.com", EmailConfirmed = false, LockoutEnabled = true, LockoutEnd = null, NormalizedEmail = "HEROPHILOS@ANATOMY.COM", NormalizedUserName = "HEROPHILOS@ANATOMY.COM", PasswordHash = @"AQAAAAEAACcQAAAAEJc81kjVQ92wjS8bfVPc9SE0dpbRWiDzuI/hCvLqGgEoM3t03UU/1tVa8r00myCGFw==", PhoneNumber = null, PhoneNumberConfirmed = false, SecurityStamp = "3561ee6b-4f0e-4fe1-adc3-a93e8d575060", TwoFactorEnabled = false, UserName = "herophilos@anatomy.com" }
                    );

                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new IdentityRole { Id = "213b5870-c691-4f55-88a1-ceb8781248ac", ConcurrencyStamp = "d9dd24bf-2036-4c71-b3e6-6468d26c47e3", Name = "Physician", NormalizedName = "PHYSICIAN" },
                        new IdentityRole { Id = "fe2da004-84cf-4fb6-a1c4-b6d7f5bd621d", ConcurrencyStamp = "0c5fd051-0127-4451-9695-79a855fb5243", Name = "Patient", NormalizedName = "PATIENT" }
                    );

                    context.SaveChanges();
                }

                if (!context.UserRoles.Any())
                {
                    context.UserRoles.AddRange(
                        new IdentityUserRole<string> { UserId = "4bb7569f-a399-4d34-ae14-f90bc371f1f2", RoleId = "213b5870-c691-4f55-88a1-ceb8781248ac" },
                        new IdentityUserRole<string> { UserId = "f65d9caf-6ff2-445e-ba2c-dbbf3018ace1", RoleId = "213b5870-c691-4f55-88a1-ceb8781248ac" },
                        new IdentityUserRole<string> { UserId = "1a105dd3-7d8d-4e85-9509-cbcd043600c9", RoleId = "fe2da004-84cf-4fb6-a1c4-b6d7f5bd621d" },
                        new IdentityUserRole<string> { UserId = "41cbf6cc-90b8-46d1-8b79-d4fca4c53f88", RoleId = "fe2da004-84cf-4fb6-a1c4-b6d7f5bd621d" }
                    );

                    context.SaveChanges();
                }

                if (!context.Patient.Any())
                {
                    context.Patient.AddRange(
                        new Patient { Address1 = "1 All Roads Lead To Rome St", Address2 = "", City = "Rome", DateOfBirth = new DateTime(1980, 7, 13), Email = "caesar@rome.com", FirstName = "Julius", LastName = "Caesar", PhoneNumber = "2125558463", State = "RM", Zip = "71230-5543" },
                        new Patient { Address1 = "1 Nile Alley", Address2 = "", City = "Alexandria", DateOfBirth = new DateTime(1985, 11, 3), Email = "cleopatra@egypt.com", FirstName = "Cleopatra", LastName = "Philopator", PhoneNumber = "1195553762", State = "AX", Zip = "48217-2938" }
                    );

                    context.SaveChanges();
                }

                if (!context.Physician.Any())
                {
                    context.Physician.AddRange(
                        new Physician { Email = "hippocrates@oath.com", FirstName = "Hippocrates", LastName = "of Kos" },
                        new Physician { Email = "herophilos@anatomy.com", FirstName = "Herophilos", LastName = "of Chalcedon" }
                    );

                    context.SaveChanges();
                }

                if (!context.AppointmentPurpose.Any())
                {
                    context.AppointmentPurpose.AddRange(
                        new AppointmentPurpose { Purpose = "Battle Wound" },
                        new AppointmentPurpose { Purpose = "Broken Heart" },
                        new AppointmentPurpose { Purpose = "Betrayal" }
                    );

                    context.SaveChanges();
                }

                if (!context.Appointment.Any())
                {
                    context.Appointment.AddRange(
                        new Appointment { CancellationReason = "I don't like this doctor...", CreatedBy = "Patient", CreatedDateTime = new DateTime(2017, 6, 4, 19, 51, 19), DateAndTime = new DateTime(2017, 6, 7, 12, 0, 0), IsApproved = false, IsCanceled = true, PatientId = 2, PhysicianId = 1, PurposeId = 2 },
                        new Appointment { CancellationReason = null, CreatedBy = "Physician", CreatedDateTime = new DateTime(2017, 6, 4, 19, 53, 38), DateAndTime = new DateTime(2017, 6, 6, 10, 0, 0), IsApproved = false, IsCanceled = false, PatientId = 1, PhysicianId = 1, PurposeId = 1 },
                        new Appointment { CancellationReason = null, CreatedBy = "Patient", CreatedDateTime = new DateTime(2017, 6, 4, 20, 23, 05), DateAndTime = new DateTime(2017, 6, 9, 15, 15, 0), IsApproved = false, IsCanceled = false, PatientId = 1, PhysicianId = 1, PurposeId = 3 },
                        new Appointment { CancellationReason = null, CreatedBy = "Patient", CreatedDateTime = new DateTime(2017, 6, 4, 21, 41, 10), DateAndTime = new DateTime(2017, 6, 1, 12, 0, 0), IsApproved = false, IsCanceled = false, PatientId = 2, PhysicianId = 1, PurposeId = 3 },
                        new Appointment { CancellationReason = null, CreatedBy = "Patient", CreatedDateTime = new DateTime(2017, 6, 4, 21, 41, 59), DateAndTime = new DateTime(2017, 6, 14, 3, 0, 0), IsApproved = true, IsCanceled = false, PatientId = 2, PhysicianId = 1, PurposeId = 1 },
                        new Appointment { CancellationReason = null, CreatedBy = "Physician", CreatedDateTime = new DateTime(2017, 6, 4, 21, 18, 44), DateAndTime = new DateTime(2017, 6, 13, 12, 0, 0), IsApproved = false, IsCanceled = false, PatientId = 1, PhysicianId = 1, PurposeId = 1 },
                        new Appointment { CancellationReason = null, CreatedBy = "Physician", CreatedDateTime = new DateTime(2017, 6, 4, 21, 19, 11), DateAndTime = new DateTime(2017, 6, 15, 14, 0, 0), IsApproved = false, IsCanceled = false, PatientId = 2, PhysicianId = 1, PurposeId = 3 }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
