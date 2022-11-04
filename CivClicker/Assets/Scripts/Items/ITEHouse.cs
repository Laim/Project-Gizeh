using System.Collections;
using System.Numerics;
using TMPro;
using UnityEngine;

// This script is attached to each spawned house
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ITEHouse : MonoBehaviour, IPurchaseItems
{
    private float _itemValue;
    private float _itemUgradePrice;

    public float ItemValue
    {
        get { return _itemValue; }
        set { _itemValue = value; }
    }

    public float ItemUpgradePrice
    {
        get { return _itemUgradePrice; }
        set { _itemUgradePrice = value; }
    }

    public PurchaseTypes PurchaseTypes { get => PurchaseTypes.HOUSE; }

    public TMP_Text MANUAL_VALUE;
    public GameObject UPGRADE_MENU;

    public ITEHouse()
    {
        if(_itemUgradePrice == 0)
        {
            _itemUgradePrice = 1000f;
        }

        if(_itemValue == 0)
        {
            _itemValue = 100;
        }
    }

    private void Awake()
    {
        ((IPurchaseItems)this).Activate();

        // We run this on awake instead of Run()
        // so the rate doesn't increase every second lol
        ScoreManager.instance.IncreasePlayerRate(_itemValue);
    }

    private void OnDisable()
    {
        ((IPurchaseItems)this).Deactivate();
    }

    void Run()
    {
        ScoreManager.instance.IncreasePlayerScore(_itemValue);
    }

    void IPurchaseItems.Activate()
    {
        InvokeRepeating(nameof(Run), 0f, 1f);
    }

    /// <summary>
    /// Deactivates the object, only used in Dev.  Not player facing.
    /// </summary>
    void IPurchaseItems.Deactivate()
    {
        CancelInvoke(nameof(Run));
    }

    public void Upgrade()
    {
        Debug.Log($"Upgrade for {_itemUgradePrice}");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click.");
            ScoreManager.instance.IncreasePlayerScore(_itemValue/2);

            MANUAL_VALUE.text = $"+{_itemValue/2}";
            MANUAL_VALUE.enabled = true;
            StartCoroutine(ShowLeftClick());
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            UPGRADE_MENU.SetActive(true);
        }

        if (Input.GetMouseButtonDown(2)) Debug.Log("Pressed middle click.");
    }

    IEnumerator ShowLeftClick()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // disable the house from being clicked again to limit spam
        yield return new WaitForSeconds(0.5f); // wait 0.5f
        gameObject.GetComponent<BoxCollider2D>().enabled = true; // enable the house clicking again
        MANUAL_VALUE.enabled = false; // hide the +value label
    }
}
