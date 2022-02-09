using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector.Dominio.Entidades
{
    public class AvatarMock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime RequestIn { get; set; }
    }
}
