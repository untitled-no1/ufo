using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Common
{
    public interface IModifyData
    {
        bool ModifyArtists(List<Artist> artist);
        bool ModifyArtist(Artist artist);
        bool DeleteArtist(Artist artist);

        bool ModifyVenue(Venue venue);
        bool DeleteVenue(Venue venue);

        bool ModifyPerformance(Performance performance);
        bool DeletePerformance(Performance performance);
    }
}
