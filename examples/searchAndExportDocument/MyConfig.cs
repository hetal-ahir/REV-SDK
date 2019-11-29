using System;
using System.Collections.Generic;
using System.Text;

namespace searchAndExportDocument
{
    public class MyConfig
    {
        // repo name
        public string projectName { get; set; }

        //search index name
        public string searchIndex { get; set; }

        // search index value
        public string searchIndexValue { get; set; }

        // Main folder name
        public string downFolder { get; set; }

        // Document's folder name
        public string docFolderName1 { get; set; }

        public string docFolderName2 { get; set; }
    }
}
