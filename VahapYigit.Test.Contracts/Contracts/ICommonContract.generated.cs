﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Contracts
{
	using System;
	using System.Net.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.Threading.Tasks;
	using System.Xml;

	/// <summary>
	/// CommonService Contract.
	/// </summary>
	[ServiceContract(Namespace = VahapYigit.Test.Core.Globals.Namespace)]
	[ServiceKnownType(typeof(VahapYigit.Test.Core.ClientContext))]
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	public partial interface ICommonService : IService
	{
		#region [ ICommonService Business ]
		#pragma warning disable 1591 // Disable 'missing XML comment for publicly visible type or member' warnings

		[OperationContract(Name = "GlobalSearch")]
		System.Collections.Generic.IList<VahapYigit.Test.Models.GlobalSearchResultItem> GlobalSearch(VahapYigit.Test.Core.IUserContext userContext, string keyword, ref System.PagingOptions paging, System.Collections.Generic.IEnumerable<string> restrictionTableNames = null);
		
		[OperationContract(Name = "GetTableSizes")]
		System.Collections.Generic.IList<VahapYigit.Test.Models.TableSizeModel> GetTableSizes(VahapYigit.Test.Core.IUserContext userContext);
		
		#pragma warning restore 1591
		#endregion
	}
}