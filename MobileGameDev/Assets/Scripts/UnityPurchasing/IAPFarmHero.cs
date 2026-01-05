using UnityEngine;
using UnityEngine.Purchasing;

public class IAPFarmHero : MonoBehaviour
{
    bool noads = false;
    public void Purchaseed(Product product)
    {
        if (product.definition.id.Equals("noads"))
        {
            Debug.Log("Purchased");
            noads = true;
        }
    }

    public bool SetNoads() { return noads; } 
}
