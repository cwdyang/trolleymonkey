using System.Runtime.Serialization;

[DataContract]
public class ShoppingListProduct
{
    [DataMember]
    public int ShoppingListProductId { get; set; }

    [DataMember]
    public int Quantity { get; set; }

    [DataMember]
    public Product Product { get; set; }

    public ShoppingListProduct(int id, int quantity, Product p)
    {
        ShoppingListProductId = id;
        Quantity = quantity;
        Product = p;
    }

}