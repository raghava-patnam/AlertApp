using AlertApp.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace AlertApp.Database
{
    public class AppDBContext : DbContext
    {
        // add-migration InitCreate
        // update-database –verbose

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Reading> Readings { get; set; }
    }


    public class Plant
    {
        [Key]
        public int Id { get; set; }
        public string PlantName { get; set; }
    }

    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string Parmeters { get; set; }
        public double LowerThreshold { get; set; }
        public double UpperThreshold { get; set; }

        // [ForeignKey("Plant")]
        public int PlantId { get; set; }
        // public virtual Plant Plant { get; set; }

    }

    public class Reading
    {
        [Key]
        public int Id { get; set; }        
        public double UnitReading { get; set; }
        public DateTime Time { get; set; }
        // [ForeignKey("Device")]
        public int DeviceId { get; set; }
        // public virtual Device Device { get; set; }

    }
}




