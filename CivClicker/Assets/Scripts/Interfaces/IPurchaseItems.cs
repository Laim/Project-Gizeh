public interface IPurchaseItems
{

    public PurchaseTypes PurchaseTypes { get; }
    public float ItemValue 
    { 
        get; 
        set; 
    }
    public float ItemUpgradePrice 
    { 
        get; 
        set; 
    }

    void Activate();
    void Deactivate();
}
