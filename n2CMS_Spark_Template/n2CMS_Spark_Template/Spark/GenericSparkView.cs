using System.Web.Mvc;
using System.Web.UI;
using Spark.Web.Mvc;

namespace n2CMS_Spark_Template.Spark
{
	public abstract class MySparkView : SparkView
	{
	}

	public abstract class MySparkView<TModel> : SparkView<TModel> where TModel : class
	{
		public new HtmlHelper<TModel> Html
		{
			get
			{
				var result = base.Html;
				if (result == null && base.Html != null)
				{
					result = new HtmlHelper<TModel>(base.Html.ViewContext, base.Html.ViewDataContainer);
					base.Html = result;
				}
				return result;
			}
		}
	}

}
