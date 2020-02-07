using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerSystem : MonoBehaviour
{
    private float hungerValue = 100;

    private Text hungerValueUIText;

    // Start is called before the first frame update
    void Start()
    {
        hungerValueUIText = GameObject.Find("HungerValue").GetComponent<Text>();
        hungerValueUIText.text = hungerValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            IncreaseHunger(5);

        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            RemoveHunger(5);
        }


    }

    public float GetHungerValue()
    {
        return hungerValue;
    }
    public void RemoveHunger(float removeValue)
    {
        if (hungerValue < removeValue)
        {
            hungerValue = 0;
        }
        else
        {

            hungerValue -= removeValue;
        }
        hungerValueUIText.text = hungerValue.ToString();

    }

    public void IncreaseHunger(float additionValue)
    {
        if (hungerValue + additionValue > 100)
        {
            hungerValue = 100;
        }
        else
        {

            hungerValue += additionValue;
        }

        hungerValueUIText.text = hungerValue.ToString();
    }
}
