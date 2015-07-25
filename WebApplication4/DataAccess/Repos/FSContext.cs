using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Models;

namespace DataAccess.Repos
{
    public class FSContext
    {
        public IList<ShoppingListProduct> GetFavourites(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand
                {
                    CommandText = "SELECT top 1 * FROM tbdcPredictItems where Id = " + id,
                    CommandType = CommandType.Text,
                    Connection = conn
                };

                conn.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();

                var tbdcPredictItem = new tbdcPredictItem();
                while (reader1.Read())
                {
                    tbdcPredictItem.Item1 = reader1["Item1"].ToString();
                    tbdcPredictItem.Item2 = reader1["Item2"].ToString();
                    tbdcPredictItem.Item3 = reader1["Item3"].ToString();
                    tbdcPredictItem.Item4 = reader1["Item4"].ToString();
                    tbdcPredictItem.Item5 = reader1["Item5"].ToString();
                    tbdcPredictItem.Item6 = reader1["Item6"].ToString();
                    tbdcPredictItem.Item7 = reader1["Item7"].ToString();
                    tbdcPredictItem.Item8 = reader1["Item8"].ToString();
                    tbdcPredictItem.Item9 = reader1["Item9"].ToString();
                    tbdcPredictItem.Item10 = reader1["Item10"].ToString();
                }
                reader1.Close();

                // Data is accessible through the DataReader object here.
                var query = "select * from dbo.tbMasterArticleDescription" +
                            " where nzpnano in (" +
                            "" + tbdcPredictItem.Item1 + "," +
                            "" + tbdcPredictItem.Item2 + "," +
                            "" + tbdcPredictItem.Item3 + "," +
                            "" + tbdcPredictItem.Item4 + "," +
                            "" + tbdcPredictItem.Item5 + "," +
                            "" + tbdcPredictItem.Item6 + "," +
                            "" + tbdcPredictItem.Item7 + "," +
                            "" + tbdcPredictItem.Item8 + "," +
                            "" + tbdcPredictItem.Item9 + "," +
                            "" + tbdcPredictItem.Item10 + ")";

                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = query,
                    CommandType = CommandType.Text,
                    Connection = conn
                }; 
                SqlDataReader reader2 = cmd2.ExecuteReader();

                IList<ShoppingListProduct> shoppingList = new List<ShoppingListProduct>();
                while (reader2.Read())
                {
                    var shoppingListProduct = new ShoppingListProduct();
                    Product product = new Product()
                    {
                        ProductId = Convert.ToInt64(reader2["nzpnano"]),
                        ShortDescription = reader2["ArticleDescription"].ToString()
                    };
                    shoppingListProduct.Product = product;
                    shoppingList.Add(shoppingListProduct);
                }
                reader2.Close();

                conn.Close();

                return shoppingList;
            }
        }
    }
}
