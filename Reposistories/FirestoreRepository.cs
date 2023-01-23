using Google.Cloud.Firestore;
using netapi.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace netapi.Reposistories
{
    public class FirestoreRepository
    {
        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public FirestoreRepository (string collectionName)
        {
            string SinSeguridadPath = "/Users/emapr/Downloads/pruebaapientrevista-firebase-adminsdk-cwp5a-be16d427a4.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", SinSeguridadPath);
            firestoreDb = FirestoreDb.Create ("pruebaapientrevista");
            this.CollectionName = collectionName;
        }

        public dynamic GetAll()
        {
            var  Festivals  = new List<Dictionary<string, object>>();

            Query allFestivalQuery = firestoreDb.Collection(CollectionName);
            QuerySnapshot allQuerySnapshot =  allFestivalQuery.GetSnapshotAsync().GetAwaiter().GetResult();

            foreach (DocumentSnapshot documentSnapshot in allQuerySnapshot.Documents)
            { 
                var data = documentSnapshot.ToDictionary();
                data.Add("Id", documentSnapshot.Id);
                Festivals.Add(data);
            }
            return Festivals;
        }

        public dynamic GetById (string id)
        {
            id = Regex.Replace(id, @"\s", "");
            DocumentReference docRef = firestoreDb.Collection(CollectionName).Document(id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();
            if (snapshot.Exists)
            {
                 return snapshot.ToDictionary();
            }
            else
            {
                return null;
            }

        }

        public  dynamic AddArtistToFestival (string id,List<string> Artistas )
        {
            id = Regex.Replace(id, @"\s", "");
            DocumentReference docRef = firestoreDb.Collection(CollectionName).Document(id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();
            if (snapshot.Exists)
            {
                docRef.UpdateAsync("ArtistaGrupo",FieldValue.ArrayUnion(Artistas)).Wait();
                return GetById(id);
            }
            else
            {
                return null;
            }


        }
        public async Task<dynamic> SetNewFestival (Festival DataFestival)
        {
            DocumentReference addedDocRef = await firestoreDb.Collection(CollectionName).AddAsync(DataFestival);

           return "Festival Creado correctamente";
        }
    

    }
}
