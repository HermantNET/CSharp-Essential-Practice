using System;

public class UnitConverter
{
    int ratio;
    public UnitConverter(int unitRatio) { ratio = unitRatio; }
    public int Convert(int unit) { return unit * ratio; }
}

public class Owl {
    string name;
    int hootFrequency;
    int hoots = 0;

    public Owl (string strName, int intHootFrequency) { name = strName; hootFrequency = intHootFrequency; } //Constructor

    public string Name { get { return name; } }

    public void hoot() {
        for (int i = 0; i < hootFrequency; i++, hoots++) {
            System.Threading.Thread.Sleep(100);
            if (hoots % 2 == 0) { Console.WriteLine("Hoot!"); } else { Console.WriteLine("Hoot! " + i.ToString()); }          
        }
    }

    public string Hoots() {
        return hoots.ToString();
    }
}
class Test {
    static void OptionalTest(int a = 0, int b = 0)
    {
        Console.WriteLine($"int a = {a.ToString()}\nint b = {b.ToString()}");
    }

    //Main method
    static void Main() {
    start:
        Console.WriteLine("1: Owl         | 2: Unit Converter | 3: Swap & Lambda\n" +
                          "4: WuXiXiao    | 5: Plus Me        | 6: Stack\n" +
                          "7: Publication |");
        Console.WriteLine();
        int CaseSwitch;

        parse:
        if (int.TryParse(Console.ReadLine(), out CaseSwitch)) {
            switch (CaseSwitch)
            {
                case 1:
                    Owlbro();
                    break;
                case 2:
                    UnitBro();
                    break;
                case 3:
                    SwapLambdaBro();
                    break;
                case 4:
                    WuXiXiaoBro();
                    break;
                case 5:
                    PlusMeBro();
                    break;
                case 6:
                    StackBro();
                    break;
                case 7:
                    PublicationBro();
                    break;
                default:
                    Console.WriteLine("Selection does not exist.");
                    break;
            }
        } else {
            Console.WriteLine("Invalid selection.");
            goto parse; }

        Console.WriteLine();
        Console.WriteLine("Continue? y/n");
        if (Console.ReadLine() == "y") { goto start; } else { Environment.Exit(0); }
    }

    //Making owls
    public static void Owlbro()
    {
        owlstart:
        Console.WriteLine("Owl name: ");
        string owlName = Console.ReadLine();

        try
        {
            Console.WriteLine("Owl hoots: ");
            int owlHoots = int.Parse(Console.ReadLine());
            Owl owl1 = new Owl(owlName, owlHoots);

            hoot:
            owl1.hoot();
            Console.WriteLine($"Owl {owl1.Name} has hooted {owl1.Hoots()} times.");
            Console.WriteLine("Hoot again? y/n");
            if (Console.ReadLine() == "y") { goto hoot; }
        }
        catch { Console.WriteLine("Please enter an integer."); goto owlstart; }
    }

    //Unit Converter
    public static void UnitBro()
    {
        UnitConverter feetToInchesConverter = new UnitConverter(12); //Feet to Inches
        UnitConverter milesToFeetConverter = new UnitConverter(5280); //Miles to Feet

        Console.WriteLine($"There is {feetToInchesConverter.Convert(30)} inches in 30 feet.");
        Console.WriteLine($"There is {feetToInchesConverter.Convert(100)} inches in 100 feet.");
        Console.WriteLine($"There is {feetToInchesConverter.Convert(milesToFeetConverter.Convert(1))} inches in 1 mile.");
    }

    //simple variable swap and lambda expression
    public static void SwapLambdaBro()
    {
        string a = "Apple";
        string b = "Pear";
        bool c;

        Console.WriteLine("Please enter 'a' or 'b'");
        string d = Console.ReadLine();

        if (d == "a") { c = true; } else { c = false; };
        Console.WriteLine(c ? a : b);

        Console.WriteLine("Please enter an integer.");
        d = Console.ReadLine();
        OptionalTest(int.Parse(d));

        Console.WriteLine("Please enter an integer.");
        d = Console.ReadLine();
        OptionalTest(0, int.Parse(d));
    }

    public static void WuXiXiaoBro()
    {
        WuXiXiao.XiaoWu Wolf = new WuXiXiao.XiaoWu("Brian", 15, false, 10);
        Console.WriteLine(Wolf.ToString());

        WuXiXiao.LiWanWan Pepper = new WuXiXiao.LiWanWan("Pepper", 3, "maizhushur", "Fire");
        Pepper.Bark();
        Console.ReadLine();
    }

    public static void PlusMeBro()
    {
        Int64 x = 2;
        xrepeat:
        x = Foo(x);
        Console.WriteLine("X = " + x + ". Again? y/n");
        if (Console.ReadLine() == "y") { goto xrepeat; }
    }

    //Learning how stacks work as well as Push & Pop *push and pop are available by default in javascript. In fact javascript treats arrays much like a stack.
    public static void StackBro()
    {
        Stack.Stack myStack = new Stack.Stack();

        myStack.Push("Fun!");
        myStack.Push("is");
        myStack.Push("Programming");

        Console.WriteLine("Press SPACE to continue, press any other key to exit.");
        button:
         if (Console.ReadKey(true).Key == ConsoleKey.Spacebar )
        {
            string s;
            s = (string)myStack.Pop();
            Console.WriteLine(s);
            goto button;
        }
    }

    //Custom interface implementation
    public static void PublicationBro()
    {
        Pub.Publication[] publications = new Pub.Publication[3]
        {
            new Pub.Publication("Dorothy and Friends", "Frank Zauth", 1998),
            new Pub.Publication("The Quick Fox", "Barney Stein", 2002),
            new Pub.Publication("The History of Cheese", "Jakob Huffman", 2008)
        };

        Pub.ConsoleListControl.List(Pub.Publication.Headers, publications);
    }

    static Int64 Foo(Int64 x) => x * 2;
}