#include <iostream>
#include <vector>
#include "ArrayCreator.h"
#include "FileHandler.h"

int main()
{
	std::unique_ptr<int> ptr(new int(42));
	std::cout << *ptr << std::endl;

	std::vector<int> vec = { 1, 2, 3, 4, 5 };
	for (int i = 0; i < vec.size(); i++) {
		std::cout << vec[i] << std::endl;
	}

	FileHandler handler("example.txt");
	handler.file << "Hello, world!\n";
	
	ArrayCreator arr(5);

	for (int i = 0; i < arr.GetSize(); i++) {
		arr.SetValue(i, i * 10);
	}

	for (int i = 0; i < arr.GetSize(); i++) {
		std::cout << arr.GetValue(i) << " ";
	}

	std::cout << std::endl;

	arr.~ArrayCreator();

	return 0;
}