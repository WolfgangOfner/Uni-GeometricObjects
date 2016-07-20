// ----------------------------------------------------------------------- 
// <copyright file="Circle.cs" company="FHWN"> 
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
    /// Class of the object circle.
    /// </summary>
    internal class Circle : GeometricObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="name">String contains the name of the object.</param>
        /// <param name="border_color">String contains the border color of the object.</param>
        /// <param name="padding_color">String contains the padding color of the object.</param>
        /// <param name="left">Integer contains the distance to the left border of the object.</param>
        /// <param name="top">Integer contains the distance to the right border of the object.</param>
        /// <param name="level">Integer contains the Level of the object.</param>
        /// <param name="radius">Integer contains the radius of the object.</param>
        internal Circle(string name, string border_color, string padding_color, int left, int top, int level, int radius)
            : base(name, border_color, padding_color, left, top, level)
        {
            this.Radius = radius;
            this.Coverage = 2 * radius * Math.PI;
            this.Area = radius * radius * Math.PI;
        }

        /// <summary>
        /// Gets or sets the value of the radius of the object.
        /// </summary>
        internal int Radius { get; set; }

        /// <summary>
        /// Method to draw a circle with a border and padding color.
        /// </summary>
        /// <param name="circle">Object Circle.</param>
        internal override void Draw(GeometricObject circle)
        {
            string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            int border = 0;
            int padding = 0;

            for (int i = 0; i < 16; i++)
            {                                                                       // takes the index of the needed border color
                if (circle.Border.ToUpper().Equals(colorNames[i].ToUpper()))
                {
                    border = i;
                    break;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (circle.Padding.ToUpper().Equals(colorNames[i].ToUpper()))
                {                                                                   // takes the index of the needed padding color
                    padding = i;
                    break;
                }
            }

            int printed_objects = 0;                                                    // counts how many X are printed in one row
            bool printed_all_objects = false;                                           // true if printed objects == 2* radius - 1
            int set_rows = 0;

            if (this.Radius == 2)
            {
                for (int i = 0; i <= this.Radius; i++)
                {
                    for (int j = 0; j <= 2 * this.Radius; j++)
                    {
                        Console.SetCursorPosition(circle.Left + j, circle.Top + i);

                        if (j == 2 - i || j == 2 + i)
                        {
                            GeometricObject.Color(border);
                            Console.WriteLine("#");
                        }

                        if (j > this.Radius - i && j < this.Radius + i)
                        {
                            GeometricObject.Color(padding);
                            Console.WriteLine("#");
                        }
                    }

                    if (i == 2)
                    {
                        int distance_to_middle = 1;
                        for (int ii = i + 1; ii <= 2 * this.Radius; ii++)
                        {
                            for (int jj = 0; jj <= 2 * this.Radius; jj++)
                            {
                                Console.SetCursorPosition(circle.Left + jj, circle.Top + ii);
                                if (jj == this.Radius - distance_to_middle || jj == distance_to_middle + this.Radius)
                                {
                                    GeometricObject.Color(border);
                                    Console.WriteLine("#");
                                }

                                if (jj > this.Radius - distance_to_middle && jj < distance_to_middle + this.Radius)
                                {
                                    GeometricObject.Color(padding);
                                    Console.WriteLine("#");
                                }
                            }

                            distance_to_middle--;
                        }
                    }
                }
            }
            else
            {
                // top down inclusive the middle
                for (int i = 0; i < (2 * this.Radius) - 3; i++)
                {
                    set_rows = i;
                    if (printed_objects != (2 * this.Radius) - 1)
                    {                                                                       // resets ptrinted objects to 0 if the last rows doesn't contain 2 * radius -1 objects, needed not to gain a diamond                                           
                        printed_objects = 0;
                    }
                    else
                    {                                                                       // else bool = true, to know that this is the maximum size of the row length
                        printed_all_objects = true;
                    }

                    for (int j = 0; j < (2 * this.Radius) + 1; j++)
                    {
                        Console.SetCursorPosition(circle.Left + j, circle.Top + i);
                        if (printed_all_objects == true)
                        {
                            if (j == 0 || j == (2 * this.Radius))
                            {                                                               // prints the border at the same position around the middle to gain a cirlce and not a diamond
                                GeometricObject.Color(border);
                                Console.WriteLine("#");
                            }

                            if (j > 0 && j < 2 * this.Radius)
                            {                                                               // if curser is between the border print padding
                                GeometricObject.Color(padding);
                                Console.WriteLine("#");
                            }

                            if (this.Radius == 4 && i == (2 * this.Radius) - 4)
                            {
                                set_rows = 5;
                                Console.SetCursorPosition(circle.Left + j, circle.Top + set_rows);

                                if (j == 0 || j == (2 * this.Radius))
                                {                                                               // prints the border at the same position around the middle to gain a cirlce and not a diamond
                                    GeometricObject.Color(border);
                                    Console.WriteLine("#");
                                }

                                if (j > 0 && j < 2 * this.Radius)
                                {                                                               // if curser is between the border print padding
                                    GeometricObject.Color(padding);
                                    Console.WriteLine("#");
                                }
                            }
                        }
                        else
                        {
                            if (j == this.Radius - (this.Radius / 2) - i || j == this.Radius + (this.Radius / 2) + i)
                            {                                                                               // prints the border, steps every row one step futher away from the middle
                                GeometricObject.Color(border);
                                printed_objects++;
                                Console.WriteLine("#");
                            }

                            if (j > this.Radius - (this.Radius / 2) - i && j < this.Radius + (this.Radius / 2) + i)
                            {                                                                               // if curser is between the border
                                if (i == 0)
                                {                                                                           // border from the first row
                                    GeometricObject.Color(border);
                                }
                                else
                                {
                                    GeometricObject.Color(padding);
                                }

                                printed_objects++;                                                          // contains how many objects were printed in the row
                                Console.WriteLine("#");
                            }
                        }
                    }
                }

                if (this.Radius % 2 == 1)
                {
                    if (this.Radius == 3)
                    {                                                                       // two additional rows are needed around the middle
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < (2 * this.Radius) + 1; j++)
                            {
                                Console.SetCursorPosition(circle.Left + j, circle.Top + set_rows + i + 1);
                                if (j == 0 || j == (2 * this.Radius))
                                {                                                               // prints the border at the same position around the middle to gain a cirlce and not a diamond
                                    GeometricObject.Color(border);
                                    Console.WriteLine("#");
                                }

                                if (j > 0 && j < 2 * this.Radius)
                                {                                                               // if curser is between the border print padding
                                    GeometricObject.Color(padding);
                                    Console.WriteLine("#");
                                }
                            }
                        }

                        set_rows += 2;                                                       // increases set_rows by 2 because of the one additional row which is needed with radius == 3
                    }

                    if (this.Radius == 5)
                    {                                                                       // one additional row is needed around the middle
                        for (int j = 0; j < (2 * this.Radius) + 1; j++)
                        {
                            Console.SetCursorPosition(circle.Left + j, circle.Top + set_rows + 1);
                            if (j == 0 || j == (2 * this.Radius))
                            {                                                               // prints the border at the same position around the middle to gain a cirlce and not a diamond
                                GeometricObject.Color(border);
                                Console.WriteLine("#");
                            }

                            if (j > 0 && j < 2 * this.Radius)
                            {                                                               // if curser is between the border print padding
                                GeometricObject.Color(padding);
                                Console.WriteLine("#");
                            }
                        }

                        set_rows++;                                                         // increases set_rows by 1 because of the one additional row which is needed with radius == 5
                    }

                    // after the rows around the middle down to the bottom
                    for (int i = 0; i <= this.Radius / 2; i++)
                    {
                        for (int j = 0; j < 2 * this.Radius; j++)
                        {
                            Console.SetCursorPosition(circle.Left + j, circle.Top + set_rows + i + 1);

                            if (j > i + 1 && j < (2 * this.Radius) - i)
                            {                                                                               // if curser is between the border
                                if (i == this.Radius / 2 || j == (2 * this.Radius) - i - 1)
                                {                                                                           // border from the first row
                                    GeometricObject.Color(border);
                                }
                                else
                                {
                                    GeometricObject.Color(padding);
                                }

                                Console.WriteLine("#");
                            }

                            if (j == i + 1)
                            {
                                GeometricObject.Color(border);
                                Console.WriteLine("#");
                            }
                        }
                    }
                }
                else
                {       // after the rows around the middle down to the bottom
                    for (int i = 0; i < this.Radius / 2; i++)
                    {
                        for (int j = 0; j < 2 * this.Radius; j++)
                        {
                            Console.SetCursorPosition(circle.Left + j, circle.Top + set_rows + i + 1);
                            if (j > i + 1 && j < (2 * this.Radius) - i)
                            {                                                                               // if curser is between the border
                                if (i == (this.Radius / 2) - 1 || j == (2 * this.Radius) - i - 1)
                                {                                                                           // border from the first row
                                    GeometricObject.Color(border);
                                }
                                else
                                {
                                    GeometricObject.Color(padding);
                                }

                                Console.WriteLine("#");
                            }

                            if (j == i + 1)
                            {
                                GeometricObject.Color(border);
                                Console.WriteLine("#");
                            }
                        }
                    }
                }
            }

            Console.ResetColor();
        }
    }
}
