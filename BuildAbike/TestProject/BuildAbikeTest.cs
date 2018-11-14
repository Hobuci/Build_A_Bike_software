using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildAbike;



namespace TestProject
{
    [TestClass]
    public class BuildAbikeTest
    {
        public void LoadStock()
        {
            if (Stock.Items.Count == 0)
            {
                // Load in Stock
                Stock.Load();
            }
        }
        // Order price calculation
        [TestMethod]
        public void Order_Price_Calculation()
        {
            // Load in stock
            LoadStock();

            // Build bike
            string frameColour = "Red";
            string frameSize = "Large";
            int gearsBreaks = 101; // Group Set 1 (Shimano, Shimano)    Price: £199
            int wheels = 201; // Shimano    Price: £99
            int handlebarSaddle = 301; // Group Set 1 (Renthal FatBar, Prologo)     Price: £129
            bool warranty = false; // No extra warranty     Price: £0

            // Expected price
            double expectedPrice = 427;

            // Generate new order
            Order order = new Order(frameSize, frameColour, gearsBreaks, wheels, handlebarSaddle, warranty);

            // Actual price
            double actualPrice = order.getPrice();

            Assert.AreEqual(expectedPrice, actualPrice, 0, "Price not calculated correclty");
        }
        [TestMethod]
        public void Order_Price_Calculation_2()
        {
            // Load in stock
            LoadStock();

            // Build bike
            string frameColour = "Black";
            string frameSize = "Small";
            int gearsBreaks = 102; // Group Set 2 (SRAM, Avid)    Price: £299
            int wheels = 202; // Campagnolo    Price: £159
            int handlebarSaddle = 302; // Group Set 2 (Race Face, Fizik Arione)     Price: £199
            bool warranty = false; // No extra warranty     Price: £50

            // Expected price
            double expectedPrice = 657;

            // Generate new order
            Order order = new Order(frameSize, frameColour, gearsBreaks, wheels, handlebarSaddle, warranty);

            // Actual price
            double actualPrice = order.getPrice();

            Assert.AreEqual(expectedPrice, actualPrice, 0, "Price not calculated correclty");
        }

        [TestMethod]
        public void Order_Price_Calculation_With_Warranty()
        {
            // Load in stock
            LoadStock();

            // Build bike
            string frameColour = "Red";
            string frameSize = "Large";
            int gearsBreaks = 103; // Group Set 3 (Campagnolo, Clarks)    Price: £399
            int wheels = 203; // Zipp    Price: £209
            int handlebarSaddle = 303; // Group Set 3 (Ragley Wiser, Prologo)     Price: £259
            bool warranty = true; // Add extra warranty     Price: £50

            // Expected price
            double expectedPrice = 917;

            // Generate new order
            Order order = new Order(frameSize, frameColour, gearsBreaks, wheels, handlebarSaddle, warranty);

            // Actual price
            double actualPrice = order.getPrice();

            Assert.AreEqual(expectedPrice, actualPrice, 0, "Price not calculated correclty");
        }
        [TestMethod]
        public void Order_Price_Calculation_With_Warranty_2()
        {
            // Load in stock
            LoadStock();

            // Build bike
            string frameColour = "Blue";
            string frameSize = "Extra Small";
            int gearsBreaks = 101; // Group Set 1 (Shimano, Shimano)    Price: £199
            int wheels = 202; // Campagnolo    Price: £159
            int handlebarSaddle = 303; // Group Set 3 (Ragley Wiser, Prologo)     Price: £259
            bool warranty = true; // Add extra warranty     Price: £50

            // Expected price
            double expectedPrice = 667;

            // Generate new order
            Order order = new Order(frameSize, frameColour, gearsBreaks, wheels, handlebarSaddle, warranty);

            // Actual price
            double actualPrice = order.getPrice();

            Assert.AreEqual(expectedPrice, actualPrice, 0, "Price not calculated correclty");
        }

        // Item count decrease
        [TestMethod]
        public void Item_Count_Decrease()
        {
            // Load in stock
            LoadStock();

            // Decrease count of item 102
            // Current count 5
            int expectedCount = 4;

            // Decrease
            Stock.decreaseItemCount(102);

            // Actual price
            int actualCount = Stock.getItemCount(102);

            Assert.AreEqual(expectedCount, actualCount, 0, "Price not calculated correclty");
        }
    }
}
