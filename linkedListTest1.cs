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
public class Program
    {
    public static void Main()
    {
        List newlist=new List();
        
        //Test nodes:
            //NOTE: since these methods are objects of the List class they must be declared by newlist.object
        newlist.NodeAddLast(35);
        newlist.NodeAddLast(32);
        newlist.NodeAddFirst(2);
        newlist.CountList();
        newlist.RemoveNode(2);
        newlist.InsertAt(1,13);

        Node? current = newlist.First; //calls the first list item from the List class
        while (current != null)//loops through the nodes changing the current node as it goes. 
            {
                System.Console.WriteLine(current.Value);
                current=current.NodeNext;
            } 
        Console.WriteLine($"Item Count: {newlist.CountList()}");//have to refer to the method, not the return variable. 
        }//end of main 
    } //end of class program 



