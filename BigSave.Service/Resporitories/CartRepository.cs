﻿using System.Collections.Generic;
using System.Linq;
using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {

        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public Cart GetByUserName(string userName)
        {
            return GetByCondition(c => c.UserName == userName).FirstOrDefault();
        }
        public List<Product> GetProductInCart(string userName)
        {
            var result = new List<Product>();
            var cart = GetByUserName(userName);
            foreach (var cartItem in cart.CartItems)
            {
                result.Add(cartItem.Product);
            }
            return result;
        }
        public int TotalProductInCart(string userName)
        {
            var products = GetProductInCart(userName);
            return products.Count;
        }
        public Cart GetExistingOrCreateNewCart(string userName)
        {
            var cart = GetByCondition(c => c.UserName == userName).FirstOrDefault();
            if (cart != null)
                return cart;
            var newCart = new Cart
            {
                UserName = userName
            };
            Add(newCart);
            return newCart;
        }
    }
}
