using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcVoyage.Models
{
    public partial class ShoppingCart
    {
        VoyageEntities storeDB = new VoyageEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CardId";
        public static ShoppingCart GetCart (HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
            {
                return GetCart(controller.HttpContext);
            }


        public void AddToCart (City city)
            {
                var cartItem = storeDB.Carts.SingleOrDefault(
                    c => c.CartId == ShoppingCartId
                    && c.CityId == city.Id);

                if (cartItem == null)
                    {
                        cartItem = new Cart
                        {
                            CityId = city.Id,
                            CartId = ShoppingCartId,
                            Count = 1,
                            DataCreated = DateTime.Now
                        };
                        storeDB.Carts.Add(cartItem);
                    }
                else
                    {
                        cartItem.Count++;
                    }
                storeDB.SaveChanges();
            }

        public int RemoveFromCart(int id)
            {
                var cartItem = storeDB.Carts.Single(
                    cart => cart.CartId == ShoppingCartId
                    && cart.RecordId == id);

                int itemCount = 0;

                if (cartItem != null)
                    {
                        if (cartItem.Count > 1)
                            {
                                cartItem.Count--;
                                itemCount = cartItem.Count;
                            }
                        else
                            {
                                storeDB.Carts.Remove(cartItem);
                            }
                        storeDB.SaveChanges();
                    }
                return itemCount;
            }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
            {
                return storeDB.Carts.Where(
                    cart => cart.CartId == ShoppingCartId).ToList();
            }
        public int GetCount()
        {
            //get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public Decimal GetTotal()
        {
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.City.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    CityId = item.CityId,
                    OrderId = order.OrderId,
                    UnitPrice = item.City.Price,
                    Quantity = item.Count
                };
            }
                order.Total = orderTotal;
                storeDB.SaveChanges();

                EmptyCart();

                return order.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                    {
                        context.Session[CartSessionKey] =
                            context.User.Identity.Name;
                    }
                else
                    {
                        Guid tempCardId = Guid.NewGuid();
                        context.Session[CartSessionKey] = tempCardId.ToString();
                    }
            }
            return context.Session[CartSessionKey].ToString();
        }


        public void MigrateCart (string userName)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }

            storeDB.SaveChanges();

        }
    }
}