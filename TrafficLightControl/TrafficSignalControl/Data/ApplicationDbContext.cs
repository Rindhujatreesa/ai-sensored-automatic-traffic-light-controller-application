using Microsoft.EntityFrameworkCore;
using TrafficSignalControl.Models;

namespace TrafficSignalControl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TrafficSensor> TrafficSensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TrafficLightControl;User Id=sa;Password=sqlsever@2019;TrustServerCertificate=True;");
        }
    }
}