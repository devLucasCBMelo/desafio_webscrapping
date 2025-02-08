﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Context;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(FoodContext))]
    partial class FoodContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backend.Entities.Alimento", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Grupo")
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeCientifico")
                        .HasColumnType("longtext");

                    b.HasKey("Codigo");

                    b.ToTable("Alimentos");
                });

            modelBuilder.Entity("backend.Models.AcidosGraxosPoliinsaturadosModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("AcidosGraxosPoliinsaturados");
                });

            modelBuilder.Entity("backend.Models.AcidosGraxosSaturadosModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("AcidosGraxosSaturados");
                });

            modelBuilder.Entity("backend.Models.AcidosGraxosTransModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("AcidosGraxosTrans");
                });

            modelBuilder.Entity("backend.Models.AlcoolModels", b =>
                {
                    b.Property<string>("Cogido")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Alcool");
                });

            modelBuilder.Entity("backend.Models.CalcioModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Calcio");
                });

            modelBuilder.Entity("backend.Models.CarboidradoDisponivelModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("CarboidratoDisponivel");
                });

            modelBuilder.Entity("backend.Models.CarboidratoTotalModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("CarboidratoTotals");
                });

            modelBuilder.Entity("backend.Models.CinzasModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Cinzas");
                });

            modelBuilder.Entity("backend.Models.CobreModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Cobre");
                });

            modelBuilder.Entity("backend.Models.ColesterolModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Colesterol");
                });

            modelBuilder.Entity("backend.Models.EnergiaKJModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("EnergiaKJ");
                });

            modelBuilder.Entity("backend.Models.EnergiaKcalModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Energiakcal");
                });

            modelBuilder.Entity("backend.Models.FerroModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Ferro");
                });

            modelBuilder.Entity("backend.Models.FibraAlimentarModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("FibraAlimentar");
                });

            modelBuilder.Entity("backend.Models.FosforoModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Fosforo");
                });

            modelBuilder.Entity("backend.Models.LipidiosModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Lipidios");
                });

            modelBuilder.Entity("backend.Models.MagnesioModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Magnesio");
                });

            modelBuilder.Entity("backend.Models.ManganesModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Manganes");
                });

            modelBuilder.Entity("backend.Models.PotassioModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Potassio");
                });

            modelBuilder.Entity("backend.Models.ProteinaModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Proteinas");
                });

            modelBuilder.Entity("backend.Models.SelenioModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Selenio");
                });

            modelBuilder.Entity("backend.Models.SodioModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Sodio");
                });

            modelBuilder.Entity("backend.Models.UmidadeModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Umidade");
                });

            modelBuilder.Entity("backend.Models.ZincoModels", b =>
                {
                    b.Property<int>("Cogido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cogido"));

                    b.Property<string>("ColherSopaCheia45g")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoDuplo200ml")
                        .HasColumnType("longtext");

                    b.Property<string>("CopoAmericanoPequeno130ml")
                        .HasColumnType("longtext");

                    b.Property<string>("PedacoUnidadeFatia")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoFundo450g")
                        .HasColumnType("longtext");

                    b.Property<string>("PratoRaso350g")
                        .HasColumnType("longtext");

                    b.Property<string>("Unidades")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("longtext");

                    b.HasKey("Cogido");

                    b.ToTable("Zinco");
                });
#pragma warning restore 612, 618
        }
    }
}
