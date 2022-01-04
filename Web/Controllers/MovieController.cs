using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        private static HttpClient _httpClient = new HttpClient();
        public IActionResult Index(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewBag.Query = searchTerm;

            string response = await _httpClient.GetStringAsync("https://yts.mx/api/v2/list_movies.json?query_term=" + HttpUtility.UrlEncode(searchTerm));
            var definition = new
            {
                Data = new
                {
                    Movies = new[]
                    {
                        new
                        {
                            Id = 0,
                            Title = string.Empty,
                            TitleLong = string.Empty,
                            SmallCoverImage = string.Empty,
                            MediumCoverImage = string.Empty,
                            Torrents = new[]
                            {
                                new
                                {
                                    Hash = string.Empty,
                                    Quality = string.Empty
                                }
                            }
                        }
                    }
                }
            };

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            var typedResponse = JsonConvert.DeserializeAnonymousType(response, definition, serializerSettings);
            List<MovieSearchViewModel> movies = typedResponse.Data.Movies.Select(movie => new MovieSearchViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                TitleLong = movie.TitleLong,
                ImageMediumUrl = movie.MediumCoverImage,
                ImageSmallUrl = movie.SmallCoverImage,
                Hash = movie.Torrents.First(x => x.Quality == "1080p").Hash
            }).ToList();

            return View(movies);
        }

        public async Task<IActionResult> Download(string hash, string title)
        {
            string tracker = "udp://p4p.arenabg.com:1337";
            string magnet = $"magnet:?xt=urn:btih:{hash}&dn={HttpUtility.UrlEncode(title)}&tr={tracker}";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(magnet)
            {
                UseShellExecute = true
            };
            process.Start();
            return View();
        }
    }
}
