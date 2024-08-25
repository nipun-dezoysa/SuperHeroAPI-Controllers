using SuperHeroAPI_Controllers.Dtos;
using SuperHeroAPI_Controllers.Entities;

namespace SuperHeroAPI_Controllers.Mapping
{
    public static class SuperHeroMap
    {
        public static SuperHero ToEntity(this AddDto dto)
        {
            return new SuperHero
            {
                Name = dto.Name,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Place = dto.Place
            };
        }
    }
}
