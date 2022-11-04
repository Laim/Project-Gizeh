using System.Numerics;
using UnityEngine;

public class AutoClickerItem : MonoBehaviour, IPurchaseItems
{
    public float ItemValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ItemUpgradePrice { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public PurchaseTypes PurchaseTypes { get => PurchaseTypes.AUTO_CLICK; }

    private void Awake()
    {
        ((IPurchaseItems)this).Activate();
    }

    private void OnDisable()
    {
        ((IPurchaseItems)this).Deactivate();
    }

    void Run()
    {
        ScoreManager.instance.IncreasePlayerScore(ShopManager.instance.CLICKER_AUTO_VALUE * ShopManager.instance.CLICKER_AUTO_COUNT);
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
}
