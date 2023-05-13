#include "pch.h"
#include "CppUnitTest.h"
#include "../UnmanagedCode/ArrayCreator.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnmangedCodeTests
{
	TEST_CLASS(UnmangedCodeTests)
	{
	public:

		TEST_METHOD(WhenCallingConstructor_ThenAllocateMemory)
		{
			ArrayCreator arr(5);

			Assert::AreEqual(5, arr.GetSize());
		}

		TEST_METHOD(WhenSettingValue_ThenSetValueCorrectly)
		{
			ArrayCreator arr(5);

			arr.SetValue(0, 10);

			Assert::AreEqual(10, arr.GetValue(0));

			arr.SetValue(3, -5);

			Assert::AreEqual(-5, arr.GetValue(3));
		}
	};
}
