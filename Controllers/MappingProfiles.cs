using AutoMapper;
using SuperBowlWeb.Data;
using SuperBowlWeb.Migrations;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<Jeu, Jeu>();
            CreateMap<Equipe, EquipeDTO>()
                .ForMember(x => x.Iso, s => s.MapFrom(o => o.Pays.Iso))
                .ForMember(x=>x.Pays,s=>s.MapFrom(o=>o.Pays.Name));
            CreateMap<Joueur, JoueurDTO>();

        }
    }
}
