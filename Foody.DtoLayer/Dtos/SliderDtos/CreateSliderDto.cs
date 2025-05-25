using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DtoLayer.Dtos.SliderDtos
{
    internal class CreateSliderDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
