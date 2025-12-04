using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    //UI text
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
    public TextMeshProUGUI gems;
    //Sell button
    public Button eggSell;
    public Button milkSell;
    public Button woolSell;
    public Button haySell;

    public GameObject AD;
    //Amounts
    private int value;
    private int hayValue = 20;
    private int moneyValue = 3200;
    private int minigameValue = 1;
    private int eggsValue;
    private int milkValue;
    private int woolValue;
    private int gemValue = 5;

    //Buying
    //Amount bought
    private int chickenAmount;
    private int cowAmount;
    private int fieldAmount;
    private int woolAmount;
    //Buy button
    public Button chickenBuy;
    public Button cowBuy;
    public Button woolBuy;
    public Button fieldBuy;
    //Place Button
    public Button chickenPlace;
    public Button cowPlace;
    public Button woolPlace;
    public Button fieldPlace;
    //Amount text
    public TextMeshProUGUI chicken;
    public TextMeshProUGUI cow;
    public TextMeshProUGUI sheep;
    public TextMeshProUGUI field;
    //Premium Button
    public Button chickenPremium;
    public Button cowPremium;
    public Button sheepPremium;
    public Button fieldPremium;

    private void Start()
    {
        hay.text = "Hay: " + hayValue.ToString();
        hay1.text = hay2.text = hayValue.ToString();
        gems.text = "Gems: " + gemValue.ToString();
        money.text = "Money: " + moneyValue.ToString();
    }

    private void Update()
    {
        //Check if user can watch ad for minigame
        if (minigameValue == 0)
        {
            AD.SetActive(true);
        }
        else
        {
            AD.SetActive(false);
        }

        //Check if the player has anything to sell
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

        //Checks if the user can afford a pen
        woolBuy.interactable = true;
        chickenBuy.interactable = true;
        cowBuy.interactable = true;
        fieldBuy.interactable = true;
        if (moneyValue < 480)
        {
            woolBuy.interactable = false;
            if(moneyValue < 320)
            {
                cowBuy.interactable = false;
                if (moneyValue < 150)
                {
                    chickenBuy.interactable = false;
                    if( moneyValue < 50)
                    {
                        fieldBuy.interactable = false;
                    }
                }
            }
        }

        //Premium Check
        sheepPremium.interactable = true;
        chickenPremium.interactable = true;
        cowPremium.interactable = true;
        fieldPremium.interactable = true;
        if (gemValue < 5)
        {
            sheepPremium.interactable = false;
            if(gemValue < 3)
            {
                cowPremium.interactable = false;
                if (gemValue < 2)
                {
                    chickenPremium.interactable = false;
                    if( gemValue < 1)
                    {
                        fieldPremium.interactable = false;
                    }
                }
            }
        }

        //Checks if user owns any pens
        if (chickenAmount == 0) chickenPlace.interactable = false;
        else chickenPlace.interactable= true;
        if (cowAmount == 0) cowPlace.interactable = false;
        else cowPlace.interactable= true;
        if (woolAmount == 0) woolPlace.interactable = false;
        else woolPlace.interactable= true;
        if (fieldAmount == 0) fieldPlace.interactable = false;
        else fieldPlace.interactable= true;

            //Set Storage value
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

    //Buying pens
    public void BuyChicken()
    {
        moneyValue -= 150;
        money.text = "Money: " + moneyValue.ToString();
        chickenAmount++;
        chicken.text = chickenAmount.ToString();
    }

    public void BuyCow()
    {
        moneyValue -= 320;
        money.text = "Money: " + moneyValue.ToString();
        cowAmount++;
        cow.text = cowAmount.ToString();
    }

    public void BuySheep()
    {
        moneyValue -= 480;
        money.text = "Money: " + moneyValue.ToString();
        woolAmount++;
        sheep.text = woolAmount.ToString();
    }
    
    public void BuyField()
    {
        moneyValue -= 50;
        money.text = "Money: " + moneyValue.ToString();
        fieldAmount++;
        field.text = fieldAmount.ToString();
    }

    //Placing Pens
    public void PlaceSheep()
    {
        woolAmount--;
        sheep.text = woolAmount.ToString();
    }

    public void PlaceChicken()
    {
        chickenAmount--;
        chicken.text = chickenAmount.ToString();
    }

    public void PlaceCow()
    {
        cowAmount--;
        cow.text = cowAmount.ToString();
    }

    public void PlaceField()
    {
        fieldAmount--;
        field.text = fieldAmount.ToString();
    }

    //Buying Premium
    public void ChickenPremium()
    {
        gemValue -= 2;
        gems.text = "Gems: " + gemValue.ToString();
        chickenAmount++;
        chicken.text = chickenAmount.ToString();
    }

    public void CowPremium()
    {
        gemValue -= 3;
        gems.text = "Gems: " + gemValue.ToString();
        cowAmount++;
        cow.text = cowAmount.ToString();
    }

    public void SheepPremium()
    {
        gemValue -= 5;
        gems.text = "Gems: " + gemValue.ToString();
        woolAmount++;
        sheep.text = woolAmount.ToString();
    }

    public void FieldPremium()
    {
        gemValue -= 1;
        gems.text = "Gems: " + gemValue.ToString();
        fieldAmount++;
        field.text = fieldAmount.ToString();
    }

    public void AddGems()
    {
        gemValue += 5;
        gems.text = "Gems: " + gemValue.ToString();
    }
}
