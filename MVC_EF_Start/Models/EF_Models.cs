using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
  public class Order
  {
    //[Key]
    public int id { get; set; }
    public int totalItems { get; set; }
    public int totalPrice { get; set; }
    public string date { get; set; }
    public List<OrderItem> ItemsInOrder { get; set; }
  }

  public class Product
  {
    //[Key]
    public int id { get; set; }
    public string name { get; set; }
    public string brand { get; set; }
    public int price { get; set; }
    public List<OrderItem> ProductOrders { get; set; }
  }

  public class OrderItem
  {
    public int id { get; set; }
    public Order PlacedOrder { get; set; }
    public Product PurchasedItem { get; set; }
  }
}