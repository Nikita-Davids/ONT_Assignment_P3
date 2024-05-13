using System;
using static SixtyFivePeopleMax;

// Observer interface
public interface IObserver
{
    void Update(string message);
}

// Subject class
public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    // Attach an observer
    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    // Detach an observer
    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    // Notify all observers
    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

// Concrete implementation of technician
public class Technician : IObserver
{
    private string name;

    public Technician(string name)
    {
        this.name = name;
    }

    // Update method to receive notifications
    public void Update(string message)
    {
        Console.WriteLine($"Technician {name} received message: {message}");
    }
}
// Abstract class for Vehicle Name
public abstract class Vehiclev
{
    public abstract string Name();
}

// Abstract class for carrier capability
public abstract class Carrier
{
    public abstract string Carry();
}

// Abstract class for engine size
public abstract class Engine
{
    public abstract string Power();
}

// Abstract class for towing capability
public abstract class Towing
{
    public abstract string Tow();
}

// Abstract class for additional features
public abstract class Feature
{
    public abstract int Cost();
    public abstract string Description();
}

// Concrete implementation of a vehicle
public class Vehicle
{
    public Vehiclev VehicleName { get; set; }
    public Carrier CarrierCapability { get; set; }
    public Engine Engine { get; set; }
    public Towing TowingCapability { get; set; }
    public object VehicleCapabilities { get; set; }
    

    protected List<Feature> additionalFeatures = new List<Feature>();
    public Subject subject = new Subject();

    // Constructor to initialize vehicle capabilities
    public Vehicle(Vehiclev vehicle, Carrier carrier, Engine engine, Towing towing)
    {
        VehicleName = vehicle;
        CarrierCapability = carrier;
        Engine = engine;
        TowingCapability = towing;
    }

    // Assemble the vehicle
    public void Assemble()
    {
        // Assemble the vehicle
        Console.WriteLine("Assembling vehicle...");
    }

    // Add a feature to the vehicle
    public void AddFeature(Feature feature)
    {
        additionalFeatures.Add(feature);
        NotifyTechnicians($"Feature '{feature.Description()}' added to the vehicle.");
    }

    public string GetDescription()
    {
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("BRIEF");
        Console.WriteLine("---------------------------------------------------------------------");

        // Generate description including all features
        string description = $"{VehicleName.Name()} with {CarrierCapability.Carry()} capability, {Engine.Power()} engine, {TowingCapability.Tow()} towing";

        // Display the description
        Console.WriteLine(description);

        // Ask the decorator question
        string decoratorQuestion = DecoratorQuestion();
        Console.WriteLine(decoratorQuestion);

        // Get user input
       bool  userInput = GetUserInput();

        return description;
    }
    public string DecoratorQuestion()
    {
        Console.WriteLine("------------------------------------------------------------------------");
        string decoratorQuestion = $"Would you like to add additions to {VehicleName.Name()} ,Yes or No? ";

        return decoratorQuestion;
    }
    public bool GetUserInput()
    {
        string userInput = Console.ReadLine()?.ToLower();

        while (userInput != "yes" && userInput != "no")
        {
            Console.WriteLine("Please enter 'yes' or 'no'.");
            userInput = Console.ReadLine()?.ToLower();
        }
        if (userInput == "yes")
        {
            if (VehicleName.Name() == "MotorBike")
            {
                Console.WriteLine("Options for MotorBike:");
                Console.WriteLine("1.Adding Sound System: R1000");
                Console.WriteLine("• Adding Wi-Fi: R750");
                Console.WriteLine("• Adding Camera: R200");
            }
            else if (VehicleName.Name() == "Light Motor Vehicle")
            {
                Console.WriteLine("Options for Light Motor Vehicle:");
                Console.WriteLine("• Adding Sound System: R1200 ");
                Console.WriteLine("• Adding Wi-Fi: R950");
                Console.WriteLine("• Adding Camera: R400");


            }
            else if (VehicleName.Name() == "Heavy Motor Vehicle")
            {
                Console.WriteLine("Options for Heavy Vehicle:");
                Console.WriteLine("• Adding Sound System: R1400 ");
                Console.WriteLine("• Adding Wi-Fi: R1000");
                Console.WriteLine("• Adding Camera: R600");



            }
          


        }
        else {
            Environment.Exit(0); 
        }
        return false;
    }
 
    // Notify technicians about changes
    private void NotifyTechnicians(string message)
    {
        subject.Notify(message);
    }
}

// Concrete implementation of a sound system feature
public class SoundSystem : Feature
{
    protected Feature baseFeature;

    public SoundSystem(Feature baseFeature)
    {
        this.baseFeature = baseFeature;
    }

    // Calculate cost including the base feature
    public override int Cost()
    {
        return (baseFeature != null ? baseFeature.Cost() : 0) + 1000; // Example cost for adding a sound system
    }

    // Generate description including the base feature
    public override string Description()
    {
        return (baseFeature != null ? baseFeature.Description() : "") + ", Sound System";
    }
}

// Concrete implementation of a Wi-Fi feature
public class WiFi : Feature
{
    protected Feature baseFeature;

    public WiFi(Feature baseFeature)
    {
        this.baseFeature = baseFeature;
    }

    // Calculate cost including the base feature
    public override int Cost()
    {
        return baseFeature.Cost() + 750; // Example cost for adding Wi-Fi
    }

    // Generate description including the base feature
    public override string Description()
    {
        return baseFeature.Description() + ", Wi-Fi";
    }
}

// Concrete implementation of an assist camera feature
public class AssistCamera : Feature
{
    protected Feature baseFeature;

    public AssistCamera(Feature baseFeature)
    {
        this.baseFeature = baseFeature;
    }

    // Calculate cost including the base feature
    public override int Cost()
    {
        return baseFeature.Cost() + 200; // Example cost for adding an assist camera
    }

    // Generate description including the base feature
    public override string Description()
    {
        return baseFeature.Description() + ", Assist Camera";
    }
}
// Concrete implementation of Vehicle name
public class MotorBike : Vehiclev
{
    public override string Name()
    {
        return "MotorBike";
    }
}
public class LightWeightVehicle : Vehiclev
{
    public override string Name()
    {
        return "Light Motor Vehicle";
    }
}
public class HeavyWeightVehicle : Vehiclev
{
    public override string Name()
    {
        return "Heavy Motor Vehicle";
    }
}

// Concrete implementation of carrier capabilities
public class GoodAndDriver : Carrier
{
    public override string Carry()
    {
        return "Good and Driver";
    }
}

public class TwoPeopleMaxAndBag : Carrier
{
    public override string Carry()
    {
        return "2 people max, and bag";
    }
}

public class TwentyPeopleMax : Carrier
{
    public override string Carry()
    {
        return "20 people max";
    }
}

public class FivePeopleMaxFewLuggage : Carrier
{
    public override string Carry()
    {
        return "5 people max and few luggage";
    }
}

// Concrete strategy for 65 People Max carrier
public class SixtyFivePeopleMax : Carrier
{
    public override string Carry()
    {
        return "65 people max";
    }
}

    // Concrete implementation of engine sizes
    public class SmallEngine : Engine
    {
        public override string Power()
        {
            return "Small";
        }
    }

    public class MediumEngine : Engine
    {
        public override string Power()
        {
            return "Medium";
        }
    }

    public class LargeEngine : Engine
    {
        public override string Power()
        {
            return "Large";
        }
    }

    public class ExtraLargeEngine : Engine
    {
        public override string Power()
        {
            return "Extra Large";
        }
    }

    // Concrete implementation of towing capabilities
    public class CanTow : Towing
    {
        public override string Tow()
        {
            return "Can Tow";
        }
    }

    public class CannotTow : Towing
    {
        public override string Tow()
        {
            return "Cannot Tow";
        }
    }

    // Strategy interface for vehicle type
    public interface IVehicleTypeStrategy
    {
        void SetVehicleCapabilities(Vehicle vehiclev);
    }

    // Concrete strategy for motorbike
    public class MotorbikeStrategy : IVehicleTypeStrategy
    {
        public void SetVehicleCapabilities(Vehicle vehiclev)
        {
            vehiclev.VehicleName = new MotorBike();
            vehiclev.CarrierCapability = new GoodAndDriver();
            vehiclev.Engine = new SmallEngine();
            vehiclev.TowingCapability = new CannotTow();
        }
    }

    // Concrete strategy for lightweight vehicle
    public class LightWeightVehicleStrategy : IVehicleTypeStrategy
    {
        public void SetVehicleCapabilities(Vehicle vehiclev)
        {
            vehiclev.VehicleName = new LightWeightVehicle();
            vehiclev.CarrierCapability = new TwoPeopleMaxAndBag();
            vehiclev.Engine = new MediumEngine();
            vehiclev.TowingCapability = new CannotTow();
        }
    }

    // Concrete strategy for heavy vehicle
    public class HeavyVehicleStrategy : IVehicleTypeStrategy
    {
        public void SetVehicleCapabilities(Vehicle vehiclev)
        {
            vehiclev.VehicleName = new HeavyWeightVehicle();
            vehiclev.CarrierCapability = new TwentyPeopleMax();
            vehiclev.Engine = new LargeEngine();
            vehiclev.TowingCapability = new CanTow();
        }
    }
    // Strategy interface for vehicle name
    public interface IVehicleNameStrategy
    {
        Vehiclev SetVehicleName();
    }

    // Strategy interface for carrier capability
    public interface ICarrierStrategy
    {
        Carrier SetCarrierCapability();
    }

    // Strategy interface for engine size
    public interface IEngineStrategy
    {
        Engine SetEngineSize();
    }

    // Strategy interface for towing capability
    public interface ITowingStrategy
    {
        Towing SetTowingCapability();
    }

    // Concrete strategy for MotorBike name
    public class MotorBikeStrategy : IVehicleNameStrategy
{
        public Vehiclev SetVehicleName()
        {
            return new MotorBike();
        }
    }
        // Concrete strategy for LightMotorVehicle name
        public class LightMotorVehicleStrategy : IVehicleNameStrategy
{
            public Vehiclev SetVehicleName()
            {
                return new LightWeightVehicle();
            }
        }
        // Concrete strategy for LightMotorVehicle name
        public class HeavyMotorVehicleStrategy : IVehicleNameStrategy
{
            public Vehiclev SetVehicleName()
            {
                return new HeavyWeightVehicle();
            }
        }

        // Concrete strategy for Good and Driver carrier
        public class GoodAndDriverStrategy : ICarrierStrategy
        {
            public Carrier SetCarrierCapability()
            {
                return new GoodAndDriver();
            }
        }

        // Concrete strategy for Two People Max and Bag carrier
        public class TwoPeopleMaxAndBagStrategy : ICarrierStrategy
        {
            public Carrier SetCarrierCapability()
            {
                return new TwoPeopleMaxAndBag();
            }
        }

        // Concrete strategy for Twenty People Max carrier
        public class TwentyPeopleMaxStrategy : ICarrierStrategy
        {
            public Carrier SetCarrierCapability()
            {
                return new TwentyPeopleMax();
            }
        }
        // Concrete strategy for 5 People Max and Few Luggage carrier
        public class FivePeopleMaxFewLuggageStrategy : ICarrierStrategy
        {
            public Carrier SetCarrierCapability()
            {
                return new FivePeopleMaxFewLuggage();
            }
        }

        // Concrete strategy for 65 People Max carrier
        public class SixtyFivePeopleMaxStrategy : ICarrierStrategy
        {
            public Carrier SetCarrierCapability()
            {
                return new SixtyFivePeopleMax();
            }
        }


        // Concrete strategy for Small engine size
        public class SmallEngineStrategy : IEngineStrategy
        {
            public Engine SetEngineSize()
            {
                return new SmallEngine();
            }
        }

        // Concrete strategy for Medium engine size
        public class MediumEngineStrategy : IEngineStrategy
        {
            public Engine SetEngineSize()
            {
                return new MediumEngine();
            }
        }

        // Concrete strategy for Large engine size
        public class LargeEngineStrategy : IEngineStrategy
        {
            public Engine SetEngineSize()
            {
                return new LargeEngine();
            }
        }

        // Concrete strategy for Extra Large engine size
        public class ExtraLargeEngineStrategy : IEngineStrategy
        {
            public Engine SetEngineSize()
            {
                return new ExtraLargeEngine();
            }
        }

        // Concrete strategy for Can Tow towing capability
        public class CanTowStrategy : ITowingStrategy
        {
            public Towing SetTowingCapability()
            {
                return new CanTow();
            }
        }

        // Concrete strategy for Cannot Tow towing capability
        public class CannotTowStrategy : ITowingStrategy
        {
            public Towing SetTowingCapability()
            {
                return new CannotTow();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {

                IVehicleTypeStrategy vehicleTypeStrategy = null;
                ICarrierStrategy carrierStrategy = null;
                IEngineStrategy engineStrategy = null;
                ITowingStrategy towingStrategy = null;
                while (true)
                {
                    // Prompt user to choose vehicle type
                    Console.WriteLine("Choose a vehicle type:");
                    Console.WriteLine("1. Motorbike");
                    Console.WriteLine("2. Light Weight Vehicle");
                    Console.WriteLine("3. Heavy Vehicle");
                    Console.Write("Enter your choice (1/2/3):\n ");
                    Console.Write("------------------------------------ \n");
                    string choice = Console.ReadLine();

                    // Set the vehicle type strategy based on user's choice
                    switch (choice)
                    {
                        case "1":
                            vehicleTypeStrategy = new MotorbikeStrategy();
                            break;
                        case "2":
                            vehicleTypeStrategy = new LightWeightVehicleStrategy();
                            break;
                        case "3":
                            vehicleTypeStrategy = new HeavyVehicleStrategy();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            continue; // Restart the loop to ask the question again
                    }
                    break; // Break out of the loop if a valid choice is made
                }

                // Create a vehicle
                Vehicle vehicle = new Vehicle(null, null, null, null);

                // Set vehicle capabilities using the selected vehicle type strategy
                vehicleTypeStrategy.SetVehicleCapabilities(vehicle);

                while (true)
                {
                    // Prompt user to choose carrier capability
                    Console.WriteLine("\nChoose a carrier capability:");
                    Console.WriteLine("1. Good and Driver");
                    Console.WriteLine("2. 2 People Max ,and Bag");
                    Console.WriteLine("3. 5 people max and few luggage");
                    Console.WriteLine("4. 2 People Max ,and Bag");
                    Console.WriteLine("5. 65 people max");

                    Console.Write("Enter your choice (1/2/3/4/5: \n");
                    Console.Write("------------------------------------\n");
                    string carrierChoice = Console.ReadLine();

                    // Set the carrier strategy based on user's choice
                    switch (carrierChoice)
                    {
                        case "1":
                            carrierStrategy = new GoodAndDriverStrategy();
                            break;
                        case "2":
                            carrierStrategy = new TwoPeopleMaxAndBagStrategy();
                            break;
                        case "3":
                            carrierStrategy = new FivePeopleMaxFewLuggageStrategy();
                            break;
                        case "4":
                            carrierStrategy = new TwentyPeopleMaxStrategy();
                            break;
                        case "5":
                            carrierStrategy = new SixtyFivePeopleMaxStrategy();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            continue; // Restart the loop to ask the question again
                    }
                    break; // Break out of the loop if a valid choice is made
                }

                // Set carrier capability using the selected strategy
                vehicle.CarrierCapability = carrierStrategy.SetCarrierCapability();
                while (true)
                {

                    // Prompt user to choose engine size
                    Console.WriteLine("\nChoose an engine size:");
                    Console.WriteLine("1. Small");
                    Console.WriteLine("2. Medium");
                    Console.WriteLine("3. Large");
                    Console.WriteLine("4. Extra Large");
                    Console.Write("Enter your choice (1/2/3/4): \n");
                    Console.Write("------------------------------------ \n");
                    string engineChoice = Console.ReadLine();

                    // Set the engine strategy based on user's choice
                    switch (engineChoice)
                    {
                        case "1":
                            engineStrategy = new SmallEngineStrategy();
                            break;
                        case "2":
                            engineStrategy = new MediumEngineStrategy();
                            break;
                        case "3":
                            engineStrategy = new LargeEngineStrategy();
                            break;
                        case "4":
                            engineStrategy = new ExtraLargeEngineStrategy();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            continue; // Restart the loop to ask the question again
                    }
                    break; // Break out of the loop if a valid choice is made
                }

                // Set engine size using the selected strategy
                vehicle.Engine = engineStrategy.SetEngineSize();
                while (true)
                {
                    // Prompt user to choose towing capability
                    Console.WriteLine("\nChoose a towing capability:");
                    Console.WriteLine("1. Can Tow");
                    Console.WriteLine("2. Cannot Tow");
                    Console.Write("Enter your choice (1/2): \n");
                    Console.Write("------------------------------------ \n");
                    string towingChoice = Console.ReadLine();

                    // Set the towing strategy based on user's choice
                    switch (towingChoice)
                    {
                        case "1":
                            towingStrategy = new CanTowStrategy();
                            break;
                        case "2":
                            towingStrategy = new CannotTowStrategy();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            continue; // Restart the loop to ask the question again
                    }
                    break; // Break out of the loop if a valid choice is made
                }

                // Set towing capability using the selected strategy
                vehicle.TowingCapability = towingStrategy.SetTowingCapability();

                // Assemble the vehicle
                vehicle.Assemble();

                // Add features dynamically
                Feature baseFeature = new WiFi(new AssistCamera(new SoundSystem(null)));
                vehicle.AddFeature(baseFeature);

                // Get the description of the vehicle
                string description = vehicle.GetDescription();
                //Console.WriteLine(description);                
            }
        }

    