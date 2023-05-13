#include <string>
#include <fstream>

class FileHandler
{
public:
	FileHandler(const std::string& filename) : file(filename) {}

	~FileHandler() {
		if (file.is_open()) {
			file.close();
		}
	}
	std::fstream file;
};
