using System;
using System.Collections.Generic;

namespace CovarianceContravariance
{
    class Program
    {
        static void Main(string[] args)
        {



           // Covariance();
            Contravariance();
            Console.ReadKey();

        }

        enum Colors
        {
            Red = 4, //4
            Green, //5
            Yellow,// 6
            Blue// 7
        }



        static void Covariance()
        {
            List<College> listCollege = new List<College>();
            listCollege.Add(new College()
            {
                universityID = 1,
                universityLocation = "Mumbai",
                universityName = "Univ1",
                collegeName = "Coll1"
            });
            listCollege.Add(new College()
            {
                universityID = 2,
                universityLocation = "Delhi",
                universityName = "Univ2",
                collegeName = "Coll2"
            });

            //Covariance 
            IEnumerable<University> listUniv = listCollege;

            foreach (var itr in listUniv)
            {
                Console.WriteLine(itr.universityName + "|" + ((College)itr).collegeName);
            }
        }

       
        static void Contravariance()
        {
            IComparer<College> collegeComp = new University();
            College x = new College();
            x.universityID = 2;
            College y = new College();
            y.universityID = 4;
            collegeComp.Compare(x,y);

            collegeComp = new College();
            collegeComp.Compare(x, y);



        }
    }

    struct strctEmpoyee
    {
        public int age;
        public string name;
    }

    public class Employee
    {
        public int age;
        public string name;
        public bool isActiveOnRecords;
    }

    public class University : IComparer<University>
    {
        public int universityID;
        public string universityName;
        public string universityLocation;
        int IComparer<University>.Compare(University x, University y)
        {
            if (x.universityID > y.universityID)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


    public class College:University,IComparer<College>
    {
        public string collegeName;
        int IComparer<College>.Compare(College x, College y)
        {
            if (x.universityID > y.universityID)
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }
    }
}
