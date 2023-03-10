// <auto-generated />
using Boxers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Boxers.Migrations
{
    [DbContext(typeof(BoxerDbContext))]
    [Migration("20230301160136_FullNameonTrainer")]
    partial class FullNameonTrainer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Boxers.Entities.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoxerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoxerId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Boxers.Entities.Boxer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<int>("Losts")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId")
                        .IsUnique();

                    b.ToTable("Boxers");
                });

            modelBuilder.Entity("Boxers.Entities.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Boxers.Entities.Achievement", b =>
                {
                    b.HasOne("Boxers.Entities.Boxer", "Boxer")
                        .WithMany("Achievements")
                        .HasForeignKey("BoxerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boxer");
                });

            modelBuilder.Entity("Boxers.Entities.Boxer", b =>
                {
                    b.HasOne("Boxers.Entities.Trainer", "Trainer")
                        .WithOne("Boxer")
                        .HasForeignKey("Boxers.Entities.Boxer", "TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Boxers.Entities.Boxer", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("Boxers.Entities.Trainer", b =>
                {
                    b.Navigation("Boxer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
