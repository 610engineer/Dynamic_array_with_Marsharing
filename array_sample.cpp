#include <afx.h>
#include <afxtempl.h>
#include <iostream>


CArray<int, int> carray;

extern "C" {
	__declspec(dllexport) void Array_func(int num ,int* array) {
		for (int i = 0; i < num; i++) {
			//copy value from array to carray
			carray.Add(array[i]);
			std :: cout << "carray[" << i << "] = " << array[i] << std :: endl;
		}
	}
}