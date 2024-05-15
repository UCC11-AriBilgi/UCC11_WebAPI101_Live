using System.Text.Json;

namespace EmployeeWeb.Helper
{
    public static class HttpClientExtensions
    {
        // HttpClient işlemleri sonucu diğer taraftan gelecek olan veriyi çözümleyecek olan bölüm. Çünkü geri planda JSON formatında veriler gidip/geleceği için

        // Aşağıda yazılacak olan metot benim arada gidip/gelen mesajlaşmamı çözümleyecek

        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            // Bana API tarafından gönderilen cevap(response) uygun durumda mı diye bir kontrol işlemi olacak

            if (response.IsSuccessStatusCode == false)
            {
                throw new ApplicationException($"API çağırılırken bir problem oluştu : {response.ReasonPhrase}");
            }

            // Eğer herşey normalse durum uygunsa API tarafından buraya gönderilen bilgi okunacak

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Şu an gelen bilgi standardt bildiğimiz text formatında. Bunu JSON formatına dönüştürmemiz gerekiyor.
            
            // JSON formatına dönüştürme işi
            var result = JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
}
