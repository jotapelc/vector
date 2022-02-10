using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector.Dominio.Entidades
{
    public class AvatarMock
    {
        public AvatarMock()
        {
            SavedIn = DateTime.Now;
        }
     
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string Mail { get; set; }
      
        public string Avatar { get; set; }
       
        public DateTime CreatedAt { get; set; }

        public DateTime SavedIn { get; private set; }
    }
   
}
