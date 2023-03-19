using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ChestInventory chestInventory = other.GetComponent<ChestInventory>();

            if (chestInventory != null)
        {
            chestInventory.ChestCollected();
            gameObject.SetActive(false);
        }
    }

}
