
//namespace ConsoleApp
//{
//    internal class UnitTests
//    {

//    }
//}

//// Implement unit tests that test different implementations of a shopping cart.

//[CustomFact]
//public void SampleTest()
//{
//    // Perform operations on '_shoppingCart'
//    _shoppingCart.AddProduct(1, 2);

//    // And assert
//    Assert.Throws<BusinessLogicException>(() => _shoppingCart.RemoveProduct(1, 6));
//}

//To check if the results are as expeceted, use the following assertion methods:
//Assert.Throws<Exception>(() => /* Testing code */ );
//Assert.True(value);
//Assert.False(value);
//Assert.Equal(expected, actual);
//Assert.NotEqual(expected, actual);

//Please use the build-in implementation of IproductRepository. The repository returns products listed below:

//    | Id | Name | AvailableQuantity | UnitPrice |
//    | --| ---------------| ------------------| ---------|
//    | 1 | Orange juice | 10 | 1 |
//    | 2 | Apple juice | 12 | 3 |
//    | 3 | Pineapple juice | 14 | 5 |
//    | 4 | Banana juice | 16 | 7 |
//    | 5 | Cherry juice | 18 | 9 |



//    A correct implementation of IShoppingCard should support the following conditions:

//    Add products only form IProductRepository. The user cannot adda product that does not belong to IProductRepository. All products are added to IShoppingCart using the Id.

//     - if this Assertion Requirement is not fullfilled the CannotAddProducctNotBelongingToRepository exception should be thrown.

//    Add only a Positive quantity of products(exclude DivideByZeroException and negative numebrs)
//    - If this is not fullfiled QuantityCannotBeNegativeException should be thrown

//    Add only a quantity of products that is lower or equal to the number available
//    - if this is not fullfilled  HigherQuantityAddedThanAvailableException should be thrown

//    BE able to removbe from the sopping cart only previously added products
//    - If this is not fullfilled CannotRemoveHigherQuantityThanAddedException should be thrown

//    Remove only positive quantity of products from the shopping cart (exclude zero and negative numebrs)
//         - If this is not fullfille QuantityCannotBeNegativeException should be thrown

//    Remove from the shopping cart as quantity of products that is no higher than the nuymber added
//         - If this is not fullfilled CannotRemoveHigherQuantityThanAddedException sholud be thrown

//    Remove product from IShoppingCart if its quantity decreases to zero
//    Sum the added quantities of the same product (in case abstract product is added multiple times)
//    Return added products (the above condition sholud also be matched)
//    Return total value of added products (quantity * price)
//    Clear shopping cart

//    If the above-listed requirements are not fulfilled by the SHoppingCart implementation, it shoulud throw BusinessLogicException Exception.