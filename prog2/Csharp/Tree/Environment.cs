// Environment.java -- a data structure for Scheme environments

// An Environment is a list of frames.  Each frame represents a scope
// in the program and contains a set of name-value pairs.  The first
// frame in the environment represents the innermost scope.

// For the code below, I am assuming that a frame is implemented
// as an association list, i.e., a list of two-element lists.  E.g.,
// the association list ((x 1) (y 2)) associates the value 1 with x
// and the value 2 with y.

// To implement environments in an object-oriented style, it would
// be better to define a Frame class and make an Environment a list
// of such Frame objects or to implement a frame as a hash table.

// You need the following methods for modifying environments:
//  - constructors:
//      - create the empty environment (an environment with an empty frame)
//      - add an empty frame to the front of an existing environment
//  DONE- lookup the value for a name (for implementing variable lookup)
//      if the name exists in the innermost scope, return the value
//      if it doesn't exist, look it up in the enclosing scope
//      if we don't find the name, it is an error
//  DONE- define a name (for implementing define and parameter passing)
//      if the name already exists in the innermost scope, update the value
//      otherwise add a name-value pair as first element to the innermost scope

//  DONE- assign to a name (for implementing set!)
//      if the name exists in the innermost scope, update the value
//      if it doesn't exist, perform the assignment in the enclosing scope
//      if we don't find the name, it is an error

using System;

namespace Tree
{
    public class Environment : Node
    {
        // An Environment is implemented like a Cons node, in which
        // every list element (every frame) is an association list.
        // Instead of Nil(), we use null to terminate the list.

        private Node frame;     	// the innermost scope, an assoc list
	private Environment env;	// the enclosing environment
   
        public Environment()
        {
            frame = Nil.getInstance();
            env = null;
        }
   
        public Environment(Environment e)
	{
            frame = Nil.getInstance();
            env = e;
        }

        public override void print(int n) {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.WriteLine("#{Environment");
            if (frame != null)
                frame.print(Math.Abs(n) + 4);
            if (env != null)
                env.print(Math.Abs(n) + 4);
            for (int i = 0; i < Math.Abs(n); i++)
                Console.Write(' ');
            Console.WriteLine('}');
        }

        // This is not in an object-oriented style, it's more or less a
        // translation of the Scheme assq function.
        private static Node find(Node id, Node alist)
        {
	    //if the association list is empty
            if (! alist.isPair())
                return null;	// in Scheme we'd return #f
            else
            {
                Node bind = alist.getCar();
		//If the ID is in an association list
                if (id.getName().Equals(bind.getCar().getName()))
                    // return a list containing the value as only element
                    return bind.getCdr();
                else
		
                    return find(id, alist.getCdr());
            }
        }


        public Node lookup(Node id)
        {
            Node val = find(id, frame);
            if (val == null && env == null)
            {
                Console.Error.WriteLine("The variable " + id.getName() + "is undefined");
                return null;
            }
            else if (val == null)
                // look up the identifier in the enclosing scope
                return env.lookup(id);
            else	
                // get the value out of the list we got from find()
		return val.getCar();
        }


        public void define(Node id, Node val) {
	
            //defining a name
            Node nameVal = find(id,frame); 
	    //Checking to see if the name is in the innermost scope
	    //if the name already exists in the innermost scope
	    
            if(nameVal != null)	{   
	    	 //updating nameVal	
		 value.setCar(val);
  	    }	else {
	    	//add a name-value pair as first element to the innermost scope
		frame = new Cons(new Cons(id, new Cons(val, new Nil())), frame);
            }
	    
        }


        public void assign(Node id, Node val) {
	   //Going to use the lookup method to make the code more efficent
	    /*Node value = find(id, frame); 
	    
	    //if the name exists in the innermost scope
            if (value == null && env == null) 
	    	//Update value
	    	define(id, val); 
		
	    //if the name DOESNT exist in the innermost scope	
            else if (value == null) 
	    	//Perform the assignment in the enclosing scope
                env.findForAssign(id, val);
	    
	    //If value isnt found
            else
	    	//Print undefined varibale error
                Console.Error.WriteLine("The variable" + id.getName() + "is undefined"); */
		
		
	   if (this.lookup(id) != null)	
              find(id, this.frame).setCar(val);
           else 
              Console.Error.WriteLine("The varaible " + id.getName() + "is undefined");
        }
    }
}
