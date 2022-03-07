using System;
using System.Linq;

namespace SliceArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            SliceArrayUsingRangeOperator();
        }

        static void SliceArrayUsingLINQ()
        {
            var posts = new string[] { "post1", "post2", "post3", "post4", "post5", "post6", "post7", "post8", "post9", "post10" }; 
            var slicedPosts = posts.Skip(0).Take(5); 
            foreach (var post in slicedPosts) 
                Console.WriteLine(post); // Outputs the first 5 posts
        }

        static void SliceArrayUsingCopy()
        {
            var posts = new string[] { "post1", "post2", "post3", "post4", "post5", "post6", "post7", "post8", "post9", "post10" }; 
            var slicedPosts = new string[5]; 
            Array.Copy(posts, 0, slicedPosts, 0, 5); 
            foreach (var post in slicedPosts) 
                Console.WriteLine(post); // Outputs the first 5 posts
        }

        static void SliceArrayUsingArraySegment()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) }; 
            var trainingData = new ArraySegment<Tuple<int, bool>>(data, 0, 3); 
            var testingData = new ArraySegment<Tuple<int, bool>>(data, 3, 2); 
            
            Console.WriteLine("Training Data:"); 
            foreach (var record in trainingData) 
                Console.WriteLine(record); 
            
            Console.WriteLine(); 
            Console.WriteLine("Testing Data:"); 
            foreach (var record in testingData) 
                Console.WriteLine(record);
        }

        static void SliceArrayUsingArraySegmentSlice()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };
            var arraySegment = new ArraySegment<Tuple<int, bool>>(data);
            var trainingData = arraySegment.Slice(0, 3);
            var testingData = arraySegment.Slice(3, 2);

            Console.WriteLine("Training Data:");
            foreach (var record in trainingData)
                Console.WriteLine(record);

            Console.WriteLine();
            Console.WriteLine("Testing Data:");
            foreach (var record in testingData)
                Console.WriteLine(record);
        }

        static void SliceArrayUsingArraySegmentWithChanging()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };
            var trainingData = new ArraySegment<Tuple<int, bool>>(data, 0, 3);
            Console.WriteLine("Training Data:");
            for (int i = 0; i < trainingData.Count; i++)
            {
                trainingData[i] = new(40, false);
                Console.WriteLine(trainingData[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Original Data:");
            foreach (var record in data)
                Console.WriteLine(record);
        }

        static void SliceArrayUsingReadOnlySpan()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };
            var trainingData = new ReadOnlySpan<Tuple<int, bool>>(data, 0, 3);
            var testingData = new ReadOnlySpan<Tuple<int, bool>>(data, 3, 2);
            Console.WriteLine("Training Data:");
            foreach (var record in trainingData)
                Console.WriteLine(record);

            Console.WriteLine();
            Console.WriteLine("Testing Data:");
            foreach (var record in testingData)
                Console.WriteLine(record);
        }

        static void SliceArrayUsingRangeOperator()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var slice1 = array[2..]; // From index 2 to the end
            var slice2 = array[..3]; // From the start to index 2
            var slice3 = array[1..3]; // From the index 1 to index 2
            var slice4 = array[..]; // The whole array
            var slice5 = array[3..1]; // Throws ArgumentOutOfRangeException
        }
    }
}
