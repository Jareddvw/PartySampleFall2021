using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public BasicVehicleMotor basicVehicle;
    public MoneyGrab moneyGrab;
    public Image[] itemUI;
    public List<Item> currentItems;

    // Start is called before the first frame update
    void Start()
    {
        basicVehicle = GetComponent<BasicVehicleMotor>();
        moneyGrab = GetComponent<MoneyGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))        
            Click(0);   
        else if (Input.GetKeyDown(KeyCode.Alpha2))       
            Click(1);     
        else if (Input.GetKeyDown(KeyCode.Alpha3))       
            Click(2);        
        else if (Input.GetKeyDown(KeyCode.Alpha4))       
            Click(3);
        
    }

    public void Click(int key)
    {
        if (currentItems[key] == null)
            return;
        if(moneyGrab.PayMoney(currentItems[key].cost))
        {
            Debug.Log("buy: " + currentItems[key]);
            currentItems[key].OnActivate();
        }          
    }
}