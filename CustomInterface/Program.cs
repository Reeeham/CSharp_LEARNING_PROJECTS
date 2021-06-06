using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interfaces *****\n");
            // Call Points property defined by IPointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine("Points: {0}", hex.Points);


            // Catch a possible InvalidCastException.
            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            /* try
             {
                 itfPt = (IPointy)c;
                 Console.WriteLine(itfPt.Points);
             }
             catch (InvalidCastException e)
             {
                 Console.WriteLine(e.Message);
             }*/

            // Can we treat hex2 as IPointy?
            Hexagon hex2 = new Hexagon("Peter");
            IPointy itfPt2 = hex2 as IPointy;
            if (itfPt2 != null)
                Console.WriteLine("Points: {0}", itfPt2.Points);
            else
                Console.WriteLine("OOPS! Not pointy...");

            // Make an array of Shapes.
            Shape[] myShapes = { new Hexagon(), new Circle(),new Triangle("Joe"), new Circle("JoJo")};
            for (int i = 0; i < myShapes.Length; i++)
            {
                // Recall the Shape base class defines an abstract Draw()
                // member, so all shapes know how to draw themselves.
                myShapes[i].Draw();
                // Who's pointy?
                if (myShapes[i] is IPointy ip)
                    Console.WriteLine("-> Points: {0}", ip.Points);
                // Can I draw you in 3D?
                if (myShapes[i] is IDraw3D)
                    DrawIn3D((IDraw3D)myShapes[i]);
            
                else
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName);
                Console.WriteLine();
            }
            // Get first pointy item.
            // To be safe, you'd want to check firstPointyItem for null before proceeding.
            IPointy firstPointyItem = FindFirstPointyShape(myShapes);
            Console.WriteLine("The item has {0} points", firstPointyItem.Points);
            Console.ReadLine();

            /*Just to highlight the importance of this example, remember this: when you have an array of a given
                 interface, the array can contain any class or structure that implements that interface. */
        }
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        //Interfaces As Return Values
        // This method returns the first object in the
        // array that implements IPointy.
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                if (s is IPointy ip)
                    return ip;
            }
            return null;
        }
    }
}
