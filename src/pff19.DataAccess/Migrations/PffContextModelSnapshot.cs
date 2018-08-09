﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pff19.DataAccess;

namespace pff19.DataAccess.Migrations
{
    [DbContext(typeof(PffContext))]
    partial class PffContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("pff19.DataAccess.Models.Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Pfadiname");

                    b.Property<string>("Vorname");

                    b.Property<string>("Wishes");

                    b.HasKey("Id");

                    b.ToTable("Assistants");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionDe");

                    b.Property<string>("DescriptionFr");

                    b.Property<string>("Mail");

                    b.Property<string>("Phone");

                    b.Property<string>("ReferenceToScout");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerDe");

                    b.Property<string>("AnswerFr");

                    b.Property<int>("Category");

                    b.Property<int>("Order");

                    b.Property<string>("QuestionDe");

                    b.Property<string>("QuestionFr");

                    b.HasKey("Id");

                    b.ToTable("Faqs");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentDe");

                    b.Property<string>("ContentFr");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Image");

                    b.Property<string>("PreviewDe");

                    b.Property<string>("PreviewFr");

                    b.Property<string>("TitleDe");

                    b.Property<string>("TitleFr");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<string>("Ressort");

                    b.Property<byte[]>("Salt");

                    b.Property<string>("ScoutName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
