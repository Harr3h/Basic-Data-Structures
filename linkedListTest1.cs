using System;
public class Node(int value)
{
    public int Value { get; set; } = value;
    public Node? NodeNext{get; set;}//allows null reference. 
    public Node? NodePrevious{get; set;}//allows null as a previous node
            }// end of node class 
public class List
{
   public Node? First{get; set;}
   public Node? Last{get; set;}
        public void NodeAddLast(int value)
            {
               
                Node? newnode=new Node(value);//creates a new node with the integer value the user added to the newnode node 
                if (this.Last == null)
                    {
                        First=newnode;
                        Last=newnode;

                    }
                else
                    {
                        Last.NodeNext=newnode;//sets the current node's next value from null to the newnode declared above
                        newnode.NodePrevious=Last;
                        Last=newnode;//sets the new node's prev value to the current node. 
                    }

            }//end of NodeAddLast

        public void NodeAddFirst(int value)
            {
                Node newNode = new Node(value);
                Node? currentFirst=this.First;
                if (currentFirst == null)
                {
                    First=newNode;
                    Last=newNode;
                }
                else
                {
                    currentFirst.NodePrevious=newNode; //sets the newNode as the previous element of the original First node, making newNode the first item.
                    newNode.NodeNext=currentFirst; //the newnode is the next item for the initial First list item.
                    First=newNode;//finally turns the First value into the newnode.
                }
            }
    public int CountList() //pretty self explanitory, loop through each list entry and add to a count. 
    {
        int counter=0;
       Node? curr=this.First;
        while (curr != null)
        {
            counter++;
            curr=curr.NodeNext;
        }
        return counter;
    }
    public void RemoveNode(int index)
    {
        Node? rCurr=this.First;
        
        if (rCurr == null || index<0)
        {
            throw new Exception("Index does not exist within List range.");
        }
        else
        {
            for (int i=0; i< index-1; i++)//creates a pseudo index and the search stops at the user declared index value
            {
                rCurr=rCurr.NodeNext; //when it reaches the node of VALUE it removes it, maybe sets the value to null and that might remove it from the list as it might run over null
            }
                if (rCurr.NodeNext.NodeNext == null)//handles the case when the current node's next next node is null
                {

                    Last=rCurr;//if the next next node is null, we can take the value null and give it to the .next node
                    rCurr.NodeNext=null;//sets the next node's previous node to the current node (hopefully)
                }
                else
                {
                    rCurr.NodeNext=rCurr.NodeNext.NodeNext; //sets the node before the index's next node to the next next node 
                    rCurr.NodeNext.NodePrevious=rCurr;//sets the new next node's previous node to the node before the index  
                }
            }
        
    }//end of RemoveNode
    public void InsertAt(int index, int value)
    {
        Node? newnode= new Node(value);
        Node? current= this.First;
        
        if (current == null || index<0)
        {
            throw new Exception("Index does not exist within List range.");
        }
        else
        {
            for (int i=0; i< index-1; i++)//creates a pseudo index and the search stops at the node before the user declared index value
            {
                current=current.NodeNext;
            }
           if (current.NodeNext == null){
                current.NodeNext=newnode;
                newnode.NodePrevious=current;
                newnode=Last;
                newnode.NodeNext=null;
            }
            else
            {
                newnode.NodePrevious=current;
                current.NodeNext.NodePrevious=newnode; 
                newnode.NodeNext=current.NodeNext;
                current.NodeNext=newnode;
            }
        }
    }//end of InsertAt method
}//end of list class
public class Stack
{
    public Node? First{get; set;}
    public Node? Last{get; set;}
    public void Push(int value)
    {
        Node? newnode= new Node(value);
        if (this.Last == null)
            {
            First=newnode;
            Last=newnode;
            
            }
        else
            {
                Last.NodeNext=newnode;//sets the current node's next value from null to the newnode declared above
                newnode.NodePrevious=Last;
                Last=newnode;//sets the new node's prev value to the current node. 
            }
    }
    public void Pop()
    {
        var stackempty = (this.First == null) && (this.Last == null); //logic var to see if the list is null or not (true when not null)
        if (stackempty==false){
            if (this.Last.NodePrevious != null)
            {
                this.Last.NodePrevious.NodeNext=null;
                this.Last=Last.NodePrevious;
            }
            else
            {
                this.First=null;
                this.Last=null; //added this so it only uses first and last within the class.
            }
        }
        else
        {
            throw new Exception("Pop() can not be performed as there are no items in the stack.");//if no items are in the list throw an error.
        }
    }//end of pop
    public void Peek()
    {
        if (this.Last != null)
        {
            Console.WriteLine($"First in stack: {this.Last.Value}");
        }
        else
        {
            throw new Exception("The Stack is empty.");
        }

    }
}//end of stack class
public class Queue
{
    public Node? First{get; set;}
    public Node? Last{get; set;}
    public void Enqueue(int value)
    {
        Node? newnode = new Node(value);
        if (this.First == null){ //queue empty case
            this.First=newnode; //this calls the node first in the class, excluding vars named First outside the class.
            this.Last=newnode;
        }
        else
        {
            Last.NodeNext=newnode;//sets the current node's next value from null to the newnode declared above
            newnode.NodePrevious=Last;
            Last=newnode;
        }
    }

    public void Dequeue()
    {
        var stackempty = (this.First == null) && (this.Last == null); // checks if the stack is empty and is false when not empty and true when empty
        if(stackempty == false)//if the stack is not empty
        {
            if (this.First.NodeNext != null) //if the first node is not null, 
            {
                First.NodeNext.NodePrevious = null; //set the First node's next node's previous node to null (FIFO)
                this.First = First.NodeNext; //after the first node has been disconnected, set the First node to the next node. 
            }
            else //if the first node is the only node in the queue, when removing it everything is null 
            {
                this.First=null;
                this.Last=null;
            }
        }
        else
        {
            throw new Exception("Dequeue failed. Queue is empty.");
        }
    }
    public void Peek()
    {
        if (this.First != null){
            Console.WriteLine($"First in queue: {this.First.Value}");
        }
        else
        {
            throw new Exception("This queue is empty.");
        }
    }
}//end of Queue 
public class Program
    {
    public static void Main()
    {
        List newlist=new List();
        /*List functions:
            newlist.NodeAddLast(value)
            newlist.NodeAddFirst(value)
            newlist.CountList();
            newlist.RemoveNode(index);
            newlist.InsertAt(index,value);*/
        
        Stack newStack= new Stack();
        /*Stack functions:
        newstack.Push(value);
        newstack.Pop();
        newstack.Peek();*/
        
    
        Queue newQueue= new Queue();
       /*Queue functions:
        newQueue.Enqueue(value);
        newQueue.Dequeue();
        newQueue.Peek();*/


        //List test:
        newlist.NodeAddLast(35);
        newlist.NodeAddLast(32);
        newlist.NodeAddFirst(2);
        newlist.CountList();
        newlist.RemoveNode(2);
        newlist.InsertAt(1,13);
        Node? current = newlist.First; //calls the first list item from the List class
        while (current != null)//loops through the nodes changing the current node as it goes. 
            {
                Console.WriteLine(current.Value);
                current=current.NodeNext;
            } 
        Console.WriteLine($"Item Count: {newlist.CountList()}");//have to refer to the method, not the return variable. 

       
       //Stack test:
        newStack.Push(10);
        newStack.Push(11);
        newStack.Push(12);
        newStack.Push(13);
        newStack.Pop();
        newStack.Peek();
        Node? currentStack=newStack.First;
        while (currentStack != null)
        {
            Console.WriteLine(currentStack.Value);
            currentStack=currentStack.NodeNext;
        }
        //Queue Test:
        newQueue.Enqueue(1);
        newQueue.Enqueue(2);
        newQueue.Enqueue(3);
        newQueue.Enqueue(4);
        newQueue.Enqueue(5);
        newQueue.Dequeue();
        newQueue.Peek();
        
        Node? current = newQueue.First;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current=current.NodeNext;
        }

        Node? current = newlist.First; //calls the first list item from the List class
        while (current != null)//loops through the nodes changing the current node as it goes. 
            {
                System.Console.WriteLine(current.Value);
                current=current.NodeNext;
            } 
        Console.WriteLine($"Item Count: {newlist.CountList()}");//have to refer to the method, not the return variable. 

        }//end of main 
    } //end of class program 
