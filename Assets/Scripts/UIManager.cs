using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<GameObject> UIChargeElements;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowCharges(int charges)
    {
        // Hide all UI elements first
        foreach (GameObject chargeElement in UIChargeElements)
        {
            chargeElement.SetActive(false);
        }
        // Show the number of charge elements based on the charges available
        for (int i = 0; i < charges && i < UIChargeElements.Count; i++)
        {
            UIChargeElements[i].SetActive(true);
        }
    }
    public void HideCharges()
    {
        // Hide all UI elements
        foreach (GameObject chargeElement in UIChargeElements)
        {
            chargeElement.SetActive(false);
        }
    }
}
