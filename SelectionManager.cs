using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance { get; set; }

    public bool onTarget;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;
    public Item currentInteractable; // Add this variable

 
    private void Start()
    {
        onTarget = false;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
 
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            var selectionTransform = hit.transform;

            Item ourInteractable = selectionTransform.GetComponent<Item>();
 
            if (ourInteractable) //If it has the component script and player in range
            {
                onTarget = true;
                
                interaction_text.text = selectionTransform.GetComponent<Item>().GetItemName();
                interaction_Info_UI.SetActive(true);

                currentInteractable = ourInteractable; // Set the currentInteractable
            }
            else 
            { 
                onTarget = false;
                interaction_Info_UI.SetActive(false); //If looking at non-interactible object
                interaction_text.text = string.Empty;

                currentInteractable = null; // Reset currentInteractable if not interacting with an item
            }
 
        }
        else 
        {
            onTarget = false;
            interaction_Info_UI.SetActive(false);
            interaction_text.text = string.Empty;
            currentInteractable = null; // Reset currentInteractable if not hitting anything
        }
    }

    public Vector3 GetRayDirection()
    {
        // Return the direction of the ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.direction;
    }
}
