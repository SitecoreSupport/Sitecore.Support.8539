namespace Sitecore.Support.XA.Foundation.Editing.Pipelines.RenderField
{
    using Sitecore.Pipelines.RenderField;
    using Sitecore.XA.Foundation.Multisite.Extensions;
    using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;

    public class RenderWebEditing : Sitecore.Pipelines.RenderField.RenderWebEditing
    {
        public new virtual void Process(RenderFieldArgs args)
        {
            if (!Context.Site.IsSxaSite())
            {
                #region Added code
                base.Process(args); 
                #endregion
                return;
            }

            string localContent = args.RenderParameters["local-content"];
            string disableEditing = args.RenderParameters["disable-editing"];

            if (disableEditing == "true")
            {
                if (localContent == "false")
                {
                    return;
                }
                args.Parameters = args.Parameters.AddParameter("skipcommonbuttons", string.Empty);
            }

            base.Process(args);
        }
    }
}