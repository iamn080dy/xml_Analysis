using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XML_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = findOpenData();
            showOpenData(nodes);
            Console.ReadKey();
        }

        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"../../../Data/opendata.epa.gov.tw.xml");

            var nodes = xml.Descendants("Data").ToList();

            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.縣市 = getValue(node, "County");
                item.測站名稱 = getValue(node, "SiteName");
                item.監測日期 = getValue(node, "MonitorDate");
                item.數值 = getValue(node, "Concentration");
                result.Add(item);
            }

            return result;
        }
        
        private static String getValue(XElement node, String propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
        }

        private static void showOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(String.Format("共收到{0}筆的資料", nodes.Count));
            nodes.GroupBy(node => node.縣市).ToList().ForEach(group =>
            {
                var key = group.Key;
                var groupDatas = group.ToList();
                var message = $"{key}, 共有{groupDatas.Count()}筆資料";
                Console.WriteLine(message);
            });

        }

    }
}
