using MovieRentalAppProject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store.Subviews
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : UserControl
    {
        public Movies()
        {
            InitializeComponent();

            UpdateMovieGrid(API.GetMovieSlice(0, 50));

        }

        private void UpdateMovieGrid(List<Movie> Movies)
        {
            if (State.Movies != null)
            {
                State.Movies.Clear();
                MoviesGrid.Children.Clear();
            }
            State.Movies = Movies;
            for (int y = 0; y < MoviesGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MoviesGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MoviesGrid.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];
                        try
                        {

                            //Movie
                            var title = new Label() { };
                            title.Content = movie.Title; // Movies från databas
                            title.FontWeight = FontWeights.UltraBold;
                            title.FontFamily = new FontFamily("Sans-Serif");
                            title.Foreground = Brushes.White;
                            title.HorizontalAlignment = HorizontalAlignment.Center;
                            title.VerticalAlignment = VerticalAlignment.Top;
                            title.FontSize = 12;

                            var image = new Image() { };
                            image.Cursor = Cursors.Hand; // Visa en 'click me' hand när man hovrar över bilden
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Margin = new Thickness(2, 2, 2, 2);
                            //image.Width = 80;
                            //image.Height = 80;
                            image.Stretch = Stretch.Fill;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));

                            MoviesGrid.Children.Add(image);
                            Grid.SetRow(image, y);
                            Grid.SetColumn(image, x);
                            MoviesGrid.Children.Add(title); // säger till att texten ska tillhöra den gridden
                            Grid.SetRow(title, y); // vilken grid i y
                            Grid.SetColumn(title, x); // vilken grid i x

                            /*
                            MoviesGrid.Children.Add(genre);
                            Grid.SetRow(genre, y);
                            Grid.SetColumn(genre, x);
                            */
                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        public void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            var movies = API.GetMovieByName(searchBox.Text);
            if (movies.Count < 1)
            {
                MessageBox.Show("No Movie(s) were found for search term: " + searchBox.Text);
            }
            else
            {
                UpdateMovieGrid(movies);
            }
            //State.Movies.AddRange(API.GetMovieByName(searchBox.Text));
            //State.Movies.AddRange(API.GetMovieByGenre(searchBox.Text));
            //var next_Seachwindow = new SearchWindow();
            //next_Seachwindow.Show();
        }

        private void SearchBoxGotFocus(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
        }
    }
}
