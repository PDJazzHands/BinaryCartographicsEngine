using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCartographicsEngine.BCEngine.Utilities.TEST_FILES
{
    class PIXELCOLLIDE
    {
        /// <summary>
        /// THIS CLASS IS TAKEN FROM https://www.austincc.edu/cchrist1/GAME1343/TransformedCollision/TransformedCollision.htm
        /// THIS CLASS MUST BE REBUILT, USING THE TRANSFORM CLASS, AND IT MUST BE IMPLEMENTED ON THE TRANSFORM CLASS, TOO
        /// </summary>
        /// <param name="transformA"></param>
        /// <param name="widthA"></param>
        /// <param name="heightA"></param>
        /// <param name="dataA"></param>
        /// <param name="transformB"></param>
        /// <param name="widthB"></param>
        /// <param name="heightB"></param>
        /// <param name="dataB"></param>
        /// <returns></returns>
        static bool IntersectPixels
        (
            Matrix transformA, int widthA, int heightA, Color[] dataA,
            Matrix transformB, int widthB, int heightB, Color[] dataB)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            Matrix transformAToB = transformA * Matrix.Invert(transformB);

            // For each row of pixels in A
            for (int yA = 0; yA < heightA; yA++)
            {
                // For each pixel in this row
                for (int xA = 0; xA < widthA; xA++)
                {
                    // Calculate this pixel's location in B
                    Vector2 positionInB =
                        Vector2.Transform(new Vector2(xA, yA), transformAToB);

                    // Round to the nearest pixel
                    int xB = (int)System.Math.Round(positionInB.X);
                    int yB = (int)System.Math.Round(positionInB.Y);

                    // If the pixel lies within the bounds of B
                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        // Get the colors of the overlapping pixels
                        Color colorA = dataA[xA + yA * widthA];
                        Color colorB = dataB[xB + yB * widthB];

                        // If both pixels are not completely transparent,
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }
                }
            }

            // No intersection found
            return false;
        }
    }
}
