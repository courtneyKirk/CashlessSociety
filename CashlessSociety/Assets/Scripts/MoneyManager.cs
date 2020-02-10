using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private float totalCurrency = 150.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCurrency(float amount)
    {
        totalCurrency -= amount;
    }

    public void AddCurrency(float amount)
    {
        totalCurrency += amount;
    }

    public float GetCurrentCurrency()
    {
        return totalCurrency;
    }
}
