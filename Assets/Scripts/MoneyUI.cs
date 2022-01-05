using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class MoneyUI : MonoBehaviour
{
    public MoneyGrab money;
    public int bal;
    public Text moneyDisplay;

    private void Awake()
    {
        bal = money.bal;
        moneyDisplay.text = "$ " + bal;
    }

    private void Update()
    {
        if (bal == money.bal) return;
        bal = money.bal;
        moneyDisplay.text = "$ " + bal;

    }
}
