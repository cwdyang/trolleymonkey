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

    [DataMember]
    public string QuantityUnit { get; set; }

    [DataMember]
    public double PricePerUnit { get; set; }

    public Product(long id, string descr, string url, string quantity, double price)
    {
        ProductId = id;
        ShortDescription = descr;
        ImageUrl = url;
        QuantityUnit = quantity;
        PricePerUnit = price;
    }

    public Product()
    {
        ImageUrl =
            "http://www.hormelfoods.com/~/media/HormelFoods/Images/Brands/Product%20Shots/High%20Res%20Product%20Shots/spam-family-of-products.ashx";
        QuantityUnit = "kg";
        PricePerUnit = 69.00;
    }
}