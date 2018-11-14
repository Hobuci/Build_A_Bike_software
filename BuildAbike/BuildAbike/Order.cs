namespace BuildAbike
{
    public class Order
    {
        private string frameSize;
        private string frameColour;
        private int gearsBreaks;
        private int wheels;
        private int handlebarSaddle;
        private bool warranty;
        private double price;

        public Order(string frameSize, string frameColour, int gearsBreaks, int wheels, int handlebarSaddle, bool warranty)
        {
            this.frameSize = frameSize;
            this.frameColour = frameColour;
            this.GearsBreaks = gearsBreaks;
            this.Wheels = wheels;
            this.HandlebarSaddle = handlebarSaddle;
            this.warranty = warranty;
        }

        public int GearsBreaks { get => gearsBreaks; set => gearsBreaks = value; }
        public int Wheels { get => wheels; set => wheels = value; }
        public int HandlebarSaddle { get => handlebarSaddle; set => handlebarSaddle = value; }

        public double getPrice()
        {// Return price of order
            // Get component prices
            price = Stock.getItemPrice(GearsBreaks) +
                    Stock.getItemPrice(Wheels) +
                    Stock.getItemPrice(HandlebarSaddle);
            if (warranty)
            {// Add warranty if needed
                price += 50;
            }

            return price;
        }
    }
}
