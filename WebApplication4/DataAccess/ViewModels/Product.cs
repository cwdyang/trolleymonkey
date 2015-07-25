using System.Runtime.Serialization;

[DataContract]
public class Product
{
    [DataMember]
    public long ProductId { get; set; }

    [DataMember]
    public string ShortDescription { get; set; }

    [DataMember]
    public string ImageUrl { get; set; }

    [DataMember]public string QuantityUnt { get; set; }

    [DataMember]
    public double PricePerUnit { get; set; }

    public Product(long id, string descr, string url, string quantity, double price)
    {
        ProductId = id;
        ShortDescription = descr;
        ImageUrl = url;
        QuantityUnt = quantity;
        PricePerUnit = price;
    }

    public Product(long id, string descr)
    {
        ProductId = id;
        ShortDescription = descr;
        ImageUrl = "http://www.hormelfoods.com/~/media/HormelFoods/Images/Brands/Product%20Shots/High%20Res%20Product%20Shots/spam-family-of-products.ashx";
        QuantityUnt = "";
        PricePerUnit = 69.00;
    }
}
