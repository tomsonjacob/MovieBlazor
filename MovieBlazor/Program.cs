
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieBlazor.MovieAPI;
using MovieBlazor.Models;

namespace MovieBlazor
{
    public class Program
    {
        public static Fetch fetch = new Fetch();
        public static LatestMovieSet latestMovieSet;
        public static UpcomingMovieSet upcomingMovieSet;
        public static PosterSet posterSet;
        public static Movie movie;
        public static Credits credits;
        public static Actor actor;
        public static ActorImgSet actorImgSet;
        public static VideoSet videoSet;
        public static PopularActorSet popularActorSet;
        public static PopularActorPosterSet popularActorPosterSet;
        public static ActorCreditSet actorCreditSet;
        public static SocialIcon socialIcon;
        public static GenresSet genresSet;
        public static List<Object> all_movies = new List<Object>();
        public static List<NearMeTheatreSet> nearMeTheatreSet = new List<NearMeTheatreSet>();
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
