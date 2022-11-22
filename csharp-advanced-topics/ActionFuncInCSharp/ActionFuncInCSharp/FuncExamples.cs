namespace ActionFuncInCSharp
{
    public class FuncExamples
    {
        public float CallFunc()
        {
            FloatBasicCalculator floatBasicCalculator = new();
            Func<float, float, float> calcFunc = floatBasicCalculator.Addition;

            return calcFunc(3, 2);
        }

        public static Func<int, int, int>? GetCalcFunc(BasicCalculationEnum basicCalculation)
        {
            IntBasicCalculator intBasicCalculator = new();
            switch (basicCalculation)
            {
                case BasicCalculationEnum.Addition:
                    return intBasicCalculator.Addition;
                case BasicCalculationEnum.Subtraction:
                    return intBasicCalculator.Subtraction;
                case BasicCalculationEnum.Multiplication:
                    return intBasicCalculator.Multiplication;
                case BasicCalculationEnum.Division:
                    return intBasicCalculator.Division;
            }

            return null;
        }

        public int FuncAsMethodReturnType()
        {
            var func = GetCalcFunc(BasicCalculationEnum.Addition);

            return func(5, 4);
        }

        public List<string> FuncAsParameter()
        {
            Func<string, bool> whereFunc = (string s) => s.Contains('C');

            List<string> progLang = new() { "C", "C++", "C#", "F#", "Rust", "Go" };
            var cLang = progLang.Where(whereFunc).ToList();

            return cLang;
        }
    }
}
