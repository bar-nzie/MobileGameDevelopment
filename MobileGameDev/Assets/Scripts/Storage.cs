using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI storage;
    public TextMeshProUGUI hay;
    public TextMeshProUGUI money;
    private int value;
    private int hayValue = 20;
    private int moneyValue = 0;

    private void Start()
    {
        hay.text = "Hay: " + hayValue.ToString();
    }

    public int RetrieveHay() { return hayValue; }

    public void IncreaseStorage(int add)
    {
        value += add;

        storage.text = "Storage: " + value.ToString();
    }

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
    }

    public void IncreaseHay(int add)
    {
        hayValue += add;

        hay.text = "Hay: " + hayValue.ToString();
    }

    public void SetMoney(int add)
    {
        moneyValue += add;
        money.text = "Money: " + moneyValue.ToString();
    }
}
