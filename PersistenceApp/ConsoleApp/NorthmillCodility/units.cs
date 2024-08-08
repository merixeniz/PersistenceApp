/*
    ShoppingCart that should be tested by unit tests that you need to prepare.
*/
public interface IShoppingCart
{
    // Add requested quantity of a product to shoppingCart
    void AddProduct(int productId, int quantity);
    // Remove requested quantity of a product from shoppingCart
    void RemoveProduct(int productId, int quantity);
    // Get ShoppingCart items and their quantity
    IList<ShoppingCartItem> GetShoppingCartItems();
    // Get total value of ShoppingCart (sum of Quantity * UnitPrice for each added product)
    int GetTotal();
    // Clear shopping cart
    void Clear();
}

/*
    Already implemented mock ProductRepository.
    Returned data is described below.
*/
public interface IProductRepository
{
    IList<Product> GetProducts();
}

/*
    Product returned by ProductRepository
*/
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AvailableQuantity { get; set; }
    public int UnitPrice { get; set; }
}

/*
    Shopping Cart Item
*/
public class ShoppingCartItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
}

/*
    This exception should be thrown by ShoppingCart class when conditions are not fulfilled;
    for example, when one tries to add a negative quantity of a product.
*/
public class QuantityCannotBeNegativeException : Exception { }

public class CannotAddProductNotBelongingToRepository : Exception { }

public class HigherQuantityAddedThanAvailableException : Exception { }

public class CannotRemoveHigherQuantityThanAddedException : Exception { }


////////////

using System;
using System.Collections.Generic;
using System.Linq;
using Codility.Tasks.BasketUnitTests.Source;
using Xunit;

namespace ConsoleApp.NorthmillCodility
{
    public class ShoppingCartUnitTests
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartUnitTests(IShoppingCart shoppingCart)
        {
            // Console.WriteLine("Sample debug output");
            _shoppingCart = shoppingCart;
        }

        [CustomFact]
        public void AddProduct_NotInRepository_ShouldThrowCannotAddProductNotBelongingToRepository()
        {
            Assert.Throws<CannotAddProductNotBelongingToRepository>(() => _shoppingCart.AddProduct(10, 1));
        }

        [CustomFact]
        public void AddProduct_NegativeQuantity_ShouldThrowQuantityCannotBeNegativeException()
        {
            Assert.Throws<QuantityCannotBeNegativeException>(() => _shoppingCart.AddProduct(1, 0));
            Assert.Throws<QuantityCannotBeNegativeException>(() => _shoppingCart.AddProduct(1, -1));
        }

        [CustomFact]
        public void AddProduct_QuantityHigherThanAvailable_ShouldThrowHigherQuantityAddedThanAvailableException()
        {
            Assert.Throws<HigherQuantityAddedThanAvailableException>(() => _shoppingCart.AddProduct(1, 11));
        }

        [CustomFact]
        public void RemoveProduct_NotInCart_ShouldThrowCannotRemoveHigherQuantityThanAddedException()
        {
            Assert.Throws<CannotRemoveHigherQuantityThanAddedException>(() => _shoppingCart.RemoveProduct(1, 1));
        }

        [CustomFact]
        public void RemoveProduct_NegativeQuantity_ShouldThrowQuantityCannotBeNegativeException()
        {
            _shoppingCart.AddProduct(1, 2);
            Assert.Throws<QuantityCannotBeNegativeException>(() => _shoppingCart.RemoveProduct(1, 0));
            Assert.Throws<QuantityCannotBeNegativeException>(() => _shoppingCart.RemoveProduct(1, -1));
        }

        [CustomFact]
        public void RemoveProduct_HigherQuantityThanAdded_ShouldThrowCannotRemoveHigherQuantityThanAddedException()
        {
            _shoppingCart.AddProduct(1, 2);
            Assert.Throws<CannotRemoveHigherQuantityThanAddedException>(() => _shoppingCart.RemoveProduct(1, 3));
        }

        [CustomFact]
        public void RemoveProduct_ValidQuantity_ShouldRemoveFromCart()
        {
            _shoppingCart.AddProduct(1, 2);
            _shoppingCart.RemoveProduct(1, 1);
            var items = _shoppingCart.GetShoppingCartItems();
            Assert.Equal(1, items.Count);
            Assert.Equal(1, items[0].ProductId);
            Assert.Equal(1, items[0].Quantity);
        }

        [CustomFact]
        public void RemoveProduct_QuantityToZero_ShouldRemoveProductFromCart()
        {
            _shoppingCart.AddProduct(1, 2);
            _shoppingCart.RemoveProduct(1, 2);
            var items = _shoppingCart.GetShoppingCartItems();
            Assert.Equal(0, items.Count);
        }

        [CustomFact]
        public void AddProduct_SameProductMultipleTimes_ShouldSumQuantities()
        {
            _shoppingCart.AddProduct(1, 2);
            _shoppingCart.AddProduct(1, 3);
            var items = _shoppingCart.GetShoppingCartItems();
            Assert.Equal(1, items.Count);
            Assert.Equal(5, items[0].Quantity);
        }

        [CustomFact]
        public void GetTotal_ShouldReturnCorrectTotalValue()
        {
            _shoppingCart.AddProduct(1, 2);
            _shoppingCart.AddProduct(2, 3);
            int total = _shoppingCart.GetTotal();
            Assert.Equal(2 * 1 + 3 * 3, total);
        }

        [CustomFact]
        public void Clear_ShouldEmptyTheCart()
        {
            _shoppingCart.AddProduct(1, 2);
            _shoppingCart.Clear();
            var items = _shoppingCart.GetShoppingCartItems();
            Assert.Equal(0, items.Count);
        }

        [CustomFact]
        public void ShouldReturnItems()
        {
            _shoppingCart.AddProduct(1, 2);
            _shoppingCart.AddProduct(2, 3);

            var items = _shoppingCart.GetShoppingCartItems();

            Assert.Equal(2, items.Count);

            Assert.Equal(1, items[0].ProductId);
            Assert.Equal(2, items[0].Quantity);
            Assert.Equal(1, items[0].UnitPrice);


            Assert.Equal(2, items[1].ProductId);
            Assert.Equal(3, items[1].Quantity);
            Assert.Equal(3, items[1].UnitPrice);
        }

        // TODO:
        // Prepare your unit tests here. You can find a sample test and class models below. Good luck!

        /* Sample test */
        /*
        [CustomFact]
        public void ShoppingCartShouldBeImplemented()
        {
            // TODO - Assertions

            Assert.Throws<Exception>(() =>  Testing code is here);
            Assert.True(value);
            Assert.False(value);
            Assert.Equal(expected, actual);
            Assert.NotEqual(expected, actual);
        }
        */
    }
}
