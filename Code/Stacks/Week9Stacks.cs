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
            if (stackPointer == -1) throw new System.InvalidOperationException("Stack is empty!");
            else{
                T value = stack[stackPointer];
                stack[stackPointer] = default(T);
                stackPointer -= 1;
                return value;
            }
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