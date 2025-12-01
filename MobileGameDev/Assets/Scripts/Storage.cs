using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    public TextMeshProUGUI storage;
    public TextMeshProUGUI hay;
    public TextMeshProUGUI money;
    public TextMeshProUGUI minigame;
    public TextMeshProUGUI eggs;
    public TextMeshProUGUI eggShop;
    public TextMeshProUGUI milk;
    public TextMeshProUGUI milkShop;
    public TextMeshProUGUI wool;
    public TextMeshProUGUI woolShop;
    public TextMeshProUGUI hay1;
    public TextMeshProUGUI hay2;
    public Button eggSell;
    public Button milkSell;
    public Button woolSell;
    public Button haySell;
    public GameObject AD;
    private int value;
    private int hayValue = 20;
    private int moneyValue = 0;
    private int minigameValue = 1;
    private int eggsValue;
    private int milkValue;
    private int woolValue;

    private void Start()
    {
        hay.text = "Hay: " + hayValue.ToString();
        hay1.text = hay2.text = hayValue.ToString();
    }

    private void Update()
    {
        if (minigameValue == 0)
        {
            AD.SetActive(true);
        }
        else
        {
            AD.SetActive(false);
        }

        if (eggsValue == 0)
        {
            eggSell.interactable = false;
        }
        else
        {
            eggSell.interactable = true;
        }
        if (milkValue == 0)
        {
            milkSell.interactable = false;
        }
        else milkSell.interactable = true;
        if (woolValue == 0)
        {
            woolSell.interactable = false;
        }
        else woolSell.interactable = true;
        if (hayValue == 0)
        {
            haySell.interactable = false;
        }
        else haySell.interactable = true;

            storage.text = "Storage: " + (hayValue + eggsValue + milkValue + woolValue).ToString() + "/100";
    }

    public int RetrieveHay() { return hayValue; }


    public int RetrieveStorage() { return value; }

    public void SetStorageZero()
    {
        value = 0;

        storage.text = "Storage: " + value.ToString();
    }

    //Hay Value
    public void DecreaseHay(int subtract)
    {
        hayValue -= subtract;

        hay.text = "Hay: " + hayValue.ToString();
        hay1.text = hay2.text = hayValue.ToString();
    }

    public void IncreaseHay(int add)
    {
        hayValue += add;

        hay.text = "Hay: " + hayValue.ToString();
        hay1.text = hay2.text = hayValue.ToString();
    }



    //Minigame Values
    public void DecreaseMinigame()
    {
        minigameValue--;
        minigame.text = "MiniGame: " + minigameValue.ToString();
    }

    public void IncreaseMinigame()
    {
        minigameValue++;
        minigame.text = "MiniGame: " + minigameValue.ToString();
    }

    public int GetMinigame() { return minigameValue; }


    //Increasing
    public void IncreaseEggs(int add)
    {
        eggsValue += add;
        eggShop.text = eggs.text = eggsValue.ToString();
    }

    public void IncreaseMilk(int add)
    {
        milkValue += add;
        milkShop.text = milk.text = milkValue.ToString();
    }

    public void IncreaseWool(int add)
    {
        woolValue += add;
        woolShop.text = wool.text = woolValue.ToString();
    }

    //Selling
    public void SellEggs()
    {
        moneyValue += eggsValue;
        money.text = "Money: " + moneyValue.ToString();
        eggsValue = 0;
        eggShop.text = eggs.text = eggsValue.ToString();
    }

    public void SellMilk()
    {
        moneyValue += milkValue;
        money.text = "Money: " + moneyValue.ToString();
        milkValue = 0;
        milkShop.text = milk.text = milkValue.ToString();
    }

    public void SellWool()
    {
        moneyValue += woolValue;
        money.text = "Money: " + moneyValue.ToString();
        woolValue = 0;
        woolShop.text = wool.text = woolValue.ToString();
    }

    public void SellHay()
    {
        moneyValue += hayValue;
        money.text= "Money: " + moneyValue.ToString();
        hayValue = 0;
        hay.text = hay1.text = hay2.text = hayValue.ToString();
    }
}
