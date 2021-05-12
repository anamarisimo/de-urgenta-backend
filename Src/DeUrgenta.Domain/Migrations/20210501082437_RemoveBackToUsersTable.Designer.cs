﻿// <auto-generated />
using System;
using DeUrgenta.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeUrgenta.Domain.Migrations
{
    [DbContext(typeof(DeUrgentaContext))]
    [Migration("20210501082437_RemoveBackToUsersTable")]
    partial class RemoveBackToUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Backpack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AdminUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id")
                        .HasName("PK_Backpack");

                    b.HasIndex("AdminUserId");

                    b.ToTable("Backpacks");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.BackpackItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<int>("BackpackCategory")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id")
                        .HasName("PK_BackpackItem");

                    b.ToTable("BackpackItem");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ContentBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id")
                        .HasName("PK_BlogPost");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Certification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IssuingAuthority")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Certification");

                    b.HasIndex("UserId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ContentBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OccursOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OrganizedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id")
                        .HasName("PK_Event");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid?>("SafeLocation1Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SafeLocation2Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Group");

                    b.HasIndex("AdminId");

                    b.HasIndex("SafeLocation1Id");

                    b.HasIndex("SafeLocation2Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.GroupInvite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvitationReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvitationSenderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Group_invite");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("IX_GroupInvite_Group");

                    b.HasIndex("InvitationReceiverId")
                        .HasDatabaseName("IX_GroupInvite_InvitationReceiver");

                    b.HasIndex("InvitationSenderId")
                        .HasDatabaseName("IX_GroupInvite_InvitationSender");

                    b.HasIndex("GroupId", "InvitationReceiverId", "InvitationSenderId")
                        .IsUnique()
                        .HasDatabaseName("IX_GroupInvite");

                    b.ToTable("GroupInvites");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.GroupSafeLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id")
                        .HasName("PK_GroupSafeLocation");

                    b.ToTable("GroupsSafeLocations");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Sub")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Latitude")
                        .HasMaxLength(100)
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_UserAddress");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.UserToGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_UserToGroup");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("IX_UserToGroup_Group");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_UserToGroup_User");

                    b.HasIndex("UserId", "GroupId")
                        .IsUnique()
                        .HasDatabaseName("IX_UserToGroup");

                    b.ToTable("UsersToGroups");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Backpack", b =>
                {
                    b.HasOne("DeUrgenta.Domain.Entities.User", "AdminUser")
                        .WithMany("Backpacks")
                        .HasForeignKey("AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminUser");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Certification", b =>
                {
                    b.HasOne("DeUrgenta.Domain.Entities.User", "User")
                        .WithMany("Certifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_User_Certification")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Group", b =>
                {
                    b.HasOne("DeUrgenta.Domain.Entities.User", "Admin")
                        .WithMany("GroupsAdministered")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeUrgenta.Domain.Entities.GroupSafeLocation", "SafeLocation1")
                        .WithMany()
                        .HasForeignKey("SafeLocation1Id");

                    b.HasOne("DeUrgenta.Domain.Entities.GroupSafeLocation", "SafeLocation2")
                        .WithMany()
                        .HasForeignKey("SafeLocation2Id");

                    b.Navigation("Admin");

                    b.Navigation("SafeLocation1");

                    b.Navigation("SafeLocation2");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.GroupInvite", b =>
                {
                    b.HasOne("DeUrgenta.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_GroupInvite_Group")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeUrgenta.Domain.Entities.User", "InvitationReceiver")
                        .WithMany()
                        .HasForeignKey("InvitationReceiverId")
                        .HasConstraintName("FK_GroupInvite_InvitationReceiver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeUrgenta.Domain.Entities.User", "InvitationSender")
                        .WithMany()
                        .HasForeignKey("InvitationSenderId")
                        .HasConstraintName("FK_GroupInvite_InvitationSender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("InvitationReceiver");

                    b.Navigation("InvitationSender");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.UserAddress", b =>
                {
                    b.HasOne("DeUrgenta.Domain.Entities.User", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.UserToGroup", b =>
                {
                    b.HasOne("DeUrgenta.Domain.Entities.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_UserToGroup_Group")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeUrgenta.Domain.Entities.User", "User")
                        .WithMany("GroupsMember")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserToGroup_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupMembers");
                });

            modelBuilder.Entity("DeUrgenta.Domain.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Backpacks");

                    b.Navigation("Certifications");

                    b.Navigation("GroupsAdministered");

                    b.Navigation("GroupsMember");
                });
#pragma warning restore 612, 618
        }
    }
}
