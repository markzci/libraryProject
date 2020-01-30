using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MarkusLib.Models;
using System.Linq;
using System.Threading;

namespace MarkusLib
{
    class Program
    {
        public static void Header()
        {
            Console.Clear();
            DateTime dtu = DateTime.Now;

            Console.WriteLine("\t\t\t" + dtu.ToString("MM-dd-yyyy"));
            Console.WriteLine("====================================");
            Console.WriteLine("Library Manager");
            Console.WriteLine("====================================");
        }

        public static void Footer()
        {
            Console.WriteLine("====================================");
        }

        public static void MainMenu()
        {
            Console.WriteLine("1) View all books");
            Console.WriteLine("2) Add a book");
            Console.WriteLine("3) Edit a book");
            Console.WriteLine("4) Search for a book");
            Console.WriteLine("5) Save and exit");
            Footer();
            Console.Write("Please Make a Selection [1-5]:");
        }

        public static void ViewAll()
        {
            Console.WriteLine("==== View Books by ID and Title ==== \n");


            var libContext = new LibContext();
            var entireLibrary = libContext.Books
                                       .ToList();
            
            var count = entireLibrary.Count();
            if (count > 0)
            {
                foreach (var book in entireLibrary)
                {
                    Console.WriteLine("[" + book.ID + "]" + book.title + "\n");
                }
                Console.WriteLine("To view details enter the book ID, to return press <Enter>.");
                Console.Write("Enter ID Number:");
            }
            else
            {
                Console.WriteLine("Nothing found in the Library.\n");
                Console.WriteLine("To Add an Item, press <Enter> to return to the Main Menu and select Add a Book.\n");
            }
           

            if (count > 0)
            {
                while (true)
                {
                    var bookIdInput = Console.ReadLine();
                    if (int.TryParse(bookIdInput, out int id))
                    {
                        var bookById = libContext.Books
                                              .Where(b => b.ID == id)
                                              .ToList();

                        foreach (var book in bookById)
                        {
                            Console.WriteLine("\nID:" + book.ID);
                            Console.WriteLine($"Title: {book.title}");
                            Console.WriteLine($"Author: {book.author}");
                            Console.WriteLine($"Summary: {book.summary}" + "\n");
                        }
                        Console.WriteLine("To view details enter the book ID, to return to the Main Menu press <Enter>.");
                        Console.Write("Enter ID Number:");
                    }
                    else
                        break;
                }
            }
        }
        
        public static void Add()
        {
            Header();
            Console.WriteLine("==== Add a Book ==== \n");
            Console.WriteLine("To Add a Book, press <Enter> to proceed, or press <Escape> to return to the Main Menu.  \n");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.Key != ConsoleKey.Escape && cki.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("==== Add a Book ==== \n");

                do
                {
                    Console.WriteLine("Please enter the following information: \n");
                    Console.Write("Title:");
                    string title = Console.ReadLine();

                    Console.Write("Author:");
                    string author = Console.ReadLine();

                    Console.Write("Summary:");
                    string summary = Console.ReadLine();

                    using var libContext = new LibContext();
                    var std = new Book()
                    {
                        title = title,
                        author = author,
                        summary = summary
                    };
                    libContext.Books.Add(std);

                    libContext.SaveChanges();
                    Console.WriteLine($"Book[{std.ID}] saved.\n");
                    ViewAll();
                    break;
                }
                while (true);
            }
        }

        public static void Edit()
        {
            Console.WriteLine("==== Edit a Book ==== \n");


            var libContext = new LibContext();
            var entireLibrary = libContext.Books
                                       .ToList();

            var count = entireLibrary.Count();
            if (count > 0)
            {
                foreach (var book in entireLibrary)
                {
                    Console.WriteLine("[" + book.ID + "]" + book.title + "\n");
                }
                Console.WriteLine("To edit the details of a Book, enter the Book's ID number; to return to the Main Menu press <Enter>.");
                Console.Write("Enter ID Number:");
            }
            else
            {
                Console.WriteLine("Nothing found in the Library.\n");
                Console.WriteLine("To Add an Item, press <Enter> to return to the Main Menu and select Add a Book.\n");
            }


            if (count > 0)
            {
                while (true)
                {
                    var editBookIdInput = Console.ReadLine();
                    if (int.TryParse(editBookIdInput, out int id))
                    {
                        var editBookById = libContext.Books
                                              .Where(b => b.ID == id)
                                              .ToList();

                        foreach (var book in editBookById)
                        {
                            Console.WriteLine("\nID:" + book.ID +"\n");
                            Console.WriteLine("Input the following information. To leave a field unchanged, hit <Enter> ");

                            Console.WriteLine(book.title);
                            Console.WriteLine(book.author);
                            Console.WriteLine(book.summary + "\n");
                        }
                        Console.WriteLine("To view details enter the book ID, to return to the Main Menu press <Enter>.");
                        Console.Write("Enter ID Number:");
                    }
                    else
                        break;
                }
            }
        }


        static void Main(string[] args)
        {
            do
            {
                Header();
                MainMenu();

                var selection = Console.ReadLine();

                if (int.TryParse(selection, out int number))
                {
                    switch (number)
                    {
                        case 1:
                            Header();
                            ViewAll();
                            break;
                        case 2:
                            Add();
                            break;
                        case 3:
                            Header();
                            Edit();
                            break;
                        
                    }
                }
            }
            while (true);   
        }
    }
}
