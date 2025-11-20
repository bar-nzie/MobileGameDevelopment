using UnityEngine;

public class SellScript : MonoBehaviour
{
    public GameObject button;
    public GameObject findStorage;
    public Storage storage;
    private int storageValue;


    private void Start()
    {
        findStorage = GameObject.Find("MainUI");
        storage = findStorage.GetComponent<Storage>();
    }

    public void onSell()
    {
        storageValue = storage.RetrieveStorage();
        storage.SetStorageZero();
        storage.SetMoney(storageValue);
        button.SetActive(false);
    }
}
