﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            
        }

        public static void WriteMessageOnNewLine(string message)
        {

        }

        public static void WriteEmptyLine()
        {

        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
