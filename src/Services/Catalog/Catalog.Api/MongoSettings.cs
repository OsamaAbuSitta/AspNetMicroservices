namespace Catalog.Api
{
    public class MongoDatabaseSettings 
    {
       public string ConnectionString {get;set;}
       public string DatabaseName {get;set;}
       public string CollectionName { get; set; }
       public bool EnableSeed { get;  set; }
    }
}
