namespace DeleteElementsFromAnArray {
    public static partial class Methods {
        public static int[] DeleteWithLoop(int[] inputArray, int elementToDelete) {
            var newSize = 0;

            for (int i = 0; i < inputArray.Length; i++) {
                if (inputArray[i] != elementToDelete) {
                    inputArray[newSize] = inputArray[i];
                    newSize++;
                }
            }

            Array.Resize(ref inputArray, newSize);

            return inputArray;
        }
    }
}
