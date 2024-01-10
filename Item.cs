using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    
    [SerializeField]
    private int quantity;
    
    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string ItemDescription;

    [SerializeField]
    private bool pickupable;

    private InventoryManager inventoryManager;
    TextMeshProUGUI interaction_text;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); //Grabbing the inventory manager script from InventoryCanvas
        interaction_text = GameObject.Find("interaction_Info_UI").GetComponent<TextMeshProUGUI>(); //Grabbing the TMP from Game Object Interaction_info_ui
    
    }

    void Update()
    {
        //interaction_text.text.ToString() == itemName
        //If "e" is pressed, AND if onTarget is true, AND if the displayed selection manager text is the SAME as the item name (to prevent multiple pick up) AND if item is able to be picked up.
        if(pickupable)
        {
            if(Input.GetKeyDown(KeyCode.E) && SelectionManager.instance.onTarget && SelectionManager.instance.currentInteractable == this) 
                {
                    Debug.Log("Attempting to pick up: " + itemName);
                    int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, ItemDescription);
                    if (leftOverItems <= 0)
                    {
                        Destroy(gameObject);
                    }
                    else {
                        quantity = leftOverItems;
                    }
                }
        }
        
    }
    
    public string GetItemName()
    {
        return itemName;
    }
    // Update is called once per frame
    // private void OnCollisonEnter2D(Collision2D collision)
    // {
        
    // }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         inventoryManager.AddItem(itemName, quantity, sprite, ItemDescription);
    //         Destroy(gameObject);  // Destroy the GameObject containing the item prefab
    //     }
    // }
    // private void OnCollisonEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         inventoryManager.AddItem(itemName, quantity, sprite, ItemDescription);
    //         Destroy(gameObject);  // Destroy the GameObject containing the item prefab
    //     }
    // }

}
