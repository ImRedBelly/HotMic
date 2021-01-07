using UnityEngine;
using UnityEngine.UI;

public class Purse : MonoBehaviour
{
    public Text purse;
    int money;
    void Start()
    {
        TextRead();
    }
    public void TextRead()
    {
        money = PlayerPrefs.GetInt(GameManager.moneyKey);
        purse.text = "Money: " + money;
    }
}
