using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    // the Controller id substituted with the name of the controller
    // in this case we are talking about User.
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        // first we add a constructor from the class with DatingRepository
        // as a parameter and initialize the parameter from repo. This is the basic 
        // Initialisation.
        private readonly IMapper _mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            // we use autoMapper to map the user class for a specific return result
            // We dont need all the info of the user like the password Hash and the password salt.
            // for the automaper we add the nuget extention in the project, then we pressed
            // control  + shift + P to open then we install the autoMapper.extention.
            // then we add the automapper service inside the statup.cs class for the service.
            // and we create a instance of the interface in the controller of this class and initialise field
            // from parameters to use it in the whole class.
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
    }
}