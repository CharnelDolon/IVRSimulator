// IVR Simulator - ComputerTalk Interview Project

// --- Program starts here ---
Console.WriteLine("==============================");
Console.WriteLine(" Welcome to ComputerTalk IVR ");
Console.WriteLine("==============================");
Console.Write("Enter your name: ");
string callerName = Console.ReadLine() ?? "Guest";
Console.Write("Enter your phone number: ");
string callerPhone = Console.ReadLine() ?? "Unknown";

Caller caller = new Caller(callerName, callerPhone);
Console.WriteLine($"\nThank you, {caller.Name}. Connecting you now...\n");

// --- Main Menu ---
bool running = true;

while (running)
{
    Console.WriteLine("------------------------------");
    Console.WriteLine("        MAIN MENU");
    Console.WriteLine("------------------------------");
    Console.WriteLine("[1] Sales");
    Console.WriteLine("[2] Technical Support");
    Console.WriteLine("[3] Billing");
    Console.WriteLine("[0] Exit");
    Console.WriteLine("------------------------------");
    Console.Write("Select an option: ");

    string choice = Console.ReadLine() ?? "invalid";

    switch (choice)
    {
        case "1":
            Console.WriteLine("\n>> Routing to Sales...\n");
            break;
        case "2":
            Console.WriteLine("\n>> Routing to Technical Support...\n");
            break;
        case "3":
            Console.WriteLine("\n>> Routing to Billing...\n");
            break;
        case "0":
            Console.WriteLine($"\nThank you for calling, {caller.Name}. Goodbye!\n");
            running = false;
            break;
        default:
            Console.WriteLine("\n>> Invalid option. Please try again.\n");
            break;
    }
}

// --- Class definitions go at the BOTTOM ---
class Caller
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Caller(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}