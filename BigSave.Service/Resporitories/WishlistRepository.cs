﻿using BigSave.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using BigSave.Service.Resporitories.Base;
using BigSave.Service.Interfaces;
using BigSave.Data.Data.Data;

namespace BigSave.Service.Resporitories
{
    public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void AddProductToWishlist(int productId, string userName)
        {
            var wishlist = GetByUserName(userName);
            wishlist.AddItem(productId);
        }

        public Wishlist GetByUserName(string userName)
        {
            return GetByCondition(w => w.UserName == userName).FirstOrDefault();
        }
        public List<Product> GetProductInWishlist(string userName)
        {
            var products = new List<Product>();
            var wishlist = GetByCondition(w => w.UserName == userName).FirstOrDefault();
            if (wishlist != null)
            {
                var wishlistProducts = wishlist.WishlistProducts;
                foreach (var wl in wishlistProducts)
                {
                    products.Add(wl.Product);
                }
            }
            return products;
        }

        public void RemoveProductOutWishlist(int productId, string userName)
        {
            throw new System.NotImplementedException();
        }

        public int TotalProductInWishlist(string userName)
        {
            var products = GetProductInWishlist(userName);
            return products.Count;
        }

    }
}
