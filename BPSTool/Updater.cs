using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BPSTool
{
    class Updater
    {
        private const string URL_LASTEST_VERSION = "https://www.beecom.online/beecom_files/bpstool_update.html";
        private const string TAG_VERSION = "version";
        private const string TAG_DOWNLOAD_URL = "download";

        private string lastestVersion;
        private string LastestVersionUrl;
        private string downloadLinkUrl;
        private bool endFlag;

        private bool launchCheckFlag;

        private MainForm form;
        private MainForm.DelUpdateUI_VV delUpdateUI_VV;


        public Updater(MainForm f)
        {
            lastestVersion = "";
            LastestVersionUrl = URL_LASTEST_VERSION;
            downloadLinkUrl = "";
            endFlag = true;
            form = f;
            launchCheckFlag = true;
        }

        public bool EndFlag { get => endFlag; }
        public string DownloadLinkUrl { get => downloadLinkUrl; }
        public string LastestVersion { get => lastestVersion; }
        public bool LaunchCheckFlag { get => launchCheckFlag; set => launchCheckFlag = value; }

        public void StartWebRequest(MainForm.DelUpdateUI_VV del_vv)
        {
            endFlag = false;
            downloadLinkUrl = "";
            delUpdateUI_VV = del_vv;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LastestVersionUrl);
            request.BeginGetResponse(new AsyncCallback(FinishWebRequest), request);
        }

        private void FinishWebRequest(IAsyncResult result)
        {
            try
            {
                HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Regex regex = new Regex(@"<" + TAG_VERSION + @">" + @"([.0-9]+)" + "</" + TAG_VERSION + @">");
                GroupCollection groups = regex.Match(content).Groups;
                lastestVersion = groups[1].Value;

                regex = new Regex(@"<" + TAG_DOWNLOAD_URL + @">" + @"(.+)" + "</" + TAG_DOWNLOAD_URL + @">");
                groups = regex.Match(content).Groups;
                downloadLinkUrl = groups[1].Value;

            }
            catch
            {
                lastestVersion = "";
                downloadLinkUrl = "";
            }
            finally
            {
                endFlag = true;
            }

            form.BpsToolCallback(delUpdateUI_VV);
        }

    }
}
