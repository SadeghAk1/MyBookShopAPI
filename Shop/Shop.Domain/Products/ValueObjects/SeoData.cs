using Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Products.ValueObjects
{

    public class SeoData : BaseValueObject
    {
        public string MetaTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string MetaKeywords { get; private set; }
        public bool IndexPage { get; private set; }
        public string Canonical { get; private set; }
        public string Schema { get; private set; }

        public SeoData(string metaTitle, string metaDescription, string metaKeywords, bool indexPage, string canonical, string schema)
        {
            MetaTitle = metaTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            IndexPage = indexPage;
            Canonical = canonical;
            Schema = schema;
        }

    }


}
