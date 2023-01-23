using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netapi.Models;
using netapi.Reposistories;

namespace netapi.Controllers
{
    [ApiController]
    [Route("/")]
    public class FestivalController : ControllerBase
    {
        private readonly FestivalRepository festivalRepository;

        public FestivalController(FestivalRepository _festivalRepository)
        {
            this.festivalRepository = _festivalRepository;
        }


        [HttpPost]
        [Route("festivals/new")]
        public IActionResult SetNewFestival(Festival DataFestival)
        {
            return Ok(festivalRepository.SetNewFestival(DataFestival));
        }
        [HttpPost]
        [Route("festivals/artist/add")]
        public IActionResult AddArtisToFestival(string id, List<string> ArtistaoGrupo)
        {
            return Ok(festivalRepository.AddArtistToFestival(id, ArtistaoGrupo));
        }

        // GET: Todos los Festivales
        [HttpGet]
        [Route("festivals/")]
        public dynamic GetFestivals()
        {
            return Ok(festivalRepository.GetAll());
        }

        // GET: Todos los Festivales
        [HttpGet]
        [Route("festivals/{id}")]
        public IActionResult GetFestivalById(string id)
        {
            return Ok(festivalRepository.GetById(id));
        }

    }
}
