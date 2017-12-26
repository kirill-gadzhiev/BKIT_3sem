using System;


namespace Lab_06
{
    
    public class MyAttribute : System.Attribute
    {
        public string Name { get; set; }

        public MyAttribute(string name)
        {
            Name = name;
        }
    }

    class Tree_calculator
    {
        private double x;
        private string creator;

        public double Value
        {
            get { return x; }
        }

        [MyAttribute("some")]
        public string Creator
        {
            get { return creator; }
        }

        [MyAttribute("ForDelegates7576")]
        public calculate_all foo;

        [MyAttribute("ForDelegateso98767")]
        public delegate double calculate_all(double y, string user_name);

        [MyAttribute("ForDelegates74")]
        public double Wrap(calculate_all del, double y, string user_name)
        {
            double temp;
            Console.WriteLine("Wrap\n{");
            temp = del.Invoke(y, user_name);
            Console.WriteLine("}");
            return temp;
        }

        [MyAttribute("ForDelegates12")]
        public double WrapFunc(Func<double, string, double> del, double y, string user_name)
        {
            double temp;
            Console.WriteLine("WrapFunc\n{");
            temp = del.Invoke(y, user_name);
            Console.WriteLine("}");
            return temp;
        }

        public Tree_calculator(double x, string user_name)
        {
            Console.WriteLine("Created with {0} by {1}", x, user_name);
            creator = user_name;
            this.x = x;
            foo = Addition;
            foo += Division;
            foo += Subtraction;
            foo += Multiplication;
        }

        public void Edit(double y, string user_name)
        {
            Console.WriteLine("Edited from {0} to {1} by {2}", this.x, y, user_name);
            this.x = y;
        }

        public double Multiplication(double y, string user_name)
        {
            Console.WriteLine("x = {0} * {1} = {2} by {3}", x, y, x * y, user_name);
            return x * y;
        }

        public double Addition(double y, string user_name)
        {
            Console.WriteLine("x = {0} + {1} = {2} by {3}", this.x, y, this.x + y, user_name);
            return x + y;
        }

        public double Subtraction(double y, string user_name)
        {
            Console.WriteLine("x = {0} - {1} = {2} by {3}", this.x, y, this.x - y, user_name);
            return x - y;
        }

        public double Division(double y, string user_name)
        {
            if (y.Equals(0.0))
            {
                Console.WriteLine("x = {0} / {1} = ZeroDivison error by {2}", this.x, y, user_name);
                return x;
            }
            else
            {
                Console.WriteLine("x = {0} / {1} = {2} by {3}", this.x, y, this.x / y, user_name);
                return x / y;
            }
        }

        public static bool GetAttributeNames(System.Reflection.MemberInfo check, Type attribute)
        {
            bool result = false;

            var isAttribute = check.GetCustomAttributes(attribute, false);
            if (isAttribute.Length > 0)
            {
                result = true;
            }
            return result;
        }

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Delegates");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter your name:");
            Console.ResetColor();
            string name = "";
            name = Console.ReadLine();

            Tree_calculator calc = new Tree_calculator(10, name);
            //calc.foo(0, name);
            calc.Wrap(calc.foo, 15, name);
            calc.Wrap(calc.Addition, 10, name);
            Console.ForegroundColor = ConsoleColor.Green;
            calc.Wrap((y, usr_name) => { Console.Write("Lambda addition: "); return calc.Addition(y, usr_name); }, 10, name);
            calc.WrapFunc(calc.Addition, 15, name);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nReflection\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
                   
            var instance = calc;
            var type = instance.GetType();
            var props = type.GetProperties();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Properties:");
            foreach (var prop in props)
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(instance));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMembers:");
            var members = type.GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine("{0}: {1}", member.Name, member.GetCustomAttributes(true));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWith custom attribute \"MyAttribute\" ");
            var attrs = typeof(Tree_calculator).GetMembers();
            foreach (var attr in attrs)
            {
                if (GetAttributeNames(attr, typeof(MyAttribute)))
                {
                    Console.WriteLine(attr.Name);
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            object[] parametres = new object[] { 4, "Reflection"};
            object result = type.InvokeMember("Addition", System.Reflection.BindingFlags.InvokeMethod, null, calc, parametres);
            Console.ResetColor();
        }
    }
}
