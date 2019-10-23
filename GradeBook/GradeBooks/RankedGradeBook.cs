using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name): base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }
    }
}
