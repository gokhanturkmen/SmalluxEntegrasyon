using System.Collections.Generic;
using System.Linq;

namespace SmalluxEntegrasyon.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string XmlURL { get; set; }

        private Tag Root            { get; set; }
        private Tag Item            { get; set; }
        private Tag id              { get; set; }
        private Tag StockCode       { get; set; }
        private Tag Label           { get; set; }
        private Tag Status          { get; set; }
        private Tag Brand           { get; set; }
        private Tag BrandId         { get; set; }
        private Tag Barcode         { get; set; }
        private Tag MainCategory    { get; set; }
        private Tag Category        { get; set; }
        private Tag SubCategory     { get; set; }
        //private Tag CategoryTree  { get; set; }
        private Tag Price1          { get; set; }
        private Tag Tax             { get; set; }
        private Tag CurrencyAbbr    { get; set; }
        private Tag StockAmount     { get; set; }
        private Tag StockType       { get; set; }
        private Tag Warranty        { get; set; }
        private Tag Picture1Path    { get; set; }
        private Tag Picture2Path    { get; set; }
        private Tag Picture3Path    { get; set; }
        private Tag Picture4Path    { get; set; }
        private Tag Picture5Path    { get; set; }
        private Tag Picture6Path    { get; set; }
        private Tag Picture7Path    { get; set; }
        private Tag Picture8Path    { get; set; }
        private Tag Dm3             { get; set; }
        private Tag Details         { get; set; }
        private Tag Rebate          { get; set; }
        private Tag RebateType      { get; set; }
        private Tag ShortDetails    { get; set; }
        private Tag Title           { get; set; }
        private Tag Keywords        { get; set; }
        private Tag Description     { get; set; }
        private Tag SearchKeywords  { get; set; }

        public List<Tag> Tags { get; set; }

        public Supplier()
        {
            Root              = new Tag("root");
            Item              = new Tag("item");
            id                = new Tag("id");
            StockCode         = new Tag("stockCode");
            Label             = new Tag("label");
            Status            = new Tag("status");
            Brand             = new Tag("brand");
            BrandId           = new Tag("brandId");
            Barcode           = new Tag("barcode");
            MainCategory      = new Tag("mainCategory");
            Category          = new Tag("category");
            SubCategory       = new Tag("subCategory");
            Price1            = new Tag("price1");
            Tax               = new Tag("tax");
            CurrencyAbbr      = new Tag("currencyAbbr");
            StockAmount       = new Tag("stockAmount");
            StockType         = new Tag("stockType");
            Warranty          = new Tag("warranty");
            Picture1Path      = new Tag("picture1Path");
            Picture2Path      = new Tag("picture2Path");
            Picture3Path      = new Tag("picture3Path");
            Picture4Path      = new Tag("picture4Path");
            Picture5Path      = new Tag("picture5Path");
            Picture6Path      = new Tag("picture6Path");
            Picture7Path      = new Tag("picture7Path");
            Picture8Path      = new Tag("picture8Path");
            Dm3               = new Tag("dm3");
            Details           = new Tag("details");
            Rebate            = new Tag("rebate");
            RebateType        = new Tag("rebateType");
            ShortDetails      = new Tag("shortdetails");
            Title             = new Tag("title");
            Keywords          = new Tag("keywords");
            Description       = new Tag("description");
            SearchKeywords    = new Tag("searchKeywords");
            
            Tags = new List<Tag>();
            Tags.Add(Root);
            Tags.Add(Item);
            Tags.Add(id);
            Tags.Add(StockCode);
            Tags.Add(Label);
            Tags.Add(Status);
            Tags.Add(Brand);
            Tags.Add(BrandId);
            Tags.Add(Barcode);
            Tags.Add(MainCategory);
            Tags.Add(Category);
            Tags.Add(SubCategory);
            Tags.Add(Price1);
            Tags.Add(Tax);
            Tags.Add(CurrencyAbbr);
            Tags.Add(StockAmount);
            Tags.Add(StockType);
            Tags.Add(Warranty);
            Tags.Add(Picture1Path);
            Tags.Add(Picture2Path);
            Tags.Add(Picture3Path);
            Tags.Add(Picture4Path);
            Tags.Add(Picture5Path);
            Tags.Add(Picture6Path);
            Tags.Add(Picture7Path);
            Tags.Add(Picture8Path);
            Tags.Add(Details);
            Tags.Add(Dm3);
            Tags.Add(Rebate);
            Tags.Add(RebateType);
            Tags.Add(ShortDetails);
            Tags.Add(Title);
            Tags.Add(Keywords);
            Tags.Add(Description);
            Tags.Add(SearchKeywords);
        }

        public Tag GetTagByName(string name)
        {
            return Tags.Where(x => x.Name == name).FirstOrDefault();
        }
    }

    public class Tag
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public TagTypes Type { get; set; }
        public bool CData { get; set; }
        public string SplitChar { get; set; }
        public string CombineChar { get; set; }
        public string Default { get; set; }
        public string Parent { get; set; }
        public int ChildLevel { get; set; }

        public Tag(string name)
        {
            Name = name.Trim();
        }
    }

    public enum TagTypes
    {
        Null = 0,
        TagName = 1,
        Combine = 2,
        Split = 3,
        Increment = 4,
        SelfClosing = 5
    }
}
