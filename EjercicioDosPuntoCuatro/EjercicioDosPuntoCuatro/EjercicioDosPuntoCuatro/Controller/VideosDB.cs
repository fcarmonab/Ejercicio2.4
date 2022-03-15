using System;
using System.Collections.Generic;
using System.Text;
using EjercicioDosPuntoCuatro.Models;
using System.Threading.Tasks;
using SQLite;

namespace EjercicioDosPuntoCuatro.Controller
{
    public class VideosDB
    {
        readonly SQLiteAsyncConnection db;

        public VideosDB(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Videos>().Wait();
        }

        public Task<List<Videos>> ObtenerListaVideos()
        {
            return db.Table<Videos>().ToListAsync();
        }

        public Task<Videos> ObtenerVideos(int pcodigo)
        {
            return db.Table<Videos>()
                .Where(i => i.Codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GrabarVideos(Videos videos)
        {
            if (videos.Codigo != 0)
            {
                return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
        }

        public Task<int> EliminarLocalizacion(Videos videos)
        {
            return db.DeleteAsync(videos);
        }
    }
}
