using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DNP_Assignment3_API.Models.List;

namespace DNP_Assignment3_API.Models.Unit 
{
    public class OldFamily
    {
        //public int Id { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public int HouseNumber{ get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children{ get; set; }
        public List<Pet> Pets{ get; set; }

        public OldFamily() {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }

        public Family ConvertToFamily()
        {
            AdultList adultList = new AdultList();
            ChildList childList = new ChildList();
            foreach (var adult in Adults)
            {
                adultList.AddAdult(adult);
            }
            foreach (var child in Children)
            {
                childList.AddChild(child);
            }
            return new Family
            {
                StreetName = StreetName,
                HouseNumber = HouseNumber,
                Adults = adultList,
                Children = childList,
                Pets = new List<Pet>(Pets)
            };
        }
    }
}