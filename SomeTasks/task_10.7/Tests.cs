using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._7
{
    class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Author == y.Author)
            {
                if (x.BookName == y.BookName)
                {
                    return 0;
                }
                else if (x.BookName.CompareTo(y.BookName) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return string.Compare(x.Author, y.Author);
            }
        }
    }

    class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (Math.Sqrt(x.X * x.X + x.Y * x.Y) == Math.Sqrt(y.X * y.X + y.Y * y.Y))
            {
                return 0;
            }
            else if (Math.Sqrt(x.X * x.X + x.Y * x.Y) < Math.Sqrt(y.X * y.X + y.Y * y.Y))
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    [TestFixture]
    class Tests
    {
        BinarySearchTree<string> binTreeString;
        BinarySearchTree<Book> binTreeBook;
        BinarySearchTree<Point> binTreePoint;
        BookComparer bookCompare;
        PointComparer pointCompare;
        
        [SetUp]
        public void SetUp()
        {
            pointCompare = new PointComparer();
            bookCompare = new BookComparer();
            binTreeBook = new BinarySearchTree<Book>(bookCompare);
            binTreePoint = new BinarySearchTree<Point>(pointCompare);
            binTreeString = new BinarySearchTree<string>(StringComparer.CurrentCulture);
        }

        [Test]
        public void Add_SomeString_StringContains()
        {
            binTreeString.Add("ABC");
            Assert.AreEqual(true, binTreeString.Contains("ABC"));
        }

        [Test]
        public void Add_SomeBook_BookContains()
        {
            binTreeBook.Add(new Book("Richter", "Clr via C#"));
            Assert.AreEqual(true, binTreeBook.Contains(new Book("Richter", "Clr via C#")));
        }

        [Test]
        public void Add_SomePoint_PointContains()
        {
            binTreePoint.Add(new Point(12, 15));
            Assert.AreEqual(true, binTreePoint.Contains(new Point(12, 15)));
        }

        [Test]
        public void AddRange_SomeString_StringContains()
        {
            binTreeString.AddRange(new string[]{"a", "b", "c"});
            Assert.AreEqual(true, (binTreeString.Contains("a") && binTreeString.Contains("b") && binTreeString.Contains("c")));
        }

        [Test]
        public void AddRange_SomeBooks_BookContains()
        {
            binTreeBook.AddRange(new Book[] {new Book("Richter", "Clr via C#"), new Book("Troelsen", "C# 6.0 and the .NET 4.6 Framework") });
            Assert.AreEqual(true, binTreeBook.Contains(new Book("Richter", "Clr via C#")));
            Assert.AreEqual(true, (binTreeBook.Contains(new Book("Richter", "Clr via C#")) && binTreeBook.Contains(new Book("Troelsen", "C# 6.0 and the .NET 4.6 Framework"))));
        }

        [Test]
        public void AddRange_SomePoint_PointContains()
        {
            binTreePoint.AddRange(new Point[]{new Point(12, 15), new Point(10, 20) });
            Assert.AreEqual(true, binTreePoint.Contains(new Point(12, 15)) && binTreePoint.Contains(new Point(10, 20)));
        }

        [Test]
        public void Count_SomeString_3()
        {
            binTreeString.AddRange(new string[] { "a", "b", "c" });
            Assert.AreEqual(3, binTreeString.Count());
        }

        [Test]
        public void Count_SomeBooks_Two()
        {
            binTreeBook.AddRange(new Book[] { new Book("Richter", "Clr via C#"), new Book("Troelsen", "C# 6.0 and the .NET 4.6 Framework") });
            Assert.AreEqual(2, binTreeBook.Count());
        }

        [Test]
        public void Count_SomePoint_Two()
        {
            binTreePoint.AddRange(new Point[] { new Point(12, 15), new Point(10, 20) });
            Assert.AreEqual(2, binTreePoint.Count());
        }

        [Test]
        public void PreOrderTraversal_SomeString_Excepted()
        {
            binTreeString.AddRange(new string[] { "c", "b", "d", "a", "y", "i"});
            IEnumerable<string> excepted = new string[] {"c", "b", "a", "d", "y", "i"};
            Assert.AreEqual(excepted, binTreeString.PreOrderTraversal());
        }

        [Test]
        public void PreOrderTraversal_SomeBooks_Excepted()
        {
            Book[] books = new Book[] { new Book("Richter", "Clr via C#"), new Book("Troelsen", "C# 6.0 and the .NET 4.6 Framework"), new Book("Albahari", "C# 6.0 in a Nutshell"), new Book("Richter", "a less") };
            binTreeBook.AddRange(books);
            IEnumerable<Book> excepted = new Book[]{books[0], books[2], books[3], books[1]};

            Assert.AreEqual(excepted, binTreeBook.PreOrderTraversal());
        }

        [Test]
        public void PreOrderTraversal_SomePoint_Excepted()
        {
            Point[] points = new Point[] { new Point(12, 15), new Point(10, 20), new Point(5, 12), new Point(22, 33)};
            binTreePoint.AddRange(points);
            IEnumerable<Point> excepted = new Point[]{points[0], points[2], points[1], points[3]};
            Assert.AreEqual(excepted, binTreePoint.PreOrderTraversal());
        }

        [Test]
        public void PostOrderTraversal_SomeString_Excepted()
        {
            binTreeString.AddRange(new string[] { "c", "b", "d", "a", "y", "i" });
            IEnumerable<string> excepted = new string[] { "a", "b", "i", "y", "d", "c" };
            Assert.AreEqual(excepted, binTreeString.PostOrderTraversal());
        }

        [Test]
        public void PostOrderTraversal_SomeBooks_Excepted()
        {
            Book[] books = new Book[] { new Book("Richter", "Clr via C#"), new Book("Troelsen", "C# 6.0 and the .NET 4.6 Framework"), new Book("Albahari", "C# 6.0 in a Nutshell"), new Book("Richter", "a less") };
            binTreeBook.AddRange(books);
            IEnumerable<Book> excepted = new Book[] { books[3], books[2], books[1], books[0] };

            Assert.AreEqual(excepted, binTreeBook.PostOrderTraversal());
        }

        [Test]
        public void PostOrderTraversal_SomePoint_Excepted()
        {
            Point[] points = new Point[] { new Point(12, 15), new Point(10, 20), new Point(5, 12), new Point(22, 33) };
            binTreePoint.AddRange(points);
            IEnumerable<Point> excepted = new Point[] { points[2], points[3], points[1], points[0] };
            Assert.AreEqual(excepted, binTreePoint.PostOrderTraversal());
        }

        [Test]
        public void InOrderTraversal_SomeString_Excepted()
        {
            binTreeString.AddRange(new string[] { "c", "b", "d", "a", "y", "i" });
            IEnumerable<string> excepted = new string[] { "a", "b", "c", "d", "i", "y" };
            Assert.AreEqual(excepted, binTreeString.InOrderTraversal());
        }

        [Test]
        public void InOrderTraversal_SomeBooks_Excepted()
        {
            Book[] books = new Book[] { new Book("Richter", "Clr via C#"), new Book("Troelsen", "C# 6.0 and the .NET 4.6 Framework"), new Book("Albahari", "C# 6.0 in a Nutshell"), new Book("Richter", "a less") };
            binTreeBook.AddRange(books);
            IEnumerable<Book> excepted = new Book[] { books[2], books[3], books[0], books[1] };

            Assert.AreEqual(excepted, binTreeBook.InOrderTraversal());
        }

        [Test]
        public void InOrderTraversal_SomePoint_Excepted()
        {
            Point[] points = new Point[] { new Point(12, 15), new Point(10, 20), new Point(5, 12), new Point(22, 33) };
            binTreePoint.AddRange(points);
            IEnumerable<Point> excepted = new Point[] { points[2], points[0], points[1], points[3] };
            Assert.AreEqual(excepted, binTreePoint.InOrderTraversal());
        }
    }
}
