using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using Serilog;
using System;
using System.Net;
using Towertycg_APP.Modules;

namespace Towertycg_APP.Methods
{
    public class APIMethod
    {
        private int time = 3000;
        /// <summary>
        /// 主要網址
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorStr { get; set; } = "NONE";
        /// <summary>
        /// API回應錯誤訊息
        /// </summary>
        public string ResponseErrorMessage { get; set; } = "";
        /// <summary>
        /// 回傳狀態
        /// </summary>
        public HttpStatusCode statusCode { get; set; }
        /// <summary>
        /// API回應數值
        /// </summary>
        public string ResponseDataMessage { get; set; } = "";
        /// <summary>
        /// API連結旗標
        /// </summary>
        public bool ClientFlag { get; set; } = true;
        /// <summary>
        /// API連結物件
        /// </summary>
        private RestClient clinet { get; set; }
        /// <summary>
        /// 版本編號
        /// </summary>
        public string ReleaseNumber { get; set; }
        public APIMethod(string url, string releaseNumber)
        {
            ReleaseNumber = releaseNumber;
            URL = url;
            post_realtime_data = url + "api/post-realtime-data";
            post_setting = url + "api/Device/post-setting";
            get_device_setting = url + "api/Device/get-device-setting";
        }
        #region 上傳資訊
        /// <summary>
        /// 上傳資訊(Post)
        /// </summary>
        private string post_realtime_data { get; set; }
        #endregion
        #region 設備設定
        /// <summary>
        /// 設定設備資訊(Post)
        /// </summary>
        private string post_setting { get; set; }
        /// <summary>
        /// 設備資訊(Get)
        /// </summary>
        private string get_device_setting { get; set; }
        #endregion

        /*以下API功能----------------------------------------------------------------------------------------*/

        #region 上傳資訊
        /// <summary>
        /// 上傳資訊
        /// </summary>
        /// <param name="updateClass"></param>
        public void Post_Realtime_Data(UpdateClass updateClass)
        {
            try
            {
                string value = JsonConvert.SerializeObject(updateClass);
                var option = new RestClientOptions(post_realtime_data)
                {
                    MaxTimeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(value, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ResponseMessage(response.Result);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "上傳資訊API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
            }
        }
        #endregion
        #region 設備設定
        /// <summary>
        /// 新增設備設定API
        /// </summary>
        /// <param name="updateClass"></param>
        public void Post_Setting(UpdateClass updateClass)
        {
            try
            {
                string value = JsonConvert.SerializeObject(updateClass);
                var option = new RestClientOptions(post_setting)
                {
                    MaxTimeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(value, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ResponseMessage(response.Result);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增設備設定API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
            }
        }
        #endregion
        #region 訊息回傳處理
        /// <summary>
        /// 訊息回傳處理
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string ResponseMessage(RestResponse response)
        {
            ResponseErrorMessage = "";
            statusCode = response.StatusCode;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ClientFlag = true;
                ResponseDataMessage += response.Content.Replace("\"", "").Replace("\\n","\r\n");
                return "200";
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ClientFlag = true;
                string error = response.Content;
                ResponseErrorMessage = error.Replace("\r\n", "").Replace("\"", "");
                return ResponseErrorMessage;
            }
            else
            {
                ClientFlag = false;
                return ResponseErrorMessage = response.ErrorMessage;
            }
        }
        #endregion
    }
}
