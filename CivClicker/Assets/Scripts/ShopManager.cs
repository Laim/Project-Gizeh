using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    internal float CLICKER_AUTO_COUNT = 0; // increase by 1 each purchase
    internal float CLICKER_AUTO_COST = 100f; // multiple by value defined in PurchaseAutoClicker() each purchase
    public float CLICKER_AUTO_VALUE = 5.5f; // the increase the player recieves, i.e 4 clickers are 4 * CLICKER_AUTO_COST;
    private GameObject SHOP_AUTOCLICK_ITEM;

    internal float CLICKER_HOUSE_COUNT = 0; // increase by 1 each purchase
    internal float CLICKER_HOUSE_COST = 10000f; // multiple by value defined in PurchaseHouseClicker() each purchase
    private GameObject SHOP_HOUSE_ITEM;
    private float SHOP_HOUSE_MAXIUM = 19;

    public PurchaseItems SHOP_OBJECTS; // list of applicable shop object types

    private bool IsWindowOpen = false; // used for shop window animations

    public static ShopManager instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        if (SHOP_AUTOCLICK_ITEM == null)
        {
            SHOP_AUTOCLICK_ITEM = GameObject.Find("CLICKER_NEW_COST");
            SHOP_AUTOCLICK_ITEM.GetComponent<TMP_Text>().text = $"{CLICKER_AUTO_COST:N0}c";

            GameObject.Find("CLICKER_OWNED_COUNT").GetComponent<TMP_Text>().text = CLICKER_AUTO_COUNT.ToString("N0");
        }

        if(SHOP_HOUSE_ITEM == null)
        {
            SHOP_HOUSE_ITEM = GameObject.Find("HOUSE_NEW_COST");
            SHOP_HOUSE_ITEM.GetComponent<TMP_Text>().text = $"{CLICKER_HOUSE_COST:N0}c";

            GameObject.Find("HOUSE_OWNED_COUNT").GetComponent<TMP_Text>().text = $"{CLICKER_HOUSE_COUNT:N0}/{SHOP_HOUSE_MAXIUM}";
        }
    }

    /// <summary>
    /// Shows the user the shop Window
    /// </summary>
    public void ShopWindowStatus()
    {
        GameObject ShopWindow = GameObject.Find("SHOP_PANEL");

        if(ShopWindow != null)
        {
            if(IsWindowOpen)
            {
                ShopWindow.GetComponent<Animation>().Play("ShopWindowClose");
                IsWindowOpen = false;
            } else
            {
                ShopWindow.GetComponent<Animation>().Play("ShopWindowOpen");
                IsWindowOpen = true;
            }
        }
    }

    public void RefreshWindow()
    {
        GameObject.Find("CLICKER_OWNED_COUNT").GetComponent<TMP_Text>().text = CLICKER_AUTO_COUNT.ToString("N0");
        SHOP_AUTOCLICK_ITEM.GetComponent<TMP_Text>().text = $"{CLICKER_AUTO_COST:N0}c";

        GameObject.Find("HOUSE_OWNED_COUNT").GetComponent<TMP_Text>().text = $"{CLICKER_HOUSE_COUNT:N0}/{SHOP_HOUSE_MAXIUM}";
        SHOP_HOUSE_ITEM.GetComponent<TMP_Text>().text = $"{CLICKER_HOUSE_COST:N0}c";
    }

    /// <summary>
    /// Purchases a new AutoClicker and runs the relevant methods
    /// </summary>
    public void PurchaseAutoClicker()
    {
        if (ScoreManager.instance.PLAYER_SCORE_VALUE > (BigInteger)CLICKER_AUTO_COST)
        {
            if(CLICKER_AUTO_COUNT == 0)
            {
                SHOP_OBJECTS.AUTOCLICKER.SetActive(true); // activates the autoclicker method
            }

            CLICKER_AUTO_COUNT++; // increase our owned auto clickers by 1
            ScoreManager.instance.PLAYER_SCORE_VALUE -= (BigInteger)CLICKER_AUTO_COST; // remove the clicker cost from our score
            CLICKER_AUTO_COST += CLICKER_AUTO_COST.Percentage(6.31383f); // increase the cost of our auto clickers by 6.31383%

            RefreshWindow();

            ScoreManager.instance.IncreasePlayerRate(CLICKER_AUTO_VALUE, this);

            float[] ClickersRequired = new float[] { 5, 10, 20, 50, 70, 100, 150, 200, 500, 800, 1000 };

            if(ClickersRequired.Contains(CLICKER_AUTO_COUNT))
            {
                ITEPeopleSpawner.instance.Spawn();
            }

        }
    }

    /// <summary>
    /// Purchases a new HouseClicker and runs the relevant methods
    /// </summary>
    public void PurchaseHouseClicker()
    {
        if(ScoreManager.instance.PLAYER_SCORE_VALUE > (BigInteger)CLICKER_HOUSE_COST)
        {
            CLICKER_HOUSE_COUNT++; // increase our owned houses by 1
            ScoreManager.instance.PLAYER_SCORE_VALUE -= (BigInteger)CLICKER_HOUSE_COST; // remove the house cost from our score
            CLICKER_HOUSE_COST += CLICKER_HOUSE_COST.Percentage(40); // increase the cost of our house clickers by 8%

            // Update the Shop page for the total owned houses + the current cost for a new house
            RefreshWindow();

            // spawn a new house on the map somewhere
            // This then triggers Items\ITEHouse.cs which is assigned to each object under the prefab
            HouseSpawner.Instance.SpawnNewHouse();

            if(CLICKER_HOUSE_COUNT >= SHOP_HOUSE_MAXIUM)
            {
                GameObject.Find("HousePurchase").GetComponent<Button>().interactable = false;
                // Show user that they've bought the maxium number of houses
            }
        }
    }
}