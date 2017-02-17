﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//-----------------------------------------------------------------------------

namespace VahapYigit.Test.Services
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.Threading.Tasks;
	using System.Transactions;
	using System.Xml;
	
	using VahapYigit.Test.Business;
	using VahapYigit.Test.Contracts;
	using VahapYigit.Test.Core;
	using VahapYigit.Test.Crud;

	/// <summary>
	/// AppSettingsService Service.
	/// </summary>
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
	public partial class AppSettingsService : IAppSettingsService
	{
		#region [ IService Implementation ]
		
		bool IService.WakeUp(IUserContext userContext)
		{
			return true;
		}

		async Task<bool> IService.WakeUpAsync(IUserContext userContext)
		{
			return await Task.Factory.StartNew(() => true);
		}

		#endregion

		#region [ IAppSettingsService Implementation ]
		
		/// <summary>
		/// Refreshs the entity instance from the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="appSettings">
		/// Entity to refresh (must be in database).
		/// </param>
		public void Refresh(IUserContext userContext, ref VahapYigit.Test.Models.AppSettings entity)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				db.Refresh(ref entity);
			}
		}
		
		/// <summary>
		/// Gets an entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The entity.
		/// </returns>
		public VahapYigit.Test.Models.AppSettings GetById(IUserContext userContext, long id)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.GetById(id);
			}
		}

		/// <summary>
		/// Gets entities with search options.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options, filters, orderby, paging, etc.
		/// </param>
		/// 
		/// <returns>
		/// A collection of entities.
		/// </returns>
		public TCollection<VahapYigit.Test.Models.AppSettings> Search(IUserContext userContext, ref SearchOptions options)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.Search(ref options);
			}
		}

		/// <summary>
		/// Gets the number of records that verify the search options.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional search options. If not defined all records are counted.
		/// </param>
		/// 
		/// <returns>
		/// The number of records.
		/// </returns>
		public int Count(IUserContext userContext, SearchOptions options = null)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.Count(options);
			}
		}
		
		/// <summary>
		/// Indicates whether the search returns at least 1 entity.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional search options. If not defined, all records are returned.
		/// </param>
		/// 
		/// <returns>
		/// True if the search returns at least 1 entity; otherwise, false.
		/// </returns>
		public bool HasResult(IUserContext userContext, SearchOptions options = null)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.HasResult(options);
			}
		}
		
		/// <summary>
		/// Saves (or updates) the entity in the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		///
		/// <param name="entity">
		/// Entity to save or update.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public int Save(IUserContext userContext, ref VahapYigit.Test.Models.AppSettings entity, SaveOptions options = null)
		{
			using (var et = new ExecutionTracerService(tag: entity.State.ToString()))
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.Save(ref entity, options);
			}
		}
		
		/// <summary>
		/// Deletes the entity from the database.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="entity">
		/// Entity to delete.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public int Delete(IUserContext userContext,VahapYigit.Test.Models.AppSettings entity)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.Delete(entity);
			}
		}
		
		/// <summary>
		/// Deletes the entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public int Delete(IUserContext userContext, long id)
		{
			using (var et = new ExecutionTracerService())
			using (var db = new AppSettingsCrud(userContext))
			{
				return db.Delete(id);
			}
		}

		#endregion

		#region [ IAppSettingsService Business Implementation ]
		#pragma warning disable 1591 // Disable 'missing XML comment for publicly visible type or member' warnings

		public VahapYigit.Test.Models.AppSettings GetByKey(VahapYigit.Test.Core.IUserContext userContext, string key)
		{
			using (var et = new ExecutionTracerService())
			{
				var business = new AppSettingsBusiness();
				return business.GetByKey(userContext, key);
			}
		}

		public string GetStringValue(VahapYigit.Test.Core.IUserContext userContext, string key, string defaultValue = null)
		{
			using (var et = new ExecutionTracerService())
			{
				var business = new AppSettingsBusiness();
				return business.GetStringValue(userContext, key, defaultValue);
			}
		}

		public bool GetBoolValue(VahapYigit.Test.Core.IUserContext userContext, string key, bool defaultValue = false)
		{
			using (var et = new ExecutionTracerService())
			{
				var business = new AppSettingsBusiness();
				return business.GetBoolValue(userContext, key, defaultValue);
			}
		}

		public short GetShortValue(VahapYigit.Test.Core.IUserContext userContext, string key, short defaultValue = 0)
		{
			using (var et = new ExecutionTracerService())
			{
				var business = new AppSettingsBusiness();
				return business.GetShortValue(userContext, key, defaultValue);
			}
		}

		public int GetIntValue(VahapYigit.Test.Core.IUserContext userContext, string key, int defaultValue = 0)
		{
			using (var et = new ExecutionTracerService())
			{
				var business = new AppSettingsBusiness();
				return business.GetIntValue(userContext, key, defaultValue);
			}
		}

		public long GetLongValue(VahapYigit.Test.Core.IUserContext userContext, string key, long defaultValue = 0)
		{
			using (var et = new ExecutionTracerService())
			{
				var business = new AppSettingsBusiness();
				return business.GetLongValue(userContext, key, defaultValue);
			}
		}

		#pragma warning restore 1591
		#endregion
	}
}