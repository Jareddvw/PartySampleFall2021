using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour {
    public CrimeBroadcast cb;
    public Transform playerTrans;
    public Shooter shooter;
    public TextMeshProUGUI primary;
    public TextMeshProUGUI secondary;
    public BasicVehicleMotor basicVehicle;
    public MoneyGrab moneyGrab;
    public Image[] itemUI;
    public Color[] originalColors;
    public Color pressedColor = Color.red;
    public float pressDuration = .5f;
    public List<Item> currentItems;

    // Start is called before the first frame update
    void Start()
    {
        basicVehicle = GetComponent<BasicVehicleMotor>();
        moneyGrab = GetComponent<MoneyGrab>();
        originalColors = new Color[currentItems.Count];
        for (int i = 0; i < currentItems.Count; i++) {
            var img = itemUI[i];
            if (img) originalColors[i] = img.color;
        }
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
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            Click(4);
        
    }

    public void Click(int key) {
        var item = currentItems[key];
        if (item.canBuy && moneyGrab.CanPayMoney(item.cost)) {
            moneyGrab.PayMoney(item.cost);
            StartCoroutine(PressColorChange(key));
            currentItems[key].OnActivate();
        }
    }

    public IEnumerator PressColorChange(int key) {
        var img = itemUI[key];
        if (img) {
            img.color = pressedColor;
            yield return new WaitForSeconds(pressDuration);
            img.color = originalColors[key];
        }
    }

    public bool Equip(Item item)
    {
        if (currentItems.Count <= 4)
        {
            currentItems.Add(item);
            return true;
        }
        return false;
    }

    public bool CanEquip(Weapon wep)
    {
        if (shooter.primaryWeapon == null) {
            return true;
        }
        else if (shooter.secondaryWeapon == null) {
            return true;
        }
        return false;
    }

    public void Equip(Weapon wep)
    {
        if (shooter.primaryWeapon == null) {
            wep.cb = cb;
            wep.playerTrans = playerTrans;
            shooter.primaryWeapon = wep;
            primary.text = wep.name;
        }
        else if (shooter.secondaryWeapon == null) {
            wep.cb = cb;
            wep.playerTrans = playerTrans;
            shooter.secondaryWeapon = wep;
            secondary.text = wep.name;
        }
    }
}
