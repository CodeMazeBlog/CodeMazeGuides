#pragma once
class ArrayCreator
{
private:
	int* data;
	int size;

public:
	ArrayCreator(int length) {
		data = new int[length];
		size = length;
	}

	~ArrayCreator() {
		delete[] data;
	}

	int GetSize() const {
		return size;
	}

	void SetValue(int index, int value) {
		data[index] = value;
	}

	int GetValue(int index) const {
		return data[index];
	}
};

