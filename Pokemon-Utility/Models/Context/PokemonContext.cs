using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pokemon_Utility.Models.Entity;

namespace Pokemon_Utility.Models.Context;

public partial class PokemonContext : DbContext
{
    public PokemonContext()
    {
    }

    public PokemonContext(DbContextOptions<PokemonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonAbility> PokemonAbilities { get; set; }

    public virtual DbSet<PokemonMove> PokemonMoves { get; set; }

    public virtual DbSet<PokemonStat> PokemonStats { get; set; }

    public virtual DbSet<PokemonType> PokemonTypes { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamPokemon> TeamPokemons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:pokedataserver.database.windows.net,1433;Initial Catalog=POKEDATA;uid=client;pwd=Wasd1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=10;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Move>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("move_pk");

            entity.ToTable("move");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Accuracy).HasColumnName("accuracy");
            entity.Property(e => e.Class)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.Pp).HasColumnName("pp");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Type)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pokemon_pk");

            entity.ToTable("pokemon");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CaptureRate).HasColumnName("capture_rate");
            entity.Property(e => e.EvolvesFromSpeciesId).HasColumnName("evolves_from_species_id");
            entity.Property(e => e.GenderRate).HasColumnName("gender_rate");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.EvolvesFromSpecies).WithMany(p => p.InverseEvolvesFromSpecies)
                .HasForeignKey(d => d.EvolvesFromSpeciesId)
                .HasConstraintName("pokemon_pokemon_id_fk");
        });

        modelBuilder.Entity<PokemonAbility>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pokemon_ability");

            entity.Property(e => e.AbilityName)
                .IsUnicode(false)
                .HasColumnName("ability_name");
            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

            entity.HasOne(d => d.Pokemon).WithMany()
                .HasForeignKey(d => d.PokemonId)
                .HasConstraintName("pokemon_ability_pokemon_id_fk");
        });

        modelBuilder.Entity<PokemonMove>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pokemon_move");

            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Method)
                .IsUnicode(false)
                .HasColumnName("method");
            entity.Property(e => e.MoveId).HasColumnName("move_id");
            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

            entity.HasOne(d => d.Move).WithMany()
                .HasForeignKey(d => d.MoveId)
                .HasConstraintName("pokemon_move_move_id_fk");

            entity.HasOne(d => d.Pokemon).WithMany()
                .HasForeignKey(d => d.PokemonId)
                .HasConstraintName("pokemon_move_pokemon_id_fk");
        });

        modelBuilder.Entity<PokemonStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pokemon_stat");

            entity.Property(e => e.BaseStat).HasColumnName("base_stat");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

            entity.HasOne(d => d.Pokemon).WithMany()
                .HasForeignKey(d => d.PokemonId)
                .HasConstraintName("pokemon_stat_pokemon_id_fk");
        });

        modelBuilder.Entity<PokemonType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pokemon_type");

            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");
            entity.Property(e => e.Slot).HasColumnName("slot");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("team_pk");

            entity.ToTable("team");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Format)
                .IsUnicode(false)
                .HasColumnName("format");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TeamPokemon>(entity =>
        {
            entity.HasKey(e => e.MovesetId).HasName("pokemonteam_move_pk");

            entity.ToTable("team_pokemon");

            entity.Property(e => e.MovesetId).HasColumnName("moveset_id");
            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.TeamPokemons)
                .HasForeignKey(d => d.PokemonId)
                .HasConstraintName("team_pokemon_pokemon_id_fk");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamPokemons)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("team_pokemon_team_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
