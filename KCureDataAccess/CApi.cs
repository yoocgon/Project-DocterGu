using DoctorGu;
using KCureVDIDataBox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace KCureVDIDataBox
{
    /// <summary>
    /// HTTP 요청을 통해 원격 서버와 상호 작용하는 API 함수
    /// 로그인, 파일 반출 용 API에서 공통으로 사용하는 부분을 따로 떼어냄
    /// </summary>
    public class CApi
    {
        private string ApiKey;
        private string ApiValue;

        /// <summary>
        /// API Key, Value를 App.config에서 읽어와 설정
        /// </summary>
        public CApi()
        {
            this.ApiKey = CCommon.GetAppSetting<string>(ConfigAppKeys.ApiKey, "");
            this.ApiValue = CCommon.GetAppSetting<string>(ConfigAppKeys.ApiValue, "");
        }

        /// <summary>
        /// API 호출에 공통으로 사용되는 함수
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        internal async Task<(bool, string, T)> Send<T>(string url, string jsonContent) where T : new()
        {
            try
            {
                string ApiDomain = CCommon.GetAppSetting<string>(ConfigAppKeys.ApiDomain, "");
                if (CCommon.useLocalhost)
                {
                    ApiDomain = "http://localhost:8080";
                }
                string requestUrl = $"{ApiDomain}{url}";
                Log("requestUrl", requestUrl);

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                request.Headers.Add(ApiKey, ApiValue);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // gony, QA
                string jsonResponseTemp = @"{
                  ""httpStatus"": 200,
                  ""successYn"": ""Y"",
                  ""errorMsg"": """",
                  ""result"": {
                    ""isLogin"": ""true"",
                    ""loginFailMsg"": null,
                    ""nasUrl"": ""198.18.229.52"",
                    ""nasId"": ""centos"",
                    ""nasPw"": """",
                    ""nasPort"": ""22"",
                    ""nasBaseFolder"": ""/nasdata/svcAplc/"",
                    ""nasEncoding"": ""euc-kr"",
                    ""today"": ""20230710"",
                    ""applyResult"": {
                      ""authCode"": [
                        {
                          ""AU006"": [
                            {
                              ""dataAplcNo"": ""KC202305001"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305002"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20240425"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": ""/K-CURE/brn/KC202305002""
                            },
                            {
                              ""dataAplcNo"": ""KC202305044"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20240619"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305045"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20240522"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305049"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20240822"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305051"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20240425"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305052"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305059"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305064"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305065"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305067"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305068"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305069"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305070"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20240725"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305074"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305075"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20240801"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305076"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305077"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20240515"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305078"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305080"",
                              ""dtuSdt"": ""20230514"",
                              ""dtuEdt"": ""20231228"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305081"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20240531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305082"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305083"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305084"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20240829"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305085"",
                              ""dtuSdt"": ""20230501"",
                              ""dtuEdt"": ""20251021"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305086"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305087"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20240628"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305088"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20261013"",
                              ""cryOutApply"": ""Y"",
                              ""prtiFile"": null,
                              ""carryFile"": ""/K-CURE/brn/KC202305088""
                            },
                            {
                              ""dataAplcNo"": ""KC202305089"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20240823"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305090"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20240620"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305091"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305092"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305093"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305094"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305095"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305096"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20231114"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305097"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305098"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305099"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20231018"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305103"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305107"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305108"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20240131"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305109"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20240726"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305111"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305112"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305116"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305117"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305118"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305119"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20240322"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305121"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305122"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305123"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305124"",
                              ""dtuSdt"": ""20230523"",
                              ""dtuEdt"": ""20240223"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305125"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305126"",
                              ""dtuSdt"": ""20230507"",
                              ""dtuEdt"": ""20241231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305127"",
                              ""dtuSdt"": ""20230501"",
                              ""dtuEdt"": ""20240201"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305128"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305129"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305130"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305131"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230515"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305132"",
                              ""dtuSdt"": ""20230531"",
                              ""dtuEdt"": ""20240629"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305133"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305134"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305135"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305136"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305137"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305143"",
                              ""dtuSdt"": ""20230524"",
                              ""dtuEdt"": ""20230909"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305144"",
                              ""dtuSdt"": ""20230501"",
                              ""dtuEdt"": ""20240430"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305146"",
                              ""dtuSdt"": ""20230525"",
                              ""dtuEdt"": ""20231007"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305147"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305148"",
                              ""dtuSdt"": ""20230525"",
                              ""dtuEdt"": ""20240202"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305149"",
                              ""dtuSdt"": ""20230526"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305151"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305152"",
                              ""dtuSdt"": ""20230530"",
                              ""dtuEdt"": ""20240927"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305153"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305154"",
                              ""dtuSdt"": ""20230526"",
                              ""dtuEdt"": ""20241015"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": ""/K-CURE/brn/KC202305154""
                            },
                            {
                              ""dataAplcNo"": ""KC202305155"",
                              ""dtuSdt"": ""20230530"",
                              ""dtuEdt"": ""20240621"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305156"",
                              ""dtuSdt"": ""20230527"",
                              ""dtuEdt"": ""20240502"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305157"",
                              ""dtuSdt"": ""20230201"",
                              ""dtuEdt"": ""20230527"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305158"",
                              ""dtuSdt"": ""20230528"",
                              ""dtuEdt"": ""20240620"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305159"",
                              ""dtuSdt"": ""20230529"",
                              ""dtuEdt"": ""20241023"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305161"",
                              ""dtuSdt"": ""20230530"",
                              ""dtuEdt"": ""20240620"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305162"",
                              ""dtuSdt"": ""20230530"",
                              ""dtuEdt"": ""20240430"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305163"",
                              ""dtuSdt"": ""20230531"",
                              ""dtuEdt"": ""20240529"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202305164"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306001"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20230930"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306002"",
                              ""dtuSdt"": ""20230602"",
                              ""dtuEdt"": ""20231214"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306003"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306004"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306005"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306006"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306007"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20240531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306008"",
                              ""dtuSdt"": ""20230605"",
                              ""dtuEdt"": ""20231109"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306009"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20240531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306012"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306013"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306015"",
                              ""dtuSdt"": ""20230605"",
                              ""dtuEdt"": ""20231026"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306016"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306017"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306018"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306019"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231030"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306020"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231031"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306021"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306022"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230927"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306023"",
                              ""dtuSdt"": ""20230610"",
                              ""dtuEdt"": ""20230921"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306024"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306025"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231202"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306026"",
                              ""dtuSdt"": ""20230610"",
                              ""dtuEdt"": ""20240210"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306027"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20231208"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306028"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20240203"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306029"",
                              ""dtuSdt"": ""20230611"",
                              ""dtuEdt"": ""20240203"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306030"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306031"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231111"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306032"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231230"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306033"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231202"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306034"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20240309"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306035"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20240309"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306036"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20240210"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306037"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20240531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306038"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20241231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": ""/K-CURE/brn/KC202306038""
                            },
                            {
                              ""dataAplcNo"": ""KC202306039"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230630"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306040"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306041"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230630"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306042"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230630"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306043"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20250610"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306044"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306045"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20240531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306046"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20231122"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306047"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20231007"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306048"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306049"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306050"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20231209"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306051"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240210"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306052"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306053"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306054"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306055"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306056"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20240106"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306057"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20231209"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306058"",
                              ""dtuSdt"": ""20230223"",
                              ""dtuEdt"": ""20250108"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306059"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20250208"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306060"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20260101"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306061"",
                              ""dtuSdt"": ""20230301"",
                              ""dtuEdt"": ""20241022"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306063"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20231103"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306064"",
                              ""dtuSdt"": ""20230602"",
                              ""dtuEdt"": ""20250611"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306065"",
                              ""dtuSdt"": ""20230302"",
                              ""dtuEdt"": ""20250608"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306066"",
                              ""dtuSdt"": ""20230108"",
                              ""dtuEdt"": ""20231012"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306067"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20231215"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306068"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306069"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20231228"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306070"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306071"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306072"",
                              ""dtuSdt"": ""20230103"",
                              ""dtuEdt"": ""20240328"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306073"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20231207"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306074"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20231213"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306075"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306076"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20231130"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306077"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230630"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306078"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20241016"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306079"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230831"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306080"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306081"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20240628"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306082"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20231031"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC202306083"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20231031"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612001"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20240928"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612002"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20240621"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612003"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20230930"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612004"",
                              ""dtuSdt"": """",
                              ""dtuEdt"": """",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612005"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20230531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612006"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612007"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612008"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612009"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612010"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230612011"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613001"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613002"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613003"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613004"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613005"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20240426"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613006"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20240427"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613007"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613008"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613009"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613010"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613011"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613012"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613013"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613014"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613015"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20240911"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613016"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20240101"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613017"",
                              ""dtuSdt"": ""20230614"",
                              ""dtuEdt"": ""20240929"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613018"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613019"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613020"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613021"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20231028"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613022"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613023"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613024"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613030"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613033"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20240531"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613036"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20230614"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230613037"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20231213"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614001"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614002"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614003"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614004"",
                              ""dtuSdt"": ""20230615"",
                              ""dtuEdt"": ""20231114"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614046"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20231201"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614051"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614052"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614054"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614055"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230710007"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20231231"",
                              ""cryOutApply"": ""Y"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230614056"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615001"",
                              ""dtuSdt"": ""20230615"",
                              ""dtuEdt"": ""20240426"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615004"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20230831"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615005"",
                              ""dtuSdt"": ""20230101"",
                              ""dtuEdt"": ""20240223"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615008"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615009"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615011"",
                              ""dtuSdt"": null,
                              ""dtuEdt"": null,
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230615014"",
                              ""dtuSdt"": ""20230615"",
                              ""dtuEdt"": ""20240615"",
                              ""cryOutApply"": ""N"",
                              ""prtiFile"": null,
                              ""carryFile"": null
                            },
                            {
                              ""dataAplcNo"": ""KC20230710007"",
                              ""dtuSdt"": ""20230615"",
                              ""dtuEdt"": ""20240615"",
                              ""cryOutApply"": ""Y"",
                              ""prtiFile"": ""/K-CURE/apc/dsb/KC20230710007"",
                              ""carryFile"": ""/K-CURE/apc/dsb/KC20230710007"",
                              ""modified"": ""Y""
                            }
                          ],
                          ""AU005"": [
                            {
                              ""dataAplcNo"": ""KC202305002"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20240608"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305002"",
                              ""modified"": ""Y""
                            },
                            {
                              ""dataAplcNo"": ""KC202305044"",
                              ""dtuSdt"": ""20230519"",
                              ""dtuEdt"": ""20230608"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305044""
                            },
                            {
                              ""dataAplcNo"": ""KC202305077"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20230610"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305077""
                            },
                            {
                              ""dataAplcNo"": ""KC202305080"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20230610"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305080""
                            },
                            {
                              ""dataAplcNo"": ""KC202305084"",
                              ""dtuSdt"": ""20230521"",
                              ""dtuEdt"": ""20230610"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305084""
                            },
                            {
                              ""dataAplcNo"": ""KC202305087"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20230611"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305087""
                            },
                            {
                              ""dataAplcNo"": ""KC202305088"",
                              ""dtuSdt"": ""20230522"",
                              ""dtuEdt"": ""20230611"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305088""
                            },
                            {
                              ""dataAplcNo"": ""KC202305131"",
                              ""dtuSdt"": ""20230523"",
                              ""dtuEdt"": ""20230612"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305131""
                            },
                            {
                              ""dataAplcNo"": ""KC202305143"",
                              ""dtuSdt"": ""20230524"",
                              ""dtuEdt"": ""20230613"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305143""
                            },
                            {
                              ""dataAplcNo"": ""KC202305144"",
                              ""dtuSdt"": ""20230525"",
                              ""dtuEdt"": ""20230614"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305144""
                            },
                            {
                              ""dataAplcNo"": ""KC202305154"",
                              ""dtuSdt"": ""20230526"",
                              ""dtuEdt"": ""20230615"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305154""
                            },
                            {
                              ""dataAplcNo"": ""KC202305155"",
                              ""dtuSdt"": ""20230530"",
                              ""dtuEdt"": ""20230619"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305155""
                            },
                            {
                              ""dataAplcNo"": ""KC202305158"",
                              ""dtuSdt"": ""20230601"",
                              ""dtuEdt"": ""20230621"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305158""
                            },
                            {
                              ""dataAplcNo"": ""KC202305159"",
                              ""dtuSdt"": ""20230529"",
                              ""dtuEdt"": ""20230618"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305159""
                            },
                            {
                              ""dataAplcNo"": ""KC202305161"",
                              ""dtuSdt"": ""20230530"",
                              ""dtuEdt"": ""20230619"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202305161""
                            },
                            {
                              ""dataAplcNo"": ""KC202306008"",
                              ""dtuSdt"": ""20230605"",
                              ""dtuEdt"": ""20230625"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306008""
                            },
                            {
                              ""dataAplcNo"": ""KC202306009"",
                              ""dtuSdt"": ""20230605"",
                              ""dtuEdt"": ""20230625"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306009""
                            },
                            {
                              ""dataAplcNo"": ""KC202306015"",
                              ""dtuSdt"": ""20230605"",
                              ""dtuEdt"": ""20230625"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306015""
                            },
                            {
                              ""dataAplcNo"": ""KC202306019"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306019""
                            },
                            {
                              ""dataAplcNo"": ""KC202306020"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306020""
                            },
                            {
                              ""dataAplcNo"": ""KC202306021"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306021""
                            },
                            {
                              ""dataAplcNo"": ""KC202306022"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306022""
                            },
                            {
                              ""dataAplcNo"": ""KC202306023"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306023""
                            },
                            {
                              ""dataAplcNo"": ""KC202306025"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306025""
                            },
                            {
                              ""dataAplcNo"": ""KC202306026"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306026""
                            },
                            {
                              ""dataAplcNo"": ""KC202306027"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306027""
                            },
                            {
                              ""dataAplcNo"": ""KC202306028"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306028""
                            },
                            {
                              ""dataAplcNo"": ""KC202306029"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306029""
                            },
                            {
                              ""dataAplcNo"": ""KC202306030"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306030""
                            },
                            {
                              ""dataAplcNo"": ""KC202306031"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306031""
                            },
                            {
                              ""dataAplcNo"": ""KC202306032"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306032""
                            },
                            {
                              ""dataAplcNo"": ""KC202306033"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306033""
                            },
                            {
                              ""dataAplcNo"": ""KC202306034"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306034""
                            },
                            {
                              ""dataAplcNo"": ""KC202306035"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306035""
                            },
                            {
                              ""dataAplcNo"": ""KC202306036"",
                              ""dtuSdt"": ""20230606"",
                              ""dtuEdt"": ""20230626"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306036""
                            },
                            {
                              ""dataAplcNo"": ""KC202306037"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306037""
                            },
                            {
                              ""dataAplcNo"": ""KC202306038"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306038""
                            },
                            {
                              ""dataAplcNo"": ""KC202306039"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306039""
                            },
                            {
                              ""dataAplcNo"": ""KC202306040"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306040""
                            },
                            {
                              ""dataAplcNo"": ""KC202306042"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306042""
                            },
                            {
                              ""dataAplcNo"": ""KC202306043"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306043""
                            },
                            {
                              ""dataAplcNo"": ""KC202306045"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306045""
                            },
                            {
                              ""dataAplcNo"": ""KC202306046"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306046""
                            },
                            {
                              ""dataAplcNo"": ""KC202306047"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306047""
                            },
                            {
                              ""dataAplcNo"": ""KC202306048"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306048""
                            },
                            {
                              ""dataAplcNo"": ""KC202306049"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306049""
                            },
                            {
                              ""dataAplcNo"": ""KC202306050"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306050""
                            },
                            {
                              ""dataAplcNo"": ""KC202306051"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306051""
                            },
                            {
                              ""dataAplcNo"": ""KC202306052"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306052""
                            },
                            {
                              ""dataAplcNo"": ""KC202306053"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306053""
                            },
                            {
                              ""dataAplcNo"": ""KC202306054"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306054""
                            },
                            {
                              ""dataAplcNo"": ""KC202306055"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306055""
                            },
                            {
                              ""dataAplcNo"": ""KC202306056"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306056""
                            },
                            {
                              ""dataAplcNo"": ""KC202306057"",
                              ""dtuSdt"": ""20230607"",
                              ""dtuEdt"": ""20230627"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306057""
                            },
                            {
                              ""dataAplcNo"": ""KC202306059"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306059""
                            },
                            {
                              ""dataAplcNo"": ""KC202306060"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306060""
                            },
                            {
                              ""dataAplcNo"": ""KC202306061"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306061""
                            },
                            {
                              ""dataAplcNo"": ""KC202306064"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306064""
                            },
                            {
                              ""dataAplcNo"": ""KC202306065"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306065""
                            },
                            {
                              ""dataAplcNo"": ""KC202306066"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306066""
                            },
                            {
                              ""dataAplcNo"": ""KC202306067"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306067""
                            },
                            {
                              ""dataAplcNo"": ""KC202306069"",
                              ""dtuSdt"": ""20230608"",
                              ""dtuEdt"": ""20230628"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306069""
                            },
                            {
                              ""dataAplcNo"": ""KC202306073"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20230629"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306073""
                            },
                            {
                              ""dataAplcNo"": ""KC202306074"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20230629"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306074""
                            },
                            {
                              ""dataAplcNo"": ""KC202306076"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20230629"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306076""
                            },
                            {
                              ""dataAplcNo"": ""KC202306077"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20230629"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306077""
                            },
                            {
                              ""dataAplcNo"": ""KC202306078"",
                              ""dtuSdt"": ""20230609"",
                              ""dtuEdt"": ""20230629"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306078""
                            },
                            {
                              ""dataAplcNo"": ""KC202306079"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20230702"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC202306079""
                            },
                            {
                              ""dataAplcNo"": ""KC20230612001"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230612001""
                            },
                            {
                              ""dataAplcNo"": ""KC20230612003"",
                              ""dtuSdt"": ""20230612"",
                              ""dtuEdt"": ""20230702"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230612003""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613003"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613003""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613005"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613005""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613013"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613013""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613017"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613017""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613021"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613021""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613023"",
                              ""dtuSdt"": ""20230614"",
                              ""dtuEdt"": ""20230704"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613023""
                            },
                            {
                              ""dataAplcNo"": ""KC20230613037"",
                              ""dtuSdt"": ""20230613"",
                              ""dtuEdt"": ""20230703"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230613037""
                            },
                            {
                              ""dataAplcNo"": ""KC20230614004"",
                              ""dtuSdt"": ""20230614"",
                              ""dtuEdt"": ""20230804"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230614004"",
                              ""modified"": ""Y""
                            },
                            {
                              ""dataAplcNo"": ""KC20230614055"",
                              ""dtuSdt"": ""20230614"",
                              ""dtuEdt"": ""20230804"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230614055"",
                              ""modified"": ""Y""
                            },
                            {
                              ""dataAplcNo"": ""KC20230710007"",
                              ""dtuSdt"": ""20230614"",
                              ""dtuEdt"": ""20230804"",
                              ""subFile"": ""/K-CURE/apc/dsb/KC20230710007"",
                              ""modified"": ""Y""
                            }
                          ]
                        }
                      ]
                    }
                  }
                }
                ";

                // gony, QA
                // jsonResponse = @"
                //{
                //  ""httpStatus"": 200,
                //  ""successYn"": ""Y"",
                //  ""errorMsg"": """",
                //  ""result"": {
                //    ""isLogin"": ""true"",
                //    ""loginFailMsg"": null,
                //    ""nasUrl"": ""198.18.229.52"",
                //    ""nasId"": ""ftpuser"",
                //    ""nasPw"": ""1234"",
                //    ""nasPort"": ""21"",
                //    ""nasBaseFolder"": ""/nasdata/svcAplc/"",
                //    ""nasEncoding"": ""euc-kr"",
                //    ""today"": ""20230710"",
                //    ""applyResult"": {
                //      ""authCode"": [
                //        {
                //          ""AU006"": [
                //            {
                //              ""dataAplcNo"": ""KC202305001"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305002"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20240425"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": ""/K-CURE/brn/KC202305002""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305044"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20240619"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305045"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20240522"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305049"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20240822"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305051"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20240425"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305052"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305059"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305064"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305065"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305067"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305068"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305069"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305070"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20240725"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305074"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305075"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20240801"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305076"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305077"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20240515"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305078"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305080"",
                //              ""dtuSdt"": ""20230514"",
                //              ""dtuEdt"": ""20231228"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305081"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20240531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305082"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305083"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305084"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20240829"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305085"",
                //              ""dtuSdt"": ""20230501"",
                //              ""dtuEdt"": ""20251021"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305086"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305087"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20240628"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305088"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20261013"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": ""/K-CURE/brn/KC202305088""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305089"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20240823"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305090"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20240620"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305091"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305092"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305093"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305094"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305095"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305096"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20231114"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305097"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305098"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305099"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20231018"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305103"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305107"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305108"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20240131"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305109"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20240726"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305111"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305112"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305116"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305117"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305118"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305119"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20240322"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305121"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305122"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305123"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305124"",
                //              ""dtuSdt"": ""20230523"",
                //              ""dtuEdt"": ""20240223"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305125"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305126"",
                //              ""dtuSdt"": ""20230507"",
                //              ""dtuEdt"": ""20241231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305127"",
                //              ""dtuSdt"": ""20230501"",
                //              ""dtuEdt"": ""20240201"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305128"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305129"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305130"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305131"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230515"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305132"",
                //              ""dtuSdt"": ""20230531"",
                //              ""dtuEdt"": ""20240629"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305133"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305134"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305135"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305136"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305137"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305143"",
                //              ""dtuSdt"": ""20230524"",
                //              ""dtuEdt"": ""20230909"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305144"",
                //              ""dtuSdt"": ""20230501"",
                //              ""dtuEdt"": ""20240430"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305146"",
                //              ""dtuSdt"": ""20230525"",
                //              ""dtuEdt"": ""20231007"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305147"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305148"",
                //              ""dtuSdt"": ""20230525"",
                //              ""dtuEdt"": ""20240202"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305149"",
                //              ""dtuSdt"": ""20230526"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305151"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305152"",
                //              ""dtuSdt"": ""20230530"",
                //              ""dtuEdt"": ""20240927"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305153"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305154"",
                //              ""dtuSdt"": ""20230526"",
                //              ""dtuEdt"": ""20241015"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": ""/K-CURE/brn/KC202305154""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305155"",
                //              ""dtuSdt"": ""20230530"",
                //              ""dtuEdt"": ""20240621"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305156"",
                //              ""dtuSdt"": ""20230527"",
                //              ""dtuEdt"": ""20240502"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305157"",
                //              ""dtuSdt"": ""20230201"",
                //              ""dtuEdt"": ""20230527"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305158"",
                //              ""dtuSdt"": ""20230528"",
                //              ""dtuEdt"": ""20240620"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305159"",
                //              ""dtuSdt"": ""20230529"",
                //              ""dtuEdt"": ""20241023"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305161"",
                //              ""dtuSdt"": ""20230530"",
                //              ""dtuEdt"": ""20240620"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305162"",
                //              ""dtuSdt"": ""20230530"",
                //              ""dtuEdt"": ""20240430"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305163"",
                //              ""dtuSdt"": ""20230531"",
                //              ""dtuEdt"": ""20240529"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305164"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306001"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20230930"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306002"",
                //              ""dtuSdt"": ""20230602"",
                //              ""dtuEdt"": ""20231214"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306003"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306004"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306005"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306006"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306007"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20240531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306008"",
                //              ""dtuSdt"": ""20230605"",
                //              ""dtuEdt"": ""20231109"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306009"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20240531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306012"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306013"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306015"",
                //              ""dtuSdt"": ""20230605"",
                //              ""dtuEdt"": ""20231026"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306016"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306017"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306018"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306019"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231030"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306020"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231031"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306021"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306022"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230927"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306023"",
                //              ""dtuSdt"": ""20230610"",
                //              ""dtuEdt"": ""20230921"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306024"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306025"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231202"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306026"",
                //              ""dtuSdt"": ""20230610"",
                //              ""dtuEdt"": ""20240210"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306027"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20231208"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306028"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20240203"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306029"",
                //              ""dtuSdt"": ""20230611"",
                //              ""dtuEdt"": ""20240203"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306030"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306031"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231111"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306032"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231230"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306033"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231202"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306034"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20240309"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306035"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20240309"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306036"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20240210"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306037"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20240531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306038"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20241231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": ""/K-CURE/brn/KC202306038""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306039"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230630"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306040"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306041"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230630"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306042"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230630"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306043"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20250610"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306044"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306045"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20240531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306046"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20231122"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306047"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20231007"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306048"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306049"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306050"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20231209"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306051"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240210"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306052"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306053"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306054"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306055"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306056"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20240106"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306057"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20231209"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306058"",
                //              ""dtuSdt"": ""20230223"",
                //              ""dtuEdt"": ""20250108"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306059"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20250208"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306060"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20260101"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306061"",
                //              ""dtuSdt"": ""20230301"",
                //              ""dtuEdt"": ""20241022"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306063"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20231103"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306064"",
                //              ""dtuSdt"": ""20230602"",
                //              ""dtuEdt"": ""20250611"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306065"",
                //              ""dtuSdt"": ""20230302"",
                //              ""dtuEdt"": ""20250608"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306066"",
                //              ""dtuSdt"": ""20230108"",
                //              ""dtuEdt"": ""20231012"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306067"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20231215"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306068"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306069"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20231228"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306070"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306071"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306072"",
                //              ""dtuSdt"": ""20230103"",
                //              ""dtuEdt"": ""20240328"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306073"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20231207"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306074"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20231213"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306075"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306076"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20231130"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306077"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230630"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306078"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20241016"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306079"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230831"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306080"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306081"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20240628"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306082"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20231031"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306083"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20231031"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612001"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20240928"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612002"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20240621"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612003"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20230930"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612004"",
                //              ""dtuSdt"": """",
                //              ""dtuEdt"": """",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612005"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20230531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612006"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612007"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612008"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612009"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612010"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612011"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613001"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613002"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613003"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613004"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613005"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20240426"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613006"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20240427"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613007"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613008"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613009"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613010"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613011"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613012"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613013"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613014"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613015"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20240911"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613016"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20240101"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613017"",
                //              ""dtuSdt"": ""20230614"",
                //              ""dtuEdt"": ""20240929"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613018"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613019"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613020"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613021"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20231028"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613022"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613023"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613024"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613030"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613033"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20240531"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613036"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20230614"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613037"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20231213"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614001"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614002"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614003"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614004"",
                //              ""dtuSdt"": ""20230615"",
                //              ""dtuEdt"": ""20231114"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614046"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20231201"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614051"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614052"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614054"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614055"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20231231"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614056"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615001"",
                //              ""dtuSdt"": ""20230615"",
                //              ""dtuEdt"": ""20240426"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615004"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20230831"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615005"",
                //              ""dtuSdt"": ""20230101"",
                //              ""dtuEdt"": ""20240223"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615008"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615009"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615011"",
                //              ""dtuSdt"": null,
                //              ""dtuEdt"": null,
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230615014"",
                //              ""dtuSdt"": ""20230615"",
                //              ""dtuEdt"": ""20240615"",
                //              ""cryOutApply"": ""N"",
                //              ""prtiFile"": null,
                //              ""carryFile"": null
                //            }
                //          ],
                //          ""AU005"": [
                //            {
                //              ""dataAplcNo"": ""KC202305002"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20230608"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305002""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305044"",
                //              ""dtuSdt"": ""20230519"",
                //              ""dtuEdt"": ""20230608"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305044""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305077"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20230610"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305077""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305080"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20230610"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305080""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305084"",
                //              ""dtuSdt"": ""20230521"",
                //              ""dtuEdt"": ""20230610"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305084""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305087"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20230611"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305087""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305088"",
                //              ""dtuSdt"": ""20230522"",
                //              ""dtuEdt"": ""20230611"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305088""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305131"",
                //              ""dtuSdt"": ""20230523"",
                //              ""dtuEdt"": ""20230612"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305131""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305143"",
                //              ""dtuSdt"": ""20230524"",
                //              ""dtuEdt"": ""20230613"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305143""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305144"",
                //              ""dtuSdt"": ""20230525"",
                //              ""dtuEdt"": ""20230614"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305144""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305154"",
                //              ""dtuSdt"": ""20230526"",
                //              ""dtuEdt"": ""20230615"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305154""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305155"",
                //              ""dtuSdt"": ""20230530"",
                //              ""dtuEdt"": ""20230619"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305155""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305158"",
                //              ""dtuSdt"": ""20230601"",
                //              ""dtuEdt"": ""20230621"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305158""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305159"",
                //              ""dtuSdt"": ""20230529"",
                //              ""dtuEdt"": ""20230618"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305159""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202305161"",
                //              ""dtuSdt"": ""20230530"",
                //              ""dtuEdt"": ""20230619"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202305161""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306008"",
                //              ""dtuSdt"": ""20230605"",
                //              ""dtuEdt"": ""20230625"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306008""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306009"",
                //              ""dtuSdt"": ""20230605"",
                //              ""dtuEdt"": ""20230625"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306009""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306015"",
                //              ""dtuSdt"": ""20230605"",
                //              ""dtuEdt"": ""20230625"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306015""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306019"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306019""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306020"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306020""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306021"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306021""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306022"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306022""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306023"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306023""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306025"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306025""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306026"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306026""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306027"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306027""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306028"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306028""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306029"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306029""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306030"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306030""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306031"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306031""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306032"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306032""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306033"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306033""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306034"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306034""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306035"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306035""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306036"",
                //              ""dtuSdt"": ""20230606"",
                //              ""dtuEdt"": ""20230626"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306036""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306037"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306037""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306038"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306038""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306039"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306039""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306040"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306040""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306042"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306042""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306043"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306043""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306045"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306045""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306046"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306046""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306047"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306047""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306048"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306048""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306049"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306049""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306050"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306050""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306051"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306051""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306052"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306052""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306053"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306053""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306054"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306054""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306055"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306055""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306056"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306056""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306057"",
                //              ""dtuSdt"": ""20230607"",
                //              ""dtuEdt"": ""20230627"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306057""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306059"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306059""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306060"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306060""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306061"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306061""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306064"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306064""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306065"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306065""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306066"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306066""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306067"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306067""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306069"",
                //              ""dtuSdt"": ""20230608"",
                //              ""dtuEdt"": ""20230628"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306069""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306073"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20230629"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306073""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306074"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20230629"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306074""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306076"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20230629"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306076""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306077"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20230629"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306077""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306078"",
                //              ""dtuSdt"": ""20230609"",
                //              ""dtuEdt"": ""20230629"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306078""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC202306079"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20230702"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC202306079""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612001"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230612001""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230612003"",
                //              ""dtuSdt"": ""20230612"",
                //              ""dtuEdt"": ""20230702"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230612003""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613003"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613003""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613005"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613005""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613013"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613013""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613017"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613017""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613021"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613021""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613023"",
                //              ""dtuSdt"": ""20230614"",
                //              ""dtuEdt"": ""20230704"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613023""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230613037"",
                //              ""dtuSdt"": ""20230613"",
                //              ""dtuEdt"": ""20230703"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230613037""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614004"",
                //              ""dtuSdt"": ""20230614"",
                //              ""dtuEdt"": ""20230704"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230614004""
                //            },
                //            {
                //              ""dataAplcNo"": ""KC20230614055"",
                //              ""dtuSdt"": ""20230614"",
                //              ""dtuEdt"": ""20230704"",
                //              ""subFile"": ""/K-CURE/apc/dsb/KC20230614055""
                //            }
                //          ]
                //        }
                //      ]
                //    }
                //  }
                //}
                //";

                jsonResponse = jsonResponseTemp;
                Log("jsonResponse", PrettifyJSON(jsonResponse));

                JsonDocument doc = JsonDocument.Parse(jsonResponse);

                var baseReponse = BaseResponse.ToObject<BaseResponse>(doc.RootElement);
                if (baseReponse == null)
                {
                    string msg = "Cannot convert to BaseResponse";
                    return (false, msg, new T());
                }

                var success = baseReponse.successYn == "Y";
                if (!success)
                {
                    string msg = baseReponse.errorMsg;
                    return (false, msg, new T());
                }

                var typeResponse = BaseResponse.ToObject<T>(doc.RootElement);
                if (response == null)
                {
                    string msg2 = $"Cannot convert to {typeof(T).Name}";
                    return (false, msg2, new T());
                }

                return (true, "", typeResponse ?? new T());
            }
            catch (Exception ex)
            {
                CCommon.Log.WriteLog(ex);
                return (false, ex.Message, new T());
            }
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal async Task<(bool, string, LoginResult)> Login(string id, string password)
        {
            string url = CCommon.GetAppSetting<string>(ConfigAppKeys.LoginUrl, "");
            Log("url", url);

            var request = new LoginRequest(id, password);
            string jsonContent = JsonSerializer.Serialize(request);
            Log("jsonContent", PrettifyJSON(jsonContent));

            (bool success, string msg, LoginResponse response) = await Send<LoginResponse>(url, jsonContent);
            if (!success)
            {
                return (false, msg, new LoginResult());
            }

            if (response.result.isLogin != "true")
            {
                string msg2 = response.result.loginFailMsg;
                return (false, msg2, new LoginResult());
            }

            return (true, "", response.result);
        }

        /// <summary>
        /// 파일 반출
        /// </summary>
        /// <param name="dataAplyNo"></param>
        /// <param name="userId"></param>
        /// <param name="cryOutFiles"></param>
        /// <returns></returns>
        internal async Task<(bool, string, AplyResponse)> Aply(string dataAplyNo, string userId, List<string> cryOutFiles)
        {
            string url = CCommon.GetAppSetting<string>(ConfigAppKeys.AplyUrl, "");
            Log("url", url);

            var request = new AplyRequest(dataAplyNo, userId, cryOutFiles);
            string jsonContent = JsonSerializer.Serialize(request);
            Log("jsonContent", PrettifyJSON(jsonContent));

            (bool success, string msg, AplyResponse response) = await Send<AplyResponse>(url, jsonContent);
            if (!success)
            {
                return (false, msg, new AplyResponse());
            }

            if (!response.result.isApply)
            {
                return (false, response.result.applyFailMsg, new AplyResponse());
            }

            return (true, "", response);
        }

        public void Log(string category, string log)
        {
            Console.WriteLine($"\nDEBUG>>> ({category}) \n{log}");
        }

        public string PrettifyJSON(string json)
        {
            string beautifiedJson = Newtonsoft.Json.JsonConvert.SerializeObject(
            Newtonsoft.Json.JsonConvert.DeserializeObject(json),
            Newtonsoft.Json.Formatting.Indented);

            return beautifiedJson;
        }
    }

}
