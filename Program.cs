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
        [DllImport("ArraySample2.dll", EntryPoint = "Array_func")]
        public static extern void Array_func(int num, IntPtr array);
        static void Main(string[] args)
        {
            int length;
            int[] array;
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            array = list.ToArray();
            length = array.Length;
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * length);
            Marshal.Copy(array, 0, ptr, length);

            Array_func(length, ptr);

            Marshal.FreeCoTaskMem(ptr);


            
        }
    }
}
