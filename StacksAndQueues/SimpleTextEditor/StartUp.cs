using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SimpleTextEditor
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<char> originalStack = new Stack<char>();
            Stack<string> previousStates = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var commandName = tokens[0];
                int argument = 0;

                switch (commandName)
                {
                    case "1":
                        var text = tokens[1];
                        StringAppend(text, originalStack, previousStates);
                        break;

                    case "2":
                        argument = int.Parse(tokens[1]);
                        EraseLastElements(argument, originalStack, previousStates);
                        break;

                    case "3":
                        argument = int.Parse(tokens[1]);
                        char el = ReturnElementAt(argument, originalStack);
                        Console.WriteLine(el);
                        break;

                    case "4":
                        Undo(originalStack, previousStates);
                        break;
                }

            }
        }

        static void StringAppend(string text, Stack<char> originalStack, Stack<string> previousStates)
        {
            AddPreviousState(originalStack, previousStates);

            var elementsToAppend = text.ToCharArray();

            foreach (char element in elementsToAppend)
            {
                originalStack.Push(element);
            }
        }

        static void EraseLastElements(int number, Stack<char> originalStack, Stack<string> previousStates)
        {
            AddPreviousState(originalStack, previousStates);



            for (int i = 0; i < number; i++)
            {
                originalStack.Pop();
            }

        }

        static char ReturnElementAt(int index, Stack<char> originalStack)
        {
            Queue<char> helperQueue = new Queue<char>();

            foreach (var element in originalStack.Reverse())
            {
                helperQueue.Enqueue(element);
            }

            for (int i = 0; i < originalStack.Count; i++)
            {
                char toReturn = helperQueue.Dequeue();
                if (i == index - 1)
                {
                    return toReturn;
                }
            }
            return ' ';
        }

        static void Undo(Stack<char> originalStack, Stack<string> previousStates)
        {
            originalStack.Clear();

            foreach (char element in previousStates.Pop())
            {
                originalStack.Push(element);
            }

        }

        static void AddPreviousState(Stack<char> originalStack, Stack<string> previousStates)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in originalStack.Reverse())
            {
                sb.Append(element.ToString());
            }
            previousStates.Push(sb.ToString());
        }
    }
}
