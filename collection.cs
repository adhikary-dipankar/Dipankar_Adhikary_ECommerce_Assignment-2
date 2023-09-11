//using System;
//using System.Collections;

//namespace Prj1Day19Col
//{

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            BitArray myBitArr1 = new BitArray(4);
//            BitArray myBitArr2 = new BitArray(4);
//            myBitArr1[0] = false;
//            myBitArr1[1] = false;
//            myBitArr1[2] = true;
//            myBitArr1[3] = true;
//            myBitArr2[0] = false;
//            myBitArr2[2] = false;
//            myBitArr2[1] = true;
//            myBitArr2[3] = true;
//            PrintValues("\n\nBA1 : ", myBitArr1);
//            PrintValues("\n\nBA2 : ", myBitArr2);
//            PrintValues("\n\nOr : BA1.Or(BA2) : ", myBitArr1.Or(myBitArr2));
//            Console.WriteLine("\n");
//        }
//        public static void PrintValues(string s, IEnumerable myList)
//        {
//            Console.WriteLine(s);
//            foreach (Object obj in myList)
//            {
//                Console.Write(obj + "\t");
//            }
//        }
//    }
//}
