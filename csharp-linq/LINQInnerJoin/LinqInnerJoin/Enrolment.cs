namespace LinqInnerJoin
{
   public class Enrolment
   {
       public int Id { get; set; }
       public int StudentId { get; set; }
       public int CourseId { get; set; }
   
       public static IEnumerable<Enrolment> GetDummyEnrolment()
       {
           int id = 1;
           IEnumerable<Enrolment> enrolments = new List<Enrolment>()
           {
               new Enrolment { Id = id++, CourseId = 1, StudentId = 1},
               new Enrolment { Id = id++, CourseId = 8, StudentId = 1},
               new Enrolment { Id = id++, CourseId = 12, StudentId = 1},
               new Enrolment { Id = id++, CourseId = 2, StudentId = 2},
               new Enrolment { Id = id++, CourseId = 3, StudentId = 2},
               new Enrolment { Id = id++, CourseId = 7, StudentId = 3},
               new Enrolment { Id = id++, CourseId = 1, StudentId = 3},
               new Enrolment { Id = id++, CourseId = 9, StudentId = 4},
               new Enrolment { Id = id++, CourseId = 9, StudentId = 5},
               new Enrolment { Id = id++, CourseId = 6, StudentId = 6},
               new Enrolment { Id = id++, CourseId = 5, StudentId = 6},
               new Enrolment { Id = id++, CourseId = 11, StudentId = 6},
               new Enrolment { Id = id++, CourseId = 9, StudentId = 7},
               new Enrolment { Id = id++, CourseId = 12, StudentId = 8},
               new Enrolment { Id = id++, CourseId = 7, StudentId = 8},
               new Enrolment { Id = id++, CourseId = 1, StudentId = 9},
               new Enrolment { Id = id++, CourseId = 10, StudentId = 9},
               new Enrolment { Id = id++, CourseId = 4, StudentId = 10},
               new Enrolment { Id = id++, CourseId = 10, StudentId = 10},
               new Enrolment { Id = id++, CourseId = 8, StudentId = 10},
           };                                                     
   
           return enrolments;
       }
   }
}
