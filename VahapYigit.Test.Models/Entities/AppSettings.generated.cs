﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Data;
	using System.Diagnostics;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using VahapYigit.Test.Core;

	/// <summary>
	/// Entity mapped to AppSettings DB table.
	/// </summary>
	[Serializable]
	[DataContract(Namespace = Globals.Namespace, IsReference = true)]
	[System.CodeDom.Compiler.GeneratedCode("LayerCake Generator", "3.7.1")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
	public partial class AppSettings : EntityBase, IAppSettings
	{
		/// <summary>
		/// Gets the name of the entity.
		/// </summary>
		public static readonly string EntityName = "AppSettings";

		#region [ Constructor ]

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AppSettings()
			: base()
		{
			this.Initialize();
		}

		#endregion

		#region [ Events ]

		#endregion

		#region [ Column Names ]

		/// <summary>
		/// Contains the entity column names.
		/// </summary>
		public static partial class ColumnNames
		{
			/// <summary>
			/// Name of the Id column ("AppSettings_Id").
			/// </summary>
			public static readonly string Id = "AppSettings_Id";

			/// <summary>
			/// Name of the Key column ("AppSettings_Key").
			/// </summary>
			public static readonly string Key = "AppSettings_Key";

			/// <summary>
			/// Name of the Value column ("AppSettings_Value").
			/// </summary>
			public static readonly string Value = "AppSettings_Value";

			/// <summary>
			/// Name of the Description column ("AppSettings_Description").
			/// </summary>
			public static readonly string Description = "AppSettings_Description";

		}

		#endregion

		#region [ Property Names ]

		/// <summary>
		/// Contains the entity property names.
		/// </summary>
		public static partial class PropertyNames
		{
			/// <summary>
			/// Name of the Id property ("Id").
			/// </summary>
			public static readonly string Id = "Id";

			/// <summary>
			/// Name of the Key property ("Key").
			/// </summary>
			public static readonly string Key = "Key";

			/// <summary>
			/// Name of the Value property ("Value").
			/// </summary>
			public static readonly string Value = "Value";

			/// <summary>
			/// Name of the Description property ("Description").
			/// </summary>
			public static readonly string Description = "Description";

		}

		#endregion

		#region [ Properties ]

		#region [ Key ]

		private string _Key;

		/// <summary>
		/// Gets or sets the Key value (MANDATORY). 
		/// </summary>
		[DebuggerHidden]
		[Required]
		[DataMember()]
		public virtual string Key
		{
			get { return _Key; }
			set
			{
				if (value != _Key)
				{
					_Key = value;

					if (!_deserializing)
					{
						base.UpdateState();
					}

					this.NotifyPropertyChanged();

					if (!_deserializing)
					{
						this.ValidateKey();
					}
				}
			}
		}

		/// <summary>
		/// Method called on Key value validation.
		/// </summary>
		/// 
		/// <param name="error">
		/// Indicates whether the Key value is valid (format, value, etc).
		/// </param>
		partial void OnKeyValidation(ref TranslationEnum? error);

		private bool ValidateKey()
		{
			bool isValid = false;

			do
			{
				if (this.Key == null)
				{
					base.AddValidationError("Key", TranslationEnum.ModelAppSettingsKeyIsRequired);
					break;
				}

				TranslationEnum? error = null;

				this.OnKeyValidation(ref error);
				if (error != null)
				{
					base.AddValidationError("Key", error.Value);
					break;
				}

				base.RemoveValidationErrors("Key");
				isValid = true;
			}
			while (false);

			return isValid;
		}

		#endregion

		#region [ Value ]

		private string _Value;

		/// <summary>
		/// Gets or sets the Value value (MANDATORY). 
		/// </summary>
		[DebuggerHidden]
		[Required]
		[DataMember()]
		public virtual string Value
		{
			get { return _Value; }
			set
			{
				if (value != _Value)
				{
					_Value = value;

					if (!_deserializing)
					{
						base.UpdateState();
					}

					this.NotifyPropertyChanged();

					if (!_deserializing)
					{
						this.ValidateValue();
					}
				}
			}
		}

		/// <summary>
		/// Method called on Value value validation.
		/// </summary>
		/// 
		/// <param name="error">
		/// Indicates whether the Value value is valid (format, value, etc).
		/// </param>
		partial void OnValueValidation(ref TranslationEnum? error);

		private bool ValidateValue()
		{
			bool isValid = false;

			do
			{
				if (this.Value == null)
				{
					base.AddValidationError("Value", TranslationEnum.ModelAppSettingsValueIsRequired);
					break;
				}

				TranslationEnum? error = null;

				this.OnValueValidation(ref error);
				if (error != null)
				{
					base.AddValidationError("Value", error.Value);
					break;
				}

				base.RemoveValidationErrors("Value");
				isValid = true;
			}
			while (false);

			return isValid;
		}

		#endregion

		#region [ Description ]

		private string _Description;

		/// <summary>
		/// Gets or sets the Description value (OPTIONAL). 
		/// </summary>
		[DebuggerHidden]
		[DataMember()]
		public virtual string Description
		{
			get { return _Description; }
			set
			{
				if (value != _Description)
				{
					_Description = value;

					if (!_deserializing)
					{
						base.UpdateState();
					}

					this.NotifyPropertyChanged();

					if (!_deserializing)
					{
						this.ValidateDescription();
					}
				}
			}
		}

		/// <summary>
		/// Method called on Description value validation.
		/// </summary>
		/// 
		/// <param name="error">
		/// Indicates whether the Description value is valid (format, value, etc).
		/// </param>
		partial void OnDescriptionValidation(ref TranslationEnum? error);

		private bool ValidateDescription()
		{
			bool isValid = false;

			do
			{
				TranslationEnum? error = null;

				this.OnDescriptionValidation(ref error);
				if (error != null)
				{
					base.AddValidationError("Description", error.Value);
					break;
				}

				base.RemoveValidationErrors("Description");
				isValid = true;
			}
			while (false);

			return isValid;
		}

		#endregion

		#endregion

		#region [ References ]

		#endregion

		#region [ EntityBase Implementation ]

		/// <summary>
		/// Gets the entity properties validity.
		/// </summary>
		/// 
		/// <param name="errors">
		/// Translation errors list (each item represents a translation key of an error).
		/// </param>
		/// 
		/// <returns>
		/// True if all the entity properties are correct; otherwise, false.
		/// </returns>
		public override bool IsValid(out IList<TranslationEnum> errors)
		{
			IList<TranslationEnum> errs = new List<TranslationEnum>();

			if (!this.ValidateKey())
			{
				var iterator = ((INotifyDataErrorInfo)this).GetErrors("Key");
				iterator.ForEach(error => errs.Add((TranslationEnum)error));
			}

			if (!this.ValidateValue())
			{
				var iterator = ((INotifyDataErrorInfo)this).GetErrors("Value");
				iterator.ForEach(error => errs.Add((TranslationEnum)error));
			}

			if (!this.ValidateDescription())
			{
				var iterator = ((INotifyDataErrorInfo)this).GetErrors("Description");
				iterator.ForEach(error => errs.Add((TranslationEnum)error));
			}

			errors = errs;

			return errors.Count == 0;
		}
		
		/// <summary>
		/// Fill the entity properties using a source.
		/// </summary>
		/// 
		/// <param name="source">
		/// Source.
		public override void Map(EntityBase source)
		{
			if (source == null)
			{
				ThrowException.ThrowArgumentNullException("source");
			}

			if (!(source is AppSettings))
			{
				ThrowException.ThrowArgumentException("The 'source' argument is not a 'AppSettings' instance");
			}

			this.Key = ((AppSettings)source).Key;
			this.Value = ((AppSettings)source).Value;
			this.Description = ((AppSettings)source).Description;

			this.Id = source.Id;
			this.State = source.State;
		}

		/// <summary>
		/// Fills the entity properties using a IDataReader object.
		/// </summary>
		/// 
		/// <param name="source">
		/// IDataReader object.
		/// </param>
		/// 
		/// <param name="userContext">
		/// User context (use base.UserContext).
		/// </param>
		/// 
		/// <param name="columnPrefix">
		/// Column prefix (optional).
		/// </param>
		public override void Map(IDataReader source, IUserContext userContext, string columnPrefix = null)
		{
			if (columnPrefix == null)
			{
				columnPrefix = string.Concat(EntityName, "_");
			}

			this.Id = TypeHelper.To<long>(source[string.Format("{0}Id", columnPrefix)]);
			this.Key = TypeHelper.To<string>(source[string.Format("{0}Key", columnPrefix)]);
			this.Value = TypeHelper.To<string>(source[string.Format("{0}Value", columnPrefix)]);
			this.Description = TypeHelper.To<string>(source[string.Format("{0}Description", columnPrefix)]);

			this.State = EntityState.None;
		}

		/// <summary>
		/// Fill the entity properties using a DataRow object.
		/// </summary>
		/// 
		/// <param name="source">
		/// DataRow object.
		/// </param>
		/// 
		/// <param name="userContext">
		/// User context (use base.UserContext).
		/// </param>
		/// 
		/// <param name="columnPrefix">
		/// Column prefix (optional).
		/// </param>
		public override void Map(DataRow source, IUserContext userContext, string columnPrefix = null)
		{
			if (columnPrefix == null)
			{
				columnPrefix = string.Concat(EntityName, "_");
			}

			this.Id = TypeHelper.To<long>(source[string.Format("{0}Id", columnPrefix)]);
			this.Key = TypeHelper.To<string>(source[string.Format("{0}Key", columnPrefix)]);
			this.Value = TypeHelper.To<string>(source[string.Format("{0}Value", columnPrefix)]);
			this.Description = TypeHelper.To<string>(source[string.Format("{0}Description", columnPrefix)]);

			this.State = EntityState.None;
		}
		
		/// <summary>
		/// Fills the entity properties and all its dependencies using a IDataReader object.
		/// </summary>
		/// 
		/// <param name="source">
		/// IDataReader object.
		/// </param>
		///
		/// <param name="userContext">
		/// User context (optional).
		/// </param>
		public override void DeepMap(IDataReader source, IUserContext userContext = null)
		{
			this.Map(source, userContext);

			this.State = EntityState.None;
		}
		
		/// <summary>
		/// Fill the entity properties and all its dependencies using a DataRow object.
		/// </summary>
		/// 
		/// <param name="source">
		/// DataRow object.
		/// </param>
		///
		/// <param name="userContext">
		/// User context (optional).
		/// </param>
		public override void DeepMap(DataRow source, IUserContext userContext = null)
		{
			this.Map(source, userContext);

			this.State = EntityState.None;
		}

		#endregion
	}
}