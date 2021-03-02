using System;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue(5);
            myQueue.Insert(100);
            myQueue.Insert(10);
            myQueue.Insert(20);
            myQueue.Insert(30);
            myQueue.View();


            Console.WriteLine($"Front of the queue is { myQueue.PeekFront() }");

            Console.WriteLine("About to remove item from queue");
            myQueue.Remove();
            Console.WriteLine($"Front of the queue is { myQueue.PeekFront() }");
        }


        public class Queue
        {
            private int maxSize;
            private long[] myQueue; // container for slots
            private int front;
            private int rear;
            private int items;

            public Queue(int size)
            {
                maxSize = size;
                myQueue = new long[size];
                front = 0;
                rear = -1;
                items = 0;
            }

            // insert items at the back of the queue 
            public void Insert(long j)
            {
                if (isFull())
                {
                    Console.WriteLine("Queue is Full");
                }
                else
                {
                    if (rear == maxSize - 1)
                    {
                        rear = -1;
                    }

                    rear++;
                    myQueue[rear] = j;
                    items++;
                }
            }

            // remove items from front of the queue
            public long Remove()
            {
                long temp = myQueue[front];
                front++;

                if (front == maxSize)
                {
                    front = 0;
                }

                return temp;
            }

            public long PeekFront()
            {
                return myQueue[front];
            }

            public bool IsEmpty()
            {
                return (items == 0);
            }

            public void View()
            {
                Console.Write("[");
                for (int i = 0; i < myQueue.Length; i++)
                {
                    Console.Write($"{ myQueue[i] } ");
                }
                Console.WriteLine("]");
            }

            private bool isFull()
            {
                return (items == maxSize);
            }


        }
    }
}
