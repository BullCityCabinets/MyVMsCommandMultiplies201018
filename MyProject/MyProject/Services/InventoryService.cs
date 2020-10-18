using MyProject.Models;
using System.Collections.Generic;

namespace MyProject.Service
{
    //This class only loads the default inventory data to poulate the initial menu.

    public class InventoryService  
    {
        public static List<Inventory> Warehouse = new List<Inventory>();

        public List<Inventory> GetAllInventory()
        {
            if (Warehouse.Count == 0)
            {
                Warehouse.Add(new Inventory { Id = 1, Condition = Condition.BrandNew, Name = "First Object" });
                Warehouse.Add(new Inventory { Id = 2, Condition = Condition.BrandNew, Name = "Second Object" });
                Warehouse.Add(new Inventory { Id = 3, Condition = Condition.Refurbished, Name = "Third Object" });
                Warehouse.Add(new Inventory { Id = 4, Condition = Condition.Refurbished, Name = "Fourth Object" });
                Warehouse.Add(new Inventory { Id = 5, Condition = Condition.AsIs, Name = "Fifth Object" });

                Warehouse.Add(new Inventory { Id = 6, Condition = Condition.BrandNew, Name = "Sixth Object" });
                Warehouse.Add(new Inventory { Id = 7, Condition = Condition.BrandNew, Name = "Seventh Object" });
                Warehouse.Add(new Inventory { Id = 8, Condition = Condition.Refurbished, Name = "Eigth Object" });
                Warehouse.Add(new Inventory { Id = 9, Condition = Condition.Refurbished, Name = "Nineth Object" });
                Warehouse.Add(new Inventory { Id = 10, Condition = Condition.AsIs, Name = "Tenth Object" });

                Warehouse.Add(new Inventory { Id = 11, Condition = Condition.BrandNew, Name = "Eleventh Object" });
                Warehouse.Add(new Inventory { Id = 12, Condition = Condition.BrandNew, Name = "Twelfth Object" });
                Warehouse.Add(new Inventory { Id = 13, Condition = Condition.Refurbished, Name = "Thirteenth Object" });
                Warehouse.Add(new Inventory { Id = 14, Condition = Condition.Refurbished, Name = "Fourteenth Object" });
                Warehouse.Add(new Inventory { Id = 15, Condition = Condition.AsIs, Name = "Fifteenth Object" });


                return Warehouse;
            }
            else
            {
                return Warehouse;
            }



        }



    }
}
