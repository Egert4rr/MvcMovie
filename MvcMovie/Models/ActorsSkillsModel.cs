using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class ActorsSkillsModel
    {
        public List<Actors> Actors { get; set; }
        public SelectList Skills { get; set; }
        public string Skill { get; set; }
        public string SearchString { get; set; }
    }
}