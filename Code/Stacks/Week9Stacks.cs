using System;
using System.Collections.Generic;

namespace Code.Stacks
{
    class Week9Stacks
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
    class Stack
    {
        string[] stack = new string[1000];
        int stackPointer;
        public Stack()
        {
            stackPointer = -1;
        }
        private bool Push(string value)
        {
            if (IsFull()) return false;
            else{ 
                stack[stackPointer+=1] = value;
                return true;
            }
        }
        private string Pop()
        {
            if (stackPointer == -1) return "Stack Underflow";
            else{
                string value = stack[stackPointer-=1];
                stack[stackPointer] = "";
                return value;
            }
        }
        private string Peek(int pointer)
        {
            return stack[pointer+1];
        } 
        private bool IsFull()
        {
            if (stackPointer > 1000) return true;
            else return false;
        }

    }
}