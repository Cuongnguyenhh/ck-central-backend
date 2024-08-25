using CK.Central.Core.Abstract.Services;
using CK.Central.Core.DataObjects.Entity;
using CK.Central.Core.DataObjects.Mapping;
using Microsoft.Extensions.Configuration;
using Nest;

namespace CK.Central.Core.Services
{
    public abstract class ElasticsearchBaseService : IElasticsearchBaseService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _client;
        public ElasticsearchBaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = CreateInstance();
        }
        private ElasticClient CreateInstance()
        {
            string? host = _configuration.GetSection("ElasticsearchServer:Host").Value;
            string? port = _configuration.GetSection("ElasticsearchServer:Port").Value;
            string? username = _configuration.GetSection("ElasticsearchServer:User").Value;
            string? password = _configuration.GetSection("ElasticsearchServer:Pass").Value;
            var settings = new ConnectionSettings(new Uri("http://" + host + ":" + port));
            //if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            settings.BasicAuthentication(username, password);

            return new ElasticClient(settings);
        }
        public async Task ChekIndex(string indexName)
        {
            var anyy = await _client.Indices.ExistsAsync(indexName);
            if (anyy.Exists)
                return;

            var response = await _client.Indices.CreateAsync(indexName,
                ci => ci
                    .Index(indexName)
                    .BaseEntityMapping()
                    .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1))
                    );

            return;
        }
        public async Task DeleteIndex(string indexName)
        {
            await _client.Indices.DeleteAsync(indexName);
        }
        public async Task<BaseEntity> GetDocument(string indexName, string id)
        {
            var response = await _client.GetAsync<BaseEntity>(id, q => q.Index(indexName));
            return response.Source;
        }
        public async Task<List<BaseEntity>> GetDocuments(string indexName)
        {
            #region Wildcard aradaki harfi kendi tamamlıyor            
            //var response = await _client.SearchAsync<Cities>(s => s
            //        .From(0)
            //        .Take(10)
            //        .Index(indexName)
            //        .Query(q => q
            //        .Bool(b => b
            //        .Should(m => m
            //        .Wildcard(w => w
            //        .Field("city")
            //        .Value("r*ze"))))));
            #endregion

            #region Fuzzy kelime kendi tamamlar parametrikde olabilir
            //var response = await _client.SearchAsync<Cities>(s => s
            //                  .Index(indexName)
            //                  .Query(q => q
            //        .Fuzzy(fz => fz.Field("city")
            //            .Value("anka").Fuzziness(Fuzziness.EditDistance(4))
            //        )
            //    ));
            //harflerin yer değiştirmesi
            //var response = await _client.SearchAsync<Cities>(s => s
            //                  .Index(indexName)
            //                  .Query(q => q
            //        .Fuzzy(fz => fz.Field("city")
            //            .Value("rie").Transpositions(true))
            //        ));
            #endregion

            #region MatchPhrasePrefix  aradaki harfi kendi tamamlıyor Wildcard göre performans olarak daha yüksek
            //var response = await _client.SearchAsync<Cities>(s => s
            //                    .Index(indexName)
            //                    .Query(q => q.MatchPhrasePrefix(m => m.Field(f => f.City).Query("iz").MaxExpansions(10)))
            //                   );
            #endregion

            #region MultiMatch çoklu  büyük küçük duyarlığı olmaz
            // MultiMatch
            //    var response = await _client.SearchAsync<Cities>(s => s
            //                   .Index(indexName)
            //                   .Query(q => q
            //.MultiMatch(mm => mm
            //    .Fields(f => f
            //        .Field(ff => ff.City)
            //        .Field(ff => ff.Region)
            //    )
            //    .Type(TextQueryType.PhrasePrefix)
            //    .Query("iz")
            //    .MaxExpansions(10)
            //)));
            #endregion

            #region Term burada tamamı küçük harf olmalı
            //var response = await _client.SearchAsync<Cities>(s => s
            //                    .Index(indexName)
            //                  .Size(10000)
            //                   .Query(query => query.Term(f => f.City, "rize"))
            //                   );
            #endregion

            #region Match büyük küçük duyarlığı olmaz
            //var response = await _client.SearchAsync<Cities>(s => s
            //                      .Index(indexName)
            //                    .Size(10000)
            //                    .Query(q => q
            //                    .Match(m => m.Field("city").Query("ankara")
            //                     )));
            #endregion

            #region AnalyzeWildcard like sorgusu mantıgında çalışmakta
            var response = await _client.SearchAsync<BaseEntity>(s => s
                                  .Index(indexName)
                                        .Query(q => q
                                .QueryString(qs => qs
                                .AnalyzeWildcard()
                                   .Query("*" + "iz" + "*")
                                   .Fields(fs => fs.Fields(f1 => f1.PK_UUID)

                                ))));
            #endregion         

            return response.Documents.ToList();
        }
        public async Task InsertDocument(string indexName, BaseEntity entity)
        {
            var response = await _client.CreateAsync(entity, q => q.Index(indexName));
            if (response.ApiCall?.HttpStatusCode == 409)
            {
                await _client.UpdateAsync<object>(entity.PK_UUID, a => a.Index(indexName).Doc(entity));
            }
        }
        public async Task InsertBulkDocuments(string indexName, List<BaseEntity> entities)
        {
            await _client.IndexManyAsync(entities, index: indexName);
        }
        public async Task DeleteByIdDocument(string indexName, BaseEntity entity)
        {
            var response = await _client.CreateAsync(entity, q => q.Index(indexName));
            if (response.ApiCall?.HttpStatusCode == 409)
            {
                await _client.DeleteAsync(DocumentPath<BaseEntity>.Id(entity.PK_UUID).Index(indexName));
            }
        }
    }
}
