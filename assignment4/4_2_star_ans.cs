using System;

namespace star
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius: ");
            int radius = int.Parse(Console.ReadLine());
            int size = 2 * (radius + 1);

            // ---------- TODO ----------
            for(int i=0; i<size;i++){
                if (i==0){
                    for(int j=0; j < size-2;j++){
                        Console.Write(" ");
                    }
                    for(int j2=0; j2<(int)size;j2++){
                        if(j2==(int)(size/3)|j2 == (int)(2*size/3)){
                            Console.Write("*");
                        }
                        else{
                            Console.Write(" ");
                        }
                    }
                    Console.Write("\n");
                }
                else if(i == 1|i == size-1){
                    Console.Write(" ");
                    for(int j=0;j<2*radius-1;j++){
                        Console.Write("*");
                    }
                    for(int j2=0; j2<(int)size;j2++){
                        if(j2==(int)(size/3)|j2 == (int)(2*size/3)){
                            Console.Write("*");
                        }
                        else{
                            Console.Write(" ");
                        }
                    }
                    Console.Write("\n");
                }
                else if(i==(int)(size/3)|i == (int)(2*size/3)){
                    Console.Write("*");
                    for(int j=0; j<2*radius-1;j++){
                        Console.Write(" ");
                    }
                    for(int j2=0; j2<size;j2++){
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
                else{
                    Console.Write("*");
                    for(int j=0;j<2*radius-1;j++){
                        Console.Write(" ");
                    }
                    for(int j2=0; j2<(int)size;j2++){
                        if(j2==(int)(size/3)|j2 == (int)(2*size/3)){
                            Console.Write("*");
                        }
                        else{
                            Console.Write(" ");
                        }
                    }
                    Console.Write("\n");
                }
            }

            // --------------------
        }

        // calculate the distance between (x1, y1) and (x2, y2)
        static double SqrDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
        }

        // Checks if two values a and b are within a given distance.
        // |a - b| < distance
        static bool IsClose(double a, double b, double distance)
        {
            return Math.Abs(a - b) < distance;
        }
    }
}


/* example output
Enter the radius: 
>> 5
                *   *   
  *********     *   *   
 *              *   *   
 *              *   *   
 *          ************
 *              *   *   
 *              *   *   
 *              *   *   
 *          ************
 *              *   *   
 *              *   *   
  *********     *   *   

*/

/* example output (CHALLANGE)
Enter the radius: 
>> 5
                *   *  
      *         *   *  
   *     *      *   *  
  *                    
           ************
               *   *   
 *             *   *   
               *   *   
           ************
  *                    
   *     *    *   *    
      *       *   *    

*/
