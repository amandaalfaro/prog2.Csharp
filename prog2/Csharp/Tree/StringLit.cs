// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;
	    private boolean pQuotes;
        
        public StringLit(string s)   
        {
            stringVal = s;
        }

      public StringLit(string s, bool b)   
        {
            stringVal = s;
            printQuotes = b;

        }
        
        public override void print(int n)
        {
            if (!quotes){
                Console.WriteLine(stringVal); 
            }
            else
                Printer.printStringLit(n, stringVal);
        }
        
        public override void print(int n)
        {
            Printer.printStringLit(n, stringVal);
        }

        public override bool isString()
        {
            return true;
        }
    }
}

