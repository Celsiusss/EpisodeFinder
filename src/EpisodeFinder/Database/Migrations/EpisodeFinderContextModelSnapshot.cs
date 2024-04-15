﻿// <auto-generated />
using EpisodeFinder.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EpisodeFinder.Database.Migrations
{
    [DbContext(typeof(EpisodeFinderContext))]
    partial class EpisodeFinderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("EpisodeFinder.Database.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlexRatingKey")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("EpisodeFinder.Database.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlexRatingKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("SeasonName")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeriesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("EpisodeFinder.Database.Entities.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImdbId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlexRatingKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TmdbId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("EpisodeFinder.Database.Entities.Episode", b =>
                {
                    b.HasOne("EpisodeFinder.Database.Entities.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("EpisodeFinder.Database.Entities.Season", b =>
                {
                    b.HasOne("EpisodeFinder.Database.Entities.Series", "Series")
                        .WithMany("Seasons")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("EpisodeFinder.Database.Entities.Series", b =>
                {
                    b.Navigation("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
