// ----------------------------------------------------------------------- 
// <copyright file="Diamond.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program works with geometric objects.</summary> 
// <author>Wolfgang Ofner</author> 
// -----------------------------------------------------------------------
namespace Aufgabe3_Wolfgang_Ofner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class of the object Diamond.
    /// </summary>
    internal class Diamond : GeometricObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Diamond"/> class.
        /// </summary>
        /// <param name="name">String contains the name of the object.</param>
        /// <param name="border_color">String contains the border color of the object.</param>
        /// <param name="padding_color">String contains the padding color of the object.</param>
        /// <param name="left">Integer contains the distance to the left border of the object.</param>
        /// <param name="top">Integer contains the distance to the right border of the object.</param>
        /// <param name="level">Integer contains the Level of the object.</param>
        /// <param name="rows">Odd Integer contains the rows of the object.</param>
        internal Diamond(string name, string border_color, string padding_color, int left, int top, int level, int rows)
            : base(name, border_color, padding_color, left, top, level)
        {
            this.Rows = rows;
            double a = Math.Sqrt(2 * ((rows / (double)2) * (rows / (double)2)));
            this.Coverage = 4 * a;
            this.Area = rows * (double)rows / 2;
        }

        /// <summary>
        /// Gets or sets the value of the rows of the object.
        /// </summary>
        internal int Rows { get; set; }

        /// <summary>
        /// Method for drawing an diamond object.
        /// </summary>
        /// <param name="diamond">Contains the object which should be drawn.</param>
        internal override void Draw(GeometricObject diamond)
        {
            string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            int border = 0;
            int padding = 0;

            for (int i = 0; i < 16; i++)
            {
                if (diamond.Border.ToUpper().Equals(colorNames[i].ToUpper()))
                {                                                               // checks on which index of the array the suitable color stands
                    border = i;
                    break;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (diamond.Padding.ToUpper().Equals(colorNames[i].ToUpper()))
                {                                                                   // checks on which index of the array the suitable color stands 
                    padding = i;
                    break;
                }
            }

            int middle = (this.Rows - 1) / 2;                                        // middle of the diamond

            for (int i = 0; i <= middle; i++)
            {
                for (int j = 0; j < this.Rows; j++)
                {
                    Console.SetCursorPosition(diamond.Left + j, diamond.Top + i);   // sets curser to to the place with the right distance to the top and left border

                    if (j == middle - i || j == middle + i)
                    {                                                               // to go everey row one step further away from the middle to draws the border
                        GeometricObject.Color(border);                              // chooses border color
                        Console.WriteLine("#");
                    }

                    if (j > middle - i && j < middle + i)
                    {                                                               // if curser is between the border
                        GeometricObject.Color(padding);                             // chooses padding color
                        Console.WriteLine("#");
                    }
                }
            }

            int counter = 1;

            for (int i = middle + 1; i < this.Rows; i++)
            {                                                                       // starts one row under the middle
                for (int j = 0; j < this.Rows; j++)
                {
                    Console.SetCursorPosition(diamond.Left + j, diamond.Top + i);   // sets curser one row under the middle

                    if (j == i - middle || j == (2 * middle) - counter)
                    {                                                               // goes every row one step closer to the middle to draw the border
                        GeometricObject.Color(border);                              // chooses the border color
                        Console.WriteLine("#");
                    }

                    if (j > i - middle && j < (2 * middle) - counter)
                    {                                                               // if curser is between the border
                        GeometricObject.Color(padding);                             // chooses padding color
                        Console.WriteLine("#");
                    }
                }

                counter++;                                                          // increases every row
            }

            Console.ResetColor();
        }
    }
}
