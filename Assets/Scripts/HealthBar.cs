using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    
    public Image hpImage;
    public int hp;
    public int maxHP;
    public HealthScript healthScript;
    public Canvas canvas;
    public Image fullHpImage;
    //public CanvasScaler canvasScaler;

    private void Awake()
    {
        //canvasScaler = GetComponent<CanvasScaler>();
        //canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        hpImage = GetComponent<Image>();
        hp = healthScript.hp;
        maxHP = healthScript.maxHP;
        hpImage.type = Image.Type.Filled;
        hpImage.fillAmount = Mathf.Clamp01((float) hp / maxHP);
    }

    private void Update()
    {
        if (hp == healthScript.hp && maxHP == healthScript.maxHP) return;
        hp = healthScript.hp;
        maxHP = healthScript.maxHP;
        hpImage.fillAmount = Mathf.Clamp01((float) hp / maxHP);
    }
}
