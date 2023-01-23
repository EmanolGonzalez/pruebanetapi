using Google.Cloud.Firestore;

namespace netapi.Models
{
    [FirestoreData]
    public class ArtitasGrupos 
    {
        [FirestoreProperty]
        public string? Nombre { get; set; }
        [FirestoreProperty]
        public string? Genero { get; set; }
        [FirestoreProperty]
        public int? Integrantes { get; set; }

    }
}
