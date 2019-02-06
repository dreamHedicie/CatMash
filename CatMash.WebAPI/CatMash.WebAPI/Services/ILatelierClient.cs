using CatMash.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatMash.WebAPI.Services
{
    public interface ILatelierClient
    {
        Task<IEnumerable<Image>> GetImages();
    }
}
