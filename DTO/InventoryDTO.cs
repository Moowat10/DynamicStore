using DynamicStore.Models;

namespace DynamicStore.DTO
{
    namespace DynamicStore.DTOs
    {
        public class InventoryDTO
        {
            public int InventoryId { get; set; }
            public int ProductId { get; set; }
            public int WarehouseId { get; set; }
            public int InventoryQuantity { get; set; }
            public int InventoryAlertQuantity { get; set; }

            public static InventoryDTO ToInventoryDTO(Inventory inventory)
            {
                return new InventoryDTO
                {
                    InventoryId = inventory.InventoryId,
                    ProductId = inventory.ProductId,
                    WarehouseId = inventory.WarehouseId,
                    InventoryQuantity = inventory.InventoryQuantity,
                    InventoryAlertQuantity = inventory.InventoryAlertQuantity
                };
            }

            public static List<InventoryDTO> ToInventoryDTOList(List<Inventory> inventory)
            {
                return inventory.Select(i => ToInventoryDTO(i)).ToList();
            }

            public static Inventory ToInventory(InventoryDTO InventoryDTO)
            {
                return new Inventory
                {
                    ProductId = InventoryDTO.ProductId,
                    WarehouseId = InventoryDTO.WarehouseId,
                    InventoryQuantity = InventoryDTO.InventoryQuantity,
                    InventoryAlertQuantity = InventoryDTO.InventoryAlertQuantity
                };
            }

            public static void UpdateInventoryFromDto(InventoryDTO InventoryDTO, Inventory inventory)
            {
                inventory.ProductId = InventoryDTO.ProductId;
                inventory.WarehouseId = InventoryDTO.WarehouseId;
                inventory.InventoryQuantity = InventoryDTO.InventoryQuantity;
                inventory.InventoryAlertQuantity = InventoryDTO.InventoryAlertQuantity;
            }
        }
    }

}
