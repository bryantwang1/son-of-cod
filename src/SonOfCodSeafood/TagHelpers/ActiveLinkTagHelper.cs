using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SonOfCodSeafood.TagHelpers
{
    public class NavlinkTagHelper : TagHelper
    {
        //private const string ActiveActionAttributeName = "active-action";
        //private const string ActiveControllerAttributeName = "active-controller";

        public string ActiveAction { get; set; }
        public string ActiveController { get; set; }
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";

            if(ViewContext.RouteData.Values["Action"].ToString() == ActiveAction && ViewContext.RouteData.Values["Controller"].ToString() == ActiveController)
            {
                output.Attributes.Add("class", "active nav-item");
            }
            else
            {
                output.Attributes.Add("class", "nav-item");
            }

        }
    }
}
