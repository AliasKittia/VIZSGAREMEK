﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tftwebapi.Data;

#nullable disable

namespace tftwebapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250303063605_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("tftwebapi.Models.PostAnomalies", b =>
                {
                    b.Property<int>("AnomalyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnomalyEffect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AnomalyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AnomalyId");

                    b.ToTable("Anomalies");
                });

            modelBuilder.Entity("tftwebapi.Models.PostAugments", b =>
                {
                    b.Property<int>("AugmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AugmentEffect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AugmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AugmentRarity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AugmentId");

                    b.ToTable("Augments");
                });

            modelBuilder.Entity("tftwebapi.Models.PostCharacter", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ability")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AbilityPower")
                        .HasColumnType("int");

                    b.Property<int>("Armor")
                        .HasColumnType("int");

                    b.Property<double>("AttackSpeed")
                        .HasColumnType("double");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Characterimageblob")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Damage1")
                        .HasColumnType("int");

                    b.Property<int>("Damage2")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Health1")
                        .HasColumnType("int");

                    b.Property<int>("Health2")
                        .HasColumnType("int");

                    b.Property<int>("MagicResist")
                        .HasColumnType("int");

                    b.Property<int>("ManaMax")
                        .HasColumnType("int");

                    b.Property<int>("ManaStart")
                        .HasColumnType("int");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("tftwebapi.Models.PostCharacterClass", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ClassId");

                    b.ToTable("CharacterClass");
                });

            modelBuilder.Entity("tftwebapi.Models.PostClass", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BasicEffect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClassId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("tftwebapi.Models.PostClassLvlBonus", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("BonusEffect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CharacterCount")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "Level");

                    b.ToTable("ClassLevelBonus");
                });

            modelBuilder.Entity("tftwebapi.Models.PostFullItem_PartialItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FullItemId")
                        .HasColumnType("int");

                    b.Property<int>("PartialItemId1")
                        .HasColumnType("int");

                    b.Property<int>("PartialItemId2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FullItems_PartialItems");
                });

            modelBuilder.Entity("tftwebapi.Models.PostFullItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActiveEffect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Halfitemeffect1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Halfitemeffect2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("bonuseffect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("bonuseffect1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("bonuseffect2")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FullItems");
                });

            modelBuilder.Entity("tftwebapi.Models.PostPartialItems", b =>
                {
                    b.Property<int>("partial_item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("effect")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("partial_item_id");

                    b.ToTable("PartialItems");
                });
#pragma warning restore 612, 618
        }
    }
}
