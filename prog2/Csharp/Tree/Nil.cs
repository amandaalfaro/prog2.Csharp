// Nil -- Parse tree node class for representing the empty list
//DONE

using System;

namespace Tree
{
    public class Nil : Node
    {
        private static Nil instance = new Nil();

        private Nil() { }
  
        public static Nil getInstance()
        {
            return instance;
        }

        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p) {
            Printer.printNil(n, p);
        }

        public override bool isNull()
        {
            return true;
        }
        
        public override Node eval(Environment env)
        {   
            throw new Exception("Error: eval() cannot be called in Nill.cs");
        }
        
    }
}
