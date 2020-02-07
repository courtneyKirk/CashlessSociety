using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private float healthValue = 100;

    private Text healthValueUIText;

    // Start is called before the first frame update
    void Start()
    {
        healthValueUIText = GameObject.Find("HealthValue").GetComponent<Text>();
        healthValueUIText.text = healthValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            IncreaseHealth(5);

        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            RemoveHealth(5);
        }


    }

    public float GetHealthValue()
    {
        return healthValue;
    }
    public void RemoveHealth(float removeValue)
    {
        if(healthValue < removeValue)
        {
            healthValue = 0;
        }
        else
        {

            healthValue -= removeValue;
        }
        healthValueUIText.text = healthValue.ToString();
      
    }

    public void IncreaseHealth(float additionValue)
    {
        if(healthValue + additionValue > 100)
        {
            healthValue = 100;
        }
        else
        {

            healthValue += additionValue;
        }

        healthValueUIText.text = healthValue.ToString();
    }
}
