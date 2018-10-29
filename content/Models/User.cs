using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vue2Spa.Models
{
  public partial class User
  {
      [Key]
      public int ID {get; set;}
      public string Name { get; set; }
      public int Age { get; set; }
      public string Address { get; set; }
  }
}
