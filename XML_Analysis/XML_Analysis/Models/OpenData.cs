using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDataImport.Models
{
	public class OpenData
	{
        public String 測站名稱 { get; set; }  // SiteName
        public String 縣市 { get; set; }      // County
        public String 監測日期 { get; set; }  // MonitorDate
        public String 數值 { get; set; }      // Concentration
    }
}
