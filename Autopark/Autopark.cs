using System.Xml.Serialization;

namespace Lesson_1;

class MainClass
{
    public static void Main(string[] args)
    {
        PassenegerCar auto1 = new PassenegerCar("Benz", 100, 2012, 2);
        PassenegerCar auto2 = new PassenegerCar("Volga", 100000000, 988, 4);
        Truck truck1 = new Truck("Tesla", 100, 2018, "Zoomer", "Pendos", 60);
        Truck truck2 = new Truck("Kamaz", 100000000, 1861, "Aleksandr", "II", 1000000000);
        Autopark park = new Autopark(new List<Car>() {auto1, truck1, auto2, truck2});
        Console.WriteLine(park.ToString());
    }
}

class Car
{
    private string brend;
    private int power;
    private int productionYear;

    public Car(string brend, int power, int productionYear)
    {
        this.brend = brend;
        this.power = power;
        this.productionYear = productionYear;
    }

    public override string ToString()
    {
        return $"Brend: {brend}\nPower: {power}\nProduction year: {productionYear}";
    }
}

class PassenegerCar : Car
{
    private int numberOfPassengers;
    private Dictionary<string, int> repairBook = new Dictionary<string, int>();

    public PassenegerCar(string brend, int power, int productionYear, int numberOfPassengers) : base(brend, power, productionYear)
    {
        this.numberOfPassengers = numberOfPassengers;
    }

    public void AddToRepairBook(string sparePart, int yearOfChange)
    {
        repairBook.Add(sparePart, yearOfChange);
    }

    public int GetRepair(string sparePart)
    {
        int returnValue;
        repairBook.TryGetValue(sparePart, out returnValue);
        
        return returnValue;
    }

    public void PrintRepairBook()
    {
        foreach (var repair in repairBook)
        {
            Console.WriteLine($"Repair: {repair.Key} in age: {repair.Value}");
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nNumber of Passengers: {numberOfPassengers}";
    }
}

class Truck : Car
{
    private string name, surname;
    private int maxWeigthOfCargo;
    private Dictionary<string, int> currentCargo = new Dictionary<string, int>();
    public Truck(string brend, int power, int productionYear, string name, string surname, int maxWeigthOfCargo) : base(brend, power, productionYear)
    {
        this.name = name;
        this.surname = surname;
        this.maxWeigthOfCargo = maxWeigthOfCargo;
    }

    public void changeDriver(string name, string surname)
    {
        this.name = name;
        this.surname = surname;
    }

    public void AddCargo(string nameOfProduct, int weightOfProduct)
    {
        currentCargo.Add(nameOfProduct, weightOfProduct);
    }

    public void DeleteCargo(string nameOfProduct)
    {
        currentCargo.Remove(nameOfProduct);
    }

    public void PrintCargos()
    {
        foreach (var cargo in currentCargo)
        {
            Console.WriteLine($"Cargo: {cargo.Key} have weight: {cargo.Value}");
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nMax weight: {maxWeigthOfCargo}\nName: {name}\nSurname: {surname}";
    }
    
}

class Autopark
{
    private string name;
    private List<Car> listOfCars = new List<Car>();
    public Autopark(List<Car> listOfCars)
    {
        this.listOfCars = listOfCars;
    }

    public override string ToString()
    {
        string retStr = "";
        foreach (var car in listOfCars)
        {
            retStr += car.ToString() + "\n";
        }

        return retStr;
    }
}