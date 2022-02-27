﻿using ExpReader.Models;
using ExpReader.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpReader.ViewModels
{
    class UserLibVM : BindableObject
    {

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        ObservableCollection<Book> db { get; set; }
        public UserLibVM()
        {
            InitBooks();
        }
        //todo нихуя не сделал блять 
        //todo tapped event on listview item to open a book

        public ICommand OpenBookCommand => new Command<Book>(OpenBook);

        public void OpenBook(Book book)
        {
            //string route = $"{nameof(ReaderPage)}?{nameof(ReaderVM.Path)}={book.Path}";
            //string route = $"{nameof(ReaderPage)}?{nameof(ReaderVM.Text)}={book.Path}";
            //Shell.Current.GoToAsync(route);
            Shell.Current.Navigation.PushAsync(new ReaderPage(book.Path));

        }

        private void InitBooks()
        {
            //todo this is test collection. It should be in db or somewhere else
            db = new ObservableCollection<Book>()
            {
                new Book
                {
                    Id = 0,
                    Title = "Преступление и наказание",
                    Author = "Достоевский Ф.М.",
                    Cover = new Uri("https://sun9-78.userapi.com/impg/ZAIRkdW85lMCo-IbM93iu5yeMNEQdNTk9t3wZQ/9KOLEdAridM.jpg?size=448x664&quality=96&sign=b75b2d5971eb40c18b7915c4646368ef&type=album"),
                    Path = "aaaaa.pdf"
                },
                new Book
                {
                    Id = 1,
                    Title = "Путешествия Души",
                    Author = "М. Ньютон",
                    Cover = new Uri("https://sun9-78.userapi.com/impg/ZAIRkdW85lMCo-IbM93iu5yeMNEQdNTk9t3wZQ/9KOLEdAridM.jpg?size=448x664&quality=96&sign=b75b2d5971eb40c18b7915c4646368ef&type=album"),
                    Path = "avidreaders.ru__puteshestviya-dushi.txt"
                },
                new Book
                {
                    Id = 2,
                    Title = "Укрощение строптивой",
                    Author = "Юлия Витальевна Шилова",
                    Cover = new Uri("https://sun9-78.userapi.com/impg/ZAIRkdW85lMCo-IbM93iu5yeMNEQdNTk9t3wZQ/9KOLEdAridM.jpg?size=448x664&quality=96&sign=b75b2d5971eb40c18b7915c4646368ef&type=album"),
                    Path = "213286.txt"
                }
            };

            foreach (var file in db)
            {
                Books.Add(file);
            }
        }
    }
}
