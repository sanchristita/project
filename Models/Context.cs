using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class Context : DbContext
    {
        //public dbset<loginsmodel> logins { get; set; }

        public DbSet<AccountModel> UserAccounts { get; set; }

        public DbSet<ChemicalsModel> Chemicals { get; set; }
        public DbSet<ChemicalsInventoryModel> ChemicalsInventory { get; set; }
        public DbSet<UsedListsModel> UsedLists { get; set; }
        public DbSet<OrderDefectChemicalsModel> OrderDefectChemicals { get; set; }
        public DbSet<WasteManagementModel> WasteManagements { get; set; }

        public DbSet<EquipmentsModel> Equipments { get; set; }
        public DbSet<EquipmentsInventoryModel> EquipmentsInventory { get; set; }
        public DbSet<BrokeListsModel> BrokeLists { get; set; }
        public DbSet<OrderDefectEquipmentsModel> OrderDefectEquipments { get; set; }

        public DbSet<StudentsModel> Students { get; set; }

        public DbSet<ClaimsModel> Claims { get; set; }
        
        public DbSet<PracticalsModel> Practicals { get; set; }

        
    }
}

