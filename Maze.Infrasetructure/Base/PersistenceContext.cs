using Maze.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Maze.Infrasetructure.Base
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration Config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<MazeBase> MazeBase { get; set; }

        public virtual DbSet<Cell> Cell { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Cell>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Col).IsRequired();
                entity.Property(e => e.Row).IsRequired();
                entity.Property(e => e.southWall);
                entity.Property(e => e.northWall);
                entity.Property(e => e.eastWall);
                entity.Property(e => e.westWall);
                entity.Property(e => e.Visited);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.MazeUid).IsRequired();
                entity.Property(e => e.GameUid);

            });
            modelBuilder.Entity<MazeBase>(entity =>
            {
           
                entity.HasKey(e => e.MazeUid);
                entity.Property(e => e.MazeUid).IsRequired();
                entity.Property(e => e.Width);
                entity.Property(e => e.Height);
             });

            base.OnModelCreating(modelBuilder);
        }
    }
}
