using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;

    public ItemSlot[] itemSlot;

    // Reference to the GameObject containing the CameraController script
    public GameObject cameraControllerObject;

    // Reference to the CameraController script
    private FirstPersonController cameraController;

    
    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject with the CameraController script
        cameraControllerObject = GameObject.Find("FirstPersonControllerObj");

        // Check if cameraControllerObject is null after attempting to find it
        if (cameraControllerObject != null)
        {
            // Assuming the CameraController script is on a different GameObject
            cameraController = cameraControllerObject.GetComponent<FirstPersonController>();

            // Check if cameraController is null after attempting to get it
            if (cameraController == null)
            {
                Debug.LogError("CameraController script not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with CameraController script not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            // Toggle the menu state
            menuActivated = !menuActivated;

            // Set the menu state
            InventoryMenu.SetActive(menuActivated);
            cameraController.enabled = !menuActivated;
        }

        if (menuActivated)
        {
            Cursor.lockState = CursorLockMode.Confined;
            
            
        } else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            
        }

    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Debug.Log("Item name: " + itemName + "quantity: " + quantity + "itemSprite: " + itemSprite);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName,quantity,itemSprite, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
