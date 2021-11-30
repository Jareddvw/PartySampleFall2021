using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public KeyCode shopButton;
    public MoneyGrab mg;
    public Inventory inv;
    public Canvas shopCanvas;
    public bool inshop;

    public void Update()
    {
        if(Input.GetKeyDown(shopButton))
        {
            inshop = !inshop;
            if (inshop)
                EnterStore();
            else
                ExitStore();
        }
    }

    public void EnterStore()
    {
        Time.timeScale = 0;
        shopCanvas.enabled = true;
    }

    public void ExitStore()
    {
        Time.timeScale = 1;
        shopCanvas.enabled = false;
    }

    public void Buy(Weapon item)
    {
        if (inv.CanEquip(item))
        {
            if (mg.CanPayMoney(item.cost))
            {
                mg.PayMoney(item.cost);
                inv.Equip(item);
            }
        }

    }
}
