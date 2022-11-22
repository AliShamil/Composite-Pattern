using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern.Models.Abstracts
{
    public interface ISystemItem
    {
        string? Name { get; set; }
        string? Location { get; set; }
        double Size { get; }
    }
}
