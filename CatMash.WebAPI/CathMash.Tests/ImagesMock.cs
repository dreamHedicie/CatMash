using CatMash.WebAPI.Models;

namespace CathMash.Tests
{
    public class ImagesMock
    {
        public static Image[] Images => new[]
            {
                new Image
                {
                    Id = "MTgwODA3MA",
                    Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg"
                },
                new Image
                {
                    Id = "tt",
                    Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg"
                }
            };
    }
}
