using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSSQL_Core_App.DTOs;

namespace MSSQL_Core_App.Queries
{
    public static class MapToDTO
    {
        public static IQueryable<DeerWithClubsDTO> MapDeerToDTO(this IQueryable<Deer> deers)
        {
            return deers.Select( deer => new DeerWithClubsDTO
            {
                Id = deer.Id,
                Name = deer.Name,
                ElvesOrdered = string.Join(",",
                    deer.Elves.OrderBy(elf => elf.Id).Select(elf => elf.Name)),
                ClubsCount = deer.Clubs.Count()
            });
        }
    }

    public class UseMapToDTO
    {
        public void UseMapToDTO1() 
        {
            using var context = new AnimalContext();
            var deerWithClubsDTOs = MapToDTO.MapDeerToDTO(context.Deers);

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var deerDTO in deerWithClubsDTOs)
            {
                Console.WriteLine(deerDTO);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
