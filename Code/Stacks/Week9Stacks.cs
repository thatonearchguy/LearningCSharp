using System;
using System.Collections.Generic;

namespace Code.Stacks
{
    class Week9Stacks
    {
        public static void Main(string[] args)
        {
            var aStack = new Stack<string>();
            aStack.Push("B");
            aStack.Push("m");
            Console.WriteLine(aStack.Pop());
            aStack.Push("o");
            aStack.Push("o");
            aStack.Pop();
            aStack.Pop();
            aStack.Pop();
            aStack.Pop();
        }
        public static int ShuntingAlgorithm(string input)
        {
            var workQueue = new Queue<string>();
            var workStack = new Stack<string>();
            var operators = new List<string>{"+", "-", "x", "/", "(", ")"};
            foreach(var token in input)
            {
                if (char.IsDigit(token)) workQueue.Add(token.ToString());
                else
                {
                    if (workStack.IsEmpty()) workStack.Push(token.ToString());
                    else
                    {
                        var index = operators.Find(n=>n=workStack.Pop());
                        
                    }
                }
            }
        }
        public static int RPN(string input)
        {
            var anotherStack = new Stack<string>();
            foreach (var element in input)
            {
                if (char.IsDigit(element)) anotherStack.Push(element.ToString());
                else
                {
                    var num1 = Int32.Parse(anotherStack.Pop());
                    var num2 = Int32.Parse(anotherStack.Pop());
                    switch (element)
                    {
                        case 'x':
                            anotherStack.Push((num2*num1).ToString());
                            break;
                        case '/':
                            anotherStack.Push((num2/num1).ToString());
                            break;
                        case '+':
                            anotherStack.Push((num2+num1).ToString());
                            break;
                        case '-':
                            anotherStack.Push((num2-num1).ToString());
                            break;
                    }
                }
            }
            return Int32.Parse(anotherStack.Pop());
        }
    }
    class Queue <T>
    {
        List<T> queue = new List<T>();
        public bool isEmpty()
        {
            if (queue.Count == 0) return true;
            else return false;
        }
        public T getFront()
        {
            return queue[0];
        }
        public void Add(T value)
        {
            queue.Add(value);
        }
        public T Dequeue()
        {
            if(isEmpty()) throw new System.InvalidOperationException("Queue is empty!");
            else 
            {
                var values = queue[0];
                queue.RemoveAt(0);
                return values;
            }
        }
        public void clear()
        {
            foreach (T value in queue)
            {
                queue.Remove(value);
            }
        }
        public Queue()
        {

        }
    }
    class Stack <T>
    {
        static int maxSize = 1000;
        T[] stack = new T[maxSize];
        int stackPointer;
        public Stack()
        {
            stackPointer = -1;
        }
        public bool Push(T value)
        {
            if (IsFull()) return false;
            else{ 
                stack[stackPointer+=1] = value;
                return true;
            }
        }
        public T Pop()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Stack is empty!");
            else{
                T value = stack[stackPointer];
                stack[stackPointer] = default(T);
                stackPointer -= 1;
                return value;
            }
        }
        public bool IsEmpty()
        {
            if (stackPointer == -1) return true;
            else return false;
        }
        public T Peek(int pointer)
        {
            return stack[pointer+1];
        } 
        public bool IsFull()
        {
            if (stackPointer > maxSize) return true;
            else return false;
        }

    }
}