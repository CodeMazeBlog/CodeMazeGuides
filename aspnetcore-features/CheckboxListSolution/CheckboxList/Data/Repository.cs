using CheckboxList.Models;

namespace CheckboxList.Data
{
    public class Repository
    {
        public static IReadOnlyList<CheckboxViewModel> GetCourses()
        {
            return new List<CheckboxViewModel>
            {
                new CheckboxViewModel
                {
                    Id = 1,
                    LabelName = "Physics",
                    IsChecked = true
                },
                new CheckboxViewModel
                {
                    Id = 2,
                    LabelName = "Chemistry",
                    IsChecked = false
                },
                new CheckboxViewModel
                {
                    Id = 3,
                    LabelName = "Mathematics",
                    IsChecked = true
                },
                new CheckboxViewModel
                {
                    Id = 4,
                    LabelName = "Biology",
                    IsChecked = false
                }
            };
        }
    }
}