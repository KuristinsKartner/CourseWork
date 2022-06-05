﻿// <auto-generated />
using System;
using Correspondence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Correspondence.Migrations
{
    [DbContext(typeof(CorrespContext))]
    [Migration("20220209210142_Change")]
    partial class Change
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Correspondence.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "i_author")
                        .IsUnique();

                    b.ToTable("author");
                });

            modelBuilder.Entity("Correspondence.Models.Dtype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "name")
                        .IsUnique();

                    b.ToTable("dtype");
                });

            modelBuilder.Entity("Correspondence.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "i_event")
                        .IsUnique();

                    b.ToTable("event");
                });

            modelBuilder.Entity("Correspondence.Models.Files", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<byte[]>("FormatData")
                        .HasColumnType("longblob")
                        .HasColumnName("format_data");

                    b.Property<string>("FormatExtension")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("format_extension");

                    b.Property<long?>("FormatLength")
                        .HasColumnType("bigint")
                        .HasColumnName("format_length");

                    b.Property<string>("FormatName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("format_name");

                    b.Property<byte[]>("ScanData")
                        .HasColumnType("longblob")
                        .HasColumnName("scan_data");

                    b.Property<string>("ScanExtension")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("scan_extension");

                    b.Property<long?>("ScanLength")
                        .HasColumnType("bigint")
                        .HasColumnName("scan_length");

                    b.Property<string>("ScanName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("scan_name");

                    b.Property<byte[]>("SverstData")
                        .HasColumnType("longblob")
                        .HasColumnName("sverst_data");

                    b.Property<string>("SverstExtension")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("sverst_extension");

                    b.Property<long?>("SverstLength")
                        .HasColumnType("bigint")
                        .HasColumnName("sverst_length");

                    b.Property<string>("SverstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sverst_name");

                    b.HasKey("Id");

                    b.ToTable("files");
                });

            modelBuilder.Entity("Correspondence.Models.Main", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("comments");

                    b.Property<int?>("Day")
                        .HasColumnType("int")
                        .HasColumnName("day");

                    b.Property<bool?>("FDate")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("f_date");

                    b.Property<string>("Folder")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("folder");

                    b.Property<int?>("IdAuthor")
                        .HasColumnType("int")
                        .HasColumnName("id_author");

                    b.Property<int?>("IdDtype")
                        .HasColumnType("int")
                        .HasColumnName("id_dtype");

                    b.Property<int?>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("id_event");

                    b.Property<int>("IdFiles")
                        .HasColumnType("int")
                        .HasColumnName("id_files");

                    b.Property<int>("IdPlace")
                        .HasColumnType("int")
                        .HasColumnName("id_place");

                    b.Property<int?>("IdSubevent")
                        .HasColumnType("int")
                        .HasColumnName("id_subevent");

                    b.Property<int?>("IdSubtheme")
                        .HasColumnType("int")
                        .HasColumnName("id_subtheme");

                    b.Property<int?>("IdTheme")
                        .HasColumnType("int")
                        .HasColumnName("id_theme");

                    b.Property<int?>("Month")
                        .HasColumnType("int")
                        .HasColumnName("month");

                    b.Property<bool>("NoPublic")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("no_public");

                    b.Property<int?>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdAuthor" }, "id_author");

                    b.HasIndex(new[] { "IdDtype" }, "id_dtype");

                    b.HasIndex(new[] { "IdEvent" }, "id_event");

                    b.HasIndex(new[] { "IdFiles" }, "id_files");

                    b.HasIndex(new[] { "IdPlace" }, "id_place");

                    b.HasIndex(new[] { "IdSubevent" }, "id_subevent");

                    b.HasIndex(new[] { "IdSubtheme" }, "id_subtheme");

                    b.HasIndex(new[] { "IdTheme" }, "id_theme");

                    b.ToTable("main");
                });

            modelBuilder.Entity("Correspondence.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("FullPlace")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("full_place");

                    b.Property<string>("House")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("house");

                    b.Property<string>("Owner")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("owner");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FullPlace" }, "i_place")
                        .IsUnique();

                    b.ToTable("place");
                });

            modelBuilder.Entity("Correspondence.Models.Subevent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "i_subevent")
                        .IsUnique();

                    b.ToTable("subevent");
                });

            modelBuilder.Entity("Correspondence.Models.Subtheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "i_subtheme")
                        .IsUnique();

                    b.ToTable("subtheme");
                });

            modelBuilder.Entity("Correspondence.Models.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "i_theme")
                        .IsUnique();

                    b.ToTable("theme");
                });

            modelBuilder.Entity("Correspondence.Models.Main", b =>
                {
                    b.HasOne("Correspondence.Models.Author", "IdAuthorNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdAuthor")
                        .HasConstraintName("main_ibfk_1")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Correspondence.Models.Dtype", "IdDtypeNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdDtype")
                        .HasConstraintName("main_ibfk_7")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Correspondence.Models.Event", "IdEventNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("main_ibfk_2")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Correspondence.Models.Files", "IdFilesNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdFiles")
                        .HasConstraintName("main_ibfk_8")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Correspondence.Models.Place", "IdPlaceNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdPlace")
                        .HasConstraintName("main_ibfk_6")
                        .IsRequired();

                    b.HasOne("Correspondence.Models.Subevent", "IdSubeventNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdSubevent")
                        .HasConstraintName("main_ibfk_3")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Correspondence.Models.Subtheme", "IdSubthemeNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdSubtheme")
                        .HasConstraintName("main_ibfk_4")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Correspondence.Models.Theme", "IdThemeNavigation")
                        .WithMany("Mains")
                        .HasForeignKey("IdTheme")
                        .HasConstraintName("main_ibfk_5")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("IdAuthorNavigation");

                    b.Navigation("IdDtypeNavigation");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdFilesNavigation");

                    b.Navigation("IdPlaceNavigation");

                    b.Navigation("IdSubeventNavigation");

                    b.Navigation("IdSubthemeNavigation");

                    b.Navigation("IdThemeNavigation");
                });

            modelBuilder.Entity("Correspondence.Models.Author", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Dtype", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Event", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Files", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Place", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Subevent", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Subtheme", b =>
                {
                    b.Navigation("Mains");
                });

            modelBuilder.Entity("Correspondence.Models.Theme", b =>
                {
                    b.Navigation("Mains");
                });
#pragma warning restore 612, 618
        }
    }
}
