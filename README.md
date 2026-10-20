# Basic-Data-Structures
Basic data structures done for the ICS4U class done natively in C#. 
## Navigation:
Data structures included in this repository are:
- [Doubly Linked Lists](#list-features) 
- [Stacks](#stack-features)
- [Queues](#queue-features)

## Doubly Linked List Features:

```csharp
    public void AddFirst(int value)
```
The function `AddFirst` adds a node as the first element in the linked list.

```csharp
    public void AddLast(int value)
```
The function `AddLast` adds a node as the last element in the linked list.

```csharp
    public void CountList()
```
The function `CountList` counts all of the elements in the array and prints the total.

```csharp
    public void RemoveAt(int index)
```
The function `RemoveAt` removes the node at the user's inputted index position. 

```csharp
    public void InsertAt(int index, int value)
```
The function `InsertAt` inserts a node at the user inputted index with a user's inputted value. 
## Stack Features:
A stack operates under the First In, Last Out (FILO) method, where the first entry into the stack is always the last to leave the stack.
```csharp
    public void Push(int value)
```
The function `Push` inserts a node at the top of the stack/last element.

```csharp
    public void Pop()
```
The function `Pop` removes the last node/element in the stack (FILO). 

```csharp
    public void Peek()
```
The function `Peek` prints the last/top value in the stack.

## Queue Features:
A queue operates under the First In, First Out (FIFO) method, where the first entry into the queue is always the first to exit the queue. 
```csharp
    public void Enqueue(int value)
```
The function `Enqueue` inserts a node at the end of the queue/at the last element.

```csharp
    public void Dequeue()
```
The function `Dequeue` removes the first element in the queue (FIFO).

```csharp
    public void Peek()
```
The function `Peek` prints the first item in the queue.
