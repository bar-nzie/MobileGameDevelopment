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
    public TextMeshProUGUI milk;
    public TextMeshProUGUI wool;
    public TextMeshProUGUI hay1;
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

        storage.text = "Storage: " + (hayValue + eggsValue + milkValue + woolValue).ToString() + "/100";
    }

    public int RetrieveHay() { return hayValue; }


    public int RetrieveStorage() { return value; }

    public void SetStorageZero()
    {
        value = 0;

        storage.text = "Storage: " + value.ToString();
    }

    public void DecreaseHay(int subtract)
    {
        hayValue -= subtract;

        hay.text = "Hay: " + hayValue.ToString();
        hay1.text = hayValue.ToString();
    }

    public void IncreaseHay(int add)
    {
        hayValue += add;

        hay.text = "Hay: " + hayValue.ToString();
        hay1.text = hayValue.ToString();
    }

    public void SetMoney(int add)
    {
        moneyValue += add;
        money.text = "Money: " + moneyValue.ToString();
    }

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

    public void IncreaseEggs(int add)
    {
        eggsValue += add;
        eggs.text = eggsValue.ToString();
    }

    public void IncreaseMilk(int add)
    {
        milkValue += add;
        milk.text = milkValue.ToString();
    }

    public void IncreaseWool(int add)
    {
        woolValue += add;
        wool.text = woolValue.ToString();
    }
}
