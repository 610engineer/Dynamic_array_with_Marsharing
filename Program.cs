using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace arraysample1
{
    class Program
    {
        //definition C++ method
        [DllImport("ArraySample2.dll", EntryPoint = "Array_func")]
        public static extern void Array_func(int num, IntPtr array);
        
        static void Main(string[] args)
        {
            //length dynamic array
            int length;
            int[] array;
            List<int> list = new List<int>();

            //add value to List
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //transfer List to array
            array = list.ToArray();
            length = array.Length;
            
            //keep memory for array size
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * length);

            //copy array value to "ptr"
            Marshal.Copy(array, 0, ptr, length);

            //call C++ method
            Array_func(length, ptr);

            //release memory
            Marshal.FreeCoTaskMem(ptr);


            
        }
    }
}
