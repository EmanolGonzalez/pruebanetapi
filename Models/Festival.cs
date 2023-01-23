using Google.Cloud.Firestore;

namespace netapi.Models
{
    [FirestoreData]
    public class Festival 
    {
        [FirestoreProperty]
        public string? Titulo { get; set; }
        [FirestoreProperty]
        public string? Ubicacion { get; set; }
        [FirestoreProperty]
        public DateTime FechaFestival { get; set; }
        [FirestoreProperty]
        public int? Precio { get; set; }
        [FirestoreProperty]
        public List<string>? ArtistaoGrupoReferencia { get; set; }
        [FirestoreProperty]
        public string? FotoCartel { get; set; }

    }
}
