namespace ActionFuncDelegate {

    public class ActionDelegate {

        public static int Sum { get; set; }
        
        public static void Add(int a, int b) {
            Sum = a+b;
        }
        
        public static void Demonstrate() {
            int valA = 100;
            int valB = 40;

            Action<int, int> addDel = new Action<int, int>(ActionDelegate.Add);
            Action<string> printDel = Console.WriteLine;

            addDel(valA, valB);
            printDel("Sum of the two values is = " + Sum);
        }
    }
}
