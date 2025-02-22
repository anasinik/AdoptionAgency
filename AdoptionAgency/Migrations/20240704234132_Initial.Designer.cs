﻿// <auto-generated />
using System;
using AdoptionAgency.Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdoptionAgency.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240704234132_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.AdoptionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdopterId")
                        .HasColumnType("integer");

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FosterUntil")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdopterId");

                    b.HasIndex("AnimalId");

                    b.ToTable("AdoptionRequest", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Adopted")
                        .HasColumnType("boolean");

                    b.Property<string>("Behaviour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FoundLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("HealthCondition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.AnimalRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdoptionId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdoptionId");

                    b.ToTable("AnimalRating", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.AnimalSpecies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AnimalSpecies", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Person.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Post.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Picture", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Post.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("PersonId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.AdoptionRequest", b =>
                {
                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Person.Person", "Adopter")
                        .WithMany()
                        .HasForeignKey("AdopterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Animal.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adopter");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.Animal", b =>
                {
                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Animal.AnimalSpecies", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Animal.AnimalRating", b =>
                {
                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Animal.AdoptionRequest", "Adoption")
                        .WithMany()
                        .HasForeignKey("AdoptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adoption");
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Person.Person", b =>
                {
                    b.OwnsOne("AdoptionAgency.Backend.Domain.Model.User.User", "User", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .HasColumnType("integer");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Password");

                            b1.Property<int>("Status")
                                .HasColumnType("integer")
                                .HasColumnName("Status");

                            b1.Property<int>("Type")
                                .HasColumnType("integer")
                                .HasColumnName("Type");

                            b1.Property<string>("Username")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Username");

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Post.Picture", b =>
                {
                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Post.Post", null)
                        .WithMany("Pictures")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Post.Post", b =>
                {
                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Animal.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdoptionAgency.Backend.Domain.Model.Person.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AdoptionAgency.Backend.Domain.Model.Post.Post", b =>
                {
                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
