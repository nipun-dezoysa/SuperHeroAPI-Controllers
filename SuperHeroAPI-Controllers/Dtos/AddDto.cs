using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI_Controllers.Dtos
{
    public record class AddDto(
        [Required] string Name,
        string FirstName,
        string LastName,
        string Place
    );
   
}
