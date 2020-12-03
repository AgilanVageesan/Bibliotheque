using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovarianceContravarianceLegacy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<College> listCollege = new List<College>();
            listCollege.Add(new College() {universityID=1,universityLocation="Mumbai",universityName="Univ1",collegeName="Coll1"});
            listCollege.Add(new College() { universityID = 2, universityLocation = "Delhi", universityName = "Univ2", collegeName = "Coll2" });
            University unv = new College();

        }
    }

    public class University
    {
        public int universityID;
        public string universityName;
        public string universityLocation;
    }

    public class College : University
    {
        public string collegeName;
    }
}
