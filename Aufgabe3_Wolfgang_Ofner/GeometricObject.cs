// ----------------------------------------------------------------------- 
// <copyright file="GeometricObject.cs" company="FHWN"> 
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
    /// Base class Geometric Object.
    /// </summary>
    internal abstract class GeometricObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeometricObject"/> class.
        /// </summary>
        /// <param name="name">String contains the name of the object.</param>
        /// <param name="border">String contains the border color of the object.</param>
        /// <param name="padding">String contains the padding color of the object.</param>
        /// <param name="left">Integer contains the distance to the left border of the object.</param>
        /// <param name="top">Integer contains the distance to the right border of the object.</param>
        /// <param name="level">Integer contains the Level of the object.</param>
        internal GeometricObject(string name, string border, string padding, int left, int top, int level)
        {
            this.Name = name;
            this.Border = border;
            this.Padding = padding;
            this.Left = left;
            this.Top = top;
            this.Level = level;
        }

        /// <summary>
        /// Gets or sets the value of the border color.
        /// </summary>
        internal string Border { get; set; }

        /// <summary>
        /// Gets or sets the value of the padding color.
        /// </summary>
        internal string Padding { get; set; }

        /// <summary>
        /// Gets or sets the value of distance to the left border.
        /// </summary>
        internal int Left { get; set; }

        /// <summary>
        /// Gets or sets the value of distance to the top border.
        /// </summary>
        internal int Top { get; set; }

        /// <summary>
        /// Gets or sets the value of the level of the object.
        /// </summary>
        internal int Level { get; set; }

        /// <summary>
        /// Gets or sets the value of the name of the object.
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the coverage of the object.
        /// </summary>
        internal double Coverage { get; set; }

        /// <summary>
        /// Gets or sets the value of the area of the object.
        /// </summary>
        internal double Area { get; set; }

        /// <summary>
        /// Method to change the font color. Needed for the drawing.
        /// </summary>
        /// <param name="color">Contains the enumeration number of the needed color.</param>
        internal static void Color(int color)
        {
            switch (color)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        /// <summary>
        /// Abstract method for drawing an object.
        /// </summary>
        /// <param name="object_xy">Contains the object for drawing.</param>
        internal abstract void Draw(GeometricObject object_xy);
    }
}
