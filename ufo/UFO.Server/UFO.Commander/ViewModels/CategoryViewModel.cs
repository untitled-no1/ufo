using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class CategoryViewModel
    {
        private Category category;

        public string Id => category?.CategoryId;

        public string Name => category?.Name;

        public CategoryViewModel(Category c)
        {
            category = c;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
