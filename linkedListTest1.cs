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
                /*
                TO DO:
                Create InsertAt()
                Create remove(node)
                */
                Node? newnode=new Node(value);//creates a new node with the integer value the user added to the newnode node 
                if (this.Last == null)
                    {
                        First=newnode;
                        Last=newnode;

                    }
                else
                    {
                        Last.NodeNext=newnode;//sets the current node's value from null to the newnode declared above
                        newnode.NodePrevious=Last;
                        Last=newnode;//sets the new node's prev value to the current looped node. 
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
                    currentFirst.NodePrevious=newNode; //initial first node to the previous value of newNode
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
}
public class Program
    {
    public static void Main()
    {
        List newlist=new List();
        
        newlist.NodeAddLast(35);
        newlist.NodeAddLast(32);
        newlist.NodeAddFirst(2);
        newlist.CountList();//calls the method from the new list defined above
        
        Node? current = newlist.First; //calls the first list item from the List class
        while (current != null)//loops through the nodes changing the current node as it goes. 
            {
                System.Console.WriteLine(current.Value);
                current=current.NodeNext;
            } 
        Console.WriteLine($"Item Count: {newlist.CountList()}");//have to refer to the method, not the return variable. 

        }//end of main 

    } //end of class program 



