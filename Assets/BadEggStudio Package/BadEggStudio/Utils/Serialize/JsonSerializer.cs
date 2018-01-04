using UnityEngine ;

namespace BadEggStudio.Utils.Serialize
{
    public static class JsonSerializer
    {
        public static string Serialize( object obj )
        {
            return JsonUtility.ToJson( obj ) ;
        }

        public static object Deserialize<T>( string json )
        {
            return JsonUtility.FromJson<T>( json ) ;
        }
    }
}