﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFG.PWManager.BackEnd.Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionsMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionsMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TFG.PWManager.BackEnd.Domain.Resources.ExceptionsMessages", typeof(ExceptionsMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo {0} no puede estar vacío.
        /// </summary>
        public static string EmptyProperty {
            get {
                return ResourceManager.GetString("EmptyProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo {0} tiene un formato incorrecto.
        /// </summary>
        public static string FormatProperty {
            get {
                return ResourceManager.GetString("FormatProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo {0} no puede superar los {1} caracteres.
        /// </summary>
        public static string MaxLengthProperty {
            get {
                return ResourceManager.GetString("MaxLengthProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La entidad no existe.
        /// </summary>
        public static string NullEntity {
            get {
                return ResourceManager.GetString("NullEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se ha informado un módelo de entrada.
        /// </summary>
        public static string NullModel {
            get {
                return ResourceManager.GetString("NullModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo {0} no puede ser nulo.
        /// </summary>
        public static string NullProperty {
            get {
                return ResourceManager.GetString("NullProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La operación indicada no está definida.
        /// </summary>
        public static string OperatorExceptionMsg {
            get {
                return ResourceManager.GetString("OperatorExceptionMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hay uno o varios errores de validación.
        /// </summary>
        public static string ValidationExceptionMsg {
            get {
                return ResourceManager.GetString("ValidationExceptionMsg", resourceCulture);
            }
        }
    }
}
