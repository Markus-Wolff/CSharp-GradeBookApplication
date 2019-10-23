using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name): base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int limit = (int)Math.Ceiling(this.Students.Count * 0.2);
            List<double> grades = this.Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (grades[limit - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(limit * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(limit * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(limit * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
