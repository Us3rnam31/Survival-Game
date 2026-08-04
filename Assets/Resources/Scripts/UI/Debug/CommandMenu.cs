using TMPro;
using UnityEngine;

public class CommandMenu : MonoBehaviour
{
    public ItemList itemList;
    public TMP_InputField inputField;
    public InventoryManager inventory;
    public HealthBar health;
    public Foodbar foodBar;
    public Waterbar waterBar;
    public CraftingManager craftingManager;
    public Death death;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            runCommand();

            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    public void runCommand()
    {
        string input = inputField.text.Trim();
        if (string.IsNullOrEmpty(input)) return;

        string[] args = input.Split(' ');
        string command = args[0].ToLower();

        switch (command)
        {
            case "/death":
                killPlayer();
                break;

            case "/revive":
                revive();
                break;

            case "/damage":
                damagePlayer(args);
                break;

            case "/heal":
                healPlayer(args);
                break;

            case "/give":
                give(args);
                break;

            case "/food":
                if (args.Length >= 2) food(args);
                break;

            case "/water":
                if (args.Length >= 2) water(args);
                break;
        }
    }

    public void killPlayer()
    {
        death.dead = true;
    }

    public void damagePlayer(string[] args)
    {
        if (args.Length > 1)
        {
            float.TryParse(args[1], out float damage);
            health.damage(damage);
        }
    }

    public void healPlayer(string[] args)
    {
        if (args.Length >= 2)
        {
            int.TryParse(args[1], out int hp);
            health.currentHealth += hp;
        }
        else
        {
            health.currentHealth = health.maxHealth;
        }
    }

    public void give(string[] args)
    {
        if (args.Length < 2) return;

        ItemData targetItem = null;

        foreach (ItemData item in itemList.itemList)
        {
            if (item.itemName.ToLower() == args[1].ToLower())
            {
                targetItem = item;
                break;
            }
        }

        if (targetItem != null)
        {
            int amount = 1;

            if (args.Length >= 3)
                int.TryParse(args[2], out amount);

            inventory.AddItem(targetItem, amount);

            if (targetItem.ItemType == ItemType.backpack)
            {
                inventory.RemoveItem(targetItem, 1);
                inventory.AddInventorySlots(targetItem.maxStorage);
                craftingManager.hasBackpack = true;
            }
        }
    }

    public void food(string[] args)
    {
        string subCommand = args[1].ToLower();

        switch (subCommand)
        {
            case "add":
                if (args.Length >= 3 && float.TryParse(args[2], out float addHunger))
                    foodBar.addFood(addHunger);
                break;

            case "remove":
                if (args.Length >= 3 && float.TryParse(args[2], out float removeHunger))
                    foodBar.removeFood(removeHunger);
                break;

            case "full":
                foodBar.currentFood = foodBar.totalFood;
                break;
        }
    }

    public void water(string[] args)
    {
        string subCommand = args[1].ToLower();

        switch (subCommand)
        {
            case "add":
                if (args.Length >= 3 && float.TryParse(args[2], out float addWater))
                    waterBar.addWater(addWater);
                break;

            case "remove":
                if (args.Length >= 3 && float.TryParse(args[2], out float removeWater))
                    waterBar.removeWater(removeWater);
                break;

            case "full":
                waterBar.currentWater = waterBar.totalWater;
                break;
        }
    }

    public void revive()
    {
        death.dead = false;
    }
}
