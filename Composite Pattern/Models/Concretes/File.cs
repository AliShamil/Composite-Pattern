using Composite_Pattern.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern.Models.Concretes;

public class File : ISystemItem
{
    public string? Name { get ; set; }
    public string? Location { get ; set; }
    public double Size { get; }



    public File(string? name, double size, string? location = "")
    {
        Name = name;
        Location = location;
        Size = size;
    }
}
