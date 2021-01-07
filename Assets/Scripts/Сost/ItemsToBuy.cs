using UnityEngine;

public class ItemsToBuy : MonoBehaviour
{
    int money;
    public void Spend(int price)
    {
        money = PlayerPrefs.GetInt(GameManager.moneyKey);

        if(money <= 0)
        {
            print("Денег нет");
            return;
        }
        else
        {
            print("Деньги есть");

            if((money = money - price) < 0)
            {
                print("Не хватает");

                return;
            }
            else
            {
                print("Денег хватает");

                Save();
                Purse purse = FindObjectOfType<Purse>();
                purse.TextRead();
            }
        }
    }

    void Save()
    {
        PlayerPrefs.SetInt(GameManager.moneyKey, money);
    }
}
