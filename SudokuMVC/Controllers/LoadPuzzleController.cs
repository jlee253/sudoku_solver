using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Xml;
using HtmlAgilityPack;

namespace SudokuMVC.Controllers
{
    public class LoadPuzzleController : ApiController
    {
        // GET: api/LoadPuzzle
        public IEnumerable<string> Get()
        {
            return new string[] { "Please call /LoadPuzzle/Puzzle Number to load a puzzle." };
        }

        // GET: api/LoadPuzzle/5
        [Route("api/loadpuzzle/{difficulty}/{id}")]
        public string Get(string difficulty, string id)
        {
            if (difficulty == "Easy") difficulty = "1";
            if (difficulty == "Medium") difficulty = "2";
            if (difficulty == "Hard") difficulty = "3";
            if (difficulty == "Evil") difficulty = "4";

            return RetrievePuzzle(difficulty, id);
        }

        // POST: api/LoadPuzzle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoadPuzzle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoadPuzzle/5
        public void Delete(int id)
        {
        }

        private string RetrievePuzzle(string strDifficulty, string strPuzzleNumber)
        {
            string ret = "";
            string strSudoku = "http://view.websudoku.com/?level=" + strDifficulty + "&set_id=" + strPuzzleNumber;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(strSudoku);
                myRequest.Method = "GET";
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);

                string strCheat = doc.GetElementbyId("cheat").GetAttributeValue("value", "");
                string strMask = doc.GetElementbyId("editmask").GetAttributeValue("value", "");
                
                ret = "";
                for (int i = 0; i < strCheat.Length; i++ )
                {
                    if (strMask.Substring(i, 1) == "1") ret += "0";
                    else ret += strCheat.Substring(i, 1);
                }
            }
            catch (Exception ex)
            {
                //ret = "Error loading puzzle";
                ret = ex.Message;
            }

            return ret;
        }
    }
}
