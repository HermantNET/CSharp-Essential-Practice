using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub
{
    interface IListable
    {
        string[] ColumnValues
        {
             get;
        }
    }

    //Inspired by 'Esseential C# 6.0' 5th Edition
    class Publication : IListable
    {
        public Publication(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        #region IListable Members
        string[] IListable.ColumnValues
        {
            get
            {
                return new string[]
                {
                    Title,
                    Author,
                    Year.ToString()
                };
            }
        }
        #endregion

        public static string[] Headers
        {
            get
            {
                return new string[]
                {
                    "Title                       ",
                    "Author            ",
                    "Year"
                };
            }
        }
    }

    //Can receive any class that utilizes IListable and provides a string of headers.
    class ConsoleListControl
    {
        public static void List(string[] headers, IListable[] items)
        {
            int[] columnwidths = DisplayHeaders(headers);

            for (int count = 0; count < items.Length; count++)
            {
                string[] values = items[count].ColumnValues;
                DisplayItemRow(columnwidths, values);
            }
        }

        //returns int array of column widths
        private static int[] DisplayHeaders(string[] headers)
        {
            int[] total = new int[headers.Length];

            //writes headers
            for (int i = 0; i < headers.Length; i++) { total[i] = headers[i].Length; Console.Write(headers[i]); }
            Console.Write("\n");
            return total;
        }

        //This parts a little hard to read without context. This method recieves the column widths of the headers and the string arrays of new string arrays(arrays of arrays!).
        private static void DisplayItemRow(int[] columnWidths, string[] values)
        {
            //The method loops through all the strings(which are arrays in themselves) in the values variable.
            for (int i = 0; i < values.Length; i++)
            {
                //Because there needs to be a new line when the all the columns have been filled, you need to create another loop that ends at the end of the total headers.
                for (int j = 0; j < columnWidths.Length; j++, i++) {
                    //If a title is not the length of the header, this statement adds a space until they become equal.
                    if (values[i].Length < columnWidths[j]) {
                        while (values[i].Length < columnWidths[j]) {
                            values[i] += " ";
                        }
                    }
                    //Writes the records to fill all fields.
                    Console.Write(values[i]); }
                //When all fields are filled, go to next line.
                Console.WriteLine();
            }
        }
    }
}
