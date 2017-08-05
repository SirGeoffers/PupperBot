using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PupperBot.Puppers {
    public class PupperPicker {

        private static HttpClient client = new HttpClient();
        private static string pupperPath = "http://thedogapi.co.uk/api/v1/dog?limit=1";

        public static async Task<string> GetPupper() {
            HttpResponseMessage response = await client.GetAsync(pupperPath);
            if (response.IsSuccessStatusCode) {
                PupperResponse pupperResponse = await response.Content.ReadAsAsync<PupperResponse>();
                if (pupperResponse.count > 0) {
                    string pupperLink = pupperResponse.data[0].url;
                    return pupperLink;
                }
            }
            return null;
        }

    }
    
    public class PupperResponse {
        public PupperData[] data;
        public int count;
        public string api_version;
    }
    
    public class PupperData {
        public string id;
        public string url;
        public string time;
        public string format;
        public int verified;
    }

}