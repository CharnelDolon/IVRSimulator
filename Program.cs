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
CallLogger logger = new CallLogger();
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
            Console.WriteLine("\n>> Sales Department");
            Console.WriteLine("[1] New Product Inquiry");
            Console.WriteLine("[2] Existing Order");
            Console.WriteLine("[0] Back to Main Menu");
            Console.Write("Select an option: ");
            string salesChoice = Console.ReadLine() ?? "invalid";
            switch (salesChoice)
            {
                case "1":
                    Console.WriteLine("\n>> Connecting to a Sales Representative...\n");
                    logger.Log(caller.Name, caller.PhoneNumber, "Sales", "New Product Inquiry"); // ✅
                    break;
                case "2":
                    Console.WriteLine("\n>> Pulling up your order. Please hold...\n");
                    logger.Log(caller.Name, caller.PhoneNumber, "Sales", "Existing Order"); // ✅
                    break;
                case "0":
                    Console.WriteLine("\n>> Returning to Main Menu...\n");
                    break;
                default:
                    Console.WriteLine("\n>> Invalid option.\n");
                    break;
            }
            break;

        case "2":
            Console.WriteLine("\n>> Technical Support");
            Console.WriteLine("[1] Software Issue");
            Console.WriteLine("[2] Hardware Issue");
            Console.WriteLine("[0] Back to Main Menu");
            Console.Write("Select an option: ");
            string techChoice = Console.ReadLine() ?? "invalid";
            switch (techChoice)
            {
                case "1":
                    Console.WriteLine("\n>> Connecting to Software Support...\n");
                    logger.Log(caller.Name, caller.PhoneNumber, "Technical Support", "Software Issue"); // ✅
                    break;
                case "2":
                    Console.WriteLine("\n>> Connecting to Hardware Support...\n");
                    logger.Log(caller.Name, caller.PhoneNumber, "Technical Support", "Hardware Issue"); // ✅
                    break;
                case "0":
                    Console.WriteLine("\n>> Returning to Main Menu...\n");
                    break;
                default:
                    Console.WriteLine("\n>> Invalid option.\n");
                    break;
            }
            break;

        case "3":
            Console.WriteLine("\n>> Billing Department");
            Console.WriteLine("[1] View Balance");
            Console.WriteLine("[2] Make a Payment");
            Console.WriteLine("[0] Back to Main Menu");
            Console.Write("Select an option: ");
            string billingChoice = Console.ReadLine() ?? "invalid";
            switch (billingChoice)
            {
                case "1":
                    Console.WriteLine("\n>> Fetching your balance...\n");
                    logger.Log(caller.Name, caller.PhoneNumber, "Billing", "View Balance"); // ✅
                    break;
                case "2":
                    Console.WriteLine("\n>> Redirecting to payment portal...\n");
                    logger.Log(caller.Name, caller.PhoneNumber, "Billing", "Make a Payment"); // ✅
                    break;
                case "0":
                    Console.WriteLine("\n>> Returning to Main Menu...\n");
                    break;
                default:
                    Console.WriteLine("\n>> Invalid option.\n");
                    break;
            }
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

// --- Class Definitions ---
class CallLogger
{
    private string _filePath = "call_log.csv";

    public CallLogger()
    {
        // Create the file with headers if it doesn't exist
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "Name,Phone,Department,SubOption,Timestamp\n");
        }
    }

    public void Log(string name, string phone, string department, string subOption)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string line = $"{name},{phone},{department},{subOption},{timestamp}\n";
        File.AppendAllText(_filePath, line);
    }

    public void PrintSummary(string name)
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine("       CALL SUMMARY");
        Console.WriteLine("==============================");

        string[] lines = File.ReadAllLines(_filePath);
        bool found = false;

        foreach (string line in lines)
        {
            if (line.StartsWith(name))
            {
                string[] parts = line.Split(',');
                Console.WriteLine($"  Dept: {parts[2]} | Option: {parts[3]} | Time: {parts[4]}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("  No activity recorded this session.");
        }

        Console.WriteLine("==============================\n");
    }
}

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