using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    /*Instance/awake -> Singleton ez
    public static UIManager Instance;
    private void Awake() 
    {
        Instance = this;     
    }
    */
    [Header("Bar")]
    [SerializeField] private Image playerHp;
    [SerializeField] private Image playerMana;
    [SerializeField] private Image playerXp;
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI hpTMP;
    [SerializeField] private TextMeshProUGUI manaTPM;
    [SerializeField] private TextMeshProUGUI xpTPM;

    private float currentHp;
    private float maxHp;

    private float currentMana;
    private float maxMana;
    
    private float currentXp;
    private float requiredXpLv;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIPlayer();
    }

    private void UpdateUIPlayer()
    {
        playerHp.fillAmount = Mathf.Lerp(a:playerHp.fillAmount, b:currentHp / maxHp, t:10f * Time.deltaTime);
        hpTMP.text = $"{currentHp}/{maxHp}";
        //String Interpolation

        playerMana.fillAmount = Mathf.Lerp(a:playerMana.fillAmount, b:currentMana / maxMana, t:10f * Time.deltaTime);
        manaTPM.text = $"{currentMana}/{maxMana}";

        playerXp.fillAmount = Mathf.Lerp(a: playerXp.fillAmount, b: currentXp / requiredXpLv, t: 10f * Time.deltaTime);
        xpTPM.text = $"{((currentXp / requiredXpLv) *100):F2}%"; //F2 limit of float
    }
    
    public void UpdateHp(float currentHpoints, float maxHpoints)
    {
        currentHp = currentHpoints;
        maxHp = maxHpoints;
    }
    
    public void UpdateManaPlayer(float currentMpoints, float maxMpoints)
    {
        currentMana = currentMpoints;
        maxMana = maxMpoints;
    }

    public void UpdateXpPlayer(float currentXpoints, float maxXpoint)
    {
        currentXp = currentXpoints;
        requiredXpLv = maxXpoint;
    }
}
