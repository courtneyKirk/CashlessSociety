using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AdvertisingManager : MonoBehaviour
{
    //List of adverts waiting to be shown
    List<GameObject> waitingPopups = new List<GameObject>();

    List<GameObject> ads = new List<GameObject>();

    List<GameObject> popUpimages = new List<GameObject>();

    Stack<int> adSpaceFull = new Stack<int>();

    //string Two = "GroupTwo";
    //string Three = "GroupThree";
    public GameObject[] groupOne; 
    //public GameObject[] groupTwo; 
    float timer = 0.0f;
    int popUptimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        popUpimages = new List<GameObject>();
        waitingPopups = new List<GameObject>();
        popUpimages.AddRange(GameObject.FindGameObjectsWithTag("PopUpImage"));
        AddNewAdvertisingToList(1);
        popUptimer = Random.Range(5, 20);
        Debug.Log("Timer number :" + popUptimer);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > popUptimer)
        {
            DisplayAdvert();
            timer = 0;
            popUptimer = Random.Range(5, 20);
        }
        else
        {
            timer += Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.P) && adSpaceFull.Count() !=0)
        {
            popUpimages[adSpaceFull.Peek()].GetComponent<Image>().color = Color.clear;
            popUpimages[adSpaceFull.Peek()].GetComponent<Image>().sprite = null;

            adSpaceFull.Pop();
        }

    }

    void AddNewAdvertisingToList(int advertGroup)
    {
        waitingPopups.Clear();
        ads.Clear();
        ///Possible change to case/switch statement
        if (advertGroup == 1)
        {
            ads.AddRange(groupOne);
        }
        else if(advertGroup == 2)
        {

        }
        
        foreach(GameObject go in ads)
        {
            waitingPopups.Add(go);
        }
    }

    void DisplayAdvert()
    {
        int randomPositionnum = Random.Range(0, (popUpimages.Count() - 1));
        int displayImagenum = Random.Range(0, (waitingPopups.Count() - 1));
        popUpimages[randomPositionnum].GetComponent<Image>().color = Color.white;
        popUpimages[randomPositionnum].GetComponent<Image>().sprite = waitingPopups[displayImagenum].GetComponent<SpriteRenderer>().sprite;
        adSpaceFull.Push(randomPositionnum);

    }
}
