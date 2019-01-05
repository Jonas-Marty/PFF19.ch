﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pff19.DataAccess;

namespace pff19.DataAccess.Migrations
{
    [DbContext(typeof(PffContext))]
    [Migration("20190105162610_NewFieldsForBands")]
    partial class NewFieldsForBands
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("pff19.DataAccess.Models.Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Pfadiname");

                    b.Property<string>("Vorname")
                        .IsRequired();

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

                    b.Property<string>("Facebook");

                    b.Property<string>("ImageLarge");

                    b.Property<string>("ImageThumbnail");

                    b.Property<string>("Instagram");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<DateTime>("PlayTime");

                    b.Property<string>("SpotifyPlaylist");

                    b.Property<string>("WebSiteUrl");

                    b.Property<string>("YoutubeUrls");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.BandRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("ReferenceToScout");

                    b.HasKey("Id");

                    b.ToTable("BandRequests");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.ContactRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Mail")
                        .IsRequired();

                    b.Property<DateTime?>("SubmitedAt");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ContactRequests");
                });

            modelBuilder.Entity("pff19.DataAccess.Models.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerDe");

                    b.Property<string>("AnswerFr");

                    b.Property<string>("Category");

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

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Images");

                    b.Property<string>("LinkFacebook");

                    b.Property<string>("LinkInstagram");

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

                    b.Property<DateTime>("CreatedAt");

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
