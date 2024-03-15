namespace LinqInnerJoin
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static IEnumerable<Category> GetDummyCourseCategories()
        {
            List<string> categories = new()
            {
                "Programming Language",
                "DevOps",
                "Database System"
            };

            List<Category> courseCategories = new List<Category>();
            int id = 1;

            foreach (var category in categories)
            {
                courseCategories.Add(new Category
                {
                    Id = id++,
                    Name = category
                });
            }

            return courseCategories;
        }
    }

}
