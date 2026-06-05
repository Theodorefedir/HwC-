using System.Collections;

namespace MovieHW
{
    internal class Program
    {
        enum Genre { 
            Comedy = 0,
            Horror = 1,
            Adventure = 2,
            Drama = 3
        }
        class Director : ICloneable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Director(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public Director() {
                FirstName = "unknown";
                LastName = "unknown";
            }
            public override string ToString()
            {
                return $"Director: {FirstName} {LastName}";
            }

            public object Clone()
            {
                Director copy = (Director) this.MemberwiseClone();
                return copy;
            }
        }
        class Movie : IComparable<Movie>, ICloneable
        {
            public string Title { get; set; }
            public Director MovieDirector { get; set; }
            public string Country { get; set; }
            public Genre MovieGenre { get; set; }
            public int Year { get; set; }
            public short Rating { get; set; }

            public Movie() { 
                Title = "unknown";
                Year = 0;
                Rating = 0;
                Country = "unknown";
                MovieGenre = Genre.Adventure;
                MovieDirector = new Director();
            }
            public Movie(string title, Director director, string country, Genre genre, int year, short rating) { 
                Title = title;
                Year = year;
                Rating = rating;
                Country = country;
                MovieDirector = director;
                MovieGenre = genre;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Director {MovieDirector}, country: {Country}, Genre {MovieGenre}, Year: {Year}, Rating: {Rating}";
            }

            public int CompareTo(Movie? other)
            {
                return this.Year.CompareTo(other.Year);
            }

            public object Clone()
            {
                Movie copy = (Movie)this.MemberwiseClone();
                copy.MovieDirector = new Director() { FirstName = this.MovieDirector.FirstName, LastName = this.MovieDirector.LastName};
                copy.MovieGenre = MovieGenre;
                return copy;
            }
        }
        class CompareByRating : IComparer<Movie>
        {
            public int Compare(Movie? x, Movie? y)
            {
                return x.Rating.CompareTo(y.Rating);
            }
        }
        class CompareByYear : IComparer<Movie>
        {
            public int Compare(Movie? x, Movie? y)
            {
                return x.Year.CompareTo(y.Year);
            }
        }
        class Cinema :IEnumerable{
            private Movie[] movies;
            public string Address { get; set; }
            public Cinema()
            {
                Address = "unknown";
                movies = new Movie[0];
            }
            public Cinema(string address, Movie[] movies)
            {
                Address = address;
                this.movies = movies;
            }

            public override string ToString() {
                return $"Adress: {Address}, you can watch {movies.Length} here";
            }
            public void ShowMovies() {
                if (movies != null)
                {
                    foreach (var movie in movies)
                    {
                        Console.WriteLine(movie);
                    }
                }
                else {
                    Console.WriteLine("Empty");
                }
            }

            public IEnumerator GetEnumerator()
            {
                return movies.GetEnumerator();
            }

            public void Sort(IComparer<Movie> comparer) { 
                Array.Sort(movies, comparer);
            }
        }
        static void Main(string[] args)
        {
            Director d = new Director("Bububu", "Lelele");
            Movie[] movies = new Movie[]
            {
                new Movie("Film A", d, "USA", Genre.Horror, 2010, 5),
                new Movie("Film B", d, "UK", Genre.Drama, 2015, 9),
                new Movie("Film C", d, "AUS", Genre.Comedy, 2000, 7)
            };
            Cinema cinema = new Cinema("Main Street", movies);
            cinema.Sort(new CompareByRating());
            cinema.ShowMovies();

        }
    }
}
