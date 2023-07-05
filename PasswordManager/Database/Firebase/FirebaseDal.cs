using Google.Cloud.Firestore;
using Newtonsoft.Json;
using PasswordManager.Models;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace PasswordManager.Database.Firebase
{
    public class FirebaseDal<T> : IFirebaseDal<T> where T : class, new()
    {
        private FirestoreDb db;
        public FirebaseDal()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(Directory.GetCurrentDirectory(), "passwordgenerator-d7fcf-firebase-adminsdk-rybae-e1076c5b67.json"));
            db = FirestoreDb.Create("passwordgenerator-d7fcf");
        }


        public async Task<Result> Add(T entity)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(T)).DefinedTypes.FirstOrDefault(p => p.Name == typeof(T).Name);
            var props = assembly.GetProperties();
            foreach (var prop in props)
            {
                dictionary.Add(prop.Name, entity.GetType().GetProperty(prop.Name)?.GetValue(entity, null));

            }
            DocumentReference docRef = db.Collection(typeof(T).Name).Document(dictionary["Id"].ToString());
            await docRef.SetAsync(dictionary);
            return new Result(true, "Başarılı");
        }

        public async Task<Result> Update(T entity)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(T)).DefinedTypes.FirstOrDefault(p => p.Name == typeof(T).Name);
            var props = assembly.GetProperties();
            foreach (var prop in props)
            {
                dictionary.Add(prop.Name, entity.GetType().GetProperty(prop.Name)?.GetValue(entity, null));

            }
            DocumentReference docRef = db.Collection(typeof(T).Name).Document(dictionary["Id"].ToString());
            await docRef.SetAsync(dictionary);
            return new Result(true, "Başarılı");
        }

        public async Task<Result> Delete(T entity)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(T)).DefinedTypes.FirstOrDefault(p => p.Name == typeof(T).Name);
            var props = assembly.GetProperties();
            foreach (var prop in props)
            {
                dictionary.Add(prop.Name, entity.GetType().GetProperty(prop.Name)?.GetValue(entity, null));

            }
            DocumentReference docRef = db.Collection(typeof(T).Name).Document(dictionary["Id"].ToString());
            await docRef.DeleteAsync(Precondition.None);
            return new Result(true, "Başarılı");
        }

        public async Task<DataResult<T>> GetById(string id)
        {
            DocumentReference docRef = db.Collection(typeof(T).Name).Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            return new DataResult<T>(JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(snapshot.ToDictionary())), true, "Başarılı");
        }
        public async Task<DataResult<T>> GetByEmail(string email)
        {
            CollectionReference cities_ref = db.Collection(typeof(T).Name);
            Query query_ca = cities_ref.WhereEqualTo("Email", email);
            QuerySnapshot snapshot = await query_ca.GetSnapshotAsync();
            T result = null;
            foreach (DocumentSnapshot documentSnapshot in snapshot)
            {
                result = JsonConvert.DeserializeObject<T>(
                    JsonConvert.SerializeObject(documentSnapshot.ToDictionary()))!;
            }
            return new DataResult<T>(result, true, "Başarılı");
        }
        public async Task<DataResult<List<T>>> GetList()
        {
            List<T> list = new List<T>();
            CollectionReference collRef = db.Collection(typeof(T).Name);
            var listDoc = await collRef.ListDocumentsAsync().ToListAsync();
            foreach (DocumentReference reference in listDoc)
            {
                DocumentSnapshot snapshot = await reference.GetSnapshotAsync();
                list.Add(JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(snapshot.ToDictionary()))!);
            }

            return new DataResult<List<T>>(list, true, "Başarılı");
        }
    }
}
