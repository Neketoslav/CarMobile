using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class InventoryController : BaseController, IInventoryController
{
    private readonly ResourcesPath _viewPath = new ResourcesPath() { PathResources = "Prefabs/Inventory" };
    private readonly ResourcesPath _slotViewPath = new ResourcesPath() { PathResources = "Prefabs/Slot" };

    private readonly IInventoryModel _inventoryModel;
    private readonly InventoryView _inventoryView;
    private readonly IItemsRepository _itemsRepository;

    private readonly Dictionary<int, IItem> _items;

    private Transform _placeForUi;
    public InventoryController(Transform placeForUi, List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _placeForUi = placeForUi;

        var _windowInterface = Object.Instantiate(ResourcesLoader.LoadPrefab(_viewPath), placeForUi, false);
    }

    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventoryModel.EquipItem(item);

        var equippedItem = _inventoryModel.GetEquippedItems();
        _inventoryView.Display(equippedItem);


        foreach (var item in equippedItem)
        {           
            var itemView = ShowItem(_inventoryView._itemsSlot);
            itemView.Init(item);
        }

    }
    private SlotView ShowItem(Transform spawnPosition)
    {
        
        var objectView = Object.Instantiate(ResourcesLoader.LoadPrefab(_slotViewPath), spawnPosition, false);
        objectView.TryGetComponent<SlotView>(out var slotView);

        return slotView;
    }


    protected override void OnDispose()
    {
        _items.Clear();
    }
}



