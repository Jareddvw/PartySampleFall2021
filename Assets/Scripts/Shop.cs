using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public KeyCode shopButton;
    public int UpgradeDamageCost;
    public int UpgradeAttackSpeedCost;
    public Shooter shooter;
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

    public void UpgradeDamage()
    {
        if (!mg.CanPayMoney(UpgradeDamageCost))
            return;
        mg.PayMoney(UpgradeDamageCost);
        if(shooter.primaryWeapon)
            shooter.primaryWeapon.ChangeWeaponDamage(10);
        if(shooter.secondaryWeapon)
            shooter.secondaryWeapon.ChangeWeaponDamage(10);
    }

    public void UpgradeAttackSpeed()
    {
        if (!mg.CanPayMoney(UpgradeAttackSpeedCost))
            return;
        mg.PayMoney(UpgradeAttackSpeedCost);
        if (shooter.primaryWeapon)
            shooter.primaryWeapon.ChangeWeaponAttackSpeed(0.1f);
        if(shooter.secondaryWeapon)
            shooter.secondaryWeapon.ChangeWeaponAttackSpeed(0.1f);
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
