using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._7
{
    class Book
    {
        public string Author { get; set; }
        public string BookName { get; set; }

        public Book(string bookAuth, string bookName)
        {
            Author = bookAuth;
            BookName = bookName;
        }
    }

    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
