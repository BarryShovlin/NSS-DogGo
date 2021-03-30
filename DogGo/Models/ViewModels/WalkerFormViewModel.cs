using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DogGo.Models.ViewModels
{
    public class WalkerFormViewModel
    {
        public Walker walker { get; set; }
        public List<Neighborhood> Neighborhoods { get; set; }

        [Display(Name = "Clients")]
        public List<Owner> Owners { get; set; }
        
        public List<Walk> Walks { get; set; } 
    }
}