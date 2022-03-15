using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EjercicioDosPuntoCuatro.Models
{
    public class Videos
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }

        [MaxLength(200)]
        public string Url_video { get; set; }

        [MaxLength(80)]
        public string Descripcion { get; set; }
    }
}
