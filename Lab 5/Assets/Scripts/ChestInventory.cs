using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : MonoBehaviour
{
   public int NumberOfChests { get; private set; }

    public UnityEvent<ChestInventory> OnChestCollected;


    public void ChestCollected()
    {
        NumberOfChests++;
        OnChestCollected.Invoke(this);
    }


}
