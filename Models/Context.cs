using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class Context:DbContext
    {
        public DbSet<ChemicalsModel> Chemicals { get; set; }
        public DbSet<EquipmentsModel> Equipments { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<ClaimsModel> Claims { get; set; }
        public DbSet<ChemicalsInventoryModel> ChemicalsInventory { get; set; }
        public DbSet<EquipmentsInventoryModel> EquipmentsInventory { get; set; }
        public DbSet<PracticalModel> Practicals { get; set; }
    }
}