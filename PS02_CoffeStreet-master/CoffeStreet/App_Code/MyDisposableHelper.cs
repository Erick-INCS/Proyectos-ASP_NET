using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeStreet.App_Code
{
    public static class Extensions
    {
        public static MyDisposableHelper DefaultSection(this HtmlHelper htmlHelper)
        {
            TagBuilder section = new TagBuilder("section"),
                        div0 = new TagBuilder("div"),
                        div1 = new TagBuilder("div"),
                        div2 = new TagBuilder("div");
            //add default css classes, attributes as needed
            section.AddCssClass("section");
            div0.AddCssClass("container");
            div1.AddCssClass("row");
            div2.AddCssClass("col-lg-12");
            
            htmlHelper.ViewContext.Writer.Write(section.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write(div0.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write(div1.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write(div2.ToString(TagRenderMode.StartTag));
            return new MyDisposableHelper(htmlHelper.ViewContext);
        }

        public static HBuilder AdmFormControl(this HtmlHelper htmlHelper, int size = 4)
        {
            htmlHelper.ViewContext.Writer.Write($"<div class=\"col-lg-{size} col-md-{size} col-sm-{size} col-xs-12\"><div class=\"form-group ic-cmp-int\" ><div class=\"form-ic-cmp\" ></div><div class=\"nk-int-st\">");

            return new HBuilder(htmlHelper.ViewContext, new string[] { "</div>", "</div>", "</div>" });
        }
    }
    public class MyDisposableHelper : IDisposable
    {
        private bool _disposed;
        private readonly ViewContext _viewContext;

        public MyDisposableHelper(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }
            _viewContext = viewContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;
            _viewContext.Writer.Write("</section>");
            _viewContext.Writer.Write("</div>");
            _viewContext.Writer.Write("</div>");
            _viewContext.Writer.Write("</div>");
        }

        public void EndForm()
        {
            Dispose(true);
        }

    }

    public class HBuilder : IDisposable
    {
        private bool _disposed;
        private readonly ViewContext _viewContext;
        private string[] labels;

        public HBuilder(ViewContext viewContext, string[] labels)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }
            this.labels = labels;
            _viewContext = viewContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;
            foreach (string lbl in labels)
            {
                _viewContext.Writer.Write(lbl);
            }
        }

        public void EndForm()
        {
            Dispose(true);
        }

    }
}