using System.Runtime.Serialization;
using System.Security.Cryptography;

[DataContract]
public class ShoppingListProduct:Product
{
   
    [DataMember]
    public int Quantity { get; set; }

    public ShoppingListProduct(long id, string descr, string url, string quantity, double price, string dept, string subdept, bool healthy, bool isfood, int qty) : 
        base(id,descr,url,quantity,price,dept,subdept,healthy,isfood)
    {
        Quantity = qty;
    }

}