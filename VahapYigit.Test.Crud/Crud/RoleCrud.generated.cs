﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Crud
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.Common;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Transactions;

	using VahapYigit.Test.Core;

	/// <summary>
	/// RoleCrud class used to access to the database using stored procedures.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
	public partial class RoleCrud : CrudBase<VahapYigit.Test.Models.Role>
	{
		#region [ Constructor ]

		/// <summary>
		/// Constructor.
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		public RoleCrud(IUserContext userContext)
			: base(userContext)
		{
			base.Initialize();
		}

		#endregion

		#region [ Public methods ]
		
		/// <summary>
		/// Refreshs the entity instance from the database.
		/// </summary>
		/// 
		/// <param name="appSettings">
		/// Entity to refresh (must be in database).
		/// </param>
		public override void Refresh(ref VahapYigit.Test.Models.Role entity)
		{
			ConditionChecker.Required(
				entity != null,
				new ArgumentNullException("entity"));

			long id = entity.Id;

			entity = this.GetById(id);
			if (entity == null)
			{
				throw new EntityNotFoundException(VahapYigit.Test.Models.Role.EntityName, id);
			}
		}
		
		/// <summary>
		/// Gets an entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The entity.
		/// </returns>
		public override VahapYigit.Test.Models.Role GetById(long id)
		{
			using (var et = new ExecutionTracerService())
			{
				VahapYigit.Test.Models.Role entity = null;

				var parameters = new Dictionary<string, object>();

				parameters.Add("@Role_Id", id);

				var collection = base.ToEntityCollection("Role_Get", parameters, withDeepMapping: false);
				if (!collection.IsNullOrEmpty())
				{
					entity = collection[0];
				}

				return entity;
			}
		}

		/// <summary>
		/// Gets an entity given its unique CodeRef value.
		/// </summary>
		/// 
		/// <param name="codeRef">
		/// Unique CodeRef value.
		/// </param>
		/// 
		/// <returns>
		/// The entity.
		/// </returns>
		public VahapYigit.Test.Models.Role GetByCodeRef(string codeRef)
		{
			VahapYigit.Test.Models.Role entity = null;

			using (var et = new ExecutionTracerService())
			{
				var options = new SearchOptions();

				options.Filters.Add(VahapYigit.Test.Models.Role.ColumnNames.CodeRef, FilterOperator.Equals, codeRef.ToString());
				options.MaxRecords = 1;

				var collection = this.Search(ref options);
				if (!collection.IsNullOrEmpty())
				{
					entity = collection[0];
				}
			}
			
			return entity;
		}

		/// <summary>
		/// Searchs entities with search options.
		/// </summary>
		/// 
		/// <param name="options">
		/// Optional options, filters, orderby, paging, etc.
		/// </param>
		/// 
		/// <returns>
		/// A collection of entities.
		/// </returns>
		public override TCollection<VahapYigit.Test.Models.Role> Search(ref SearchOptions options)
		{
			TCollection<VahapYigit.Test.Models.Role> collection = null;
			
			using (var et = new ExecutionTracerService())
			{
				if (options == null)
				{
					options = new SearchOptions();
				}

				var parameters = new Dictionary<string, object>();

				if (!options.Filters.IsNullOrEmpty())
				{
					parameters.Add("Filter", options.Filters.ToSql());
				}

				if (!options.Orders.IsNullOrEmpty())
				{
					parameters.Add("OrderBy", options.Orders.ToSql());
				}

				int maxRecords = int.MaxValue;
				if (options.MaxRecords != 0)
				{
					maxRecords = (options.MaxRecords < 0) ? 0 : options.MaxRecords;
				}

				parameters.Add("MaxRecords", maxRecords);

				parameters.Add("CtxWithPaging", options.WithPaging);
				parameters.Add("CtxPagingCurrentPage", options.PagingOptions.CurrentPage);
				parameters.Add("CtxPagingRecordsPerPage", options.PagingOptions.RecordsPerPage);

				DbConnection dbConnection;

				using (var dbReader = this.ToDataReader("Role_Search", parameters, out dbConnection))
				{
					collection = this.Map(dbReader);

					dbReader.NextResult();
					dbReader.Read();

					options.PagingOptions.TotalRecords = TypeHelper.To<int>(dbReader[0]);
				}

				if (dbConnection != null)
					dbConnection.Close();
			}

			return collection;
		}

		/// <summary>
		/// Gets the number of records that verify the search options.
		/// </summary>
		/// 
		/// <param name="options">
		/// Optional search options. If not defined all records are counted.
		/// </param>
		/// 
		/// <returns>
		/// The number of records.
		/// </returns>
		public override int Count(SearchOptions options = null)
		{
			using (var et = new ExecutionTracerService())
			{
				if (options == null)
				{
					options = new SearchOptions();
				}

				var parameters = new Dictionary<string, object>();

				if (!options.Filters.IsNullOrEmpty())
				{
					parameters.Add("Filter", options.Filters.ToSql());
				}

				return base.ExecuteScalar<int>("Role_Count", parameters);
			}
		}
		
		/// <summary>
		/// Saves (or updates) the entity in the database.
		/// </summary>
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
		public override int Save(ref VahapYigit.Test.Models.Role entity, SaveOptions options = null)
		{
			ConditionChecker.Required(
				entity != null,
				new ArgumentNullException("entity"));

			if (options == null)
			{
				options = SaveOptions.Default;
			}

			int rowCount = 0;

			using (var scope = TransactionScopeHelper.CreateDefaultTransactionScope())
			{
				this.OnSaving(ref entity, options);

				if (options.SaveChildren)
				{
					rowCount = this.PersistWithChildren(ref entity, new ObjectIDGenerator(), options);
				}
				else
				{
					rowCount = this.Persist(ref entity, options);
				}
				
				this.OnSaved(ref entity, options);

				scope.Complete();
			}

			return rowCount;
		}
		
		/// <summary>
		/// Saves or updates the entity without its children.
		/// </summary>
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
		private int Persist(ref VahapYigit.Test.Models.Role entity, SaveOptions options = null)
		{
			if (entity.State !=VahapYigit.Test.Models.EntityState.ToInsert && 
				entity.State !=VahapYigit.Test.Models.EntityState.ToUpdate)
			{
				return 0;
			}

			IList<TranslationEnum> errors;
			if (!entity.IsValid(out errors))
			{
				throw new EntityValidationException(errors);
			}

			int rowCount = 0;

			using (var et = new ExecutionTracerService(tag: entity.State.ToString()))
			{
				if (options.CheckUniqueConstraints)
				{
					IList<TranslationEnum> ucErrors = new List<TranslationEnum>();
					SearchOptions searchOpts = new SearchOptions();

					searchOpts.Clear();

					if (entity.State ==VahapYigit.Test.Models.EntityState.ToUpdate)
					{
						searchOpts.Filters.Add(VahapYigit.Test.Models.Role.ColumnNames.Id, FilterOperator.Different, entity.Id);
					}

					searchOpts.Filters.Add(VahapYigit.Test.Models.Role.ColumnNames.CodeRef, FilterOperator.Equals, entity.CodeRef);

					if (this.HasResult(searchOpts))
					{
						ucErrors.Add(TranslationEnum.CrudRoleCodeRefUniqueConstraint);
					}

					searchOpts.Clear();

					if (entity.State ==VahapYigit.Test.Models.EntityState.ToUpdate)
					{
						searchOpts.Filters.Add(VahapYigit.Test.Models.Role.ColumnNames.Id, FilterOperator.Different, entity.Id);
					}

					searchOpts.Filters.Add(VahapYigit.Test.Models.Role.ColumnNames.Name, FilterOperator.Equals, entity.Name);

					if (this.HasResult(searchOpts))
					{
						ucErrors.Add(TranslationEnum.CrudRoleNameUniqueConstraint);
					}

					if (ucErrors.Count != 0)
					{
						throw new EntityValidationException(ucErrors);
					}
				}

				var parameters = new Dictionary<string, object>();

				parameters.Add("@Role_Id", entity.Id);
				parameters.Add("@Role_CodeRef", entity.CodeRef);
				parameters.Add("@Role_Name", entity.Name);

				var collection = base.ToEntityCollection("Role_Save", parameters, withDeepMapping: false);
				if (!collection.IsNullOrEmpty())
				{
					entity.Map(collection[0]);
					rowCount = 1;
				}

				return rowCount;
			}
		}
		
		/// <summary>
		/// Saves or updates the entity without its children.
		/// </summary>
		/// 
		/// <param name="entity">
		/// Entity to save or update.
		/// </param>
		/// 
		/// <param name="idGenerator">
		/// ObjectIDGenerator instance to generate IDs for objects.
		/// </param>
		/// 
		/// <param name="options">
		/// Optional options.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		internal int PersistWithChildren(ref VahapYigit.Test.Models.Role entity, ObjectIDGenerator idGenerator, SaveOptions options = null)
		{
			int rowCount = 0;

			rowCount += this.Persist(ref entity, options);

			using (var  db = new UserRoleCrud(base.UserContext))
			{
				for (int i = 0; i < entity.UserRoleCollection.Count; i++)
				{
					var child = entity.UserRoleCollection[i];
					child.IdRole = entity.Id;

					rowCount += db.PersistWithChildren(ref child, idGenerator, options);
				}
			}

			return rowCount;
		}
		
		/// <summary>
		/// Deletes the entity from the database.
		/// </summary>
		/// 
		/// <param name="entity">
		/// Entity to delete.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public override int Delete(VahapYigit.Test.Models.Role entity)
		{
			int rowCount = 0;

			if (entity != null)
			{
				rowCount = this.Delete(entity.Id);
				if (rowCount > 0)
				{				
					entity.Id = 0;
					entity.State =VahapYigit.Test.Models.EntityState.Deleted;
				}
			}

			return rowCount;
		}

		/// <summary>
		/// Deletes the entity given its unique ID.
		/// </summary>
		/// 
		/// <param name="id">
		/// Unique ID.
		/// </param>
		/// 
		/// <returns>
		/// The number of affected rows.
		/// </returns>
		public override int Delete(long id)
		{
			int rowCount = 0;

			using (var et = new ExecutionTracerService())
			using (var scope = TransactionScopeHelper.CreateDefaultTransactionScope())
			{
				this.OnDeleting(id);

				var parameters = new Dictionary<string, object>();

				parameters.Add("@Role_Id", id);

				rowCount = base.ExecuteScalar<int>("Role_Delete", parameters);

				this.OnDeleted(id);

				scope.Complete();
			}

			return rowCount;
		}

		/// <summary>
		/// Loads the UserRole entities associated to the current instance (entity.UserRole collection property).
		/// </summary>
		/// 
		/// <param name="entity">
		/// The target entity.
		/// </param>
		public void LoadUserRoleCollection(ref VahapYigit.Test.Models.Role entity)
		{
			if (entity != null && entity.IsInDb)
			{
				var options = new SearchOptions();
				options.Filters.Add(VahapYigit.Test.Models.UserRole.ColumnNames.IdRole, FilterOperator.Equals, entity.Id);

				using (var  db = new UserRoleCrud(base.UserContext))
				{
					entity.UserRoleCollection = db.Search(ref options);
				}

				foreach (var item in entity.UserRoleCollection)
				{
					item.Role = entity;
				}
			}
		}

		/// <summary>
		/// Loads the UserRole entities associated to the instances (entity.UserRole collection property).
		/// </summary>
		/// 
		/// <param name="entities">
		/// The target entity collection.
		/// </param>
		public void LoadUserRoleCollection(TCollection<VahapYigit.Test.Models.Role> entities)
		{
			if (entities != null)
			{
				var collection = entities.Where(i => i.IsInDb).ToTCollection();
				var idList = collection.Select(i => i.Id).ToList();

				var options = new SearchOptions();
				options.Filters.Add(VahapYigit.Test.Models.UserRole.ColumnNames.IdRole, FilterOperator.In, idList);

				using (var  db = new UserRoleCrud(base.UserContext))
				{
					var data = db.Search(ref options);
					foreach (var entity in collection)
					{
						entity.UserRoleCollection = data.Where(i => i.IdRole == entity.Id).ToTCollection();
					}

					foreach (var item in data)
					{
						item.Role = collection.First(i => i.Id == item.IdRole);
					}
				}
			}
		}

		/// <summary>
		/// Converts an IDataReader to a TCollection WITHOUT associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// IDataReader source.
		/// </param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.Role> Map(IDataReader dbReader)
		{
			var collection = new TCollection<VahapYigit.Test.Models.Role>();

			while (dbReader.Read())
			{
				var entity = new VahapYigit.Test.Models.Role();
				entity.Map(dbReader, base.UserContext);

				var currentRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentRole == null)
				{
					collection.Add(entity);
					currentRole = entity;
				}

				// UserRoleCollection (-> Role)...
				foreach (var child in entity.UserRoleCollection)
				{
					var e = currentRole.UserRoleCollection.FirstOrDefault(i => i.Id == child.Id);
					if (e == null)
					{
						currentRole.UserRoleCollection.Add(child);
						e = child;
					}
				}
			}

			return collection;
		}
		
		/// <summary>
		/// Converts an DataTable to a TCollection WITHOUT associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// DataTable source.
		/// </param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.Role> Map(DataTable source)
		{
			var collection = new TCollection<VahapYigit.Test.Models.Role>();

			foreach (DataRow row in source.Rows)
			{
				var entity = new VahapYigit.Test.Models.Role();
				entity.Map(row, base.UserContext);

				var currentRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentRole == null)
				{
					collection.Add(entity);
					currentRole = entity;
				}

				// UserRoleCollection (-> Role)...
				foreach (var child in entity.UserRoleCollection)
				{
					var e = currentRole.UserRoleCollection.FirstOrDefault(i => i.Id == child.Id);
					if (e == null)
					{
						currentRole.UserRoleCollection.Add(child);
						e = child;
					}
				}
			}

			return collection;
		}
		
		/// <summary>
		/// Converts an IDataReader to a TCollection WITH possible associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// IDataReader source.
		///</param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.Role> DeepMap(IDataReader dbReader)
		{
			var collection = new TCollection<VahapYigit.Test.Models.Role>();

			while (dbReader.Read())
			{
				var entity = new VahapYigit.Test.Models.Role();
				entity.DeepMap(dbReader, base.UserContext);

				var currentRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentRole == null)
				{
					collection.Add(entity);
					currentRole = entity;
				}

				// UserRoleCollection (-> Role)...
				foreach (var child in entity.UserRoleCollection)
				{
					var e = currentRole.UserRoleCollection.FirstOrDefault(i => i.Id == child.Id);
					if (e == null)
					{
						currentRole.UserRoleCollection.Add(child);
						e = child;
					}
				}
			}

			return collection;
		}
		
		/// <summary>
		/// Converts an DataTable to a TCollection WITH possible associated children (linked entities).
		/// </summary>
		/// 
		/// <param name="source">
		/// DataTable source.
		/// </param>
		/// 
		/// <returns>
		/// A collection.
		/// </returns>
		protected override TCollection<VahapYigit.Test.Models.Role> DeepMap(DataTable source)
		{
			var collection = new TCollection<VahapYigit.Test.Models.Role>();

			foreach (DataRow row in source.Rows)
			{
				var entity = new VahapYigit.Test.Models.Role();
				entity.DeepMap(row, base.UserContext);

				var currentRole = collection.FirstOrDefault(i => i.Id == entity.Id);
				if (currentRole == null)
				{
					collection.Add(entity);
					currentRole = entity;
				}

				// UserRoleCollection (-> Role)...
				foreach (var child in entity.UserRoleCollection)
				{
					var e = currentRole.UserRoleCollection.FirstOrDefault(i => i.Id == child.Id);
					if (e == null)
					{
						currentRole.UserRoleCollection.Add(child);
						e = child;
					}
				}
			}

			return collection;
		}

		#endregion

		#region [ Partial methods ]

		partial void OnSaving(ref VahapYigit.Test.Models.Role entity, SaveOptions options);
		partial void OnSaved(ref VahapYigit.Test.Models.Role entity, SaveOptions option);

		partial void OnDeleting(long id);
		partial void OnDeleted(long id);

		#endregion
	}
}
