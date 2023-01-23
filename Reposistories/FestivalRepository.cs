using netapi.Models;

namespace netapi.Reposistories
{
    public class FestivalRepository 
    {
        private readonly string CollectionName = "Festival";
        private readonly FirestoreRepository firestoreRepository;

        public FestivalRepository()
        {
            firestoreRepository = new FirestoreRepository(this.CollectionName);
        }

        public dynamic GetAll()
        {
            return firestoreRepository.GetAll();
        }

        public dynamic GetById(string id)
        {
            return firestoreRepository.GetById(id); 
        }

        public dynamic AddArtistToFestival(string id,List<string> ArtistaoGrupo) {
            return firestoreRepository.AddArtistToFestival(id,ArtistaoGrupo);
        }
        public dynamic SetNewFestival(Festival DataFestival) {
            return firestoreRepository.SetNewFestival(DataFestival);
        }
    }
}
