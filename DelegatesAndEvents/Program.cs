
// Amir Moeini Rad
// August 15, 2025
// Help from ChatGPT

// Main Concept: Defining events by using delegates.
// The event is automatically triggered when a property is set.


namespace EventsAndDelegatesExample
{
    // Step (1): Define a delegate with a specific signature for the event.
    // Delegates are defined at the namespace level.
    // This delegate will hold the reference to a method (an event handler) with the following signature.
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);


    /////////////////////////////////
    

    // Step (2): Create a class with an event based on the delegate.
    // This class is the publisher class. The class that raises the event.
    public class Stock
    {
        private decimal _price;
        public event PriceChangedHandler? PriceChanged;


        // Constructor to initialize the stock with a price.
        public Stock(decimal price)
        {
            _price = price;
        }


        // Property to get and set the stock price.
        public decimal Price
        {
            get { return _price; }

            set
            {
                if (_price != value)
                {
                    // Raise the event only if there is a change in price.
                    // Use null-conditional operator '?' to check for subscribers.
                    PriceChanged?.Invoke(_price, value);  
                    _price = value;
                }
            }
        }
    }


    /////////////////////////////////
    

    // Step (3): Create a class that subscribes to the event and handles it.
    public class StockObserver
    {
        // The actual event handler (callable entity)
        public void OnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"Stock price changed from {oldPrice} to {newPrice}");
        }
    }


    /////////////////////////////////
    

    // Testing the setup
    class Program
    {
        static void Main()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Events and Delegates in C#.NET...");
            Console.WriteLine("---------------------------------\n");


            // Instantiate the stock (publisher) and observer (subscriber) objects.
            Stock stock = new Stock(100);
            StockObserver observer = new StockObserver();


            // Subscribe the observer's method (event handler) to the stock's PriceChanged event.
            // Installing the event.
            stock.PriceChanged += observer.OnPriceChanged;


            // Change the price to trigger the event.
            stock.Price = 105;
            stock.Price = 110;


            Console.WriteLine("\nDone.");
        }
    }
}

/*

Key Takeaways:

    (*) A delegate defines the signature for methods that can handle an event.
    (*) An event is a delegate type field with additional restrictions to control how and when it can be invoked.
    (*) The publisher raises the event to notify subscribers (event handlers) of certain occurrences.
 
*/