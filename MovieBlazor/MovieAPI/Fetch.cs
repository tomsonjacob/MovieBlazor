using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MovieBlazor.Models;

namespace MovieBlazor.MovieAPI
{
    public class Fetch {
        public HttpClient client = new HttpClient();
        public string Data { get; set; }
        public string PopularData { get; set; }
        public string Search { get; set; }
        public string NowPlay { get; set; }
        public string UpcomingMovie { get; set; }
        public string NearMeData { get; set; }        
        public string SocialIconSet { get; set; }
        public string GenresInfo { get; set; }



        public async Task GrabPosterAsync(string search)
        {
            clearYourHead(); // 
            // grab 20 vids - default result number
            HttpResponseMessage posterData =
                await client.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=d194eb72915bc79fac2eb1a70a71ddd3&query=" + search);
            if (posterData.IsSuccessStatusCode) {
                Data = await posterData.Content.ReadAsStringAsync();
                Program.posterSet = JsonConvert.DeserializeObject<PosterSet>(Data);
            }
            else {
                Data = null;
            }
        } // GrabPosterAsync()

        public async Task GrabActorDetailsAsync(int actorID)
        {
            clearYourHead(); // 

            // grabs the cast info
            HttpResponseMessage actorInfo =
                await client.GetAsync("https://api.themoviedb.org/3/person/" +
                    actorID + "?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US");

            // grab cast images details
            HttpResponseMessage actorImgs = await client.GetAsync(
                "https://api.themoviedb.org/3/person/" + actorID +
                    "/images?api_key=d194eb72915bc79fac2eb1a70a71ddd3");

            // grab cast movie credit details
            HttpResponseMessage actorCredits = await client.GetAsync(
                "https://api.themoviedb.org/3/person/" + actorID +
                    "/movie_credits?api_key=d194eb72915bc79fac2eb1a70a71ddd3");
            // null checks
            if (actorInfo.IsSuccessStatusCode)
            {
                string Details = await actorInfo.Content.ReadAsStringAsync();
                Program.actor = JsonConvert.DeserializeObject<Actor>(Details);
            }
            if (actorImgs.IsSuccessStatusCode)
            {
                string Images = await actorImgs.Content.ReadAsStringAsync();
                Program.actorImgSet = JsonConvert.DeserializeObject<ActorImgSet>(Images);
            }
            if (actorCredits.IsSuccessStatusCode)
            {
                string MovieCredits = await actorCredits.Content.ReadAsStringAsync();
                Program.actorCreditSet = JsonConvert.DeserializeObject<ActorCreditSet>(MovieCredits);
            }

        } // GrabActorDetailsAsync()


        public async Task GrabMovieAsync(int movieID)
        {
            clearYourHead(); // 

            // grabs the movie info
            HttpResponseMessage movieInfo = 
                await client.GetAsync("https://api.themoviedb.org/3/movie/" + 
                    movieID + "?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US");
            // grabs the movie credits - includes cast
            HttpResponseMessage castInfo = 
                await client.GetAsync("https://api.themoviedb.org/3/movie/" +
                movieID + "/credits?api_key=d194eb72915bc79fac2eb1a70a71ddd3");
            // grab vids
            HttpResponseMessage videoInfo = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID +
                    "/videos?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US");
            // null checks
            if (movieInfo.IsSuccessStatusCode) {
                string Details = await movieInfo.Content.ReadAsStringAsync();
                Program.movie = JsonConvert.DeserializeObject<Movie>(Details);
            }
            if (castInfo.IsSuccessStatusCode) {
                string Credits = await castInfo.Content.ReadAsStringAsync();
                Program.credits = JsonConvert.DeserializeObject<Credits>(Credits);
            }
            if (castInfo.IsSuccessStatusCode)
            {
                string Videos = await videoInfo.Content.ReadAsStringAsync();
                Program.videoSet = JsonConvert.DeserializeObject<VideoSet>(Videos);
            }
        } // GrabMovieAsync()
        public async Task GrabLatestMovieDetails()
        {
            clearYourHead(); // 

            // grab latest movie details
            HttpResponseMessage nowPlay = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/now_playing?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US&page=1");
            if (nowPlay.IsSuccessStatusCode)
            {
                NowPlay = await nowPlay.Content.ReadAsStringAsync();
                Program.latestMovieSet = JsonConvert.DeserializeObject<LatestMovieSet>(NowPlay);
            }
            else
            {
                NowPlay = null;
            }
        }//grab cast d
        public async Task UpcomingMovieDetails()
        {
            clearYourHead(); // 
            // grab upcoming movie details
            HttpResponseMessage upcomingMovie = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/upcoming?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US&page=1");
            if (upcomingMovie.IsSuccessStatusCode)
            {
                UpcomingMovie = await upcomingMovie.Content.ReadAsStringAsync();
                Program.upcomingMovieSet = JsonConvert.DeserializeObject<UpcomingMovieSet>(UpcomingMovie);
            }
            else
            {
                UpcomingMovie = null;
            }
        }//grab 

        public async Task GrabPopularActorDetails()
        {
            clearYourHead(); // 
            // grab 20 vids - default result number
            HttpResponseMessage popularData =
                await client.GetAsync("https://api.themoviedb.org/3/person/popular?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US&page=1");
            if (popularData.IsSuccessStatusCode)
            {
                PopularData = await popularData.Content.ReadAsStringAsync();
                Program.popularActorSet = JsonConvert.DeserializeObject<PopularActorSet>(PopularData);
            }
            else
            {
                PopularData = null;
            }
        } // GrabPopularActorDetails()

        public async Task GrabGenresDetails(string genID)
        {
            clearYourHead(); // 

            // grab cast details

            HttpResponseMessage genresInfo =
               await client.GetAsync("https://api.themoviedb.org/3/discover/movie?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_genres=" + genID);

            if (genresInfo.IsSuccessStatusCode)
            {
                GenresInfo = await genresInfo.Content.ReadAsStringAsync();
                Program.genresSet = JsonConvert.DeserializeObject<GenresSet>(GenresInfo);
            }
            else
            {
                GenresInfo = null;
            }
        }//grab social details
        public async Task GrabSearchActorAsync(string search)
        {
            clearYourHead(); // 
            // grab 20 vids - default result number
            HttpResponseMessage searchActorData =
                await client.GetAsync("https://api.themoviedb.org/3/search/person?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US&query=" + search);
            if (searchActorData.IsSuccessStatusCode)
            {
                Data = await searchActorData.Content.ReadAsStringAsync();
                Program.popularActorPosterSet = JsonConvert.DeserializeObject<PopularActorPosterSet>(Data);
            }
            else
            {
                Data = null;
            }
        } // GrabPosterAsync()

        public async Task GrabSocialDetails(int castID)
        {
            clearYourHead(); // 

            // grab cast details
           
            HttpResponseMessage socialInfo =
               await client.GetAsync("https://api.themoviedb.org/3/person/" + castID + "/external_ids?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US");

            if (socialInfo.IsSuccessStatusCode)
            {
                SocialIconSet = await socialInfo.Content.ReadAsStringAsync();
                Program.socialIcon = JsonConvert.DeserializeObject<SocialIcon>(SocialIconSet);
            }
            else
            {
                SocialIconSet = null;
            }
        }//grab social details
        public async Task GrabNearMeTheatreDetails()
        {
            clearYourHead(); // 
           
            // grab 20 vids - default result number
            HttpResponseMessage nearData =
                await client.GetAsync("http://data.tmsapi.com/v1.1/movies/showings?startDate=" + @DateTime.Now.ToString("yyyy-MM-dd") + "&numDays=1&zip=N6G0G3&radius=10&units=km&imageSize=Md&api_key=gdxfr8measc7z7hyhkt2dn8p");
            if (nearData.IsSuccessStatusCode)
            {
                NearMeData = await nearData.Content.ReadAsStringAsync();
                Program.all_movies = JsonConvert.DeserializeObject<List<Object>>(NearMeData);

                // loop through all teams then deserialize each 
                // adding that teams to the collection of movies
                foreach (Object t in Program.all_movies)
                {
                    Program.nearMeTheatreSet.Add(JsonConvert.DeserializeObject<NearMeTheatreSet>(t.ToString()));
                }
            }
            else
            {
                NearMeData = null;
            }
        } // GrabPopularActorDetails()

        public void clearYourHead() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));
        }
    } // Fetch

} // namespace