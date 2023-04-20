using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> getTeams();
        Task<Team> getTeam(int id);
        Task<Team> createTeam(Team team);
        Task<bool> updateTeam(Team team);
        Task<bool> deleteTeam(int id);


    }
}
