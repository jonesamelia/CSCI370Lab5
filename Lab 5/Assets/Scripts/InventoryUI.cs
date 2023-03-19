using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI chestText;
    // Start is called before the first frame update
    void Start()
    {
        chestText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateChestText(ChestInventory chestInventory)
    {
        chestText.text = chestInventory.NumberOfChests.ToString();
    }
}
