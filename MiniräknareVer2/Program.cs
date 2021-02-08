using System;
using System.Collections.Generic;


namespace MiniräknareVer2
{
    public class Miniräknare
    {

        /*     
            Tja!

            Overall har jag tyckt att denna uppgift haft varit riktigt kul. Men även RIKTIGT RIKTIGT svår. I och med att jag börjar tänka på alla fel som kan hända. Och om 
            man inte gör den så som du hade i ditt exempel där man först fäljer operator, och sedan matar in inputsen.


            Det här innebär att det blir en massa kod som blir svår att dela upp till mindre metoder då situationerna är så olika...speciellt när det kommer till min
            kalylator! :)

            Det finns säkert ett väldigt mycket enklare sätt att göra en miniräknare på som har samma flöde som min har, där
            man i princip nästan kan avbryta när som helst och t.ex. ändra operator vid tilltället operator ska anges genom att bara
            skriva in en annan operator och [ENTER] fast du redan valt en, för att byta ut den du valde innan osv.

            Med detta sagt hoppas jag du finner denna intressant ändå.

            Har du frågor så fråga gärna!
        
            //Kimmo
         */

        /*Tänkte fixa Listan med att bara göra en string array och ha t.ex. : som delimiter med en .Split(":") funktion,
         men jag tycker att det här är mer cleant och hoppas att det är ok!*/
        public static List<string> calcHistory = new List<string>();


        /*OBS
         Det här var det enda sättet jag kunde komma åt dessa variablar överallt, dvs göra dom "globala" , "statiska" inom denna klass.
        Ge gärna kommentarer om detta.
         */
        public static string    InputA          { get; private set; }
        public static string    InputB          { get; private set; }
        public static string    Op              { get; private set; }
        public static bool      RunProgram      { get; private set; }
        public static string    CurrentState    { get; private set; }
        public static bool      AcceptedInput   { get; private set; }
        public static string    Calculation     { get; private set; }

         /*
          
         * Jag har skapat tester på några utav alla metoder, men inte alla.
         * Och jag har även försökt att använda try{} catch(){} där jag har känt att det behövs.
         
         */

        /// <summary>
        /// Shows the available commands for the current state you are in
        /// </summary>
        public static void ShowAvailableCommands()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nKey Legend:\n",Console.ForegroundColor);

            switch (CurrentState)
            {
                case "programstart":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"All Available commands in this program.\n" +
                        $"Numbers :  Input numbers.\n" +
                        $"+,-,*,/ :  The four normal operators. \n" +
                        $"LIST    :  Lists all your current calculations.\n" +
                        $"NEWTON  :  Calculate newtons second law 'FORCE' (Will reset memory).\n" +
                        $"C       :  Used in operator input for Celsius => Farenheit conversion.\n" +
                        $"F       :  Used in operator input for Farenheit => Celsius conversion.\n" +
                        $"MARCUS  :  Super secret word containing the integer 42, used in any non operator input field.\n" +
                        $"QUIT    :  To quit the program.\n" +
                        $"HELP    :  To see available commands\n\n" +
                        $"        ###  Typing messages is prohibited  ###"
                        , Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "startmenu":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"Available commands\n" +
                        $"Numbers :  Input numbers\n" +
                        $"LIST    :  Lists all your current calculations.\n" +
                        $"NEWTON  :  Calculate newtons second law 'FORCE' (Will reset memory).\n" +
                        $"C       :  Used in operator input for Celsius => Farenheit conversion.\n" +
                        $"F       :  Used in operator input for Farenheit => Celsius conversion.\n" +
                        $"MARCUS  :  Super secret word containing the integer 42, used in any non operator input field.\n" +
                        $"QUIT    :  To quit the program.\n" +
                        $"HELP    :  To see available commands\n\n"
                        , Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "operator":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"Available commands\n" +
                        $"+,-,*,/ :  The four normal operators\n" +
                        $"LIST    :  Lists all your current calculations.\n" +
                        $"NEWTON  :  Calculate newtons second law 'FORCE' (Will reset memory).\n" +
                        $"C       :  Used in operator input for Celsius => Farenheit conversion.\n" +
                        $"F       :  Used in operator input for Farenheit => Celsius conversion.\n" +
                        $"MARCUS  :  Super secret word containing the integer 42, used in any non operator input field.\n" +
                        $"QUIT    :  To quit the program.\n" +
                        $"HELP    :  To see available commands\n\n"
                        , Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "calculate":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"Available commands\n" +
                        $"Numbers :  Input numbers\n" +
                        $"LIST    :  Lists all your current calculations.\n" +
                        $"NEWTON  :  Calculate newtons second law 'FORCE' (Will reset memory).\n" +
                        $"C       :  Used in operator input for Celsius => Farenheit conversion.\n" +
                        $"F       :  Used in operator input for Farenheit => Celsius conversion.\n" +
                        $"MARCUS  :  Super secret word containing the integer 42, used in any non operator input field.\n" +
                        $"QUIT    :  To quit the program.\n" +
                        $"HELP    :  To see available commands\n\n"
                        , Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "newton":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"Available commands\n" +
                        $"Numbers :  Input numbers\n" +
                        $"LIST    :  Lists all your current calculations\n" +
                        $"MARCUS  :  Super secret word containing the integer 42, used in any non operator input field.\n" +
                        $"EXIT    :  To exit this program and go back to start\n" +
                        $"QUIT    :  To quit the program\n" +
                        $"HELP    :  To see available commands"
                        , Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

        }
  
        /// <summary>
        /// Converts from Farenheit to Celsius and returns the sum.
        /// </summary>
        /// <param name="C">Input number</param>
        /// <returns></returns>
        public static double ConvertToFarenheit(float C)
        {
            return (double)Math.Round(Convert.ToSingle((C * 9.0f / 5.0f) + 32f),2);
        }
 
        /// <summary>
        /// Converts from Celcius to Farenheit and returns the sum.
        /// </summary>
        /// <param name="F">Input number</param>
        /// <returns></returns>
        public static double ConvertToCelsius(float F)
        {
            return (double)Math.Round(Convert.ToSingle((F - 32f) * (5.0/9.0)),2);
        }

       /// <summary>
       /// Calculates all the 4 normal ways (Add,Subtract,Multiplication Division)
       /// And also can convert from Farenheit to Celsius and the other way around.
       /// </summary>
       /// <param name="a">First number</param>
       /// <param name="op">Operator (+,-,*,/,C,F)</param>
       /// <param name="b">Second number (Is skipped when converting temperatures)</param>
       /// <returns></returns>
        public static string Compute(float a,string op,float b)
        {
            float tempNum;
            try
            {
                switch (op)
                {
                    case "+":
                        /*Addition*/
                        Console.WriteLine($"{a} + {b} = {a + b}", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        tempNum = (float)Math.Round(a + b,2);
                        return tempNum.ToString();
                    case "-":
                        /*Subtraktion*/
                        Console.WriteLine($"{a} - {b} = {a - b}",Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        tempNum = (float)Math.Round(a - b,2);
                        return tempNum.ToString();
                    case "*":
                        /*Multiplikation*/
                        Console.WriteLine($"{a} * {b} = {a * b}", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        tempNum = (float)Math.Round(a * b,2);
                        return tempNum.ToString();
                    case "/":
                        /*Division*/
                        try
                        {
                            if(a.ToString() == "0" || b.ToString() == "0")
                            {
                                Console.WriteLine($"{a} / {b} = infinity", Console.ForegroundColor = ConsoleColor.Green);
                                Console.ForegroundColor = ConsoleColor.White;
                                //string chosenSum = "faulty";
                                throw new DivideByZeroException();
                            //return chosenSum;
                            }
                            else
                            {
                                Console.WriteLine($"{a} / {b} = {a / b}", Console.ForegroundColor = ConsoleColor.Green);
                                Console.ForegroundColor = ConsoleColor.White;
                                tempNum = (float)Math.Round(a / b, 2);
                                return tempNum.ToString();
                            }
                        }
                        catch (DivideByZeroException ex) when (a == 0 || b == 0)
                        {
                            Console.WriteLine(ex.Message);
                            return "faulty";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return "faulty";
                    }
                    case "C":
                    case "c":
                        /*Konvertera från Celsius till Farenheit*/
                        tempNum = (float)ConvertToFarenheit(a);
                        Console.WriteLine($"{a}{op.ToUpper()} => {tempNum}F", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        return tempNum.ToString();
                    case "F":
                    case "f":
                        /*Konvertera från farenheit till Celsius*/
                        tempNum = (float)ConvertToCelsius(a);
                        Console.WriteLine($"{a}{op.ToUpper()} => {tempNum}C", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        return tempNum.ToString();
                    default:
                    /*Ifall operator är felaktig*/
                    return "faulty";
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return "faulty";
            }


        }
       
        /// <summary>
        /// Checks the given input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetNumber(string input)
        {
            try
            {
                string str = input.ToLower();

                if(str == null || str ==  "")
                {
                    throw new ArgumentNullException();
                }
                if (str == "marcus")
                {
                    str = 42.ToString();
                }
            
                bool isSpecialCase = CheckInput(str);
                bool isOperator = ((str == "+" || str == "-" || str == "*" || str == "/" || str == "c" || str == "f"));

                if (isSpecialCase)
                {
                    AcceptedInput = true;
                    return str;
                
                }
                else
                {
                    while (!isOperator)
                    {
                        if (!Single.TryParse(str, out float output))
                        {
                            
                            Console.WriteLine("This is not a number or any of the accepted commands.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            calcHistory.Add($"{str} => ???");
                            AcceptedInput = false;
                            throw new ArgumentException();
                            //return "faulty";
                        }
                        AcceptedInput = true;
                        return output.ToString();
                    }

                    if (isOperator)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is not an operand.");
                        Console.ForegroundColor = ConsoleColor.White;
                        //break;
                    }
                }
                calcHistory.Add($"{str} => ???");
                AcceptedInput = false;
                return "faulty";
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return "faulty";
            }
            catch (ArgumentException ex )
            {
                Console.WriteLine(ex.Message);
                return "faulty";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "faulty";
            }

        }
        /// <summary>
        /// Calculates the newtons second law. Returns the sum of Mass multiplied with acceleration "F = M*a"
        /// </summary>
        /// <param name="m">Mass</param>
        /// <param name="a">Acceleration(in m/s)</param>
        /// <returns>F = M*a</returns>
        public static string CalculateForce(float m, float a)
        {
            Console.WriteLine($"M{m} * a{a} => F = {Math.Round(m * a,1)} N", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            return Math.Round(m * a, 1).ToString();
        }
       
        /// <summary>
        /// Checks if input command is : quit, newton, list, exit or faulty
        /// </summary>
        /// <param name="a">The input to check</param>
        /// <returns>A true or false if any of the conditions are true</returns>
        public static bool CheckInput(string a)
        {
            bool isQuit = a.ToLower() == "quit";
            bool isNewton = a.ToLower() == "newton";
            bool isList = a.ToLower() == "list";
            bool isExit = a.ToLower() == "exit";
            bool isFaulty = a.ToLower() == "faulty";
            return isQuit || isNewton || isList || isExit || isFaulty;

        }
       
        /// <summary>
        /// Checks if the operator given is a valid one.
        /// </summary>
        /// <param name="a">Operator to check</param>
        /// <returns>Returns the given operator, *or special (Quit, List, Newton , Exit, Quit)</returns>
        public static string GetOperator(string a)
        {
            try
            {

            
            bool isSpecialCase = CheckInput(a);
            string str = a.ToLower();
            bool isValidOperator = ((str =="+" || str == "-" || str =="*" || str =="/" || str =="c" || str =="f") && str.Length == 1);

            if (isSpecialCase)
            {
                AcceptedInput = true;
                return str;
            }
            else
            {
                while (!isValidOperator)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not an valid operator");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                if (isValidOperator)
                {
                    AcceptedInput = true;
                    return str.ToLower();
                }
            }
            return "faulty";
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return "faulty";
            }
        }
       
        /// <summary>
        /// Shows a list of all finished entries so far
        /// </summary>
        public static void ShowList()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("#######HISTORY#######", Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.White;
            if (calcHistory.Contains(null))
            {
                //TODO Fick inte denna o lira..vet inte riktigt hur jag ska kolla i hela Listan om det ens finns något. Och visa tessten empty om det inte finsn något innehåll
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EMPTY");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                calcHistory.ForEach(Console.WriteLine);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// Huvudprogrammet CALCuna
        /// </summary>
        static void Main()
        {
            
            string inputA, inputB, memorizedInput,_operator = "";
            CurrentState = "";
            RunProgram = true;
            Console.WriteLine("Welcome to CALCuna!", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.ForegroundColor = ConsoleColor.White;
            inputA = null;

            CurrentState = "programstart";
            ShowAvailableCommands();

            
            while (RunProgram == true)
            {
                /*Nollställ värden*/
                CurrentState = "startmenu";
                inputB = "";
                memorizedInput = "";
                _operator = "";
                if(AcceptedInput == true)
                {
                    Console.WriteLine("::::#START MENU#::::", Console.ForegroundColor = ConsoleColor.Cyan);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                AcceptedInput = false;

                /*Steg 1*/
                #region STEG 1

                try
                {             
                    while (!AcceptedInput)
                    {
                        inputA = null;
                        if (inputA == null)
                        {
                            Console.Write(">");
                            inputA = Console.ReadLine().TrimStart().TrimEnd().ToLower();
                            if (inputA.ToLower() != "help")
                            {
                                inputA = GetNumber(inputA);
                            }
                            else
                            {
                                ShowAvailableCommands();
                                continue;
                            }
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                #endregion
                /*Steg 2*/
                #region STEG 2
                while (!CheckInput(inputA))
                {
                    CurrentState = "operator";
                    AcceptedInput = false;
                    Calculation = "";

                    
                    
                    if (_operator != "faulty")
                    {
                        Calculation += inputA.ToString() == "42" ? "MARCUS" : inputA.ToString() + " ";
                        if (inputA != "")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"###In memory({inputA})###");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                        /*Loopa tills AcceptedInput == true*/
                        while (!AcceptedInput)
                        {
                            if (_operator.ToLower() != "f" && _operator.ToLower() != "c" && _operator.ToLower() != "exit")
                            {
                                Console.Write(">");
                                _operator = Console.ReadLine().TrimStart().TrimEnd().ToLower();
                            }
                            if (_operator.ToLower() == "exit")
                            {
                                inputA = "exit";
                                _operator = "exit";
                                Calculation = "";
                                AcceptedInput = true;
                                break;
                            }
                            if (_operator.ToLower() == "list")
                            {
                                _operator = "";
                                Calculation = "";
                                AcceptedInput = false;
                                ShowList();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"###In memory({inputA})###");
                                Console.ForegroundColor = ConsoleColor.White;
                                continue;
                            }
                            if (_operator.ToLower() == "quit")
                            {
                                inputA = "quit";
                                _operator = "quit";
                                Calculation = "";
                                AcceptedInput = true;
                                break;
                            }
                            if (_operator.ToLower() == "marcus")
                            {
                                inputA = 42.ToString();
                                Calculation = "";
                                break;
                            }
                            if (!float.TryParse(_operator, out float numOutput))
                            {
                                if (_operator.ToString().ToLower() == "help")
                                {
                                    ShowAvailableCommands();

                                    break;
                                }
                                GetOperator(_operator).ToLower();
                            }
                            else
                            {
                                inputA = _operator.ToLower() == "help" ? inputA : numOutput.ToString();
                                Calculation = "";
                                break;
                            }
                        }
                    }
                    #endregion

                    #region STEG 3
                    /*Om operatorn inte har ´blivit assignerad med dessa strängvärden så kan vi forstätta våran beräkning*/
                    if (_operator != "faulty" && _operator != "exit")
                    {
                        CurrentState = "calculate";
                        switch (_operator)
                        {
                            case "+":
                            case "-":
                            case "*":
                            case "/":
                                /*
                                 * Här nedan körs en helt vanlig kalkylering, oavsett vilken utav dessa 4
                                 * räknesätt som används, så kommer Compute Metoden sköta det.
                                */
                                AcceptedInput = false;
                                Calculation += _operator.ToString() + " ";
                                while (!AcceptedInput)
                                {
                                    /*Låter användaren veta hur beräkningen ser ut just nu*/
                                    Console.WriteLine($"Output: {inputA} {_operator}", Console.ForegroundColor = ConsoleColor.Blue);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    inputB = "";
                                    Console.Write(">");
                                    /*Ta in andra operanden*/
                                    if(inputB == "")
                                    {
                                        inputB = Console.ReadLine().TrimStart().TrimEnd();
                                    }

                                    /*om man inte skriver in help så kommer denna köras*/
                                    if (inputB.ToLower() != "help")
                                    {
                                        if (inputB.ToLower() == "marcus")
                                        {
                                            inputB = 42.ToString();
                                        }
                                        if (!float.TryParse(inputB, out float num))
                                        {
                                            _operator = GetOperator(inputB) != "faulty" && GetOperator(inputB) != "list" ? GetOperator(inputB) : _operator; //Håller kvar föregående operator ifall din ändring av operator är felaktig

                                            AcceptedInput = false; // Det här tvingar while looparna köra igen med en annan operator!

                                            if (inputB.ToLower() == "exit")
                                            {
                                                inputA = "exit";
                                                _operator = "exit";
                                                Calculation = "";
                                                AcceptedInput = true;
                                                break;
                                            }
                                            if (inputB.ToLower() == "quit")
                                            {
                                                inputA = "quit";
                                                _operator = "quit";
                                                Calculation = "";
                                                AcceptedInput = true;
                                                break;
                                            }
                                            if (inputB.ToLower() == "list")
                                            {
                                                inputB = "";
                                                Calculation = "";
                                                AcceptedInput = false;
                                                ShowList();
                                                continue;
                                            }
                                            if (_operator == "newton")
                                            {
                                                inputA = "newton";
                                                break;
                                            }
                                            if (_operator == "f" || _operator == "c")
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                        else
                                        {
                                            inputB = num.ToString();
                                            GetNumber(inputB);
                                        }


                                        if (!CheckInput(inputB))
                                        {
                                            float a = Convert.ToSingle(inputA);
                                            float b = Convert.ToSingle(inputB);
                                            Calculation += inputB.ToString() == "42" ? "MARCUS" : inputB.ToString() + " ";
                                            memorizedInput = Compute(a, _operator, b);
                                            if (memorizedInput == "faulty")
                                            {
                                                //AcceptedInput = false;
                                                inputA = "faulty";
                                                _operator = memorizedInput;
                                                break;
                                            }
                                            calcHistory.Add($"{Calculation} => {memorizedInput}");
                                            inputA = memorizedInput.ToString();
                                            Calculation = "";
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        /*Visa tillgängliga kommandon*/
                                        ShowAvailableCommands();
                                        continue;
                                    }

                                }
                                continue;
                            case "c":
                            case "f":
                                /*Celsius och Farenheit konverteringar*/
                                Calculation += _operator.ToString().ToUpper() + " ";
                                float temperature = Convert.ToSingle(inputA);

                                memorizedInput = Compute(temperature, _operator,0f);   //Själva uträkningen händer här

                                calcHistory.Add($"{Calculation} => {memorizedInput}F"); // lägga till beräkningen i listan
                                inputA = memorizedInput.ToString();                     // Spara förra resultatet som första input
                                Calculation = "";
                                _operator = "";
                                break;
                            case "list":
                                /*Visa lista på alla beräkningar och hoppa tillbaka till förra steget*/
                                ShowList();
                                AcceptedInput = false;
                                break;
                            case "newton":
                                /*Gå ur steg 2 och hoppa in i Newton case längre ner*/
                                inputA = "newton";
                                _operator = "newton";
                                break;
                            case "quit":
                                /*Stäng progammet*/
                                RunProgram = false;
                                break;
                            case "faulty":
                                /*Om Operator ger ett felaktigt resultat*/
                                inputA = "";
                                Calculation = "";
                                Console.WriteLine("Not an acceptable input, try again.");
                                Console.WriteLine("Resetting Program", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case "exit":
                                /*gå till startmenyn*/
                                inputA = "";
                                _operator = "";
                                Calculation = "";
                                break;
                        }
                    }
                    #endregion
                    else
                    {
                        /*Ifall man råkar göra special kommandon eller ge fel vid operator inputten*/
                        switch (_operator)
                        {
                            case "list":
                                /*##########################   Redundans   ##########################*/
                                ShowList();
                                AcceptedInput = false;
                                break;
                            case "newton":
                                /*##########################   Redundans   ##########################*/
                                inputA = "newton";
                                CurrentState = "newton";
                                break;
                            case "quit":
                                /*##########################   Redundans   ##########################*/
                                RunProgram = false;
                                break;
                            case "faulty":
                                /*##########################   Redundans   ##########################*/
                                inputA = "";
                                Calculation = "";
                                Console.WriteLine("Not an acceptable input, try again.");
                                Console.WriteLine("Resetting Program", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            default:
                                /*Kan ses som exit*/
                                inputA = "";
                                inputB = "";
                                _operator = "";
                                Calculation = "";
                                break;
                        }
                        break;
                    }
                
                }

                /*Special Kommandon*/
                switch (inputA)
                {
                    case "list":
                        /*visar lista med alla beräkningar*/
                        ShowList();
                        break;
                    case "newton":
                        /*Här beräknas newtons andra lag*/
                        CurrentState = "newton";
                        inputA = "";
                        inputB = "";
                        Calculation = "";
                        float tempNum1;
                        float tempNum2;
                        AcceptedInput = false;

                        Console.WriteLine("Here you can calculate newtons 2nd law!", Console.ForegroundColor = ConsoleColor.DarkYellow);
                        Console.ForegroundColor = ConsoleColor.White;


                        /*Medans denna är falsk så kommer programmet att köras, tills du kör klart din beräkning,avslutar Newton programmet (EXIT) eller avslutar hela programmet (QUIT)*/
                        while (!AcceptedInput)
                        {

                            /*Input 1 Massa*/
                            if(inputA.ToLower() == "" || inputA.ToLower() == "help" || inputA.ToLower() == "list" || inputA.ToLower() == "quit")
                            {
                                Console.WriteLine("Please input Mass");
                                Console.Write(">");
                                inputA = Console.ReadLine();

                                /*Visa tillgängliga kommandon*/
                                if (inputA.ToLower() == "help")
                                {
                                    ShowAvailableCommands();  
                                    continue;
                                }

                                /*Visa lista*/
                                if(inputA.ToLower() == "list")
                                {
                                    ShowList();
                                    continue;
                                }

                                /*Gå tillbaka till startmenyn*/
                                if (inputA.ToLower() == "exit")
                                {
                                    inputA = "";
                                    Calculation = "";
                                    AcceptedInput = true;
                                    break;
                                }

                                /*Avsluta hela propgrammet*/
                                if (inputA.ToLower() == "quit")
                                {
                                    inputA = "quit";
                                    RunProgram = false;
                                    Calculation = "";
                                    AcceptedInput = true;
                                    break;
                                }
                                GetNumber(inputA);
                                if (inputA.ToLower() == "marcus")
                                {
                                    inputA = 42.ToString();
                                }
                                /*Loopa från början ifall det inte är en siffra*/
                                if (!float.TryParse(inputA, out tempNum1))
                                {
                                    continue;
                                }
                                inputA = tempNum1.ToString();
                                Calculation += inputA.ToString() == "42" ? "MARCUS" + " * " : inputA.ToString() + " * ";
                                Console.WriteLine($"Output: {inputA} * ", Console.ForegroundColor = ConsoleColor.Blue);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                inputA = "";
                                continue;
                            }


                            /*Input 2 Acceleration*/
                            if(inputB.ToLower() == "")
                            {
                                Console.WriteLine("Please input Acceleration (will be in m/s for thius calculation)");
                                Console.Write(">");
                                inputB = Console.ReadLine();

                                /*Dessa förklarar sig självt*/
                                if (inputB.ToLower() == "help")
                                {
                                    ShowAvailableCommands();
                                    continue;
                                }
                                if (inputB.ToLower() == "list")
                                {
                                    ShowList();
                                    continue;
                                }
                                if (inputB.ToLower() == "exit")
                                {
                                    inputB = "";
                                    Calculation = "";
                                    AcceptedInput = false;
                                    continue;
                                }
                                if (inputB.ToLower() == "quit")
                                {
                                    inputB = "quit";
                                    RunProgram = false;
                                    Calculation = "";
                                    AcceptedInput = true;
                                    continue;
                                }
                                GetNumber(inputB);
                                if (inputB.ToLower() == "marcus")
                                {
                                    inputB = 42.ToString();
                                }

                                if (!float.TryParse(inputB, out tempNum2))
                                {
                                    inputA = "";
                                    inputB = "";
                                    continue;
                                }
                                inputB = tempNum2.ToString();
                                float tempNum3 = Convert.ToSingle(inputA);
                                Calculation += inputB.ToString() == "42" ? "MARCUS" : inputB.ToString();
                                memorizedInput = CalculateForce(tempNum3, tempNum2);
                                calcHistory.Add($"{Calculation} => {memorizedInput}");

                                inputA = "";
                                Calculation = "";
                                AcceptedInput = true;
                                break;
                            }   
                        }
                        break;
                    case "quit":
                        RunProgram = false;
                        break;
                    case "faulty":
                        inputA = "";
                        Calculation = "";
                        Console.WriteLine("Not an acceptable input, try again.", Console.ForegroundColor = ConsoleColor.Red);
                        Console.WriteLine("Resetting Program",Console.ForegroundColor = ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        inputA = "";
                        inputB = "";
                        Calculation = "";
                        memorizedInput = "";
                        break;
                }
            }
            Console.WriteLine("Exiting program");
            Console.WriteLine("Thank you and goodbye!");
            Console.ReadKey();
        }
    }
}